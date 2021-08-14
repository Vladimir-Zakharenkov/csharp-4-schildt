#region Russian

/*

Применение ключевых слов checked и unchecked

В C# имеется специальное средство, связанное с генерированием исключений, возникающих
при переполнении в арифметических вычислениях. Как вам должно быть
уже известно, результаты некоторых видов арифметических вычислений могут превышать
диапазон представления чисел для типа данных, используемого в вычислении.
В этом случае происходит так называемое переполнение. Рассмотрим в качестве примера
следующий фрагмент кода.

byte a, b, result;
а = 127;
b = 127;
result = (byte)(а * b);

В этом коде произведение значений переменных а и b превышает диапазон представления
чисел для типа byte. Следовательно, результат вычисления данного выражения
приводит к переполнению для типа данных, сохраняемого в переменной
result.

В C# допускается указывать, будет ли в коде сгенерировано исключение при переполнении,
с помощью ключевых слов checked и unchecked. Так, если требуется указать,
что выражение будет проверяться на переполнение, следует использовать ключевое
слово checked, а если требуется проигнорировать переполнение — ключевое
слово unchecked. В последнем случае результат усекается, чтобы не выйти за пределы
диапазона представления чисел для целевого типа выражения.

У ключевого слова checked имеются две общие формы. В одной форме проверяется
конкретное выражение, и поэтому она называется операторной. А в другой форме
проверяется блок операторов, и поэтому она называется блочной. Ниже приведены обе
формы:

checked (выражение)

checked {
// проверяемые операторы
}

где выражение обозначает проверяемое выражение. Если вычисление проверяемого
выражения приводит к переполнению, то генерируется исключение
OverflowException.

У ключевого слова unchecked также имеются две общие формы. В первой, операторной
форме переполнение игнорируется при вычислении конкретного выражения.
А во второй, блочной форме оно игнорируется при выполнении блока операторов:

unchecked (выражение)

unchecked {
// операторы, для которых переполнение игнорируется
}

где выражение обозначает конкретное выражение, при вычислении которого переполнение
игнорируется. Если же в непроверяемом выражении происходит переполнение,
то результат его вычисления усекается.

Ниже приведен пример программы, в котором демонстрируется применение ключевых
слов checked и unchecked.

*/

// Продемонстрировать применение ключевых слов checked и unchecked.

using System;

class CheckedDemo
{
    static void Main()
    {
        byte a, b;
        byte result;

        a = 127;
        b = 127;

        try
        {
            result = unchecked((byte)(a * b));
            Console.WriteLine("Непроверенный на переполнение результат: " + result);

            result = checked((byte)(a * b)); // эта операция приводит к исключительной ситуации
            Console.WriteLine("Проверенный на переполнение результат: " + result); // не подлежит выполнению
        }
        catch (OverflowException exc)
        {
            Console.WriteLine(exc);
        }

        Console.ReadKey();
    }
}

/*

При выполнении этой программы получается следующий результат.

Непроверенный на переполнение результат: 1
System.OverflowException: Переполнение в результате
выполнения арифметической операции.
в CheckedDemo.Main() в <имя_файла>:строка 20

Как видите, результат вычисления непроверяемого выражения был усечен. А вычисление
проверяемого выражения привело к исключительной ситуации.

*/

#endregion

#region English

/*

Using checked and unchecked

A special feature in C# relates to the generation of overflow exceptions in arithmetic
computations. As you know, it is possible for some types of arithmetic computations to
produce a result that exceeds the range of the data type involved in the computation. When
this occurs, the result is said to overflow. For example, consider the following sequence:

byte a, b, result;
a = 127;
b = 127;
result = (byte)(a * b);

Here, the product of a and b exceeds the range of a byte value. Thus, the result overflows
the type of the result.

C# allows you to specify whether your code will raise an exception when overflow
occurs by using the keywords checked and unchecked. To specify that an expression be
checked for overflow, use checked. To specify that overflow be ignored, use unchecked.
In this case, the result is truncated to fit into the target type of the expression.

The checked keyword has these two general forms. One checks a specific expression
and is called the operator form of checked. The other checks a block of statements and is
called the statement form.

checked (expr)

checked {
// statements to be checked
}

Here, expr is the expression being checked. If a checked expression overflows, then an
OverflowException is thrown.

The unchecked keyword also has two general forms. The first is the operator form,
which ignores overflow for a specific expression. The second ignores overflow for a block
of statements.

unchecked (expr)

unchecked {
// statements for which overflow is ignored
}

Here, expr is the expression that is not being checked for overflow. If an unchecked
expression overflows, then truncation will occur.

Here is a program that demonstrates both checked and unchecked:

*/

// Using checked and unchecked. 

//using System; 

//class CheckedDemo
//{
//    static void Main()
//    {
//        byte a, b;
//        byte result;

//        a = 127;
//        b = 127;

//        try
//        {
//            result = unchecked((byte)(a * b));
//            Console.WriteLine("Unchecked result: " + result);

//            result = checked((byte)(a * b)); // this causes exception 
//            Console.WriteLine("Checked result: " + result); // won't execute 
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
System.OverflowException: Arithmetic operation resulted in an overflow.
at CheckedDemo.Main()

As is evident, the unchecked expression resulted in a truncation. The checked expression
caused an exception.

*/

#endregion