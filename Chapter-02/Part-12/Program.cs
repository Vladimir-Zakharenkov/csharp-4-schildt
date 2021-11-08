#region Russian

/*

Типы данных с плавающей точкой зачастую используются в операциях с реальными
числовыми величинами, где обычно требуется дробная часть числа. Так, приведенная
ниже программа вычисляет площадь круга, используя значение 3,1416 числа "пи".

*/

// Вычислить площадь круга.

using System;

class Circle
{
    static void Main()
    {
        double radius;
        double area;

        radius = 10.0;
        area = radius * radius * 3.1416;

        Console.WriteLine("Площадь круга равна " + area);
    }
}

/*

Выполнение этой программы дает следующий результат.

Площадь равна 314.16

Очевидно, что вычисление площади круга не дало бы удовлетворительного результата,
если бы при этом не использовались данные с плавающей точкой.

*/

#endregion

#region English

/*

The floating-point data types are often used when working with real-world quantities
where fractional components are commonly needed. For example, this program computes
the area of a circle. It uses the value 3.1416 for pi.

*/

// Compute the area of a circle.

//using System;

//class Circle
//{
//    static void Main()
//    {
//        double radius;
//        double area;

//        radius = 10.0;
//        area = radius * radius * 3.1416;

//        Console.WriteLine("Area is " + area);
//    }
//}

/*

The output from the program is shown here:

Area is 314.16

Clearly, the computation of a circle’s area could not be achieved satisfactorily without the
use of floating-point data.

*/

#endregion