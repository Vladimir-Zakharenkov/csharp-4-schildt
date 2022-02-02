#region Russian

/*

Динамическая инициализация

В приведенных выше примерах в качестве инициализаторов переменных использовались
только константы, но в C# допускается также динамическая инициализация
переменных с помощью любого выражения, действительного на момент объявления
переменной. Ниже приведен пример краткой программы для вычисления гипотенузы
прямоугольного треугольника по длине его противоположных сторон.

*/

// Продемонстрировать динамическую инициализацию.

//using System;

//class DynInit
//{
//    static void Main()
//    {
//        // Длина сторон прямоугольного треугольника,
//        double s1 = 4.0;
//        double s2 = 5.0;

//        // Инициализировать переменную hypot динамически,
//        double hypot = Math.Sqrt((s1 * s1) + (s2 * s2));

//        Console.Write("Гипотенуза треугольника со сторонами " + s1 + " и " + s2 + " равна ");

//        Console.WriteLine("{0:#.###}.", hypot);
//    }
//}

/*
Результат выполнения этой программы выглядит следующим образом.

Гипотенуза треугольника со сторонами 4 и 5 равна 6.403

В данном примере объявляются три локальные переменные: s1, s2 и hypot. Две
из них (s1 и s2) инициализируются константами, А третья (hypot) динамически инициализируется
вычисляемой длиной гипотенузы. Для такой инициализации используется
выражение, указываемое в вызываемом методе Math.Sqrt(). Как пояснялось
выше, для динамической инициализации пригодно любое выражение, действительное
на момент объявления переменной. А поскольку вызов метода Math.Sqrt() (или любого
другого библиотечного метода) является действительным на данный момент, то
его можно использовать для инициализации переменной hypot. Следует особо подчеркнуть,
что в выражении для инициализации можно использовать любой элемент,
действительный на момент самой инициализации переменной, в том числе вызовы
методов, другие переменные или литералы.

*/

#endregion

#region English

/*

Dynamic Initialization

Although the preceding examples have used only constants as initializers, C# allows
variables to be initialized dynamically, using any expression valid at the point at which
the variable is declared. For example, here is a short program that computes the hypotenuse
of a right triangle given the lengths of its two opposing sides.

*/

// Demonstrate dynamic initialization.
using System;
class DynInit
{
    static void Main()
    {
        // Length of sides.
        double s1 = 4.0;
        double s2 = 5.0;

        // Dynamically initialize hypot.
        double hypot = Math.Sqrt((s1 * s1) + (s2 * s2));

        Console.Write("Hypotenuse of triangle with sides " + s1 + " by " + s2 + " is ");
        Console.WriteLine("{0:#.###}.", hypot);
    }
}

/*
 * 
Here is the output:

Hypotenuse of triangle with sides 4 by 5 is 6.403.

Here, three local variables — s1, s2, and hypot — are declared. The first two, s1 and s2, are
initialized by constants. However, hypot is initialized dynamically to the length of the
hypotenuse. Notice that the initialization involves calling Math.Sqrt( ). As explained, you can
use any expression that is valid at the point of the initialization. Since a call to Math.Sqrt()
(or any other library method) is valid at this point, it can be used in the initialization of
hypot. The key point here is that the initialization expression can use any element valid
at the time of the initialization, including calls to methods, other variables, or literals.

*/

#endregion