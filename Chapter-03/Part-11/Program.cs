#region Russian

/*

В приведенных выше примерах сами выводимые значения не форматировались.
Но ведь основное назначение спецификаторов формата — управлять внешним видом
выводимых данных. Чаще всего форматированию подлежат следующие типы данных:
с плавающей точкой и десятичный. Самый простой способ указать формат данных —
описать шаблон, который будет использоваться в методе WriteLine(). Для этого указывается
образец требуемого формата с помощью символов #, обозначающих разряды
чисел. Кроме того, можно указать десятичную точку и запятые, разделяющие цифры.
Ниже приведен пример более подходящего вывода результата деления 10 на 3.

Console.WriteLine("Деление 10/3 дает: (0:#.##)", 10.0/3.0);

Выполнение этого оператора приводит к следующему результату.

Деление 10/3 дает: 3.33

В данном примере шаблон #.## указывает методу WriteLine() отобразить два
десятичных разряда в дробной части числа. Следует, однако, иметь в виду, что метод
WriteLine() может отобразить столько цифр слева от десятичной точки, сколько потребуется
для правильной интерпретации выводимого значения.

Рассмотрим еще один пример. Оператор

Console.WriteLine("{0:###,###.##}", 123456.56);

дает следующий результат.

123,456.56

Для вывода денежных сумм, например, рекомендуется использовать спецификатор
формата С.

decimal balance;
balance = 12323.09m;
Console.WriteLine("Текущий баланс равен {0:С}" , balance);

Результат выполнения этого фрагмента кода выводится в формате денежных сумм,
указываемых в долларах США.

Текущий баланс равен $12,323.09

Форматом С можно также воспользоваться, чтобы представить в более подходящем
виде результат выполнения рассматривавшейся ранее программы расчета цены со скидкой.

*/

using System;

class UseDecimal
{
    static void Main()
    {
        decimal price;
        decimal discount;
        decimal discounted_price;

        // рассчитать цену со скидкой

        price = 19.95m;
        discount = 0.15m; // норма скидки составляет 15%

        discounted_price = price - (price * discount);

        Console.WriteLine("Цена со скидкой: {0:C}", discounted_price);

    }
}

/*

Вот как теперь выглядит результат выполнения этой программы.
Цена со скидкой: $16,96

*/

#endregion

#region English

/*

In the preceding examples, no formatting was applied to the values themselves. Of
course, the purpose of using format specifiers is to control the way the data looks. The types
of data most commonly formatted are floating-point and decimal values. One of the easiest
ways to specify a format is to describe a template that WriteLine( ) will use. To do this,
show an example of the format that you want, using #s to mark the digit positions. You can
also specify the decimal point and commas. For example, here is a better way to display 10
divided by 3:

Console.WriteLine("Here is 10/3: {0:#.##}", 10.0/3.0);

The output from this statement is shown here:

Here is 10/3: 3.33

In this example, the template is #.##, which tells WriteLine( ) to display two decimal places.
It is important to understand, however, that WriteLine( ) will display more than one digit
to the left of the decimal point, if necessary, so as not to misrepresent the value.

Here is another example. This statement

Console.WriteLine("{0:###,###.##}", 123456.56);

generates this output:

123,456.56

If you want to display monetary values, use the C format specifier. For example:

decimal balance;

balance = 12323.09m;
Console.WriteLine("Current balance is {0:C}", balance);

The output from this sequence is shown here (in U.S. dollar format):

Current balance is $12,323.09

The C format can be used to improve the output from the price discount program
shown earlier:

*/

// Use the C format specifier to output dollars and cents.

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
//        Console.WriteLine("Discounted price: {0:C}", discounted_price);

//    }
//}

/*

Here is the way the output now looks:

Discounted price: $16.96

*/

#endregion