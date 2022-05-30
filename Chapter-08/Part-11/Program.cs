#region Russian

/*

Использование модификаторов параметров ref и out

Как пояснялось выше, аргументы простых типов, например int или char, передаются
методу по значению. Это означает, что изменения, вносимые в параметр, принимающий
значение, не будут оказывать никакого влияния на аргумент, используемый
для вызова. Но такое поведение можно изменить, используя ключевые слова ref и out
для передачи значений обычных типов по ссылке. Это позволяет изменить в самом
методе аргумент, указываемый при его вызове.

Прежде чем переходить к особенностям использования ключевых слов ref и out,
полезно уяснить причины, по которым значение простого типа иногда требуется передавать
по ссылке. В общем, для этого существуют две причины: разрешить методу
изменить содержимое его аргументов или же возвратить несколько значений. Рассмотрим
каждую из этих причин более подробно.

Нередко требуется, чтобы метод оперировал теми аргументами, которые ему передаются.
Характерным тому примером служит метод Swap(), осуществляющий перестановку
значений своих аргументов. Но поскольку аргументы простых типов передаются по значению, 
то, используя выбираемый в C# по умолчанию механизм вызова
по значению для передачи аргумента параметру, невозможно написать метод, меняющий
местами значения двух его аргументов, например типа int. Это затруднение разрешает
модификатор ref.

Как вам должно быть уже известно, значение возвращается из метода вызывающей
части программы с помощью оператора return. Но метод может одновременно возвратить
лишь одно значение. А что, если из метода требуется возвратить два или более
фрагментов информации, например, целую и дробную части числового значения с
плавающей точкой? Такой метод можно написать, используя модификатор out.

Использование модификатора параметра ref

Модификатор параметра ref принудительно организует вызов по ссылке, а не по
значению. Этот модификатор указывается как при объявлении, так и при вызове метода.
Для начала рассмотрим простой пример. В приведенной ниже программе создается
метод Sqr(), возвращающий вместо своего аргумента квадрат его целочисленного
значения. Обратите особое внимание на применение и местоположение модификатора
ref.

*/

// Использовать модификатор ref для передачи значения обычного типа по ссылке.

using System;

class RefTest
{
    // Этот метод изменяет свой аргумент. Обратите
    // внимание на применение модификатора ref.
    public void Sqr(ref int i)
    {
        i = i * i;
    }
}

class RefDemo
{
    static void Main()
    {
        RefTest ob = new RefTest();

        int a = 10;

        Console.WriteLine("а до вызова: " + a);

        ob.Sqr(ref a); // обратите внимание на применение модификатора ref

        Console.WriteLine("а после вызова: " + a);
    }
}

/*

Как видите, модификатор ref указывается перед объявлением параметра в самом
методе и перед аргументом при вызове метода. Ниже приведен результат выполнения
данной программы, который подтверждает, что значение аргумента а действительно
было изменено с помощью метода Sqr().

а до вызова: 10
а после вызова: 100

*/

#endregion

#region English

/*

Use ref and out Parameters

As just explained, value types, such as int or char, are passed by value to a method. This
means that changes to the parameter that receives a value type will not affect the actual
argument used in the call. You can, however, alter this behavior. Through the use of the ref
and out keywords, it is possible to pass any of the value types by reference. Doing so allows
a method to alter the argument used in the call.

Before going into the mechanics of using ref and out, it is useful to understand why you
might want to pass a value type by reference. In general, there are two reasons: to allow a
method to alter the contents of its arguments or to allow a method to return more than one
value. Let’s look at each reason in detail.

Often you will want a method to be able to operate on the actual arguments that are
passed to it. The quintessential example of this is a Swap( ) method that exchanges the values
of its two arguments. Since value types are passed by value, it is not possible to write a
method that swaps the value of two ints, for example, using C#’s default call-by-value
parameter passing mechanism. The ref modifier solves this problem.

As you know, a return statement enables a method to return a value to its caller. However, a
method can return only one value each time it is called. What if you need to return two or more
pieces of information? For example, what if you want to create a method that decomposes a
floating-point number into its integer and fractional parts? To do this requires that two pieces
of information be returned: the integer portion and the fractional component. This method
cannot be written using only a single return value. The out modifier solves this problem.

Use ref

The ref parameter modifier causes C# to create a call-by-reference, rather than a call-byvalue.
The ref modifier is specified when the method is declared and when it is called. Let’s
begin with a simple example. The following program creates a method called Sqr( ) that
returns in-place the square of its integer argument. Notice the use and placement of ref.

*/

// Use ref to pass a value type by reference.
//using System;

//class RefTest
//{
//    // This method changes its argument. Notice the use of ref.
//    public void Sqr(ref int i)
//    {
//        i = i * i;
//    }
//}

//class RefDemo
//{
//    static void Main()
//    {
//        RefTest ob = new RefTest();

//        int a = 10;

//        Console.WriteLine("a before call: " + a);

//        ob.Sqr(ref a); // notice the use of ref

//        Console.WriteLine("a after call: " + a);
//    }
//}

/*

Notice that ref precedes the entire parameter declaration in the method and that it precedes
the argument when the method is called. The output from this program, shown here, confirms
that the value of the argument, a, was indeed modified by Sqr():

a before call: 10
a after call: 100

*/

#endregion