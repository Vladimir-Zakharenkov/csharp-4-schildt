#region Russian

/*

Применение мьютекса и семафора

В большинстве случаев, когда требуется синхронизация, оказывается достаточно
и оператора lock. Тем не менее в некоторых случаях, как, например, при ограничении
доступа к общим ресурсам, более удобными оказываются механизмы синхронизации,
встроенные в среду .NET Framework. Ниже рассматриваются по порядку два таких механизма:
мьютекс и семафор.

Мьютекс

Мьютекс представляет собой взаимно исключающий синхронизирующий объект.
Это означает, что он может быть получен потоком только по очереди. Мьютекс
предназначен для тех ситуаций, в которых общий ресурс может быть одновременно
использован только в одном потоке. Допустим, что системный журнал совместно используется
в нескольких процессах, но только в одном из них данные могут записываться
в файл этого журнала в любой момент времени. Для синхронизации процессов
в данной ситуации идеально подходит мьютекс.

Мьютекс поддерживается в классе System.Threading.Mutex. У него имеется несколько
конструкторов. Ниже приведены два наиболее употребительных конструктора.

public Mutex()
public Mutex(bool initiallyOwned)

В первой форме конструктора создается мьютекс, которым первоначально никто не
владеет. А во второй форме исходным состоянием мьютекса завладевает вызывающий
поток, если параметр initiallyOwned имеет логическое значение true. В противном
случае мьютексом никто не владеет.

Для того чтобы получить мьютекс, в коде программы следует вызвать метод
WaitOne() для этого мьютекса. Метод WaitOne() наследуется классом Mutex от класса
Thread.WaitHandle. Ниже приведена его простейшая форма.

public bool WaitOne();

Метод WaitOne() ожидает до тех пор, пока не будет получен мьютекс, для которого
он был вызван. Следовательно, этот метод блокирует выполнение вызывающего потока
до тех пор, пока не станет доступным указанный мьютекс. Он всегда возвращает
логическое значение true.

Когда же в коде больше не требуется владеть мьютексом, он освобождается посредством
вызова метода ReleaseMutex(), форма которого приведена ниже.

public void ReleaseMutex()

В этой форме метод ReleaseMutex() освобождает мьютекс, для которого он был
вызван, что дает возможность другому потоку получить данный мьютекс.

Для применения мьютекса с целью синхронизировать доступ к общему ресурсу
упомянутые выше методы WaitOne() и ReleaseMutex() используются так, как показано
в приведенном ниже фрагменте кода.

Mutex myMtx = new Mutex();
// ...
myMtx.WaitOne(); // ожидать получения мьютекса
// Получить доступ к общему ресурсу.
myMtx.ReleaseMutex(); // освободить мьютекс

При вызове метода WaitOne() выполнение соответствующего потока приостанавливается
до тех пор, пока не будет получен мьютекс. А при вызове метода
ReleaseMutex() мьютекс освобождается и затем может быть получен другим потоком.
Благодаря такому подходу к синхронизации одновременный доступ к общему
ресурсу ограничивается только одним потоком.

В приведенном ниже примере программы описанный выше механизм синхронизации
демонстрируется на практике. В этой программе создаются два потока в виде
классов IncThread и DecThread, которым требуется доступ к общему ресурсу: переменной
SharedRes.Count. В потоке IncThread переменная SharedRes.Count
инкрементируется, а в потоке DecThread — декрементируется. Во избежание одновременного
доступа обоих потоков к общему ресурсу SharedRes.Count этот доступ
синхронизируется мьютексом Mtx, также являющимся членом класса SharedRes.

*/

// Применить мьютекс.

using System;
using System.Threading;

// В этом классе содержится общий ресурс (переменная Count),
// а также мьютекс (Mtx), управляющий доступом к ней.

class SharedRess
{
    public static int Count = 0;
    public static Mutex Mtx = new();
}

// В этом потоке переменная SharedRes.Count инкриминируется.
class IncThread
{
    int num;
    public Thread Thrd;

    public IncThread(string name, int n)
    {
        Thrd = new Thread(this.Run);
        num = n;
        Thrd.Name = name;
        Thrd.Start();
    }

    // Точка входа в поток
    void Run()
    {
        Console.WriteLine(Thrd.Name + " ожидает мьютекс.");

        // Получить мьютекс.
        SharedRess.Mtx.WaitOne();

        Console.WriteLine(Thrd.Name + " получает мьютекс.");

        do
        {
            Thread.Sleep(500);
            SharedRess.Count++;
            Console.WriteLine("В потоке " + Thrd.Name + ", SharedRes.Count = " + SharedRess.Count);
            num--;
        } while (num > 0);

        Console.WriteLine(Thrd.Name + " освобождает мьютекс.");

        // Освободить мьютекс.
        SharedRess.Mtx.ReleaseMutex();
    }
}

// В этом потоке переменная ShaerdRes.Count декременируется.
class DecThread
{
    int num;
    public Thread Thrd;

    public DecThread(string name, int n)
    {
        Thrd = new Thread(new ThreadStart(this.Run));
        num = n;
        Thrd.Name = name;
        Thrd.Start();
    }

    // Точка входа в поток.
    void Run()
    {
        Console.WriteLine(Thrd.Name + " ожидает мьютекс.");

        // Получить мьютекс.
        SharedRess.Mtx.WaitOne();

        Console.WriteLine(Thrd.Name + " получает мьютекс.");

        do
        {
            Thread.Sleep(500);
            SharedRess.Count--;
            Console.WriteLine("В потоке " + Thrd.Name + ", SharedRes.Count = " + SharedRess.Count);
            num--;
        } while (num > 0);

        // Освободить мьютекс.
        SharedRess.Mtx.ReleaseMutex();
    }
}

class MutexDemo
{
    static void Main()
    {
        // Сконструировать два потока.
        IncThread mt1 = new IncThread("Инкрементирующий поток", 5);

        Thread.Sleep(1); // разрешить инкрементирующему потоку начаться.

        DecThread mt2 = new DecThread("Декрементирующий поток", 5);

        mt1.Thrd.Join();
        mt2.Thrd.Join();

    }
}

/*

Эта программа дает следующий результат.

Инкрементирующий Поток ожидает мьютекс.
Инкрементирующий Поток получает мьютекс.
Декрементирующий Поток ожидает мьютекс.
В потоке Инкрементирующий Поток, SharedRes.Count = 1
В потоке Инкрементирующий Поток, SharedRes.Count = 2
В потоке Инкрементирующий Поток, SharedRes.Count = 3
В потоке Инкрементирующий Поток, SharedRes.Count = 4
В потоке Инкрементирующий Поток, SharedRes.Count = 5
Инкрементирующий Поток освобождает мьютекс.
Декрементирующий Поток получает мьютекс.
В потоке Декрементирующий Поток, SharedRes.Count = 4
В потоке Декрементирующий Поток, SharedRes.Count = 3
В потоке Декрементирующий Поток, SharedRes.Count = 2
В потоке Декрементирующий Поток, SharedRes.Count = 1
В потоке Декрементирующий Поток, SharedRes.Count = 0
Декрементирующий Поток освобождает мьютекс.

Как следует из приведенного выше результата, доступ к общему ресурсу (переменной
SharedRes.Count) синхронизирован, и поэтому значение данной переменной
может быть одновременно изменено только в одном потоке.

Для того чтобы убедиться в том, что мьютекс необходим для получения приведенного
выше результата, попробуйте закомментировать вызовы методов WaitOne()
и ReleaseMutex() в исходном коде рассматриваемой здесь программы. При ее последующем
выполнении вы получите следующий результат, хотя у вас он может оказаться
несколько иным.

В потоке Инкрементирующий Поток, SharedRes.Count = 1
В потоке Декрементирующий Поток, SharedRes.Count = 0
В потоке Инкрементирующий Поток, SharedRes.Count = 1
В потоке Декрементирующий Поток, SharedRes.Count = 0
В потоке Инкрементирующий Поток, SharedRes.Count = 1
В потоке Декрементирующий Поток, SharedRes.Count = 0
В потоке Инкрементирующий Поток, SharedRes.Count = 1
В потоке Декрементирующий Поток, SharedRes.Count = 0
В потоке Инкрементирующий Поток, SharedRes.Count = 1

Как следует из приведенного выше результата, без мьютекса инкрементирование и
декрементирование переменной SharedRes.Count происходит, скорее, беспорядочно,
чем последовательно.

Мьютекс, созданный в предыдущем примере, известен только тому процессу, который
его породил. Но мьютекс можно создать и таким образом, чтобы он был известен
где-нибудь еще. Для этого он должен быть именованным. Ниже приведены формы
конструктора, предназначенные для создания такого мьютекса.

public Mutex(bool initiallyOwned, string имя)
public Mutex(bool initiallyOwned, string имя, out bool createdNew)

В обеих формах конструктора имя обозначает конкретное имя мьютекса. Если в
первой форме конструктора параметр initiallyOwned имеет логическое значение
true, то владение мьютексом запрашивается. Но поскольку мьютекс может принадлежать
другому процессу на системном уровне, то для этого параметра лучше указать
логическое значение false. А после возврата из второй формы конструктора параметр
createdNew будет иметь логическое значение true, если владение мьютексом
было запрошено и получено, и логическое значение false, если запрос на владение
был отклонен. Существует и третья форма конструктора типа Mutex, в которой допускается
указывать управляющий доступом объект типа MutexSecurity. С помощью
именованных мьютексов можно синхронизировать взаимодействие процессов.

И последнее замечание: в потоке, получившем мьютекс, допускается делать один
или несколько дополнительных вызовов метода WaitOne() перед вызовом метода
ReleaseMutex(), причем все эти дополнительные вызовы будут произведены успешно.
Это означает, что дополнительные вызовы метода WaitOne() не будут блокировать
поток, который уже владеет мьютексом. Но количество вызовов метода WaitOne()
должно быть равно количеству вызовов метода ReleaseMutex() перед освобождением
мьютекса.

*/

#endregion

#region English

/*

Using a Mutex and a Semaphore

Although C#’s lock statement is sufficient for many synchronization needs, some situations,
such as restricting access to a shared resource, are sometimes more conveniently handled by
other synchronization mechanisms built into the .NET Framework. The two described here
are related to each other: mutexes and semaphores.

The Mutex

A mutex is a mutually exclusive synchronization object. This means it can be acquired by
one and only one thread at a time. The mutex is designed for those situations in which a
shared resource can be used by only one thread at a time. For example, imagine a log file
that is shared by several processes, but only one process can write to that file at any one
time. A mutex is the perfect synchronization device to handle this situation.

The mutex is supported by the System.Threading.Mutex class. It has several
constructors. Two commonly used ones are shown here:

public Mutex()
public Mutex(bool initiallyOwned)

The first version creates a mutex that is initially unowned. In the second version, if
initiallyOwned is true, the initial state of the mutex is owned by the calling thread.
Otherwise, it is unowned.

To acquire the mutex, your code will call WaitOne() on the mutex. This method
is inherited by Mutex from the Thread.WaitHandle class. Here is its simplest form:

public bool WaitOne();

It waits until the mutex on which it is called can be acquired. Thus, it blocks execution of the
calling thread until the specified mutex is available. It always returns true.
When your code no longer needs ownership of the mutex, it releases it by calling
ReleaseMutex(), shown here:

public void ReleaseMutex()

This releases the mutex on which it is called, enabling the mutex to be acquired by another
thread.

To use a mutex to synchronize access to a shared resource, you will use WaitOne() and
ReleaseMutex(), as shown in the following sequence:

Mutex myMtx = new Mutex();
// ...
myMtx.WaitOne(); // wait to acquire the mutex
// Access the shared resource.
myMtx.ReleaseMutex(); // release the mutex

When the call to WaitOne() takes place, execution of the thread will suspend until the
mutex can be acquired. When the call to ReleaseMutex() takes place, the mutex is released
and another thread can acquire it. Using this approach, access to a shared resource can be
limited to one thread at a time.

The following program puts this framework into action. It creates two threads,
IncThread and DecThread, which both access a shared resource called SharedRes.Count.
IncThread increments SharedRes.Count and DecThread decrements it. To prevent both
threads from accessing SharedRes.Count at the same time, access is synchronized by the
Mtx mutex, which is also part of the SharedRes class.

*/

// Use a Mutex. 

//using System;  
//using System.Threading;  

//// This class contains a shared resource (Count), 
//// and a mutex (Mtx) to control access to it.  
//class SharedRes
//{
//    public static int Count = 0;
//    public static Mutex Mtx = new Mutex();
//}

//// This thread increments SharedRes.Count. 
//class IncThread
//{
//    int num;
//    public Thread Thrd;

//    public IncThread(string name, int n)
//    {
//        Thrd = new Thread(this.Run);
//        num = n;
//        Thrd.Name = name;
//        Thrd.Start();
//    }

//    // Entry point of thread.  
//    void Run()
//    {

//        Console.WriteLine(Thrd.Name + " is waiting for the mutex.");

//        // Acquire the Mutex. 
//        SharedRes.Mtx.WaitOne();

//        Console.WriteLine(Thrd.Name + " acquires the mutex.");

//        do
//        {
//            Thread.Sleep(500);
//            SharedRes.Count++;
//            Console.WriteLine("In " + Thrd.Name +
//                              ", SharedRes.Count is " + SharedRes.Count);
//            num--;
//        } while (num > 0);

//        Console.WriteLine(Thrd.Name + " releases the mutex.");

//        // Release the Mutex. 
//        SharedRes.Mtx.ReleaseMutex();
//    }
//}

//// This thread decrements SharedRes.Count. 
//class DecThread
//{
//    int num;
//    public Thread Thrd;

//    public DecThread(string name, int n)
//    {
//        Thrd = new Thread(new ThreadStart(this.Run));
//        num = n;
//        Thrd.Name = name;
//        Thrd.Start();
//    }

//    // Entry point of thread.  
//    void Run()
//    {

//        Console.WriteLine(Thrd.Name + " is waiting for the mutex.");

//        // Acquire the Mutex. 
//        SharedRes.Mtx.WaitOne();

//        Console.WriteLine(Thrd.Name + " acquires the mutex.");

//        do
//        {
//            Thread.Sleep(500);
//            SharedRes.Count--;
//            Console.WriteLine("In " + Thrd.Name +
//                              ", SharedRes.Count is " + SharedRes.Count);
//            num--;
//        } while (num > 0);

//        Console.WriteLine(Thrd.Name + " releases the mutex.");

//        // Release the Mutex. 
//        SharedRes.Mtx.ReleaseMutex();
//    }
//}

//class MutexDemo
//{
//    static void Main()
//    {

//        // Construct three threads.  
//        IncThread mt1 = new IncThread("Increment Thread", 5);

//        Thread.Sleep(1); // let the Increment thread start 

//        DecThread mt2 = new DecThread("Decrement Thread", 5);

//        mt1.Thrd.Join();
//        mt2.Thrd.Join();
//    }
//}

/*

The output is shown here:

Increment Thread is waiting for the mutex.
Increment Thread acquires the mutex.
Decrement Thread is waiting for the mutex.
In Increment Thread, SharedRes.Count is 1
In Increment Thread, SharedRes.Count is 2
In Increment Thread, SharedRes.Count is 3
In Increment Thread, SharedRes.Count is 4
In Increment Thread, SharedRes.Count is 5
Increment Thread releases the mutex.
Decrement Thread acquires the mutex.
In Decrement Thread, SharedRes.Count is 4
In Decrement Thread, SharedRes.Count is 3
In Decrement Thread, SharedRes.Count is 2
In Decrement Thread, SharedRes.Count is 1
In Decrement Thread, SharedRes.Count is 0
Decrement Thread releases the mutex.

As the output shows, access to SharedRes.Count is synchronized, with only one thread at a
time being able to change its value.

To prove that the Mtx mutex was needed to produce the preceding output, try
commenting out the calls to WaitOne( ) and ReleaseMutex( ) in the preceding program.
When you run the program, you will see the following sequence (the actual output you see
may vary):

In Increment Thread, SharedRes.Count is 1
In Decrement Thread, SharedRes.Count is 0
In Increment Thread, SharedRes.Count is 1
In Decrement Thread, SharedRes.Count is 0
In Increment Thread, SharedRes.Count is 1
In Decrement Thread, SharedRes.Count is 0
In Increment Thread, SharedRes.Count is 1
In Decrement Thread, SharedRes.Count is 0
In Increment Thread, SharedRes.Count is 1

As this output shows, without the mutex, increments and decrements to SharedRes.Count
are interspersed rather than sequenced.

The mutex created by the previous example is known only to the process that creates it.
However, it is possible to create a mutex that is known systemwide. To do so, you must
create a named mutex, using one of these constructors:

public Mutex(bool initiallyOwned, string name)
public Mutex(bool initiallyOwned, string name, out bool createdNew)

In both forms, the name of the mutex is passed in name. In the first form, if initiallyOwned
is true, then ownership of the mutex is requested. However, because a systemwide mutex
might already be owned by another process, it is better to specify false for this parameter.
In the second form, on return createdNew will be true if ownership was requested and
acquired. It will be false if ownership was denied. (There is also a third form of the Mutex
constructor that allows you to specify a MutexSecurity object, which controls access.) Using
a named mutex enables you to manage interprocess synchronization.

One other point: It is legal for a thread that has acquired a mutex to make one or more
additional calls to WaitOne() prior to calling ReleaseMutex(), and these additional calls
will succeed. That is, redundant calls to WaitOne() will not block a thread that already
owns the mutex. However, the number of calls to WaitOne() must be balanced by the
same number of calls to ReleaseMutex() before the mutex is released.

*/

#endregion