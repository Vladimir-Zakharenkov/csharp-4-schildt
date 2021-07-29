#region Russian

/*

Пример групповой адресации события

Как и делегаты, события поддерживают групповую адресацию. Это дает возможность
нескольким объектам реагировать на уведомление о событии. Ниже приведен
пример групповой адресации события.

*/

// Продемонстрировать групповую адресацию события.

using System;

// Объявить тип делегата для события.
delegate void MyEventHandler();

//Объявить класс содержащий событие.
class MyEvent
{
    public event MyEventHandler SomeEvent;

    // Этот метод вызывается для запуска события.
    public void OnSomeEvent()
    {
        if (SomeEvent != null)
        {
            SomeEvent();
        }

        //SomeEvent?.Invoke();
    }
}

class X
{
    public void Xhandler()
    {
        Console.WriteLine("Событие получено объектом класса X");
    }
}

class Y
{
    public void Yhandler()
    {
        Console.WriteLine("Событие получено объектом класса Y");
    }
}

class EventDemo2
{
    static void Handler()
    {
        Console.WriteLine("Событие получено объектом класса EventDemo");
    }

    static void Main()
    {
        MyEvent evt = new MyEvent();
        X xOb = new X();
        Y yOb = new Y();

        // Добавить обработчики в список событий.
        evt.SomeEvent += Handler;
        evt.SomeEvent += xOb.Xhandler;
        evt.SomeEvent += yOb.Yhandler;

        // Запустить событие.
        evt.OnSomeEvent();
        Console.WriteLine();

        // Удалить обработчик.
        evt.SomeEvent -= xOb.Xhandler;
        evt.OnSomeEvent();

        Console.ReadKey();
    }
}

/*

При выполнении кода этого примера получается следующий результат.

Событие получено объектом класса EventDemo
Событие получено объектом класса X
Событие получено объектом класса Y

Событие получено объектом класса EventDemo
Событие получено объектом класса Y

В данном примере создаются два дополнительных класса, X и Y, в которых также
определяются обработчики событий, совместимые с делегатом MyEventHandler.
Поэтому эти обработчики могут быть также включены в цепочку событий. Обратите
внимание на то, что обработчики в классах X и Y не являются статическими. Это означает,
что сначала должны быть созданы объекты каждого из этих классов, а затем в
цепочку событий должны быть введены обработчики, связанные с их экземплярами.
Об отличиях между обработчиками экземпляра и статическими обработчиками речь
пойдет в следующем разделе.

*/

#endregion

#region English

/*

A Multicast Event Example

Like delegates, events can be multicast. This enables multiple objects to respond to an event
notification. Here is an event multicast example:

*/

// An event multicast demonstration. 

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
//    public void Xhandler()
//    {
//        Console.WriteLine("Event received by X object");
//    }
//}

//class Y
//{
//    public void Yhandler()
//    {
//        Console.WriteLine("Event received by Y object");
//    }
//}

//class EventDemo2
//{
//    static void Handler()
//    {
//        Console.WriteLine("Event received by EventDemo");
//    }

//    static void Main()
//    {
//        MyEvent evt = new MyEvent();
//        X xOb = new X();
//        Y yOb = new Y();

//        // Add handlers to the event list. 
//        evt.SomeEvent += Handler;
//        evt.SomeEvent += xOb.Xhandler;
//        evt.SomeEvent += yOb.Yhandler;

//        // Raise the event. 
//        evt.OnSomeEvent();
//        Console.WriteLine();

//        // Remove a handler. 
//        evt.SomeEvent -= xOb.Xhandler;
//        evt.OnSomeEvent();

//        Console.ReadKey();
//    }
//}

/*

The output from the program is shown here:

Event received by EventDemo
Event received by X object
Event received by Y object

Event received by EventDemo
Event received by Y object

This example creates two additional classes, called X and Y, which also define event handlers
compatible with MyEventHandler. Thus, these handlers can also become part of the event
chain. Notice that the handlers in X and Y are not static. This means that objects of each must
be created, and the handler linked to each instance must be added to the event chain. The
differences between instance and static handlers are examined in the next section.

*/

#endregion