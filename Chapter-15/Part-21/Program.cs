#region Russian

/*

Практический пример обработки событий

События нередко применяются в таких ориентированных на обмен сообщениями
средах, как Windows. В подобной среде программа просто ожидает до тех пор, пока
не будет получено конкретное сообщение, а затем она предпринимает соответствующее
действие. Такая архитектура вполне пригодна для обработки событий средствами
С#, поскольку дает возможность создавать обработчики событий для реагирования
на различные сообщения и затем просто вызывать обработчик при получении конкретного
сообщения. Так, щелчок левой кнопкой мыши может быть связан с событием
LButtonClick. При получении сообщения о щелчке левой кнопкой мыши вызывается
метод OnLButtonClick(), и об этом событии уведомляются все зарегистрированные
обработчики.

Разработка программ для Windows, демонстрирующих такой подход, выходит
за рамки этой главы, тем не менее, рассмотрим пример, дающий представление о
принципе, по которому действует данный подход. В приведенной ниже программе
создается обработчик событий, связанных с нажатием клавиш. Всякий раз, когда
на клавиатуре нажимается клавиша, запускается событие KeyPress при вызове метода
OnKeyPress(). Следует заметить, что в этой программе формируются .NET-
совместимые события и что их обработчики предоставляются в лямбда-выражениях.

*/

// Пример обработки событий, связанных с нажатием клавиш на клавиатуре.

using System;

// Создать класс, производный от класса EventArgs и хранящий символ нажатой клавиши.
class KeyEventArgs : EventArgs
{
    public char ch;
}

// Объявить класс события, связанного с нажатием клавиши на клавиатуре.
class KeyEvent
{
    public event EventHandler<KeyEventArgs> KeyPress;

    // Этот метод вызывается при нажатии клавиши.
    public void OnKeyPress(char key)
    {
        KeyEventArgs k = new();

        if (KeyPress != null)
        {
            k.ch = key;
            KeyPress(this, k);
        }
    }
}

// Продемонстрировать обработку события типа KeyEvent.
class KeyEventDemo
{
    static void Main()
    {
        KeyEvent kevt = new();

        ConsoleKeyInfo key;
        int count = 0;

        // Использовать лямбда-выражение для отображения факта нажатия клавиши.
        kevt.KeyPress += (sender, e) => Console.WriteLine(" Получено сообщение о нажатии клавиши: " + e.ch);

        // Использовать лямбда-выражение для подсчета нажатых клавиш.
        kevt.KeyPress += (sender, e) => count++; // count - это внешняя переменная

        Console.WriteLine("Введите несколько символов. По завершении нажмите точку.");

        do
        {
            key = Console.ReadKey();
            kevt.OnKeyPress(key.KeyChar);
        }
        while (key.KeyChar != '.');

        Console.WriteLine("Было нажато " + count + " клавиш.");

        Console.ReadKey();
    }
}

/*

Вот, например, к какому результату приводит выполнение этой программы.

Введите несколько символов. По завершении введите точку.
t Получено сообщение о нажатии клавиши: t
е Получено сообщение о нажатии клавиши: е
s Получено сообщение о нажатии клавиши: s
t Получено сообщение о нажатии клавиши: t
. Получено сообщение о нажатии клавиши: .
Было нажато 5 клавиш.

В самом начале этой программы объявляется класс KeyEventArgs, производный
от класса EventArgs и служащий для передачи сообщения о нажатии клавиши обработчику
событий. Затем объявляется обобщенный делегат EventHandler, определяющий
обработчик событий, связанных с нажатием клавиш. Эти события инкапсулируются
в классе KeyEvent, где определяется событие KeyPress.

В методе Main() сначала создается объект kevt класса KeyEvent. Затем в цепочку
событий kevt.KeyPress добавляется обработчик, предоставляемый лямбда-
выражением. В этом обработчике отображается факт каждого нажатия клавиши, как
показано ниже.

kevt.KeyPress += (sender, е) => Console.WriteLine(" Получено сообщение о нажатии клавиши: " + e.ch);

Далее в цепочку событий kevt.KeyPress добавляется еще один обработчик, предоставляемый
лямбда-выражением. В этом обработчике подсчитывается количество
нажатых клавиш, как показано ниже.

kevt.KeyPress += (sender, е) => count++; // count — это внешняя переменная

Обратите внимание на то, что count является локальной переменной, объявленной
в методе Main() и инициализированной нулевым значением.

Далее начинает выполняться цикл, в котором метод kevt.OnKeyPress() вызывается
при нажатии клавиши. Об этом событии уведомляются все зарегистрированные
обработчики событий. По окончании цикла отображается количество нажатых клавиш.
Несмотря на всю свою простоту, данный пример наглядно демонстрирует саму
суть обработки событий средствами С#. Аналогичный подход может быть использован
и для обработки других событий. Безусловно, в некоторых случаях анонимные обработчики
событий могут оказаться непригодными, и тогда придется внедрить именованные
методы.

*/

#endregion

#region English

/*

Applying Events: A Case Study

Events are frequently used in message-based environments such as Windows. In such an
environment, a program simply waits until it receives a message, and then it takes the
appropriate action. Such an architecture is well suited for C#-style event handling because it
is possible to create event handlers for various messages and then simply invoke a handler
when a message is received. For example, the left-button mouse click message could be tied
to an event called LButtonClick. When a left-button click is received, a method called
OnLButtonClick() can be called, and all registered handlers will be notified.

Although developing a Windows program that demonstrates this approach is beyond
the scope of this chapter, it is possible to give an idea of how such an approach would work.
The following program creates an event handler that processes keystrokes. The event is
called KeyPress, and each time a key is pressed, the event is raised by calling OnKeyPress().
Notice that .NET-compatible events are created and that lambda expressions provide the
event handlers.

*/

// A keypress event example.  

//using System;  

//// Derive a custom EventArgs class that holds the key.  
//class KeyEventArgs : EventArgs
//{
//    public char ch;
//}

//// Declare a keypress event class.  
//class KeyEvent
//{
//    public event EventHandler<KeyEventArgs> KeyPress;

//    // This is called when a key is pressed.  
//    public void OnKeyPress(char key)
//    {
//        KeyEventArgs k = new KeyEventArgs();

//        if (KeyPress != null)
//        {
//            k.ch = key;
//            KeyPress(this, k);
//        }
//    }
//}

//// Demonstrate KeyEvent.  
//class KeyEventDemo
//{
//    static void Main()
//    {
//        KeyEvent kevt = new KeyEvent();
//        ConsoleKeyInfo key;
//        int count = 0;

//        // Use a lambda expression to display the keypress.  
//        kevt.KeyPress += (sender, e) =>
//          Console.WriteLine(" Received keystroke: " + e.ch);

//        // Use a lambda expression to count keypresses. 
//        kevt.KeyPress += (sender, e) =>
//          count++; // count is an outer variable 

//        Console.WriteLine("Enter some characters. " +
//                          "Enter a period to stop.");
//        do
//        {
//            key = Console.ReadKey();
//            kevt.OnKeyPress(key.KeyChar);
//        } while (key.KeyChar != '.');

//        Console.WriteLine(count + " keys pressed.");

//        Console.ReadKey();
//    }
//}

/*

Here is a sample run:

Enter some characters. Enter a period to stop.
t Received keystroke: t
e Received keystroke: e
s Received keystroke: s
t Received keystroke: t
. Received keystroke: .
5 keys pressed.

The program begins by deriving a class from EventArgs called KeyEventArgs, which is
used to pass a keystroke to an event handler. Next, a delegate called KeyHandler defines
the event handler for keystroke events. The class KeyEvent encapsulates the keypress event.
It defines the event KeyPress.

In Main( ), a KeyEvent object called kevt is created. Next, an event handler based on
a lambda expression is added to kvet.KeyPress that displays each key as it is entered, as
shown here:

kevt.KeyPress += (sender, e) => Console.WriteLine(" Received keystroke: " + e.ch);

Next, another lambda expression–based handler is added to kvet.KeyPress by the
following code. It counts the number of keypresses.

kevt.KeyPress += (sender, e) => count++; // count is an outer variable

Notice that count is a local variable declared in Main( ) that is initialized to zero.

Next, a loop is started that calls kevt.OnKeyPress( ) when a key is pressed. This causes
the registered event handlers to be notified. When the loop ends, the number of keypresses
is displayed. Although quite simple, this example illustrates the essence of event handling.
The same basic approach will be used for other event handling situations. Of course, in
some cases, anonymous event handlers will not be appropriate and named methods will
need to be employed.

*/

#endregion