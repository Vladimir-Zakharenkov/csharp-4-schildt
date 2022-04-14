#region Russian

/*

Отмена задачи и обработка исключения AggregateException

В версии 4.0 среды .NET Framework внедрена новая подсистема, обеспечивающая
структурированный, хотя и очень удобный способ отмены задачи. Эта новая подсистема
основывается на понятии признака отмены. Признаки отмены поддерживаются в
классе Task, среди прочего, с помощью фабричного метода StartNew().

ПРИМЕЧАНИЕ
Новую подсистему отмены можно применять и для отмены потоков, рассматривавшихся
в предыдущей главе, но она полностью интегрирована в TPL и PLINQ. Именно поэтому эта
подсистема рассматривается в этой главе.

Отмена задачи, как правило, выполняется следующим образом. Сначала получается
признак отмены из источника признаков отмены. Затем этот признак передается
задаче, после чего она должна контролировать его на предмет получения запроса
на отмену. (Этот запрос может поступить только из источника признаков
отмены.) Если получен запрос на отмену, задача должна завершиться. В одних случаях
этого оказывается достаточно для простого прекращения задачи без каких-
либо дополнительных действий, а в других — из задачи должен быть вызван метод
ThrowIfCancellationRequested() для признака отмены. Благодаря этому в отменяющем
коде становится известно, что задача отменена. А теперь рассмотрим процесс
отмены задачи более подробно.

Признак отмены является экземпляром объекта типа CancellationToken,
т.е. структуры, определенной в пространстве имен System.Threading. В структуре
CancellationToken определено несколько свойств и методов, но мы воспользуемся
двумя из них. Во-первых, это доступное только для чтения свойство
IsCancellationRequested, которое объявляется следующим образом.

public bool IsCancellationRequested { get; }

Оно возвращает логическое значение true, если отмена задачи была запрошена для
вызывающего признака, а иначе — логическое значение false. И во-вторых, это метод
ThrowIfCancellationRequested(), который объявляется следующим образом.

public void ThrowIfCancellationRequested()

Если признак отмены, для которого вызывается этот метод, получил запрос на отмену,
то в данном методе генерируется исключение OperationCanceledException.
В противном случае никаких действий не выполняется. В отменяющем коде можно
организовать отслеживание упомянутого исключения с целью убедиться в том, что
отмена задачи действительно произошла. Как правило, с этой целью сначала перехватывается
исключение AggregateException, а затем его внутреннее исключение
анализируется с помощью свойства InnerException или InnerExceptions. (Свойство
InnerExceptions представляет собой коллекцию исключений. Подробнее о коллекциях
речь пойдет в главе 25.)

Признак отмены получается из источника признаков отмены, который представляет
собой объект класса CancellationTokenSource, определенного в пространстве
имен System. Threading. Для того чтобы получить данный признак, нужно
создать сначала экземпляр объекта типа CancellationTokenSource. (С этой
целью можно воспользоваться вызываемым по умолчанию конструктором класса
CancellationTokenSource.) Признак отмены, связанный с данным источником, оказывается
доступным через используемое только для чтения свойство Token, которое
объявляется следующим образом.

public CancellationToken Token { get; }

Это и есть тот признак, который должен быть передан отменяемой задаче.

Для отмены в задаче должна быть получена копия признака отмены и организован
контроль этого признака с целью отслеживать саму отмену. Такое отслеживание
можно организовать тремя способами: опросом, методом обратного вызова и с помощью
дескриптора ожидания. Проще всего организовать опрос, и поэтому здесь будет
рассмотрен именно этот способ. С целью опроса в задаче проверяется упомянутое
выше свойство IsCancellationRequested признака отмены. Если это свойство содержит
логическое значение true, значит, отмена была запрошена, и задача должна 
быть завершена. Опрос может оказаться весьма эффективным, если организовать
его правильно. Так, если задача содержит вложенные циклы, то проверка свойства
IsCancellationRequested во внешнем цикле зачастую дает лучший результат, чем
его проверка на каждом шаге внутреннего цикла.

Для создания задачи, из которой вызывается метод ThrowIfCancellationRequested(),
когда она отменяется, обычно требуется передать признак отмены как самой задаче,
так и конструктору класса Task, будь то непосредственно или же косвенно через метод
StartNew(). Передача признака отмены самой задаче позволяет изменить состояние отменяемой
задачи в запросе на отмену из внешнего кода. Далее будет использована следующая
форма метода StartNew().

public Task StartNew(Action<Object> action, Object состояние, CancellationToken признак_отмены)

В этой форме признак отмены передается через параметры, обозначаемые как
состояние и признак_отмены. Это означает, что признак отмены будет передан как
делегату, реализующему задачу, так и самому экземпляру объекта типа Task. Ниже
приведена форма, поддерживающая делегат Action.

public delegate void Action<in T>(T obj)

В данном случае обобщенный параметр Т обозначает тип Object. В силу этого
объект obj должен быть приведен внутри задачи к типу CancellationToken.

И еще одно замечание: по завершении работы с источником признаков отмены
следует освободить его ресурсы, вызвав метод Dispose().

Факт отмены задачи может быть проверен самыми разными способами. Здесь применяется
следующий подход: проверка значения свойства IsCanceled для экземпляра
объекта типа Task. Если это логическое значение true, то задача была отменена.

*/

#endregion

#region English

/*

Cancelling a Task and Using AggregateException

The .NET Framework 4.0 adds a new subsystem that provides a structured, yet highly
flexible way to cancel tasks. This new mechanism is based on the cancellation token.
Cancellation tokens are supported by the Task class, and through the StartNew() factory
method (among others).

NOTE
The new cancellation subsystem can also be used to cancel threads, which were described in
the previous chapter. However, it is fully integrated into the TPL and PLINQ. For this reason, it
is described here.

In general, here is how task cancellation works. A cancellation token is obtained from a
cancellation token source. This token is then passed to the task. The task must then monitor
that token for a cancellation request. (This request can come only from the cancellation
token source.) If a cancellation request is received, the task must end. Sometimes it is
sufficient for the task to simply stop, taking no further action. Other times, the task should
call ThrowIfCancellationRequested() on the cancellation token. This lets the canceling
code know that the task was cancelled. Now, we will look at the cancellation process in detail.

A cancellation token is an instance of CancellationToken, which is a structure defined in
System.Threading. It defines several properties and methods. We will use two of them. The
first is the read-only property IsCancellationRequested. It is shown here:

public bool IsCancellationRequested { get; }

It returns true if cancellation has been requested on the invoking token and false otherwise.
The second member that we will use is the ThrowIfCancellationRequested() method. It is
shown here:

public void ThrowIfCancellationRequested()

If the cancellation token on which it is called has received a cancellation request, then this
method will throw an OperationCanceledException. Otherwise, it takes no action. The
cancelling code can watch for this exception to confirm that cancellation did, indeed, occur.
This is normally done by catching AggregateException and then examining the inner
exception, via the InnerException or InnerExceptions properties. (InnerExceptions is
a collection of exceptions. Collections are described in Chapter 25.)

A cancellation token is obtained from a cancellation source. This is an object of
CancellationTokenSource, which is defined in System.Threading. To obtain a token, first
create a CancellationTokenSource instance. (You can use its default constructor for this
purpose.) The cancellation token associated with that source is available through the readonly
Token property, which is shown here:

public CancellationToken Token { get; }

This is the token that must be passed to the task that you want to be able to cancel.

To use cancellation, the task must receive a copy of the cancellation token and then
monitor that token, watching for cancellation. There are three ways to watch for
cancellation: polling, using a callback method, and using a wait handle. The easiest is
polling, and that is the approach used here. To use polling, the task will check the
IsCancellationRequested property of the cancellation token, described earlier. If this
property is true, cancellation has been requested and the task should terminate. Polling
can be quite efficient if it is done appropriately. For example, if a task contains nested loops,
then checking IsCancellationRequested in the outer loop would often be better than
checking it with each iteration of the inner loop.

To create a task that calls ThrowIfCancellationRequested() when cancelled, you will
often want to pass the cancellation token to both the task and the Task constructor, whether
directly or indirectly through the StartNew() method. Passing the cancellation token to the
task enables a cancellation request by outside code to change the state of the task to be
cancelled. Here, we will use this version of StartNew():

public Task StartNew(Action<Object> action, Object state, CancellationToken cancellationToken)

In this use, the cancellation token will be passed to both state and cancellationToken. This means
that the cancellation token will be passed to both the delegate that implements the task and
to the Task instance, itself. The form of Action that supports this is shown here:

public delegate void Action<in T>(T obj)

In this case, T is Object. Because of this, inside the task, obj must be cast to CancellationToken.
One other point: when you are done with the token source, you should release its
resources by calling Dispose().

There are various ways to determine if a task has been cancelled. The approach used here
is to test the value of IsCanceled on the Task instance. If it is true, the task was cancelled.

*/

#endregion