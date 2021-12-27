#region Russian

/*

Десятичный тип данных

Вероятно, самым интересным среди всех числовых типов данных в C# является тип
decimal, который предназначен для применения в финансовых расчетах. Этот тип
имеет разрядность 128 бит для представления числовых значений в пределах от 1Е-28
до 7,9Е+28. Вам, вероятно, известно, что для обычных арифметических вычислений
с плавающей точкой характерны ошибки округления десятичных значений. Эти ошибки
исключаются при использовании типа decimal, который позволяет представить
числа с точностью до 28 (а иногда и 29) десятичных разрядов. Благодаря тому что этот
тип данных способен представлять десятичные значения без ошибок округления, он
особенно удобен для расчетов, связанных с финансами.

Ниже приведен пример программы, в которой тип decimal используется в конкретном
финансовом расчете. В этой программе цена со скидкой рассчитывается на
основании исходной цены и скидки в процентах.

*/

// Использовать тип decimal для расчета скидки.

using System;

class UseDecimal
{
    static void Main()
    {
        decimal price;
        decimal discount;
        decimal discounted_price;

        // Рассчитать цену со скидкой.
        price = 19.95m;
        discount = 0.15m; // норма скидки составляет 15%

        discounted_price = price - (price * discount);

        Console.WriteLine("Цена со скидкой: $" + discounted_price);
    }
}

/*

Результат выполнения этой программы выглядит следующим образом.

Цена со скидкой: $16.9575

Обратите внимание на то, что значения констант типа decimal в приведенном
выше примере программы указываются с суффиксом m. Дело в том, что без суффикса
m эти значения интерпретировались бы как стандартные константы с плавающей точкой,
которые несовместимы с типом данных decimal. Тем не менее переменной типа
decimal можно присвоить целое значение без суффикса m, например 10. (Подробнее
о числовых константах речь пойдет далее в этой главе.)

*/

#endregion

#region English

/*

The decimal Type

Perhaps the most interesting C# numeric type is decimal, which is intended for use in
monetary calculations. The decimal type utilizes 128 bits to represent values within the
range 1E–28 to 7.9E+28. As you may know, normal floating-point arithmetic is subject to a
variety of rounding errors when it is applied to decimal values. The decimal type eliminates
these errors and can accurately represent up to 28 decimal places (or 29 places in some
cases). This ability to represent decimal values without rounding errors makes it especially
useful for computations that involve money.

Here is a program that uses a decimal type in a financial calculation. The program
computes the discounted price given the original price and a discount percentage.

*/

// Use the decimal type to compute a discount.

//using System;
//class UseDecimal
//{
//    static void Main()
//    {
//        decimal price;
//        decimal discount;
//        decimal discounted_price;

//        // Compute discounted price.
//        price = 19.95m;
//        discount = 0.15m; // discount rate is 15%

//        discounted_price = price - (price * discount);

//        Console.WriteLine("Discounted price: $" + discounted_price);
//    }
//}

/*

The output from this program is shown here:

Discounted price: $16.9575

In the program, notice that the decimal constants are followed by the m suffix. This
is necessary because without the suffix, these values would be interpreted as standard
floating-point constants, which are not compatible with the decimal data type. You can
assign an integer value, such as 10, to a decimal variable without the use of the m suffix,
though. (A detailed discussion of numeric constants is found later in this chapter.)

*/

#endregion