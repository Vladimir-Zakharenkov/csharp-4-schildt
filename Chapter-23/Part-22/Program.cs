#region Russian

/*

Классы синхронизации, внедренные в версии .NET Framework 4.0

Рассматривавшиеся ранее классы синхронизации, в том числе Semaphore и
AutoResetEvent, были доступны в среде .NET Framework, начиная с версии 1.1.
Таким образом, эти классы образуют основу поддержки синхронизации в среде .NET
Framework. Но после выпуска версии .NET Framework 4.0 появился ряд новых альтернатив
этим классам синхронизации. Все они перечисляются ниже.

Класс                       Назначение

Barrier                     Вынуждает потоки ожидать появления всех остальных потоков
                            в указанной точке, называемой барьерной

CountdownEvent              Выдает сигнал, когда обратный отсчет завершается

ManualResetEventSlim        Это упрощенный вариант класса ManualResetEvent

SemaphoreSlim               Это упрощенный вариант класса Semaphore

Если вам понятно, как пользоваться основными классами синхронизации, описанными
ранее в этой главе, то у вас не должно возникнуть затруднений при использовании
их новых альтернатив и дополнений.

Прерывание потока

Иногда поток полезно прервать до его нормального завершения. Например, отладчику
может понадобиться прервать вышедший из-под контроля поток. После прерывания
поток удаляется из системы и не может быть начат снова.

Для прерывания потока до его нормального завершения служит метод Thread.Abort(). 
Ниже приведена простейшая форма этого метода.

public void Abort()

Метод Abort() создает необходимые условия Для генерирования исключения
ThreadAbortException в том потоке, для которого он был вызван. Это исключение
приводит к прерыванию потока и может быть перехвачено и в коде программы, но
в этом случае оно автоматически генерируется еще раз, чтобы остановить поток. Метод
Abort() не всегда способен остановить поток немедленно, поэтому если поток
требуется остановить перед тем, как продолжить выполнение программы, то после
метода Abort() следует сразу же вызвать метод Join(). Кроме того, в самых редких
случаях методу Abort() вообще не удается остановить поток. Это происходит, например,
в том случае, если кодовый блок finally входит в бесконечный цикл.

В приведенном ниже примере программы демонстрируется применение метода
Abort() для прерывания потока.

*/

// Прервать поток с помощью метода Abort().

using System;
using System.Threading;

class MyThread
{
    public Thread Thrd;

    public MyThread(string name)
    {
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        Thrd.Start();
    }

    // Это точка входа в поток.
    void Run()
    {
        Console.WriteLine(Thrd.Name + " начат.");

        for (int i = 0; i <= 1000; i++)
        {
            Console.Write(i + " ");
            if ((i % 10) == 0)
            {
                Console.WriteLine();
                Thread.Sleep(250);
            }
        }

        Console.WriteLine(Thrd.Name + " завершен.");
    }
}

class StopDemo
{
    static void Main()
    {
        MyThread mt1 = new MyThread("Мой поток");

        Thread.Sleep(1000); // разрешить порожденному потоку начать свое выполнение

        Console.WriteLine("Прерывание потока.");
        mt1.Thrd.Abort();

        mt1.Thrd.Join(); // ожидать прерывания потока

        Console.WriteLine("Основной поток прерван.");
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

Мой Поток начат
1 2 3 4 5 6 7 8 9 10
11 12 13 14 15 16 17 18 19 20
21 22 23 24 25 26 27 28 29 30
31 32 33 34 35 36 37 38 39 40
Прерывание потока.
Основной поток прерван.

ПРИМЕЧАНИЕ
Метод Abort() не следует применять в качестве обычного средства прерывания потока,
поскольку он предназначен для особых случаев. Обычно поток должен завершаться естественным
образом, чтобы произошел возврат из метода, выполняющего роль точки входа в него.

*/

#endregion

#region English

/*

Synchronization Classes Added by .NET 4.0

The synchronization classes discussed by the foregoing sections, such as Semaphore and
AutoResetEvent, have been available in earlier versions of the .NET Framework, with some
going as far back as .NET 1.1. As a result, these classes form the core of .NET’s support for
synchronization. However, with the release of .NET 4.0, several new synchronization
alternatives have been added. They are shown here:

Class                               Purpose

Barrier                             Causes threads to wait at a specified point 
                                    (called the barrier) until all threads arrive.

CountdownEvent                      Raises a signal when a countdown completes.

ManualResetEventSlim                A lightweight version of ManualResetEvent.

SemaphoreSlim                       A lightweight version of Semaphore.

If you understand how to use the core synchronization classes described earlier, then
you will have no trouble using these additions.

Terminating a Thread Via Abort()

It is sometimes useful to stop a thread prior to its normal conclusion, even when the new
cancellation subsystem is used. For example, a debugger may need to stop a thread that has
run wild. Once a thread has been terminated, it is removed from the system and cannot be
restarted.

To terminate a thread prior to its normal conclusion, use Thread.Abort( ). Its simplest
form is shown here:

public void Abort()

Abort() causes a ThreadAbortException to be thrown to the thread on which Abort() is
called. This exception causes the thread to terminate. This exception can also be caught by
your code (but is automatically rethrown in order to stop the thread). Abort() may not
always be able to stop a thread immediately, so if it is important that a thread be stopped
before your program continues, you will need to follow a call to Abort() with a call to Join( ).
Also, in rare cases, it is possible that Abort() won’t be able to stop a thread. One way this
could happen is if a finally block goes into an infinite loop.

The following example shows how to stop a thread by use of Abort():

*/

// Stopping a thread by use of Abort(). 

//using System; 
//using System.Threading; 

//class MyThread
//{
//    public Thread Thrd;

//    public MyThread(string name)
//    {
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start();
//    }

//    // This is the entry point for thread.  
//    void Run()
//    {
//        Console.WriteLine(Thrd.Name + " starting.");

//        for (int i = 1; i <= 1000; i++)
//        {
//            Console.Write(i + " ");
//            if ((i % 10) == 0)
//            {
//                Console.WriteLine();
//                Thread.Sleep(250);
//            }
//        }
//        Console.WriteLine(Thrd.Name + " exiting.");
//    }
//}

//class StopDemo
//{
//    static void Main()
//    {
//        MyThread mt1 = new MyThread("My Thread");

//        Thread.Sleep(1000); // let child thread start executing 

//        Console.WriteLine("Stopping thread.");
//        mt1.Thrd.Abort();

//        mt1.Thrd.Join(); // wait for thread to terminate 

//        Console.WriteLine("Main thread terminating.");
//    }
//}

/*

NOTE
Abort() should not be used as the normal means of stopping a thread. It is meant for
specialized situations. Usually, a thread should end because its entry point method returns.

*/

#endregion