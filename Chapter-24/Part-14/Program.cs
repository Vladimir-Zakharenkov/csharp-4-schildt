#region Russian

/*

Возврат значения из задачи

Задача может возвращать значение. Это очень удобно по двум причинам.
Во-первых, это означает, что с помощью задачи можно вычислить некоторый результат.
Подобным образом поддерживаются параллельные вычисления. И во-вторых, вызывающий
процесс окажется блокированным до тех пор, пока не будет получен результат.
Это означает, что для организации ожидания результата не требуется никакой
особой синхронизации.

Для того чтобы возвратить результат из задачи, достаточно создать эту задачу, используя
обобщенную форму Task<TResult> класса Task. Ниже приведены два конструктора
этой формы класса Task:

public Task(Func<TResult> функция)
public Task(Func<Object, TResult> функция, Object состояние)

где функция обозначает выполняемый делегат. Обратите внимание на то, что он должен
быть типа Func, а не Action. Тип Func используется именно в тех случаях, когда
задача возвращает результат. В первом конструкторе создается задача без аргументов,
а во втором конструкторе — задача, принимающая аргумент типа Object, передаваемый
как состояние. Имеются также другие конструкторы данного класса.

Как и следовало ожидать, имеются также другие варианты метода StartNew(),
доступные в обобщенной форме класса TaskFactory<TResult> и поддерживающие
возврат результата из задачи. Ниже приведены те варианты данного метода, которые
применяются параллельно с только что рассмотренными конструкторами класса Task.

public Task<TResult> StartNew(Func<TResult> функция)
public Task<TResult> StartNew(Func<Object,TResult> функция, Object состояние)

В любом случае значение, возвращаемое задачей, получается из свойства Result в
классе Task, которое определяется следующим образом.

public TResult Result { get; internal set; }

Аксессор set является внутренним для данного свойства, и поэтому оно оказывается
доступным во внешнем коде, по существу, только для чтения. Следовательно, задача
получения результата блокирует вызывающий код до тех пор, пока результат не будет
вычислен.

В приведенном ниже примере программы демонстрируется возврат задачей значений.
В этой программе создаются два метода. Первый из них, MyTask(), не принимает
параметров, а просто возвращает логическое значение true типа bool. Второй метод,
SumIt(), принимает единственный параметр, который приводится к типу int, и возвращает
сумму из значения, передаваемого в качестве этого параметра.

*/

// Возвратить значение из задачи.

using System;
using System.Threading;
using System.Threading.Tasks;

class DemoTask
{
    // Простейший метод, возвращающий результат и не принимающий аргументов.
    static bool MyTask()
    {
        return true;
    }

    // Этот метод возвращает сумму из положительного целого значения,
    // которое ему передается в качестве единственного параметра
    static int SumIt(object v)
    {
        int x = (int)v;
        int sum = 0;

        for (; x > 0; x--)
        {
            sum += x;
        }

        return sum;
    }

    static void Main()
    {
        Console.WriteLine("Основной поток запущен.");

        // Сконструировать объект первой задачи.
        Task<bool> tsk = Task<bool>.Factory.StartNew(MyTask);

        Console.WriteLine("Результат после выполнения задачи MyTask: " + tsk.Result);

        // Сконструировать объект второй задачи.
        Task<int> tsk2 = Task<int>.Factory.StartNew(SumIt, 3);

        Console.WriteLine("Результат после выполнения задачи SumIt: " + tsk2.Result);

        tsk.Dispose();
        tsk2.Dispose();

        Console.WriteLine("Основной поток завершен.");
    }
}

/*

Выполнение этой программы приводит к следующему результату.

Основной поток запущен.
Результат после выполнения задачи MyTask: True
Результат после выполнения Sumlt: 6
Основной поток завершен.

Помимо упомянутых выше форм класса Task<TResult> и метода
StartNew<TResult>, имеются также другие формы. Они позволяют указывать другие
дополнительные параметры.

*/

#endregion

#region English

/*

Returning a Value from a Task

A task can return a value. This is a very useful feature for two reasons. First, it means that
you can use a task to compute some result. This supports parallel computation. Second, the
calling process will block until the result is ready. This means that you don’t need to do any
special synchronization to wait for the result.

To return a result, you will create a task by using the generic form of Task, which is
Task<TResult>. Here are two of its constructors:

public Task(Func<TResult> function)
public Task(Func<Object, TResult> function, Object state)

Here, function is the delegate to be run. Notice that it is of type Func rather than Action.
Func is used when a task returns a result. The first form creates a task that takes no
arguments. The second form creates a task that takes an argument of type Object passed
in state. Other constructors are also available.

As you might expect, there are also versions of StartNew( ) provided by
TaskFactory<TResult> that support returning a result from a task. Here are the
ones that parallel the Task constructors just shown:

public Task<TResult> StartNew(Func<TResult> function)
public Task<TResult> StartNew(Func<Object,TResult> function, Object state)

In all cases, the value returned by the task is obtained from Task’s Result property,
which is defined like this:

public TResult Result { get; internal set; }

Because the set accessor is internal, this property is effectively read-only relative to external
code. The get accessor won’t return until the result is ready. Thus, retrieving the result
blocks the calling code until the result has been computed.

The following program demonstrates task return values. It creates two methods. The first
is MyTask( ), which takes no parameters. It simply returns the bool value true. The second is
SumIt( ), which has a single parameter (which is cast to int) and returns the summation of
the value passed to that parameter

*/

// Return a value from a task.
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class DemoTask
//{
//    // A trivial method that returns a result and takes no arguments.
//    static bool MyTask()
//    {
//        return true;
//    }

//    // This method returns the summation of a positive integer
//    // which is passed to it.
//    static int SumIt(object v)
//    {
//        int x = (int)v;
//        int sum = 0;
//        for (; x > 0; x--)
//            sum += x;
//        return sum;
//    }

//    static void Main()
//    {
//        Console.WriteLine("Main thread starting.");

//        // Construct the first task.
//        Task<bool> tsk = Task<bool>.Factory.StartNew(MyTask);
//        Console.WriteLine("After running MyTask. The result is " + tsk.Result);

//        // Construct the second task.
//        Task<int> tsk2 = Task<int>.Factory.StartNew(SumIt, 3);
//        Console.WriteLine("After running SumIt. The result is " + tsk2.Result);

//        tsk.Dispose();
//        tsk2.Dispose();

//        Console.WriteLine("Main thread ending.");
//    }
//}

/*

The output is shown here:

Main thread starting.
After running MyTask. The result is True
After running SumIt. The result is 6
Main thread ending.

In addition to the forms of Task<TResult> and StartNew<TResult> used here, there are
other forms available for use that let you specify other options.

*/

#endregion