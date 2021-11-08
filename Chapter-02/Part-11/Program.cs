#region Russian

/*

Другие типы данных

В предыдущем примере программы использовались переменные типа int. Но
в переменных типа int могут храниться только целые числа. Их нельзя использовать
в операциях с числами, имеющими дробную часть. Например, переменная типа int
может содержать значение 18, но не значение 18,3. Правда, int — далеко не единственный
тип данных, определяемых в С#. Для операций с числами, имеющими дробную
часть, в C# предусмотрены два типа данных с плавающей точкой: float и double. Они
обозначают числовые значения с одинарной и двойной точностью соответственно.
Из этих двух типов чаще всего используется тип double.

Для объявления переменной типа double служит оператор

double result;

где result — это имя переменной типа double. А поскольку переменная result
имеет тип данных с плавающей точкой, то в ней могут храниться такие числовые значения,
как, например, 122,23, 0,034 или -19,0.

Для лучшего понимания отличий между типами данных int и double рассмотрим
такой пример программы.

 */

// Эта программа демонстрирует отличия между типами данных int и double.

using System;

class Example3
{
    static void Main()
    {
        int ivar; // объявить целочисленную переменную
        double dvar; // объявить переменную с плавающей точкой

        ivar = 100; // присвоить переменной ivar значение 100
        dvar = 100.0; // присвоить переменной dvar значение 100.0

        Console.WriteLine("Исходное значение ivar: " + ivar);
        Console.WriteLine("Исходное значение dvar: " + dvar);

        Console.WriteLine(); // вывести пустую строку

        // Разделить значение обоих переменных на 3.
        ivar = ivar / 3;
        dvar = dvar / 3;

        Console.WriteLine("Значение ivar после деления: " + ivar);
        Console.WriteLine("Значение dvar после деления: " + dvar);
    }
}

/*

Ниже приведен результат выполнения приведенной выше программы.

Исходное значение ivar: 100
Исходное значение dvar: 100

Значение ivar после деления: 33
Значение dvar после деления: 33.3333333333333

Как видите, при делении значения переменной ivar типа int на 3 остается лишь
целая часть результата — 33, а дробная его часть теряется. В то же время при делении
значения переменной dvar типа double на 3 дробная часть результата сохраняется.

Как демонстрирует данный пример программы, в числовых значениях с плавающей
точкой следует использовать обозначение самой десятичной точки. Например,
значение 100 в С# считается целым, а значение 100,0 — с плавающей точкой.

В данной программе обнаруживается еще одна особенность. Для вывода пустой
строки достаточно вызвать метод WriteLine() без аргументов.

*/

#endregion

#region English

/*

Another Data Type

In the preceding program, a variable of type int was used. However, an int variable can
hold only whole numbers. It cannot be used when a fractional component is required. For
example, an int variable can hold the value 18, but not the value 18.3. Fortunately, int is
only one of several data types defined by C#. To allow numbers with fractional components,
C# defines two floating-point types: float and double, which represent single- and doubleprecision
values, respectively. Of the two, double is the most commonly used.

To declare a variable of type double, use a statement similar to that shown here:

double result;

Here, result is the name of the variable, which is of type double. Because result has a
floating-point type, it can hold values such as 122.23, 0.034, or –19.0.

To better understand the difference between int and double, try the following program:

*/

/*
This program illustrates the differences
between int and double.
*/

//using System;

//class Example3
//{
//    static void Main()
//    {
//        int ivar; // this declares an int variable
//        double dvar; // this declares a floating-point variable

//        ivar = 100; // assign ivar the value 100
//        dvar = 100.0; // assign dvar the value 100.0

//        Console.WriteLine("Original value of ivar: " + ivar);
//        Console.WriteLine("Original value of dvar: " + dvar);

//        Console.WriteLine(); // print a blank line

//        // Now, divide both by 3.
//        ivar = ivar / 3;
//        dvar = dvar / 3.0;

//        Console.WriteLine("ivar after division: " + ivar);
//        Console.WriteLine("dvar after division: " + dvar);
//    }
//}

/*

The output from this program is shown here:

Original value of ivar: 100
Original value of dvar: 100

ivar after division: 33
dvar after division: 33.3333333333333

As you can see, when ivar (an int variable) is divided by 3, a whole-number division is
performed, and the outcome is 33—the fractional component is lost. However, when dvar
(a double variable) is divided by 3, the fractional component is preserved.

As the program shows, when you want to specify a floating-point value in a program,
you must include a decimal point. If you don’t, it will be interpreted as an integer. For
example, in C#, the value 100 is an integer, but the value 100.0 is a floating-point value.

There is one other new thing to notice in the program. To print a blank line, simply
call WriteLine() without any arguments.

*/

#endregion