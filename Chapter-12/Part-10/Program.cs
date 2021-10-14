#region Russian

/*

Явные реализации

При реализации члена интерфейса имеется возможность указать его имя полностью
вместе с именем самого интерфейса. В этом случае получается явная реализация
члена интерфейса, или просто явная реализация. Так, если объявлен интерфейс IMyIF

interface IMyIF {
int MyMeth(int x);
}

то следующая его реализация считается вполне допустимой:

class MyClass : IMyIF {
int IMyIF.MyMeth(int x) {
return x / 3;
}
}

Как видите, при реализации члена MyMeth() интерфейса IMyIF указывается его
полное имя, включающее в себя имя его интерфейса.

Для явной реализации интерфейсного метода могут быть две причины.

Во-первых, когда интерфейсный метод реализуется с указанием его полного имени, 
то такой метод оказывается доступным не посредством объектов класса, реализующего 
данный интерфейс, а по интерфейсной ссылке. Следовательно, явная реализация позволяет
реализовать интерфейсный метод таким образом, чтобы он не стал открытым членом
класса, предоставляющего его реализацию.

И во-вторых, в одном классе могут быть реализованы два интерфейса с методами, 
объявленными с одинаковыми именами и сигнатурами. Но неоднозначность в данном случае 
устраняется благодаря указанию в именах этих методов их соответствующих интерфейсов.

Рассмотрим каждую из этих двух возможностей явной реализации на конкретных примерах.
В приведенном ниже примере программы демонстрируется интерфейс IEven,
в котором объявляются два метода: IsEven() и IsOdd(). В первом из них определяется
четность числа, а во втором — его нечетность. Интерфейс IEven затем реализуется
в классе MyClass. При этом метод IsOdd() реализуется явно.

*/

// Реализовать член интерфейса явно.

using System;

interface IEven
{
    bool IsOdd(int x);
    bool IsEven(int x);
}

class MyClass : IEven
{
    // Явная реализация. Обратите внимание на то, что
    // этот член является закрытым по умолчанию.
    bool IEven.IsOdd(int x)
    {
        if ((x % 2) != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Обычная реализация.
    public bool IsEven(int x)
    {
        IEven o = this; // Интерфейсная ссылка на вызывающий объект.
        return !o.IsOdd(x);
    }
}

class Demo
{
    static void Main()
    {
        MyClass ob = new();
        bool result;

        result = ob.IsEven(4);
        if (result)
        {
            Console.WriteLine("4 - четное число.");
        }

        // result = ob.IsOdd(4); // Ошибка, член IsOdd интерфейса IEven недоступен

        // Но следующий код написан верно, поскольку в нем сначала создается
        // интерфейсная ссылка типа IEven наа объект класса MyClass, аа затем
        // по этой ссылке вызывается метод IsOdd().
        IEven iRef = (IEven)ob;
        result = iRef.IsOdd(3);
        if (result)
        {
            Console.WriteLine("3 - нечетное число.");
        }
    }
}

/*

В приведенном выше примере метод IsOdd() реализуется явно, а значит, он недоступен
как открытый член класса MyClass. Напротив, он доступен только по интерфейсной
ссылке. Именно поэтому он вызывается посредством переменной о ссылочного
типа IEven в реализации метода IsEven().

*/

#endregion

#region English

/*

Explicit Implementations

When implementing a member of an interface, it is possible to fully qualify its name with
its interface name. Doing this creates an explicit interface member implementation, or explicit
implementation, for short. For example, given

interface IMyIF {
int MyMeth(int x);
}

then it is legal to implement IMyIF as shown here:

class MyClass : IMyIF {
int IMyIF.MyMeth(int x) {
return x / 3;
}
}

As you can see, when the MyMeth( ) member of IMyIF is implemented, its complete name,
including its interface name, is specified.

There are two reasons that you might need to create an explicit implementation of an
interface method.

First, when you implement an interface method using its fully qualified
name, you are providing an implementation that cannot be accessed through an object of the
class. Instead, it must be accessed via an interface reference. Thus, an explicit implementation
gives you a way to implement an interface method so that it is not a public member of the
class that provides the implementation.

Second, it is possible for a class to implement two
interfaces, both of which declare methods by the same name and type signature. Qualifying
the names with their interfaces removes the ambiguity from this situation. Let’s look at an
example of each.

The following program contains an interface called IEven, which defines two methods,
IsEven( ) and IsOdd( ), which determine if a number is even or odd. MyClass then implements
IEven. When it does so, it implements IsOdd( ) explicitly.
*/

// Explicitly implement an interface member.

//using System;
//interface IEven
//{
//    bool IsOdd(int x);
//    bool IsEven(int x);
//}
//class MyClass : IEven
//{
//    // Explicit implementation. Notice that this member is private
//    // by default.
//    bool IEven.IsOdd(int x)
//    {
//        if ((x % 2) != 0) return true;
//        else return false;
//    }
//    // Normal implementation.
//    public bool IsEven(int x)
//    {
//        IEven o = this; // Interface reference to the invoking object.
//        return !o.IsOdd(x);
//    }
//}
//class Demo
//{
//    static void Main()
//    {
//        MyClass ob = new MyClass();
//        bool result;
//        result = ob.IsEven(4);
//        if (result) Console.WriteLine("4 is even.");
//        // result = ob.IsOdd(4); // Error, IsOdd not exposed.
//        // But, this is OK. It creates an IEven reference to a MyClass object
//        // and then calls IsOdd() through that reference.
//        IEven iRef = (IEven)ob;
//        result = iRef.IsOdd(3);
//        if (result) Console.WriteLine("3 is odd.");
//    }
//}

/*

Since IsOdd( ) is implemented explicitly, it is not exposed as a public member of MyClass.
Instead, IsOdd( ) can be accessed only through an interface reference. This is why it is
invoked through o (which is a reference variable of type IEven) in the implementation for
IsEven( ).

*/

#endregion