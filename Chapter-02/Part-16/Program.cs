#region Russian

/*

Рассмотрим еще один пример, где кодовый блок служит для вычисления суммы и
произведения чисел от 1 до 10.

*/

// Вычислить сумму и произведение чисел от 1 до 10.

//using System;

//class ProSum
//{
//    static void Main()
//    {
//        int prod;
//        int sum;
//        int i;

//        sum = 0;
//        prod = 1;

//        for (i = 1; i <= 10; i++)
//        {
//            sum = sum + i;
//            prod = prod * i;
//        }

//        Console.WriteLine("Сумма равна " + sum);
//        Console.WriteLine("Произведение равно " + prod);
//    }
//}

/*

Ниже приведен результат выполнения данной программы.

Сумма равна 55
Произведение равно 3628800

В данном примере внутри кодового блока организуется цикл для вычисления суммы
и произведения. В отсутствие такого блока для достижения того же самого результата
пришлось бы организовать два отдельных цикла.

И последнее: кодовые блоки не снижают эффективность программ во время их выполнения.
Иными словами, наличие символов { и }, обозначающих кодовый блок,
никоим образом не замедляет выполнение программы. В действительности применение
кодовых блоков, как правило, приводит к повышению быстродействия и эффективности
программ, поскольку они упрощают программирование определенных
алгоритмов.

*/

#endregion

#region English

/*

Here is another example. It uses a code block to compute the sum and the product of the
numbers from 1 to 10.

*/

// Compute the sum and product of the numbers from 1 to 10.
using System;
class ProdSum
{
    static void Main()
    {
        int prod;
        int sum;
        int i;

        sum = 0;
        prod = 1;

        for (i = 1; i <= 10; i++)
        {
            sum = sum + i;
            prod = prod * i;
        }

        Console.WriteLine("Sum is " + sum);
        Console.WriteLine("Product is " + prod);
    }
}

/*

The output is shown here:

Sum is 55
Product is 3628800

Here, the block enables one loop to compute both the sum and the product. Without the use
of the block, two separate for loops would have been required.

One last point: Code blocks do not introduce any runtime inefficiencies. In other words,
the { and } do not consume any extra time during the execution of a program. In fact, because
of their ability to simplify (and clarify) the coding of certain algorithms, the use of code blocks
generally results in increased speed and efficiency.

*/

#endregion