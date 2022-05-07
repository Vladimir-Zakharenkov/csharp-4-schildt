#region Russian

/*

Модификаторы доступа

Управление доступом в языке C# организуется с помощью четырех модификаторов
доступа: public, private, protected и internal. В этой главе основное внимание
уделяется модификаторам доступа public и private. Модификатор protected применяется
только в тех случаях, которые связаны с наследованием, и поэтому речь о нем
пойдет в главе 11. А модификатор internal служит в основном для сборки, которая в
широком смысле означает в C# разворачиваемую программу или библиотеку, и поэтому
данный модификатор подробнее рассматривается в главе 16.

Когда член класса обозначается спецификатором public, он становится доступным
из любого другого кода в программе, включая и методы, определенные в других
классах. Когда же член класса обозначается спецификатором private, он может быть
доступен только другим членам этого класса. Следовательно, методы из других классов
не имеют доступа к закрытому члену (private) данного класса. Как пояснялось в главе
6, если ни один из спецификаторов доступа не указан, член класса считается закрытым
для своего класса по умолчанию. Поэтому при создании закрытых членов класса
спецификатор private указывать для них необязательно.

Спецификатор доступа указывается перед остальной частью описания типа отдельного
члена. Это означает, что именно с него должен начинаться оператор объявления
члена класса. Ниже приведены соответствующие примеры.

public string errMsg;
private double bal;
private bool isError(byte status) { // ...

Для того чтобы стали более понятными отличия между модификаторами public
и private, рассмотрим следующий пример программы.

*/

// Отличия между видами доступа public и private к членам класса.

using System;

class Myclass
{
    private int alpha;  // закрытый доступ, указываемый явно
    int beta;           // закрытый доступ по умолчанию
    public int gamma;   // открытый доступ

    // методы, которым доступны члены alpha и beta данного класса.
    // член класса может иметь доступ к закрытому члену этого же класса.

    public void SetAlpha(int а)
    {
        alpha = а;
    }

    public int GetAlpha()
    {
        return alpha;
    }
    public void SetBeta(int a)
    {
        beta = a;
    }
    public int GetBeta()
    {
        return beta;
    }
}

class Accessdemo
{
    static void Main()
    {
        Myclass ob = new Myclass();

        // доступ к членам alpha и beta данного класса
        // разрешен только посредством его методов.

        ob.SetAlpha(-99);
        ob.SetBeta(19);
        Console.WriteLine("ob.alpha равно " + ob.GetAlpha());
        Console.WriteLine("ob.beta равно " + ob.GetBeta());

        // следующие виды доступа к членам alpha и beta
        // данного класса не разрешаются.

        // ob.alpha = 10; // ошибка! alpha - закрытый член!
        // ob.beta =9; // ошибка! beta - закрытый член!

        // член gamma данного класса доступен непосредственно,
        // поскольку он является открытым.

        ob.gamma = 99;
    }
}

/*

Как видите, в классе MyClass член alpha указан явно как private, член beta становится
private по умолчанию, а член gamma указан как public. Таким образом,
члены alpha и beta недоступны непосредственно из кода за пределами данного класса,
поскольку они являются закрытыми. В частности, ими нельзя пользоваться непосредственно
в классе AccessDemo. Они доступны только с помощью таких открытых
(public) методов, как SetAlpha() и GetAlpha(). Так, если удалить символы комментария
в начале следующей строки кода:

// ob.alpha = 10; // Ошибка! alpha - закрытый член!

то приведенная выше программа не будет скомпилирована из-за нарушения правил
доступа. Но несмотря на то, что член alpha недоступен непосредственно за пределами
класса MyClass, свободный доступ к нему организуется с помощью методов,
определенных в классе MyClass, как наглядно показывают методы SetAlpha()
и GetAlpha(). Это же относится и к члену beta.

Из всего сказанного выше можно сделать следующий важный вывод: закрытый член
может свободно использоваться другими членами этого же класса, но недоступен для
кода за пределами своего класса.

*/

#endregion

#region English

/*

C#’s Access Modifiers

Member access control is achieved through the use of four access modifiers: public, private,
protected, and internal. In this chapter, we will be concerned with public and private. The
protected modifier applies only when inheritance is involved and is described in Chapter 11.

The internal modifier applies mostly to the use of an assembly, which for C# loosely means
a deployable program or library. The internal modifier is examined in Chapter 16.

When a member of a class is modified by the public specifier, that member can be
accessed by any other code in your program. This includes methods defined inside other
classes.

When a member of a class is specified as private, then that member can be accessed only
by other members of its class. Thus, methods in other classes are not able to access a private
member of another class. As explained in Chapter 6, if no access specifier is used, a class
member is private to its class by default. Thus, the private specifier is optional when creating
private class members.

An access specifier precedes the rest of a member’s type specification. That is, it must
begin a member’s declaration statement. Here are some examples:

public string errMsg;
private double bal;
private bool isError(byte status) { // ...

To understand the difference between public and private, consider the following
program:

*/

// Public vs. private access.

//using System;

//class MyClass
//{
//    private int alpha;  // private access explicitly specified
//    int beta;           // private access by default
//    public int gamma;   // public access
//        // Methods to access alpha and beta. It is OK for a member
//        // of a class to access a private member of the same class.

//    public void SetAlpha(int a)
//    {
//        alpha = a;
//    }
//    public int GetAlpha()
//    {
//        return alpha;
//    }
//    public void SetBeta(int a)
//    {
//        beta = a;
//    }
//    public int GetBeta()
//    {
//        return beta;
//    }
//}
//class AccessDemo
//{
//    static void Main()
//    {
//        MyClass ob = new MyClass();

//        // Access to alpha and beta is allowed only through methods.

//        ob.SetAlpha(-99);
//        ob.SetBeta(19);
//        Console.WriteLine("ob.alpha is " + ob.GetAlpha());
//        Console.WriteLine("ob.beta is " + ob.GetBeta());

//        // You cannot access alpha or beta like this:
//        // ob.alpha = 10; // Wrong! alpha is private!
//        // ob.beta = 9; // Wrong! beta is private!
//        // It is OK to directly access gamma because it is public.

//        ob.gamma = 99;
//    }
//}

/*

As you can see, inside the MyClass class, alpha is specified as private, beta is private by
default, and gamma is specified as public. Because alpha and beta are private, they cannot
be accessed by code outside of their class. Therefore, inside the AccessDemo class, neither
can be used directly. Each must be accessed through public methods, such as SetAlpha( )
and GetAlpha( ). For example, if you were to remove the comment symbol from the
beginning of the following line

// ob.alpha = 10; // Wrong! alpha is private!

you would not be able to compile this program because of the access violation. Although
access to alpha by code outside of MyClass is not allowed, methods defined within
MyClass can freely access it, as the SetAlpha( ) and GetAlpha( ) methods show. The same
is true for beta.

The key point is this: A private member can be used freely by other members of its class,
but it cannot be accessed by code outside its class.

*/

#endregion