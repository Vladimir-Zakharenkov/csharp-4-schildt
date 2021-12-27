#region Russian

/*

В следующем примере программы демонстрируется применение нескольких тригонометрических
функций, которые относятся к классу Math и входят в стандартную
библиотеку классов С#. Они также оперируют данными типа double. В этом примере
на экран выводятся значения синуса, косинуса и тангенса угла, измеряемого в пределах
от 0,1 до 1,0 радиана.

*/

// Продемонстрировать применение тригонометрических функций.

using System;

class Trigonometry
{
    static void Main()
    {
        Double theta; // угол в радианах

        for (theta = 0.1; theta <= 1; theta = theta + 0.1)
        {
            Console.WriteLine("Синус угла " + theta + " равен " + Math.Sin(theta));
            Console.WriteLine("Косинус угла " + theta + " равен " + Math.Cos(theta));
            Console.WriteLine("Тангенс угла " + theta + " равен " + Math.Tan(theta));
            Console.WriteLine();
        }
    }
}

/*

Ниже приведена лишь часть результата выполнения данной программы.

Синус угла 0.1 равен 0.0998334166468282
Косинус угла 0.1 равен 0.995004165278026
Тангенс угла 0.1 равен 0.100334672085451

Синус угла 0.2 равен 0.198669330795061
Косинус угла 0.2 равен 0.980066577841242
Тангенс угла 0.2 равен 0.202710035508673

Синус угла 0.3 равен 0.29552020666134
Косинус угла 0.3 равен 0.955336489125606
Тангенс угла 0.3 равен 0.309336249609623

Для вычисления синуса, косинуса и тангенса угла в приведенном выше примере
были использованы стандартные методы Math.Sin(), Math.Cos() и Math.Tan().
Как и метод Math.Sqrt(), эти тригонометрические методы вызываются с аргументом
типа double и возвращают результат того же типа. Вычисляемые углы должны быть
указаны в радианах.

*/

#endregion

#region English

/*

The following program demonstrates several of C#’s trigonometric functions, which are
also part of C#’s math library. They also operate on double data. The program displays the
sine, cosine, and tangent for the angles (measured in radians) from 0.1 to 1.0.

*/

// Demonstrate Math.Sin(), Math.Cos(), and Math.Tan().

//using System;
//class Trigonometry
//{
//    static void Main()
//    {
//        Double theta; // angle in radians
//        for (theta = 0.1; theta <= 1.0; theta = theta + 0.1)
//        {
//            Console.WriteLine("Sine of " + theta + " is " + Math.Sin(theta));
//            Console.WriteLine("Cosine of " + theta + " is " + Math.Cos(theta));
//            Console.WriteLine("Tangent of " + theta + " is " + Math.Tan(theta));
//            Console.WriteLine();
//        }
//    }
//}

/*

Here is a portion of the program’s output:

Sine of 0.1 is 0.0998334166468282
Cosine of 0.1 is 0.995004165278026
Tangent of 0.1 is 0.100334672085451

Sine of 0.2 is 0.198669330795061
Cosine of 0.2 is 0.980066577841242
Tangent of 0.2 is 0.202710035508673

Sine of 0.3 is 0.29552020666134
Cosine of 0.3 is 0.955336489125606
Tangent of 0.3 is 0.309336249609623

To compute the sine, cosine, and tangent, the standard library methods Math.Sin(),
Math.Cos(), and Math.Tan() are used. Like Math.Sqrt(), the trigonometric methods
are called with a double argument, and they return a double result. The angles must be
specified in radians.

*/

#endregion