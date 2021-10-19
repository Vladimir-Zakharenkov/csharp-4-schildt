#region Russian

/*

Перечисления

Перечисление представляет собой множество именованных целочисленных констант.
Перечислимый тип данных объявляется с помощью ключевого слова enum. Ниже приведена
общая форма объявления перечисления:

enum имя {список_перечисления};

где имя — это имя типа перечисления, а список_перечисления — список идентификаторов,
разделяемый запятыми.

В приведенном ниже примере объявляется перечисление Apple различных сортов
яблок.

enum Apple { Jonathan, GoldenDel, RedDel, Winesap, Cortland, McIntosh };

Следует особо подчеркнуть, что каждая символически обозначаемая константа
в перечислении имеет целое значение. Тем не менее неявные преобразования перечислимого
типа во встроенные целочисленные типы и обратно в C# не определены,
а значит, в подобных случаях требуется явное приведение типов. Кроме того, приведение
типов требуется при преобразовании двух перечислимых типов. Но поскольку
перечисления обозначают целые значения, то их можно, например, использовать для
управления оператором выбора switch или же оператором цикла for.

Для каждой последующей символически обозначаемой константы в перечислении
задается целое значение, которое на единицу больше, чем у предыдущей константы.
По умолчанию значение первой символически обозначаемой константы в перечислении
равно нулю. Следовательно, в приведенном выше примере перечисления Apple
константа Jonathan равна нулю, константа GoldenDel — 1, константа RedDel — 2
и т.д.

Доступ к членам перечисления осуществляется по имени их типа, после которого
следует оператор-точка. Например, при выполнении фрагмента кода

Console.WriteLine(Apple.RedDel + " имеет значение " +
(int)Apple.RedDel);

выводится следующий результат.

RedDel имеет значение 2

Как показывает результат выполнения приведенного выше фрагмента кода, для вывода
перечислимого значения используется его имя. Но для получения этого значения
требуется предварительно привести его к типу int.
Ниже приведен пример программы, демонстрирующий применение перечисления
Apple.

*/

// Продемонстрировать применение перечисления.

//using System;

//class EnumDemo
//{
//    enum Apple
//    {
//        Jonathan, GoldenDel, RedDel, Winesap, Cortland, McIntosh
//    };

//    static void Main()
//    {
//        string[] color =
//        {
//            "красный",
//            "желтый",
//            "красный",
//            "красный",
//            "красный",
//            "красновато-зеленый"
//        };

//        Apple i; // Объявить переменную перечислимого типа

//        // Использовать переменную i для циклического обращения к членам перечисления.
//        for (i = Apple.Jonathan; i <= Apple.McIntosh; i++)
//        {
//            Console.WriteLine(i + " имеет значение " + (int)i);
//        }

//        Console.WriteLine();

//        // Использовать перечисление для индексирования массива.
//        for (i = Apple.Jonathan; i <= Apple.McIntosh; i++)
//        {
//            Console.WriteLine("Цвет сорта " + i + " - " + color[(int)i]);
//        }
//    }
//}

/*

Ниже приведен результат выполнения этой программы.

Jonathan имеет значение 0
GoldenDel имеет значение 1
RedDel имеет значение 2
Winsap имеет значение 3
Cortland имеет значение 4
McIntosh имеет значение 5

Цвет сорта Jonathan - красный
Цвет сорта GoldenDel - желтый
Цвет сорта RedDel - красный
Цвет сорта Winsap - красный
Цвет сорта Cortland - красный
Цвет сорта McIntosh - красновато-зеленый

Обратите внимание на то, как переменная типа Apple управляет циклами for.
Значения символически обозначаемых констант в перечислении Apple начинаются с
нуля, поэтому их можно использовать для индексирования массива, чтобы получить
цвет каждого сорта яблок. Обратите также внимание на необходимость производить
приведение типов, когда перечислимое значение используется для индексирования
массива. Как упоминалось выше, в C# не предусмотрены неявные преобразования
перечислимых типов в целочисленные и обратно, поэтому для этой цели требуется
явное приведение типов.

И еще одно замечание: все перечисления неявно наследуют от класса System.Enum,
который наследует от класса System.ValueType, а тот, в свою очередь, — от класса
object.

*/

#endregion

#region English

/*

Enumerations

An enumeration is a set of named integer constants. The keyword enum declares an
enumerated type. The general form for an enumeration is

enum name { enumeration list };

Here, the type name of the enumeration is specified by name. The enumeration list is a
comma-separated list of identifiers.

Here is an example. It defines an enumeration called Apple that enumerates various
types of apples:

enum Apple { Jonathan, GoldenDel, RedDel, Winesap, Cortland, McIntosh };

A key point to understand about an enumeration is that each of the symbols stands for
an integer value. However, no implicit conversions are defined between an enum type and
the built-in integer types, so an explicit cast must be used. Also, a cast is required when
converting between two enumeration types. Since enumerations represent integer values,
you can use an enumeration to control a switch statement or as the control variable in a for
loop, for example.

Each enumeration symbol is given a value one greater than the symbol that precedes it.
By default, the value of the first enumeration symbol is 0. Therefore, in the Apple enumeration,
Jonathan is 0, GoldenDel is 1, RedDel is 2, and so on.
The members of an enumeration are accessed through their type name via the dot
operator. For example

Console.WriteLine(Apple.RedDel + " has the value " + (int)Apple.RedDel);

displays

RedDel has the value 2

As the output shows, when an enumerated value is displayed, its name is used. To obtain
its integer value, a cast to int must be employed.

Here is a program that illustrates the Apple enumeration:
*/

// Demonstrate an enumeration.
using System;
class EnumDemo
{
    enum Apple
    {
        Jonathan, GoldenDel, RedDel, Winesap,
        Cortland, McIntosh
    };
    static void Main()
    {
        string[] color = {
"Red",
"Yellow",
"Red",
"Red",
"Red",
"Reddish Green"
};

        Apple i; // declare an enum variable

                 // Use i to cycle through the enum.
        for (i = Apple.Jonathan; i <= Apple.McIntosh; i++)
            Console.WriteLine(i + " has value of " + (int)i);

        Console.WriteLine();

        // Use an enumeration to index an array.
        for (i = Apple.Jonathan; i <= Apple.McIntosh; i++)
            Console.WriteLine("Color of " + i + " is " +
            color[(int)i]);
    }
}

/*

The output from the program is shown here:

Jonathan has value of 0
GoldenDel has value of 1
RedDel has value of 2
Winesap has value of 3
Cortland has value of 4
McIntosh has value of 5

Color of Jonathan is Red
Color of GoldenDel is Yellow
Color of RedDel is Red
Color of Winesap is Red
Color of Cortland is Red
Color of McIntosh is Reddish Green

Notice how the for loops are controlled by a variable of type Apple. Because the
enumerated values in Apple start at zero, these values can be used to index color to obtain
the color of the apple. Notice that a cast is required when the enumeration value is used to
index the color array. As mentioned, there are no implicit conversions defined between
integers and enumeration types. An explicit cast is required.

One other point: all enumerations implicitly inherit System.Enum, which inherits
System.ValueType, which inherits object.

*/

#endregion