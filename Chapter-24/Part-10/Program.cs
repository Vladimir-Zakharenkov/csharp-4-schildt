#region Russian

/*

Применение класса TaskFactory для запуска задачи

Приведенные выше примеры программы были составлены не так эффективно, как
следовало бы, поскольку задачу можно создать и сразу же начать ее исполнение, вызвав
метод StartNew(), определенный в классе TaskFactory. В классе TaskFactory
предоставляются различные методы, упрощающие создание задач и управление ими.
По умолчанию объект класса TaskFactory может быть получен из свойства Factory,
доступного только для чтения в классе Task. Используя это свойство, можно вызвать
любые методы класса TaskFactory. Метод StartNew() существует во множестве
форм. Ниже приведена самая простая форма его объявления:

public Task StartNew(Action action)

где action — точка входа в исполняемую задачу. Сначала в методе StartNew() автоматически
создается экземпляр объекта типа Task для действия, определяемого параметром
action, а затем планируется запуск задачи на исполнение. Следовательно,
необходимость в вызове метода Start() теперь отпадает.

Например, следующий вызов метода StartNew() в рассматривавшихся ранее программах
приведет к созданию и запуску задачи tsk одним действием.

Task tsk = Task.Factory.StartNew(MyTask);

После этого оператора сразу же начнет выполняться метод MyTask().
Метод StartNew() оказывается более эффективным в тех случаях, когда задача создается
и сразу же запускается на исполнение. Поэтому именно такой подход и применяется
в последующих примерах программ.

*/

//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class DemoTask
//{
//    // Метод, исполняемый как задача.
//    static void MyTask()
//    {
//        Console.WriteLine("MyTask() №" + Task.CurrentId + " запущен");

//        for (int count = 0; count < 10; count++)
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("В методе MyTask() #" + Task.CurrentId + ", подсчет равен " + count);
//        }

//        Console.WriteLine("MyTask №" + Task.CurrentId + " завершен");
//    }

//    static void Main()
//    {
//        Console.WriteLine("Основной поток запущен.");

//        // Сконструировать объекты двух задач.
//        Task tsk = Task.Factory.StartNew(MyTask);
//        Task tsk2 = Task.Factory.StartNew(MyTask);

//        Console.WriteLine("Идентификатор задачи tsk:" + tsk.Id);
//        Console.WriteLine("Идентификатор задачи tsk2:" + tsk2.Id);

//        // Приостановить выполнение метода Main() до тех пор,
//        // пока не завершатся обе задачи tsk и tsk2
//        Task.WaitAny(tsk, tsk2);

//        Console.WriteLine("Основной поток завершен.");
//    }
//}

#endregion

#region English

/*

Using TaskFactory to Start a Task

The preceding examples are written a bit less efficiently than they need to be because it is
possible to create a task and start its execution in a single step by calling the StartNew()
method defined by TaskFactory. TaskFactory is a class that provides various methods that
streamline the creation and management of tasks. The default TaskFactory can be obtained
from the read-only Factory property provided by Task. Using this property, you can call any
of the TaskFactory methods.

There are many forms of StartNew(). The simplest version is shown here:

public Task StartNew(Action action)

Here, action is the entry point to the task to be executed. StartNew() automatically creates a
Task instance for action and then starts the task by scheduling it for execution. Thus, there is
no need to call Start().

For example, assuming the preceding programs, the following call creates and starts tsk
in one step:

Task tsk = Task.Factory.StartNew(MyTask);

After this statement executes, MyTask will begin executing.

Since StartNew() is more efficient when a task is going to be created and then
immediately started, subsequent examples will use this approach.

*/

using System;
using System.Threading;
using System.Threading.Tasks;

class DemoTask
{
    // A method to be run as a task.
    static void MyTask()
    {
        Console.WriteLine("MyTask() #" + Task.CurrentId + " starting");

        for (int count = 0; count < 10; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("In MyTask() #" + Task.CurrentId + ", count is " + count);
        }

        Console.WriteLine("MyTask #" + Task.CurrentId + " terminating");
    }

    static void Main()
    {
        Console.WriteLine("Main thread starting.");

        // Construct two tasks.
        Task tsk = Task.Factory.StartNew(MyTask);
        Task tsk2 = Task.Factory.StartNew(MyTask);

        Console.WriteLine("Task ID for tsk is " + tsk.Id);
        Console.WriteLine("Task ID for tsk2 is " + tsk2.Id);

        // Suspend Main() until both tsk and tsk2 finish.
        Task.WaitAny(tsk, tsk2);

        Console.WriteLine("Main thread ending.");
    }
}

#endregion