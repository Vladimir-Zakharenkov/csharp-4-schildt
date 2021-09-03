#region Russian

/*

Определение момента окончания потока

Нередко оказывается полезно знать, когда именно завершается поток. В предыдущих
примерах программ для этой цели отслеживалось значение переменной Count.
Но ведь это далеко не лучшее и не совсем пригодное для обобщения решение. Правда,
в классе Thread имеются два других средства для определения момента окончания
потока. С этой целью можно, прежде всего, опросить доступное только для чтения
свойство IsAlive, определяемое следующим образом.

public bool IsAlive { get; }

Свойство IsAlive возвращает логическое значение true, если поток, для которого
оно вызывается, по-прежнему выполняется. Для "опробования" свойства IsAlive
подставьте приведенный ниже фрагмент кода вместо кода в классе MoreThread из
предыдущей версии многопоточной программы, как показано ниже.

*/

// Использовать свойство IsAlive для отслеживания момента окончания потоков.

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
        } while (mt1.Thrd.IsAlive && mt2.Thrd.IsAlive && mt3.Thrd.IsAlive);

        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Основной поток завершен.");

        Console.ReadKey();
    }
}

/*

При выполнении этой версии программы результат получается таким же, как
и прежде. Единственное отличие заключается в том, что в ней используется свойство
IsAlive для отслеживания момента окончания порожденных потоков.

*/

#endregion

#region English

/*

Determining When a Thread Ends

Often it is useful to know when a thread has ended. In the preceding examples, this was
accomplished by watching the Count variable—hardly a satisfactory or generalizable
solution. Fortunately, Thread provides two means by which you can determine whether a
thread has ended. First, you can interrogate the read-only IsAlive property for the thread.
It is defined like this:

public bool IsAlive { get; }

IsAlive returns true if the thread upon which it is called is still running. It returns false
otherwise. To try IsAlive, substitute this version of MoreThreads for the one shown in the
preceding program:

*/

// Use IsAlive to wait for threads to end.

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
//        } while (mt1.Thrd.IsAlive && mt2.Thrd.IsAlive && mt3.Thrd.IsAlive);

//        Console.WriteLine("Main thread ending.");

//        Console.ReadKey();
//    }
//}

/*

This version produces the same output as before. The only difference is that it uses IsAlive
to wait for the child threads to terminate.

*/

#endregion