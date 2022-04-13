#region Russian

/*

Организуя ожидание завершения нескольких задач, следует быть особенно внимательным,
чтобы избежать взаимоблокировок. Так, если две задачи ожидают завершения
друг друга, то вызов метода WaitAll() вообще не приведет к возврату из него.
Разумеется, условия для взаимоблокировок возникают в результате ошибок программирования,
которых следует избегать. Следовательно, если вызов метода WaitAll()
не приводит к возврату из него, то следует внимательно проанализировать, могут ли
две задачи или больше взаимно блокироваться. (Вызов метода Wait(), который не
приводит к возврату из него, также может стать причиной взаимоблокировок.)

Иногда требуется организовать ожидание до тех пор, пока не завершится любая из
группы задач. Для этой цели служит метод WaitAny(). Ниже приведена простейшая
форма его объявления.

public static int WaitAny(params Task[] tasks)

Задачи, завершения которых требуется ожидать, передаются с помощью параметра
в виде массива tasks объектов типа Task или отдельного списка аргументов типа
Task. Этот метод возвращает индекс задачи, которая завершается первой. При этом
могут быть сгенерированы различные исключения.

Попробуйте применить метод WaitAny() на практике, подставив в предыдущей
программе следующий вызов.

Task.WaitAny(tsk, tsk2);

Теперь, выполнение метода Main() возобновится, а программа завершится, как
только завершится одна из двух задач.

Помимо рассматривавшихся здесь форм методов Wait(), WaitAll() и
WaitAny(), имеются и другие их варианты, в которых можно указывать период простоя
или отслеживать признак отмены. (Подробнее об отмене задач речь пойдет далее
в этой главе.)

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
        Task.WaitAny(tsk, tsk2);

        Console.WriteLine("Основной поток завершен.");
    }
}

#endregion

#region English

/*

When waiting for multiple tasks, you need to be careful about deadlocks. If two tasks
are waiting on each other, then a call to WaitAll() will never return. Of course, deadlock
conditions are errors that you must avoid. Therefore, if a call to WaitAll() does not return,
consider the possibility that two or more of the tasks could be deadlocking. (A call to Wait()
that doesn’t return could also be the result of deadlock.)

Sometimes you will want to wait until any one of a group of tasks completes. To do this,
use the WaitAny() method. Here is its simplest form:

public static int WaitAny(params Task[] tasks)

The tasks that you want to wait for are passed via tasks. The tasks can be passed either as
an array of Task objects or separately as a list of Task arguments. It returns the index of the
task that completes first. Various exceptions are possible.

You can try WaitAny() in the previous program by substituting this call:

Task.WaitAny(tsk, tsk2);

Now, as soon as one task finishes, Main() resumes and the program ends.
In addition to the forms of Wait(), WaitAll(), and WaitAny() shown here, there are
versions that let you specify a timeout period or watch for a cancellation token. (Task
cancellation is described later in this chapter.)

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
//        Task.WaitAny(tsk, tsk2);

//        Console.WriteLine("Main thread ending.");
//    }
//}

#endregion