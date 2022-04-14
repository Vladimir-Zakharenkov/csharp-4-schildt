#region Russian

/*

Создание продолжения задачи

Одной из новаторских и очень удобных особенностей библиотеки TPL является возможность
создавать продолжение задачи. Продолжение — это одна задача, которая автоматически
начинается после завершения другой задачи. Создать продолжение можно,
в частности, с помощью метода ContinueWith(), определенного в классе Task.
Ниже приведена простейшая форма его объявления:

public Task ContinueWith(Action<Task> действие_продолжения)

где действие_продолжения обозначает задачу, которая будет запущена на исполнение
по завершении вызывающей задачи. У делегата Action имеется единственный параметр
типа Task. Следовательно, вариант делегата Action, применяемого в данном
методе, выглядит следующим образом.

public delegate void Action<in T>(T obj)

В данном случае обобщенный параметр T обозначает класс Task.

Продолжение задачи демонстрируется на примере следующей программы.

*/

// Продемонстрировать продолжение задачи.

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

    // Метод, исполняемый как продолжение задачи.
    static void ContTask(Task t)
    {
        Console.WriteLine("Продолжение запущено");

        for (int count = 0; count < 5; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("В продолжении подсчет равен " + count);
        }

        Console.WriteLine("Продолжение завершено");
    }

    static void Main()
    {
        Console.WriteLine("Основной поток запущен.");

        // Сконструировать объект первой задачи.
        Task tsk = new(MyTask);

        // А теперь создать продолжение задачи.
        Task taskCont = tsk.ContinueWith(ContTask);

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

Ниже приведен результата выполнения данной программы.

Основной поток запущен.
MyTask() запущен
В методе MyTask() подсчет равен 0
В методе MyTask() подсчет равен 1
В методе MyTask() подсчет равен 2
В методе MyTask() подсчет равен 3
В методе MyTask() подсчет равен 4
MyTask() завершен
Продолжение запущено
В продолжении подсчет равен 0
В продолжении подсчет равен 1
В продолжении подсчет равен 2
В продолжении подсчет равен 3
В продолжении подсчет равен 4
Продолжение завершено
Основной поток завершен.

Как следует из приведенного выше результата, вторая задача не начинается до тех
пор, пока не завершится первая. Обратите также внимание на то, что в методе Main()
пришлось ожидать окончания только продолжения задачи. Дело в том, что метод
MyTask() как задача завершается еще до начала метода ContTask как продолжения
задачи. Следовательно, ожидать завершения метода MyTask() нет никакой надобности,
хотя если и организовать такое ожидание, то в этом будет ничего плохого.

*/

#endregion

#region English

/*

Create a Task Continuation

One innovative, and very convenient, feature of the TPL is its ability to create a task
continuation. A continuation is a task that automatically begins when another task finishes.
One way to create a continuation is to use the ContinueWith() method defined by Task.
Its simplest form is shown here:

public Task ContinueWith(Action<Task> continuationAction)

Here, continuationAction specifies the task that will be run after the invoking task completes.
This delegate has one parameter of type Task. Thus, this is the version of the Action
delegate used by the method:

public delegate void Action<in T>(T obj)

In this case, T is Task.

The following program demonstrates a task continuation.

*/

// Demonstrate a continuation.
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

//    // A method to be run as a continuation.
//    static void ContTask(Task t)
//    {
//        Console.WriteLine("Continuation starting");

//        for (int count = 0; count < 5; count++)
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("Continuation count is " + count);
//        }

//        Console.WriteLine("Continuation terminating");
//    }
//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // Construct the first task.
//        Task tsk = new Task(MyTask);

//        // Now, create the continuation.
//        Task taskCont = tsk.ContinueWith(ContTask);

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

The output is shown here:

Main thread starting.
MyTask() starting
In MyTask() count is 0
In MyTask() count is 1
In MyTask() count is 2
In MyTask() count is 3
In MyTask() count is 4
MyTask terminating
Continuation starting
Continuation count is 0
Continuation count is 1
Continuation count is 2
Continuation count is 3
Continuation count is 4
Continuation terminating
Main thread ending.

As the output shows, the second task did not begin until the first task completed. Also
notice that it was necessary for Main() to wait only on the continuation task. This is
because MyTask() will be finished before ContTask begins. Thus, there is no need to wait
for MyTask(), although it would not be wrong to do so.

*/

#endregion