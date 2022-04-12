#region Russian

/*

Применение идентификатора задачи

В отличие от класса Thread; в классе Task отсутствует свойство Name для хранения
имени задачи. Но вместо этого в нем имеется свойство Id для хранения идентификатора
задачи, по которому можно распознавать задачи. Свойство Id доступно только для
чтения и относится к типу int. Оно объявляется следующим образом.

public int Id { get; }

Каждая задача получает идентификатор, когда она создается. Значения идентификаторов
уникальны, но не упорядочены. Поэтому один идентификатор задачи может
появиться перед другим, хотя он может и не иметь меньшее значение.

Идентификатор исполняемой в настоящий момент задачи можно выявить с помощью
свойства CurrentId. Это свойство доступно только для чтения, относится к типу
static и объявляется следующим образом.

public static Nullable<int> CurrentID { get; }

Оно возвращает исполняемую в настоящий момент задачу или же пустое значение,
если вызывающий код не является задачей.

В приведенном ниже примере программы создаются две задачи и показывается,
какая из них исполняется.

*/

// Продемонстрировать применение свойств ID и CurrentId.

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

        Console.WriteLine("Идентификатор задачи tsk: " + tsk.Id);
        Console.WriteLine("Идентификатор задачи tsk2: " + tsk2.Id);

        // Сохранить метод Main() активным до завершения остальных задач.
        for (int i = 0; i < 60; i++)
        {
            Console.Write(".");
            Thread.Sleep(100);
        }

        Console.WriteLine("Основной поток завершен.");
    }
}

/*

Выполнение этой программы приводит к следующему результату.

Основной поток запущен
Идентификатор задачи tsk: 1
Идентификатор задачи tsk2: 2
.MyTask() №1 запущен
MyTask() №2 запущен
.....В методе MyTask() №1, подсчет равен 0
В методе MyTask() №2, подсчет равен 0
.....В методе MyTask() №2, подсчет равен 1
В методе MyTask() №1, подсчет равен 1
.....В методе MyTask() №1, подсчет равен 2
В методе MyTask() №2, подсчет равен 2
.....В методе MyTask() №2, подсчет равен 3
В методе MyTask() №1, подсчет равен 3
.....В методе MyTask() №1, подсчет равен 4
В методе MyTask() №2, подсчет равен 4
.....В методе MyTask() №1, подсчет равен 5
В методе MyTask() №2, подсчет равен 5
.....В методе MyTask() №2, подсчет равен 6
В методе MyTask() №1, подсчет равен 6
.....В методе MyTask() №2, подсчет равен 7
В методе MyTask() №1, подсчет равен 7
.....В методе MyTask() №1, подсчет равен 8
В методе MyTask() №2, подсчет равен 8
.....В методе MyTask() №1, подсчет равен 9
MyTask №1 завершен
В методе MyTask() №2, подсчет равен 9
MyTask №2 завершен
.........Основной поток завершен.

*/

#endregion

#region English

/*

Use a Task ID

Unlike Thread, Task does not include a name property. It does, however, have an ID
property called Id, which can be used to identify the task. Id is a read-only property of type
int. It is shown here:

public int Id { get; }

A task is given an ID when it is created. The ID values are unique, but unordered. Therefore,
the ID of a task begun before another might not be lower in value.

You can find the ID of the currently executing task by using the CurrentId property.
This is a read-only static property, which is declared like this:

public static Nullable<int> CurrentID { get; }

It returns the ID of the currently executing task or null if the invoking code is not a task.
The following program creates two tasks and shows which task is executing:

*/

// Demonstrate the Id and CurrentId properties.
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
//            Console.WriteLine("In MyTask() #" + Task.CurrentId +
//            ", count is " + count);
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

//        // Keep Main() alive until the other tasks finish.
//        for (int i = 0; i < 60; i++)
//        {
//            Console.Write(".");
//            Thread.Sleep(100);
//        }
//        Console.WriteLine("Main thread ending.");
//    }
//}

/*

The output is shown here:

Main thread starting.
Task ID for tsk is 1
Task ID for tsk2 is 2
.MyTask() #1 starting
MyTask() #2 starting
.....In MyTask() #1, count is 0
In MyTask() #2, count is 0
.....In MyTask() #2, count is 1
In MyTask() #1, count is 1
.....In MyTask() #1, count is 2
In MyTask() #2, count is 2
.....In MyTask() #2, count is 3
In MyTask() #1, count is 3
.....In MyTask() #1, count is 4
In MyTask() #2, count is 4
....In MyTask() #1, count is 5
In MyTask() #2, count is 5
.....In MyTask() #2, count is 6
.In MyTask() #1, count is 6
....In MyTask() #2, count is 7
.In MyTask() #1, count is 7
....In MyTask() #1, count is 8
In MyTask() #2, count is 8
.....In MyTask() #1, count is 9
MyTask #1 terminating
In MyTask() #2, count is 9
MyTask #2 terminating
..........Main thread ending.

*/

#endregion