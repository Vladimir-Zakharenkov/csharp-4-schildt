#region Russian

/*

Целочисленные типы

В C# определены девять целочисленных типов: char, byte, sbyte, short, ushort,
int, uint, long и ulong. Но тип char применяется, главным образом, для представления
символов и поэтому рассматривается далее в этой главе. Остальные восемь
целочисленных типов предназначены для числовых расчетов. Ниже представлены их
диапазон представления чисел и разрядность в битах.

Тип     Разрядность в битах     Диапазон представления чисел
byte    8                       0-255
sbyte   8                       -128-127
short   16                      -32 768-32 767
ushort  16                      0-65 535
int     32                      -2 147 483 648-2 147 483 647
uint    32                      0-4 294 967 295
long    64                      -9 223 372 036 854 775 808-9 223 372 036 854 775 807
ulong   64                      0-18 446 744 073 709 551 615

Как следует из приведенной выше таблицы, в C# определены оба варианта различных
целочисленных типов: со знаком и без знака. Целочисленные типы со знаком отличаются
от аналогичных типов без знака способом интерпретации старшего разряда
целого числа. Так, если в программе указано целочисленное значение со знаком, то
компилятор C# сгенерирует код, в котором старший разряд целого числа используется
в качестве флага знака. Число считается положительным, если флаг знака равен 0,
и отрицательным, если он равен 1. Отрицательные числа практически всегда представляются
методом дополнения до двух, в соответствии с которым все двоичные разряды
отрицательного числа сначала инвертируются, а затем к этому числу добавляется 1.

Целочисленные типы со знаком имеют большое значение для очень многих алгоритмов,
но по абсолютной величине они наполовину меньше своих аналогов без знака.
Вот как, например, выглядит число 32 767 типа short в двоичном представлении.

0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1

Если установить старший разряд этого числа равным 1, чтобы получить значение
со знаком, то оно будет интерпретировано как -1, принимая во внимание формат дополнения
до двух. Но если объявить его как значение типа ushort, то после установки
в 1 старшего разряда оно станет равным 65 535.

Вероятно, самым распространенным в программировании целочисленным типом
является тип int. Переменные типа int нередко используются для управления циклами,
индексирования массивов и математических расчетов общего назначения. Когда
же требуется целочисленное значение с большим диапазоном представления чисел,
чем у типа int, то для этой цели имеется целый ряд других целочисленных типов. Так,
если значение нужно сохранить без знака, то для него можно выбрать тип uint, для
больших значений со знаком — тип long, а для больших значений без знака — тип
ulong. В качестве примера ниже приведена программа, вычисляющая расстояние от
Земли до Солнца в дюймах. Для хранения столь большого значения в ней используется
переменная типа long.

*/

// Вычислить расстояние от Земли до Солнца в дюймах.

using System;

class Inches
{
    static void Main()
    {
        long inches;
        long miles;

        miles = 93000000; // 93 000 000 миль до Солнца

        // 5 280 футов в миле, 12 дюймов в футе
        inches = miles * 5280 * 12;

        Console.WriteLine("Расстояние до Солнца: " + inches + " дюймов.");
    }
}

/*

Вот как выглядит результат выполнения этой программы.

Расстояние до Солнца: 5892480000000 дюймов.

Очевидно, что этот результат нельзя было бы сохранить в переменной типа int или uint.

*/

#endregion

#region English

/*

Integers

C# defines nine integer types: char, byte, sbyte, short, ushort, int, uint, long, and ulong.
However, the char type is primarily used for representing characters, and it is discussed
later in this chapter. The remaining eight integer types are used for numeric calculations.
Their bit-width and ranges are shown here:

Type        Width in Bits       Range
byte        8                   0 to 255
sbyte       8                   –128 to 127
short       16                  –32,768 to 32,767
ushort      16                  0 to 65,535
int         32                  –2,147,483,648 to 2,147,483,647
uint        32                  0 to 4,294,967,295
long        64                  –9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
ulong       64                  0 to 18,446,744,073,709,551,615

As the table shows, C# defines both signed and unsigned versions of the various integer
types. The difference between signed and unsigned integers is in the way the high-order
bit of the integer is interpreted. If a signed integer is specified, then the C# compiler will
generate code that assumes the high-order bit of an integer is to be used as a sign flag. If the
sign flag is 0, then the number is positive; if it is 1, then the number is negative. Negative
numbers are almost always represented using the two’s complement approach. In this
method, all bits in the negative number are reversed, and then 1 is added to this number.

Signed integers are important for a great many algorithms, but they have only half the
absolute magnitude of their unsigned relatives. For example, as a short, here is 32,767:

0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1

For a signed value, if the high-order bit were set to 1, the number would then be interpreted
as –1 (assuming the two’s complement format). However, if you declared this to be a
ushort, then when the high-order bit was set to 1, the number would become 65,535.

Probably the most commonly used integer type is int. Variables of type int are often
employed to control loops, to index arrays, and for general-purpose integer math. When you
need an integer that has a range greater than int, you have many options. If the value you want
to store is unsigned, you can use uint. For large signed values, use long. For large unsigned
values, use ulong. For example, here is a program that computes the distance from the Earth to
the sun, in inches. Because this value is so large, the program uses a long variable to hold it.

*/

// Compute the distance from the Earth to the sun, in inches.

//using System;
//class Inches
//{
//    static void Main()
//    {
//        long inches;
//        long miles;

//        miles = 93000000; // 93,000,000 miles to the sun

//        // 5,280 feet in a mile, 12 inches in a foot.
//        inches = miles * 5280 * 12;

//        Console.WriteLine("Distance to the sun: " + inches + " inches.");
//    }
//}

/*

Here is the output from the program:

Distance to the sun: 5892480000000 inches.

Clearly, the result could not have been held in an int or uint variable.

*/

#endregion