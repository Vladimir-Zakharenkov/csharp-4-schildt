#region Russian

/*

Методы экземпляра в сравнении со статическими методами в качестве обработчиков событий

Методы экземпляра и статические методы могут быть использованы в качестве
обработчиков событий, но между ними имеется одно существенное отличие. Когда
статический метод используется в качестве обработчика, уведомление о событии распространяется
на весь класс. А когда в качестве обработчика используется метод экземпляра,
то события адресуются конкретным экземплярам объектов. Следовательно,
каждый объект определенного класса, которому требуется получить уведомление о событии,
должен быть зарегистрирован отдельно. На практике большинство обработчиков
событий представляет собой методы экземпляра, хотя это, конечно, зависит от
конкретного приложения. Рассмотрим применение каждой из этих двух разновидностей
методов в качестве обработчиков событий на конкретных примерах.

В приведенной ниже программе создается класс X, в котором метод экземпляра
определяется в качестве обработчика событий. Это означает, что каждый объект класса
X должен быть зарегистрирован отдельно, чтобы получать уведомления о событиях.
Для демонстрации этого факта в данной программе производится групповая адресация
события трем отдельным объектам класса X.

*/

/* Уведомления о событиях получают отдельные объекты, когда метод экземпляра
используется в качестве обработчика событий. */

using System;

// Объявить тип делегата для события.
delegate void MyEventHandler();

// Объявить класс, содержащий событие.
class MyEvent
{
    public event MyEventHandler SomeEvent;

    // Этот метод вызывается для запуска события.
    public void OnSomeEvrnt()
    {
        if (SomeEvent != null)
        {
            SomeEvent();
        }
    }
}

class X
{
    int id;

    public X(int x)
    {
        id = x;
    }

    // Этот метод экземпляра предназначен в качестве обработчика событий.

    public void Xhandler()
    {
        Console.WriteLine("Событие получено объектом " + id);
    }
}

class EventDemo3
{
    static void Main()
    {
        MyEvent evt = new MyEvent();
        X o1 = new X(1);
        X o2 = new X(2);
        X o3 = new X(3);

        evt.SomeEvent += o1.Xhandler;
        evt.SomeEvent += o2.Xhandler;
        evt.SomeEvent += o3.Xhandler;

        // Запустить событие.
        evt.OnSomeEvrnt();

        Console.ReadKey();
    }
}

/*
Выполнение кода из этого примера приводит к следующему результату.

Событие получено объектом 1
Событие получено объектом 2
Событие получено объектом 3

Как следует из результата выполнения кода из приведенного выше примера, каждый
объект должен зарегистрировать свой интерес в событии отдельно, и тогда он будет
получать отдельное уведомление о событии.

*/

#endregion

#region English

/*

Instance Methods vs. Static Methods as Event Handlers

Although both instance methods and static methods can be used as event handlers, they do
differ in one important way. When a static method is used as a handler, an event notification
applies to the class. When an instance method is used as an event handler, events are sent to
specific object instances. Thus, each object of a class that wants to receive an event notification
must register individually. In practice, most event handlers are instance methods, but, of
course, this is subject to the specific application. Let’s look at an example of each.

The following program creates a class called X that defines an instance method as an
event handler. This means that each X object must register individually to receive events.
To demonstrate this fact, the program multicasts an event to three objects of type X.

*/

/* Individual objects receive notifications when instance 
   event handlers are used. */

//using System; 

//// Declare a delegate type for an event.  
//delegate void MyEventHandler();

//// Declare a class that contains an event. 
//class MyEvent
//{
//    public event MyEventHandler SomeEvent;

//    // This is called to raise the event. 
//    public void OnSomeEvent()
//    {
//        if (SomeEvent != null)
//            SomeEvent();
//    }
//}

//class X
//{
//    int id;

//    public X(int x) { id = x; }

//    // This is an instance method that will be used as an event handler. 
//    public void Xhandler()
//    {
//        Console.WriteLine("Event received by object " + id);
//    }
//}

//class EventDemo3
//{
//    static void Main()
//    {
//        MyEvent evt = new MyEvent();
//        X o1 = new X(1);
//        X o2 = new X(2);
//        X o3 = new X(3);

//        evt.SomeEvent += o1.Xhandler;
//        evt.SomeEvent += o2.Xhandler;
//        evt.SomeEvent += o3.Xhandler;

//        // Raise the event. 
//        evt.OnSomeEvent();

//        Console.ReadKey();
//    }
//}

/*

The output from this program is shown here:

Event received by object 1
Event received by object 2
Event received by object 3

As the output shows, each object registers its interest in an event separately, and each
receives a separate notification.

*/

#endregion