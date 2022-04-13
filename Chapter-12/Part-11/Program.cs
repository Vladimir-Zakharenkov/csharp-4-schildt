#region Russian

/*

Ниже приведен пример программы, в которой реализуются два интерфейса, причем
в обоих интерфейсах объявляется метод Meth(). Благодаря явной реализации исключается
неоднозначность, характерная для подобной ситуации.

*/

// Воспользоваться явной реализацией для устранения неоднозначности.

using System;

interface IMyIF_A
{
    int Meth(int x);
}

interface IMyIF_B
{
    int Meth(int x);
}

// Оба интерфейса реализуются в классе MyClass.
class MyClass : IMyIF_A, IMyIF_B
{
    // Реализовать оба метода Meth() явно.
    int IMyIF_A.Meth(int x)
    {
        return x + x;
    }

    int IMyIF_B.Meth(int x)
    {
        return x * x;
    }

    // Вызвать метод Meth() по интерфейсной ссылке.
    public int MehtA(int x)
    {
        IMyIF_A a_ob;
        a_ob = this;
        return a_ob.Meth(x); // вызов интерфейсного метода IMyIF_A
    }

    public int MehtB(int x)
    {
        IMyIF_B b_ob;
        b_ob = this;
        return b_ob.Meth(x); // вызов интерфейсного метода IMyIF_B
    }
}

class FQIFNames
{
    static void Main()
    {
        MyClass ob = new();

        Console.WriteLine("Вызов метода IMyIF_A.Meth(): ");
        Console.WriteLine(ob.MehtA(3));

        Console.WriteLine("Вызов метода IMyIF_B.Meth(): ");
        Console.WriteLine(ob.MehtB(3));
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

Вызов метода IMyIF_A.Meth(): 6
Вызов метода IMyIF_B.Meth(): 9

Анализируя приведенный выше пример программы, обратим прежде всего внимание
на одинаковую сигнатуру метода Meth() в обоих интерфейсах, IMyIF_A и
IMyIF_B. Когда оба этих интерфейса реализуются в классе MyClass, для каждого из
них в отдельности это делается явно, т.е. с указанием полного имени метода Meth().
А поскольку явно реализованный метод может вызываться только по интерфейсной
ссылке, то в классе MyClass создаются две такие ссылки: одна — для интерфейса
IMyIF_A, а другая — для интерфейса IMyIF_B. Именно по этим ссылкам происходит
обращение к объектам данного класса с целью вызвать методы соответствующих интерфейсов,
благодаря чему и устраняется неоднозначность.

Выбор между интерфейсом и абстрактным классом

Одна из самых больших трудностей программирования на C# состоит в правильном
выборе между интерфейсом и абстрактным классом в тех случаях, когда требуется
описать функциональные возможности, но не реализацию. В подобных случаях
рекомендуется придерживаться следующего общего правила: если какое-то понятие
можно описать с точки зрения функционального назначения, не уточняя конкретные
детали реализации, то следует использовать интерфейс. А если требуются некоторые
детали реализации, то данное понятие следует представить абстрактным классом.

Стандартные интерфейсы для среды .NET Framework

Для среды .NET Framework определено немало стандартных интерфейсов, которыми
можно пользоваться в программах на С#. Так, в интерфейсе System.IComparable
определен метод CompareTo(), применяемый для сравнения объектов, когда требуется
соблюдать отношение порядка. Стандартные интерфейсы являются также важной
частью классов коллекций, предоставляющих различные средства, в том числе
стеки и очереди, для хранения целых групп объектов. Так, в интерфейсе System.
Collections.ICollection определяются функции для всей коллекции, а в интерфейсе
System.Collections.IEnumerator — способ последовательного обращения
к элементам коллекции. Эти и многие другие интерфейсы подробнее рассматриваются
в части II данной книги.


*/

#endregion

#region English

/*

Here is an example in which two interfaces are implemented and both interfaces declare
a method called Meth(). Explicit implementation is used to eliminate the ambiguity inherent
in this situation.

*/

// Use explicit implementation to remove ambiguity.

//using System;
//interface IMyIF_A
//{
//    int Meth(int x);
//}
//interface IMyIF_B
//{
//    int Meth(int x);
//}
//// MyClass implements both interfaces.
//class MyClass : IMyIF_A, IMyIF_B
//{
//    // Explicitly implement the two Meth()s.
//    int IMyIF_A.Meth(int x)
//    {
//        return x + x;
//    }
//    int IMyIF_B.Meth(int x)
//    {
//        return x * x;
//    }
//    // Call Meth() through an interface reference.
//    public int MethA(int x)
//    {
//        IMyIF_A a_ob;
//        a_ob = this;
//        return a_ob.Meth(x); // calls IMyIF_A
//    }
//    public int MethB(int x)
//    {
//        IMyIF_B b_ob;
//        b_ob = this;
//        return b_ob.Meth(x); // calls IMyIF_B
//    }
//}
//class FQIFNames
//{
//    static void Main()
//    {
//        MyClass ob = new MyClass();
//        Console.Write("Calling IMyIF_A.Meth(): ");
//        Console.WriteLine(ob.MethA(3));
//        Console.Write("Calling IMyIF_B.Meth(): ");
//        Console.WriteLine(ob.MethB(3));
//    }
//}

/*

The output from this program is shown here:

Calling IMyIF_A.Meth(): 6
Calling IMyIF_B.Meth(): 9

Looking at the program, first notice that Meth() has the same signature in both IMyIF_A
and IMyIF_B. Thus, when MyClass implements both of these interfaces, it explicitly
implements each one separately, fully qualifying its name in the process. Since the only way
that an explicitly implemented method can be called is on an interface reference, MyClass
creates two such references, one for IMyIF_A and one for IMyIF_B, inside MethA() and
MethB(), respectively. It then calls these methods, which call the interface methods, thereby
removing the ambiguity.

Choosing Between an Interface and an Abstract Class

One of the more challenging parts of C# programming is knowing when to create an interface
and when to use an abstract class in cases in which you want to describe functionality but
not implementation. The general rule is this: When you can fully describe the concept in
terms of “what it does” without needing to specify any “how it does it,” then you should
use an interface. If you need to include some implementation details, then you will need to
represent your concept in an abstract class.

The .NET Standard Interfaces

The .NET Framework defines a large number of interfaces that a C# program can use. For
example, System.IComparable defines the CompareTo() method, which allows objects to be
compared when an ordering relationship is required. Interfaces also form an important part
of the Collections classes, which provide various types of storage (such as stacks and queues)
for groups of objects. For example, System.Collections.ICollection defines the functionality
of a collection. System.Collections.IEnumerator offers a way to sequence through the
elements in a collection. These and many other interfaces are described in Part II.

*/

#endregion