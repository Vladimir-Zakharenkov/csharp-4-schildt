#region Russian

/*

Простые способы усовершенствования многопоточной программы

Рассмотренная выше программа вполне работоспособна, но ее можно сделать более
эффективной, внеся ряд простых усовершенствований. Во-первых, можно сделать
так, чтобы выполнение потока начиналось сразу же после его создания. Для этого достаточно
получить экземпляр объекта типа Thread в конструкторе класса MyThread.
И во-вторых, в классе MyThread совсем не обязательно хранить имя потока, поскольку
для этой цели в классе Thread специально определено свойство Name.

public string Name { get; set; }

Свойство Name доступно для записи и чтения и поэтому может служить как для
запоминания, так и для считывания имени потока.

Ниже приведена версия предыдущей программы, в которую внесены упомянутые
выше усовершенствования.

*/

// Другой способ запуска потока.

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
        Thrd.Name = name; // задать имя потока
        Thrd.Start(); // начать поток
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

        Console.WriteLine(Thrd.Name + " Завершен.");
    }
}

class MultiThreadImprove
{
    static void Main()
    {
        Console.WriteLine("Основной поток начат.");

        // Сначала сконструировать объект типа MyThread.
        MyThread mt = new MyThread("Поток #1");

        do
        {
            Console.Write(".");
            Thread.Sleep(100);
        } while (mt.Count != 10);

        Console.WriteLine("Основной поток завершен.");

        Console.ReadKey();
    }
}

/*

Эта версия программы дает такой же результат, как и предыдущая. Обратите внимание
на то, что объект потока сохраняется в переменной Thrd из класса MyThread.

*/

#endregion

#region English

/*

Some Simple Improvements

While the preceding program is perfectly valid, some easy improvements will make it more
efficient. First, it is possible to have a thread begin execution as soon as it is created. In the
case of MyThread, this is done by instantiating a Thread object inside MyThread’s
constructor. Second, there is no need for MyThread to store the name of the thread since
Thread defines a property called Name that can be used for this purpose. Name is defined
like this:

public string Name { get; set; }

Since Name is a read-write property, you can use it to set the name of a thread or to retrieve
the thread’s name.

Here is a version of the preceding program that makes these three improvements:

*/

// An alternate way to start a thread. 

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
//        Thrd.Name = name; // set the name of the thread 
//        Thrd.Start(); // start the thread 
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

//class MultiThreadImproved
//{
//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // First, construct a MyThread object. 
//        MyThread mt = new MyThread("Child #1");

//        do
//        {
//            Console.Write(".");
//            Thread.Sleep(100);
//        } while (mt.Count != 10);

//        Console.WriteLine("Main thread ending.");

//        Console.ReadKey();
//    }
//}

/*

This version produces the same output as before. Notice that the thread object is stored in
Thrd inside MyThread.

*/

#endregion