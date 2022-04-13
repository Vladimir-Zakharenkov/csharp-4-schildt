#region Russian

/*

В приведенном выше примере программы задача, предназначавшаяся для параллельного
исполнения, обозначалась в виде статического метода. Но такое требование к
задаче не является обязательным. Например, в приведенной ниже программе, которая
является переработанным вариантом предыдущей, метод MyTask(), выполняющий
роль задачи, инкапсулирован внутри класса.

*/

// Использовать метод экземпляра в качестве задачи.

using System;
using System.Threading;
using System.Threading.Tasks;

class MyClass
{
    // Метод выполняемый в качестве задачи.
    public void MyTask()
    {
        Console.WriteLine("MyTask() запущен");

        for (int count = 0; count < 10; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("В методе MyTask(), подсчет равен " + count);
        }

        Console.WriteLine("MyTask() завершен");
    }
}

class DemoTask
{
    static void Main()
    {
        // Сконструировать объект типа MyClass.
        MyClass mc = new();

        // Сконструировать объект задачи для метода ms.MyTask().
        Task tsk = new(mc.MyTask);

        // Запустить задачу на исполнение.
        tsk.Start();

        // Сохранить метод Main() активным до завершения метода MyTask().
        for (int i = 0; i < 60; i++)
        {
            Console.Write(".");
            Thread.Sleep(100);
        }

        Console.WriteLine("Основной поток завершен.");
    }
}

/*

Результат выполнения этой программы получается таким же, как и прежде. Единственное
отличие состоит в том, что метод MyTask() вызывается теперь для экземпляра
объекта класса MyClass.

В отношении задач необходимо также иметь в виду следующее: после того, как задача
завершена, она не может быть перезапущена. Следовательно, иного способа повторного
запуска задачи на исполнение, кроме создания ее снова, не существует.

*/

#endregion

#region English

/*

In the foregoing example, the task to be concurrently executed is specified by a static
method. However, there is no requirement to this effect. For example, the following
program reworks the previous one so that MyTask() is encapsulated within a class:

*/

// Use an instance method as a task.
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class MyClass
//{
//    // A method to be run as a task.
//    public void MyTask()
//    {
//        Console.WriteLine("MyTask() starting");

//        for (int count = 0; count < 10; count++)
//        {
//            Thread.Sleep(500);
//            Console.WriteLine("In MyTask(), count is " + count);
//        }

//        Console.WriteLine("MyTask terminating");
//    }
//}

//class DemoTask
//{
//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // Construct a MyClass object.
//        MyClass mc = new MyClass();

//        // Construct a task on mc.MyTask().
//        Task tsk = new Task(mc.MyTask);

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

The output is the same as before. The only difference is that MyTask() is now called on
an instance of MyClass.

One other important point about tasks needs to be made now: once a task completes, it
cannot be restarted. Thus, there is no way to rerun a task without re-creating it.

*/

#endregion