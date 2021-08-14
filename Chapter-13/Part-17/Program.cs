#region Russian

/*

В представленном выше примере программы было продемонстрировано применение
ключевых слов checked и unchecked в одном выражении. А в следующем примере
программы показывается, каким образом проверяется и не проверяется на переполнение
целый блок операторов.

*/

// Продемонстрировать применение ключевых слов checked и unchecked в блоке операторов.

using System;

class CheckedBlocks
{
    static void Main()
    {
        byte a, b;
        byte result;

        a = 127;
        b = 127;

        try
        {
            unchecked
            {
                a = 127;
                b = 127;
                result = unchecked((byte)(a * b));
                Console.WriteLine("Непроверенный на переполнение результат: " + result);

                a = 125;
                b = 5;
                result = unchecked((byte)(a * b));
                Console.WriteLine("Непроверенный на переполнение результат: " + result);
            }
            checked
            {
                a = 2;
                b = 7;
                result = (byte)(a * b); // верно
                Console.WriteLine("Проверенный на переполнение результат: " + result);

                a = 127;
                b = 127;
                result = (byte)(a * b); // эта операция приводит к исключительной ситуации
                Console.WriteLine("Проверенный на переполнение результат: " + result); // не подлежит исполнению
            }
        }
        catch (OverflowException exc)
        {
            Console.WriteLine(exc);
        }

        Console.ReadKey();
    }
}

/*

Результат выполнения этой программы приведен ниже.

Непроверенный на переполнение результат: 1
Непроверенный на переполнение результат: 113
Проверенный на переполнение результат: 14
System.OverflowException: Переполнение в результате
выполнения арифметической операции.
в CheckedDemo.Main() в <имя_файма>:строка 41

Как видите, результаты выполнения непроверяемого на переполнение блока операторов
были усечены. Когда же в проверяемом блоке операторов произошло переполнение,
то возникла исключительная ситуация.

Потребность в применении ключевого слова checked или unchecked может возникнуть,
в частности, потому, что по умолчанию проверяемое или непроверяемое состояние
переполнения определяется путем установки соответствующего параметра
компилятора и настройки самой среды выполнения. Поэтому в некоторых программах
состояние переполнения лучше проверять явным образом.

*/

#endregion

#region English

/*

The preceding program demonstrated the use of checked and unchecked for a single
expression. The following program shows how to check and uncheck a block of statements.

*/

// Using checked and unchecked with statement blocks. 

//using System; 

//class CheckedBlocks
//{
//    static void Main()
//    {
//        byte a, b;
//        byte result;

//        a = 127;
//        b = 127;

//        try
//        {
//            unchecked
//            {
//                a = 127;
//                b = 127;
//                result = unchecked((byte)(a * b));
//                Console.WriteLine("Unchecked result: " + result);

//                a = 125;
//                b = 5;
//                result = unchecked((byte)(a * b));
//                Console.WriteLine("Unchecked result: " + result);
//            }

//            checked
//            {
//                a = 2;
//                b = 7;
//                result = checked((byte)(a * b)); // this is OK 
//                Console.WriteLine("Checked result: " + result);

//                a = 127;
//                b = 127;
//                result = checked((byte)(a * b)); // this causes exception 
//                Console.WriteLine("Checked result: " + result); // won't execute 
//            }
//        }
//        catch (OverflowException exc)
//        {
//            Console.WriteLine(exc);
//        }

//        Console.ReadKey();
//    }
//}

/*

The output from the program is shown here:

Unchecked result: 1
Unchecked result: 113
Checked result: 14
System.OverflowException: Arithmetic operation resulted in an overflow.
at CheckedBlocks.Main()

As you can see, the unchecked block results in the overflow being truncated. When
overflow occurred in the checked block, an exception was raised.

One reason that you may need to use checked or unchecked is that the default
checked/unchecked status of overflow is determined by the setting of a compiler option
and the execution environment, itself. Thus, for some types of programs, it is best to specify
the overflow check status explicitly.

*/
#endregion