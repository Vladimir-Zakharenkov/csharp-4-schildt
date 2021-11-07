#region Russian

/*

Вторая простая программа

В языке программирования, вероятно, нет более важной конструкции, чем переменная.
Переменная — это именованная область памяти, для которой может быть установлено
значение. Она называется переменной потому, что ее значение может быть
изменено по ходу выполнения программы. Иными словами, содержимое переменной
подлежит изменению и не является постоянным.

В приведенной ниже программе создаются две переменные — х и у.

*/

// Эта программа демонстрирует применение переменных.

using System;

class Example2
{
    static void Main()
    {
        int x; // здесь объявляется переменная
        int y; // здесь объявляется еще одна переменная

        x = 100; // здесь переменной x присваивается значение 100

        Console.WriteLine("x содержит " + x);

        y = x / 2;

        Console.Write("y содержит x / 2: ");
        Console.WriteLine(y);
    }
}

/*

Выполнение этой программы дает следующий результат.

х содержит 100
у содержит х / 2: 50

В этой программе вводится ряд новых понятий. Прежде всего, в операторе

int х; // здесь объявляется переменная

объявляется переменная целочисленного типа с именем х. В C# все переменные должны
объявляться до их применения. Кроме того, нужно обязательно указать тип значения,
которое будет храниться в переменной. Это так называемый тип переменной.
В данном примере в переменной х хранится целочисленное значение, т.е. целое число.
Для объявления в C# переменной целочисленного типа перед ее именем указывается
ключевое слово int. Таким образом, в приведенном выше операторе объявляется
переменная х типа int.

В следующей строке объявляется вторая переменная с именем у.

int у; // здесь объявляется еще одна переменная

Как видите, эта переменная объявляется таким же образом, как и предыдущая,
за исключением того, что ей присваивается другое имя.

В целом, для объявления переменной служит следующий оператор:

тип имя_переменной;

где тип — это конкретный тип объявляемой переменной, а имя_переменной — имя
самой переменной. Помимо типа int, в C# поддерживается ряд других типов данных.

В следующей строке программы переменной х присваивается значение 100.

х = 100; // здесь переменной х присваивается значение 100

В C# оператор присваивания обозначается одиночным знаком равенства (=).
Данный оператор выполняет копирование значения, расположенного справа от знака
равенства, в переменную, находящуюся слева от него.

В следующей строке программы осуществляется вывод на экран текстовой строки
"х содержит " и значения переменной х.

Console.WriteLine("х содержит " + х);

В этом операторе знак + обозначает, что значение переменной х выводится вслед
за предшествующей ему текстовой строкой. Если обобщить этот частный случай, то
с помощью знака операции + можно организовать сцепление какого угодно числа элементов
в одном операторе с вызовом метода WriteLine().

В следующей строке программы переменной у присваивается значение переменной
х, деленное на 2.

у = х / 2;

В этой строке значение переменной х делится на 2, а полученный результат сохраняется
в переменной у. Таким образом, после выполнения данной строки в переменной
у содержится значение 50. При этом значение переменной х не меняется. Как
и в большинстве других языков программирования, в C# поддерживаются все арифметические
операции, в том числе и перечисленные ниже.

+   Сложение
-   Вычитание
*   Умножение
/   Деление

Рассмотрим две оставшиеся строки программы.

Console.Write("у содержит х / 2: ");
Console.WriteLine(у);

В этих строках обнаруживаются еще две особенности. Во-первых, для вывода текстовой
строки "у содержит х / 2: " на экран используется встроенный метод Write().
После этой текстовой строки новая строка не следует. Это означает, что
последующий вывод будет осуществлен в той же самой строке. Метод Write() подобен
методу WriteLine(), за исключением того, что после каждого его вызова вывод
не начинается с новой строки. И во-вторых, обратите внимание на то, что в вызове
метода WriteLine() указывается только переменная у. Оба метода, Write()
и WriteLine(), могут быть использованы для вывода значений любых встроенных в
C# типов.

Прежде чем двигаться дальше, следует упомянуть еще об одной особенности объявления
переменных. Две иди более переменных можно указать в одном операторе
объявления. Нужно лишь разделить их запятой. Например, переменные х и у могут
быть объявлены следующим образом.

int х, у; // обе переменные объявляются в одном операторе

ПРИМЕЧАНИЕ
В C# внедрено средство, называемое неявно типизированной переменной. Неявно
типизированными являются такие переменные, тип которых автоматически определяется
компилятором. Подробнее неявно типизированные переменные рассматриваются в главе 3.

*/

#endregion

#region English

/*

A Second Simple Program

Perhaps no other construct is as important to a programming language as the variable. A
variable is a named memory location that can be assigned a value. It is called a variable
because its value can be changed during the execution of a program. In other words, the
content of a variable is changeable, not fixed.

The following program creates two variables called x and y.

*/

// This program demonstrates variables.
//using System;
//class Example2
//{
//    static void Main()
//    {
//        int x; // this declares a variable
//        int y; // this declares another variable
//        x = 100; // this assigns 100 to x
//        Console.WriteLine("x contains " + x);

//        y = x / 2;
//        Console.Write("y contains x / 2: ");
//        Console.WriteLine(y);
//    }
//}

/*

When you run this program, you will see the following output:

x contains 100
y contains x / 2: 50

This program introduces several new concepts. First, the statement

int x; // this declares a variable

declares a variable called x of type integer. In C#, all variables must be declared before they
are used. Further, the kind of values that the variable can hold must also be specified. This
is called the type of the variable. In this case, x can hold integer values. These are whole
numbers. In C#, to declare a variable to be of type integer, precede its name with the
keyword int. Thus, the preceding statement declares a variable called x of type int.

The next line declares a second variable called y.

int y; // this declares another variable

Notice that it uses the same format as the first except that the name of the variable is
different.

In general, to declare a variable, you will use a statement like this:

type var-name;

Here, type specifies the type of variable being declared, and var-name is the name of the
variable. In addition to int, C# supports several other data types.

The following line of code assigns x the value 100:

x = 100; // this assigns 100 to x

In C#, the assignment operator is the single equal sign. It copies the value on its right side
into the variable on its left.

The next line of code outputs the value of x preceded by the string “x contains ”.

Console.WriteLine("x contains " + x);

In this statement, the plus sign causes the value of x to be displayed after the string that
precedes it. This approach can be generalized. Using the + operator, you can chain together
as many items as you want within a single WriteLine( ) statement.

The next line of code assigns y the value of x divided by 2:

y = x / 2;

This line divides the value in x by 2 and then stores that result in y. Thus, after the line
executes, y will contain the value 50. The value of x will be unchanged. Like most other
computer languages, C# supports a full range of arithmetic operators, including those
shown here:

+   Addition
–   Subtraction
*   Multiplication
/   Division

Here are the next two lines in the program:

Console.Write("y contains x / 2: ");
Console.WriteLine(y);

Two new things are occurring here. First, the built-in method Write( ) is used to display the
string “y contains x / 2: ”. This string is not followed by a new line. This means that when
the next output is generated, it will start on the same line. The Write( ) method is just like
WriteLine( ), except that it does not output a new line after each call. Second, in the call
toWriteLine( ), notice that y is used by itself. Both Write( ) and WriteLine( ) can be used to
output values of any of C#’s built-in types.

One more point about declaring variables before we move on: It is possible to declare
two or more variables using the same declaration statement. Just separate their names by
commas. For example, x and y could have been declared like this:

int x, y; // both declared using one statement

NOTE
C# includes a feature called an implicitly typed variable. Implicitly typed variables are
variables whose type is automatically determined by the compiler. Implicitly typed variables
are discussed in Chapter 3.

*/

#endregion