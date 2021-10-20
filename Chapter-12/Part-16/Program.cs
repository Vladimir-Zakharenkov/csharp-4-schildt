#region Russian

/*

Инициализация перечисления

Значение одной или нескольких символически обозначаемых констант в перечислении
можно задать с помощью инициализатора. Для этого достаточно указать после
символического обозначения отдельной константы знак равенства и целое значение.
Каждой последующей константе присваивается значение, которое на единицу больше
значения предыдущей инициализированной константы. Например, в приведенном
ниже фрагменте кода константе RedDel присваивается значение 10.

enum Apple { Jonathan, GoldenDel, RedDel = 10, Winesap, Cortland, McIntosh };

В итоге все константы в перечислении принимают приведенные ниже значения.

Jonathan 0
GoldenDel 1
RedDel 10
Winesap 11
Cortland 12
McIntosh 13

Указание базового типа перечисления

По умолчанию в качестве базового для перечислений выбирается тип int, тем не
менее перечисление может быть создано любого целочисленного типа, за исключением
char. Для того чтобы указать другой тип, кроме int, достаточно поместить этот
тип после имени перечисления, отделив его двоеточием. В качестве примера ниже задается
тип byte для перечисления Apple.

enum Apple : byte { Jonathan, GoldenDel, RedDel, Winesap, Cortland, McIntosh };

Теперь константа Apple.Winesap, например, имеет количественное значение типа byte.

Применение перечислений

На первый взгляд перечисления могут показаться любопытным, но не очень нужным
элементом С#, но на самом деле это не так. Перечисления очень полезны, когда
в программе требуется одна или несколько специальных символически обозначаемых
констант. Допустим, что требуется написать программу для управления лентой конвейера
на фабрике. Для этой цели можно создать метод Conveyor(), принимающий в
качестве параметров следующие команды: "старт", "стоп", "вперед" и "назад". Вместо
того чтобы передавать методу Conveyor() целые значения, например, 1 — в качестве
команды "старт", 2 — в качестве команды "стоп" и так далее, что чревато ошибками,
можно создать перечисление, чтобы присвоить этим значениям содержательные символические
обозначения. Ниже приведен пример применения такого подхода.

*/

// Сымитировать управление лентой конвейера.

using System;

class ConveyorControl
{
    // Перечислить команды конвейера.
    public enum Action { Start, Stop, Forward, Reverse };

    public void Conveyor(Action com)
    {
        switch (com)
        {
            case Action.Start:
                Console.WriteLine("Запустить конвейер.");
                break;
            case Action.Stop:
                Console.WriteLine("Остановить конвейер.");
                break;
            case Action.Forward:
                Console.WriteLine("Переместить конвейер вперед.");
                break;
            case Action.Reverse:
                Console.WriteLine("Переместить конвейер назад.");
                break;
        }
    }
}

class ConveyorDemo
{
    static void Main()
    {
        ConveyorControl c = new();

        c.Conveyor(ConveyorControl.Action.Start);
        c.Conveyor(ConveyorControl.Action.Forward);
        c.Conveyor(ConveyorControl.Action.Reverse);
        c.Conveyor(ConveyorControl.Action.Stop);
    }
}

/*

Вот к какому результату приводит выполнение этого кода.

Запустить конвейер.
Переместить конвейер вперед.
Переместить конвейер назад.
Остановить конвейер.

Метод Conveyor() принимает аргумент типа Action, и поэтому ему могут быть
переданы только значения, определяемые в перечислении Action. Например, ниже
приведена попытка передать методу Conveyor() значение 22.

с.Conveyor(22); // Ошибка!

Эта строка кода не будет скомпилирована, поскольку отсутствует предварительно
заданное преобразование типа int в перечислимый тип Action. Именно это и
препятствует передаче неправильных команд методу Conveyor(). Конечно, такое
преобразование можно организовать принудительно с помощью приведения типов,
но это было бы преднамеренным, а не случайным или неумышленным действием.
Кроме того, вероятность неумышленной передачи пользователем неправильных команд
методу Conveyor() сводится с минимуму благодаря тому, что эти команды обозначены
символическими именами в перечислении.

В приведенном выше примере обращает на себя внимание еще одно интересное
обстоятельство: перечислимый тип используется для управления оператором switch.
Как упоминалось выше, перечисления относятся к целочисленным типам данных,
и поэтому их вполне допустимо использовать в операторе switch.

*/

#endregion

#region English

/*

Initialize an Enumeration

You can specify the value of one or more of the symbols by using an initializer. Do this by
following the symbol with an equal sign and an integer constant expression. Symbols that
appear after initializers are assigned values greater than the previous initialization value.
For example, the following code assigns the value of 10 to RedDel:

enum Apple { Jonathan, GoldenDel, RedDel = 10, Winesap, Cortland, McIntosh };

Now the values of these symbols are

Jonathan 0
GoldenDel 1
RedDel 10
Winesap 11
Cortland 12
McIntosh 13

Specify the Underlying Type of an Enumeration

By default, enumerations are based on type int, but you can create an enumeration of any
integral type, except for type char. To specify a type other than int, put the desired type
after the enumeration name, separated by a colon. For example, this statement makes
Apple an enumeration based on byte:

enum Apple : byte { Jonathan, GoldenDel, RedDel, Winesap, Cortland, McIntosh };

Now Apple.Winesap, for example, is a byte quantity.

Use Enumerations

At first glance you might think that enumerations are an interesting but relatively
unimportant part of C#, yet this is not the case. Enumerations are very useful when your
program requires one or more specialized symbols. For example, imagine that you are
writing a program that controls a conveyor belt in a factory. You might create a method
called Conveyor( ) that accepts the following commands as parameters: start, stop, forward,
and reverse. Instead of passing Conveyor( ) integers, such as 1 for start, 2 for stop, and so
on, which is error-prone, you can create an enumeration that assigns words to these values.
Here is an example of this approach:

*/

// Simulate a conveyor belt.

//using System;

//class ConveyorControl
//{
//    // Enumerate the conveyor commands.
//    public enum Action { Start, Stop, Forward, Reverse };
//    public void Conveyor(Action com)
//    {
//        switch (com)
//        {
//            case Action.Start:
//                Console.WriteLine("Starting conveyor.");
//                break;
//            case Action.Stop:
//                Console.WriteLine("Stopping conveyor.");
//                break;

//            case Action.Forward:
//                Console.WriteLine("Moving forward.");
//                break;
//            case Action.Reverse:
//                Console.WriteLine("Moving backward.");
//                break;
//        }
//    }
//}
//class ConveyorDemo
//{
//    static void Main()
//    {
//        ConveyorControl c = new ConveyorControl();
//        c.Conveyor(ConveyorControl.Action.Start);
//        c.Conveyor(ConveyorControl.Action.Forward);
//        c.Conveyor(ConveyorControl.Action.Reverse);
//        c.Conveyor(ConveyorControl.Action.Stop);
//    }
//}

/*

The output from the program is shown here:

Starting conveyor.
Moving forward.
Moving backward.
Stopping conveyor.

Because Conveyor( ) takes an argument of type Action, only the values defined by Action
can be passed to the method. For example, here an attempt is made to pass the value 22 to
Conveyor( ):

c.Conveyor(22); // Error!

This won’t compile because there is no predefined conversion from int to Action. This prevents
the passing of invalid commands to Conveyor( ). Of course, you could use a cast to force
a conversion, but this would require a premeditated act, not an accidental misuse. Also,
because commands are specified by name rather than by number, it is less likely that a
user of Conveyor( ) will inadvertently pass the wrong value.

There is one other interesting thing in this example: Notice that an enumeration type
is used to control the switch statement. Because enumerations are integral types, they are
perfectly valid for use in a switch.

*/

#endregion