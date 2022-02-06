#region Russian

/*

В языке C# имеется еще одна особенность соблюдения правил области действия: несмотря
на то, что блоки могут быть вложены, ни у одной из переменных из внутренней
области действия не должно быть такое же имя, как и у переменной из внешней области
действия. В приведенном ниже примере программы предпринимается попытка
объявить две разные переменные с одним и тем же именем, и поэтому программа не
может быть скомпилирована.

*/

/*

В этой программе предпринимается попытка объявить во внутренней
области действия переменную с таким же самым именем, как и у
переменной, определенной во внешней области действия.

*** Эта программа не может быть скомпилирована. ***

*/

using System;

class NestVar
{
    static void Main()
    {
        int count;

        for (count = 0; count < 10; count = count + 1)
        {
            Console.WriteLine("Это подсчет: " + count);

            int count; // Недопустимо!!!

            for (count = 0; count < 2; count++)
                Console.WriteLine("В этой программе есть ошибка!");
        }
    }
}

/*

Если у вас имеется некоторый опыт программирования на С или C++, то вам должно
быть известно, что на присваивание имен переменным, объявляемым во внутренней
области действия, в этих языках не существует никаких ограничений. Следовательно,
в С и C++ объявление переменной count в кодовом блоке, входящем во внешний цикл
for, как в приведенном выше примере, считается вполне допустимым. Но в С и C++ такое
объявление одновременно означает сокрытие внешней переменной. Разработчики
C# посчитали, что такого рода сокрытие имен может легко привести к программным
ошибкам, и поэтому решили запретить его.

*/

#endregion

#region English

/*

There is one quirk to C#’s scope rules that may surprise you: Although blocks can be
nested, no variable declared within an inner scope can have the same name as a variable
declared by an enclosing scope. For example, the following program, which tries to declare
two separate variables with the same name, will not compile.

*/

/*

This program attempts to declare a variable
in an inner scope with the same name as one
defined in an outer scope.

*** This program will not compile. ***

*/

//using System;

//class NestVar
//{
//    static void Main()
//    {
//        int count;

//        for (count = 0; count < 10; count = count + 1)
//        {
//            Console.WriteLine("This is count: " + count);

//            int count; // illegal!!!

//            for (count = 0; count < 2; count++)
//                Console.WriteLine("This program is in error!");
//        }
//    }
}

/*

If you come from a C/C++ background, then you know that there is no restriction on
the names you give variables declared in an inner scope. Thus, in C/C++ the declaration of
count within the block of the outer for loop is completely valid. However, in C/C++, such
a declaration hides the outer variable. The designers of C# felt that this type of name hiding
could easily lead to programming errors and disallowed it.

*/

#endregion