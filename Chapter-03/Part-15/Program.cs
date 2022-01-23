#region Russian

/*

Помимо описанной выше формы строкового литерала, можно также указать буквальный
строковый литерал. Такой литерал начинается с символа @, после которого
следует строка в кавычках. Содержимое строки в кавычках воспринимается без изменений
и может быть расширено до двух и более строк. Это означает, что в буквальный
строковый литерал можно включить символы новой строки, табуляции и прочие, не
прибегая к управляющим последовательностям. Единственное исключение составляют
двойные кавычки ("), для указания которых необходимо использовать две двойные
кавычки подряд (""). В приведенном ниже примере программы демонстрируется
применение буквальных строковых литералов.

*/

// Продемонстрировать применение буквальных строковых литералов.

using System;

class Verbatim
{
    static void Main()
    {
        Console.WriteLine(@"Это буквальный
строковый литерал,
занимающий несколько строк.
");
        Console.WriteLine(@"А это вывод с табуляцией:
1   2   3   4
5   6   7   8
");
        Console.WriteLine(@"Отзыв программиста: ""Мне нравится C#.""");
    }
}

/*

Результат выполнения этой программы приведен ниже.

Это буквальный
строковый литерал,
занимающий несколько строк.
А это вывод с табуляцией:
1   2   3   4
5   6   7   
Отзыв программиста: "Мне нравится С#."

Следует особо подчеркнуть, что буквальные строковые литералы выводятся в том
же виде, в каком они введены в исходном тексте программы.

Преимущество буквальных строковых литералов заключается в том, что они позволяют
указать в программе выводимый результат именно так, как он должен выглядеть
на экране. Но если выводится несколько строк, то переход на новую строку может нарушить
порядок набора исходного текста программы с отступами. Именно по этой
причине в примерах программ, приведенных в этой книге, применение буквальных
строковых литералов ограничено. Тем не менее они приносят немало замечательных
выгод во многих случаях, когда требуется форматирование выводимых результатов.

И последнее замечание: не путайте строки с символами. Символьный литерал, например
'X', обозначает одиночную букву типа char. А строка, состоящая из одного
символа, например "X", по-прежнему остается текстовой строкой.

*/

#endregion

#region English

/*

In addition to the form of string literal just described, you can also specify a verbatim
string literal. A verbatim string literal begins with an @, which is followed by a quoted string.
The contents of the quoted string are accepted without modification and can span two or
more lines. Thus, you can include newlines, tabs, and so on, but you don’t need to use the
escape sequences. The only exception is that to obtain a double quote (“), you must use two
double quotes in a row (“”). Here is a program that demonstrates verbatim string literals:

*/

// Demonstrate verbatim string literals.
//using System;

//class Verbatim
//{
//    static void Main()
//    {
//        Console.WriteLine(@"This is a verbatim
//string literal
//that spans several lines.
//");
//        Console.WriteLine(@"Here is some tabbed output:
//1   2   3   4
//5   6   7   8
//");
//        Console.WriteLine(@"Programmers say, ""I like C#.""");
//    }
//}

/*

The output from this program is shown here:

This is a verbatim
string literal
that spans several lines.

Here is some tabbed output:
1   2   3   4
5   6   7   8

Programmers say, "I like C#."

The important point to notice about the preceding program is that the verbatim string
literals are displayed precisely as they are entered into the program.

The advantage of verbatim string literals is that you can specify output in your program
exactly as it will appear on the screen. However, in the case of multiline strings, the
wrapping will obscure the indentation of your program. For this reason, the programs in
this book will make only limited use of verbatim string literals. That said, they are still a
wonderful benefit for many formatting situations.

One last point: Don’t confuse strings with characters. A character literal, such as 'X',
represents a single letter of type char. A string containing only one letter, such as "X", is still
a string.

*/

#endregion