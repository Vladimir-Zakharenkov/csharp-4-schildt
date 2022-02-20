#region Russian

/*

Приведение типов в выражениях

Приведение типов можно применять и к отдельным частям крупного выражения.
Это позволяет точнее управлять преобразованиями типов при вычислении выражения.
Рассмотрим следующий пример программы, в которой выводятся квадратные
корни чисел от 1 до 10 и отдельно целые и дробные части каждого числового результата.
Для этого в данной программе применяется приведение типов, благодаря которому
результат, возвращаемый методом Math.Sqrt(), преобразуется в тип int.

*/

// Пример приведения типов в выражениях.
using System;
class CastExpr
{
    static void Main()
    {
        double n;

        for (n = 1.0; n <= 10; n++)
        {
            Console.WriteLine("Квадратный корень из {0} равен {1}", n, Math.Sqrt(n));
            Console.WriteLine("Целая часть числа: {0}", (int)Math.Sqrt(n));
            Console.WriteLine("Дробная часть числа: {0}", Math.Sqrt(n) - (int)Math.Sqrt(n));
            Console.WriteLine();
        }
    }
}

/*

Вот как выглядит результат выполнения этой программы.

Квадратный корень из 1 равен 1
Целая часть числа: 1
Дробная часть числа: 0

Квадратный корень из 2 равен 1.4142135623731
Целая часть числа: 1
Дробная часть числа: 0.414213562373095

Квадратный корень из 3 равен 1.73205080756888
Целая часть числа: 1
Дробная часть числа: 0.732050807568877

Квадратный корень из 4 равен 2
Целая часть числа: 2
Дробная часть числа: 0

Квадратный корень из 5 равен 2.23606797749979
Целая часть числа: 2
Дробная часть числа: 0.23606797749979

Квадратный корень из 6 равен 2.44948974278318
Целая часть числа: 2
Дробная часть числа: 0.449489742783178

Квадратный корень из 7 равен 2.64575131106459
Целая часть числа: 2
Дробная часть числа: 0.645751311064591

Квадратный корень из 8 равен 2.82842712474619
Целая часть числа: 2
Дробная часть числа: 0.82842712474619

Квадратный корень из 9 равен 3
Целая часть числа: 3
Дробная часть числа: 0

Квадратный корень из 10 равен 3.16227766016838
Целая часть числа: 3
Дробная часть числа: 0.16227766016838

Как видите, приведение результата, возвращаемого методом Math.Sqrt(), к типу
int позволяет получить целую часть числа. Так, в выражении

Math.Sqrt(n) - (int) Math.Sqrt(n)

приведение к типу int дает целую часть числа, которая затем вычитается из всего
числа, а в итоге получается дробная его часть. Следовательно, результат вычисления
данного выражения имеет тип double. Но к типу int приводится только значение,
возвращаемое вторым методом Math.Sqrt().

*/

#endregion

#region English

/*

Using Casts in Expressions

A cast can be applied to a specific portion of a larger expression. This gives you fine-grained
control over the way type conversions occur when an expression is evaluated. For example,
consider the following program. It displays the square roots of the numbers from 1 to 10. It
also displays the whole number portion and the fractional part of each result, separately. To
do so, it uses a cast to convert the result of Math.Sqrt( ) to int.

*/

// Using casts in an expression.
//using System;
//class CastExpr
//{
//    static void Main()
//    {
//        double n;
//        for (n = 1.0; n <= 10; n++)
//        {
//            Console.WriteLine("The square root of {0} is {1}", n, Math.Sqrt(n));
//            Console.WriteLine("Whole number part: {0}", (int)Math.Sqrt(n));
//            Console.WriteLine("Fractional part: {0}", Math.Sqrt(n) - (int)Math.Sqrt(n));
//            Console.WriteLine();
//        }
//    }
//}

/*

Here is the output from the program:
The square root of 1 is 1
Whole number part: 1
Fractional part: 0

The square root of 2 is 1.4142135623731
Whole number part: 1
Fractional part: 0.414213562373095

The square root of 3 is 1.73205080756888
Whole number part: 1
Fractional part: 0.732050807568877

The square root of 4 is 2
Whole number part: 2
Fractional part: 0

The square root of 5 is 2.23606797749979
Whole number part: 2
Fractional part: 0.23606797749979

The square root of 6 is 2.44948974278318
Whole number part: 2
Fractional part: 0.449489742783178

The square root of 7 is 2.64575131106459
Whole number part: 2
Fractional part: 0.645751311064591

The square root of 8 is 2.82842712474619
Whole number part: 2
Fractional part: 0.82842712474619

The square root of 9 is 3
Whole number part: 3
Fractional part: 0

The square root of 10 is 3.16227766016838
Whole number part: 3
Fractional part: 0.16227766016838

As the output shows, the cast of Math.Sqrt( ) to int results in the whole number component
of the value. In this expression

Math.Sqrt(n) - (int) Math.Sqrt(n)

the cast to int obtains the whole number component, which is then subtracted from the
complete value, yielding the fractional component. Thus, the outcome of the expression
is double. Only the value of the second call to Math.Sqrt( ) is cast to int.

*/

#endregion