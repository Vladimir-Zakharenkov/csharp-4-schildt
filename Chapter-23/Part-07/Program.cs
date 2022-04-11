#region Russian

/*

Еще один способ отслеживания момента окончания состоит в вызове метода
Join(). Ниже приведена его простейшая форма.

public void Join()

Метод Join() ожидает до тех пор, пока поток, для которого он был вызван, не
завершится. Его имя отражает принцип ожидания до тех пор, пока вызывающий поток
не присоединится к вызванному методу. Если же данный поток не был начат, то
генерируется исключение ThreadStateException. В других формах метода Join()
можно указать максимальный период времени, в течение которого следует ожидать
завершения указанного потока.

В приведенном ниже примере программы метод Join() используется для того,
чтобы основной поток завершился последним.

*/

// Использовать метод Join().

using System;
using System.Threading;

class MyThread
{
    public int Count;
    public Thread Thrd;

    public MyThread(string name)
    {
        Count = 0;
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        Thrd.Start();
    }

    // Точка входа в поток.
    void Run()
    {
        Console.WriteLine(Thrd.Name + " начат.");

        do
        {
            Thread.Sleep(500);
            Console.WriteLine("В потоке " + Thrd.Name + ", Count = " + Count);
            Count++;
        }
        while (Count < 10);

        Console.WriteLine(Thrd.Name + " завершен.");
    }
}

// Использовать метод Join() для ожидания до тех пор, пока потоки не завершатся.
class JoinThread
{
    static void Main()
    {
        Console.WriteLine("Основной поток начат.");

        // Сконструировать три потока.
        MyThread mt1 = new MyThread("Потомок #1");
        MyThread mt2 = new MyThread("Потомок #2");
        MyThread mt3 = new MyThread("Потомок #3");

        mt1.Thrd.Join();
        Console.WriteLine("Потомок #1 присоединен.");

        mt2.Thrd.Join();
        Console.WriteLine("Потомок #2 присоединен.");

        mt3.Thrd.Join();
        Console.WriteLine("Потомок #3 присоединен.");

        Console.WriteLine("Основной поток завершен.");

        Console.ReadKey();
    }
}

/*

Ниже приведен один из возможных результатов выполнения этой программы. Напомним,
что он может отличаться в зависимости от среды выполнения, операционной
системы и прочих факторов, влияющих на выполнение программы.

Основной поток начат.
Потомок #1 начат.
Потомок #2 начат.
Потомок #3 начат.
В потоке Потомок #1, Count = 0
В потоке Потомок #2, Count = 0
В потоке Потомок #3, Count = 0
В потоке Потомок #1, Count = 1
В потоке Потомок #2, Count = 1
В потоке Потомок #3, Count = 1
В потоке Потомок #1, Count = 2
В потоке Потомок #2, Count = 2
В потоке Потомок #3, Count = 2
В потоке Потомок #1, Count = 3
В потоке Потомок #2, Count = 3
В потоке Потомок #3, Count = 3
В потоке Потомок #1, Count = 4
В потоке Потомок #2, Count = 4
В потоке Потомок #3, Count = 4
В потоке Потомок #1, Count = 5
В потоке Потомок #2, Count = 5
В потоке Потомок #3, Count = 5
В потоке Потомок #1, Count = 6
В потоке Потомок #2, Count = 6
В потоке Потомок #3, Count = 6
В потоке Потомок #1, Count = 7
В потоке Потомок #2, Count = 7
В потоке Потомок #3, Count = 7
В потоке Потомок #1, Count = 8
В потоке Потомок #2, Count = 8
В потоке Потомок #3, Count = 8
В потоке Потомок #1, Count = 9
Потомок #1 завершен.
В потоке Потомок #2, Count = 9
Потомок #2 завершен.
В потоке Потомок #3, Count = 9
Потомок #3 завершен.
Потомок #1 присоединен.
Потомок #2 присоединен.
Потомок #3 присоединен.
Основной поток завершен.

Как видите, выполнение потоков завершилось после возврата из последовательного
ряда вызовов метода Join().

*/

#endregion

#region English

/*

Another way to wait for a thread to finish is to call Join( ). Its simplest form is shown here:

public void Join()

Join( ) waits until the thread on which it is called terminates. Its name comes from the concept
of the calling thread waiting until the specified thread joins it. A ThreadStateException will be
thrown if the thread has not been started. Additional forms of Join( ) allow you to specify a
maximum amount of time that you want to wait for the specified thread to terminate.

Here is a program that uses Join( ) to ensure that the main thread is the last to stop:

*/

// Use Join(). 

//using System; 
//using System.Threading; 

//class MyThread
//{
//    public int Count;
//    public Thread Thrd;

//    public MyThread(string name)
//    {
//        Count = 0;
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start();
//    }

//    // Entry point of thread. 
//    void Run()
//    {
//        Console.WriteLine(Thrd.Name + " starting.");

//        do
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("In " + Thrd.Name +
//                              ", Count is " + Count);
//            Count++;
//        } while (Count < 10);

//        Console.WriteLine(Thrd.Name + " terminating.");
//    }
//}

//// Use Join() to wait for threads to end. 
//class JoinThreads
//{
//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // Construct three threads. 
//        MyThread mt1 = new MyThread("Child #1");
//        MyThread mt2 = new MyThread("Child #2");
//        MyThread mt3 = new MyThread("Child #3");

//        mt1.Thrd.Join();
//        Console.WriteLine("Child #1 joined.");

//        mt2.Thrd.Join();
//        Console.WriteLine("Child #2 joined.");

//        mt3.Thrd.Join();
//        Console.WriteLine("Child #3 joined.");

//        Console.WriteLine("Main thread ending.");

//        Console.ReadKey();
//    }
//}

/*

Sample output from this program is shown here. Remember when you try the program,
your output may vary slightly.

Main thread starting.
Child #1 starting.
Child #2 starting.
Child #3 starting.
In Child #1, Count is 0
In Child #2, Count is 0
In Child #3, Count is 0
In Child #1, Count is 1
In Child #2, Count is 1
In Child #3, Count is 1
In Child #1, Count is 2
In Child #2, Count is 2
In Child #3, Count is 2
In Child #1, Count is 3
In Child #2, Count is 3
In Child #3, Count is 3
In Child #1, Count is 4
In Child #2, Count is 4
In Child #3, Count is 4
In Child #1, Count is 5
In Child #2, Count is 5
In Child #3, Count is 5
In Child #1, Count is 6
In Child #2, Count is 6
In Child #3, Count is 6
In Child #1, Count is 7
In Child #2, Count is 7
In Child #3, Count is 7
In Child #1, Count is 8
In Child #2, Count is 8
In Child #3, Count is 8
In Child #1, Count is 9
Child #1 terminating.
In Child #2, Count is 9
Child #2 terminating.
In Child #3, Count is 9
Child #3 terminating.
Child #1 joined.
Child #2 joined.
Child #3 joined.
Main thread ending.

As you can see, after the calls to Join() return, the threads have stopped executing.

*/

#endregion