#region Russian

/*

Область действия и время существования переменных

Все переменные, использовавшиеся в предыдущих примерах программ, объявлялись
в самом начале метода Main(). Но в C# локальную переменную разрешается
объявлять в любом кодовом блоке. Как пояснялось в главе 2, кодовый блок начинается
открывающей фигурной скобкой и оканчивается закрывающей фигурной скобкой.
Этот блок и определяет область действия. Следовательно, всякий раз, когда начинается
блок, образуется новая область действия. Прежде всего область действия определяет
видимость имен отдельных элементов, в том числе и переменных, в других частях программы
без дополнительного уточнения. Она определяет также время существования
локальных переменных.

В C# к числу наиболее важных относятся области действия, определяемые классом
и методом. Рассмотрение области действия класса (и объявляемых в ней переменных)
придется отложить до того момента, когда в этой книге будут описываться классы.
А до тех пор будут рассматриваться только те области действия, которые определяются
методом или же в самом методе.

Область действия, определяемая методом, начинается открывающей фигурной
скобкой и оканчивается закрывающей фигурной скобкой. Но если у этого метода имеются
параметры, то и они входят в область действия, определяемую данным методом.

Как правило, локальные переменные объявляются в области действия, невидимой
для кода, находящегося вне этой области. Поэтому, объявляя переменную в определенной
области действия, вы тем самым защищаете ее от доступа или видоизменения
вне данной области. Разумеется, правила области действия служат основанием для инкапсуляции.
Области действия могут быть вложенными. Например, всякий раз, когда создается
кодовый блок, одновременно образуется и новая, вложенная область действия. В этом
случае внешняя область действия охватывает внутреннюю область. Это означает, что
локальные переменные, объявленные во внешней области действия, будут видимы для
кода во внутренней области действия. Но обратное не справедливо: локальные переменные,
объявленные во внутренней области действия, не будут видимы вне этой области.

Для того чтобы стала более понятной сущность вложенных областей действия, рассмотрим
следующий пример программы.

*/

// Продемонстрировать область действия кодового блока.
using System;
class ScopeDemo
{
    static void Main()
    {
        int x; // Эта переменная доступна для всего кода внутри метода Main().

        x = 10;

        if (x == 10)
        { // начать новую область действия
            int у = 20; // Эта переменная доступна только в данном кодовом блоке.
                        // Здесь доступны обе переменные, х и у.

            Console.WriteLine("х и у: " + x + " " + у);

            x = у * 2;
        }

        // у = 100; // Ошибка! Переменная здесь недоступна.

        // А переменная х здесь по-прежнему доступна.
        Console.WriteLine("х равно " + x);
    }
}

/*

Как поясняется в комментариях к приведенной выше программе, переменная х
объявляется в начале области действия метода Main(), и поэтому она доступна для
всего последующего кода в пределах этого метода. В блоке условного оператора if
объявляется переменная у. А поскольку этот кодовый блок определяет свою собственную
область действия, то переменная у видима только для кода в пределах данного
блока. Именно поэтому строка line у = 100;, находящаяся за пределами этого
блока, закомментирована. Если удалить находящиеся перед ней символы комментария
(//), то во время компиляции программы произойдет ошибка, поскольку переменная
у невидима за пределами своего кодового блока. В то же время переменная х
может использоваться в блоке условного оператора if, поскольку коду из этого блока,
находящемуся во вложенной области действия, доступны переменные, объявленные
в охватывающей его внешней области действия.

*/

#endregion

#region English

/*

The Scope and Lifetime of Variables

So far, all of the variables that we have been using are declared at the start of the Main()
method. However, C# allows a local variable to be declared within any block. As explained
in Chapter 1, a block begins with an opening curly brace and ends with a closing curly
brace. A block defines a scope. Thus, each time you start a new block, you are creating a new
scope. A scope determines what names are visible to other parts of your program without
qualification. It also determines the lifetime of local variables.

The most important scopes in C# are those defined by a class and those defined by a
method. A discussion of class scope (and variables declared within it) is deferred until later
in this book, when classes are described. For now, we will examine only the scopes defined
by or within a method.

The scope defined by a method begins with its opening curly brace and ends with its
closing curly brace. However, if that method has parameters, they too are included within
the scope defined by the method.

As a general rule, local variables declared inside a scope are not visible to code that
is defined outside that scope. Thus, when you declare a variable within a scope, you are
protecting it from access or modification from outside the scope. Indeed, the scope rules
provide the foundation for encapsulation.

Scopes can be nested. For example, each time you create a block of code, you are creating
a new, nested scope. When this occurs, the outer scope encloses the inner scope. This means
that local variables declared in the outer scope will be visible to code within the inner scope.However, the reverse is not true. Local variables declared within the inner scope will not be
visible outside it.

To understand the effect of nested scopes, consider the following program:

*/

// Demonstrate block scope.
//using System;
//class ScopeDemo
//{
//    static void Main()
//    {
//        int x; // known to all code within Main()

//        x = 10;

//        if (x == 10)
//        { // start new scope

//            int y = 20; // known only to this block
//                        // x and y both known here.

//            Console.WriteLine("x and y: " + x + " " + y);

//            x = y * 2;
//        }

//        // y = 100; // Error! y not known here.

//        // x is still known here.
//        Console.WriteLine("x is " + x);
//    }
//}

/*

As the comments indicate, the variable x is declared at the start of Main()’s scope and is
accessible to all subsequent code within Main(). Within the if block, y is declared. Since a
block defines a scope, y is visible only to other code within its block. This is why outside of
its block, the line y = 100; is commented out. If you remove the leading comment symbol,
a compile-time error will occur because y is not visible outside of its block. Within the if
block, x can be used because code within a block (that is, a nested scope) has access to
variables declared by an enclosing scope.

*/

#endregion