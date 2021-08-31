#region Russian

/*

 Методы расширения

 Как упоминалось выше, методы расширения предоставляют средства для расширения
 функций класса, не прибегая к обычному механизму наследования. Методы расширения
 создаются нечасто, поскольку механизм наследования, как правило, предлагает
 лучшее решение. Тем не менее знать, как они действуют, никогда не помешает.
 Ведь они имеют существенное значение для LINQ.

 Метод расширения является статическим и поэтому должен быть включен в состав
 статического, необобщенного класса. Тип первого параметра метода расширения
 определяет тип объектов, для которых этот метод может быть вызван. Кроме того,
 первый параметр может быть указан с модификатором this. Объект, для которого
 вызывается метод расширения, автоматически передается его первому параметру. Он
 не передается явным образом в списке аргументов. Следует, однако, иметь в виду, что
 метод расширения может по-прежнему вызываться для объекта аналогично методу
 экземпляра, несмотря на то, что он объявляется как статический.

 Ниже приведена общая форма метода расширения.

static возращаемый_тип имя(this тип_вызывающего_объекта ob, список_параметров)

 Очевидно, что список_параметров окажется пустым в отсутствие аргументов, за
 исключением аргумента, неявно передаваемого вызывающим объектом ob. Не следует,
 однако, забывать, что первым параметром метода расширения является автоматически
 передаваемый объект, для которого вызывается этот метод. Как правило, метод
 расширения становится открытым членом своего класса.

В приведенном ниже примере программы создаются три простых метода расширения.

*/

// Создать и использовать ряд методов расширения.

using System;
using System.Globalization;

static class MyExtMeth
{
    //Возвратить обратную величину числового значения типа double/
    public static double Reciprocal(this double v)
    {
        return 1.0 / v;
    }

    //Изменить на обратный регистр буквы в символьной строке
    //и возвратить результат.
    public static string RevCase(this string str)
    {
        string temp = "";

        foreach (char ch in str)
        {
            if (Char.IsLower(ch))
            {
                temp += Char.ToUpper(ch, CultureInfo.CurrentCulture);
            }
            else
            {
                temp += Char.ToLower(ch, CultureInfo.CurrentCulture);
            }
        }

        return temp;
    }

    //Возвратить абсолютное значение выражения n / d.
    public static double AbsDevideBy(this double n, double d)
    {
        return Math.Abs(n / d);
    }
}

class ExtDemo
{
    static void Main()
    {
        double val = 8.0;
        string str = "Alpha Beta Gamma";

        //Вызвать метод расширения Reciprocal().
        Console.WriteLine("Обратная величина {0} равна {1}", val, val.Reciprocal());

        //Вызвать метод расширения RevCase().
        Console.WriteLine(str + " после замены регистра: " + str.RevCase());

        //Использовать метод расширения AbsDevideBy().
        Console.WriteLine("Результат вызова метода val.AbsDevideBy(-2): " + val.AbsDevideBy(-2));

        Console.ReadKey();
    }
}

/*

 Эта программа дает следующий результат.

 Обратная величина 8 равна 0.125
 Alpha Beta Gamma после смены регистра: aLPHA bЕТА gАММА
 Результат вызова метода val.AbsDivideBy(-2): 4

 В данном примере программы каждый метод расширения содержится в статическом
 классе MyExtMeths. Как пояснялось выше, метод расширения должен быть
 объявлен в статическом классе. Более того, этот класс должен находиться в области
 действия своих методов расширения, чтобы ими можно было пользоваться. (Именно
 поэтому в исходный текст программы следует включить пространство имен System.Linq,
 так как это дает возможность пользоваться методами расширения, связанными с LINQ.)
 Объявленные методы расширения вызываются для объекта таким же образом, как
 и методы экземпляра. Главное отличие заключается в том, что вызывающий объект
 передается первому параметру метода расширения. Поэтому при выполнении выражения

 val.AbsDivideBy(-2)

 объект val передается параметру n метода расширения AbsDivideBy(), а значение
 -2 — параметру d.

 Любопытно, что методы расширения Reciprocal() и AbsDivideBy() могут
 вполне законно вызываться и для литерала типа double, как показано ниже, поскольку
 они определены для этого типа данных.

 8.0.Reciprocal()
 8.0.AbsDivideBy(-1)

 Кроме того, метод расширения RevCase() может быть вызван следующим образом.

 "AbCDe".RevCase()

В данном случае возвращается строковый литерал с измененным на обратный
регистром букв.

 PLINQ

 В версии .NET Framework 4.0 внедрено новое дополнение LINQ под названием
 PLINQ. Это средство предназначено для поддержки параллельного программирования.
 Оно позволяет автоматически задействовать в запросе несколько доступных процессоров.
 Подробнее о PLINQ и других средствах, связанных с параллельным программированием,
 речь пойдет в главе 24.

*/

#endregion

#region English

/*

Extension Methods

As mentioned earlier, extension methods provide a means by which functionality can be
added to a class without using the normal inheritance mechanism. Although you won’t
often create your own extension methods (because the inheritance mechanism offers a
better solution in many cases), it is still important that you understand how they work
because of their integral importance to LINQ.

An extension method is a static method that must be contained within a static, non-generic
class. The type of its first parameter determines the type of objects on which the extension
method can be called. Furthermore, the first parameter must be modified by this. The object on
which the method is invoked is passed automatically to the first parameter. It is not explicitly
passed in the argument list. A key point is that even though an extension method is declared
static, it can still be called on an object, just as if it were an instance method.

Here is the general form of an extension method:

static ret-type name(this invoked-on-type ob, param-list)

Of course, if there are no arguments other than the one passed implicitly to ob, then param-list
will be empty. Remember, the first parameter is automatically passed the object on which
the method is invoked. In general, an extension method will be a public member of its class.

Here is an example that creates three simple extension methods:

*/

// Create and use some extension methods. 

//using System;  
//using System.Globalization;

//static class MyExtMeths
//{

//    // Return the reciprocal of a double. 
//    public static double Reciprocal(this double v)
//    {
//        return 1.0 / v;
//    }

//    // Reverse the case of letters within a string and 
//    // return th result. 
//    public static string RevCase(this string str)
//    {
//        string temp = "";

//        foreach (char ch in str)
//        {
//            if (Char.IsLower(ch)) temp +=
//                Char.ToUpper(ch, CultureInfo.CurrentCulture);
//            else temp += Char.ToLower(ch, CultureInfo.CurrentCulture);
//        }
//        return temp;
//    }

//    // Return the absolute value of n / d.  
//    public static double AbsDivideBy(this double n, double d)
//    {
//        return Math.Abs(n / d);
//    }
//}

//class ExtDemo
//{
//    static void Main()
//    {
//        double val = 8.0;
//        string str = "Alpha Beta Gamma";

//        // Call the Recip() extension method. 
//        Console.WriteLine("Reciprocal of {0} is {1}",
//                          val, val.Reciprocal());

//        // Call the RevCase() extension method. 
//        Console.WriteLine(str + " after reversing case is " +
//                          str.RevCase());

//        // Use AbsDivideBy(); 
//        Console.WriteLine("Result of val.AbsDivideBy(-2): " +
//                          val.AbsDivideBy(-2));
//    }
//}

/*

The output is shown here:

Reciprocal of 8 is 0.125
Alpha Beta Gamma after reversing case is aLPHA bETA gAMMA
Result of val.AbsDivideBy(-2): 4

In the program, notice that each extension method is contained in a static class called
MyExtMeths. As explained, an extension method must be declared within a static class.
Furthermore, this class must be in scope in order for the extension methods that it contains
to be used. (This is why you needed to include the System.Linq namespace to use the LINQrelated
extension methods.) Next, notice the calls to the extension methods. They are
invoked on an object, in just the same way that an instance method is called. The main
difference is that the invoking object is passed to the first parameter of the extension
method. Therefore, when the expression

val.AbsDivideBy(-2)

executes, val is passed to the n parameter of AbsDivideBy( ) and –2 is passed to the
d parameter.

As a point of interest, because the methods Reciprocal( ) and AbsDivideBy( ) are
defined for double, it is legal to invoke them on a double literal, as shown here:

8.0.Reciprocal()
8.0.AbsDivideBy(-1)

Furthermore, RevCase( ) can be invoked like this:

"AbCDe".RevCase()

Here, the reversed-case version of a string literal is returned.

PLINQ

The .NET Framework 4.0 adds a new capability to LINQ called PLINQ. PLINQ provides
support for parallel programming. This feature enables a query to automatically take
advantage of multiple processors. PLINQ and other features related to parallel
programming are described in Chapter 24.

*/

#endregion