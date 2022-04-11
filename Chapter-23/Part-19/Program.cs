#region Russian

/*

Семафор

Семафор подобен мьютексу, за исключением того, что он предоставляет одновременный
доступ к общему ресурсу не одному, а нескольким потокам. Поэтому семафор
пригоден для синхронизации целого ряда ресурсов. Семафор управляет доступом к
общему ресурсу, используя для этой цели счетчик. Если значение счетчика больше
нуля, то доступ к ресурсу разрешен. А если это значение равно нулю, то доступ к ресурсу
запрещен. С помощью счетчика ведется подсчет количества разрешений. Следовательно,
для доступа к ресурсу поток должен получить разрешение от семафора.

Обычно поток, которому требуется доступ к общему ресурсу, пытается получить
разрешение от семафора. Если значение счетчика семафора больше нуля, то поток
получает разрешение, а счетчик семафора декрементируется. В противном случае поток
блокируется до тех пор, пока не получит разрешение. Когда же потоку больше не
требуется доступ к общему ресурсу, он высвобождает разрешение, а счетчик семафора
инкрементируется. Если разрешения ожидает другой поток, то он получает его в этот
момент. Количество одновременно разрешаемых доступов указывается при создании
семафора. Так, если создать семафор, одновременно разрешающий только один доступ,
то такой семафор будет действовать как мьютекс.

Семафоры особенно полезны в тех случаях, когда общий ресурс состоит из группы
или пула ресурсов. Например, пул ресурсов может состоять из целого ряда сетевых
соединений, каждое из которых служит для передачи данных. Поэтому потоку, которому
требуется сетевое соединение, все равно, какое именно соединение он получит.
В данном случае семафор обеспечивает удобный механизм управления доступом к сетевым
соединениям.

Семафор реализуется в классе System.Threading.Semaphore, у которого имеется
несколько конструкторов. Ниже приведена простейшая форма конструктора данного
класса:

public Semaphore(int initialCount, int maximumCount)

где initialCount — это первоначальное значение для счетчика разрешений семафора,
т.е. количество первоначально доступных разрешений; maximumCount — максимальное
значение данного счетчика, т.е. максимальное количество разрешений, которые
может дать семафор.

Семафор применяется таким же образом, как и описанный ранее мьютекс. В целях
получения доступа к ресурсу в коде программы вызывается метод WaitOne() для
семафора. Этот метод наследуется классом Semaphore от класса WaitHandle. Метод
WaitOne() ожидает до тех пор, пока не будет получен семафор, для которого он вызывается.
Таким образом, он блокирует выполнение вызывающего потока до тех пор,
пока указанный семафор не предоставит разрешение на доступ к ресурсу.

Если коду больше не требуется владеть семафором, он освобождает его, вызывая
метод Release(). Ниже приведены две формы этого метода.

public int Release()
public int Release(int releaseCount)

В первой форме метод Release() высвобождает только одно разрешение, а во
второй форме — количество разрешений, определяемых параметром releaseCount.
В обеих формах данный метод возвращает подсчитанное количество разрешений, существовавших
до высвобождения.

Метод WaitOne() допускается вызывать в потоке несколько раз перед вызовом метода
Release(). Но количество вызовов метода WaitOne() должно быть равно количеству
вызовов метода Release() перед высвобождением разрешения. С другой
стороны, можно воспользоваться формой вызова метода Release(int num), чтобы
передать количество высвобождаемых разрешений, равное количеству вызовов метода
WaitOne().

Ниже приведен пример программы, в которой демонстрируется применение семафора.
В этой программе семафор используется в классе MyThread для одновременного
выполнения только двух потоков типа MyThread. Следовательно, разделяемым
ресурсом в данном случае является ЦП.

*/

using System;
using System.Threading;

// Этот поток разрешает одновременное выполнение только двух своих экземпляров.
class MyThread
{
    public Thread Thrd;

    // Здесь создается семафор, дающий только два разрешения из двух первоначально имеющихся.
    static Semaphore sem = new Semaphore(2, 2);

    public MyThread(string name)
    {
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        Thrd.Start();
    }

    // Точка входа в поток.
    void Run()
    {
        Console.WriteLine(Thrd.Name + " ожидает разрешения.");

        sem.WaitOne();

        for (char ch = 'A'; ch < 'D'; ch++)
        {
            Console.WriteLine(Thrd.Name + " : " + ch + " ");
            Thread.Sleep(2000);
        }

        Console.WriteLine(Thrd.Name + " высвобождает разрешение.");

        // Освободить семафор.
        sem.Release();
    }
}

class SemaphorDemo
{
    static void Main()
    {
        // Сконструировать три потока.
        MyThread mt1 = new MyThread("Поток #1");
        MyThread mt2 = new MyThread("Поток #2");
        MyThread mt3 = new MyThread("Поток #3");

        mt1.Thrd.Join();
        mt2.Thrd.Join();
        mt3.Thrd.Join();
    }
}

/*

В классе MyThread объявляется семафор sem, как показано ниже.

static Semaphore sem = new Semaphore(2, 2);

При этом создается семафор, способный дать не более двух разрешений на доступ
к ресурсу из двух первоначально имеющихся разрешений.

Обратите внимание на то, что выполнение метода MyThread.Run() не может быть
продолжено до тех пор, пока семафор sem не даст соответствующее разрешение. Если
разрешение отсутствует, то выполнение потока приостанавливается. Когда же разрешение
появляется, выполнение потока возобновляется. В методе Main() создаются
три потока. Но выполняться могут только два первых потока, а третий должен ожидать
окончания одного из этих двух потоков. Ниже приведен результат выполнения
рассматриваемой здесь программы, хотя у вас он может оказаться несколько иным.

Поток #1 ожидает разрешения.
Поток #1 получает разрешение.
Поток #1 : А
Поток #2 ожидает разрешения.
Поток #2 получает разрешение.
Поток #2 : А
Поток #3 ожидает разрешения.
Поток #1 : В
Поток #2 : В
Поток #1 : С
Поток #2 : С
Поток #1 высвобождает разрешение.
Поток #3 получает разрешение.
Поток #3 : А
Поток #2 высвобождает разрешение.
Поток #3 : В
Поток #3 : С
Поток #3 высвобождает разрешение.

Семафор, созданный в предыдущем примере, известен только тому процессу, который
его породил. Но семафор можно создать и таким образом, чтобы он был известен
где-нибудь еще. Для этого он должен быть именованным. Ниже приведены формы
конструктора класса Semaphore, предназначенные для создания такого семафора.

public Semaphore(int initialCount, int maximumCount, string имя)
public Semaphore(int initialCount, int maximumCount, string имя, out bool createdNew)

В обеих формах имя обозначает конкретное имя, передаваемое конструктору. Если
в первой форме семафор, на который указывает имя, еще не существует, то он создается
с помощью значений, определяемых параметрами initialCount и maximumCount.
А если он уже существует, то значения параметров initialCount и maximumCount
игнорируются. После возврата из второй формы конструктора параметр createdNew
будет иметь логическое значение true, если семафор был создан. В этом случае значения
параметров initialCount и maximumCount используются для создания семафора.
Если же параметр createdNew будет иметь логическое значение false, значит, семафор
уже существует и значения параметров initialCount и maximumCount игнорируются.
Существует и третья форма конструктора класса Semaphore, в которой допускается
указывать управляющий доступом объект типа SemaphoreSecurity. С помощью
именованных семафоров можно синхронизировать взаимодействие процессов.

*/

#endregion

#region English

/*

The Semaphore

A semaphore is similar to a mutex except that it can grant more than one thread access
to a shared resource at the same time. Thus, the semaphore is useful when a collection of
resources is being synchronized. A semaphore controls access to a shared resource through
the use of a counter. If the counter is greater than zero, then access is allowed. If it is zero,
access is denied. What the counter is counting are permits. Thus, to access the resource, a
thread must be granted a permit from the semaphore.

In general, to use a semaphore, the thread that wants access to the shared resource tries
to acquire a permit. If the semaphore’s counter is greater than zero, the thread acquires a
permit, which causes the semaphore’s count to be decremented. Otherwise, the thread will
block until a permit can be acquired. When the thread no longer needs access to the shared
resource, it releases the permit, which causes the semaphore’s count to be incremented. If
there is another thread waiting for a permit, then that thread will acquire a permit at that
time. The number of simultaneous accesses permitted is specified when the semaphore is
created. If you create a semaphore that allows only one access, then a semaphore acts just
like a mutex.

Semaphores are especially useful in situations in which a shared resource consists of a
group or pool. For example, a collection of network connections, any of which can be used
for communication, is a resource pool. A thread needing a network connection doesn’t care
which one it gets. In this case, a semaphore offers a convenient mechanism to manage
access to the connections.

The semaphore is implemented by System.Threading.Semaphore. It has several
constructors. The simplest form is shown here:

public Semaphore(int initialCount, int maximumCount)

Here, initialCount specifies the initial value of the semaphore permit counter, which is the
number of permits available. The maximum value of the counter is passed in maximumCount.
Thus, maximumCount represents the maximum number of permits that can granted by the
semaphore. The value in initialCount specifies how many of these permits are initially
available.

Using a semaphore is similar to using a mutex, described earlier. To acquire access, your
code will call WaitOne() on the semaphore. This method is inherited by Semaphore from
theWaitHandle class. WaitOne() waits until the semaphore on which it is called can be
acquired. Thus, it blocks execution of the calling thread until the specified semaphore can
grant permission.

When your code no longer needs ownership of the semaphore, it releases it by calling
Release(), which is shown here:

public int Release()
public int Release(int releaseCount)

The first form releases one permit. The second form releases the number of permits
specified by releaseCount. Both return the permit count that existed prior to the release.

It is possible for a thread to call WaitOne() more than once before calling Release( ).
However, the number of calls to WaitOne() must be balanced by the same number of calls
to Release() before the permit is released. Alternatively, you can call the Release(int) form,
passing a number equal to the number of times that WaitOne() was called.

Here is an example that illustrates the semaphore. In the program, the class MyThread
uses a semaphore to allow only two MyThread threads to be executed at any one time.
Thus, the resource being shared is the CPU.

*/

// Use a Semaphore 

//using System;  
//using System.Threading;  

//// This thread allows only two instances of itself 
//// to run at any one time. 
//class MyThread
//{
//    public Thread Thrd;

//    // This creates a semaphore that allows up to 2 
//    // permits to be granted and that initially has 
//    // two permits available. 
//    static Semaphore sem = new Semaphore(2, 2);

//    public MyThread(string name)
//    {
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start();
//    }

//    // Entry point of thread.  
//    void Run()
//    {

//        Console.WriteLine(Thrd.Name + " is waiting for a permit.");

//        sem.WaitOne();

//        Console.WriteLine(Thrd.Name + " acquires a permit.");

//        for (char ch = 'A'; ch < 'D'; ch++)
//        {
//            Console.WriteLine(Thrd.Name + " : " + ch + " ");
//            Thread.Sleep(500);
//        }

//        Console.WriteLine(Thrd.Name + " releases a permit.");

//        // Release the semaphore. 
//        sem.Release();
//    }
//}


//class SemaphoreDemo
//{
//    static void Main()
//    {

//        // Construct three threads.  
//        MyThread mt1 = new MyThread("Thread #1");
//        MyThread mt2 = new MyThread("Thread #2");
//        MyThread mt3 = new MyThread("Thread #3");

//        mt1.Thrd.Join();
//        mt2.Thrd.Join();
//        mt3.Thrd.Join();
//    }
//}

/*

MyThread declares the semaphore sem, as shown here:

static Semaphore sem = new Semaphore(2, 2);

This creates a semaphore that can grant up to two permits and that initially has both
permits available.

In MyThread.Run( ), notice that execution cannot continue until a permit is granted by
the semaphore, sem. If no permits are available, then execution of that thread suspends.
When a permit does become available, execution resumes and the thread can run. In Main( ),
three MyThread threads are created. However, only the first two get to execute. The third
must wait until one of the other threads terminates. The output, shown here, verifies this.
(The actual output you see may vary slightly.)

Thread #1 is waiting for a permit.
Thread #1 acquires a permit.
Thread #1 : A
Thread #2 is waiting for a permit.
Thread #2 acquires a permit.
Thread #2 : A
Thread #3 is waiting for a permit.
Thread #1 : B
Thread #2 : B
Thread #1 : C
Thread #2 : C
Thread #1 releases a permit.
Thread #3 acquires a permit.
Thread #3 : A
Thread #2 releases a permit.
Thread #3 : B
Thread #3 : C
Thread #3 releases a permit.

The semaphore created by the previous example is known only to the process that
creates it. However, it is possible to create a semaphore that is known systemwide. To do
so, you must create a named semaphore. To do this, use one of these constructors:

public Semaphore(int initialCount, int maximumCount, string name)
public Semaphore(int initialCount, int maximumCount, string name, out bool createdNew)

In both forms, the name of the semaphore is passed in name. In the first form, if a semaphore
by the specified name does not already exist, it is created using the values of initialCount and
maximumCount. If it does already exist, then the values of initialCount and maximumCount are
ignored. In the second form, on return, createdNew will be true if the semaphore was created.
In this case, the values of initialCount and maximumCount will be used to create the
semaphore. If createdNew is false, then the semaphore already exists and the values of
initialCount and maximumCount are ignored. (There is also a third form of the Semaphore
constructor that allows you to specify a SemaphoreSecurity object, which controls access.)
Using a named semaphore enables you to manage interprocess synchronization.

*/

#endregion