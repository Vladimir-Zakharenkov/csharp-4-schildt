﻿#region Russian

/*

Второй пример обработки исключительной ситуации

Следует особо подчеркнуть, что весь код, выполняемый в блоке try, контролируется
на предмет исключительных ситуаций, в том числе и тех, которые могут возникнуть
в результате вызова метода из самого блока try. Исключение, генерируемое методом
в блоке try, может быть перехвачено в том же блоке, если, конечно, этого не будет
сделано в самом методе.

В качестве еще одного примера рассмотрим следующую программу, где блок try
помещается в методе Main(). Из этого блока вызывается метод GenException(), в котором
и генерируется исключение IndexOutOfRangeException. Это исключение не
перехватывается методом GenException(). Но поскольку метод GenException() вызывается
из блока try в методе Main(), то исключение перехватывается в блоке catch,
связанном непосредственно с этим блоком try.

*/

// Исключение может быть сгенерировано одним методом и перехвачено другим.

using System;

class ExcTest
{
    // Сгенерировать исключение.
    public static void GenException()
    {
        int[] nums = new int[4];

        Console.WriteLine("До генерирования исключения");

        // Сгенерировать исключение в связи с выходом индекса за границы массива.
        for (int i = 0; i < 10; i++)
        {
            nums[i] = i;
            Console.WriteLine("nums [{0}] : {1}", i, nums[i]);
        }

        Console.WriteLine("Не подлежит выводу");
    }
}

class ExcDemo2
{
    static void Main()
    {
        try
        {
            ExcTest.GenException();
        }
        catch (IndexOutOfRangeException)
        {
            // Перехватить исключение.
            Console.WriteLine("Индекс вышел за границы массива!");
        }

        Console.WriteLine("После блока перехвата исключения.");

        Console.ReadKey();
    }
}

/*

Выполнение этой программы дает такой же результат, как и в предыдущем
примере.

До генерирования исключения.
nums[0]: 0
nums[1]: 1
nums[2]: 2
nums[3]: 3
Индекс вышел за границы массива!
После блока перехвата исключения.

Как пояснялось выше, метод GenException() вызывается из блока try, и поэтому
генерируемое им исключение перехватывается не в нем, а в блоке catch внутри метода
Main(). А если бы исключение перехватывалось в методе GenException(), оно не
было бы вообще передано обратно методу Main().

*/

#endregion

#region English

/*

A Second Exception Example

It is important to understand that all code executed within a try block is monitored for
exceptions. This includes exceptions that might be generated by a method called from
within the try block. An exception thrown by a method called from within a try block
can be caught by that try block, assuming, of course, that the method itself did not catch
the exception.

For example, consider the following program. Main() establishes a try block from which
the method GenException() is called. Inside GenException(), an IndexOutOfRangeException
is generated. This exception is not caught by GenException(). However, since GenException()
was called from within a try block in Main(), the exception is caught by the catch statement
associated with that try.

*/

// An exception can be generated by one method and caught by another. 

//using System; 

//class ExcTest
//{
//    // Generate an exception. 
//    public static void GenException()
//    {
//        int[] nums = new int[4];

//        Console.WriteLine("Before exception is generated.");

//        // Generate an index out-of-bounds exception. 
//        for (int i = 0; i < 10; i++)
//        {
//            nums[i] = i;
//            Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
//        }

//        Console.WriteLine("this won't be displayed");
//    }
//}

//class ExcDemo2
//{
//    static void Main()
//    {

//        try
//        {
//            ExcTest.GenException();
//        }
//        catch (IndexOutOfRangeException)
//        {
//            // Catch the exception. 
//            Console.WriteLine("Index out-of-bounds!");
//        }
//        Console.WriteLine("After catch block.");

//        Console.ReadKey();
//    }
//}

/*

This program produces the following output, which is the same as that produced by the
first version of the program shown earlier:

Before exception is generated.
nums[0]: 0
nums[1]: 1
nums[2]: 2
nums[3]: 3
Index out-of-bounds!
After catch block.

As explained, because GenException() is called from within a try block, the exception that
it generates (and does not catch) is caught by the catch in Main(). Understand, however,
that if GenException() had caught the exception, then it never would have been passed
back to Main().

*/

#endregion