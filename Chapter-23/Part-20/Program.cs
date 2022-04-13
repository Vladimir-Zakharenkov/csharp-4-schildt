#region Russian

/*

Применение событий

Для синхронизации в C# предусмотрен еще один тип объекта: событие. Существуют
две разновидности событий: устанавливаемые в исходное состояние вручную и автоматически.
Они поддерживаются в классах ManualResetEvent и AutoResetEvent
соответственно. Эти классы являются производными от класса EventWaitHandle, находящегося
на верхнем уровне иерархии классов, и применяются в тех случаях, когда
один поток ожидает появления некоторого события в другом потоке. Как только такое
событие появляется, второй поток уведомляет о нем первый поток, позволяя тем самым
возобновить его выполнение.

Ниже приведены конструкторы классов ManualResetEvent и AutoResetEvent.

public ManualResetEvent(bool initialState)
public AutoResetEvent(bool initialState)

Если в обеих формах параметр initialState имеет логическое значение true, то
о событии первоначально уведомляется. А если он имеет логическое значение false,
то о событии первоначально не уведомляется.

Применяются события очень просто. Так, для события типа ManualResetEvent
порядок применения следующий. Поток, ожидающий некоторое событие, вызывает
метод WaitOne() для событийного объекта, представляющего данное событие. Если
событийный объект находится в сигнальном состоянии, то происходит немедленный
возврат из метода WaitOne(). В противном случае выполнение вызывающего потока
приостанавливается до тех пор, пока не будет получено уведомление о событии. Как
только событие произойдет в другом потоке, этот поток установит событийный объект
в сигнальное состояние, вызвав метод Set(). Поэтому метод Set() следует рассматривать
как уведомляющий о том, что событие произошло. После установки событийного
объекта в сигнальное состояние произойдет немедленный возврат из метода
WaitOne(), и первый поток возобновит свое выполнение. А в результате вызова метода
Reset() событийный объект возвращается в несигнальное состояние.

Событие типа AutoResetEvent отличается от события типа ManualResetEvent
лишь способом установки в исходное состояние. Если для события типа
ManualResetEvent событийный объект остается в сигнальном состоянии до тех пор,
пока не будет вызван метод Reset(), то для события типа AutoResetEvent событийный
объект автоматически переходит в несигнальное состояние, как только поток,
ожидающий это событие, получит уведомление о нем и возобновит свое выполнение.
Поэтому если применяется событие типа AutoResetEvent, то вызывать метод
Reset() необязательно.
В приведенном ниже примере программы демонстрируется применение события
типа ManualResetEvent.

*/

// Использовать событийный объект, устанавливаемый в исходное состояние вручную.

using System;
using System.Threading;

// Этот поток уведомляет о том, что событие передано его конструктору.
class MyThread
{
    public Thread Thrd;
    ManualResetEvent mre;

    public MyThread(string name, ManualResetEvent evt)
    {
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        mre = evt;
        Thrd.Start();
    }

    // Точка входа в поток.
    void Run()
    {
        Console.WriteLine("Внутри потока " + Thrd.Name);

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(Thrd.Name);
            Thread.Sleep(1000);
        }

        Console.WriteLine(Thrd.Name + " завершен!");

        // Уведомить о событии.
        mre.Set();
    }
}

class ManualEventDemo
{
    static void Main()
    {
        ManualResetEvent evtObj = new ManualResetEvent(false);

        MyThread mt1 = new MyThread("Событийный поток 1", evtObj);

        Console.WriteLine("Основной поток ожидает событие.");

        // Ожидать уведомление о событии.
        evtObj.WaitOne();

        Console.WriteLine("Основной поток получил уведомление о событии от превого потока.");

        // Установить событийный объект в исходное состояние.
        evtObj.Reset();

        MyThread mt2 = new MyThread("Событийный поток 2", evtObj);

        // Ожидать уведомления о событии.
        evtObj.WaitOne();

        Console.WriteLine("Основной поток получил уведомление о событии от второго потока.");
    }
}

/*

Ниже приведен результат выполнения рассматриваемой здесь программы, хотя у
вас он может оказаться несколько иным.

В потоке Событийный Поток 1
Событийный Поток 1
Основной поток ожидает событие.
Событийный Поток 1
Событийный Поток 1
Событийный Поток 1
Событийный Поток 1
Событийный Поток 1 завершен!
Основной поток получил уведомление о событии от первого потока.
В потоке Событийный Поток 2
Событийный Поток 2
Событийный Поток 2
Событийный Поток 2
Событийный Поток 2
Событийный Поток 2
Событийный Поток 2 завершен!
Основной поток получил уведомление о событии от второго потока.

Прежде всего обратите внимание на то, что событие типа ManualResetEvent
передается непосредственно конструктору класса MyThread. Когда завершается метод
Run() из класса MyThread, он вызывает для событийного объекта метод Set(),
устанавливающий этот объект в сигнальное состояние. В методе Main() формируется
событийный объект evtObj типа ManualResetEvent, первоначально устанавливаемый
в исходное, несигнальное состояние. Затем создается экземпляр объекта типа
MyThread, которому передается событийный объект evtObj. После этого основной
поток ожидает уведомления о событии. А поскольку событийный объект evtObj первоначально
находится в несигнальном состоянии, то основной поток вынужден ожидать
до тех пор, пока для экземпляра объекта типа MyThread не будет вызван метод
Set(), устанавливающий событийный объект evtObj в сигнальное состояние. Это
дает возможность основному потоку возобновить свое выполнение. Затем событийный
объект устанавливается в исходное состояние, и весь процесс повторяется, но на этот
раз для второго потока. Если бы не событийный объект, то все потоки выполнялись
бы одновременно, а результаты их выполнения оказались бы окончательно запутанными.
Для того чтобы убедиться в этом, попробуйте закомментировать вызов метода
WaitOne() в методе Main().

Если бы в рассматриваемой здесь программе событийный объект типа
AutoResetEvent использовался вместо событийного объекта типа ManualResetEvent,
то вызывать метод Reset() в методе Main() не пришлось бы. Ведь в этом случае событийный
объект автоматически устанавливается в несигнальное состояние, когда поток,
ожидающий данное событие, возобновляет свое выполнение. Для опробования
этой разновидности события замените в данной программе все ссылки на объект типа
ManualResetEvent ссылками на объект типа AutoResetEvent и удалите все вызовы метода
Reset(). Видоизмененная версия программы будет работать так же, как и прежде.

*/

#endregion

#region English

/*

Using Events

C# supports another type of synchronization object: the event. There are two types of
events: manual reset and auto reset. These are supported by the classes ManualResetEvent
and AutoResetEvent. These classes are derived from the top-level class EventWaitHandle.
These classes are used in situations in which one thread is waiting for some event to occur
in another thread. When the event takes place, the second thread signals the first, allowing
it to resume execution.

The constructors for ManualResetEvent and AutoResetEvent are shown here:

public ManualResetEvent(bool initialState)
public AutoResetEvent(bool initialState)

Here, if initialState is true, the event is initially signaled. If initialState is false, the event is
initially non-signaled.

Events are easy to use. For a ManualResetEvent, the procedure works like this. A thread
that is waiting for some event simply calls WaitOne() on the event object representing that
event.WaitOne() returns immediately if the event object is in a signaled state. Otherwise,
it suspends execution of the calling thread until the event is signaled. After another thread
performs the event, that thread sets the event object to a signaled state by calling Set().
Thus, a call Set() can be understood as signaling that an event has occurred. After the event
object is set to a signaled state, the call to WaitOne() will return and the first thread will
resume execution. The event is returned to a non-signaled state by calling Reset().

The difference between AutoResetEvent and ManualResetEvent is how the event gets
reset. For ManualResetEvent, the event remains signaled until a call to Reset() is made.
For AutoResetEvent, the event automatically changes to a non-signaled state as soon as a
thread waiting on that event receives the event notification and resumes execution. Thus,
a call to Reset() is not necessary when using AutoResetEvent.

Here is an example that illustrates ManualResetEvent:

*/

// Use a manual event object.   

//using System;    
//using System.Threading;    

//// This thread signals the event passed to its constructor.   
//class MyThread
//{
//    public Thread Thrd;
//    ManualResetEvent mre;

//    public MyThread(string name, ManualResetEvent evt)
//    {
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        mre = evt;
//        Thrd.Start();
//    }

//    // Entry point of thread.    
//    void Run()
//    {
//        Console.WriteLine("Inside thread " + Thrd.Name);

//        for (int i = 0; i < 5; i++)
//        {
//            Console.WriteLine(Thrd.Name);
//            Thread.Sleep(500);
//        }

//        Console.WriteLine(Thrd.Name + " Done!");

//        // Signal the event. 
//        mre.Set();
//    }
//}

//class ManualEventDemo
//{
//    public static void Main()
//    {
//        ManualResetEvent evtObj = new ManualResetEvent(false);

//        MyThread mt1 = new MyThread("Event Thread 1", evtObj);

//        Console.WriteLine("Main thread waiting for event.");

//        // Wait for signaled event. 
//        evtObj.WaitOne();

//        Console.WriteLine("Main thread received first event.");


//        // Reset the event. 
//        evtObj.Reset();


//        mt1 = new MyThread("Event Thread 2", evtObj);

//        // Wait for signaled event. 
//        evtObj.WaitOne();

//        Console.WriteLine("Main thread received second event.");
//    }
//}

/*

The output is shown here. (The actual output you see may vary slightly.)

Inside thread Event Thread 1
Event Thread 1
Main thread waiting for event.
Event Thread 1
Event Thread 1
Event Thread 1
Event Thread 1
Event Thread 1 Done!
Main thread received first event.
Inside thread Event Thread 2
Event Thread 2
Event Thread 2
Event Thread 2
Event Thread 2
Event Thread 2
Event Thread 2 Done!
Main thread received second event.

First, notice that MyThread is passed a ManualResetEvent in its constructor. When
MyThread’s Run() method finishes, it calls Set() on that event object, which puts the
event object into a signaled state. Inside Main(), a ManualResetEvent called evtObj is
created with an initially unsignaled state. Then, a MyThread instance is created and passed
evtObj. Next, the main thread waits on the event object. Because the initial state of evtObj
is not signaled, this causes the main thread to wait until the instance of MyThread calls Set(),
which puts evtObj into a signaled state. This allows the main thread to run again. Then the
event is reset and the process is repeated for the second thread. Without the use of the event
object, all threads would have run simultaneously and their output would have been jumbled.
To verify this, try commenting out the call to WaitOne() inside Main().

In the preceding program, if an AutoResetEvent object rather than a ManualResetEvent
object were used, then the call to Reset() in Main() would not be necessary. The reason is that
the event is automatically set to a non-signaled state when a thread waiting on the event is
resumed. To try this, simply change all references to ManualResetEvent to AutoResetEvent
and remove the calls to Reset(). This version will execute the same as before.

*/

#endregion