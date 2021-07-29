#region Russian

/*

Лямбда-выражения

Несмотря на всю ценность анонимных методов, им на смену пришел более совершенный
подход: лямбда-выражение. Не будет преувеличением сказать, что лямбда-выражение 
относится к одним из самых важных нововведений в С#, начиная с выпуска
исходной версии 1.0 этого языка программирования. Лямбда-выражение основывается
на совершенно новом синтаксическом элементе и служит более эффективной альтернативой
анонимному методу. И хотя лямбда-выражения находят применение главным
образом в работе с LINQ (подробнее об этом — в главе 19), они часто используются
и вместе с делегатами и событиями. Именно об этом применении лямбда-выражений
и пойдет речь в данном разделе.

Лямбда-выражение — это другой собой создания анонимной функции. (Первый
ее способ, анонимный метод, был рассмотрен в предыдущем разделе.) Следовательно,
лямбда-выражение может быть присвоено делегату. А поскольку лямбда-выражение
считается более эффективным, чем эквивалентный ему анонимный метод то в большинстве
случаев рекомендуется отдавать предпочтение именно ему.

Лямбда-оператор

Во всех лямбда-выражениях применяется новый лямбда-оператор =>, который разделяет
лямбда-выражение на две части. В левой его части указывается входной параметр
(или несколько параметров), а в правой части — тело лямбда-выражения. Оператор
=> иногда описывается такими словами, как "переходит" или "становится".

В C# поддерживаются две разновидности лямбда-выражений в зависимости от тела
самого лямбда-выражения. Так, если тело лямбда-выражения состоит из одного выражения,
то образуется одиночное лямбда-выражение. В этом случае тело выражения не
заключается в фигурные скобки. Если же тело лямбда-выражения состоит из блока
операторов, заключенных в фигурные скобки, то образуется блочное лямбда-выражение.
При этом блочное лямбда-выражение может содержать целый ряд операторов, в том
числе циклы, вызовы методов и условные операторы if. Обе разновидности лямбда-
выражений рассматриваются далее по отдельности.

Одиночные лямбда-выражения

В одиночном лямбда-выражении часть, находящаяся справа от оператора =>, воздействует
на параметр (или ряд параметров), указываемый слева. Возвращаемым
результатом вычисления такого выражения является результат выполнения лямбда-
оператора.

Ниже приведена общая форма одиночного лямбда-выражения, принимающего
единственный параметр.

параметр => выражение

Если же требуется указать несколько параметров, то используется следующая форма.

(список_параметров) => выражение

Таким образом, когда требуется указать два параметра или более, их следует заключить
в скобки. Если же выражение не требует параметров, то следует использовать
пустые скобки.

Ниже приведен простой пример одиночного лямбда-выражения.

count => count + 2

В этом выражении count служит параметром, на который воздействует выражение
count + 2. В итоге значение параметра count увеличивается на 2. А вот еще один
пример одиночного лямбда-выражения.

n => n % 2 == 0

В данном случае выражение возвращает логическое значение true, если числовое
значение параметра n оказывается четным, а иначе — логическое значение false.

Лямбда-выражение применяется в два этапа. Сначала объявляется тип делегата, совместимый
с лямбда-выражением, а затем экземпляр делегата, которому присваивается
лямбда-выражение. После этого лямбда-выражение вычисляется при обращении к
экземпляру делегата. Результатом его вычисления становится возвращаемое значение.

В приведенном ниже примере программы демонстрируется применение двух одиночных
лямбда-выражений. Сначала в этой программе объявляются два типа делегатов.
Первый из них, Incr, принимает аргумент типа int и возвращает результат того
же типа. Второй делегат, IsEven, также принимает аргумент типа int, но возвращает
результат типа bool. Затем экземплярам этих делегатов присваиваются одиночные
лямбда-выражения. И наконец, лямбда-выражения вычисляются с помощью соответствующих
экземпляров делегатов.

*/

// Применить два одиночных лямбда-выражения.

using System;

// Объявить делегат, принимающий аргумент типа int и возвращающий результат типа int.
delegate int Incr(int v);

// Объявить делегат, принимающий аргумент типа int и возвращающий результат типа bool.
delegate bool IsEven(int v);

class SimpleLambdaDemo
{
    static void Main()
    {
        // Создать делегат Incr, ссылающийся на лямбда-выражение, увеличивающее свой параметр на 2.
        Incr incr = count => count + 2;

        // А теперь использовать лямбда-выражение incr.
        Console.WriteLine("Использовать лямбда-выражение incr: ");
        int x = -10;
        while (x <= 0)
        {
            Console.Write(x + " ");
            x = incr(x); // увеличить значение x на 2
        }

        Console.WriteLine("\n");

        // Создать экземпляр делегата IsEven, ссылающийся на лямбда-выражение,
        // возвращающее логическое значение true, если его параметр имеет четное
        // значение, а иначе — логическое значение false.
        IsEven isEven = n => n % 2 == 0;

        // А теперь использовать лямбда-выражение isEven.
        Console.WriteLine("Использовать лямбда-выражение isEven: ");
        for (int i = 0; i < 10; i++)
        {
            if (isEven(i))
            {
                Console.WriteLine(i + " четное");
            }
        }

        Console.ReadKey();
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

Использование лямбда-выражения incr:
-10 -8 -6 -4 -2 0

Использование лямбда-выражения isEven:
2 четное.
4 четное.
6 четное.
8 четное.
10 четное.

Обратите в данной программе особое внимание на следующие строки объявлений.

Incr incr = count => count + 2;
IsEven isEven = n => n % 2 == 0;

В первой строке объявления экземпляру делегата incr присваивается одиночное
лямбда-выражение, возвращающее результат увеличения на 2 значения параметра
count. Это выражение может быть присвоено делегату Incr, поскольку оно совместимо
с объявлением данного делегата. Аргумент, указываемый при обращении к экземпляру
делегата incr, передается параметру count, который и возвращает результат
вычисления лямбда-выражения. Во второй строке объявления делегату isEven присваивается
выражение, возвращающее логическое значение true, если передаваемый
ему аргумент оказывается четным, а иначе — логическое значение false. Следовательно,
это лямбда-выражение совместимо с объявлением делегата IsEven.

В связи со всем изложенным выше возникает резонный вопрос: каким образом
компилятору становится известно о типе данных, используемых в лямбда-выражении, 
например, о типе int параметра count в лямбда-выражении, присваиваемом
экземпляру делегата incr? Ответить на этот вопрос можно так: компилятор
делает заключение о типе параметра и типе результата вычисления выражения
по типу делегата. Следовательно, параметры и возвращаемое значение лямбда-
выражения должны быть совместимы по типу с параметрами и возвращаемым значением
делегата.

Несмотря на всю полезность логического заключения о типе данных, в некоторых
случаях приходится явно указывать тип параметра лямбда-выражения. Для этого достаточно
ввести конкретное название типа данных. В качестве примера ниже приведен
другой способ объявления экземпляра делегата incr.

Incr incr = (int count) => count + 2;

Как видите, count теперь явно объявлен как параметр типа int. Обратите также
внимание на использование скобок. Теперь они необходимы. (Скобки могут быть опущены
только в том случае, если задается лишь один параметр, а его тип явно не указывается.)

В предыдущем примере в обоих лямбда-выражениях использовался единственный
параметр, но в целом у лямбда-выражений может быть любое количество параметров,
в том числе и нулевое. Если в лямбда-выражении используется несколько параметров,
их необходимо заключить в скобки. Ниже приведен пример использования лямбда-
выражения с целью определить, находится ли значение в заданных пределах.

(low, high, val) => val >= low && val <= high;

А вот как объявляется тип делегата, совместимого с этим лямбда-выражением.

delegate bool InRange(int lower, int upper, int v);

Следовательно, экземпляр делегата InRange может быть создан следующим образом.

InRange rangeOK = (low, high, val) => val >= low && val <= high;

После этого одиночное лямбда-выражение может быть выполнено так, как показано
ниже.

if(rangeOK(1, 5, 3)) Console.WriteLine("Число 3 находится в пределах от 1 до 5.");

И последнее замечание: внешние переменные могут использоваться и захватываться
в лямбда-выражениях таким же образом, как и в анонимных методах.

*/

#endregion

#region English

/*

Lambda Expressions

Although anonymous methods are still part of C#, they have been largely superceded
by a better approach: the lambda expression. It is not an overstatement to say that the lambda
expression is one of the most important features added to C# since its original 1.0 release.
Based on a distinctive syntactic element, the lambda expression provides a powerful
alternative to the anonymous method. Although a principal use of lambda expressions is
found when working with LINQ (see Chapter 19), they are also applicable to (and commonly
used with) delegates and events. This use of lambda expressions is described here.

A lambda expression is the second way that an anonymous function can be created.
(The other type of anonymous function is the anonymous method, described in the
preceding section.) Thus, a lambda expression can be assigned to a delegate. Because a
lambda expression is more streamlined than the equivalent anonymous method, lambda
expressions are now the recommended approach in almost all cases.

The Lambda Operator

All lambda expressions use the lambda operator, which is =>. This operator divides
a lambda expression into two parts. On the left the input parameter (or parameters) is
specified. On the right is the lambda body. The => operator is sometimes verbalized as
“goes to” or “becomes.”

C# supports two types of lambda expressions, and it is the lambda body that determines
what type is being created. If the lambda body consists of a single expression, then an
expression lambda is being created. In this case, the body is free-standing—it is not enclosed
between braces. If the lambda body consists of a block of statements enclosed by braces,
then a statement lambda is being created. A statement lambda can contain multiple statements
and include such things as loops, method calls, and if statements. The following sections
describe both kinds of lambdas.

Expression Lambdas

In an expression lambda, the expression on the right side of the => acts on the parameter (or
parameters) specified by the left side. The result of the expression becomes the result of the
lambda operator and is returned.

Here is the general form of an expression lambda that takes only one parameter:

param => expr

When more than one parameter is required, then the following form is used:

(param-list) => expr

Therefore, when two or more parameters are needed, they must be enclosed by parentheses.
If no parameters are needed, then empty parentheses must be used.

Here is a simple expression lambda:

count => count + 2

Here count is the parameter that is acted on by the expression count + 2. Thus, the result is
the value of count increased by two. Here is another example:

n => n % 2 == 0

In this case, this expression returns true if n is even and false if it is odd.

To use a lambda expression involves two steps. First, declare a delegate type that
is compatible with the lambda expression. Second, declare an instance of the delegate,
assigning to it the lambda expression. Once this has been done, the lambda expression can
be executed by calling the delegate instance. The result of the lambda expression becomes
the return value.

The following program shows how to put the two expression lambdas just shown into
action. It declares two delegate types. The first, called Incr, takes an int argument and
returns an int result. The second, called IsEven, takes an int argument and returns a bool
result. It then assigns the lambda expressions to instances of those delegates. Finally, it
executes the lambda expressions through the delegate instances.

*/

// Use two simple lambda expressions. 

//using System;  

//// Declare a delegate that takes an int argument 
//// and returns an int result. 
//delegate int Incr(int v);

//// Declare a delegate that takes an int argument  
//// and returns a bool result. 
//delegate bool IsEven(int v);

//class SimpleLambdaDemo
//{

//    static void Main()
//    {

//        // Create an Incr delegate instance that refers to  
//        // a lambda expression that increases its parameter by 2. 
//        Incr incr = count => count + 2;

//        // Now, use the incr lambda expression. 
//        Console.WriteLine("Use incr lambda expression: ");
//        int x = -10;
//        while (x <= 0)
//        {
//            Console.Write(x + " ");
//            x = incr(x); // increase x by 2 
//        }

//        Console.WriteLine("\n");

//        // Create a IsEven delegate instance that refers to  
//        // a lambda expression that returns true if its parameter 
//        // is even and false otherwise. 
//        IsEven isEven = n => n % 2 == 0;

//        // Now, use the isEven lambda expression 
//        Console.WriteLine("Use isEven lambda expression: ");
//        for (int i = 1; i <= 10; i++)
//            if (isEven(i)) Console.WriteLine(i + " is even.");

//        Console.ReadKey();
//    }
//}


/*

The output is shown here:

Use incr lambda expression:
-10 -8 -6 -4 -2 0

Use isEven lambda expression:
2 is even.
4 is even.
6 is even.
8 is even.
10 is even.

In the program, pay special attention to these declarations:

Incr incr = count => count + 2;
IsEven isEven = n => n % 2 == 0;

The first assigns to incr a lambda expression that returns the result of increasing the value
passed to count by 2. This expression can be assigned to an Incr delegate because it is
compatible with Incr’s declaration. The argument used in the call to incr is passed to count.
The result is returned. The second declaration assigns to isEven an expression that returns
true if the argument is even and false otherwise. Thus, it is compatible with the IsEven
delegate declaration.

At this point, you might be wondering how the compiler knows the type of the data
used in a lambda expression. For example, in the lambda expression assigned to incr, how
does the compiler know that count is an int? The answer is that the compiler infers the type
of the parameter and the expression’s result type from the delegate type. Thus, the lambda
parameters and return value must be compatible with the parameter type(s) and return type
of the delegate.

Although type inference is quite useful, in some cases, you might need to explicitly
specify the type of a lambda parameter. To do so, simply include the type name. For
example, here is another way to declare the incr delegate instance:

Incr incr = (int count) => count + 2;

Notice now that count is explicitly declared as an int. Also notice the use of parentheses.
They are now necessary. (Parentheses can be omitted only when exactly one parameter is
specified and no type specifier is used.)

Although the preceding two lambda expressions each used one parameter, lambda
expressions can use any number, including zero. When using more than one parameter you
must enclose them within parentheses. Here is an example that uses a lambda expression to
determine if a value is within a specified range:

(low, high, val) => val >= low && val <= high;

Here is a delegate type that is compatible with this lambda expression:

delegate bool InRange(int lower, int upper, int v);

Thus, you could create an InRange delegate instance like this:

InRange rangeOK = (low, high, val) => val >= low && val <= high;

After doing so, the lambda expression can be executed as shown here:

if(rangeOK(1, 5, 3)) Console.WriteLine("3 is within 1 to 5.");

One other point: Lambda expressions can use outer variables in the same way as
anonymous methods, and they are captured in the same way.

*/

#endregion