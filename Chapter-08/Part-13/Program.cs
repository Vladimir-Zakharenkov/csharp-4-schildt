#region Russian

/*

Использование модификатора параметра out

Иногда ссылочный параметр требуется использовать для получения значения из
метода, а не для передачи ему значения. Допустим, что имеется метод, выполняющий
некоторую функцию, например, открытие сетевого сокета и возврат кода успешного
или неудачного завершения данной операции в качестве ссылочного параметра.
В этом случае методу не передается никакой информации, но в то же время он должен
возвратить определенную информацию. Главная трудность при этом состоит в том,
что параметр типа ref должен быть инициализирован определенным значением до
вызова метода. Следовательно, чтобы воспользоваться параметром типа ref, придется
задать для аргумента фиктивное значение и тем самым преодолеть данное ограничение.
Правда, в C# имеется более подходящий вариант выхода из подобного затруднения
— воспользоваться модификатором параметра out.

Модификатор параметра out подобен модификатору ref, за одним исключением:
он служит только для передачи значения за пределы метода. Поэтому переменной,
используемой в качестве параметра out, не нужно (да и бесполезно) присваивать
какое-то значение. Более того, в методе параметр out считается неинициализированным,
т.е. предполагается, что у него отсутствует первоначальное значение. Это
означает, что значение должно быть присвоено данному параметру в методе до его
завершения. Следовательно, после вызова метода параметр out будет содержать некоторое
значение.

Ниже приведен пример применения модификатора параметра out. В этом примере
программы для разделения числа с плавающей точкой на целую и дробную части
используется метод GetParts() из класса Decompose. Обратите внимание на то, как
возвращается каждая часть исходного числа.

*/

// Использовать модификатор параметра out.
//using System;

//class Decompose
//{
//    /* Разделить числовое значение с плавающей точкой на целую и дробную части. */
//    public int GetParts(double n, out double frac)
//    {
//        int whole;
//        whole = (int)n;
//        frac = n - whole; // передать дробную часть числа через параметр frac
//        return whole; // возвратить целую часть числа
//    }
//}

//class UseOut
//{
//    static void Main()
//    {
//        Decompose ob = new Decompose();

//        int i;
//        double f;

//        i = ob.GetParts(10.125, out f);

//        Console.WriteLine("Целая часть числа равна " + i);
//        Console.WriteLine("Дробная часть числа равна " + f);
//    }
//}

/*

Выполнение этой программы дает следующий результат.

Целая часть числа равна 10
Дробная часть числа равна 0.125

Метод GetParts() возвращает два фрагмента информации. Во-первых, целую
часть исходного числового значения переменной n обычным образом с помощью оператора
return. И во-вторых, дробную часть этого значения посредством параметра
frас типа out. Как показывает данный пример, используя модификатор параметра
out, можно организовать возврат двух значений из одного и того же метода.

*/

#endregion

#region English

/*

Use out

Sometimes you will want to use a reference parameter to receive a value from a method, but
not pass in a value. For example, you might have a method that performs some function,
such as opening a network socket, that returns a success/fail code in a reference parameter.
In this case, there is no information to pass into the method, but there is information to pass
back out. The problem with this scenario is that a ref parameter must be initialized to a
value prior to the call. Thus, to use a ref parameter would require giving the argument a
dummy value just to satisfy this constraint. Fortunately, C# provides a better alternative:
the out parameter.

An out parameter is similar to a ref parameter with this one exception: It can only be
used to pass a value out of a method. It is not necessary (or useful) to give the variable used
as an out parameter an initial value prior to calling the method. The method will give the
variable a value. Furthermore, inside the method, an out parameter is considered unassigned;
that is, it is assumed to have no initial value. This implies that the method must assign the
parameter a value prior to the method’s termination. Thus, after the call to the method, an
out parameter will contain a value.

Here is an example that uses an out parameter. In the class Decompose, the GetParts( )
method decomposes a floating-point number into its integer and fractional parts. Notice
how each component is returned to the caller.

*/

// Use out.
using System;

class Decompose
{
    /* Decompose a floating-point value into its integer and fractional parts. */
    public int GetParts(double n, out double frac)
    {
        int whole;

        whole = (int)n;

        frac = n - whole; // pass fractional part back through frac

        return whole; // return integer portion
    }
}

class UseOut
{
    static void Main()
    {
        Decompose ob = new Decompose();

        int i;
        double f;

        i = ob.GetParts(10.125, out f);

        Console.WriteLine("Integer portion is " + i);
        Console.WriteLine("Fractional part is " + f);
    }
}

/*

The output from the program is shown here:

Integer portion is 10
Fractional part is 0.125

The GetParts() method returns two pieces of information. First, the integer portion of n is
returned as GetParts( )’s return value. Second, the fractional portion of n is passed back to
the caller through the out parameter frac. As this example shows, by using out, it is possible
for one method to return two values.

*/

#endregion