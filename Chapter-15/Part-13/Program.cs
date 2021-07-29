#region Russian

/*

События

Еще одним важным средством С#, основывающимся на делегатах, является событие.
Событие, по существу, представляет собой автоматическое уведомление о том,
что произошло некоторое действие. События действуют по следующему принципу:
объект, проявляющий интерес к событию, регистрирует обработчик этого события.
Когда же событие происходит, вызываются все зарегистрированные обработчики этого
события. Обработчики событий обычно представлены делегатами.

События являются членами класса и объявляются с помощью ключевого слова
event. Чаще всего для этой цели используется следующая форма:

event делегат_события имя_события;

где делегат_события обозначает имя делегата, используемого для поддержки события,
а имя_события — конкретный объект объявляемого события.

Рассмотрим для начала очень простой пример.

*/

// Очень простой пример, демонстрирующий событие.

using System;

// Объявить тип делегата для события.
delegate void MyEventHandler();

// Объявить класс содержащий событие.
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

class EventDemo
{
    // Обработчик события.
    static void Handler()
    {
        Console.WriteLine("Произошло событие");
    }

    static void Main()
    {
        MyEvent evt = new MyEvent();

        // Добавить метод Handler() в список событий.
        evt.SomeEvent += Handler;

        // Запустить событие.
        evt.OnSomeEvent();

        Console.ReadKey();
    }
}

/*

Вот какой результат получается при выполнении этого кода.

Произошло событие

Несмотря на всю свою простоту, данный пример кода содержит все основные элементы,
необходимые для обработки событий. Он начинается с объявления типа делегата
для обработчика событий, как показано ниже.

delegate void MyEventHandler();

Все события активизируются с помощью делегатов. Поэтому тип делегата события
определяет возвращаемый тип и сигнатуру для события. В данном случае параметры
события отсутствуют, но их разрешается указывать.

Далее создается класс события MyEvent. В этом классе объявляется событие
SomeEvent в следующей строке кода.

public event MyEventHandler SomeEvent;

Обратите внимание на синтаксис этого объявления. Ключевое слово event уведомляет
компилятор о том, что объявляется событие.

Кроме того, в классе MyEvent объявляется метод OnSomeEvent(), вызываемый для
сигнализации о запуске события. Это означает, что он вызывается, когда происходит
событие. В методе OnSomeEvent() вызывается обработчик событий с помощью делегата
SomeEvent.

if(SomeEvent != null)
SomeEvent();

Как видите, обработчик вызывается лишь в том случае, если событие SomeEvent не
является пустым. А поскольку интерес к событию должен быть зарегистрирован в других
частях программы, чтобы получать уведомления о нем, то метод OnSomeEvent()
может быть вызван до регистрации любого обработчика события. Но во избежание
вызова по пустой ссылке делегат события должен быть проверен, чтобы убедиться в
том, что он не является пустым.

В классе EventDemo создается обработчик событий Handler(). В данном простом
примере обработчик событий просто выводит сообщение, но другие обработчики
могут выполнять более содержательные функции. Далее в методе Main() создается
объект класса события MyEvent, a Handler() регистрируется как обработчик этого
события, добавляемый в список.

MyEvent evt = new MyEvent();
// Добавить метод Handler() в список событий.
evt.SomeEvent += Handler;

Обратите внимание на то, что обработчик добавляется в список с помощью оператора
+=. События поддерживают только операторы += и -=. В данном случае метод
Handler() является статическим, но в качестве обработчиков событий могут также
служить методы экземпляра.

И наконец, событие запускается, как показано ниже.

// Запустить событие.
evt.OnSomeEvent();

Вызов метода OnSomeEvent() приводит к вызову всех событий, зарегистрированных
обработчиком. В данном случае зарегистрирован только один такой обработчик,
но их может быть больше, как поясняется в следующем разделе.

*/

#endregion

#region English

/*

Events

Another important C# feature is built upon the foundation of delegates: the event. An event
is, essentially, an automatic notification that some action has occurred. Events work like this:
An object that has an interest in an event registers an event handler for that event. When the
event occurs, all registered handlers are called. Event handlers are represented by delegates.

Events are members of a class and are declared using the event keyword. Its most
commonly used form is shown here:

event event-delegate event-name;

Here, event-delegate is the name of the delegate used to support the event, and event-name is
the name of the specific event object being declared.

Let’s begin with a very simple example:

*/

// A very simple event demonstration. 

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

//class EventDemo
//{
//    // An event handler. 
//    static void Handler()
//    {
//        Console.WriteLine("Event occurred");
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

This program displays the following output:

Event occurred

Although simple, this program contains all the elements essential to proper event
handling. Let’s look at it carefully. The program begins by declaring a delegate type for
the event handler, as shown here:

delegate void MyEventHandler();

All events are activated through a delegate. Thus, the event delegate type defines the return
type and signature for the event. In this case, there are no parameters, but event parameters
are allowed.

Next, an event class, called MyEvent, is created. Inside the class, an event called
SomeEvent is declared, using this line:

public event MyEventHandler SomeEvent;

Notice the syntax. The keyword event tells the compiler that an event is being declared.

Also declared inside MyEvent is the method OnSomeEvent( ), which is the method a
program will call to raise (or “fire”) an event. (That is, this is the method called when the
event occurs.) It calls an event handler through the SomeEvent delegate, as shown here:

if(SomeEvent != null)
SomeEvent();

Notice that a handler is called if and only if SomeEvent is not null. Since other parts of your
program must register an interest in an event in order to receive event notifications, it is
possible that OnSomeEvent( ) could be called before any event handler has been registered.
To prevent calling on a null reference, the event delegate must be tested to ensure that it is
not null.

Inside EventDemo, an event handler called Handler( ) is created. In this simple example,
the event handler simply displays a message, but other handlers could perform more
meaningful actions. In Main( ), a MyEvent object is created, and Handler( ) is registered
as a handler for this event, by adding it as shown here:

MyEvent evt = new MyEvent();

// Add Handler() to the event list.
evt.SomeEvent += Handler;

Notice that the handler is added using the += operator. Events support only += and – =. In
this case, Handler( ) is a static method, but event handlers can also be instance methods.

Finally, the event is raised as shown here:

// Raise the event.
evt.OnSomeEvent();

Calling OnSomeEvent( ) causes all registered event handlers to be called. In this case, there
is only one registered handler, but there could be more, as the next section explains.

*/

#endregion