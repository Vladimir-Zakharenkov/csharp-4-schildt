#region Russian

/*

15 ГЛАВА

Делегаты, события и лямбда-выражения

В этой главе рассматриваются три новых средства С#:
делегаты, события и лямбда-выражения. Делегат
предоставляет возможность инкапсулировать метод,
а событие уведомляет о том, что произошло некоторое
действие. Делегаты и события тесно связаны друг с другом,
поскольку событие основывается на делегате. Оба средства
расширяют круг прикладных задача, решаемых при программировании
на С#. А лямбда-выражение представляет
собой новое синтаксическое средство, обеспечивающее
упрощенный, но в то же время эффективный способ определения
того, что по сути является единицей исполняемого
кода. Лямбда-выражения обычно служат для работы с делегатами
и событиями, поскольку делегат может ссылаться на
лямбда-выражение. (Кроме того, лямбда-выражения очень
важны для языка LINQ, описываемого в главе 19.) В данной
главе рассматриваются также анонимные методы, ковариантность,
контравариантность и групповые преобразования
методов.

Делегаты

Начнем с определения понятия делегата. Попросту говоря,
делегат представляет собой объект, который может
ссылаться на метод. Следовательно, когда создается делегат,
то в итоге получается объект, содержащий ссылку на метод.
Более того, метод можно вызывать по этой ссылке. Иными
словами, делегат позволяет вызывать метод, на который он
ссылается. Ниже будет показано, насколько действенным
оказывается такой принцип.

Следует особо подчеркнуть, что один и тот же делегат может быть использован
для вызова разных методов во время выполнения программы, для чего достаточно
изменить метод, на который ссылается делегат. Таким образом, метод, вызываемый
делегатом, определяется во время выполнения, а не в процессе компиляции. В этом,
собственно, и заключается главное преимущество делегата.

ПРИМЕЧАНИЕ
Если у вас имеется опыт программирования на C/C++, то вам полезно будет знать, что
делегат в C# подобен указателю на функцию в C/C++.

Тип делегата объявляется с помощью ключевого слова delegate. Ниже приведена
общая форма объявления делегата:

delegate возвращаемый_тип имя(список_параметров);

где возвращаемый_тип обозначает тип значения, возвращаемого методами, которые
будут вызываться делегатом; имя — конкретное имя делегата; список_параметров —
параметры, необходимые для методов, вызываемых делегатом. Как только будет создан
экземпляр делегата, он может вызывать и ссылаться на те методы, возвращаемый
тип и параметры которых соответствуют указанным в объявлении делегата.

Самое главное, что делегат может служить для вызова любого метода с соответствующей
сигнатурой и возвращаемым типом. Более того, вызываемый метод может быть
методом экземпляра, связанным с отдельным объектом, или же статическим методом,
связанным с конкретным классом. Значение имеет лишь одно: возвращаемый тип
и сигнатура метода должны быть согласованы с теми, которые указаны в объявлении
делегата.

Для того чтобы показать делегат в действии, рассмотрим для начала простой пример
его применения.

*/

// Простой пример применения делегата.

using System;

//Объявить тип делегата.
delegate string StrMod(string str);

class DelegateTest
{
    //Заменить пробелы дефисами
    static string ReplaceSpaces(string s)
    {
        Console.WriteLine("Замена пробелов дефисами."); ;
        return s.Replace(' ', '-');
    }

    //Удалить пробелы
    static string RemoveSpaces(string s)
    {
        string temp = "";
        int i;

        Console.WriteLine("Удаление пробелов.");

        for (i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
            {
                temp += s[i];
            }
        }

        return temp;
    }

    //Обратить строку
    static string Reverse(string s)
    {
        string temp = "";
        int i;

        Console.WriteLine("Обращение строки.");
        for (i = s.Length - 1; i >= 0; i--)
        {
            temp += s[i];
        }

        return temp;
    }

    static void Main()
    {
        //Сконструировать делегат
        StrMod strOp = new StrMod(ReplaceSpaces);
        string str;

        //Вызвать методы с помощью делегата.
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        strOp = new StrMod(RemoveSpaces);
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        strOp = new StrMod(Reverse);
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);

        Console.ReadKey();

    }
}

/*

Вот к какому результату приводит выполнение этого кода.

Замена пробелов дефисами.
Результирующая строка: Это-простой-тест.

Удаление пробелов.
Результирующая строка: Этопростойтест.

Обращение строки.
Результирующая строка: .тсет йотсорп отЭ

Рассмотрим данный пример более подробно. В его коде сначала объявляется делегат
StrMod типа string, как показано ниже.

delegate string StrMod(string str);

Как видите, делегат StrMod принимает один параметр типа string и возвращает
одно значение того же типа.

Далее в классе DelegateTest объявляются три статических метода с одним параметром
типа string и возвращаемым значением того же типа. Следовательно, они соответствуют
делегату StrMod. Эти методы видоизменяют строку в той или иной форме.
Обратите внимание на то, что в методе ReplaceSpaces() для замены пробелов
дефисами используется один из методов типа string — Replace().

В методе Main() создается переменная экземпляра strOp ссылочного типа StrMod
и затем ей присваивается ссылка на метод ReplaceSpaces(). Обратите особое внимание
на следующую строку кода.

StrMod strOp = new StrMod(ReplaceSpaces);

В этой строке метод ReplaceSpaces() передается в качестве параметра. При этом
указывается только его имя, но не параметры. Данный пример можно обобщить: при
получении экземпляра делегата достаточно указать только имя метода, на который
должен ссылаться делегат. Ясно, что сигнатура метода должна совпадать с той, что
указана в объявлении делегата. В противном случае во время компиляции возникнет
ошибка.

Далее метод ReplaceSpaces() вызывается с помощью экземпляра делегата strOp,
как показано ниже.

str = strOp("Это простой тест.");

Экземпляр делегата strOp ссылается на метод ReplaceSpaces(), и поэтому вызывается
именно этот метод.

Затем экземпляру делегата strOp присваивается ссылка на метод RemoveSpaces(),
и с его помощью вновь вызывается указанный метод — на этот раз RemoveSpaces().

И наконец, экземпляру делегата strOp присваивается ссылка на метод Reverse().
А в итоге вызывается именно этот метод.

Главный вывод из данного примера заключается в следующем: в тот момент, когда
происходит обращение к экземпляру делегата strOp, вызывается метод, на который
он ссылается. Следовательно, вызов метода разрешается во время выполнения, а не в
процессе компиляции.

*/

#endregion

#region English

/*

15 CHAPTER

Delegates, Events, and Lambda Expressions

This chapter examines three innovative C# features: delegates, events, and lambda
expressions. A delegate provides a way to encapsulate a method. An event is a
notification that some action has occurred. Delegates and events are related because
an event is built upon a delegate. Both expand the set of programming tasks to which C#
can be applied. The lambda expression is a relatively new syntactic feature that offers a
streamlined, yet powerful way to define what is, essentially, a unit of executable code.
Lambda expressions are often used when working with delegates and events because a
delegate can refer to a lambda expression. (Lambda expressions are also very important to
LINQ, which is described in Chapter 19.) Also examined are anonymous methods, covariance,
contravariance, and method group conversions.

Delegates

Let’s begin by defining the term delegate. In straightforward language, a delegate is an object
that can refer to a method. Therefore, when you create a delegate, you are creating an object
that can hold a reference to a method. Furthermore, the method can be called through this
reference. In other words, a delegate can invoke the method to which it refers. As you will
see, this is a very powerful concept.

It is important to understand that the same delegate can be used to call different
methods during the runtime of a program by simply changing the method to which the
delegate refers. Thus, the method that will be invoked by a delegate is not determined at
compile time, but rather at runtime. This is the principal advantage of a delegate.

NOTE
If you are familiar with C/C++, then it will help to know that a delegate in C# is similar to a
function pointer in C/C++.

A delegate type is declared using the keyword delegate. The general form of a delegate
declaration is shown here:

delegate ret-type name(parameter-list);

Here, ret-type is the type of value returned by the methods that the delegate will be calling.
The name of the delegate is specified by name. The parameters required by the methods
called through the delegate are specified in the parameter-list. Once created, a delegate
instance can refer to and call methods whose return type and parameter list match those
specified by the delegate declaration.

A key point to understand is that a delegate can be used to call any method that agrees
with its signature and return type. Furthermore, the method can be either an instance method
associated with an object or a static method associated with a class. All that matters is that
the return type and signature of the method agree with those of the delegate.
To see delegates in action, let’s begin with the simple example shown here:

*/

// A simple delegate example.

//using System; 

//// Declare a delegate type.  
//delegate string StrMod(string str);

//class DelegateTest
//{
//    // Replaces spaces with hyphens. 
//    static string ReplaceSpaces(string s)
//    {
//        Console.WriteLine("Replacing spaces with hyphens.");
//        return s.Replace(' ', '-');
//    }

//    // Remove spaces. 
//    static string RemoveSpaces(string s)
//    {
//        string temp = "";
//        int i;

//        Console.WriteLine("Removing spaces.");
//        for (i = 0; i < s.Length; i++)
//            if (s[i] != ' ') temp += s[i];

//        return temp;
//    }

//    // Reverse a string. 
//    static string Reverse(string s)
//    {
//        string temp = "";
//        int i, j;

//        Console.WriteLine("Reversing string.");
//        for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
//            temp += s[i];

//        return temp;
//    }

//    static void Main()
//    {
//        // Construct a delegate. 
//        StrMod strOp = new StrMod(ReplaceSpaces);
//        string str;

//        // Call methods through the delegate. 
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        strOp = new StrMod(RemoveSpaces);
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        strOp = new StrMod(Reverse);
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);

//        Console.ReadKey();
//    }
//}

/*

The output from the program is shown here:

Replacing spaces with hyphens.
Resulting string: This-is-a-test.

Removing spaces.
Resulting string: Thisisatest.

Reversing string.
Resulting string: .tset a si sihT

Let’s examine this program closely. The program declares a delegate type called
StrMod, shown here:

delegate string StrMod(string str);

Notice that StrMod takes one string parameter and returns a string.

Next, in DelegateTest, three static methods are declared, each with a single parameter
of type string and a return type of string. Thus, they match the StrMod delegate. These
methods perform some type of string modification. Notice that ReplaceSpaces( ) uses one
of string’s methods, called Replace( ), to replace spaces with hyphens.

In Main(), a StrMod reference called strOp is created and assigned a reference to
ReplaceSpaces(). Pay close attention to this line:

StrMod strOp = new StrMod(ReplaceSpaces);

Notice how the method ReplaceSpaces() is passed as a parameter. Only its name is used;
no parameters are specified. This can be generalized. When instantiating a delegate, you
specify only the name of the method to which you want the delegate to refer. Of course, the
method’s signature must match that of the delegate’s declaration. If it doesn’t, a compiletime
error will result.

Next, ReplaceSpaces() is called through the delegate instance strOp, as shown here:

str = strOp("This is a test.");

Because strOp refers to ReplaceSpaces(), ReplaceSpaces() is invoked.

Next, strOp is assigned a reference to RemoveSpaces(), and then strOp is called again.
This time, RemoveSpaces() is invoked.

Finally, strOp is assigned a reference to Reverse() and strOp is called. This results in
Reverse() being called.

The key point of the example is that the invocation of strOp results in a call to the method
referred to by strOp at the time at which the invocation occurs. Thus, the method to call is
resolved at runtime, not compile time.

*/

#endregion