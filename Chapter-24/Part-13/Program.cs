#region Russian

/*

Любопытно, что в качестве продолжения задачи нередко применяется лямбда-
выражение. Для примера ниже приведен еще один способ организации продолжения
задачи из предыдущего примера программы.

*/

using System;
using System.Threading;
using System.Threading.Tasks;

class ContinuationDemo
{
    // Метод, исполняемый как задача.
    static void MyTask()
    {
        Console.WriteLine("MyTask() запущен");

        for (int count = 0; count < 5; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("В методе MyTask() подсчет равен " + count);
        }

        Console.WriteLine("MyTask() завершен");
    }

    static void Main()
    {
        Console.WriteLine("Основной поток запущен.");

        // Сконструировать объект первой задачи.
        Task tsk = new(MyTask);

        // А теперь создать продолжение задачи.
        Task taskCont = tsk.ContinueWith((first) =>
        {
            Console.WriteLine("Продолжение запущено");

            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В продолжении подсчет равен " + count);
            }

            Console.WriteLine("Продолжение завершено");
        });

        // Начать последовательность задач.
        tsk.Start();

        // Ожидать завершения продолжения.
        taskCont.Wait();

        tsk.Dispose();
        taskCont.Dispose();

        Console.WriteLine("Основной поток завершен.");
    }
}

/*

// В данном случае в качестве продолжения задачи применяется лямбда-выражение.

Task taskCont = tsk.ContinueWith((first) =>
        {
            Console.WriteLine("Продолжение запущено");

            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("В продолжении подсчет равен " + count);
            }

            Console.WriteLine("Продолжение завершено");
        });

В этом фрагменте кода параметр first принимает предыдущую задачу (в данном случае — tsk).

Помимо метода ContinueWith(), в классе Task предоставляются и другие методы,
поддерживающие продолжение задачи, обеспечиваемое классом TaskFactory. К их числу
относятся различные формы методов ContinueWhenAny() и ContinueWhenAll(),
которые продолжают задачу, если завершится любая или все указанные задачи соответственно.

*/

#endregion

#region English

/*

As a point of interest, it is not uncommon to use a lambda expression as a continuation
task. For example, here is another way to write the continuation used in the preceding
program:

*/

//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class ContinuationDemo
//{
//    // A method to be run as a task.
//    static void MyTask()
//    {
//        Console.WriteLine("MyTask() starting");

//        for (int count = 0; count < 5; count++)
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("In MyTask() count is " + count);
//        }

//        Console.WriteLine("MyTask terminating");
//    }

//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // Construct the first task.
//        Task tsk = new Task(MyTask);

//        // Now, create the continuation.
//        Task taskCont = tsk.ContinueWith((first) =>
//        {
//            for (int count = 0; count < 5; count++)
//            {
//                Thread.Sleep(500);
//                Console.WriteLine("Continuation count is " + count);
//            }

//            Console.WriteLine("Continuation terminating");
//        });

//        // Begin the task sequence.
//        tsk.Start();

//        // Just wait on the continuation.
//        taskCont.Wait();

//        tsk.Dispose();
//        taskCont.Dispose();

//        Console.WriteLine("Main thread ending.");
//    }
//}

/*

// Here, a lambda expression is used as the continuation.
Task taskCont = tsk.ContinueWith((first) =>
            {
                for (int count = 0; count < 5; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Continuation count is " + count);
                }

                Console.WriteLine("Continuation terminating");
            });

Here, the parameter first receives the antecedent task (which is tsk in this case).

In addition to ContinueWith() provided by Task, there are other methods that
support task continuation provided by TaskFactory. These include various forms of
ContinueWhenAny() and ContinueWhenAll(), which continue a task when any or
all of the specified tasks complete, respectively.

*/

#endregion