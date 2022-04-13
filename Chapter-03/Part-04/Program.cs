#region Russian

/*

Типы для представления чисел с плавающей точкой

Типы с плавающей точкой позволяют представлять числа с дробной частью. В С#
имеются две разновидности типов данных с плавающей точкой: float и double. Они
представляют числовые значения с одинарной и двойной точностью соответственно.
Так, разрядность типа float составляет 32 бита, что приближенно соответствует диапазону
представления чисел от 5Е-45 до 3,4Е+38. А разрядность типа double составляет
64 бита, что приближенно соответствует диапазону представления чисел от 5Е-324 до
1,7Е+308.

В программировании на С# чаще применяется тип double, в частности, потому,
что во многих математических функциях из библиотеки классов С#, которая одновременно
является библиотекой классов для среды .NET Framework, используются числовые
значения типа double. Например, метод Sqrt(), определенный в библиотеке
классов System.Math, возвращает значение типа double, которое представляет собой
квадратный корень из аргумента типа double, передаваемого данному методу. В приведенном
ниже примере программы метод Sqrt() используется для вычисления радиуса
окружности по площади круга.

*/

// Определить радиус окружности по площади круга.

using System;

class FindRadius
{
    static void Main()
    {
        Double r;
        Double area;

        area = 10.0;
        r = Math.Sqrt(area / 3.1416);

        Console.WriteLine("Радиус равен " + r);
    }
}

/*

Результат выполнения этой программы выглядит следующим образом.

Радиус равен 1.78412203012729

В приведенном выше примере программы следует обратить внимание на вызов метода
Sqrt(). Как упоминалось выше, метод Sqrt() относится к классу Math, поэтому
в его Вызове имя Math предшествует имени самого метода. Аналогичным образом имя
класса Console предшествует имени метода WriteLine() в его вызове. При вызове
некоторых, хотя и не всех, стандартных методов обычно указывается имя их класса, как
показано в следующем примере.

*/

#endregion

#region English

/*

Floating-Point Types

The floating-point types can represent numbers that have fractional components. There are
two kinds of floating-point types, float and double, which represent single- and doubleprecision
numbers, respectively. The type float is 32 bits wide and has an approximate
range of 1.5E–45 to 3.4E+38. The double type is 64 bits wide and has an approximate range
of 5E–324 to 1.7E+308.

Of the two, double is the most commonly used. One reason for this is that many of the
math functions in C#’s class library (which is the .NET Framework library) use double
values. For example, the Sqrt() method (which is defined by the library class System.Math)
returns a double value that is the square root of its double argument. Here, Sqrt() is used to
compute the radius of a circle given the circle’s area:

*/

// Find the radius of a circle given its area.

//using System;

//class FindRadius
//{
//    static void Main()
//    {
//        Double r;
//        Double area;

//        area = 10.0;

//        r = Math.Sqrt(area / 3.1416);

//        Console.WriteLine("Radius is " + r);
//    }
//}

/*

The output from the program is shown here:

Radius is 1.78412203012729

One other point about the preceding example. As mentioned, Sqrt() is a member of the
Math class. Notice how Sqrt() is called; it is preceded by the name Math. This is similar to
the way Console precedes WriteLine(). Although not all standard methods are called by
specifying their class name first, several are, as the next example shows.

*/

#endregion