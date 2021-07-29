#region Russian

/*

Применение анонимных методов и лямбда-выражений вместе с событиями

Анонимные методы и лямбда-выражения особенно удобны для работы с событиями,
поскольку обработчик событий зачастую вызывается только в коде, реализующем
механизм обработки событий. Это означает, что создавать автономный метод, как правило,
нет никаких причин. А с помощью лямбда-выражений или анонимных методов
можно существенно упростить код обработки событий.

Как упоминалось выше, лямбда-выражениям теперь отдается большее предпочтение
по сравнению с анонимными методами, поэтому начнем именно с них. Ниже
приведен пример программы, в которой лямбда-выражение используется в качестве
обработчика событий.

*/

// Использовать лямбда-выражение в качестве обработчика событий.

using System;

// Объявить тип делегата для события.
delegate void MyEventHandler(int n);

// Объявить класс содержащий событие.
class MyEvent
{
    public event MyEventHandler SomeEvent;

    // Этот метод вызывается для запуска события.
    public void OnSomeEvent(int n)
    {
        if (SomeEvent != null)
        {
            SomeEvent(n);
        }
    }
}

class LambdaEventDemo
{
    static void Main()
    {
        MyEvent evt = new();

        // Использовать лямбда-выражение в  качестве обработчика событий.
        evt.SomeEvent += n => Console.WriteLine("Событие получено. Значение равно " + n);

        // Использовать анонимный метод в качестве обработчика событий.
        evt.SomeEvent += delegate (int n)
        {
            Console.WriteLine("Событие получено. Значение равно " + n);
        };

        // Запустить событие.
        evt.OnSomeEvent(1);
        evt.OnSomeEvent(2);

        Console.ReadKey();
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

Событие получено. Значение равно 1
Событие получено. Значение равно 2

Обратите особое внимание на то, как в этой программе лямбда-выражение используется
в качестве обработчика событий.

evt.SomeEvent += (n) =>
Console.WriteLine("Событие получено. Значение равно " + n);

Синтаксис для использования лямбда-выражения в качестве обработчика событий
остается таким же, как для его применения вместе с любым другим типом делегата.

Несмотря на то что при создании анонимной функции предпочтение следует
теперь отдавать лямбда-выражениям, в качестве обработчика событий можно по-
прежнему использовать анонимный метод. Ниже приведен вариант обработчика событий
из предыдущего примера, измененный с целью продемонстрировать применение
анонимного метода.

// Использовать анонимный метод в качестве обработчика событий.
evt.SomeEvent += delegate(int n) {
Console.WriteLine("Событие получено. Значение равно " + n);
};

Как видите, синтаксис использования анонимного метода в качестве обработчика
событий остается таким же, как и для его применения вместе с любым другим типом
делегата.

*/

#endregion

#region English

/*

Use Anonymous Methods and Lambda Expressions with Events

Anonymous methods and lambda expressions are especially useful when working with
events because often the event handler is not called by any code other than the event
handling mechanism. As a result, there is usually no reason to create a standalone method.
Thus, the use of lambda expressions or anonymous methods can significantly streamline
event handling code.

Since lambda expressions are now the preferred approach, we will start there. Here is an
example that uses a lambda expression as an event handler:

*/

// Use a lambda expression as an event handler.   
//using System;  

//// Declare a delegate type for an event.   
//delegate void MyEventHandler(int n);

//// Declare a class that contains an event. 
//class MyEvent
//{
//    public event MyEventHandler SomeEvent;

//    // This is called to raise the event.  
//    public void OnSomeEvent(int n)
//    {
//        if (SomeEvent != null)
//            SomeEvent(n);
//    }
//}

//class LambdaEventDemo
//{
//    static void Main()
//    {
//        MyEvent evt = new MyEvent();

//        // Use a lambda expression as an event handler. 
//        evt.SomeEvent += (n) =>
//          Console.WriteLine("Event received. Value is " + n);

//        // Use an anonymous method as an event handler.
//        evt.SomeEvent += delegate (int n)
//        {
//            Console.WriteLine("Event received. Value is" + n);
//        };

//        // Raise the event twice.  
//        evt.OnSomeEvent(1);
//        evt.OnSomeEvent(2);

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

Event received. Value is 1
Event received. Value is 2

In the program, pay special attention to the way the lambda expression is used as an
event handler, as shown here:

evt.SomeEvent += (n) =>
Console.WriteLine("Event received. Value is " + n);

The syntax for using a lambda expression event handler is the same as that for using a
lambda expression with any other type of delegate.

Although lambda expressions are now the preferred way to construct an anonymous
function, you can still use an anonymous method as an event handler if you so choose. For
example, here is the event handler from the previous example rewritten to use an
anonymous method:

// Use an anonymous method as an event handler.
evt.SomeEvent += delegate(int n) {
Console.WriteLine("Event received. Value is" + n);
};

As you can see, the syntax for using an anonymous event handler is the same as that for any
anonymous method.

*/

#endregion