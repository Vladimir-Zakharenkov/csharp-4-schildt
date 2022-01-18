#region Russian

/*

Рассмотрим еще один пример применения типа decimal. В этом примере рассчитывается
будущая стоимость капиталовложений с фиксированной нормой прибыли в течение ряда лет.

*/

// Применить тип decimal для расчета будущей стоимости капиталовложений.

using System;

class FutVal
{
    static void Main()
    {
        decimal amount;
        decimal rate_of_return;
        int years, i;

        amount = 1000.0M;
        rate_of_return = 0.07M;
        years = 10;

        Console.WriteLine("Первоначальные капиталовложения: $" + amount);
        Console.WriteLine("Норма прибыли: " + rate_of_return);
        Console.WriteLine("В течении " + years + " лет");

        for (i = 0; i < years; i++)
        {
            amount = amount + (amount * rate_of_return);
        }

        Console.WriteLine("Будущая стоимость равна $" + amount);
    }
}

/*

Вот как выглядит результат выполнения этой программы.

Первоначальные капиталовложения: $1000
Норма прибыли: 0.07
В течение 10 лет
Будущая стоимость равна $1967.151357289565322490000

Обратите внимание на то, что результат выполнения приведенной выше программы
представлен с точностью ДО целого ряда десятичных разрядов, т.е. с явным избытком
по сравнению с тем, что обычно требуется! Далее в этой главе будет показано, как
подобный результат приводится к более "привлекательному" виду.

*/

#endregion

#region English

/*

Here is another example that uses the decimal type. It computes the future value of an
investment that has a fixed rate of return over a period of years.

*/

// Use the decimal type to compute the future value of an investment.

//using System;
//class FutVal
//{
//    static void Main()
//    {
//        decimal amount;
//        decimal rate_of_return;
//        int years, i;

//        amount = 1000.0M;
//        rate_of_return = 0.07M;
//        years = 10;

//        Console.WriteLine("Original investment: $" + amount);
//        Console.WriteLine("Rate of return: " + rate_of_return);
//        Console.WriteLine("Over " + years + " years");

//        for (i = 0; i < years; i++)
//            amount = amount + (amount * rate_of_return);

//        Console.WriteLine("Future value is $" + amount);
//    }
//}

/*

Here is the output:

Original investment: $1000
Rate of return: 0.07
Over 10 years
Future value is $1967.151357289565322490000

Notice that the result is accurate to several decimal places—more than you would probably
want! Later in this chapter you will see how to format such output in a more appealing
fashion.

*/

#endregion