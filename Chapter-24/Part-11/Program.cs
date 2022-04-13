#region Russian

/*

Применение лямбда-выражения в качестве задачи

Кроме использования обычного метода в качестве задачи, существует и другой, более
рациональный подход: указать лямбда-выражение как отдельно решаемую задачу.
Напомним, что лямбда-выражения являются особой формой анонимных функций. Поэтому
они могут исполняться как отдельные задачи. Лямбда-выражения оказываются
особенно полезными в тех случаях, когда единственным назначением метода является
решение одноразовой задачи. Лямбда-выражения могут составлять отдельную задачу
или же вызывать другие методы. Так или иначе, применение лямбда-выражения в качестве
задачи может стать привлекательной альтернативой именованному методу.

В приведенном ниже примере программы демонстрируется применение лямбда-
выражения в качестве задачи. В этой программе код метода MyTask() из предыдущих
примеров программ преобразуется в лямбда-выражение.

*/

// Применить лямбда-выражение в качестве задачи.

using System;
using System.Threading;
using System.Threading.Tasks;

class DemoLambdaTask
{
    static void Main()
    {
        Console.WriteLine("Основной поток запущен");

        // Далее лямбда-выражение используется для определения задачи.
        Task tsk = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Задача запущена");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Подсчет в задаче равен " + count);
            }

            Console.WriteLine("Задача завершена");
        });

        // Ожидать завершение задачи tsk.
        tsk.Wait();

        // Освободить задачу tsk.
        tsk.Dispose();

        Console.WriteLine("Основной поток завершен");

    }
}

/*

Ниже приведен результат выполнения этой программы.

Основной поток запущен.
Задача запущена
Подсчет в задаче равен 0
Подсчет в задаче равен 1
Подсчет в задаче равен 2
Подсчет в задаче равен 3
Подсчет в задаче равен 4
Подсчет в задаче равен 5
Подсчет в задаче равен 6
Подсчет в задаче равен 7
Подсчет в задаче равен 8
Подсчет в задаче равен 9
Задача завершена
Основной поток завершен.

Помимо применения лямбда-выражения для описания задачи, обратите также
внимание в данной программе на то, что вызов метода tsk.Dispose() не делается до
тех пор, пока не произойдет возврат из метода tsk.Wait(). Как пояснялось в предыдущем
разделе, метод Dispose() можно вызывать только по завершении задачи.
Для того чтобы убедиться в этом, попробуйте поставить вызов метода tsk.Dispose()
в рассматриваемой здесь программе перед вызовом метода tsk.Wait(). Вы сразу же
заметите, что это приведет к исключительной ситуации.

*/

#endregion

#region English

/*

Use a Lambda Expression as a Task

Although there is nothing wrong with using a normal method as a task, there is a second
option that is more streamlined. You can simply specify a lambda expression as the task.
Recall that a lambda expression is a form of anonymous function. Thus, it can be run as
a separate task. The lambda expression is especially useful when the only purpose of a
method is to be a single-use task. The lambda can either constitute the entire task, or it
can invoke other methods. Either way, the lambda expression approach offers a pleasing
alternative to using a named method.

The following program demonstrates the use of a lambda expression as a task. It
converts the MyTask( ) code in preceding programs into a lambda expression.

*/

// Use a lambda expression as a task.
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class DemoLambdaTask
//{
//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // The following uses a lambda expression to define a task.
//        Task tsk = Task.Factory.StartNew(() =>
//        {
//            Console.WriteLine("Task starting");

//            for (int count = 0; count < 10; count++)
//            {
//                Thread.Sleep(500);
//                Console.WriteLine("Task count is " + count);
//            }

//            Console.WriteLine("Task terminating");
//        });

//        // Wait until tsk finishes.
//        tsk.Wait();

//        // Dispose of tsk.
//        tsk.Dispose();

//        Console.WriteLine("Main thread ending.");
//    }
//}

/*

The output is shown here:

Main thread starting.
Task starting
Task count is 0
Task count is 1
Task count is 2
Task count is 3
Task count is 4
Task count is 5
Task count is 6
Task count is 7
Task count is 8
Task count is 9
Task terminating
Main thread ending.

In addition to the use of a lambda expression to describe a task, notice that tsk.Dispose( )
is not called until after tsk.Wait( ) returns. As explained in the previous section, Dispose( ) can
be called only on a completed task. To prove this, try putting the call to tsk.Dispose( ) before
the call to tsk.Wait( ). As you will see, an exception is generated.

*/

#endregion