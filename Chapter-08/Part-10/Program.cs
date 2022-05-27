#region Russian

/*

Дело несколько усложняется при передаче методу ссылки на объект. В этом случае
сама ссылка по-прежнему передается по значению. Следовательно, создается копия
ссылки, а изменения, вносимые в параметр, не оказывают никакого влияния на аргумент.
(Так, если организовать ссылку параметра на новый объект, то это изменение не
повлечет за собой никаких последствий для объекта, на который ссылается аргумент.)
Но главное отличие вызова по ссылке заключается в том, что изменения, происходящие
с объектом, на который ссылается параметр, окажут влияние на тот объект, на
который ссылается аргумент. Попытаемся выяснить причины подобного влияния.

Напомним, что при создании переменной типа класса формируется только ссылка
на объект. Поэтому при передаче этой ссылки методу принимающий ее параметр
будет ссылаться на тот же самый объект, на который ссылается аргумент. Это означает,
что и аргумент, и параметр ссылаются на один и тот же объект и что объекты, по существу,
передаются методам по ссылке. Таким образом, объект в методе будет оказывать
влияние на объект, используемый в качестве аргумента. Для примера рассмотрим следующую
программу.

*/

// Передача объектов по ссылке.

using System;

class Test
{
    public int a, b;
    public Test(int i, int j)
    {
        a = i;
        b = j;
    }

    // Передать объект. Теперь переменные ob.а и ob.b из объекта,
    // используемого в вызове метода, будут изменены.
    public void Change(Test ob)
    {
        ob.a = ob.a + ob.b;
        ob.b = -ob.b;
    }
}
class CallByRef
{
    static void Main()
    {
        Test ob = new Test(15, 20);

        Console.WriteLine("ob.а и ob.b до вызова: " + ob.a + " " + ob.b);

        ob.Change(ob);

        Console.WriteLine("ob.а и ob.b после вызова: " + ob.a + " " + ob.b);
    }
}

/*

Выполнение этой программы дает следующий результат.

ob.a и ob.b до вызова: 15 20
ob.a и ob.b после вызова: 35 -20

Как видите, действия в методе Change() оказали в данном случае влияние на
объект, использовавшийся в качестве аргумента.

Итак, подведем краткий итог. Когда объект передается методу по ссылке, сама ссылка
передается по значению, а следовательно, создается копия этой ссылки. Но эта копия
будет по-прежнему ссылаться на тот же самый объект, что и соответствующий аргумент.
Это означает, что объекты передаются методам неявным образом по ссылке.

*/

#endregion

#region English

/*

When you pass a reference to a method, the situation is a bit more complicated. In this
case, the reference, itself, is still passed by value. Thus, a copy of the reference is made and
changes to the parameter will not affect the argument. (For example, making the parameter
refer to a new object will not change the object to which the argument refers.) However—
and this is a big however—changes made to the object being referred to by the parameter will
affect the object referred to by the argument. Let’s see why.

Recall that when you create a variable of a class type, you are only creating a reference
to an object. Thus, when you pass this reference to a method, the parameter that receives it
will refer to the same object as that referred to by the argument. Therefore, the argument
and the parameter will both refer to the same object. This means that objects are passed to
methods by what is effectively call-by-reference. Thus, changes to the object inside the method
do affect the object used as an argument. For example, consider the following program:

*/

// Objects are passed by reference.
//using System;

//class Test
//{
//    public int a, b;

//    public Test(int i, int j)
//    {
//        a = i;
//        b = j;
//    }

//    /* Pass an object. Now, ob.a and ob.b in object
//    used in the call will be changed. */
//    public void Change(Test ob)
//    {
//        ob.a = ob.a + ob.b;
//        ob.b = -ob.b;
//    }
//}
//class CallByRef
//{
//    static void Main()
//    {
//        Test ob = new Test(15, 20);

//        Console.WriteLine("ob.a and ob.b before call: " + ob.a + " " + ob.b);

//        ob.Change(ob);

//        Console.WriteLine("ob.a and ob.b after call: " + ob.a + " " + ob.b);
//    }
//}

/*

This program generates the following output:

ob.a and ob.b before call: 15 20
ob.a and ob.b after call: 35 -20

As you can see, in this case, the actions inside Change( ) have affected the object used as an
argument.

To review: When a reference is passed to a method, the reference itself is passed by use
of call-by-value. Thus, a copy of that reference is made. However, the copy of that reference
will still refer to the same object as its corresponding argument. This means that objects are
implicitly passed using call-by-reference.

*/

#endregion