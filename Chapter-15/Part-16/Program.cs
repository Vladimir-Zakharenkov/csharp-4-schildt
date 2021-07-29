#region Russian

/*

С другой стороны, когда в качестве обработчика событий используется статический
метод, события обрабатываются независимо от какого-либо объекта, как демонстрируется
в приведенном ниже примере программы.

*/

/* Уведомления о событии получает класс, когда статический метод
используется в качестве обработчика событий. */

using System;

// Объявить тип делегата для события.
delegate void MyEventHandler();

// Объявить класс, содержащий событие.
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
    }
}

class X
{
    // Этот статический метод предназначен в качестве обработчика событий.
    public static void Xhandler()
    {
        Console.WriteLine("Событие получено классом.");
    }
}

class EventDemo4
{
    static void Main()
    {
        MyEvent evt = new MyEvent();

        evt.SomeEvent += X.Xhandler;

        // Запустить событие.
        evt.OnSomeEvent();

        Console.ReadKey();
    }
}

/*

При выполнение кода этого примера получается следующий результат.

Событие получено классом.

Обратите в данном примере внимание на то, что объекты класса X вообще не
создаются. Но поскольку Xhandler() является статическим методом класса X, то
он может быть привязан к событию SomeEvent и выполнен при вызове метода
OnSomeEvent().

*/

#endregion

#region English

/*

Alternatively, when a static method is used as an event handler, events are handled
independently of any object, as the following program shows:

*/

/* A class receives the notification when  
   a static method is used as an event handler. */

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

//    /* This is a static method that will be used as 
//       an event handler. */
//    public static void Xhandler()
//    {
//        Console.WriteLine("Event received by class.");
//    }
//}

//class EventDemo4
//{
//    static void Main()
//    {
//        MyEvent evt = new MyEvent();

//        evt.SomeEvent += X.Xhandler;

//        // Raise the event. 
//        evt.OnSomeEvent();

//        Console.ReadKey();
//    }

//}

/*

The output from this program is shown here:

Event received by class.

In the program, notice that no object of type X is ever created. However, since Xhandler( ) is
a static method of X, it can be attached to SomeEvent and executed when OnSomeEvent( )
is called.

*/

#endregion