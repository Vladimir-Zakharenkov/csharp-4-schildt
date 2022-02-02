#region Russian

/*

Неявно типизированные переменные

Как пояснялось выше, все переменные в C# должны быть объявлены. Как правило,
при объявлении переменной сначала указывается тип, например int или bool,
а затем имя переменной. Но начиная с версии C# 3.0, компилятору предоставляется
возможность самому определить тип локальной переменной, исходя из значения, которым
она инициализируется. Такая переменная называется неявно типизированной.

Неявно типизированная переменная объявляется с помощью ключевого слова var
и должна быть непременно инициализирована. Для определения типа этой переменной
компилятору служит тип ее инициализатора, т.е. значения, которым она инициализируется.
Рассмотрим такой пример.

var е = 2.7183;

В данном примере переменная е инициализируется литералом с плавающей
точкой, который по умолчанию имеет тип double, и поэтому она относится к типу
double. Если бы переменная е была объявлена следующим образом:

var е = 2.7183F;

то она была бы отнесена к типу float.

В приведенном ниже примере программы демонстрируется применение неявно
типизированных переменных. Он представляет собой вариант программы из предыдущего
раздела, измененной таким образом, чтобы все переменные были типизированы
неявно.

 */

// Продемонстрировать применение неявно типизированных переменных.
using System;

class ImplicitlyTypedVar
{
    static void Main()
    {
        // Эти переменные типизированы неявно. Они отнесены
        // к типу double, поскольку инициализирующие их
        // выражения сами относятся к типу double.
        var s1 = 4.0;
        var s2 = 5.0;

        // Итак, переменная hypot типизирована неявно и
        // относится к типу double, поскольку результат,
        // возвращаемый методом Sqrt(), имеет тип double.
        var hypot = Math.Sqrt((s1 * s1) + (s2 * s2));

        Console.Write("Гипотенуза треугольника со сторонами " + s1 + " by " + s2 + " равна ");
        Console.WriteLine("{0:#.###}.", hypot);

        // Следующий оператор не может быть скомпилирован,
        // поскольку переменная s1 имеет тип double и
        // ей нельзя присвоить десятичное значение.
        // s1 = 12.2М; // Ошибка!
    }
}

/*

Результат выполнения этой программы оказывается таким же, как и прежде.
Важно подчеркнуть, что неявно типизированная переменная по-прежнему остается
строго типизированной. Обратите внимание на следующую закомментированную
строку из приведенной выше программы.

// s1 = 12.2М; // Ошибка!

Эта операция присваивания недействительна, поскольку переменная s1 относится
к типу double. Следовательно, ей нельзя присвоить десятичное значение. Единственное
отличие неявно типизированной переменной от обычной, явно типизированной
переменной, — в способе определения ее типа. Как только этот тип будет определен,
он закрепляется за переменной до конца ее существования. Это, в частности, означает,
что тип переменной s1 не может быть изменен по ходу выполнения программы.

Неявно типизированные переменные внедрены в C# не для того, чтобы заменить
собой обычные объявления переменных. Напротив, неявно типизированные переменные
предназначены для особых случаев, и самый примечательный из них имеет отношение
к языку интегрированных запросов (LINQ), подробно рассматриваемому в главе
19. Таким образом, большинство объявлений переменных должно и впредь оставаться
явно типизированными, поскольку они облегчают чтение и понимание исходного текста
программы.

И последнее замечание: одновременно можно объявить только одну неявно типизированную
переменную. Поэтому объявление

var s1 = 4.0, s2 = 5.0; // Ошибка!

является неверным и не может быть скомпилировано. Ведь в нем предпринимается
попытка объявить обе переменные, s1 и s2, одновременно.

*/

#endregion


#region English

/*

Implicitly Typed Variables

As explained, in C# all variables must be declared. Normally, a declaration includes the
type of the variable, such as int or bool, followed by the name of the variable. However,
beginning with C# 3.0, it became possible to let the compiler determine the type of a local
variable based on the value used to initialize it. This is called an implicitly typed variable.

An implicitly typed variable is declared using the keyword var, and it must be initialized.
The compiler uses the type of the initializer to determine the type of the variable. Here is an
example:

var e = 2.7183;

Because e is initialized with a floating-point literal (whose type is double by default), the
type of e is double. Had e been declared like this:

var e = 2.7183F;

then e would have the type float, instead.

The following program demonstrates implicitly typed variables. It reworks the program
shown in the preceding section so that all variables are implicitly typed.

*/

// Demonstrate implicitly typed variables.
//using System;
//class ImplicitlyTypedVar
//{
//    static void Main()
//    {
//        // These are now implicitly typed variables. They
//        // are of type double because their initializing
//        // expressions are of type double.
//        var s1 = 4.0;
//        var s2 = 5.0;

//        // Now, hypot is implicitly typed. Its type is double
//        // because the return type of Sqrt() is double.
//        var hypot = Math.Sqrt((s1 * s1) + (s2 * s2));

//        Console.Write("Hypotenuse of triangle with sides " + s1 + " by " + s2 + " is ");
//        Console.WriteLine("{0:#.###}.", hypot);

//        // The following statement will not compile because
//        // s1 is a double and cannot be assigned a decimal value.
//        // s1 = 12.2M; // Error!
//    }
//}

/*

The output is the same as before.

It is important to emphasize that an implicitly typed variable is still a strongly typed
variable. Notice this commented-out line in the program:

// s1 = 12.2M; // Error!

This assignment is invalid because s1 is of type double. Thus, it cannot be assigned a
decimal value. The only difference between an implicitly typed variable and a “normal”
explicitly typed variable is how the type is determined. Once that type has been determined,
the variable has a type, and this type is fixed throughout the lifetime of the variable. Thus,
the type of s1 cannot be changed during execution of the program.

Implicitly typed variables were not added to C# to replace “normal” variable declarations.
Instead, implicitly typed variables are designed to handle some special-case situations, the
most important of which relate to Language-Integrated Query (LINQ), which is described
in Chapter 19. Therefore, for most variable declarations, you should continue to use explicitly
typed variables because they make your code easier to read and easier to understand.

One last point: Only one implicitly typed variable can be declared at any one time.
Therefore, the following declaration,

var s1 = 4.0, s2 = 5.0; // Error!

is wrong and won’t compile because it attempts to declare both s1 and s2 at the same time.

*/

#endregion