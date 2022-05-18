#region MyRegion

/*

Передача объектов методам по ссылке

В приведенных до сих пор примерах программ при указании параметров, передаваемых
методам, использовались типы значений, например int или double. Но в
методах можно также использовать параметры ссылочного типа, что не только правильно,
но и весьма распространено в ООП. Подобным образом объекты могут передаваться
методам по ссылке. В качестве примера рассмотрим следующую программу.

*/

// Пример передачи объектов методам по ссылке.

using System;

class MyClass
{
    int alpha, beta;

    public MyClass(int i, int j)
    {
        alpha = i;
        beta = j;
    }

    // Возвратить значение true, если параметр ob
    // имеет те же значения, что и вызывающий объект.
    public bool SameAs(MyClass ob)
    {
        if ((ob.alpha == alpha) & (ob.beta == beta))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    // Сделать копию объекта ob.
    public void Copy(MyClass ob)
    {
        alpha = ob.alpha;
        beta = ob.beta;
    }

    public void Show()
    {
        Console.WriteLine("alpha: {0}, beta: {1}", alpha, beta);
    }
}
class PassOb
{
    static void Main()
    {
        MyClass ob1 = new MyClass(4, 5);
        MyClass ob2 = new MyClass(6, 7);

        Console.Write("ob1: ");
        ob1.Show();

        Console.Write("ob2: ");
        ob2.Show();

        if (ob1.SameAs(ob2))
        {
            Console.WriteLine("ob1 и ob2 имеют одинаковые значения.");
        }
        else
        {
            Console.WriteLine("ob1 и ob2 имеют разные значения.");
        }

        Console.WriteLine();

        // А теперь сделать объект ob1 копией объекта ob2.
        ob1.Copy(ob2);

        Console.Write("оb1 после копирования: ");
        ob1.Show();

        if (ob1.SameAs(ob2))
        {
            Console.WriteLine("ob1 и ob2 имеют одинаковые значения.");
        }
        else
        {
            Console.WriteLine("ob1 и ob2 имеют разные значения.");
        }
    }
}

/*

Выполнение этой программы дает следующий результат.

ob1: alpha: 4, beta: 5
ob2: alpha: 6, beta: 7

ob1 и ob2 имеют разные значения.

ob1 после копирования: alpha: 6, beta: 7
ob1 и оb2 имеют одинаковые значения.

Каждый из методов SameAs() и Сору() в приведенной выше программе получает
ссылку на объект типа MyClass в качестве аргумента. Метод SameAs() сравнивает
значения переменных экземпляра alpha и beta в вызывающем объекте со значениями
аналогичных переменных в объекте, передаваемом посредством параметра ob.
Данный метод возвращает логическое значение true только в том случае, если оба
объекта имеют одинаковые значения этих переменных экземпляра. А метод Сору()
присваивает значения переменных alpha и beta из объекта, передаваемого по ссылке
посредством параметра ob, переменным alpha и beta из вызывающего объекта. Как
показывает данный пример, с точки зрения синтаксиса объекты передаются методам
по ссылке таким же образом, как и значения обычных типов.

*/

#endregion

#region English

/*

Pass References to Methods

Up to this point, the examples in this book have been using value types, such as int or
double, as parameters to methods. However, it is both correct and common to use a
reference type as a parameter. Doing so allows an object to be passed to a method. For
example, consider the following program:

*/

// References can be passed to methods.
//using System;

//class MyClass
//{
//    int alpha, beta;

//    public MyClass(int i, int j)
//    {
//        alpha = i;
//        beta = j;
//    }

//    // Return true if ob contains the same values as the invoking object.
//    public bool SameAs(MyClass ob)
//    {
//        if ((ob.alpha == alpha) & (ob.beta == beta))
//            return true;
//        else return false;
//    }

//    // Make a copy of ob.
//    public void Copy(MyClass ob)
//    {
//        alpha = ob.alpha;
//        beta = ob.beta;
//    }

//    public void Show()
//    {
//        Console.WriteLine("alpha: {0}, beta: {1}",
//        alpha, beta);
//    }
//}
//class PassOb
//{
//    static void Main()
//    {
//        MyClass ob1 = new MyClass(4, 5);
//        MyClass ob2 = new MyClass(6, 7);

//        Console.Write("ob1: ");
//        ob1.Show();

//        Console.Write("ob2: ");
//        ob2.Show();

//        if (ob1.SameAs(ob2))
//            Console.WriteLine("ob1 and ob2 have the same values.");
//        else
//            Console.WriteLine("ob1 and ob2 have different values.");

//        Console.WriteLine();

//        // Now, make ob1 a copy of ob2.
//        ob1.Copy(ob2);
//        Console.Write("ob1 after copy: ");
//        ob1.Show();

//        if (ob1.SameAs(ob2))
//            Console.WriteLine("ob1 and ob2 have the same values.");
//        else
//            Console.WriteLine("ob1 and ob2 have different values.");
//    }
//}

/*

This program generates the following output:

ob1: alpha: 4, beta: 5
ob2: alpha: 6, beta: 7
ob1 and ob2 have different values.

ob1 after copy: alpha: 6, beta: 7
ob1 and ob2 have the same values.

The SameAs() and Copy() methods each take a reference of type MyClass as an
argument. The SameAs() method compares the values of alpha and beta in the invoking
object with the values of alpha and beta in the object passed via ob. The method returns
true only if the two objects contain the same values for these instance variables. The Copy()
method assigns the values of alpha and beta in the object referred to by ob to alpha and
beta in the invoking object. As this example shows, syntactically, reference types are passed
to methods in the same way as are value types.

*/

#endregion