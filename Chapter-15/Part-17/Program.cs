#region Russian

/*

Применение аксессоров событий

В приведенных выше примерах события формировались в форме, допускавшей автоматическое
управление списком вызовов обработчиков событий, включая добавление
и удаление обработчиков событий из списка. Поэтому управление этим списком
не нужно было организовывать вручную. Благодаря именно этому свойству такие события
используются чаще всего. Тем не менее организовать управление списком вызовов
обработчиков событий можно и вручную, чтобы, например, реализовать специальный
механизм сохранения событий.

Для управления списком обработчиков событий служит расширенная форма оператора
event, позволяющая использовать аксессоры событий. Эти аксессоры предоставляют
средства для управления реализацией подобного списка в приведенной
ниже форме.

event делегат_события имя_события {
add {
// Код добавления события в цепочку событий.
}
remove {
// Код удаления события из цепочки событий.
}
}

В эту форму входят два аксессора событий: add и remove. Аксессор add вызывается,
когда обработчик событий добавляется в цепочку событий с помощью оператора +=.
В то же время аксессор remove вызывается, когда обработчик событий удаляется из
цепочки событий с помощью оператора -=.

Когда вызывается аксессор add или remove, он принимает в качестве параметра
добавляемый или удаляемый обработчик. Как и в других разновидностях аксессоров,
этот неявный параметр называется value. Реализовав аксессоры add или remove,
можно организовать специальную схему хранения обработчиков событий. Например,
обработчики событий можно хранить в массиве, стеке или очереди.

Ниже приведен пример программы, демонстрирующей аксессорную форму события.
В ней для хранения обработчиков событий используется массив. Этот массив
состоит всего из трех элементов, поэтому в цепочке событий можно хранить одновременно
только три обработчика.

*/

// Создать специальные средства для управления списками вызова обработчиков событий.

using System;

// Объявить тип делегата для события.
delegate void MyEventHandler();

// Объявить класс для хранения максимум трех событий.
class MyEvent
{
    MyEventHandler[] evnt = new MyEventHandler[3];

    public event MyEventHandler SomeEvent
    {
        // Добавить событие в список.
        add
        {
            int i;

            for (i = 0; i < 3; i++)
            {
                if (evnt[i] == null)
                {
                    evnt[i] = value;
                    break;
                }
            }

            if (i == 3)
            {
                Console.WriteLine("Список событий заполнен.");
            }
        }

        // Удалить событие из списка.
        remove
        {
            int i;

            for (i = 0; i < 3; i++)
            {
                if (evnt[i] == value)
                {
                    evnt[i] = null;
                    break;
                }
            }

            if (i == 3)
            {
                Console.WriteLine("Обработчик событий не найден.");
            }
        }
    }

    // Этот метод вызывается для запуска событий.
    public void OnSomeEvent()
    {
        for (int i = 0; i < 3; i++)
        {
            if (evnt[i] != null)
            {
                evnt[i]();
            }
        }
    }
}

// Создать ряд классов, использующих делегат MyEventHandler.
class W
{
    public void Whandler()
    {
        Console.WriteLine("Событие получено объектом W");
    }
}

class X
{
    public void Xhandler()
    {
        Console.WriteLine("Событие получено объектом X");
    }
}

class Y
{
    public void Yhandler()
    {
        Console.WriteLine("Событие получено объектом Y");
    }
}

class Z
{
    public void Zhandler()
    {
        Console.WriteLine("Событие получено объектом Z");
    }
}

class EventDemo5
{
    static void Main()
    {
        MyEvent evt = new MyEvent();
        W wOb = new W();
        X xOb = new X();
        Y yOb = new Y();
        Z zOb = new Z();

        // Добавить обработчики в цепочку событий.
        Console.WriteLine("Добавление событий. ");
        evt.SomeEvent += wOb.Whandler;
        evt.SomeEvent += xOb.Xhandler;
        evt.SomeEvent += yOb.Yhandler;

        // Сохранить нельзя - список заполнен
        evt.SomeEvent += zOb.Zhandler;
        Console.WriteLine();

        // Запустить события.
        evt.OnSomeEvent();
        Console.WriteLine();

        // Удалить обработчик.
        Console.WriteLine("Удаление обработчика xOb.Handler.");
        evt.SomeEvent -= xOb.Xhandler;
        evt.OnSomeEvent();

        Console.WriteLine();

        // попробовать удалить обработчик еще раз.
        Console.WriteLine("Попытка удалить обработчик xOb.Handler еще раз.");
        evt.SomeEvent -= xOb.Xhandler;
        evt.OnSomeEvent();

        Console.WriteLine();

        // А теперь добавить обработчик Zhandler.
        Console.WriteLine("Добавление обработчика zOb.Handler.");
        evt.SomeEvent += zOb.Zhandler;
        evt.OnSomeEvent();

        Console.ReadKey();
    }
}

/*

Ниже приведен результат выполнения этой программы:

Добавление событий.
Список событий заполнен.

Событие получено объектом W
Событие получено объектом X
Событие получено объектом Y

Удаление обработчика xOb.Xhandler.
Событие получено объектом W
Событие получено объектом Y

Попытка удалить обработчик xOb.Xhandler еще раз.
Обработчик событий не найден.
Событие получено объектом W
Событие получено объектом Y

Добавление обработчика zOb.Zhandler.
Событие получено объектом W
Событие получено объектом Z
Событие получено объектом Y

Рассмотрим данную программу более подробно. Сначала в ней определяется делегат
обработчиков событий MyEventHandler. Затем объявляется класс MyEvent. В самом
его начале определяется массив обработчиков событий evnt, состоящий из трех
элементов.

MyEventHandler[] evnt = new MyEventHandler[3];

Этот массив служит для хранения обработчиков событий, добавляемых в цепочку
событий. По умолчанию элементы массива evnt инициализируются пустым значением
(null).

Далее объявляется событие SomeEvent. В этом объявлении используется приведенная
ниже аксессорная форма оператора event.

public event MyEventHandler SomeEvent {
// Добавить событие в список.
add {
int i;
for(i=0; i < 3; i++)
if(evnt[i] == null) {
evnt[i] = value;
break;
}
if (i == 3) Console.WriteLine("Список событий заполнен.");
}
// Удалить событие из списка.
remove {
int i;
for(i=0; i < 3; i++)
if(evnt[i] == value) {
evnt[i] = null;
break;
}
if (i == 3) Console.WriteLine("Обработчик событий не найден.");
}
}

Когда в цепочку событий добавляется обработчик событий, вызывается аксессор
add, и в первом неиспользуемом (т.е. пустом) элементе массива evnt запоминается
ссылка на этот обработчик, содержащаяся в неявно задаваемом параметре value. Если
в массиве отсутствуют свободные элементы, то выдается сообщение об ошибке. (Разумеется,
в реальном коде при переполнении списка лучше сгенерировать соответствующее
исключение.) Массив evnt состоит всего из трех элементов, поэтому в нем можно
сохранить только три обработчика событий. Когда же обработчик событий удаляется
из цепочки событий, то вызывается аксессор remove и в массиве evnt осуществляется
поиск ссылки на этот обработчик, передаваемой в качестве параметра value. Если
ссылка найдена, то соответствующему элементу массива присваивается пустое значение
(null), а значит, обработчик удаляется из цепочки событий.

При запуске события вызывается метод OnSomeEvent(). В этом методе происходит
циклическое обращение к элементам массива evnt для вызова по очереди каждого обработчика
событий.

Как демонстрирует рассматриваемый здесь пример программы, механизм хранения
обработчиков событий нетрудно реализовать, если в этом есть потребность. Но для большинства
приложений более подходящим оказывается используемый по умолчанию механизм
хранения обработчиков событий, который обеспечивает форма оператора event
без аксессоров. Тем не менее аксессорная форма оператора event используется в особых
случаях. Так, если обработчики событий необходимо выполнять в программе в порядке
их приоритетности, а не в том порядке, в каком они вводятся в цепочку событий, то для их
хранения можно воспользоваться очередью по приоритету.

ПРИМЕЧАНИЕ
В многопоточных приложениях обычно приходится синхронизировать доступ к аксессорам
событий. Подробнее о многопоточном программировании речь пойдет в главе 23.

*/

#endregion

#region English

/*

Using Event Accessors

The form of event used in the preceding examples created events that automatically manage
the event handler invocation list, including the adding and subtracting of event handlers
to and from the list. Thus, you did not need to implement any of the list management
functionality yourself. Because they manage the details for you, these types of events are
by far the most commonly used. It is possible, however, to provide the event handler list
operations yourself, perhaps to implement some type of specialized event storage mechanism.

To take control of the event handler list, you will use an expanded form of the event
statement, which allows the use of event accessors. The accessors give you control over how
the event handler list is implemented. This form is shown here:

event event-delegate event-name {
add {
// code to add an event to the chain
}
remove {
// code to remove an event from the chain
}
}

This form includes the two event accessors add and remove. The add accessor is called
when an event handler is added to the event chain, by using +=. The remove accessor is
called when an event handler is removed from the chain, by using – =.

When add or remove is called, it receives the handler to add or remove as a parameter.
As with other types of accessors, this parameter is called value. By implementing add and
remove, you can define a custom event-handler storage scheme. For example, you could
use an array, a stack, or a queue to store the handlers.

Here is an example that uses the accessor form of event. It uses an array to hold the
event handlers. Because the array is only three elements long, only three event handlers
can be held in the chain at any one time.

*/

// Create a custom means of managing the event invocation list. 

//using System;  

//// Declare a delegate type for an event.   
//delegate void MyEventHandler();

//// Declare a class that holds up to 3 events. 
//class MyEvent
//{
//    MyEventHandler[] evnt = new MyEventHandler[3];

//    public event MyEventHandler SomeEvent
//    {
//        // Add an event to the list. 
//        add
//        {
//            int i;

//            for (i = 0; i < 3; i++)
//                if (evnt[i] == null)
//                {
//                    evnt[i] = value;
//                    break;
//                }
//            if (i == 3) Console.WriteLine("Event list full.");
//        }

//        // Remove an event from the list. 
//        remove
//        {
//            int i;

//            for (i = 0; i < 3; i++)
//                if (evnt[i] == value)
//                {
//                    evnt[i] = null;
//                    break;
//                }
//            if (i == 3) Console.WriteLine("Event handler not found.");
//        }
//    }

//    // This is called to raise the events.  
//    public void OnSomeEvent()
//    {
//        for (int i = 0; i < 3; i++)
//            if (evnt[i] != null) evnt[i]();
//    }

//}

//// Create some classes that use MyEventHandler. 
//class W
//{
//    public void Whandler()
//    {
//        Console.WriteLine("Event received by W object");
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

//class Z
//{
//    public void Zhandler()
//    {
//        Console.WriteLine("Event received by Z object");
//    }
//}

//class EventDemo5
//{
//    static void Main()
//    {
//        MyEvent evt = new MyEvent();
//        W wOb = new W();
//        X xOb = new X();
//        Y yOb = new Y();
//        Z zOb = new Z();

//        // Add handlers to the event list. 
//        Console.WriteLine("Adding events.");
//        evt.SomeEvent += wOb.Whandler;
//        evt.SomeEvent += xOb.Xhandler;
//        evt.SomeEvent += yOb.Yhandler;

//        // Can't store this one -- full. 
//        evt.SomeEvent += zOb.Zhandler;
//        Console.WriteLine();

//        // Raise the events.  
//        evt.OnSomeEvent();
//        Console.WriteLine();

//        // Remove a handler. 
//        Console.WriteLine("Remove xOb.Xhandler.");
//        evt.SomeEvent -= xOb.Xhandler;
//        evt.OnSomeEvent();

//        Console.WriteLine();

//        // Try to remove it again. 
//        Console.WriteLine("Try to remove xOb.Xhandler again.");
//        evt.SomeEvent -= xOb.Xhandler;
//        evt.OnSomeEvent();

//        Console.WriteLine();

//        // Now, add Zhandler. 
//        Console.WriteLine("Add zOb.Zhandler.");
//        evt.SomeEvent += zOb.Zhandler;
//        evt.OnSomeEvent();

//        Console.ReadKey();
//    }
//}

/*

The output from the program is shown here:

Adding events.
Event list full.

Event received by W object
Event received by X object
Event received by Y object

Remove xOb.Xhandler.
Event received by W object
Event received by Y object

Try to remove xOb.Xhandler again.
Event handler not found.
Event received by W object
Event received by Y object

Add zOb.Zhandler.
Event received by W object
Event received by Z object
Event received by Y object

Let’s examine this program closely. First, an event handler delegate called MyEventHandler
is defined. Next, the class MyEvent is declared. It begins by defining a three-element array
of event handlers called evnt, as shown here:

MyEventHandler[] evnt = new MyEventHandler[3];

This array will be used to store the event handlers that are added to the event chain. The
elements in evnt are initialized to null by default.

Next, the event SomeEvent is declared. It uses the accessor form of the event statement,
as shown here:

public event MyEventHandler SomeEvent {
// Add an event to the list.
add {
int i;
for(i=0; i < 3; i++)
if(evnt[i] == null) {
evnt[i] = value;
break;
}
if (i == 3) Console.WriteLine("Event queue full.");
}

// Remove an event from the list.
remove {
int i;
for(i=0; i < 3; i++)
if(evnt[i] == value) {
evnt[i] = null;
break;
}
if (i == 3) Console.WriteLine("Event handler not found.");
}
}

When an event handler is added, add is called and a reference to the handler (contained in
value) is put into the first unused (that is, null) element of evnt. If no element is free, then
an error is reported. (Of course, throwing an exception when the list is full would be a better
approach for real-world code.) Since evnt is only three elements long, only three event
handlers can be stored. When an event handler is removed, remove is called and the evnt
array is searched for the reference to the handler passed in value. If it is found, its element
in the array is assigned null, thus removing the handler from the list.

When an event is raised, OnSomeEvent( ) is called. It cycles through the evnt array,
calling each event handler in turn.

As the preceding example shows, it is relatively easy to implement a custom eventhandler
storage mechanism if one is needed. For most applications, though, the default
storage provided by the non-accessor form of event is better. The accessor-based form of
event can be useful in certain specialized situations, however. For example, if you have a
program in which event handlers need to be executed in order of their priority and not in
the order in which they are added to the chain, then you could use a priority queue to store
the handlers.

NOTE
In multithreaded applications, you will usually need to synchronize access to the event
accessors. For information on multithreaded programming, see Chapter 23.

*/

#endregion