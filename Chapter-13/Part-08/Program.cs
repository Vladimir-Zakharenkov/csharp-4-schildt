#region Russian

/*

Вложение блоков try

Один блок try может быть вложен в другой. Исключение, генерируемое во внутреннем
блоке try и не перехваченное в соответствующем блоке catch, передается во
внешний блок try. В качестве примера ниже приведена программа, в которой исключение
IndexOutOfRangeException перехватывается не во внутреннем, а во внешнем
блоке try.

*/

// Использовать вложенный блок try.

using System;

class NestTrys
{
    static void Main()
    {
        // Здесь массив numer длиннее массива demon.
        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
        int[] denom = { 2, 0, 4, 4, 0, 8 };

        try
        {
            // внешний блок try
            for (int i = 0; i < numer.Length; i++)
            {
                try
                {
                    // вложенный блок try
                    Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Делить на ноль нельзя!");
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Подходящий элемент не найден.");
            Console.WriteLine("Неисправимая ошибка - программа прервана.");
        }
    }
}

/*

Выполнение этой программы приводит к следующему результату.

4/2 равно 2
Делить на нуль нельзя!
16/4 равно 4
32/4 равно 8
Делить на нуль нельзя!
128 / 8 равно 16
Подходящий элемент не найден.
Неисправимая ошибка - программа прервана.

В данном примере исключение, обрабатываемое во внутреннем блоке try и связанное
с ошибкой из-за деления на нуль, не мешает дальнейшему выполнению программы.
Но ошибка нарушения границ массива, обнаруживаемая во внешнем блоке try,
приводит к прерыванию программы.

Безусловно, приведенный выше пример демонстрирует далеко не единственное
основание для применения вложенных блоков try, тем не менее из него можно сделать
важный общий вывод. Вложенные блоки try нередко применяются для обработки различных
категорий ошибок разными способами. В частности, одни ошибки считаются
неисправимыми и не подлежат исправлению, а другие ошибки незначительны и могут
быть обработаны немедленно. Как правило, внешний блок try служит для обнаружения и
обработки самых серьезных ошибок, а во внутренних блоках try обрабатываются
менее серьезные ошибки. Кроме того, внешний блок try может стать "универсальным"
для тех ошибок, которые не подлежат обработке во внутреннем блоке.

*/

#endregion

#region English

/*

Nesting try Blocks

One try block can be nested within another. An exception generated within the inner try
block that is not caught by a catch associated with that try is propagated to the outer try block.
For example, here the IndexOutOfRangeException is not caught by the inner try block, but
by the outer try:

*/

// Use a nested try block. 

//using System; 

//class NestTrys
//{
//    static void Main()
//    {
//        // Here, numer is longer than denom. 
//        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
//        int[] denom = { 2, 0, 4, 4, 0, 8 };

//        try
//        { // outer try 
//            for (int i = 0; i < numer.Length; i++)
//            {
//                try
//                { // nested try 
//                    Console.WriteLine(numer[i] + " / " +
//                                       denom[i] + " is " +
//                                       numer[i] / denom[i]);
//                }
//                catch (DivideByZeroException)
//                {
//                    Console.WriteLine("Can't divide by Zero!");
//                }
//            }
//        }
//        catch (IndexOutOfRangeException)
//        {
//            Console.WriteLine("No matching element found.");
//            Console.WriteLine("Fatal error -- program terminated.");
//        }
//    }
//}

/*

The output from the program is shown here:

4 / 2 is 2
Can't divide by Zero!
16 / 4 is 4
32 / 4 is 8
Can't divide by Zero!
128 / 8 is 16
No matching element found.
Fatal error -- program terminated.

In this example, an exception that can be handled by the inner try—in this case a divide-byzero
error—allows the program to continue. However, an array boundary error is caught by
the outer try, which causes the program to terminate.

Although certainly not the only reason for nested try statements, the preceding program
makes an important point that can be generalized. Often, nested try blocks are used to
allow different categories of errors to be handled in different ways. Some types of errors
are catastrophic and cannot be fixed. Some are minor and can be handled immediately.
Many programmers use an outer try block to catch the most severe errors, allowing inner
try blocks to handle less serious ones. You can also use an outer try block as a “catch all”
block for those errors that are not handled by the inner block.

*/

#endregion