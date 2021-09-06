#region Russian

/*

Синхронизация

Когда используется несколько потоков, то иногда приходится координировать действия
двух или более потоков. Процесс достижения такой координации называется
синхронизацией. Самой распространенной причиной применения синхронизации служит
необходимость разделять среди двух или более потоков общий ресурс, который
может быть одновременно доступен только одному потоку. Например, когда в одном
потоке выполняется запись информации в файл, второму потоку должно быть запрещено
делать это в тот же самый момент времени. Синхронизация требуется и в том
случае, если один поток ожидает событие, вызываемое другим потоком. В подобной
ситуации требуются какие-то средства, позволяющие приостановить один из потоков
до тех пор, пока не произойдет событие в другом потоке. После этого ожидающий поток
может возобновить свое выполнение.

В основу синхронизации положено понятие блокировки, посредством которой организуется
управление доступом к кодовому блоку в объекте. Когда объект заблокирован
одним потоком, остальные потоки не могут получить доступ к заблокированному
кодовому блоку. Когда же блокировка снимается одним потоком, объект становится
доступным для использования в другом потоке.

Средство блокировки встроено в язык С#. Благодаря этому все объекты могут быть
синхронизированы. Синхронизация организуется с помощью ключевого слова lock.
Она была предусмотрена в C# с самого начала, и поэтому пользоваться ею намного
проще, чем кажется на первый взгляд. В действительности синхронизация объектов во
многих программах на С# происходит практически незаметно.

Ниже приведена общая форма блокировки:

lock(lockObj) {
// синхронизируемые операторы
}

где lockObj обозначает ссылку на синхронизируемый объект. Если же требуется синхронизировать
только один оператор, то фигурные скобки не нужны. Оператор lock
гарантирует, что фрагмент кода, защищенный блокировкой для данного объекта, будет
использоваться только в потоке, получающем эту блокировку. А все остальные потоки
блокируются до тех пор, пока блокировка не будет снята. Блокировка снимается
по завершении защищаемого ею фрагмента кода.

Блокируемым считается такой объект, который представляет синхронизируемый
ресурс. В некоторых случаях им оказывается экземпляр самого ресурса или же произвольный
экземпляр объекта, используемого для синхронизации. Следует, однако,
иметь в виду, что блокируемый объект не должен быть общедоступным, так как в противном
случае он может быть заблокирован из другого, неконтролируемого в программе
фрагмента кода и в дальнейшем вообще не разблокируется. В прошлом для
блокировки объектов очень часто применялась конструкция lock(this). Но она пригодна
только в том случае, если this является ссылкой на закрытый объект. В связи с
возможными программными и концептуальными ошибками, к которым может привести
конструкция lock(this), применять ее больше не рекомендуется. Вместо нее
лучше создать закрытый объект, чтобы затем заблокировать его. Именно такой подход
принят в примерах программ, приведенных далее в этой главе. Но в унаследованном
коде C# могут быть обнаружены примеры применения конструкции lock(this).
В одних случаях такой код оказывается безопасным, а в других — требует изменений
во избежание серьезных осложнений при его выполнении.

В приведенной ниже программе синхронизация демонстрируется на примере
управления доступом к методу SumIt(), суммирующему элементы целочисленного
массива.

*/

// Использовать блокировку для синхронизации доступа к объекту.

using System;
using System.Threading;


class SumArray
{
    int sum;
    object lockOn = new object(); // закрытый объект, доступный для последующей блокировки

    public int SumIt(int[] nums)
    {
        lock (lockOn) // заблокировать весь метод
        {
            sum = 0; // установить исходное значение суммы

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                Console.WriteLine("Текущая сумма для потока " + Thread.CurrentThread.Name + " равна " + sum);

                Thread.Sleep(10); // разрешить переключение задач
            }

            return sum;
        }
    }
}

class MyThread
{
    public Thread Thrd;
    int[] a;
    int answer;

    // Создать один объект типа SumArray для всех экземпляров класса MyThread.
    static SumArray sa = new SumArray();

    // Сконструировать новый поток.
    public MyThread(string name, int[] nums)
    {
        a = nums;
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        Thrd.Start(); // начать поток
    }

    // Начать выполнение нового потока.
    void Run()
    {
        Console.WriteLine(Thrd.Name + " начат.");

        answer = sa.SumIt(a);

        Console.WriteLine("Сумма для потока " + Thrd.Name + " равна" + answer);

        Console.WriteLine(Thrd.Name + " завершен.");
    }
}

class Sync
{
    static void Main()
    {
        int[] a = { 1, 2, 3, 4, 5 };

        MyThread mt1 = new MyThread("Потомок #1", a);
        MyThread mt2 = new MyThread("Потомок #2", a);

        mt1.Thrd.Join();
        mt2.Thrd.Join();

        Console.ReadKey();
    }
}

/*

Ниже приведен результат выполнения данной программы, хотя у вас он может оказаться
несколько иным.

Потомок #1 начат.
Текущая сумма для потока Потомок #1 равна 1
Потомок #2 начат.
Текущая сумма для потока Потомок #1 равна 3
Текущая сумма для потока Потомок #1 равна 6
Текущая сумма для потока Потомок #1 равна 10
Текущая сумма для потока Потомок #1 равна 15
Текущая сумма для потока Потомок #2 равна 1
Сумма для потока Потомок #1 равна 15
Потомок #1 завершен.
Текущая сумма для потока Потомок #2 равна 3
Текущая сумма для потока Потомок #2 равна 6
Текущая сумма для потока Потомок #2 равна 10
Текущая сумма для потока Потомок #2 равна 15
Сумма для потока Потомок #2 равна 15
Потомок #2 завершен.

Как следует из приведенного выше результата, в обоих потоках правильно подсчитывается
сумма, равная 15.

Рассмотрим эту программу более подробно. Сначала в ней создаются три класса.
Первым из них оказывается класс SumArray, в котором определяется метод SumIt(),
суммирующий элементы целочисленного массива. Вторым создается класс MyThread,
в котором используется статический объект sa типа SumArray. Следовательно, единственный
объект типа SumArray используется всеми объектами типа MyThread. С помощью
этого объекта получается сумма элементов целочисленного массива. Обратите
внимание на то, что текущая сумма запоминается в поле sum объекта типа SumArray.
Поэтому если метод SumIt() используется параллельно в двух потоках, то оба потока
попытаются обратиться к полю sum, чтобы сохранить в нем текущую сумму. А поскольку
это может привести к ошибкам, то доступ к методу SumIt() должен быть
синхронизирован. И наконец, в третьем классе, Sync, создаются два потока, в которых
подсчитывается сумма элементов целочисленного массива.

Оператор lock в методе SumIt() препятствует одновременному использованию
данного метода в разных потоках. Обратите внимание на то, что в операторе lock объект
lockOn используется в качестве синхронизируемого. Это закрытый объект, предназначенный
исключительно для синхронизации. Метод Sleep() намеренно вызывается
для того, чтобы произошло переключение задач, хотя в данном случае это невозможно.
Код в методе SumIt() заблокирован, и поэтому он может быть одновременно использован
только в одном потоке. Таким образом, когда начинает выполняться второй
порожденный поток, он не сможет войти в метод SumIt() до тех пор, пока из него не
выйдет первый порожденный поток. Благодаря этому гарантируется получение правильного
результата.

Для того чтобы полностью уяснить принцип действия блокировки, попробуйте
удалить из рассматриваемой здесь программы тело метода SumIt(). В итоге метод
SumIt() перестанет быть синхронизированным, а следовательно, он может параллельно
использоваться в любом числе потоков для одного и того же объекта. Поскольку
текущая сумма сохраняется в поле sum, она может быть изменена в каждом потоке,
вызывающем метод SumIt(). Это означает, что если два потока одновременно вызывают
метод SumIt() для одного и того же объекта, то конечный результат получается
неверным, поскольку содержимое поля sum отражает смешанный результат суммирования
в обоих потоках. В качестве примера ниже приведен результат выполнения
рассматриваемой здесь программы после снятия блокировки с метода SumIt().

Потомок #1 начат.
Текущая сумма для потока Потомок #1 равна 1
Потомок #2 начат.
Текущая сумма для потока Потомок #2 равна 1
Текущая сумма для потока Потомок #1 равна 3
Текущая сумма для потока Потомок #2 равна 5
Текущая сумма для потока Потомок #1 равна 8
Текущая сумма для потока Потомок #2 равна 11
Текущая сумма для потока Потомок #1 равна 15
Текущая сумма для потока Потомок #2 равна 19
Текущая сумма для потока Потомок #1 равна 24
Текущая сумма для потока Потомок #2 равна 29
Сумма для потока Потомок #1 равна 29
Потомок #1 завершен.
Текущая сумма для потока Потомок #2 равна 29
Потомок #2 завершен.

Как следует из приведенного выше результата, в обоих порожденных потоках метод
SumIt() используется одновременно для одного и того же объекта, а это приводит
к искажению значения в поде sum.

Ниже подведены краткие итоги использования блокировки.

• Если блокировка любого заданного объекта получена в одном потоке, то после
блокировки объекта она не может быть получена в другом потоке.

• Остальным потокам, пытающимся получить блокировку того же самого объекта,
придется ждать до тех пор, пока объект не окажется в разблокированном
состоянии.

• Когда поток выходит из заблокированного фрагмента кода, соответствующий
объект разблокируется.

*/

#endregion

#region English

/*

Synchronization

When using multiple threads, you will sometimes need to coordinate the activities of two
or more of the threads. The process by which this is achieved is called synchronization. The
most common reason for using synchronization is when two or more threads need access
to a shared resource that can be used by only one thread at a time. For example, when one
thread is writing to a file, a second thread must be prevented from doing so at the same
time. Another situation in which synchronization is needed is when one thread is waiting
for an event that is caused by another thread. In this case, there must be some means by
which the first thread is held in a suspended state until the event has occurred. Then the
waiting thread must resume execution.

The key to synchronization is the concept of a lock, which controls access to a block of
code within an object. When an object is locked by one thread, no other thread can gain
access to the locked block of code. When the thread releases the lock, the object is available
for use by another thread.

The lock feature is built into the C# language. Thus, all objects can be synchronized.
Synchronization is supported by the keyword lock. Since synchronization was designed
into C# from the start, it is much easier to use than you might first expect. In fact, for many
programs, the synchronization of objects is almost transparent.

The general form of lock is shown here:

lock(lockObj) {
// statements to be synchronized
}

Here, lockObj is a reference to the object being synchronized. If you want to synchronize
only a single statement, the curly braces are not needed. A lock statement ensures that the
section of code protected by the lock for the given object can be used only by the thread that
obtains the lock. All other threads are blocked until the lock is removed. The lock is released
when the block is exited.

The object you lock on is an object that represents the resource being synchronized. In
some cases, this will be an instance of the resource itself or simply an arbitrary instance of
object that is being used to provide synchronization. A key point to understand about lock
is that the lock-on object should not be publically accessible. Why? Because it is possible
that another piece of code that is outside your control could lock on the object and never
release it. In the past, it was common to use a construct such as lock(this). However, this
only works if this refers to a private object. Because of the potential for error and conceptual
mistakes in this regard, lock(this) is no longer recommended for general use. Instead, it is
better to simply create a private object on which to lock. This is the approach used by the
examples in this chapter. Be aware that you will still find many examples of lock(this) in
legacy C# code. In some cases, it will be safe. In others, it will need to be changed to avoid
problems.

The following program demonstrates synchronization by controlling access to a method
called SumIt( ), which sums the elements of an integer array:

*/

// Use lock to synchronize access to an object.  

//using System; 
//using System.Threading; 

//class SumArray
//{
//    int sum;
//    object lockOn = new object(); // a private object to lock on 

//    public int SumIt(int[] nums)
//    {
//        lock (lockOn)
//        { // lock the entire method 
//            sum = 0; // reset sum  

//            for (int i = 0; i < nums.Length; i++)
//            {
//                sum += nums[i];
//                Console.WriteLine("Running total for " +
//                       Thread.CurrentThread.Name +
//                       " is " + sum);
//                Thread.Sleep(10); // allow task-switch  
//            }
//            return sum;
//        }
//    }
//}

//class MyThread
//{
//    public Thread Thrd;
//    int[] a;
//    int answer;

//    // Create one SumArray object for all instances of MyThread. 
//    static SumArray sa = new SumArray();

//    // Construct a new thread.  
//    public MyThread(string name, int[] nums)
//    {
//        a = nums;
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start(); // start the thread  
//    }

//    // Begin execution of new thread.  
//    void Run()
//    {
//        Console.WriteLine(Thrd.Name + " starting.");

//        answer = sa.SumIt(a);

//        Console.WriteLine("Sum for " + Thrd.Name +
//                           " is " + answer);

//        Console.WriteLine(Thrd.Name + " terminating.");
//    }
//}

//class Sync
//{
//    static void Main()
//    {
//        int[] a = { 1, 2, 3, 4, 5 };

//        MyThread mt1 = new MyThread("Child #1", a);
//        MyThread mt2 = new MyThread("Child #2", a);

//        mt1.Thrd.Join();
//        mt2.Thrd.Join();

//        Console.ReadKey();
//    }
//}

/*

Here is sample output from the program. (The actual output you see may vary slightly.)

Child #1 starting.
Running total for Child #1 is 1
Child #2 starting.
Running total for Child #1 is 3
Running total for Child #1 is 6
Running total for Child #1 is 10
Running total for Child #1 is 15
Running total for Child #2 is 1
Sum for Child #1 is 15
Child #1 terminating.
Running total for Child #2 is 3
Running total for Child #2 is 6
Running total for Child #2 is 10
Running total for Child #2 is 15
Sum for Child #2 is 15
Child #2 terminating.

As the output shows, both threads compute the proper sum of 15.

Let’s examine this program in detail. The program creates three classes. The first is
SumArray. It defines the method SumIt(), which sums an integer array. The second class
is MyThread, which uses a static object called sa that is of type SumArray. Thus, only one
object of SumArray is shared by all objects of type MyThread. This object is used to obtain
the sum of an integer array. Notice that SumArray stores the running total in a field called
sum. Thus, if two threads use SumIt() concurrently, both will be attempting to use sum to
hold the running total. Because this will cause errors, access to SumIt() must be synchronized.
Finally, the class Sync creates two threads and has them compute the sum of an integer array.

Inside SumIt(), the lock statement prevents simultaneous use of the method by
different threads. Notice that lock uses lockOn as the object being synchronized. This is a
private object that is used solely for synchronization. Sleep() is called to purposely allow
a task-switch to occur, if one can—but it can’t in this case. Because the code within SumIt( )
is locked, it can be used by only one thread at a time. Thus, when the second child thread
begins execution, it does not enter SumIt() until after the first child thread is done with it.
This ensures the correct result is produced.

To understand the effects of lock fully, try removing it from the body of SumIt( ). After
doing this, SumIt() is no longer synchronized, and any number of threads can use it
concurrently on the same object. The problem with this is that the running total is stored in
sum, which will be changed by each thread that calls SumIt(). Thus, when two threads call
SumIt() at the same time on the same object, incorrect results are produced because sum
reflects the summation of both threads, mixed together. For example, here is sample output
from the program after lock has been removed from SumIt():

Child #1 starting.
Running total for Child #1 is 1
Child #2 starting.
Running total for Child #2 is 1
Running total for Child #1 is 3
Running total for Child #2 is 5
Running total for Child #1 is 8
Running total for Child #2 is 11
Running total for Child #1 is 15
Running total for Child #2 is 19
Running total for Child #1 is 24
Running total for Child #2 is 29
Sum for Child #1 is 29
Child #1 terminating.
Sum for Child #2 is 29
Child #2 terminating.

As the output shows, both child threads are using SumIt( ) at the same time on the same
object, and the value of sum is corrupted.

The effects of lock are summarized here:

• For any given object, once a lock has been acquired, the object is locked and no
other thread can acquire the lock.

• Other threads trying to acquire the lock on the same object will enter a wait state
until the code is unlocked.

• When a thread leaves the locked block, the object is unlocked.

*/

#endregion
