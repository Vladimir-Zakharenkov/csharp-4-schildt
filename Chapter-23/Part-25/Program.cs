#region Russian

/*

Приостановка и возобновление потока

В первоначальных версиях среды .NET Framework поток можно было приостановить
вызовом метода Thread.Suspend() и возобновить вызовом метода Thread.Resume(). 
Но теперь оба эти метода считаются устаревшими и не рекомендуются к
применению в новом коде. Объясняется это, в частности, тем, что пользоваться методом
Suspend() на самом деле небезопасно, так как с его помощью можно приостановить
поток, который в настоящий момент удерживает блокировку, что препятствует
ее снятию, а следовательно, приводит к взаимоблокировке. Применение обоих методов
может стать причиной серьезных осложнений на уровне системы. Поэтому для
приостановки и возобновления потока следует использовать другие средства синхронизации,
в том числе мьютекс и семафор.

Определение состояния потока

Состояние потока может быть получено из свойства ThreadState, доступного в
классе Thread. Ниже приведена общая форма этого свойства.

public ThreadState ThreadState{ get; }

Состояние потока возвращается в виде значения, определенного в перечислении
ThreadState. Ниже приведены значения, определенные в этом перечислении.

ThreadState.Aborted             ThreadState.AbortRequested
ThreadState.Background          ThreadState.Running
ThreadState.Stopped             ThreadState.StopRequested
ThreadState.Suspended           ThreadState.SuspendRequested
ThreadState.Unstarted           ThreadState.WaitSleepJoin

Все эти значения не требуют особых пояснений, за исключением одного. Значение
ThreadState.WaitSleepJoin обозначает состояние, в которое поток переходит во
время ожидания в связи с вызовом метода Wait(), Sleep() или Join().

Применение основного потока

Как пояснялось в самом начале этой главы, у всякой программы на C# имеется хотя
бы один поток исполнения, называемый основным. Этот поток программа получает
автоматически, как только начинает выполняться. С основным потоком можно обращаться
таким же образом, как и со всеми остальными потоками.

Для доступа к основному потоку необходимо получить объект типа Thread, который
ссылается на него. Это делается с помощью свойства CurrentThread, являющегося
членом класса Thread. Ниже приведена общая форма этого свойства.

public static Thread CurrentThread{ get; }

Данное свойство возвращает ссылку на тот поток, в котором оно используется. Поэтому
если свойство CurrentThread используется при выполнении кода в основном
потоке, то с его помощью можно получить ссылку на основной поток. Имея в своем
распоряжении такую ссылку, можно управлять основным потоком так же, как и любым
другим потоком.

В приведенном ниже примере программы сначала получается ссылка на основной
поток, а затем получаются и устанавливаются имя и приоритет основного потока.

*/

// Продемонстрировать управление основным потоком.

using System;
using System.Threading;

class useMain
{
    static void Main()
    {
        Thread Thrd;

        // Получить основной поток.
        Thrd = Thread.CurrentThread;

        // Отобразить имя основного потока.
        if (Thrd.Name == null)
        {
            Console.WriteLine("У основного потока нет имени.");
        }
        else
        {
            Console.WriteLine("Основной поток называется:" + Thrd.Name);
        }

        // Отобразить приоритет основного патока.
        Console.WriteLine("Приоритет: " + Thrd.Priority);
        Console.WriteLine();

        // Установить имя и приоритет.
        Console.WriteLine("Установка имени и приоритета.\n");

        Thrd.Name = "Основной поток";
        Thrd.Priority = ThreadPriority.AboveNormal;

        Console.WriteLine("Теперь основной поток называется: " + Thrd.Name);
        Console.WriteLine("Теперь приоритет: " + Thrd.Priority);
    }
}

/*

Ниже приведен результат выполнения этой программы.

У основного потока нет имени.
Приоритет: Normal
Установка имени и приоритета.
Теперь основной поток называется: Основной Поток
Теперь приоритет: AboveNormal

Следует, однако, быть очень внимательным, выполняя операции с основным потоком.
Так, если добавить в конце метода Main() следующий вызов метода Join():

Thrd.Join();

программа никогда не завершится, поскольку она будет ожидать окончания основного
потока!

*/

#endregion

#region English

/*

Suspending and Resuming a Thread

In early versions of the .NET Framework, a thread could be suspended by calling
Thread.Suspend() and resumed by calling Thread.Resume(). Today, however, both
of these methods are marked as obsolete and should not be used for new code. One reason
is that Suspend() is inherently dangerous because it can be used to suspend a thread that is
currently holding a lock, thus preventing the lock from being released, resulting in deadlock.
This can cause a systemwide problem. You must use C#’s other synchronization features,
such as a mutex, to suspend and resume a thread.

Determining a Thread’s State

The state of a thread can be obtained from the ThreadState property provided by Thread.
It is shown here:

public ThreadState ThreadState{ get; }

The state of the thread is returned as a value defined by the ThreadState enumeration. It
defines the following values:

ThreadState.Aborted         ThreadState.AbortRequested
ThreadState.Background      ThreadState.Running
ThreadState.Stopped         ThreadState.StopRequested
ThreadState.Suspended       ThreadState.SuspendRequested
ThreadState.Unstarted       ThreadState.WaitSleepJoin

All but one of these values is self-explanatory. The one that needs some explanation is
ThreadState.WaitSleepJoin. A thread enters this state when it is waiting because of a call
toWait(), Sleep(), or Join().

Using the Main Thread

As mentioned at the start of this chapter, all C# programs have at least one thread of
execution, called the main thread, which is given to the program automatically when it
begins running. The main thread can be handled just like all other threads.

To access the main thread, you must obtain a Thread object that refers to it. You do this
through the CurrentThread property, which is a member of Thread. Its general form is
shown here:

public static Thread CurrentThread{ get; }

This property returns a reference to the thread in which it is used. Therefore, if you use
CurrentThread while execution is inside the main thread, you will obtain a reference to the
main thread. Once you have this reference, you can control the main thread just like any
other thread.

The following program obtains a reference to the main thread and then gets and sets the
main thread’s name and priority:

*/

// Control the main thread. 

//using System; 
//using System.Threading; 

//class UseMain
//{
//    static void Main()
//    {
//        Thread Thrd;

//        // Get the main thread. 
//        Thrd = Thread.CurrentThread;

//        // Display main thread's name. 
//        if (Thrd.Name == null)
//            Console.WriteLine("Main thread has no name.");
//        else
//            Console.WriteLine("Main thread is called: " + Thrd.Name);

//        // Display main thread's priority. 
//        Console.WriteLine("Priority: " + Thrd.Priority);

//        Console.WriteLine();

//        // Set the name and priority. 
//        Console.WriteLine("Setting name and priority.\n");
//        Thrd.Name = "Main Thread";
//        Thrd.Priority = ThreadPriority.AboveNormal;

//        Console.WriteLine("Main thread is now called: " +
//                           Thrd.Name);

//        Console.WriteLine("Priority is now: " +
//                           Thrd.Priority);
//    }
//}

/*

The output from the program is shown here:

Main thread has no name.
Priority: Normal
Setting name and priority.
Main thread is now called: Main Thread
Priority is now: AboveNormal

One word of caution: You need to be careful about what operations you perform on the
main thread. For example, if you add this call to Join( ) to the end of Main(),

Thrd.Join();

the program will never terminate because it will be waiting for the main thread to end!

*/

#endregion