#region Russian

/*

Блочные лямбда-выражения

Как упоминалось выше, существуют две разновидности лямбда-выражений. Первая
из них, одиночное лямбда-выражение, была рассмотрена в предыдущем разделе. Тело
такого лямбда-выражения состоит только из одного выражения. Второй разновидностью
является блочное лямбда-выражение. Для такого лямбда-выражения характерны
расширенные возможности выполнения различных операций, поскольку в его теле допускается
указывать несколько операторов. Например, в блочном лямбда-выражении
можно использовать циклы и условные операторы if, объявлять переменные и т.д.
Создать блочное лямбда-выражение нетрудно. Для этого достаточно заключить тело
выражения в фигурные скобки. Помимо возможности использовать несколько операторов,
в остальном блочное лямбда-выражение, практически ничем не отличается от
только что рассмотренного одиночного лямбда-выражения.

Ниже приведен пример использования блочного лямбда-выражения для вычисления
и возврата факториала целого значения.

*/

// Продемонстрировать применение блочного лямбда-выражения.

using System;

// Делегат IntOp принимает один аргумент типа int и возвращает результат типа int.
delegate int IntOp(int end);

class StatementLambdaDemo
{
    static void Main()
    {
        // Блочное лямбда-выражение возвращает факториал передаваемого ему значения.
        IntOp fact = n =>
        {
            int r = 1;
            for (int i = 1; i <= n; i++)
            {
                r = i * r;
            }
            return r;
        };

        Console.WriteLine("Факториал 3 равен " + fact(3));
        Console.WriteLine("Факториал 5 равен " + fact(5));

        Console.ReadKey();
    }
}

/*

При выполнении этого кода получается следующий результат.

Факториал 3 равен 6
Факториал 5 равен 120

В приведенном выше примере обратите внимание на то, что в теле блочного
лямбда-выражения объявляется переменная r, организуется цикл for и используется
оператор return. Все эти элементы вполне допустимы в блочном лямбда-выражении.
И в этом отношении оно очень похоже на анонимный метод. Следовательно, многие
анонимные методы могут быть преобразованы в блочные лямбда-выражения при
обновлении унаследованного кода. И еще одно замечание: когда в блочном лямбда-
выражении встречается оператор return, он просто обусловливает возврат из лямбда-
выражения, но не возврат из охватывающего метода.

*/

#endregion

#region English

/*

Statement Lambdas

As mentioned, there are two basic flavors of the lambda expression. The first is the expression
lambda, which was discussed in the preceding section. As explained, the body of an
expression lambda consists solely of a single expression. The second type of lambda
expression is the statement lambda. A statement lambda expands the types of operations that
can be handled within a lambda expression because it allows the body of lambda to contain
multiple statements. For example, using a statement lambda you can use loops, if statements,
declare variables, and so on. A statement lambda is easy to create. Simply enclose the body
within braces. Aside from allowing multiple statements, it works much like the expression
lambdas just discussed.

Here is an example that uses a statement lambda to compute and return the factorial of
an int value:

*/

// Demonstrate a statement lambda. 
//using System;  

//// IntOp takes one int argument and returns an int result. 
//delegate int IntOp(int end);

//class StatementLambdaDemo
//{

//    static void Main()
//    {

//        // A statement lambda that returns the factorial 
//        // of the value it is passed. 
//        IntOp fact = n =>
//        {
//            int r = 1;
//            for (int i = 1; i <= n; i++)
//                r = i * r;
//            return r;
//        };

//        Console.WriteLine("The factorial of 3 is " + fact(3));
//        Console.WriteLine("The factorial of 5 is " + fact(5));

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

The factorial of 3 is 6
The factorial of 5 is 120

In the program, notice that the statement lambda declares a variable called r, uses a for
loop, and has a return statement. These are legal inside a statement lambda. In essence, a
statement lambda closely parallels an anonymous method. Therefore, many anonymous
methods will be converted to statement lambdas when updating legacy code. One other
point: When a return statement occurs within a lambda expression, it simply causes a
return from the lambda. It does not cause the enclosing method to return.

*/

#endregion