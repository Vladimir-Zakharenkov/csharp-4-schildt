#region Russian

/*

Теперь, используя модификатор ref, можно написать метод, переставляющий местами
значения двух своих аргументов простого типа. В качестве примера ниже приведена
программа, в которой метод Swap() выполняет перестановку значений двух
своих целочисленных аргументов, когда он вызывается.

*/

// Поменять местами два значения.
//using System;

//class ValueSwap
//{
//    // Этот метод меняет местами свои аргументы.
//    public void Swap(ref int a, ref int b)
//    {
//        int t;
//        t = a;
//        a = b;
//        b = t;
//    }
//}

//class ValueSwapDemo
//{
//    static void Main()
//    {
//        ValueSwap ob = new ValueSwap();

//        int x = 10, у = 20;

//        Console.WriteLine("x и у до вызова: " + x + " " + у);

//        ob.Swap(ref x, ref у);

//        Console.WriteLine("х и у после вызова: " + x + " " + у);
//    }
//}

/*

Вот к какому результату приводит выполнение этой программы.

х и у до вызова: 10 20
х и у после вызова: 20 10

В отношении модификатора ref необходимо иметь в виду следующее. Аргументу,
передаваемому по ссылке с помощью этого модификатора, должно быть присвоено
значение до вызова метода. Дело в том, что в методе, получающем такой аргумент в
качестве параметра, предполагается, что параметр ссылается на действительное значение.
Следовательно, при использовании модификатора ref в методе нельзя задать
первоначальное значение аргумента.

*/

#endregion

#region English

/*

Using ref, it is now possible to write a method that exchanges the values of its two
value-type arguments. For example, here is a program that contains a method called
Swap() that exchanges the values of the two integer arguments with which it is called:

*/

// Swap two values.
using System;

class ValueSwap
{
    // This method now changes its arguments.
    public void Swap(ref int a, ref int b)
    {
        int t;
        t = a;
        a = b;
        b = t;
    }
}

class ValueSwapDemo
{
    static void Main()
    {
        ValueSwap ob = new ValueSwap();

        int x = 10, y = 20;

        Console.WriteLine("x and y before call: " + x + " " + y);

        ob.Swap(ref x, ref y);

        Console.WriteLine("x and y after call: " + x + " " + y);
    }
}

/*

The output from this program is shown here:

x and y before call: 10 20
x and y after call: 20 10

Here is one important point to understand about ref: An argument passed by ref must
be assigned a value prior to the call. The reason is that the method that receives such an
argument assumes that the parameter refers to a valid value. Thus, using ref, you cannot
use a method to give an argument an initial value.

*/

#endregion