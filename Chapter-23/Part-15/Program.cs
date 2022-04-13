#region Russian

/*

Пример использования методов Wait() и Pulse()

Для того чтобы стало понятнее назначение методов Wait() и Pulse(), рассмотрим
пример программы, имитирующей тиканье часов и отображающей этот процесс на
экране словами "тик" и "так". Для этой цели в программе создается класс TickTock,
содержащий два следующих метода: Tick() и Тоск(). Метод Tick() выводит на
экран слово "тик", а метод Тоск() — слово "так". Для запуска часов далее в программе
создаются два потока: один из них вызывает метод Tick(), а другой — метод Тоск().
Преследуемая в данном случае цель состоит в том, чтобы оба потока выполнялись, поочередно
выводя на экран слова "тик" и "так", из которых образуется повторяющийся
ряд "тик-так", имитирующий ход часов.

*/

// Использовать методы Wait() и Pulse() для имитации тиканья часов.

using System;
using System.Threading;

class TickTock
{
    object lockOn = new();

    public void Tick(bool running)
    {
        lock (lockOn)
        {
            if (!running) // остановить часы
            {
                Monitor.Pulse(lockOn); // уведомить любые ожидающие потоки
                return;
            }

            Console.Write("\nтик-");
            Thread.Sleep(1000);
            Monitor.Pulse(lockOn); // разрешить выполнение метода Tock()
            Monitor.Wait(lockOn); // ожидать разрешения метода Tock()
        }
    }

    public void Tock(bool running)
    {
        lock (lockOn)
        {
            if (!running) // остановить часы
            {
                Monitor.Pulse(lockOn); // уведомить любые ожидающие потоки
                return;
            }

            Console.Write("так");
            Thread.Sleep(500);
            Monitor.Pulse(lockOn); // разрешить выполнение метода Tick()
            Monitor.Wait(lockOn); // ожидать завершение метода Tick()
        }
    }
}

class MyThread
{
    public Thread Thrd;
    TickTock ttob;

    // Сконструировать новый поток.
    public MyThread(string name, TickTock tt)
    {
        Thrd = new Thread(this.Run);
        ttob = tt;
        Thrd.Name = name;
        Thrd.Start();
    }

    // Начать выполнение нового потока.
    void Run()
    {
        if (Thrd.Name == "Tick")
        {
            for (int i = 0; i < 20; i++)
            {
                ttob.Tick(true);
            }

            ttob.Tick(false);
        }
        else
        {
            for (int i = 0; i < 20; i++)
            {
                ttob.Tock(true);
            }

            ttob.Tock(false);
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

        Console.WriteLine("\nЧасы остановлены");
    }
}

/*

Ниже приведен результат выполнения этой программы.

тик так
тик так
тик так
тик так
тик так
Часы остановлены

Рассмотрим эту программу более подробно. В методе Main() создается объект tt
типа TickTock, который используется для запуска двух потоков на выполнение. Если
в методе Run() из класса MyThread обнаруживается имя потока Tick, соответствующее
ходу часов "тик", то вызывается метод Tick(). А если это имя потока Тоск, соответствующее
ходу часов "так", то вызывается метод Тоск(). Каждый из этих методов
вызывается пять раз подряд с передачей логического значения true в качестве аргумента. 
Часы идут до тех пор, пока этим методам передается логическое значение true,
и останавливаются, как только передается логическое значение false.

Самая важная часть рассматриваемой здесь программы находится в методах
Tick() и Тоск(). Начнем с метода Tick(), код которого для удобства приводится
ниже.

public void Tick(bool running) {
lock(lockOn) {
if((running) { // остановить часы
Monitor.Pulse(lockOn); // уведомить любые ожидающие потоки
return;
}
Console.Write("тик ");
Monitor.Pulse(lockOn); // разрешить выполнение метода Tock()
Monitor.Wait(lockOn); // ожидать завершения метода Tock()
}
}

Прежде всего обратите внимание на код метода Tick() в блоке lock. Напомним,
что методы Wait() и Pulse() могут использоваться только в синхронизированных
блоках кода. В начале метода Tick() проверяется значение текущего параметра, которое
служит явным признаком остановки часов. Если это логическое значение false,
то часы остановлены. В этом случае вызывается метод Pulse(), разрешающий выполнение
любого потока, ожидающего своей очереди. Мы еще вернемся к этому моменту
в дальнейшем. Если же часы идут при выполнении метода Tick(), то на экран выводится
слово "тик" с пробелом, затем вызывается метод Pulse(), а после него — метод
Wait(). При вызове метода Pulse() разрешается выполнение потока для того же
самого объекта, а при вызове метода Wait() выполнение метода Tick() приостанавливается
до тех пор, пока метод Pulse() не будет вызван из другого потока. Таким
образом, когда вызывается метод Tick(), отображается одно слово "тик" с пробелом,
разрешается выполнение другого потока, а затем выполнение данного метода приостанавливается.

Метод Tock() является точной копией метода Tick(), за исключением того, что
он выводит на экран слово "так". Таким образом, при входе в метод Tock() на экран
выводится слово "так", вызывается метод Pulse(), а затем выполнение метода Tock()
приостанавливается. Методы Tick() и Tock() можно рассматривать как поочередно
сменяющие друг друга, т.е. они взаимно синхронизированы.

Когда часы остановлены, метод Pulse() вызывается для того, чтобы обеспечить
успешный вызов метода Wait(). Напомним, что метод Wait() вызывается в обоих
методах, Tick() и Tock(), после вывода соответствующего слова на экран. Но дело в
том, что когда часы остановлены, один из этих методов все еще находится в состоянии
ожидания. Поэтому завершающий вызов метода Pulse() требуется, чтобы выполнить
ожидающий метод до конца. В качестве эксперимента попробуйте удалить этот
вызов метода Pulse() и понаблюдайте за тем, что при этом произойдет. Вы сразу же
обнаружите, что программа "зависает", и для выхода из нее придется нажать комбинацию
клавиш <Ctrl+C>. Дело в том, что когда метод Wait() вызывается в последнем
вызове метода Tock(), соответствующий ему метод Pulse() не вызывается, а значит,
выполнение метода Tock() оказывается незавершенным, и он ожидает своей очереди
до бесконечности.

*/

#endregion

#region English

/*

An Example That Uses Wait() and Pulse()

To understand the need for and the application of Wait() and Pulse(), we will create a
program that simulates the ticking of a clock by displaying the words “Tick” and “Tock”
on the screen. To accomplish this, we will create a class called TickTock that contains two
methods: Tick() and Tock(). The Tick() method displays the word “Tick” and Tock()
displays “Tock”. To run the clock, two threads are created, one that calls Tick() and one that
calls Tock(). The goal is to make the two threads execute in a way that the output from the
program displays a consistent “Tick Tock”—that is, a repeated pattern of one “Tick”
followed by one “Tock.”

*/

// Use Wait() and Pulse() to create a ticking clock. 

//using System; 
//using System.Threading; 

//class TickTock
//{
//    object lockOn = new object();

//    public void Tick(bool running)
//    {
//        lock (lockOn)
//        {
//            if (!running)
//            { // stop the clock 
//                Monitor.Pulse(lockOn); // notify any waiting threads 
//                return;
//            }

//            Console.Write("Tick ");
//            Monitor.Pulse(lockOn); // let Tock() run 

//            Monitor.Wait(lockOn); // wait for Tock() to complete 
//        }
//    }

//    public void Tock(bool running)
//    {
//        lock (lockOn)
//        {
//            if (!running)
//            { // stop the clock 
//                Monitor.Pulse(lockOn); // notify any waiting threads 
//                return;
//            }

//            Console.WriteLine("Tock");
//            Monitor.Pulse(lockOn); // let Tick() run 

//            Monitor.Wait(lockOn); // wait for Tick() to complete 
//        }
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

Here is the output produced by the program:

Tick Tock
Tick Tock
Tick Tock
Tick Tock
Tick Tock
Clock Stopped

Let’s take a close look at this program. In Main(), a TickTock object called tt is created,
and this object is used to start two threads of execution. Inside the Run() method of
MyThread, if the name of the thread is “Tick,” calls to Tick() are made. If the name of the
thread is “Tock,” the Tock() method is called. Five calls that pass true as an argument are
made to each method. The clock runs as long as true is passed. A final call that passes false
to each method stops the clock.

The most important part of the program is found in the Tick() and Tock() methods.
We will begin with the Tick() method, which, for convenience, is shown here:
public void Tick(bool running) {
lock(lockOn) {
if(!running) { // stop the clock
Monitor.Pulse(lockOn); // notify any waiting threads
return;
}
Console.Write("Tick ");
Monitor.Pulse(lockOn); // let Tock() run
Monitor.Wait(lockOn); // wait for Tock() to complete
}
}

First, notice that the code in Tick() is contained within a lock block. Recall, Wait() and
Pulse() can be used only inside synchronized blocks. The method begins by checking the
value of the running parameter. This parameter is used to provide a clean shutdown of the
clock. If it is false, then the clock has been stopped. If this is the case, a call to Pulse() is
made to enable any waiting thread to run. We will return to this point in a moment.
Assuming the clock is running when Tick() executes, the word “Tick” is displayed, and
then a call to Pulse() takes place followed by a call to Wait(). The call to Pulse() allows a
thread waiting on the same lock to run. The call to Wait() causes Tick() to suspend until
another thread calls Pulse(). Thus, when Tick() is called, it displays one “Tick,” lets another
thread run, and then suspends.

The Tock() method is an exact copy of Tick(), except that it displays “Tock.” Thus,
when entered, it displays “Tock,” calls Pulse(), and then waits. When viewed as a pair, a
call to Tick() can be followed only by a call to Tock(), which can be followed only by a call
to Tick(), and so on. Therefore, the two methods are mutually synchronized.

The reason for the call to Pulse() when the clock is stopped is to allow a final call to Wait()
to succeed. Remember, both Tick() and Tock() execute a call to Wait() after displaying their
message. The problem is that when the clock is stopped, one of the methods will still be
waiting. Thus, a final call to Pulse() is required in order for the waiting method to run. As an
experiment, try removing this call to Pulse() inside Tick() and watch what happens. As you
will see, the program will “hang,” and you will need to press ctrl-c to exit. The reason for
this is that when the final call to Tock() calls Wait(), there is no corresponding call to Pulse()
that lets Tock() conclude. Thus, Tock() just sits there, waiting forever.

*/

#endregion