#region Russian

/*

Класс Task

В основу TPL положен класс Task. Элементарная единица исполнения инкапсулируется
в TPL средствами класса Task, а не Thread. Класс Task отличается от класса
Thread тем, что он является абстракцией, представляющей асинхронную операцию.
А в классе Thread инкапсулируется поток исполнения. Разумеется, на системном уровне
поток по-прежнему остается элементарной единицей исполнения, которую можно
планировать средствами операционной системы. Но соответствие экземпляра объекта
класса Task и потока исполнения не обязательно оказывается взаимно-однозначным.
Кроме того, исполнением задач управляет планировщик задач, который работает с пудом
потоков. Это, например, означает, что несколько задач могут разделять один и тот
же поток. Класс Task (и вся остальная библиотека TPL) определены в пространстве
имен System.Threading.Tasks.

Создание задачи

Создать новую задачу в виде объекта класса Task и начать ее исполнение можно
самыми разными способами. Для начала создадим объект типа Task с помощью конструктора
и запустим его, вызвав метод Start(). Для этой цели в классе Task определено
несколько конструкторов. Ниже приведен тот конструктор, которым мы собираемся
воспользоваться:

public Task(Action действие)

где действие обозначает точку входа в код, представляющий задачу, тогда как
Action — делегат, определенный в пространстве имен System. Форма делегата
Action, которой мы собираемся воспользоваться, выглядит следующим образом.

public delegate void Action()

Таким образом, точкой входа должен служить метод, не принимающий никаких
параметров и не возвращающий никаких значений. (Как будет показано далее, делегату
Action можно также передать аргумент.)

Как только задача будет создана, ее можно запустить на исполнение, вызвав метод
Start(). Ниже приведена одна из его форм.

public void Start()

После вызова метода Start() планировщик задач запланирует исполнение задачи.
В приведенной ниже программе все изложенное выше демонстрируется на практике.
В этой программе отдельная задача создается на основе метода MyTask(). После
того как начнет выполняться метод Main(), задача фактически создается и запускается
на исполнение. Оба метода MyTask() и Main() выполняются параллельно.

*/

// Создать и запустить задачу на исполнение.

using System;
using System.Threading;
using System.Threading.Tasks;

class DemoTask
{
    // Метод выполняемый в качестве задачи.

    static void MyTask()
    {
        Console.WriteLine("MyTask() запущен");

        for (int count = 0; count < 10; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("В методе MyTask(), подсчет равен " + count);
        }

        Console.WriteLine("MyTask завершен");
    }

    static void Main()
    {
        Console.WriteLine("Основной поток запущен.");

        // Сконструировать объект задачи.
        Task tsk = new Task(MyTask);

        // Запустить задачу на исполнение.
        tsk.Start();

        // метод Main() активным до завершения метода MyTask().
        for (int i = 0; i < 60; i++)
        {
            Console.Write(".");
            Thread.Sleep(100);
        }

        Console.WriteLine("Основной поток завершен.");
    }
}

/*

Ниже приведен результат выполнения этой программы. (У вас он может несколько
отличаться в зависимости от загрузки задач, операционной системы и прочих факторов.)

Основной поток запущен.
.MyTask() запущен
.....В методе MyTask(), подсчет равен 0
.....В методе MyTask(), подсчет равен 1
.....В методе MyTask(), подсчет равен 2
.....В методе MyTask(), подсчет равен 3
.....В методе MyTask(), подсчет равен 4
.....В методе MyTask(), подсчет равен 5
.....В методе MyTask(), подсчет равен 6
.....В методе MyTask(), подсчет равен 7
.....В методе MyTask(), подсчет равен 8
.....В методе MyTask(), подсчет равен 9
MyTask завершен
.........Основной поток завершен.

Следует иметь в виду, что по умолчанию задача исполняется в фоновом потоке.
Следовательно, при завершении создающего потока завершается и сама задача. Именно
поэтому в рассматриваемой здесь программе метод Thread.Sleep() использован
для сохранения активным основного потока до тех пор, пока не завершится выполнение
метода MyTask(). Как и следовало ожидать, организовать ожидание завершения
задачи можно и более совершенными способами, что и будет показано далее.

*/

#endregion

#region English

/*

The Task Class

At the core of the TPL is the Task class. With the TPL, the basic unit of execution is
encapsulated by Task, not Thread. Task differs from Thread in that Task is an abstraction
that represents an asynchronous operation. Thread encapsulates a thread of execution. Of
course, at the system level, a thread is still the basic unit of execution that can be scheduled
by the operating system. However, the correspondence between a Task instance and a
thread of execution is not necessarily one-to-one. Furthermore, task execution is managed
by a task scheduler, which works with a thread pool. This means that several tasks might
share the same thread, for example. The Task class (and all of the TPL) is defined in
System.Threading.Tasks.

Creating a Task

There are various ways to create a new Task and start its execution. We will begin by first
creating a Task using a constructor and then starting it by calling the Start( ) method. Task
defines several constructors. Here is the one we will be using:

public Task(Action action)

Here, action is the entry point of the code that represents the task. Action is a delegate
defined in System. It has several forms. Here is the form we will use now:

public delegate void Action()

Thus, the entry point must be a method that takes no parameters and returns void. (As you
will see later, it is possible to specify an argument to Action.)

Once a task has been created, you can start it by calling Start( ). One version is shown here:

public void Start()

After a call to Start(), the task scheduler schedules it for execution.
The following program puts the preceding discussion into action. It creates a separate
task based on the MyTask() method. After Main() starts, the task is created and then
started. Both MyTask() and Main() execute concurrently.

*/

// Create and run a task.

//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class DemoTask
//{
//    // A method to be run as a task.
//    static void MyTask()
//    {
//        Console.WriteLine("MyTask() starting");
//        for (int count = 0; count < 10; count++)
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("In MyTask(), count is " + count);
//        }
//        Console.WriteLine("MyTask terminating");
//    }

//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // Construct a task.
//        Task tsk = new Task(MyTask);

//        // Run the task.
//        tsk.Start();

//        // Keep Main() alive until MyTask() finishes.
//        for (int i = 0; i < 60; i++)
//        {
//            Console.Write(".");
//            Thread.Sleep(100);
//        }

//        Console.WriteLine("Main thread ending.");
//    }
//}

/*

The output is shown here. (The precise output that you see may differ slightly based on
task load, operating system, etc.)

Main thread starting.
.MyTask() starting
.....In MyTask(), count is 0
.....In MyTask(), count is 1
.....In MyTask(), count is 2
.....In MyTask(), count is 3
.....In MyTask(), count is 4
.....In MyTask(), count is 5
.....In MyTask(), count is 6
.....In MyTask(), count is 7
.....In MyTask(), count is 8
.....In MyTask(), count is 9
MyTask terminating
.........Main thread ending.

It is important to understand that, by default, a task executes in a background thread.
Thus, when the creating thread ends, the task will end. This is why Thread.Sleep() was
used to keep the main thread alive until MyTask() completed. As you would expect and
will soon see, there are far better ways of waiting for a task to finish.

*/

#endregion