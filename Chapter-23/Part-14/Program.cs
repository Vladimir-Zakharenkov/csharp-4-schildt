#region Russian

/*

Сообщение между потоками с помощью методов Wait(), Pulse() и PulseAll()

Рассмотрим следующую ситуацию. Поток Т выполняется в кодовом блоке lock,
и ему требуется доступ к ресурсу R, который временно недоступен. Что же тогда делать
потоку Т? Если поток Т войдет в организованный в той или иной форме цикл опроса,
ожидая освобождения ресурса R, то тем самым он свяжет соответствующий объект,
блокируя доступ к нему других потоков. Это далеко не самое оптимальное решение,
поскольку оно лишает отчасти преимуществ программирования для многопоточной
среды. Более совершенное решение заключается в том, чтобы временно освободить
объект и тем самым дать возможность выполняться другим потокам. Такой подход
основывается на некоторой форме сообщения между потоками, благодаря которому
один поток может уведомлять другой о том, что он заблокирован и что другой поток
может возобновить свое выполнение. Сообщение между потоками организуется в C# с
помощью методов Wait(), Pulse() и PulseAll().

Методы Wait(), Pulse() и PulseAll() определены в классе Monitor и могут
вызываться только из заблокированного фрагмента блока. Они применяются следующим
образом. Когда выполнение потока временно заблокировано, он вызывает метод
Wait(). В итоге поток переходит в состояние ожидания, а блокировка с соответствующего
объекта снимается, что дает возможность использовать этот объект в другом потоке.
В дальнейшем ожидающий поток активизируется, когда другой поток войдет в
аналогичное состояние блокировки, и вызывает метод Pulse() или PulseAll(). При
вызове метода Pulse() возобновляется выполнение первого потока, ожидающего своей
очереди на получение блокировки. А вызов метода PulseAll() сигнализирует о
снятии блокировки всем ожидающим потокам.

Ниже приведены две наиболее часто используемые формы метода Wait().

public static bool Wait(object obj)
public static bool Wait(object obj, int миллисекунд_простоя)

В первой форме ожидание длится вплоть до уведомления об освобождении объекта,
а во второй форме — как до уведомления об освобождении объекта, так и до истечения
периода времени, на который указывает количество миллисекунд_простоя.
В обеих формах obj обозначает объект, освобождение которого ожидается.

Ниже приведены общие формы методов Pulse() и PulseAll():

public static void Pulse(object obj)
public static void PulseAll(object obj)

где obj обозначает освобождаемый объект.

Если методы Wait(), Pulse() и PulseAll() вызываются из кода, находящегося
за пределами синхронизированного кода, например из блока lock, то генерируется
исключение SynchronizationLockException.

*/

#endregion

#region English

/*

Thread Communication Using Wait(), Pulse(), and PulseAll()

Consider the following situation. A thread called T is executing inside a lock block and needs
access to a resource, called R, that is temporarily unavailable. What should T do? If T enters
some form of polling loop that waits for R, then T ties up the lock, blocking other threads’
access to it. This is a less than optimal solution because it partially defeats the advantages of
programming for a multithreaded environment. A better solution is to have T temporarily
relinquish the lock, allowing another thread to run. When R becomes available, T can be
notified and resume execution. Such an approach relies upon some form of interthread
communication in which one thread can notify another that it is blocked and be notified when
it can resume execution. C# supports interthread communication with the Wait(), Pulse(),
and PulseAll() methods.

TheWait(), Pulse(), and PulseAll() methods are defined by the Monitor class. These
methods can be called only from within a locked block of code. Here is how they are used.
When a thread is temporarily blocked from running, it calls Wait(). This causes the thread
to go to sleep and the lock for that object to be released, allowing another thread to acquire
the lock. At a later point, the sleeping thread is awakened when some other thread enters the
same lock and calls Pulse() or PulseAll(). A call to Pulse() resumes the first thread in the
queue of threads waiting for the lock. A call to PulseAll() signals the release of the lock to
all waiting threads.

Here are two commonly used forms of Wait():

public static bool Wait(object obj)
public static bool Wait(object obj, int millisecondsTimeout)

The first form waits until notified. The second form waits until notified or until the specified
period of milliseconds has expired. For both, obj specifies the object upon which to wait.
Here are the general forms for Pulse() and PulseAll():

public static void Pulse(object obj)
public static void PulseAll(object obj)

Here, obj is the object being released.

A SynchronizationLockException will be thrown if Wait(), Pulse(), or PulseAll() is
called from code that is not within synchronized code, such as a lock block.

*/

#endregion