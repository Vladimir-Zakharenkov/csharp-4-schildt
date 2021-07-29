#region Russian

/*

Передача аргументов анонимному методу

Анонимному методу можно передать один или несколько аргументов. Для этого
достаточно указать в скобках список параметров после ключевого слова delegate,
а при обращении к экземпляру делегата — передать ему соответствующие аргументы.
В качестве примера ниже приведен вариант предыдущей программы, измененный
с целью передать в качестве аргумента конечное значение для подсчета.

*/

// Продемонстрировать применение анонимного метода, принимающего аргумент.

using System;

// Обратите внимание на то, что теперь у делегата CountIt имеется параметр.
delegate void CounIt(int end);

class AnonMethDemo2
{
    static void Main()
    {
        // Здесь конечное значение для подсчета передается анонимному методу.
        CounIt count = delegate (int end)
        {
            // Этот кодовый блок передается делегату.
            for (int i = 0; i <= end; i++)
            {
                Console.WriteLine(i);
            };
        }; // Обратите внимание на точку с запятой

        count(3);
        Console.WriteLine();
        count(5);

        Console.ReadKey();
    }
}

/*

В этом варианте программы делегат CountIt принимает целочисленный аргумент.
Обратите внимание на то, что при создании анонимного метода список параметров
указывается после ключевого слова delegate. Параметр end становится доступным
для кода в анонимном методе таким же образом, как и при создании именованного
метода. Ниже приведен результат выполнения данной программы.

0
1
2
3

0
1
2
3
4
5

*/

#endregion

#region English

/*

Pass Arguments to an Anonymous Method

It is possible to pass one or more arguments to an anonymous method. To do so, follow the
delegate keyword with a parenthesized parameter list. Then, pass the argument(s) to the
delegate instance when it is called. For example, here is the preceding program rewritten
so that the ending value for the count is passed:

*/

// Demonstrate an anonymous method that takes an argument. 

//using System;  

//// Notice that CountIt now has a parameter. 
//delegate void CountIt(int end);

//class AnonMethDemo2
//{

//    static void Main()
//    {

//        // Here, the ending value for the count 
//        // is passed to the anonymous method. 
//        CountIt count = delegate (int end)
//        {
//            for (int i = 0; i <= end; i++)
//                Console.WriteLine(i);
//        };

//        count(3);
//        Console.WriteLine();
//        count(5);

//        Console.ReadKey();
//    }
//}

/*

In this version, CountIt now takes an integer argument. Notice how the parameter list
is specified after the delegate keyword when the anonymous method is created. The code
inside the anonymous method has access to the parameter end in just the same way it would
if a named method were being created. The output from this program is shown next:

0
1
2
3

0
1
2
3
4
5

*/

#endregion