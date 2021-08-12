#region Russian

/*

Повторное генерирование исключений

Исключение, перехваченное в одном блоке catch, может быть повторно сгенерировано
в другом блоке, чтобы быть перехваченным во внешнем блоке catch. Наиболее
вероятной причиной для повторного генерирования исключения служит предоставление
доступа к исключению нескольким обработчикам. Допустим, что один обработчик
оперирует каким-нибудь одним аспектом исключения, а другой обработчик — другим
его аспектом. Для повторного генерирования исключения достаточно указать оператор
throw без сопутствующего выражения, как в приведенной ниже форме.

throw ;

Не следует, однако, забывать, что когда исключение генерируется повторно, то оно
не перехватывается снова тем же самым блоком catch, а передается во внешний блок
catch.

В приведенном ниже примере программы демонстрируется повторное
генерирование исключения. В данном случае генерируется исключение
IndexOutOfRangeException.

*/

// Сгенерировать исключение повторно.

using System;

class Rethrow
{
    public static void GenException()
    {
        // Здесь массив numer длиннее массива denom.
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
                throw; // сгенерировать исключение повторно
            }
        }
    }
}

class RethrowDemo
{
    static void Main()
    {
        try
        {
            Rethrow.GenException();
        }
        catch (IndexOutOfRangeException)
        {
            // перехватить исключение повторно
            Console.WriteLine("Неисправимая ошибка - программа прервана.");
        }

        Console.ReadKey();
    }
}

/*

В этом примере программы ошибки из-за деления на нуль обрабатываются локально
в методе GenException(), но ошибка выхода за границы массива генерируется
повторно. В данном случае исключение IndexOutOfRangeException обрабатывается
в методе Main().

*/

#endregion

#region English

/*

Rethrowing an Exception

An exception caught by one catch can be rethrown so that it can be caught by an outer
catch. The most likely reason for rethrowing an exception is to allow multiple handlers
access to the exception. For example, perhaps one exception handler manages one aspect of
an exception, and a second handler copes with another aspect. To rethrow an exception, you
simply specify throw, without specifying an expression. That is, you use this form of throw:

throw ;

Remember, when you rethrow an exception, it will not be recaught by the same catch
clause. Instead, it will propagate to an outer catch.
The following program illustrates rethrowing an exception. In this case, it rethrows an
IndexOutOfRangeException.

*/

// Rethrow an exception. 

//using System; 

//class Rethrow
//{
//    public static void GenException()
//    {
//        // Here, numer is longer than denom. 
//        int[] numer = { 4, 8, 16, 32, 64, 128, 256, 512 };
//        int[] denom = { 2, 0, 4, 4, 0, 8 };

//        for (int i = 0; i < numer.Length; i++)
//        {
//            try
//            {
//                Console.WriteLine(numer[i] + " / " +
//                                  denom[i] + " is " +
//                                  numer[i] / denom[i]);
//            }
//            catch (DivideByZeroException)
//            {
//                Console.WriteLine("Can't divide by Zero!");
//            }
//            catch (IndexOutOfRangeException)
//            {
//                Console.WriteLine("No matching element found.");
//                throw; // rethrow the exception 
//            }
//        }
//    }
//}

//class RethrowDemo
//{
//    static void Main()
//    {
//        try
//        {
//            Rethrow.GenException();
//        }
//        catch (IndexOutOfRangeException)
//        {
//            // recatch exception 
//            Console.WriteLine("Fatal error -- " + "program terminated.");
//        }

//        Console.ReadKey();
//    }
//}

/*

In this program, divide-by-zero errors are handled locally, by GenException( ), but an array
boundary error is rethrown. In this case, the IndexOutOfRangeException is handled by
Main( ).

*/

#endregion