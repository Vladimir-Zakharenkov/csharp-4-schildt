#region Russian

/*

Прежде чем переходить к чтению следующего раздела, убедитесь сами, если, конечно,
сомневаетесь, в том, что следует обязательно вызывать методы Wait() и Pulse(),
чтобы имитируемые часы шли правильно. Для этого подставьте приведенный ниже
вариант класса TickTock в рассматриваемую здесь программу. В этом варианте все
вызовы методов Wait() и Pulse() исключены.

*/

// Нерабочий вариант класса TickTock.

using System;
using System.Threading;

class TickTock
{
    object lockOn = new();

    public void Tick(bool running)
    {
        lock (lockOn)
        {
            if (!running) // остановить часы
            {
                return;
            }

            Console.Write("\nтик-");
        }
    }

    public void Tock(bool running)
    {
        lock (lockOn)
        {
            if (!running) // остановить часы
            {
                return;
            }

            Console.Write("так");
        }
    }
}

class MyThread
{
    public Thread Thrd;
    TickTock ttob;

    // Сконструировать новый поток.
    public MyThread(string name, TickTock tt)
    {
        Thrd = new Thread(this.Run);
        ttob = tt;
        Thrd.Name = name;
        Thrd.Start();
    }

    // Начать выполнение нового потока.
    void Run()
    {
        if (Thrd.Name == "Tick")
        {
            for (int i = 0; i < 5; i++)
            {
                ttob.Tick(true);
            }

            ttob.Tick(false);
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                ttob.Tock(true);
            }

            ttob.Tock(false);
        }
    }
}

class TickingClock
{
    static void Main()
    {
        TickTock tt = new();
        MyThread mt1 = new MyThread("Tick", tt);
        MyThread mt2 = new MyThread("Tock", tt);

        mt1.Thrd.Join();
        mt2.Thrd.Join();

        Console.WriteLine("\nЧасы остановлены");
    }
}

/*

После этой подстановки результат выполнения данной программы будет выглядеть
следующим образом.

тик тик тик тик тик так
так
так
так
так
Часы остановлены

Очевидно, что методы Tick() и Тосk() больше не синхронизированы!

*/

#endregion

#region English

/*

Before moving on, if you have any doubt that the calls to Wait() and Pulse() are
actually needed to make the “clock” run right, substitute this version of TickTock into
the preceding program. It has all calls to Wait() and Pulse() removed.

*/

// A non-functional version of TickTock.

//using System; 
//using System.Threading; 

//class TickTock
//{

//    object lockOn = new object();

//    public void Tick(bool running)
//    {
//        lock (lockOn)
//        {
//            if (!running)
//            { // stop the clock 
//                return;
//            }

//            Console.Write("Tick ");
//        }
//    }

//    public void Tock(bool running)
//    {
//        lock (lockOn)
//        {
//            if (!running)
//            { // stop the clock 
//                return;
//            }

//            Console.WriteLine("Tock");
//        }
//    }
//}

//public void Tock(bool running)
//{
//    lock (lockOn)
//    {
//        if (!running)
//        { // stop the clock 
//            Monitor.Pulse(lockOn); // notify any waiting threads 
//            return;
//        }

//        Console.WriteLine("Tock");
//        Monitor.Pulse(lockOn); // let Tick() run 

//        Monitor.Wait(lockOn); // wait for Tick() to complete 
//    }
//}
//}

//class MyThread
//{
//    public Thread Thrd;
//    TickTock ttOb;

//    // Construct a new thread. 
//    public MyThread(string name, TickTock tt)
//    {
//        Thrd = new Thread(this.Run);
//        ttOb = tt;
//        Thrd.Name = name;
//        Thrd.Start();
//    }

//    // Begin execution of new thread. 
//    void Run()
//    {
//        if (Thrd.Name == "Tick")
//        {
//            for (int i = 0; i < 5; i++) ttOb.Tick(true);
//            ttOb.Tick(false);
//        }
//        else
//        {
//            for (int i = 0; i < 5; i++) ttOb.Tock(true);
//            ttOb.Tock(false);
//        }
//    }
//}

//class TickingClock
//{
//    static void Main()
//    {
//        TickTock tt = new TickTock();
//        MyThread mt1 = new MyThread("Tick", tt);
//        MyThread mt2 = new MyThread("Tock", tt);

//        mt1.Thrd.Join();
//        mt2.Thrd.Join();
//        Console.WriteLine("Clock Stopped");
//    }
//}

/*

After the substitution, the output produced by the program will look like this:

Tick Tick Tick Tick Tick Tock
Tock
Tock
Tock
Tock
Clock Stopped

Clearly, the Tick( ) and Tock( ) methods are no longer synchronized!

*/

#endregion