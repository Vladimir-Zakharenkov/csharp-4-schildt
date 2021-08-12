#region Russian

/*

Как упоминалось ранее, тип генерируемого исключения должен соответствовать
типу, указанному в операторе catch. В противном случае исключение не будет перехвачено.
Например, в приведенной ниже программе предпринимается попытка перехватить
ошибку нарушения границ массива в блоке catch, реагирующем на исключение
DivideByZeroException, связанное с делением на нуль и являющееся еще одним
стандартным исключением. Когда индексирование массива выходит за его границы,
генерируется исключение IndexOutOfRangeException, но оно не будет перехвачено
блоком catch, что приведет к аварийному завершению программы.

*/

// Не сработает!

using System;

class ExcTypeMismatch
{
    static void Main()
    {
        int[] nums = new int[4];

        try
        {
            Console.WriteLine("До генерирования исключения");

            // Сгенерировать исключение в связи с выходом индекса за границы массива.
            for (int i = 0; i < 10; i++)
            {
                nums[i] = i;
                Console.WriteLine("nums [{0}] : {1}", i, nums[i]);
            }

            Console.WriteLine("Не подлежит выводу");
        }
        /* Если перехват рассчитан на исключение DevideByZeroException,
           то перехватить ошибку нарушения границ массива не удастся. */
        catch (DivideByZeroException)
        {
            // Перехватить исключение.
            Console.WriteLine("Индекс вышел за границы массива");
        }

        Console.WriteLine("После блока перехвата исключения.");

        Console.ReadKey();
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

До генерирования исключения.
nums[0]: 0
nums[1]: 1
nums[2]: 2
nums[3]: 3
Необработанное исключение: System.IndexOutOfRangeException:
Индекс находился вне границ массива
в ExcTypeMismatch.Main() в <имя_файла>:строка 18

Как следует из приведенного выше результата, в блоке catch, реагирующем
на исключение DivideByZeroException, не удалось перехватить исключение
IndexOutOfRangeException.

*/

#endregion

#region English

/*

As mentioned earlier, the type of the exception must match the type specified in a catch.
If it doesn’t, the exception won’t be caught. For example, the following program tries to
catch an array boundary error with a catch for a DivideByZeroException (another built-in
exception). When the array boundary is overrun, an IndexOutOfRangeException is
generated, but it won’t be caught by the catch. This results in abnormal program termination.

*/

// This won't work! 

//using System; 

//class ExcTypeMismatch
//{
//    static void Main()
//    {
//        int[] nums = new int[4];

//        try
//        {
//            Console.WriteLine("Before exception is generated.");

//            // Generate an index out-of-bounds exception. 
//            for (int i = 0; i < 10; i++)
//            {
//                nums[i] = i;
//                Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
//            }

//            Console.WriteLine("this won't be displayed");
//        }

//        /* Can't catch an array boundary error with a 
//           DivideByZeroException. */
//        catch (DivideByZeroException)
//        {
//            // Catch the exception. 
//            Console.WriteLine("Index out-of-bounds!");
//        }
//        Console.WriteLine("After catch block.");
//    }
//}

/*

The output is shown here:

Before exception is generated.
nums[0]: 0
nums[1]: 1
nums[2]: 2
nums[3]: 3
Unhandled Exception: System.IndexOutOfRangeException:
Index was outside the bounds of the array.
at ExcTypeMismatch.Main()

As the output demonstrates, a catch for DivideByZeroException won’t catch an
IndexOutOfRangeException.

*/

#endregion