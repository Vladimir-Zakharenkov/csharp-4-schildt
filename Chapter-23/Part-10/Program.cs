#region Russian

/*

Приоритеты потоков

У каждого потока имеется свой приоритет, который отчасти определяет, насколько
часто поток получает доступ к ЦП. Вообще говоря, низкоприоритетные потоки получают
доступ к ЦП реже, чем высокоприоритетные. Таким образом, в течение заданного
промежутка времени низкоприоритетному потоку будет доступно меньше времени
ЦП, чем высокоприоритетному. Как и следовало ожидать, время ЦП, получаемое потоком,
оказывает определяющее влияние на характер его выполнения и взаимодействия
с другими потоками, исполняемыми в настоящий момент в системе.

Следует иметь в виду, что, помимо приоритета, на частоту доступа потока к ЦП
оказывают влияние и другие факторы. Так, если высокоприоритетный поток ожидает
доступа к некоторому ресурсу, например для ввода с клавиатуры, он блокируется,
а вместо него выполняется низкоприоритетный поток. В подобной ситуации низкоприоритетный
поток может получать доступ к ЦП чаще, чем высокоприоритетный
поток в течение определенного периода времени. И наконец, конкретное планирование
задач на уровне операционной системы также оказывает влияние на время ЦП,
выделяемое для потока.

Когда порожденный поток начинает выполняться, он получает приоритет, устанавливаемый
по умолчанию. Приоритет потока можно изменить с помощью свойства
Priority, являющегося членом класса Thread. Ниже приведена общая форма данного
свойства:

public ThreadPriority Priority{ get; set; }

где ThreadPriority обозначает перечисление, в котором определяются приведенные
ниже значения приоритетов.

ThreadPriority.Highest
ThreadPriority.AboveNormal
ThreadPriority.Normal
ThreadPriority.BelowNormal
ThreadPriority.Lowest

По умолчанию для потока устанавливается значение приоритета ThreadPriority.Normal.

Для того чтобы стало понятнее влияние приоритетов на исполнение потоков, обратимся
к примеру, в котором выполняются два потока: один с более высоким приоритетом.
Оба потока создаются в качестве экземпляров объектов класса MyThread.
В методе Run() организуется цикл, в котором подсчитывается определенное число
повторений. Цикл завершается, когда подсчет достигает величины 1000000000 или когда
статическая переменная stop получает логическое значение true. Первоначально
переменная stop получает логическое значение false. В первом потоке, где производится
подсчет до 1000000000, устанавливается логическое значение true переменной
stop. В силу этого второй поток оканчивается на следующем своем интервале
времени. На каждом шаге цикла строка в переменной currentName проверяется на
наличие имени исполняемого потока. Если имена потоков не совпадают, это означает,
что произошло переключение исполняемых задач. Всякий раз, когда происходит
переключение задач, имя нового потока отображается и присваивается переменной
currentName. Это дает возможность отследить частоту доступа потока к ЦП. По окончании
обоих потоков отображается число повторений цикла в каждом из них.

*/

// Продемонстрировать влияние приоритетов потоков.

using System;
using System.Threading;

class MyThread
{
    public int Count;
    public Thread Thrd;

    static bool stop = false;
    static string currentName;

    // Сконструировать новый поток. Обратите внимание на то,
    // что данный конструктор еще не начинает выполнение потоков.
    public MyThread(string name)
    {
        Count = 0;
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        currentName = name;
    }

    // Начать выполнение нового потока.
    void Run()
    {
        Console.WriteLine("Поток " + Thrd.Name + " начат.");

        do
        {
            Count++;
            if (currentName != Thrd.Name)
            {
                currentName = Thrd.Name;
            }
        } while (stop == false && Count < 1000000000);

        stop = true;

        Console.WriteLine("Поток " + Thrd.Name + " завершен.");
    }
}

class PriorityDemo
{
    static void Main()
    {
        MyThread mt1 = new MyThread("с высоким приоритетом");
        MyThread mt2 = new MyThread("с низким приоритетом");

        // Установить приоритеты у потоков.
        mt1.Thrd.Priority = ThreadPriority.AboveNormal;
        mt2.Thrd.Priority = ThreadPriority.BelowNormal;

        // Начать потоки.
        mt1.Thrd.Start();
        mt2.Thrd.Start();

        mt1.Thrd.Join();
        mt2.Thrd.Join();

        Console.WriteLine();
        Console.WriteLine("Поток " + mt1.Thrd.Name + " досчитал до " + mt1.Count);
        Console.WriteLine("Поток " + mt2.Thrd.Name + " досчитал до " + mt2.Count);

        Console.ReadKey();
    }
}

/*

Вот к какому результату может привести выполнение этой программы.

Поток с высоким приоритетом начат.
В потоке с высоким приоритетом
Поток с низким приоритетом начат.
В потоке с низким приоритетом
В потоке с высоким приоритетом
В потоке с низким приоритетом
В потоке с высоким приоритетом
В потоке с низким приоритетом
В потоке с высоким приоритетом
В потоке с низким приоритетом
В потоке с высоким приоритетом
В потоке с низким приоритетом
В потоке с высоким приоритетом
Поток с высоким приоритетом завершен.
Поток с низким приоритетом завершен.

Поток с высоким приоритетом досчитал до 1000000000
Поток с низким приоритетом досчитал до 23996334

Судя по результату, высокоприоритетный поток получил около 98% всего времени,
которое было выделено для выполнения этой программы. Разумеется, конкретный результат
может отличаться в зависимости от быстродействия ЦП и числа других задач,
решаемых в системе, а также от используемой версии Windows.

Многопоточный код может вести себя по-разному в различных средах, поэтому
никогда не следует полагаться на результаты его выполнения только в одной среде.
Так, было бы ошибкой полагать, что низкоприоритетный поток из приведенного выше
примера будет всегда выполняться лишь в течение небольшого периода времени до
тех пор, пока не завершится высокоприоритетный поток. В другой среде высокоприоритетный
поток может, например, завершиться еще до того, как низкоприоритетный
поток выполнится хотя бы один раз.

*/

#endregion

#region English

/*

Thread Priorities

Each thread has a priority setting associated with it. A thread’s priority determines, in part,
how frequently a thread gains access to the CPU. In general, low-priority threads gain
access to the CPU less often than high-priority threads. As a result, within a given period of
time, a low-priority thread will often receive less CPU time than a high-priority thread. As
you might expect, how much CPU time a thread receives profoundly affects its execution
characteristics and its interaction with other threads currently executing in the system.

It is important to understand that factors other than a thread’s priority can also affect
how frequently a thread gains access to the CPU. For example, if a high-priority thread is
waiting on some resource, perhaps for keyboard input, it will be blocked, and a lowerpriority
thread will run. Thus, in this situation, a low-priority thread may gain greater
access to the CPU than the high-priority thread over a specific period. Finally, precisely how
task scheduling is implemented by the operating system affects how CPU time is allocated.

When a child thread is started, it receives a default priority setting. You can change a
thread’s priority through the Priority property, which is a member of Thread. This is its
general form:

public ThreadPriority Priority{ get; set; }

ThreadPriority is an enumeration that defines the following five priority settings:

ThreadPriority.Highest
ThreadPriority.AboveNormal
ThreadPriority.Normal
ThreadPriority.BelowNormal
ThreadPriority.Lowest

The default priority setting for a thread is ThreadPriority.Normal.

To understand how priorities affect thread execution, we will use an example that
executes two threads, one having a higher priority than the other. The threads are created as
instances of the MyThread class. The Run( ) method contains a loop that counts the number
of iterations. The loop stops when either the count reaches 1,000,000,000 or the static variable
stop is true. Initially, stop is set to false. The first thread to count to 1,000,000,000 sets stop
to true. This causes the second thread to terminate with its next time slice. Each time
through the loop, the string in currentName is checked against the name of the executing
thread. If they don’t match, it means that a task-switch occurred. Each time a task-switch
happens, the name of the new thread is displayed and currentName is given the name of
the new thread. This allows you to watch how often each thread has access to the CPU.
After both threads stop, the number of iterations for each loop is displayed.

*/

// Demonstrate thread priorities. 

//using System; 
//using System.Threading; 

//class MyThread
//{
//    public int Count;
//    public Thread Thrd;

//    static bool stop = false;
//    static string currentName;

//    /* Construct a new thread. Notice that this  
//       constructor does not actually start the 
//       threads running. */
//    public MyThread(string name)
//    {
//        Count = 0;
//        Thrd = new Thread(this.Run);
//        Thrd.Name = name;
//        currentName = name;
//    }

//    // Begin execution of new thread. 
//    void Run()
//    {
//        Console.WriteLine(Thrd.Name + " starting.");
//        do
//        {
//            Count++;

//            if (currentName != Thrd.Name)
//            {
//                currentName = Thrd.Name;
//                Console.WriteLine("In " + currentName);
//            }

//        } while (stop == false && Count < 1000000000);
//        stop = true;

//        Console.WriteLine(Thrd.Name + " terminating.");
//    }
//}

//class PriorityDemo
//{
//    static void Main()
//    {
//        MyThread mt1 = new MyThread("High Priority");
//        MyThread mt2 = new MyThread("Low Priority");

//        // Set the priorities. 
//        mt1.Thrd.Priority = ThreadPriority.AboveNormal;
//        mt2.Thrd.Priority = ThreadPriority.BelowNormal;

//        // Start the threads. 
//        mt1.Thrd.Start();
//        mt2.Thrd.Start();

//        mt1.Thrd.Join();
//        mt2.Thrd.Join();

//        Console.WriteLine();
//        Console.WriteLine(mt1.Thrd.Name + " thread counted to " +
//                          mt1.Count);
//        Console.WriteLine(mt2.Thrd.Name + " thread counted to " +
//                          mt2.Count);

//        Console.ReadKey();
//    }
//}

/*

Here is sample output:

High Priority starting.
In High Priority
Low Priority starting.
In Low Priority
In High Priority
In Low Priority
In High Priority
In Low Priority
In High Priority
In Low Priority
In High Priority
In Low Priority
In High Priority
High Priority terminating.
Low Priority terminating.

High Priority thread counted to 1000000000
Low Priority thread counted to 23996334

In this run, of the CPU time allotted to the program, the high-priority thread got approximately
98 percent. Of course, the precise output you see may vary, depending on the speed of your
CPU and the number of other tasks running on the system. Which version of Windows you
are running will also have an effect.

Because multithreaded code can behave differently in different environments, you
should never base your code on the execution characteristics of a single environment. For
example, in the preceding example, it would be a mistake to assume that the low-priority
thread will always execute at least a small amount of time before the high-priority thread
finishes. In a different environment, the high-priority thread might complete before the
low-priority thread has executed even once, for example.

*/




#endregion