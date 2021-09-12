#region Russian

/*

Отмена действия метода Abort()

Запрос на преждевременное прерывание может быть переопределен в самом
потоке. Для этого необходимо сначала перехватить в потоке исключение
ThreadAbortException, а затем вызвать метод ResetAbort(). Благодаря этому
исключается повторное генерирование исключения по завершении обработчика исключения,
прерывающего данный поток. Ниже приведена форма объявления метода
ResetAbort().

public static void ResetAbort()

Вызов метода ResetAbort() может завершиться неудачно, если в потоке отсутствует
надлежащий режим надежной отмены преждевременного прерывания потока.

В приведенном ниже примере программы демонстрируется применение метода
ResetAbort().

*/

// Использовать метод ResetAbort().

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
            try
            {
                Console.Write(i + " ");

                if ((i % 10) == 0)
                {
                    Console.WriteLine();
                    Thread.Sleep(250);
                }
            }
            catch (ThreadAbortException exc)
            {

                if ((int)exc.ExceptionState == 0)
                {
                    Console.WriteLine("Прерывание потока отменено! Код завершения " + exc.ExceptionState);
                    Thread.ResetAbort();
                }
                else
                {
                    Console.WriteLine("Поток прерван, код завершения " + exc.ExceptionState);
                }
            }
        }

        Console.WriteLine(Thrd.Name + " завершен нормально.");
    }
}

class ResetAbort
{
    static void Main()
    {
        MyThread mt1 = new MyThread("Мой поток");

        Thread.Sleep(1000); // разрешить порожденному потоку начать свое выполнение

        Console.WriteLine("Прерывание потока.");
        mt1.Thrd.Abort(0); // это не остановит поток

        Thread.Sleep(1000); // разрешить порожденному потоку выполняться подольше

        Console.WriteLine("Прерывание потока.");
        mt1.Thrd.Abort(100); // а это остановит поток

        mt1.Thrd.Join(); // ожидать прерывание потока

        Console.WriteLine("Основной поток прерван.");
    }
}

/*

Ниже приведен результат выполнения этой программы.

Мой Поток начат
1 2 3 4 5 6 7 8 9 10
11 12 13 14 15 16 17 18 19 20
21 22 23 24 25 26 27 28 29 30
31 32 33 34 35 36 37 38 39 40
Прерывание потока.
Прерывание потока отменено! Код завершения 0
41 42 43 44 45 46 47 48 49 50
51 52 53 54 55 56 57 58 59 60
61 62 63 64 65 66 67 68 69 70
71 72 73 74 75 76 77 78 79 80
Поток прерван, код завершения 100
Основной поток прерван.

Если в данном примере программы метод Abort() вызывается с нулевым аргументом,
то запрос на преждевременное прерывание отменяется потоком, вызывающим
метод ResetAbort(), и выполнение этого потока продолжается. Любое другое значение
аргумента приведет к прерыванию потока.

*/

#endregion

#region English

/*

Canceling Abort()

A thread can override a request to abort. To do so, the thread must catch the
ThreadAbortException and then call ResetAbort( ). This prevents the exception
from being automatically rethrown when the thread’s exception handler ends.
ResetAbort() is declared like this:

public static void ResetAbort()

A call to ResetAbort() can fail if the thread does not have the proper security setting to
cancel the abort.

The following program demonstrates ResetAbort():

*/

// Using ResetAbort(). 

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
//            try
//            {
//                Console.Write(i + " ");
//                if ((i % 10) == 0)
//                {
//                    Console.WriteLine();
//                    Thread.Sleep(250);
//                }
//            }
//            catch (ThreadAbortException exc)
//            {
//                if ((int)exc.ExceptionState == 0)
//                {
//                    Console.WriteLine("Abort Cancelled! Code is " +
//                                       exc.ExceptionState);
//                    Thread.ResetAbort();
//                }
//                else
//                    Console.WriteLine("Thread aborting, code is " +
//                                       exc.ExceptionState);
//            }
//        }
//        Console.WriteLine(Thrd.Name + " exiting normally.");
//    }
//}

//class ResetAbort
//{
//    static void Main()
//    {
//        MyThread mt1 = new MyThread("My Thread");

//        Thread.Sleep(1000); // let child thread start executing 

//        Console.WriteLine("Stopping thread.");
//        mt1.Thrd.Abort(0); // this won't stop the thread 

//        Thread.Sleep(1000); // let child execute a bit longer 

//        Console.WriteLine("Stopping thread.");
//        mt1.Thrd.Abort(100); // this will stop the thread 

//        mt1.Thrd.Join(); // wait for thread to terminate 

//        Console.WriteLine("Main thread terminating.");
//    }
//}


/*

The output is shown here:

My Thread starting.
1 2 3 4 5 6 7 8 9 10
11 12 13 14 15 16 17 18 19 20
21 22 23 24 25 26 27 28 29 30
31 32 33 34 35 36 37 38 39 40
Stopping thread.
Abort Cancelled! Code is 0
41 42 43 44 45 46 47 48 49 50
51 52 53 54 55 56 57 58 59 60
61 62 63 64 65 66 67 68 69 70
71 72 73 74 75 76 77 78 79 80
Stopping thread.
Thread aborting, code is 100
Main thread terminating.

In this example, if Abort() is called with an argument that equals zero, then the abort
request is cancelled by the thread by calling ResetAbort( ), and the thread’s execution
continues. Any other value causes the thread to stop.


*/

#endregion