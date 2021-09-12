#region Russian

/*

Класс Interlocked

Еще одним классом, связанным с синхронизацией, является класс Interlocked.
Этот класс служит в качестве альтернативы другим средствам синхронизации, когда
требуется только изменить значение общей переменной. Методы, доступные в классе
Interlocked, гарантируют, что их действие будет выполняться как единая, непрерываемая
операция. Это означает, что никакой синхронизации в данном случае вообще
не требуется. В классе Interlocked предоставляются статические методы для сложения
двух целых значений, инкрементирования и декрементирования целого значения,
сравнения и установки значений объекта, обмена объектами и получения 64-разрядного 
значения. Все эти операции выполняются без прерывания.

В приведенном ниже примере программы демонстрируется применение двух методов
из класса Interlocked:Increment() и Decrement(). При этом используются
следующие формы обоих методов:

public static int Increment(ref int location)
public static int Decrement(ref int location)

где location — это переменная, которая подлежит инкрементированию или декрементированию.

*/

// Использовать блокируемые операции.

using System;
using System.Threading;

// Общий ресурс.
class SharedRes
{
    public static int Count = 0;
}

// В этом потоке переменная SharedRes.Count инкрементируется.
class IncThread
{
    public Thread Thrd;

    public IncThread(string name)
    {
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        Thrd.Start();
    }

    // Точка входа в поток.
    void Run()
    {
        for (int i = 0; i < 5; i++)
        {
            Interlocked.Increment(ref SharedRes.Count);
            Console.WriteLine(Thrd.Name + " Count = " + SharedRes.Count);
        }
    }
}

// В этом потоке переменная SharedRes.Count декрементируется.
class DecThread
{
    public Thread Thrd;

    public DecThread(string name)
    {
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        Thrd.Start();
    }

    // Точка входа в поток.
    void Run()
    {
        for (int i = 0; i < 5; i++)
        {
            Interlocked.Decrement(ref SharedRes.Count);
            Console.WriteLine(Thrd.Name + " Count = " + SharedRes.Count);
        }
    }
}

class InterlockedDemo
{
    static void Main()
    {
        // Сконструировать два потока.
        IncThread mt1 = new IncThread("Инкрементирующий поток");
        DecThread mt2 = new DecThread("Декрементирующий поток");

        mt1.Thrd.Join();
        mt2.Thrd.Join();
    }
}

#endregion

#region English

/*

The Interlocked Class

One other class that is related to synchronization is Interlocked. This class offers an
alternative to the other synchronization features when all you need to do is change the
value of a shared variable. The methods provided by Interlocked guarantee that their
operation is performed as a single, uninterruptable operation. Thus, no other
synchronization is needed. Interlocked provides static methods that add two integers,
increment an integer, decrement an integer, compare and set an object, exchange objects,
and obtain a 64-bit value. All of these operations take place without interruption.

The following program demonstrates two Interlocked methods: Increment() and
Decrement(). Here are the forms of these methods that will be used:

public static int Increment(ref int location)
public static int Decrement(ref int location)

Here, location is the variable to be incremented or decremented.

*/

// Use Interlocked operations. 
  
//using System;  
//using System.Threading;  
 
//// A shared resource. 
//class SharedRes
//{
//    public static int Count = 0;
//}

//// This thread increments SharedRes.Count. 
//class IncThread
//{
//    public Thread Thrd;

//    public IncThread(string name)
//    {
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start();
//    }

//    // Entry point of thread.  
//    void Run()
//    {

//        for (int i = 0; i < 5; i++)
//        {
//            Interlocked.Increment(ref SharedRes.Count);
//            Console.WriteLine(Thrd.Name + " Count is " + SharedRes.Count);
//        }
//    }
//}

//// This thread decrements SharedRes.Count. 
//class DecThread
//{
//    public Thread Thrd;

//    public DecThread(string name)
//    {
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        Thrd.Start();
//    }

//    // Entry point of thread.  
//    void Run()
//    {

//        for (int i = 0; i < 5; i++)
//        {
//            Interlocked.Decrement(ref SharedRes.Count);
//            Console.WriteLine(Thrd.Name + " Count is " + SharedRes.Count);
//        }
//    }
//}

//class InterdlockedDemo
//{
//    static void Main()
//    {

//        // Construct two threads.  
//        IncThread mt1 = new IncThread("Increment Thread");
//        DecThread mt2 = new DecThread("Decrement Thread");

//        mt1.Thrd.Join();
//        mt2.Thrd.Join();
//    }
//}

#endregion