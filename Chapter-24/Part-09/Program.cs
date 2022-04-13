#region Russian

/*

Вызов метода Dispose()

В классе Task реализуется интерфейс IDisposable, в котором определяется метод
Dispose(). Ниже приведена форма его объявления.

public void Dispose()

Метод Dispose() реализуется в классе Task, освобождая ресурсы, используемые
этим классом. Как правило, ресурсы, связанные с классом Task, освобождаются автоматически
во время "сборки мусора" (или по завершении программы). Но если эти
ресурсы требуется освободить еще раньше, то для этой цели служит метод Dispose().
Это особенно важно в тех программах, где создается большое число задач, оставляемых
на произвол судьбы.

Следует, однако, иметь в виду, что метод Dispose() можно вызывать для отдельной
задачи только после ее завершения. Следовательно, для выяснения факта завершения
отдельной задачи, прежде чем вызывать метод Dispose(), потребуется некоторый
механизм, например, вызов метода Wait(). Именно поэтому так важно было
рассмотреть метод Wait(), перед тем как обсуждать метод Dispose(). Ели же попытаться
вызвать Dispose() для все еще активной задачи, то будет сгенерировано исключение
InvalidOperationException.

Во всех примерах, приведенных в этой главе, создаются довольно короткие задачи,
которые сразу же завершаются, и поэтому применение метода Dispose() в этих примерах
не дает никаких преимуществ. (Именно по этой причине вызывать метод Dispose()
в приведенных выше программах не было никакой необходимости. Ведь все они завершались,
как только завершалась задача, что в конечном итоге приводило к освобождению от
остальных задач.) Но в целях демонстрации возможностей данного метода и во избежание
каких-либо недоразумений метод Dispose() будет вызываться явным образом при
непосредственном обращении с экземплярами объектов типа Task во всех последующих
примерах программ. Если вы обнаружите отсутствие вызовов метода Dispose() в исходном
коде, полученном из других источников, то не удивляйтесь этому. Опять же, если
программа завершается, как только завершится задача, то вызывать метод Dispose() нет
никакого смысла — разве что в целях демонстрации его применения.

*/

#endregion

#region English

/*

Calling Dispose()

The Task class implements the IDisposable interface, which specifies the Dispose()
method. It has this form:

public void Dispose()

As implemented by Task, Dispose() releases the resources used by the Task. In general, the
resources associated with a Task are automatically released when the Task is subjected to
garbage collection (or when the program terminates). However, to release those resources
before then, call Dispose(). This is especially important in a program in which large
numbers of tasks are created and then abandoned.
It is important to understand that Dispose() can be called on a task only after it has
completed. Thus, you will need to use some mechanism, such as Wait(), to determine that
a task has completed before calling Dispose(). This is why it was necessary to describe the
Wait() method prior to discussing Dispose(). It you do try to call Dispose() on a still active
task, an InvalidOperationException will be generated.
Because all of the examples in this chapter create few tasks, are quite short, and end
immediately, calls to Dispose() are of essentially no benefit. (This is why it was not
necessary to call Dispose() in the preceding programs; they all end as soon as the tasks end,
thus resulting in the disposal of the tasks.) However, so as to demonstrate its use and to
avoid confusion in this regard, all subsequent examples will call Dispose() explicitly when
working directly with Task instances. However, don’t be surprised if you see example code
from other sources that do not. Again, if a program will be ending as soon as a task ends,
then there is essentially no point is calling Dispose()—aside from demonstrating its use.

*/

#endregion