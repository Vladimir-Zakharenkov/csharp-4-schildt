#region Russian

/*

Класс Thread

Система многопоточной обработки основывается на классе Thread, который инкапсулирует
поток исполнения. Класс Thread является герметичным, т.е. он не может
наследоваться. В классе Thread определен ряд методов и свойств, предназначенных
для управления потоками. На протяжении всей этой главы будут рассмотрены наиболее
часто используемые члены данного класса.

Создание и запуск потока

Для создания потока достаточно получить экземпляр объекта типа Thread,
т.е. класса, определенного в пространстве имен System.Threading. Ниже приведена
простейшая форма конструктора класса Thread:

public Thread(ThreadStart запуск)

где запуск — это имя метода, вызываемого с целью начать выполнение потока,
a ThreadStart — делегат, определенный в среде .NET Framework, как показано
ниже.

public delegate void ThreadStart()

Следовательно, метод, указываемый в качестве точки входа в поток, должен иметь
возвращаемый тип void и не принимать никаких аргументов.

Вновь созданный новый поток не начнет выполняться до тех пор, пока не будет
вызван его метод Start(), определяемый в классе Thread. Существуют две формы
объявления метода Start(). Ниже приведена одна из них.

public void Start()

Однажды начавшись, поток будет выполняться до тех пор, пока не произойдет
возврат из метода, на который указывает запуск. Таким образом, после возврата из
этого метода поток автоматически прекращается. Если же попытаться вызвать метод
Start() для потока, который уже начался, это приведет к генерированию исключения
ThreadStateException.

В приведенном ниже примере программы создается и начинает выполняться новый поток.

*/

// Создать поток исполнения.

using System;
using System.Threading;

class MyThread
{
    public int Count;
    string thrdName;

    public MyThread(string name)
    {
        Count = 0;
        thrdName = name;
    }

    // Точка входа в поток.
    public void Run()
    {
        Console.WriteLine(thrdName + " начат.");

        do
        {
            Thread.Sleep(900);
            Console.WriteLine("В потоке " + thrdName + ", Count = " + Count);
            Count++;
        }
        while (Count < 10);

        Console.WriteLine(thrdName + " завершен.");
    }
}

class MultiThread
{
    static void Main()
    {
        Console.WriteLine("Основной поток начат.");

        // Сначала сконструировать объект типа MyThread.
        MyThread mt = new MyThread("Поток #1");

        // Далее сконструировать поток из этого объекта.
        Thread newThrd = new Thread(mt.Run);

        // И наконец начать выполнение потока.
        newThrd.Start();

        do
        {
            Console.Write(".");
            Thread.Sleep(300);
        } while (mt.Count != 10);

        Console.WriteLine("Основной поток завершен.");

        Console.ReadKey();
    }
}

/*

Рассмотрим приведенную выше программу более подробно. В самом ее начале
определяется класс MyThread, предназначенный для создания второго потока исполнения.
В методе Run() этого класса организуется цикл для подсчета от 0 до 9. Обратите
внимание на вызов статического метода Sleep(), определенного в классе Thread.
Этот метод обусловливает приостановление того потока, из которого он был вызван,
на определенный период времени, указываемый в миллисекундах. Когда приостанавливается
один поток, может выполняться другой. В данной программе используется
следующая форма метода Sleep():

public static void Sleep(int миллисекунд_простоя)

где миллисекунд_простоя обозначает период времени, на который приостанавливается
выполнение потока. Если указанное количество миллисекунд_простоя равно
нулю, то вызывающий поток приостанавливается лишь для того, чтобы предоставить
возможность для выполнения потока, ожидающего своей очереди.

В методе Main() новый объект типа Thread создается с помощью приведенной
ниже последовательности операторов.

// Сначала сконструировать объект типа MyThread.
MyThread mt = new MyThread("Потомок #1");
// Далее сконструировать поток из этого объекта.
Thread newThrd = new Thread(mt.Run);
// И наконец, начать выполнение потока.
newThrd.Start();

Как следует из комментариев к приведенному выше фрагменту кода, сначала создается
объект типа MyThread. Затем этот объект используется для создания объекта
типа Thread, для чего конструктору этого объекта в качестве точки входа передается
метод mt.Run(). И наконец, выполнение потока начинается с вызова метода Start().

Благодаря этому метод mt.Run() выполняется в своем собственном потоке. После вызова
метода Start() выполнение основного потока возвращается к методу Main(),
где начинается цикл do-while. Оба потока продолжают выполняться, совместно используя
ЦП, вплоть до окончания цикла. Ниже приведен результат выполнения данной
программы. (Он может отличаться в зависимости от среды выполнения, операционной
системы и степени загрузки задач.)

Основной поток начат.
Потомок #1 начат.
....В потоке Потомок #1, Count = 0
....В потоке Потомок #1, Count = 1
....В потоке Потомок #1, Count = 2
....В потоке Потомок #1, Count = 3
....В потоке Потомок #1, Count = 4
....В потоке Потомок #1, Count = 5
....В потоке Потомок #1, Count = 6
....В потоке Потомок #1, Count = 7
....В потоке Потомок #1, Count = 8
....В потоке Потомок #1, Count = 9
Потомок #1 завершен.
Основной поток завершен.

Зачастую в многопоточной программе требуется, чтобы основной поток был последним
потоком, завершающим ее выполнение. Формально программа продолжает
выполняться до тех пор, пока не завершатся все ее приоритетные потоки. Поэтому
требовать, чтобы основной поток завершал выполнение программы, совсем не обязательно.
Тем не менее этого правила принято придерживаться в многопоточном
программировании, поскольку оно явно определяет конечную точку программы.
В рассмотренной выше программе предпринята попытка сделать основной поток
завершающим ее выполнение. Для этой цели значение переменной Count проверяется
в цикле do-while внутри метода Main(), и как только это значение оказывается
равным 10, цикл завершается и происходит поочередный возврат из методов Sleep().
Но такой подход далек от совершенства, поэтому далее в этой главе будут представлены
более совершенные способы организации ожидания одного потока до завершения
другого.

*/

#endregion

#region English

/*

The Thread Class

The multithreading system is built upon the Thread class, which encapsulates a thread
of execution. The Thread class is sealed, which means that it cannot be inherited. Thread
defines several methods and properties that help manage threads. Throughout this chapter,
several of its most commonly used members will be examined.

Creating and Starting a Thread

There are a number of ways to create and start a thread. This section describes the basic
mechanism. Various options are described later in this chapter.
To create a thread, instantiate an object of type Thread, which is a class defined in
System.Threading. The simplest Thread constructor is shown here:

public Thread(ThreadStart start)

Here, start specifies the method that will be called to begin execution of the thread. In other
words, it specifies the thread’s entry point. ThreadStart is a delegate defined by the .NET
Framework as shown here:

public delegate void ThreadStart()

Thus, your entry point method must have a void return type and take no arguments.

Once created, the new thread will not start running until you call its Start( ) method,
which is defined by Thread. The Start( ) method has two forms. The one used here is

public void Start()

Once started, the thread will run until the entry point method returns. Thus, when the
thread’s entry point method returns, the thread automatically stops. If you try to call
Start( ) on a thread that has already been started, a ThreadStateException will be thrown.

Here is an example that creates a new thread and starts it running:

*/

// Create a thread of execution.

//using System; 
//using System.Threading; 

//class MyThread
//{
//    public int Count;
//    string thrdName;

//    public MyThread(string name)
//    {
//        Count = 0;
//        thrdName = name;
//    }

//    // Entry point of thread. 
//    public void Run()
//    {
//        Console.WriteLine(thrdName + " starting.");

//        do
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("In " + thrdName +
//                              ", Count is " + Count);
//            Count++;
//        } while (Count < 10);

//        Console.WriteLine(thrdName + " terminating.");
//    }
//}

//class MultiThread
//{
//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // First, construct a MyThread object. 
//        MyThread mt = new MyThread("Child #1");

//        // Next, construct a thread from that object. 
//        Thread newThrd = new Thread(mt.Run);

//        // Finally, start execution of the thread. 
//        newThrd.Start();

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

Let’s look closely at this program. MyThread defines a class that will be used to create a
second thread of execution. Inside its Run( ) method, a loop is established that counts from
0 to 9. Notice the call to Sleep( ), which is a static method defined by Thread. The Sleep( )
method causes the thread from which it is called to suspend execution for the specified
period of milliseconds. The form used by the program is shown here:

public static void Sleep(int millisecondsTimeout)

The number of milliseconds to suspend is specified in millisecondsTimeout. If millisecondsTimeout
is zero, the calling thread is suspended only to allow a waiting thread to execute.

Inside Main( ), a new Thread object is created by the following sequence of statements:

// First, construct a MyThread object.
MyThread mt = new MyThread("Child #1");

// Next, construct a thread from that object.
Thread newThrd = new Thread(mt.Run);

// Finally, start execution of the thread.
newThrd.Start();

As the comments suggest, first an object of MyThread is created. This object is then used
to construct a Thread object by passing the mt.Run( ) method as the entry point. Finally,
execution of the new thread is started by calling Start( ). This causes mt.Run( ) to begin
executing in its own thread. After calling Start( ), execution of the main thread returns to
Main( ), and it enters Main( )’s do loop. Both threads continue running, sharing the CPU,
until their loops finish. The output produced by this program is as follows. (The precise
output that you see may vary slightly because of differences in your execution environment,
operating system, and task load.)

Main thread starting.
Child #1 starting.
.....In Child #1, Count is 0
.....In Child #1, Count is 1
.....In Child #1, Count is 2
.....In Child #1, Count is 3
.....In Child #1, Count is 4
.....In Child #1, Count is 5
.....In Child #1, Count is 6
.....In Child #1, Count is 7
.....In Child #1, Count is 8
.....In Child #1, Count is 9
Child #1 terminating.
Main thread ending.

Often in a multithreaded program, you will want the main thread to be the last thread
to finish running. Technically, a program continues to run until all of its foreground threads
have finished. Thus, having the main thread finish last is not a requirement. It is, however,
good practice to follow because it clearly defines your program’s endpoint. The preceding
program tries to ensure that the main thread will finish last by checking the value of Count
within Main( )’s do loop, stopping when Count equals 10, and through the use of calls to
Sleep( ). However, this is an imperfect approach. Later in this chapter, you will see better
ways for one thread to wait until another finishes.

*/

#endregion