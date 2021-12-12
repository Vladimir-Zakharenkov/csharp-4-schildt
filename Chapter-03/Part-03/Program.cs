#region Russian

/*

Самыми мелкими целочисленными типами являются byte и sbyte. Тип byte
представляет целые значения без знака в пределах от 0 до 255. Переменные типа byte
особенно удобны для обработки исходных двоичных данных, например байтового потока,
поступающего от некоторого устройства. А для представления мелких целых значений
со знаком служит тип sbyte. Ниже приведен пример программы, в которой
переменная типа byte используется для управления циклом, где суммируются числа
от 1 до 100.

*/

// Использовать тип byte.

using System;

class Use_Byte
{
    static void Main()
    {
        byte x;
        int sum;

        sum = 0;

        for (x = 1; x <= 100; x++)
        {
            sum = sum + x;
        }

        Console.WriteLine("Сумма чисел от 1 до 100 равна " + sum);
    }
}

/*

Результат выполнения этой программы выглядит следующим образом.

Сумма чисел от 1 до 100 равна 5050

В приведенном выше примере программы цикл выполняется только от 1 до 100,
что не превышает диапазон представления чисел для типа byte, и поэтому для управления
этим циклом не требуется переменная более крупного типа.

Если же требуется целое значение, большее, чем значение типа byte или sbyte,
но меньшее, чем значение типа int или uint, то для него можно выбрать тип short
или ushort.

*/

#endregion

#region English

/*

The smallest integer types are byte and sbyte. The byte type is an unsigned value
between 0 and 255. Variables of type byte are especially useful when working with raw
binary data, such as a byte stream produced by some device. For small signed integers,
use sbyte. Here is an example that uses a variable of type byte to control a for loop that
produces the summation of the number 100.

*/

// Use byte.

//using System;
//class Use_byte
//{
//    static void Main()
//    {
//        byte x;
//        int sum;
//        sum = 0;

//        for (x = 1; x <= 100; x++)
//            sum = sum + x;

//        Console.WriteLine("Summation of 100 is " + sum);
//    }
//}

/*

The output from the program is shown here:

Summation of 100 is 5050

Since the for loop runs only from 0 to 100, which is well within the range of a byte, there is
no need to use a larger type variable to control it.

When you need an integer that is larger than a byte or sbyte, but smaller than an int or
uint, use short or ushort.

*/
#endregion