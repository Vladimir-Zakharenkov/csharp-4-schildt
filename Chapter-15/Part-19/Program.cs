#region Russian

/*      

Рекомендации по обработке событий в среде .NET Framework

В C# разрешается формировать какие угодно разновидности событий. Но ради совместимости
программных компонентов со средой .NET Framework следует придерживаться
рекомендаций, установленных для этой цели корпорацией Microsoft. Эти
рекомендации, по существу, сводятся к следующему требованию: у обработчиков событий
должны быть два параметра. Первый из них — ссылка на объект, формирующий
событие, второй — параметр типа EventArgs, содержащий любую дополнительную
информацию о событии, которая требуется обработчику. Таким образом, .NET-
совместимые обработчики событий должны иметь следующую общую форму.

void обработчик(object отправитель, EventArgs е) {
// ...
}

Как правило, отправитель — это параметр, передаваемый вызывающим кодом с
помощью ключевого слова this. А параметр е типа EventArgs содержит дополнительную
информацию о событии и может быть проигнорирован, если он не нужен.

Сам класс EventArgs не содержит поля, которые могут быть использованы для
передачи дополнительных данных обработчику. Напротив, EventArgs служит в качестве
базового класса, от которого получается производный класс, содержащий все
необходимые поля. Тем не менее в классе EventArgs имеется одно поле Empty типа
static, которое представляет собой объект типа EventArgs без данных.

Ниже приведен пример программы, в которой формируется .NET-совместимое
событие.

*/

// Пример формирования .NET-совместимого события.

using System;

// Объявить класс, производный от класса EventArgs.
class MyEventArgs : EventArgs
{
    public int EventNum;
}

// Объявить тип делегата для события.
delegate void MyEventHandler(object source, MyEventArgs arg);

// Объявить класс, содержащий событие.
class MyEvent
{
    static int count = 0;

    public event MyEventHandler SomeEvent;

    // Этот метод запускает событие SomeEvent.
    public void OnSomeEvent()
    {
        MyEventArgs arg = new();

        if (SomeEvent != null)
        {
            arg.EventNum = count++;

            SomeEvent(this, arg);
        }
    }
}

class X
{
    public void Handler(object source, MyEventArgs arg)
    {
        Console.WriteLine("Событие " + arg.EventNum + " получено объектом класса X.");
        Console.WriteLine("Источник: " + source);
        Console.WriteLine();
    }
}

class Y
{
    public void Handler(object source, MyEventArgs arg)
    {
        Console.WriteLine("Событие " + arg.EventNum + " получено объектом класса Y.");
        Console.WriteLine("Источник: " + source);
        Console.WriteLine();
    }
}

class EventDemo6
{
    static void Main()
    {
        X ob1 = new();
        Y ob2 = new();
        MyEvent evt = new();

        // Добавить обработчик Handler() в цепочку событий.
        evt.SomeEvent += ob1.Handler;
        evt.SomeEvent += ob2.Handler;

        // Запустить событие.
        evt.OnSomeEvent();
        evt.OnSomeEvent();

        Console.ReadKey();
    }
}

/*

Ниже приведен результат выполнения этой программы.

Событие 0 получено объектом класса X
Источник: MyEvent

Событие 0 получено объектом класса Y
Источник: MyEvent

Событие 1 получено объектом класса X
Источник: MyEvent

Событие 1 получено объектом класса Y
Источник: MyEvent

В данном примере создается класс MyEventArgs, производный от класса EventArgs.
В классе MyEventArgs добавляется лишь одно его собственное поле: EventNum. Затем
объявляется делегат MyEventHandler, принимающий два параметра, требующиеся
для среды .NET Framework. Как пояснялось выше, первый параметр содержит ссылку
на объект, формирующий событие, а второй параметр — ссылку на объект класса
EventArgs или производного от него класса. Обработчики событий Handler(), определяемые
в классах X и Y, принимают параметры тех же самых типов.

В классе MyEvent объявляется событие SomeEvent типа MyEventHandler. Это
событие запускается в методе OnSomeEvent() с помощью делегата SomeEvent, которому
в качестве первого аргумента передается ссылка this, а вторым аргументом
служит экземпляр объекта типа MyEventArgs. Таким образом, делегату типа
MyEventHandler передаются надлежащие аргументы в соответствии с требованиями
совместимости со средой .NET.

*/

#endregion

#region English

/*

.NET Event Guidelines

C# allows you to write any type of event you desire. However, for component compatibility
with the .NET Framework, you will need to follow the guidelines Microsoft has established
for this purpose. At the core of these guidelines is the requirement that event handlers have
two parameters. The first is a reference to the object that generated the event. The second is
a parameter of type EventArgs that contains any other information required by the handler.
Thus, .NET-compatible event handlers will have this general form:

void handler(object sender, EventArgs e) {
// ...
}

Typically, the sender parameter is passed this by the calling code. The EventArgs parameter
contains additional information and can be ignored if it is not needed.

The EventArgs class itself does not contain fields that you use to pass additional data to
a handler. Instead, EventArgs is used as a base class from which you will derive a class that
contains the necessary fields. EventArgs does include one static field called Empty, which is
an EventArgs object that contains no data.

Here is an example that creates a .NET-compatible event:

*/

// A .NET-compatible event. 

//using System; 

//// Derive a class from EventArgs. 
//class MyEventArgs : EventArgs
//{
//    public int EventNum;
//}

//// Declare a delegate type for an event.  
//delegate void MyEventHandler(object sender, MyEventArgs e);

//// Declare a class that contains an event. 
//class MyEvent
//{
//    static int count = 0;

//    public event MyEventHandler SomeEvent;

//    // This raises SomeEvent. 
//    public void OnSomeEvent()
//    {
//        MyEventArgs arg = new MyEventArgs();

//        if (SomeEvent != null)
//        {
//            arg.EventNum = count++;
//            SomeEvent(this, arg);
//        }
//    }
//}

//class X
//{
//    public void Handler(object sender, MyEventArgs e)
//    {
//        Console.WriteLine("Event " + e.EventNum +
//                          " received by an X object.");
//        Console.WriteLine("Source is " + sender);
//        Console.WriteLine();
//    }
//}

//class Y
//{
//    public void Handler(object sender, MyEventArgs e)
//    {
//        Console.WriteLine("Event " + e.EventNum +
//                          " received by a Y object.");
//        Console.WriteLine("Source is " + sender);
//        Console.WriteLine();
//    }
//}

//class EventDemo6
//{
//    static void Main()
//    {
//        X ob1 = new X();
//        Y ob2 = new Y();
//        MyEvent evt = new MyEvent();

//        // Add Handler() to the event list. 
//        evt.SomeEvent += ob1.Handler;
//        evt.SomeEvent += ob2.Handler;

//        // Raise the event. 
//        evt.OnSomeEvent();
//        evt.OnSomeEvent();

//        Console.ReadKey();
//    }
//}

/*

Here is the output:

Event 0 received by an X object.
Source is MyEvent

Event 0 received by a Y object.
Source is MyEvent

Event 1 received by an X object.
Source is MyEvent

Event 1 received by a Y object.
Source is MyEvent

In this example, MyEventArgs is derived from EventArgs. MyEventArgs adds just one
field of its own: EventNum. The event handler delegate MyEventHandler now takes the
two parameters required by the .NET Framework. As explained, the first is an object
reference to the generator of the event. The second is a reference to EventArgs or a class
derived from EventArgs. The event handler in the X and Y classes, Handler( ), also has the
same types of parameters.

Inside MyEvent, a MyEventHandler called SomeEvent is declared. In the OnSomeEvent( )
method, SomeEvent is called with the first argument being this, and the second argument
being a MyEventArgs instance. Thus, the proper arguments are passed to MyEventHandler
to fulfill the requirements for .NET compatibility.

*/

#endregion