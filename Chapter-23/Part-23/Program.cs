#region Russian

/*

Другая форма метода Abort()

В некоторых случаях оказывается полезной другая форма метода Abort(), приведенная
ниже в общем виде:

public void Abort (object stateInfo)

где stateInfo обозначает любую информацию, которую требуется передать потоку,
когда он останавливается. Эта информация доступна посредством свойства
ExceptionState из класса исключения ThreadAbortException. Подобным образом
потоку можно передать код завершения. В приведенном ниже примере программы
демонстрируется применение данной формы метода Abort().

*/

// Использовать форму метода Abort (object stateInfo).

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
        try
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

            Console.WriteLine(Thrd.Name + " завершен нормально.");
        }
        catch (ThreadAbortException exc)
        {

            Console.WriteLine("Поток прерван, код завершения " + exc.ExceptionState);
        }
    }
}

class UseAltAbort
{
    static void Main()
    {
        MyThread mt1 = new MyThread("Мой поток");

        Thread.Sleep(1000); // разрешить порожденному потоку начать свое выполнение

        Console.WriteLine("Прерывание потока.");

        mt1.Thrd.Abort(1000);

        mt1.Thrd.Join(); // ожидать прерывание потока

        Console.WriteLine("Основной поток прерван.");
    }
}

/*

Эта программа дает следующий результат.

Мой Поток начат
1 2 3 4 5 6 7 8 9 10
11 12 13 14 15 16 17 18 19 20
21 22 23 24 25 26 27 28 29 30
31 32 33 34 35 36 37 38 39 40
Прерывание потока.
Поток прерван, код завершения 100
Основной поток прерван.

Как следует из приведенного выше результата, значение 100 передается методу
Abort() в качестве кода прерывания. Это значение становится затем доступным посредством
свойства ExceptionState из класса исключения ThreadAbortException,
которое перехватывается потоком при его прерывании.

*/

#endregion

#region English

/*

An Abort() Alternative

You might find a second form of Abort() useful in some cases. Its general form is shown
here:

public void Abort(object stateInfo)

Here, stateInfo contains any information that you want to pass to the thread when it is
being stopped. This information is accessible through the ExceptionState property of
ThreadAbortException. You might use this to pass a termination code to a thread. The
following program demonstrates this form of Abort():

*/

// Using Abort(object). 

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
//        try
//        {
//            Console.WriteLine(Thrd.Name + " starting.");

//            for (int i = 1; i <= 1000; i++)
//            {
//                Console.Write(i + " ");
//                if ((i % 10) == 0)
//                {
//                    Console.WriteLine();
//                    Thread.Sleep(250);
//                }
//            }
//            Console.WriteLine(Thrd.Name + " exiting normally.");
//        }
//        catch (ThreadAbortException exc)
//        {
//            Console.WriteLine("Thread aborting, code is " +
//                               exc.ExceptionState);
//        }
//    }
//}

//class UseAltAbort
//{
//    static void Main()
//    {
//        MyThread mt1 = new MyThread("My Thread");

//        Thread.Sleep(1000); // let child thread start executing 

//        Console.WriteLine("Stopping thread.");
//        mt1.Thrd.Abort(100);

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
Thread aborting, code is 100
Main thread terminating.

As the output shows, the value 100 is passed to Abort( ). This value is then accessed
through the ExceptionState property of the ThreadAbortException caught by the thread
when it is terminated.

*/

#endregion