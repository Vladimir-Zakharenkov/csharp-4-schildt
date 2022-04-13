#region Russian

/*

В данном случае оказывается достаточно двух вызовов метода Wait(), но того же
результата можно добиться и более простым способом, воспользовавшись методом
WaitAll(). Этот метод организует ожидание завершения группы задач. Возврата из
него не произойдет до тех пор, пока не завершатся все задачи. Ниже приведена простейшая
форма объявления этого метода.

public static void WaitAll(params Task[] tasks)

Задачи, завершения которых требуется ожидать, передаются с помощью параметра
в виде массива tasks. А поскольку этот параметр относится к типу params,
то данному методу можно отдельно передать массив объектов типа Task или список
задач. При этом могут быть сгенерированы различные исключения, включая и
AggregateException.

Для того чтобы посмотреть, как метод WaitAll() действует на практике, замените
в приведенной выше программе следующую последовательность вызовов.

tsk.Wait();
tsk2.Wait();

на

Task.WaitAll(tsk, tsk2);

Программа будет работать точно так же, но логика ее выполнения станет более понятной.

*/

using System;
using System.Threading;
using System.Threading.Tasks;

class DemoTask
{
    // Метод, исполняемый как задача.
    static void MyTask()
    {
        Console.WriteLine("MyTask() №" + Task.CurrentId + " запущен");

        for (int count = 0; count < 10; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("В методе MyTask() #" + Task.CurrentId + ", подсчет равен " + count);
        }

        Console.WriteLine("MyTask №" + Task.CurrentId + " завершен");
    }

    static void Main()
    {
        Console.WriteLine("Основной поток запущен.");

        // Сконструировать объекты двух задач.
        Task tsk = new(MyTask);
        Task tsk2 = new(MyTask);

        // Запустить задачи на исполнение.
        tsk.Start();
        tsk2.Start();

        Console.WriteLine("Идентификатор задачи tsk:" + tsk.Id);
        Console.WriteLine("Идентификатор задачи tsk2:" + tsk2.Id);

        // Приостановить выполнение метода Main() до тех пор,
        // пока не завершатся обе задачи tsk и tsk2
        Task.WaitAll(tsk, tsk2);

        Console.WriteLine("Основной поток завершен.");
    }
}

#endregion

#region English

/*

Although using two separate calls to Wait() works in this case, there is a simpler way:
use WaitAll(). This method waits on a group of tasks. It will not return until all have
finished. Here is its simplest form:

public static void WaitAll(params Task[] tasks)

The tasks that you want to wait for are passed via tasks. Because this is a params parameter,
you can pass an array of Task objects or list of tasks separately. Various exceptions are
possible, including AggregateException.
To see WaitAll() in action, in the preceding program try replacing this sequence
tsk.Wait();
tsk2.Wait();
with
Task.WaitAll(tsk, tsk2);
The program will work the same, but the logic is cleaner and more compact.

*/

//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class DemoTask
//{
//    // A method to be run as a task.
//    static void MyTask()
//    {
//        Console.WriteLine("MyTask() #" + Task.CurrentId + " starting");

//        for (int count = 0; count < 10; count++)
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("In MyTask() #" + Task.CurrentId + ", count is " + count);
//        }

//        Console.WriteLine("MyTask #" + Task.CurrentId + " terminating");
//    }

//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // Construct two tasks.
//        Task tsk = new Task(MyTask);
//        Task tsk2 = new Task(MyTask);

//        // Run the tasks.
//        tsk.Start();
//        tsk2.Start();

//        Console.WriteLine("Task ID for tsk is " + tsk.Id);
//        Console.WriteLine("Task ID for tsk2 is " + tsk2.Id);

//        // Suspend Main() until both tsk and tsk2 finish.
//        Task.WaitAll(tsk, tsk2);

//        Console.WriteLine("Main thread ending.");
//    }
//}

#endregion