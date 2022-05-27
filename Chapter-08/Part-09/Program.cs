#region Russian

/*

Способы передачи аргументов методу

Как показывает приведенный выше пример, передача объекта методу по ссылке
делается достаточно просто. Но в этом примере показаны не все нюансы данного процесса.
В некоторых случаях последствия передачи объекта по ссылке будут отличаться
от тех результатов, к которым приводит передача значения обычного типа. Для выяснения
причин этих отличий рассмотрим два способа передачи аргументов методу.

Первым способом является вызов по значению. В этом случае значение аргумента
копируется в формальный параметр метода. Следовательно, изменения, вносимые в
параметр метода, не оказывают никакого влияния на аргумент, используемый для вызова.
А вторым способом передачи аргумента является вызов по ссылке. В данном случае
параметру метода передается ссылка на аргумент, а не значение аргумента. В методе
эта ссылка используется для доступа к конкретному аргументу, указываемому при вызове.
Это означает, что изменения, вносимые в параметр, будут оказывать влияние на
аргумент, используемый для вызова метода.

По умолчанию в C# используется вызов по значению, а это означает, что копия аргумента
создается и затем передается принимающему параметру. Следовательно, при
передаче значения обычного типа, например int или double, все, что происходит с
параметром, принимающим аргумент, не оказывает никакого влияния за пределами
метода. В качестве примера рассмотрим следующую программу.

*/

// Передача аргументов обычных типов по значению.

//using System;

//class Test
//{
//    /* Этот метод не оказывает никакого влияния на
//    аргументы, используемые для его вызова. */
//    public void NoChange(int i, int j)
//    {
//        i = i + j;
//        j = -j;
//    }
//}
//class CallByValue
//{
//    static void Main()
//    {
//        Test ob = new Test();

//        int a = 15, b = 20;

//        Console.WriteLine("а и b до вызова: " + a + " " + b);

//        ob.NoChange(a, b);

//        Console.WriteLine("а и b после вызова: " + a + " " + b);
//    }
//}

/*

Вот какой результат дает выполнение этой программы.

а и b до вызова: 15 20
а и b после вызова: 15 20

Как видите, операции, выполняемые в методе NoChange(), не оказывают никакого
влияния на значения аргументов а и b, используемых для вызова данного метода. Это
опять же объясняется тем, что параметрам i и j переданы копии значений аргументов
а и b, а сами аргументы а и b совершенно не зависят от параметров i и j. В частности,
присваивание параметру i нового значения не будет оказывать никакого влияния на
аргумент а.

*/

#endregion

#region English

/*

How Arguments Are Passed

As the preceding example demonstrated, passing an object reference to a method is a
straightforward task. However, there are some nuances that the example did not show.
In certain cases, the effects of passing a reference type will be different than those experienced
when passing a value type. To see why, let’s review the two ways in which an argument
can be passed to a subroutine.

The first way is call-by-value. This method copies the value of an argument into the formal
parameter of the subroutine. Therefore, changes made to the parameter of the subroutine
have no effect on the argument used in the call. The second way an argument can be passed
is call-by-reference. In this method, a reference to an argument (not the value of the argument)
is passed to the parameter. Inside the subroutine, this reference is used to access the actual
argument specified in the call. This means that changes made to the parameter will affect
the argument used to call the subroutine.

By default, C# uses call-by-value, which means that a copy of the argument is made and
given to the receiving parameter. Thus, when you pass a value type, such as int or double,
what occurs to the parameter that receives the argument has no effect outside the method.
For example, consider the following program:

*/

// Value types are passed by value.

using System;

class Test
{
    /* This method causes no change to the arguments
    used in the call. */
    public void NoChange(int i, int j)
    {
        i = i + j;
        j = -j;
    }
}
class CallByValue
{
    static void Main()
    {
        Test ob = new Test();

        int a = 15, b = 20;

        Console.WriteLine("a and b before call: " + a + " " + b);

        ob.NoChange(a, b);

        Console.WriteLine("a and b after call: " + a + " " + b);
    }
}

/*

The output from this program is shown here:

a and b before call: 15 20
a and b after call: 15 20

As you can see, the operations that occur inside NoChange() have no effect on the values of
a and b used in the call. Again, this is because copies of the value of a and b have been given
to parameters i and j, but a and b are otherwise completely independent of i and j. Thus,
assigning i a new value will not affect a.

*/

#endregion