#region Russian

/*

4 ГЛАВА

Операторы

В языке C# предусмотрен обширный ряд операторов, предоставляющих программирующему возможность
полного контроля над построением и вычислением выражений. Большинство операторов в С# относится к следующим
категориям: арифметические, поразрядные, логические и операторы отношения. Все перечисленные категории
операторов рассматриваются в этой главе. Кроме того, в C# предусмотрен ряд других операторов для особых случаев,
включая индексирование массивов, доступ к членам класса и обработку лямбда-выражений. Эти специальные операторы
рассматриваются далее в книге вместе с теми средствами, в которых они применяются.

Арифметические операторы

Арифметические операторы, представленные в языке С#, приведены ниже.

Оператор    Действие

+           Сложение
-           Вычитание, унарный минус
*           Умножение
/           Деление
%           Деление по модулю
- -           Декремент
++          Инкремент

Операторы +, -, * и / действуют так, как предполагает их обозначение. Их можно
применять к любому встроенному числовому типу данных.

Действие арифметических операторов не требует особых пояснений, за исключением
следующих особых случаев. Прежде всего, не следует забывать, что когда оператор
/ применяется к целому числу, то любой остаток от деления отбрасывается; например,
результат целочисленного деления 10/3 будет равен 3. Остаток от этого деления можно
получить с помощью оператора деления по модулю (%), который иначе называется
оператором вычисления остатка. Он дает остаток от целочисленного деления. Например,
10 % 3 равно 1. В C# оператор % можно применять как к целочисленным типам
данных, так и к типам с плавающей точкой. Поэтому 10.0 % 3.0 также равно 1.
В этом отношении C# отличается от языков С и C++, где операции деления по модулю
разрешаются только для целочисленных типов данных. В приведенном ниже примере
программы демонстрируется применение оператора деления по модулю.

*/

// Продемонстрировать применение оператора %.
using System;
class ModDemo
{
    static void Main()
    {
        int iresult, irem;

        double dresult, drem;

        iresult = 10 / 3;
        irem = 10 % 3;
        dresult = 10.0 / 3.0;
        drem = 10.0 % 3.0;

        Console.WriteLine("Результат и остаток от деления 10/3: " + iresult + " " + irem);
        Console.WriteLine("Результат и остаток от деления 10.0 / 3.0: " + dresult + " " + drem);
    }
}

/*

Результат выполнения этой программы приведен ниже.

Результат и остаток от деления 10 / 3: 3 1
Результат и остаток от деления 10.0 / 3.0: 3.33333333333333 1

Как видите, обе операции, % целочисленного типа и с плавающей точкой, дают
один и тот же остаток, равный 1.

*/

#endregion

#region English

/*

4 CHAPTER

Operators

C# provides an extensive set of operators that give the programmer detailed control
over the construction and evaluation of expressions. Most of C#’s operators fall into
the following categories: arithmetic, bitwise, relational, and logical. These operators are
examined in this chapter. Also discussed are the assignment operator and the ? operator. C#
also defines several other operators that handle specialized situations, such as array indexing,
member access, and the lambda operator. These special operators are examined later in this
book, when the features to which they apply are described.

Arithmetic Operators

C# defines the following arithmetic operators:

Operator    Meaning

+           Addition
–           Subtraction (also unary minus)
*           Multiplication
/           Division
%           Modulus
++          Increment
– –         Decrement

The operators +, –, *, and / all work in the expected way. These can be applied to any builtin
numeric data type.

Although the actions of arithmetic operators are well known to all readers, a few special
situations warrant some explanation. First, remember that when / is applied to an integer,
any remainder will be truncated; for example, 10/3 will equal 3 in integer division. You
can obtain the remainder of this division by using the modulus operator, %. The % is also
referred to as the remainder operator. It yields the remainder of an integer division. For
example, 10 % 3 is 1. In C#, the % can be applied to both integer and floating-point types.
Thus, 10.0 % 3.0 is also 1. (This differs from C/C++, which allow modulus operations only
on integer types.) The following program demonstrates the modulus operator.

*/

// Demonstrate the % operator.
//using System;
//class ModDemo
//{
//    static void Main()
//    {
//        int iresult, irem;

//        double dresult, drem;

//        iresult = 10 / 3;
//        irem = 10 % 3;

//        dresult = 10.0 / 3.0;
//        drem = 10.0 % 3.0;

//        Console.WriteLine("Result and remainder of 10 / 3: " + iresult + " " + irem);
//        Console.WriteLine("Result and remainder of 10.0 / 3.0: " + dresult + " " + drem);
//    }
//}

/*

The output from the program is shown here:

Result and remainder of 10 / 3: 3 1
Result and remainder of 10.0 / 3.0: 3.33333333333333 1

As you can see, the % yields a remainder of 1 for both integer and floating-point operations.

*/

#endregion