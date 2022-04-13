#region Russian

/*

Строковые литералы

В С# поддерживается еще один тип литералов — строковый. Строковый литерал
представляет собой набор символов, заключенных в двойные кавычки. Например следующий
фрагмент кода:

"это тест"

представляет собой текстовую строку. Образцы подобных строк не раз встречались
в приведенных выше примерах программ.

Помимо обычных символов, строковый литерал может содержать одну или несколько
управляющих последовательностей символов, о которых речь шла выше. Рассмотрим
для примера программу, в которой используются управляющие последовательности
\n и \t.

*/

// Продемонстрировать применение управляющих
// последовательностей символов в строковых литералах.

//using System;

//class StrDemo
//{
//    static void Main()
//    {
//        Console.WriteLine("Первая строка\nВторая строка\nТретья строка");
//        Console.WriteLine("Один\tДва\tТри");
//        Console.WriteLine("Четыре\tПять\tШесть");

//        // Вставить кавычки.
//        Console.WriteLine("\"Зачем?\", спросил он.");
//    }
//}

/*

Результат выполнения этой программы приведен ниже.

Первая строка
Вторая строка
Третья строка
Один Два Три
Четыре Пять Шесть
"Зачем?", спросил он.

В приведенном выше примере программы обратите внимание на то, что для перехода
на новую строку используется управляющая последовательность \n. Для вывода
нескольких строк совсем не обязательно вызывать метод WriteLine() несколько
раз — достаточно вставить управляющую последовательность \n в тех местах удлиненной
текстовой строки (или строкового литерала), где должен происходить переход
на новую строку. Обратите также внимание на то, как в текстовой строке формируется
знак кавычек.

*/

#endregion

#region English

/*

String Literals

C# supports one other type of literal: the string. A string literal is a set of characters enclosed
by double quotes. For example,

"this is a test"

is a string. You have seen examples of strings in many of the WriteLine() statements in the
preceding sample programs.

In addition to normal characters, a string literal can also contain one or more of the
escape sequences just described. For example, consider the following program. It uses
the \n and \t escape sequences.

*/

// Demonstrate escape sequences in strings.

using System;
class StrDemo
{
    static void Main()
    {
        Console.WriteLine("Line One\nLine Two\nLine Three");
        Console.WriteLine("One\tTwo\tThree");
        Console.WriteLine("Four\tFive\tSix");
        // Embed quotes.
        Console.WriteLine("\"Why?\", he asked.");
    }
}

/*

The output is shown here:

Line One
Line Two
Line Three
One Two Three
Four Five Six
"Why?", he asked.

Notice how the \n escape sequence is used to generate a new line. You don’t need to use
multiple WriteLine() statements to get multiline output. Just embed \n within a longer
string at the points where you want the new lines to occur. Also note how a quotation mark
is generated inside a string.

*/

#endregion