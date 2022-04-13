#region Russian

/*

Другой подход к синхронизации потоков

Несмотря на всю простоту и эффективность блокировки кода метода, как показано
в приведенном выше примере, такое средство синхронизации оказывается пригодным
далеко не всегда. Допустим, что требуется синхронизировать доступ к методу класса,
который был создан кем-то другим и сам не синхронизирован. Подобная ситуация
вполне возможна при использовании чужого класса, исходный код которого недоступен.
В этом случае оператор lock нельзя ввести в соответствующий метод чужого
класса. Как же тогда синхронизировать объект такого класса? К счастью, этот вопрос
разрешается довольно просто: доступ к объекту может быть заблокирован из внешнего
кода по отношению к данному объекту, для чего достаточно указать этот объект
в операторе lock. В качестве примера ниже приведен другой вариант реализации
предыдущей программы. Обратите внимание на то, что код в методе SumIt() уже не
является заблокированным, а объект lockOn больше не объявляется. Вместо этого вызовы
метода SumIt() блокируются в классе MyThread.

*/

// Другой способ блокировки для синхронизации доступа к объекту.

using System;
using System.Threading;

class SumArray
{
    int sum;

    public int SumIt(int[] nums)
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

class MyThread
{
    public Thread Thrd;
    int[] a;
    int answer;

    // Создать один объект типа SumArray для всех экземпляров класса MyThread.
   static SumArray sa = new();

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

        // Заблокировать вызовы метода SumIt().
        lock (sa) answer = sa.SumIt(a);

        Console.WriteLine("Сумма для потока " + Thrd.Name + " равна " + answer);

        Console.WriteLine("Поток " + Thrd.Name + " завершен.");
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
    }
}

/*

В данной программе блокируется вызов метода sa.SumIt(), а не сам метод
SumIt(). Ниже приведена соответствующая строка кода, в которой осуществляется
подобная блокировка.

// Заблокировать вызовы метода SumIt().
lock(sa) answer = sa.SumIt(а);

Объект sa является закрытым, и поэтому он может быть благополучно заблокирован.
При таком подходе к синхронизации потоков данная программа дает такой же
правильный результат, как и при первоначальном подходе.

*/

#endregion

#region English

/*

An Alternative Approach

Although locking a method’s code, as shown in the previous example, is an easy and
effective means of achieving synchronization, it will not work in all cases. For example, you
might want to synchronize access to a method of a class you did not create, which is itself
not synchronized. This can occur if you want to use a class that was written by a third party
and for which you do not have access to the source code. Thus, it is not possible for you to
add a lock statement to the appropriate method within the class. How can access to an
object of this class be synchronized? Fortunately, the solution to this problem is simple: Lock
access to the object from code outside the object by specifying the object in a lock statement.
For example, here is an alternative implementation of the preceding program. Notice that
the code within SumIt ) is no longer locked and no longer declares the lockOn object.
Instead, calls to SumIt() are locked within MyThread.

*/

// Another way to use lock to synchronize access to an object.  

//using System; 
//using System.Threading; 

//class SumArray
//{
//    int sum;

//    public int SumIt(int[] nums)
//    {
//        sum = 0; // reset sum  

//        for (int i = 0; i < nums.Length; i++)
//        {
//            sum += nums[i];
//            Console.WriteLine("Running total for " +
//                   Thread.CurrentThread.Name +
//                   " is " + sum);
//            Thread.Sleep(10); // allow task-switch  
//        }
//        return sum;
//    }
//}

//class MyThread
//{
//    public Thread Thrd;
//    int[] a;
//    int answer;

//    /* Create one SumArray object for all 
//       instances of MyThread. */
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

//        // Lock calls to SumIt().  
//        lock (sa) answer = sa.SumIt(a);

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
//    }
//}

/*

Here, the call to sa.SumIt() is locked, rather than the code inside SumIt() itself. The code
that accomplishes this is shown here:

// Lock calls to SumIt().
lock(sa) answer = sa.SumIt(a);

Because sa is a private object, it is safe to lock on. Using this approach, the program
produces the same correct results as the original approach.

*/

#endregion