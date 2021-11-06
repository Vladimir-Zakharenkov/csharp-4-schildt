#region Russian

/*

Незначительное изменение программы

Несмотря на то что приведенная ниже строка указывается во всех примерах программ,
рассматриваемых в этой книге, формально она не нужна.

using System;

Тем не менее она указывается ради удобства. Эта строка не нужна потому, что в C#
можно всегда полностью определить имя с помощью пространства имен, к которому
оно принадлежит. Например, строку

Console.WriteLine("Простая программа на С#.");

можно переписать следующим образом.

System.Console.WriteLine("Простая программа на С#.");

Таким образом, первый пример программы можно видоизменить так.

*/

// В эту версию не включена строка "using System;".
class Example
{
    // Любая программа на C# начинается с вызова метода Main().
    static void Main()
    {
        // Здесь имя Console.WriteLine полностью определено.
        System.Console.WriteLine("Простая программа на С#.");
    }
}

/*

Указывать пространство имен System всякий раз, когда используется член этого
пространства, — довольно утомительное занятие, и поэтому большинство программистов
на C# вводят директиву using System в начале своих программ, как это сделано
в примерах всех программ, приведенных в данной книге. Следует, однако, иметь
в виду, что любое имя можно всегда определить, явно указав его пространство имен,
если в этом есть необходимость.

*/

#endregion

#region English

/*

A Small Variation

Although all of the programs in this book will use it, the line

using System;

at the start of the first example program is not technically needed. It is, however, a valuable
convenience. The reason it’s not necessary is that in C# you can always fully qualify a name
with the namespace to which it belongs. For example, the line

Console.WriteLine("A simple C# program.");

can be rewritten as

System.Console.WriteLine("A simple C# program.");

Thus, the first example could be recoded as shown here:

*/

// This version does not include "using System;".
//class Example
//{
//    // A C# program begins with a call to Main().
//    static void Main()
//    {
//        // Here, Console.WriteLine is fully qualified.
//        System.Console.WriteLine("A simple C# program.");
//    }
//}

/*

Since it is quite tedious to always specify the System namespace whenever a member
of that namespace is used, most C# programmers include using System at the top of their
programs, as will all of the programs in this book. It is important to understand, however,
that you can explicitly qualify a name with its namespace if needed.

*/

#endregion