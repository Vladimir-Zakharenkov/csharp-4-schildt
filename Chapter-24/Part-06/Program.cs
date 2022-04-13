#region Russian

/*

Применение методов ожидания

В приведенных выше примерах основной поток исполнения, а по существу, метод
Main(), завершался последним потому, что такой результат гарантировали вызовы метода
Thread.Sleep(). Но подобный подход нельзя считать удовлетворительным.

Организовать ожидание завершения задач можно и более совершенным способом,
применяя методы ожидания, специально предоставляемые в классе Task. Самым простым
из них считается метод Wait(), приостанавливающий исполнение вызывающего
потока до тех пор, пока не завершится вызываемая задача. Ниже приведена простейшая
форма объявления этого метода.

public void Wait()

При выполнении этого метода могут быть сгенерированы два исключения. Первым
из них является исключение ObjectDisposedException. Оно генерируется в том
случае, если задача освобождена посредством вызова метода Dispose(). А второе исключение,
AggregateException, генерируется в том случае, если задача сама генерирует
исключение или же отменяется. Как правило, отслеживается и обрабатывается
именно это исключение. В связи с тем что задача может сгенерировать не одно исключение,
если, например, у нее имеются порожденные задачи, все подобные исключения
собираются в единое исключение типа AggregateException. Для того чтобы
выяснить, что же произошло на самом деле, достаточно проанализировать внутренние
исключения, связанные с этим совокупным исключением. А до тех пор в приведенных
далее примерах любые исключения, генерируемые задачами, будут обрабатываться во
время выполнения.

Ниже приведен вариант предыдущей программы, измененный с целью продемонстрировать
применение метода Wait() на практике. Этот метод используется внутри
метода Main(), чтобы приостановить его выполнение до тех пор, пока не завершатся
обе задачи tsk и tsk2.

*/

// Применить метод Wait().

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
//        Task tsk = new(MyTask);
//        Task tsk2 = new(MyTask);

//        // Запустить задачи на исполнение.
//        tsk.Start();
//        tsk2.Start();

//        Console.WriteLine("Идентификатор задачи tsk:" + tsk.Id);
//        Console.WriteLine("Идентификатор задачи tsk2:" + tsk2.Id);

//        // Приостановить выполнение метода Main() до тех пор,
//        // пока не завершатся обе задачи tsk и tsk2
//        tsk.Wait();
//        tsk2.Wait();

//        Console.WriteLine("Основной поток завершен.");
//    }
//}

/*

При выполнении этой программы получается следующий результат.

Основной поток запущен
Идентификатор задачи tsk: 1
Идентификатор задачи tsk2: 2
MyTask() №1 запущен
MyTask() №2 запущен
В методе MyTask() №1, подсчет равен 0
В методе MyTask() №2, подсчет равен 0
В методе MyTask() №1, подсчет равен 1
В методе MyTask() №2, подсчет равен 1
В методе MyTask() №1, подсчет равен 2
В методе MyTask() №2, подсчет равен 2
В методе MyTask() №1, подсчет равен 3
В методе MyTask() №2, подсчет равен 3
В методе MyTask() №1, подсчет равен 4
В методе MyTask() №2, подсчет равен 4
В методе MyTask() №1, подсчет равен 5
В методе MyTask() №2, подсчет равен 5
В методе MyTask() №1, подсчет равен 6
В методе MyTask() №2, подсчет равен 6
В методе MyTask() №1, подсчет равен 7
В методе MyTask() №2, подсчет равен 7
В методе MyTask() №1, подсчет равен 8
В методе MyTask() №2, подсчет равен 8
В методе MyTask() №1, подсчет равен 9
MyTask №1 завершен
В методе MyTask() №2, подсчет равен 9
MyTask №2 завершен
Основной поток завершен.

Как следует из приведенного выше результата, выполнение метода Main() приостанавливается
до тех пор, пока не завершатся обе задачи tsk и tsk2. Следует, однако, иметь
в виду, что в рассматриваемой здесь программе последовательность завершения задач
tsk и tsk2 не имеет особого значения для вызовов метода Wait(). Так, если первой завершается
задача tsk2, то в вызове метода tsk.Wait() будет по-прежнему ожидаться
завершение задачи tsk. В таком случае вызов метода tsk2.Wait() приведет к выполнению
и немедленному возврату из него, поскольку задача tsk2 уже завершена.

*/

#endregion

#region English

/*

Using Wait Methods

In the preceding examples, the Main() thread ended last because the calls to Thread.Sleep()
ensured this outcome, but this is not a satisfactory approach. The best way to wait for a task
to end is to use one of the wait methods that Task provides. The simplest one is called Wait(),
and it pauses execution of the calling thread until the invoking task completes. Here is its
most straightforward form:
public void Wait()
This method can throw two exceptions. The first is ObjectDisposedException. It is thrown
if the task has been released via a call to Dispose(). The second is AggregateException. It
is thrown when a task throws an exception or is cancelled. In general, you will want to
watch for and handle this exception. Because a task might produce more than one exception
(if it has child tasks, for example), they are aggregated into a single exception of type
AggregateException. You can then examine the inner exception(s) associated with this
exception to determine what happened. For now, the following examples will simply let
any task-based exceptions be handled by the runtime.
The following reworked version of the preceding program shows Wait() in action. It is
used inside Main() to suspend execution until both tsk and tsk2 finish.

*/

// Use Wait().
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
//        tsk.Wait();
//        tsk2.Wait();

//        Console.WriteLine("Main thread ending.");
//    }
//}

/*

Here is the output:

Main thread starting.
Task ID for tsk is 1
Task ID for tsk2 is 2
MyTask() #1 starting
MyTask() #2 starting
In MyTask() #1, count is 0
In MyTask() #2, count is 0
In MyTask() #1, count is 1
In MyTask() #2, count is 1
In MyTask() #1, count is 2
In MyTask() #2, count is 2
In MyTask() #1, count is 3
In MyTask() #2, count is 3
In MyTask() #1, count is 4
In MyTask() #2, count is 4
In MyTask() #1, count is 5
In MyTask() #2, count is 5
In MyTask() #1, count is 6
In MyTask() #2, count is 6
In MyTask() #1, count is 7
In MyTask() #2, count is 7
In MyTask() #1, count is 8
In MyTask() #2, count is 8
In MyTask() #1, count is 9
MyTask #1 terminating
In MyTask() #2, count is 9
MyTask #2 terminating
Main thread ending.

As the output shows, Main( ) suspends execution until both tsk and tsk2 terminate. It
is important to understand that in this program, the sequence in which tsk and tsk2 finish is
not important relative to the calls to Wait( ). For example, if tsk2 completed first, the call to
tsk.Wait( ) would still wait until tsk finished. Then, the call to tsk2.Wait( ) would execute
and return immediately, since tsk2 was already done.

*/

#endregion