#region Russian

/*

Применение делегатов EventHandler<TEventArgs> и EventHandler

В приведенном выше примере программы объявлялся собственный делегат события.
Но как правило, в этом не никакой необходимости, поскольку в среде .NET
Framework предоставляется встроенный обобщенный делегат под названием
EventHandler<TEventArgs>. (Более подробно обобщенные типы рассматриваются
в главе 18.) В данном случае тип TEventArgs обозначает тип аргумента, передаваемого
параметру EventArgs события. Например, в приведенной выше программе событие
SomeEvent может быть объявлено в классе MyEvent следующим образом.

public event EventHandler<MyEventArgs> SomeEvent;

В общем, рекомендуется пользоваться именно таким способом, а не определять
собственный делегат.

Для обработки многих событий параметр типа EventArgs оказывается ненужным.
Поэтому с целью упростить создание кода в подобных ситуациях в среду .NET
Framework внедрен необобщенный делегат типа EventHandler. Он может быть использован
для объявления обработчиков событий, которым не требуется дополнительная
информация о событиях. Ниже приведен пример использования делегата
EventHandler.

*/

// Использовать встроенный делегат EventHandler.

using System;

// Объявить класс, содержащий событие.
class MyEvent
{
    public event EventHandler SomeEvent; // Использовать делегат EventHandler

    // Этот метод вызывается для запуска события.
    public void OnSomeEvent()
    {
        if (SomeEvent != null)
        {
            SomeEvent(this, EventArgs.Empty);
        }
    }
}

class EventDemo7
{
    static void Handler(object source, EventArgs arg)
    {
        Console.WriteLine("Произошло событие");
        Console.WriteLine("Источник: " + source);
    }

    static void Main()
    {
        MyEvent evt = new();

        // Добавить обработчик Handler() в цепочку событий.
        evt.SomeEvent += Handler;

        // Запустить событие.
        evt.OnSomeEvent();

        Console.ReadKey();
    }
}

/*

В данном примере параметр типа EventArgs не используется, поэтому в качестве
этого параметра передается объект-заполнитель EventArgs.Empty. Результат выполнения
кода из данного примера следующий.

Произошло событие
Источник: MyEvent

*/

#endregion

#region English

/*

Use EventHandler<TEventArgs> and EventHandler

The previous program declared its own event delegate. However, there is no need
to do this because the .NET Framework provides a built-in generic delegate called
EventHandler<TEventArgs>. (See Chapter 18 for a discussion of generic types.) Here,
the type of TEventArgs specifies the type of the argument passed to the EventArgs
parameter of the event. For example, in the preceding program, SomeEvent in MyEvent
could have been declared like this:

public event EventHandler<MyEventArgs> SomeEvent;

In general, it is better to use this approach rather than defining your own delegate.

For many events, the EventArgs parameter is unused. To help facilitate the creation
of code in these situations, the .NET Framework includes a non-generic delegate called
EventHandler, which can be used to declare event handlers in which no extra information
is needed. Here is an example that uses EventHandler:

*/

// Use the built-in EventHandler delegate. 

//using System; 

//// Declare a class that contains an event. 
//class MyEvent
//{
//    public event EventHandler SomeEvent; // uses EventHandler delegate 

//    // This is called to raise SomeEvent. 
//    public void OnSomeEvent()
//    {
//        if (SomeEvent != null)
//            SomeEvent(this, EventArgs.Empty);
//    }
//}

//class EventDemo7
//{
//    static void Handler(object sender, EventArgs e)
//    {
//        Console.WriteLine("Event occurred");
//        Console.WriteLine("Source is " + sender);
//    }

//    static void Main()
//    {
//        MyEvent evt = new MyEvent();

//        // Add Handler() to the event list. 
//        evt.SomeEvent += Handler;

//        // Raise the event. 
//        evt.OnSomeEvent();

//        Console.ReadKey();
//    }
//}

/*

In this case, the EventArgs parameter is unused and is passed the placeholder object
EventArgs.Empty. The output is shown here:

Event occurred
Source is MyEvent

*/

#endregion