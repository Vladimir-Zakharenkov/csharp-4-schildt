#region Russian

/*

В приведенной ниже программе демонстрируется отмена задачи. В ней применяется
опрос для контроля состояния признака отмены. Обратите внимание на
то, что метод ThrowIfCancellationRequested() вызывается после входа в метод
MyTask(). Это дает возможность завершить задачу, если она была отмена еще до ее
запуска. Внутри цикла проверяется свойство IsCancellationRequested. Если это
свойство содержит логическое значение true, а оно устанавливается после вызова метода
Cancel() для экземпляра источника признаков отмены, то на экран выводится
сообщение об отмене и далее вызывается метод ThrowIfCancellationRequested()
для отмены задачи.

*/

// Простой пример отмены задачи с использованием опроса.

//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class DemoCancelTask
//{
//    // Метод, исполняемый как задача.
//    static void MyTask(Object ct)
//    {
//        CancellationToken cancelTok = (CancellationToken)ct;

//        // Проверить, отменена ли задача, прежде чем запускать ее.
//        cancelTok.ThrowIfCancellationRequested();

//        Console.WriteLine("MyTask() запущен");

//        for (int count = 0; count < 10; count++)
//        {
//            // В данном примере для отслеживания отмены задачи применяется опрос.
//            if (cancelTok.IsCancellationRequested)
//            {
//                Console.WriteLine("Получен запрос на отмену задачи.");
//                cancelTok.ThrowIfCancellationRequested();
//            }

//            Thread.Sleep(500);
//            Console.WriteLine("В методе MyTask() подсчет равен " + count);
//        }

//        Console.WriteLine("MyTask() завершен");
//    }

//    static void Main()
//    {
//        Console.WriteLine("Основной поток запущен.");

//        // Создать ообъект источника признаков отмены.
//        CancellationTokenSource cancelTokSrc = new();

//        // Запустить задачу, передав признак отмены ей самой и делегату.
//        Task tsk = Task.Factory.StartNew(MyTask, cancelTokSrc.Token, cancelTokSrc.Token);

//        // Дать задаче возможность исполниться вплоть до ее отмены.
//        Thread.Sleep(2000);

//        try
//        {
//            // Отменить задачу.
//            cancelTokSrc.Cancel();

//            // Приостановить выполнение метода Main() до тех пор,
//            // пока не завершится задача tsk.
//            tsk.Wait();
//        }
//        catch(AggregateException exc)
//        {
//            if (tsk.IsCanceled)
//            {
//                Console.WriteLine("\nЗадача tsk отменена\n");
//            }

//            // Для просмотра исключения снять комментарий со следующей строки кода:
//            // Console.WriteLine(exc);
//        }
//        finally
//        {
//            tsk.Dispose();
//            cancelTokSrc.Dispose();
//        }

//        Console.WriteLine("Основной поток завершен.");
//    }
//}

/*

Ниже приведен результат выполнения этой программы. Обратите внимание на то
что задача отменяется через 2 секунды.

Основной поток запущен.
MyTask() запущен
В методе MyTask() подсчет равен 0
В методе MyTask() подсчет равен 1
В методе MyTask() подсчет равен 2
В методе MyTask() подсчет равен 3
Получен запрос, на отмену задачи.

Задача tsk отменена

Основной поток завершен.

Как следует из приведенного выше результата, выполнение метода MyTask()
отменяется в методе Main() лишь две секунды спустя. Следовательно, в методе
MyTask() выполняются четыре шага цикла. Когда же перехватывается исключение
AggregateException, проверяется состояние задачи. Если задача tsk отменена, что
и должно произойти в данном примере, то об этом выводится соответствующее сообщение.
Следует, однако, иметь в виду, что когда сообщение AggregateException
генерируется в ответ на отмену задачи, то это еще не свидетельствует об ошибке, а просто
означает, что задача была отменена.

Выше были изложены лишь самые основные принципы, положенные в основу отмены
задачи и генерирования исключения AggregateException. Тем не менее эта
тема намного обширнее и требует от вас самостоятельного и углубленного изучения,
если вы действительно хотите создавать высокопроизводительные, масштабируемые
приложения.

*/

#endregion

#region English

/*

The following program demonstrates cancellation. It uses polling to monitor the state of
the cancellation token. Notice that ThrowIfCancellationRequested( ) is called on entry into
MyTask( ). This enables the task to be terminated if it was cancelled before it was started.
Inside the loop, IsCancellationRequested is checked. When this property is true (which it
will be after Cancel( ) is called on the token source), a message indicating cancellation is
displayed and ThrowIfCancellationRequested( ) is called to cancel the task.

*/

// A simple example of cancellation that uses polling.

using System;
using System.Threading;
using System.Threading.Tasks;

class DemoCancelTask
{
    // A method to be run as a task.
    static void MyTask(Object ct)
    {
        CancellationToken cancelTok = (CancellationToken)ct;

        // Check if cancelled prior to starting.
        cancelTok.ThrowIfCancellationRequested();

        Console.WriteLine("MyTask() starting");

        for (int count = 0; count < 10; count++)
        {
            // This example uses polling to watch for cancellation.
            if (cancelTok.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation request received.");
                cancelTok.ThrowIfCancellationRequested();
            }

            Thread.Sleep(500);

            Console.WriteLine("In MyTask(), count is " + count);
        }

        Console.WriteLine("MyTask terminating");
    }
    static void Main()
    {
        Console.WriteLine("Main thread starting.");

        // Create a cancellation token source.
        CancellationTokenSource cancelTokSrc = new CancellationTokenSource();

        // Start a task, passing the cancellation token to both
        // the delegate and the task.
        Task tsk = Task.Factory.StartNew(MyTask, cancelTokSrc.Token, cancelTokSrc.Token);

        // Let tsk run until cancelled.
        Thread.Sleep(2000);
        try
        {
            // Cancel the task.
            cancelTokSrc.Cancel();

            // Suspend Main() until tsk terminates.
            tsk.Wait();
        }
        catch (AggregateException exc)
        {
            if (tsk.IsCanceled)
                Console.WriteLine("\ntsk Cancelled\n");

            // To see the exception, un-comment this line:
            // Console.WriteLine(exc);
        }
        finally
        {
            tsk.Dispose();
            cancelTokSrc.Dispose();
        }

        Console.WriteLine("Main thread ending.");
    }
}

/*

The output is shown here. Notice that the task is cancelled after 2 seconds.

Main thread starting.
MyTask() starting
In MyTask(), count is 0
In MyTask(), count is 1
In MyTask(), count is 2
In MyTask(), count is 3
Cancellation request received.

tsk Cancelled

Main thread ending.

As the output shows, MyTask( ) was cancelled by Main( ) after a delay of 2 seconds.
Thus, MyTask( ) executes four loop iterations. When an AggregateException is caught,
the status of the task is checked. If it is cancelled (which it will be in this example), the
cancellation of tsk is reported. It is important to understand that when AggregateException
is thrown in response to a cancellation, it does not indicate an error. It simply means that the
task was cancelled.

Although the preceding discussion introduces the fundamental concepts behind task
cancellation and AggregateException, there is much more to these topics. These are areas
that you will need to study in-depth if you want to create high-performance, scalable code.

*/

#endregion