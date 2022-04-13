#region Russian

/*

Передача аргумента потоку

Первоначально в среде .NET Framework нельзя было передавать аргумент потоку,
когда он начинался, поскольку у метода, служившего в качестве точки входа в поток, не
могло быть параметров. Если же потоку требовалось передать какую-то информацию,
то к этой цели приходилось идти различными обходными путями, например использовать
общую переменную. Но этот недостаток был впоследствии устранен, и теперь
аргумент может быть передан потоку. Для этого придется воспользоваться другими
формами метода Start(), конструктора класса Thread, а также метода, служащего в
качестве точки входа в поток.

Аргумент передается потоку в следующей форме метода Start().

public void Start(object параметр)

Объект, указываемый в качестве аргумента параметр, автоматически передается
методу, выполняющему роль точки входа в поток. Следовательно, для того чтобы передать
аргумент потоку, достаточно передать его методу Start().

Для применения параметризированной формы метода Start() потребуется следующая
форма конструктора класса Thread:

public Thread(ParameterizedThreadStart запуск)

где запуск обозначает метод, вызываемый с целью начать выполнение потока.
Обратите внимание на то, что в этой форме конструктора запуск имеет тип
ParameterizedThreadStart, а не ThreadStart, как в форме, использовавшейся
в предыдущих примерах. В данном случае ParameterizedThreadStart является делегатом,
объявляемым следующим образом.

public delegate void ParameterizedThreadStart(object obj)

Как видите, этот делегат принимает аргумент типа object. Поэтому для правильного
применения данной формы конструктора класса Thread у метода, служащего
в качестве точки входа в поток, должен быть параметр типа object.
В приведенном ниже примере программы демонстрируется передача аргумента
потоку.

*/


// Пример передачи аргумента методу потока.

using System;
using System.Threading;

class MyThread
{
    public int Count;
    public Thread Thrd;

    // Обратите внимание на то, что конструктору класса MyThread передается также значение типа int/
    public MyThread(string name, int num)
    {
        Count = 0;

        // Вызвать конструктор типа ParameterizedThreadStart явным образом
        // только ради наглядности примера.
        Thrd = new Thread(this.Run);

        Thrd.Name = name;

        // Здесь переменная num передается методу Start() в качестве аргумента.
        Thrd.Start(num);
    }

    // Обратите внимание на то, что в этой форме метода Run() указывается параметр типа object.
    void Run(object num)
    {
        Console.WriteLine(Thrd.Name + " начат со счета " + num);

        do
        {
            Thread.Sleep(500);
            Console.WriteLine("В потоке " + Thrd.Name + ", Count = " + Count);
            Count++;
        }
        while (Count < (int)num);

        Console.WriteLine(Thrd.Name + " завершен.");
    }
}

class PassArgDemo
{
    static void Main()
    {
        // Обратите внимание на то, что число повторений передается
        // этим двум объектам типа MyThread.
        MyThread mt = new MyThread("Потомок #1", 5);
        MyThread mt2 = new MyThread("Потомок #2", 3);

        do
        {
            Thread.Sleep(100);
        }
        while (mt.Thrd.IsAlive || mt2.Thrd.IsAlive);

        Console.WriteLine("Основной поток завершен.");

        Console.ReadKey();
    }
}

/*

Ниже приведен результат выполнения данной программы, хотя у вас он может оказаться
несколько иным.

Потомок #1 начат со счета 5
Потомок #2 начат со счета 3
В потоке Потомок #2, Count = 0
В потоке Потомок #1, Count = 0
В потоке Потомок #1, Count = 1
В потоке Потомок #2, Count = 1
В потоке Потомок #2, Count = 2
Потомок #2 завершен.
В потоке Потомок #1, Count = 2
В потоке Потомок #1, Count = 3
В потоке Потомок #1, Count = 4
Потомок #1 завершен.
Основной поток завершен.

Как следует из приведенного выше результата, первый поток повторяется пять раз,
а второй — три раза. Число повторений указывается в конструкторе класса MyThread
и затем передается методу Run(), служащему в качестве точки входа в поток, с помощью
параметризированной формы ParameterizedThreadStart метода Start().

*/

#endregion

#region English

/*

Passing an Argument to a Thread

In the early days of the .NET Framework, it was not possible to pass an argument to a thread
when the thread was started because the method that serves as the entry point to a thread
could not have a parameter. If information needed to be passed to a thread, various
workarounds (such as using a shared variable) were required. However, this deficiency was
subsequently remedied, and today it is possible to pass an argument to a thread. To do so,
you must use different forms of Start(), the Thread constructor, and the entry point method.

An argument is passed to a thread through this version of Start():

public void Start(object parameter)

The object passed to parameter is automatically passed to the thread’s entry point method.
Thus, to pass an argument to a thread, you pass it to Start().

To make use of the parameterized version of Start(), you must use the following form
of the Thread constructor:

public Thread(ParameterizedThreadStart start)

Here, start specifies the method that will be called to begin execution of the thread. Notice
in this version, the type of start is ParameterizedThreadStart rather than ThreadStart, as
used by the preceding examples. ParameterizedThreadStart is a delegate that is declared as
shown here:

public delegate void ParameterizedThreadStart(object obj)

As you can see, this delegate takes an argument of type object. Therefore, to use this form
of the Thread constructor, the thread entry point method must have an object parameter.
Here is an example that demonstrates the passing of an argument to a thread:

*/

// Passing an argument to the thread method. 

//using System;  
//using System.Threading;  

//class MyThread
//{
//    public int Count;
//    public Thread Thrd;

//    // Notice that MyThread is also pass an int value. 
//    public MyThread(string name, int num)
//    {
//        Count = 0;

//        // Explicitly invoke ParameterizedThreadStart constructor 
//        // for the sake of illustration. 
//        Thrd = new Thread(this.Run);

//        Thrd.Name = name;

//        // Here, Start() is passed num as an argument. 
//        Thrd.Start(num);
//    }

//    // Notice that this version of Run() has 
//    // a parameter of type object. 
//    void Run(object num)
//    {
//        Console.WriteLine(Thrd.Name +
//                          " starting with count of " + num);

//        do
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("In " + Thrd.Name +
//                              ", Count is " + Count);
//            Count++;
//        } while (Count < (int)num);

//        Console.WriteLine(Thrd.Name + " terminating.");
//    }
//}

//class PassArgDemo
//{
//    static void Main()
//    {

//        // Notice that the iteration count is passed 
//        // to these two MyThread objects. 
//        MyThread mt = new MyThread("Child #1", 5);
//        MyThread mt2 = new MyThread("Child #2", 3);

//        do
//        {
//            Thread.Sleep(100);
//        } while (mt.Thrd.IsAlive | mt2.Thrd.IsAlive);

//        Console.WriteLine("Main thread ending.");

//        Console.ReadKey();
//    }
//}

/*

The output is shown here. (The actual output you see may vary.)

Child #1 starting with count of 5
Child #2 starting with count of 3
In Child #2, Count is 0
In Child #1, Count is 0
In Child #1, Count is 1
In Child #2, Count is 1
In Child #2, Count is 2
Child #2 terminating.
In Child #1, Count is 2
In Child #1, Count is 3
In Child #1, Count is 4
Child #1 terminating.
Main thread ending.

As the output shows, the first thread iterates five times and the second thread iterates three
times. The iteration count is specified in the MyThread constructor and then passed to the
thread entry method Run() through the use of the ParameterizedThreadStart version of
Start().

*/

#endregion