#region Russian

/*

Когда одна структура присваивается другой, создается копия ее объекта. В этом заключается
одно из главных отличий структуры от класса. Как пояснялось ранее в этой
книге, когда ссылка на один класс присваивается ссылке на другой класс, в итоге ссылка
в левой части оператора присваивания указывает на тот же самый объект, что и ссылка
в правой его части. А когда переменная одной структуры присваивается переменной
другой структуры, создается копия объекта структуры из правой части оператора присваивания.
Рассмотрим в качестве примера следующую программу.

*/

// Скопировать структуру.

using System;

// Определить структуру.
struct MyStruct
{
    public int x;
}

// Продемонстрировать присваивание структуры.
class StructAssignment
{
    static void Main()
    {
        MyStruct a;
        MyStruct b;

        a.x = 10;
        b.x = 20;

        Console.WriteLine("a.x {0}, b.x {1}", a.x, b.x);

        a = b;
        b.x = 30;

        Console.WriteLine("a.x {0}, b.x {1}", a.x, b.x);
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

а.х 10, b.x 20
a.x 20, b.x 30

Как показывает приведенный выше результат, после присваивания

а = b;

переменные структуры а и b по-прежнему остаются совершенно обособленными,
т.е. переменная а не указывает на переменную b и никак не связана с ней, помимо того,
что она содержит копию значения переменной b.

*/

#endregion

#region English

/*

When you assign one structure to another, a copy of the object is made. This is an
important way in which struct differs from class. As explained earlier in this book, when
you assign one class reference to another, you are simply making the reference on the left
side of the assignment refer to the same object as that referred to by the reference on the
right. When you assign one struct variable to another, you are making a copy of the object
on the right. For example, consider the following program:

*/

// Copy a struct.

//using System;

//// Define a structure.
//struct MyStruct
//{
//    public int x;
//}

//// Demonstrate structure assignment.
//class StructAssignment
//{
//    static void Main()
//    {
//        MyStruct a;
//        MyStruct b;
//        a.x = 10;
//        b.x = 20;
//        Console.WriteLine("a.x {0}, b.x {1}", a.x, b.x);
//        a = b;
//        b.x = 30;
//        Console.WriteLine("a.x {0}, b.x {1}", a.x, b.x);
//    }
//}

/*

The output is shown here:

a.x 10, b.x 20
a.x 20, b.x 30

As the output shows, after the assignment

a = b;

the structure variables a and b are still separate and distinct. That is, a does not refer to or
relate to b in any way other than containing a copy of b’s value.

*/

#endregion