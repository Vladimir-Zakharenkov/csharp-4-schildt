#region Russian

/*

Взаимоблокировка и состояние гонки

При разработке многопоточных программ следует быть особенно внимательным,
чтобы избежать взаимоблокировки и состояний гонок. Взаимоблокировка, как подразумевает
само название, — это ситуация, в которой один поток ожидает определенных
действий от другого потока, а другой поток, в свою очередь, ожидает чего-то от первого
потока. В итоге оба потока приостанавливаются, ожидая друг друга, и ни один из
них не выполняется. Эта ситуация напоминает двух слишком вежливых людей, каждый
из которых настаивает на том, чтобы другой прошел в дверь первым!

На первый взгляд избежать взаимоблокировки нетрудно, но на самом деле не все так
просто, ведь взаимоблокировка может возникать окольными путями. В качестве примера
рассмотрим класс TickTock из предыдущей программы. Как пояснялось выше,
в отсутствие завершающего вызова метода Pulse() из метода Tick() или Тосk() тот
или другой будет ожидать до бесконечности, что приведет к "зависанию" программы
вследствие взаимоблокировки. Зачастую причину взаимоблокировки не так-то просто
выяснить, анализируя исходный код программы, поскольку параллельно действующие
процессы могут взаимодействовать довольно сложным образом во время выполнения.
Для исключения взаимоблокировки требуется внимательное программирование и
тщательное тестирование. В целом, если многопоточная программа периодически "зависает",
то наиболее вероятной причиной этого является взаимоблокировка.

Состояние гонки возникает в том случае, когда два потока или больше пытаются
одновременно получить доступ к общему ресурсу без должной синхронизации. Так,
в одном потоке может сохраняться значение в переменной, а в другом — инкрементироваться
текущее значение этой же переменной. В отсутствие синхронизации конечный
результат будет зависеть от того, в каком именно порядке выполняются потоки:
инкрементируется ли значение переменной во втором потоке или же оно сохраняется
в первом. О подобной ситуации говорят, что потоки "гоняются друг за другом", причем
конечный результат зависит от того, какой из потоков завершится первым. Возникающее
состояние гонок, как и взаимоблокировку, непросто обнаружить. Поэтому его
лучше предотвратить, синхронизируя должным образом доступ к общим ресурсам
при программировании.

Применение атрибута MethodImplAttribute

Метод может быть полностью синхронизирован с помощью атрибута
MethodImplAttribute. Такой подход может стать альтернативой оператору
lock в тех случаях, когда метод требуется заблокировать полностью. Атрибут
MethodImplAttribute определен в пространстве имен Sуstem.Runtime.
CompilerServices. Ниже приведен конструктор, применяемый для подобной
синхронизации:

public MethodImplAttribute(MethodImplOptions methodImplOptions)

где methodImplOptions обозначает атрибут реализации. Для синхронизации метода
достаточно указать атрибут MethodImplOptions.Synchronized. Этот атрибут вызывает
блокировку всего метода для текущего экземпляра объекта, доступного по ссылке
this. Если же метод относится к типу static, то блокируется его тип. Поэтому данный
атрибут непригоден для применения в открытых объектах или классах.

Ниже приведена еще одна версия программы, имитирующей тиканье часов, с переделанным
вариантом класса TickTock, в котором атрибут MethodImplOptions обеспечивает
должную синхронизацию.

*/

// Использовать атрибут MethodImplAttribute для синхронизации метода.

using System;
using System.Threading;
using System.Runtime.CompilerServices;

// Вариант класса TickTock, переделанный с целью использовать атрибут MethodImplOptions.Synchronized
class TickTock
{
    // Следующий атрибут полностью синхронизирует метод Tick().
    [MethodImplAttribute(MethodImplOptions.Synchronized)]
    public void Tick(bool running)
    {
        if (!running) // остановить часы
        {
            Monitor.Pulse(this); // уведомить любые ожидающие потоки
            return;
        }

        Console.Write("тик-");
        Monitor.Pulse(this); // разрешить выполнение метода Tock()
        Monitor.Wait(this); // ожидание завершения метода Tock()
    }

    // Следующий атрибут полностью синхронизирует метод Tock().
    [MethodImplAttribute(MethodImplOptions.Synchronized)]
    public void Tock(bool running)
    {
        if (!running) // остановить часы
        {
            Monitor.Pulse(this); // уведомить любые ожидающие потоки
            return;
        }

        Console.WriteLine("так");
        Monitor.Pulse(this); // разрешить выполнение метода Tick()
        Monitor.Wait(this); // ожидать завершения метода Tick()

    }
}

class MyThread
{
    public Thread Thrd;
    TickTock ttOb;

    // Сконструировать новый поток.
    public MyThread(string name, TickTock tt)
    {
        Thrd = new Thread(this.Run);
        ttOb = tt;
        Thrd.Name = name;
        Thrd.Start();
    }

    // Начать выполнение нового потока
    void Run()
    {
        if (Thrd.Name == "Tick")
        {
            for (int i = 0; i < 5; i++)
            {
                ttOb.Tick(true);
            }

            ttOb.Tick(false);
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                ttOb.Tock(true);
            }

            ttOb.Tock(false);
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

        Console.WriteLine("Часы остановлены");
    }
}

/*

Эта версия программы дает такой же результат, как и предыдущая.

Синхронизируемый метод не определен в открытом классе и не вызывается
для открытого объекта, поэтому применение оператора lock или атрибута
MethodImplAttribute зависит от личных предпочтений. Ведь и тот и другой дает один
и тот же результат. Но поскольку ключевое слово lock относится непосредственно к
языку С#, то в примерах, приведенных в этой книге, предпочтение отдано именно ему.

ПРИМЕЧАНИЕ
Не применяйте атрибут MethodImplAttribute в открытых классах или экземплярах
открытых объектов. Вместо этого пользуйтесь оператором lock, чтобы заблокировать метод
для закрытого объекта, как пояснялось ранее.


*/

#endregion

#region English

/*

Deadlock and Race Conditions

When developing multithreaded programs, you must be careful to avoid deadlock and race
conditions. Deadlock is, as the name implies, a situation in which one thread is waiting for
another thread to do something, but that other thread is waiting on the first. Thus, both
threads are suspended, waiting for each other, and neither executes. This situation is
analogous to two overly polite people both insisting that the other step through a door first!

Avoiding deadlock seems easy, but it’s not. For example, deadlock can occur in roundabout
ways. Consider the TickTock class. As explained, if a final Pulse( ) is not executed by Tick( ) or
Tock( ), then one or the other will be waiting indefinitely and the program is deadlocked.
Often the cause of the deadlock is not readily understood simply by looking at the source code
to the program, because concurrently executing threads can interact in complex ways at
runtime. To avoid deadlock, careful programming and thorough testing is required. In general,
if a multithreaded program occasionally “hangs,” deadlock is the likely cause.

A race condition occurs when two (or more) threads attempt to access a shared resource
at the same time, without proper synchronization. For example, one thread may be writing
a new value to a variable while another thread is incrementing the variable’s current value.
Without synchronization, the new value of the variable will depend on the order in which
the threads execute. (Does the second thread increment the original value or the new value
written by the first thread?) In situations like this, the two threads are said to be “racing each
other,” with the final outcome determined by which thread finishes first. Like deadlock, a
race condition can occur in difficult-to-discover ways. The solution is prevention: careful
programming that properly synchronizes access to shared resources.

Using MethodImplAttribute

It is possible to synchronize an entire method by using the MethodImplAttribute attribute.
This approach can be used as an alternative to the lock statement in cases in which the
entire contents of a method are to be locked. MethodImplAttribute is defined within
the System.Runtime.CompilerServices namespace. The constructor that applies to
synchronization is shown here:

public MethodImplAttribute(MethodImplOptions methodImplOptions)

Here, methodImplOptions specifies the implementation attribute. To synchronize a method,
specify MethodImplOptions.Synchronized. This attribute causes the entire method to be
locked on the instance (that is, via this). (In the case of static methods, the type is locked
on.) Thus, it must not be used on a public object or with a public class.

Here is a rewrite of the TickTock class that uses MethodImplAttribute to provide
synchronization:

*/

// Use MethodImplAttribute to synchronize a method. 

//using System; 
//using System.Threading; 
//using System.Runtime.CompilerServices; 

//// Rewrite of TickTock to use MethodImplOptions.Synchronized. 
//class TickTock
//{

//    /* The following attribute synchronizes the entire 
//       Tick() method. */
//    [MethodImplAttribute(MethodImplOptions.Synchronized)]
//    public void Tick(bool running)
//    {
//        if (!running)
//        { // stop the clock 
//            Monitor.Pulse(this); // notify any waiting threads 
//            return;
//        }

//        Console.Write("Tick ");
//        Monitor.Pulse(this); // let Tock() run 

//        Monitor.Wait(this); // wait for Tock() to complete 
//    }


//    /* The following attribute synchronizes the entire 
//       Tock() method. */
//    [MethodImplAttribute(MethodImplOptions.Synchronized)]
//    public void Tock(bool running)
//    {
//        if (!running)
//        { // stop the clock 
//            Monitor.Pulse(this); // notify any waiting threads 
//            return;
//        }

//        Console.WriteLine("Tock");
//        Monitor.Pulse(this); // let Tick() run 

//        Monitor.Wait(this); // wait for Tick() to complete 
//    }
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

The proper Tick Tock output is the same as before.

As long as the method being synchronized is not defined by a public class or called on a
public object, then whether you use lock or MethodImplAttribute is your decision. Both
produce the same results. Because lock is a keyword built into C#, that is the approach the
examples in this book will use.

REMEMBER
Do not use MethodImplAttribute with public classes or public instances. Instead,
use lock, locking on a private object (as explained earlier).

*/

#endregion