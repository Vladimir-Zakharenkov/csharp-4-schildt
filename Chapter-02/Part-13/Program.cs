#region Russian

/*

Два управляющих оператора

Выполнение программы внутри метода (т.е. в его теле) происходит последовательно
от одного оператора к другому, т.е. по цепочке сверху вниз. Этот порядок выполнения
программы можно изменить с помощью различных управляющих операторов,
поддерживаемых в С#. Более подробно управляющие операторы будут рассмотрены
в дальнейшем, а здесь они представлены вкратце, поскольку используются в последующих
примерах программ.

Условный оператор

С помощью условного оператора if в C# можно организовать выборочное выполнение
части программы. Оператор if действует в C# практически так же, как и оператор
IF в любом другом языке программирования. В частности, с точки зрения синтаксиса 
он тождествен операторам if в С, C++ и Java. Ниже приведена простейшая форма
этого оператора.

if(условие) оператор;

Здесь условие представляет собой булево, т.е. логическое, выражение, принимающее
одно из двух значений: "истина" или "ложь". Если условие истинно, то оператор
выполняется. А если условие ложно, то выполнение программы происходит, минуя
оператор. Ниже приведен пример применения условного оператора.

if(10 < 11) Console.WriteLine("10 меньше 11");

В данном примере условное выражение принимает истинное значение, поскольку
10 меньше 11, и поэтому метод WriteLine() выполняется. А теперь рассмотрим другой
пример.

if(10 < 9) Console.WriteLine("не подлежит выводу");

В данном примере 10 не меньше 9. Следовательно, вызов метода WriteLine() не
произойдет.

В C# определен полный набор операторов отношения, которые можно использовать
в условных выражениях. Ниже перечислены все эти операторы и их обозначения.

Операция    Значение
<           Меньше
<=          Меньше или равно
>           Больше
>=          Больше или равно
==          Равно
!=          Не равно

Далее следует пример еще одной программы, демонстрирующей применение
условного оператора if.

*/

// Продемонстрировать применение условного оператора if.

using System;

class IfDemo
{
    static void Main()
    {
        int a, b, c;

        a = 2;
        b = 3;

        if (a < b)
        {
            Console.WriteLine("a меньше b");
        }

        // Не подлежит выводу.
        if (a == b)
        {
            Console.WriteLine("Этого никто не увидит");
        }

        Console.WriteLine();

        c = a - b; // c содержит -1

        Console.WriteLine("с содержит -1");

        if (c >= 0)
        {
            Console.WriteLine("значение c неотрицательно");
        }

        if (c < 0)
        {
            Console.WriteLine("значение c отрицательно");
        }

        Console.WriteLine();

        c = b - a; // теперь содержит 1

        Console.WriteLine("c содержит 1");

        if (c >= 0)
        {
            Console.WriteLine("значение c неотрицательно");
        }

        if (c < 0)
        {
            Console.WriteLine("значение с отрицательно");
        }
    }
}

/*

Вот к какому результату приводит выполнение данной программы.

а меньше b

с содержит -1
значение с отрицательно

с содержит 1
значение с неотрицательно

Обратите внимание на еще одну особенность этой программы. В строке

int а, b, с;

три переменные, а, b и с, объявляются списком, разделяемым запятыми. Как упоминалось
выше, если требуется объявить две или более переменные одного и того же
типа, это можно сделать в одном операторе, разделив их имена запятыми.

*/

#endregion

#region English

/*

Two Control Statements

Inside a method, execution proceeds from one statement to the next, top to bottom. It
is possible to alter this flow through the use of the various program control statements
supported by C#. Although we will look closely at control statements later, two are briefly
introduced here because we will be using them to write sample programs.

The if Statement

You can selectively execute part of a program through the use of C#’s conditional statement:
the if. The if statement works in C# much like the IF statement in any other language. For
example, it is syntactically identical to the if statements in C, C++, and Java. Its simplest
form is shown here:

if(condition) statement;

Here, condition is a Boolean (that is, true or false) expression. If condition is true, then the
statement is executed. If condition is false, then the statement is bypassed. Here is an
example:

if(10 < 11) Console.WriteLine("10 is less than 11");

In this case, since 10 is less than 11, the conditional expression is true, and WriteLine() will
execute. However, consider the following:

if(10 < 9) Console.WriteLine("this won’t be displayed");

In this case, 10 is not less than 9. Thus, the call to WriteLine() will not take place.

C# defines a full complement of relational operators that can be used in a conditional
expression. They are shown here:

Operator    Meaning
<           Less than
<=          Less than or equal to
>           Greater than
>=          Greater than or equal to
==         Equal to
!=          Not equal

Here is a program that illustrates the if statement:

*/

// Demonstrate the if.

//using System;

//class IfDemo
//{
//    static void Main()
//    {
//        int a, b, c;

//        a = 2;
//        b = 3;

//        if (a < b) Console.WriteLine("a is less than b");

//        // This won’t display anything.
//        if (a == b) Console.WriteLine("you won’t see this");

//        Console.WriteLine();

//        c = a - b; // c contains -1

//        Console.WriteLine("c contains -1");

//        if (c >= 0) Console.WriteLine("c is non-negative");

//        if (c < 0) Console.WriteLine("c is negative");

//        Console.WriteLine();

//        c = b - a; // c now contains 1

//        Console.WriteLine("c contains 1");

//        if (c >= 0) Console.WriteLine("c is non-negative");

//        if (c < 0) Console.WriteLine("c is negative");
//    }
//}

/*

The output generated by this program is shown here:

a is less than b

c contains -1
c is negative

c contains 1
c is non-negative

Notice one other thing in this program. The line

int a, b, c;

declares three variables, a, b, and c, by use of a comma-separated list. As mentioned earlier,
when you need two or more variables of the same type, they can be declared in one statement.
Just separate the variable names with commas.

*/

#endregion