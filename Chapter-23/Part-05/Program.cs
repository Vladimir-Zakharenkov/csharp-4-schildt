#region Russian

/*

Создание нескольких потоков

В предыдущих примерах программ был создан лишь один порожденный поток.
Но в программе можно породить столько потоков, сколько потребуется. Например,
в следующей программе создаются три порожденных потока.

*/

// Создать несколько потоков исполнения.

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
        } while (Count < 10);

        Console.WriteLine(Thrd.Name + " завершен.");
    }
}

class MoreThreads
{
    static void Main()
    {
        Console.WriteLine("Основной поток начат.");

        // Сконструировать три потока.
        MyThread mt1 = new MyThread("Потомок #1");
        MyThread mt2 = new MyThread("Потомок #2");
        MyThread mt3 = new MyThread("Потомок #3");

        do
        {
            Console.Write(".");
            Thread.Sleep(100);
        } while (mt1.Count < 10 || mt2.Count < 10 || mt3.Count < 10);

        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Основной поток завершен.");

        Console.ReadKey();
    }
}

/*

Ниже приведен один из возможных результатов выполнения этой программы

Основной поток начат.
.Потомок #1 начат.
Потомок #2 начат.
Потомок #3 начат.
....В потоке Потомок #1, Count = 0
В потоке Потомок #2, Count = 0
В потоке Потомок #3, Count = 0
.....В потоке Потомок #1, Count = 1
В потоке Потомок #2, Count = 1
В потоке Потомок #3, Count = 1
.....В потоке Потомок #1, Count = 2
В потоке Потомок #2, Count = 2
В потоке Потомок #3, Count = 2
.....В потоке Потомок #1, Count = 3
В потоке Потомок #2, Count = 3
В потоке Потомок #3, Count = 3
.....В потоке Потомок #1, Count = 4
В потоке Потомок #2, Count = 4
В потоке Потомок #3, Count = 4
.....В потоке Потомок #1, Count = 5
В потоке Потомок #2, Count = 5
В потоке Потомок #3, Count = 5
.....В потоке Потомок #1, Count = 6
В потоке Потомок #2, Count = 6
В потоке Потомок #3, Count = 6
.....В потоке Потомок #1, Count = 7
В потоке Потомок #2, Count = 7
В потоке Потомок #3, Count = 7
.....В потоке Потомок #1, Count = 8
В потоке Потомок #2, Count = 8
В потоке Потомок #3, Count = 8
.....В потоке Потомок #1, Count = 9
Поток #1 завершен.
В потоке Потомок #2, Count = 9
Поток #2 завершен.
В потоке Потомок #3, Count = 9
Поток #3 завершен.
Основной поток завершен.

Как видите, после того как все три потока начнут выполняться, они будут совместно
использовать ЦП. Приведенный выше результат может отличаться в зависимости от
среды выполнения, операционной системы и других внешних факторов, влияющих на
выполнение программы.

*/

#endregion

#region English

/*

Creating Multiple Threads

The preceding examples have created only one child thread. However, your program can
spawn as many threads as it needs. For example, the following program creates three child
threads:

*/

// Create multiple threads of execution.

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

//class MoreThreads
//{
//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // Construct three threads. 
//        MyThread mt1 = new MyThread("Child #1");
//        MyThread mt2 = new MyThread("Child #2");
//        MyThread mt3 = new MyThread("Child #3");

//        do
//        {
//            Console.Write(".");
//            Thread.Sleep(100);
//        } while (mt1.Count < 10 ||
//                 mt2.Count < 10 ||
//                 mt3.Count < 10);

//        Console.WriteLine("Main thread ending.");

//        Console.ReadKey();
//    }
//}

/*

Sample output from this program is shown next:

Main thread starting.
.Child #1 starting.
Child #2 starting.
Child #3 starting.
....In Child #1, Count is 0
In Child #2, Count is 0
In Child #3, Count is 0
.....In Child #1, Count is 1
In Child #2, Count is 1
In Child #3, Count is 1
.....In Child #1, Count is 2
In Child #2, Count is 2
In Child #3, Count is 2
.....In Child #1, Count is 3
In Child #2, Count is 3
In Child #3, Count is 3
.....In Child #1, Count is 4
In Child #2, Count is 4
In Child #3, Count is 4
.....In Child #1, Count is 5
In Child #2, Count is 5
In Child #3, Count is 5
.....In Child #1, Count is 6
In Child #2, Count is 6
In Child #3, Count is 6
.....In Child #1, Count is 7
In Child #2, Count is 7
In Child #3, Count is 7
.....In Child #1, Count is 8
In Child #2, Count is 8
In Child #3, Count is 8
.....In Child #1, Count is 9
Child #1 terminating.
In Child #2, Count is 9
Child #2 terminating.
In Child #3, Count is 9
Child #3 terminating.
Main thread ending.

As you can see, once started, all three child threads share the CPU. Again, because of
differences among system configurations, operating systems, and other environmental
factors, when you run the program, the output you see may differ slightly from that shown
here.

*/

#endregion