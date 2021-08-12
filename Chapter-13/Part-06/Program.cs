#region Russian

/*

Применение нескольких операторов catch

С одним оператором try можно связать несколько операторов catch. И на практике
это делается довольно часто. Но все операторы catch должны перехватывать исключения
разного типа. В качестве примера ниже приведена программа, в которой
перехватываются ошибки выхода за границы массива и деления на нуль.

*/

// Использовать несколько операторов catch.

using System;

class ExcDemo3
{
    static void Main()
    {
        // Здесь массив numer длиннее массива demon.
        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
        int[] denom = { 2, 0, 4, 4, 0, 8 };

        for (int i = 0; i < numer.Length; i++)
        {
            try
            {
                Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Делить на ноль нельзя!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Подходящий элемент не найден.");
            }
        }

        Console.ReadKey();
    }
}

/*

Вот к какому результату приводит выполнение этой программы.
4/2 равно 2
Делить на нуль нельзя!
16/4 равно 4
32/4 равно 8
Делить на нуль нельзя!
128 / 8 равно 16
Подходящий элемент не найден.
Подходящий элемент не найден.

Как следует из приведенного выше результата, каждый оператор catch реагирует
только на свой тип исключения.

Вообще говоря, операторы catch выполняются по порядку их следования в программе.
Но при этом выполняется только один блок catch, в котором тип исключения
совпадает с типом генерируемого исключения. А все остальные блоки catch
пропускаются.

*/

#endregion

#region English

/*

Using Multiple catch Clauses

You can associate more than one catch clause with a try. In fact, it is common to do so.
However, each catch must catch a different type of exception. For example, the program
shown here catches both array boundary and divide-by-zero errors:

*/

// Use multiple catch clauses. 

//using System; 

//class ExcDemo4
//{
//    static void Main()
//    {
//        // Here, numer is longer than denom. 
//        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
//        int[] denom = { 2, 0, 4, 4, 0, 8 };

//        for (int i = 0; i < numer.Length; i++)
//        {
//            try
//            {
//                Console.WriteLine(numer[i] + " / " +
//                                   denom[i] + " is " +
//                                   numer[i] / denom[i]);
//            }
//            catch (DivideByZeroException)
//            {
//                Console.WriteLine("Can't divide by Zero!");
//            }
//            catch (IndexOutOfRangeException)
//            {
//                Console.WriteLine("No matching element found.");
//            }
//        }
//    }
//}

/*

This program produces the following output:

4 / 2 is 2
Can't divide by Zero!
16 / 4 is 4
32 / 4 is 8
Can't divide by Zero!
128 / 8 is 16
No matching element found.
No matching element found.

As the output confirms, each catch clause responds only to its own type of exception.
In general, catch clauses are checked in the order in which they occur in a program.
Only the first matching clause is executed. All other catch blocks are ignored.

*/

#endregion