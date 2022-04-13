#region Russian

/*

Групповое преобразование делегируемых методов

Еще в версии C# 2.0 было внедрено специальное средство, существенно упрощающее
синтаксис присваивания метода делегату. Это так называемое групповое преобразование
методов, позволяющее присвоить имя метода делегату, не прибегая к оператору
new или явному вызову конструктора делегата.

Ниже приведен метод Main() из предыдущего примера, измененный с целью продемонстрировать
групповое преобразование методов.

*/

using System;

//Объявить тип делегата.
delegate string StrMod(string str);

class DelegateTest
{
    //Заменить пробелы дефисами
    static string ReplaceSpaces(string s)
    {
        Console.WriteLine("Замена пробелов дефисами."); ;
        return s.Replace(' ', '-');
    }

    //Удалить пробелы
    static string RemoveSpaces(string s)
    {
        string temp = "";
        int i;

        Console.WriteLine("Удаление пробелов.");

        for (i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
            {
                temp += s[i];
            }
        }

        return temp;
    }

    //Обратить строку
    static string Reverse(string s)
    {
        string temp = "";
        int i;

        Console.WriteLine("Обращение строки.");
        for (i = s.Length - 1; i >= 0; i--)
        {
            temp += s[i];
        }

        return temp;
    }

    static void Main()
    {
        //Сконструировать делегат, используя групповое преобразование методов.
        StrMod strOp = ReplaceSpaces; //использовать групповое преобразование методов
        string str;

        //Вызвать методы с помощью делегата.
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        strOp = RemoveSpaces; //использовать групповое преобразование методов
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        strOp = Reverse; //использовать групповое преобразование методов
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);

        Console.ReadKey();
    }
}

/*

Обратите особое внимание на то, как создается экземпляр делегата strOp и как ему
присваивается метод ReplaceSpaces в следующей строке кода.

strOp = RemoveSpaces; // использовать групповое преобразование методов

В этой строке кода имя метода присваивается непосредственно экземпляру делегата
strOp, а все заботы по автоматическому преобразованию метода в тип делегата
"возлагаются" на средства С#. Этот синтаксис может быть распространен на любую
ситуацию, в которой метод присваивается или преобразуется в тип делегата.

Синтаксис группового преобразования методов существенно упрощен по сравнению
с прежним подходом к делегированию, поэтому в остальной части книги используется
именно он.

*/

#endregion

#region English

/*

Delegate Method Group Conversion

Since version 2.0, C# has included an option that significantly simplifies the syntax that
assigns a method to a delegate. This feature is called method group conversion, and it allows
you to simply assign the name of a method to a delegate, without using new or explicitly
invoking the delegate’s constructor.

For example, here is the Main() method of the preceding program rewritten to use
method group conversions:

*/

// A simple delegate example.

//using System; 

//// Declare a delegate type.  
//delegate string StrMod(string str);

//class DelegateTest
//{
//    // Replaces spaces with hyphens. 
//    static string ReplaceSpaces(string s)
//    {
//        Console.WriteLine("Replacing spaces with hyphens.");
//        return s.Replace(' ', '-');
//    }

//    // Remove spaces. 
//    static string RemoveSpaces(string s)
//    {
//        string temp = "";
//        int i;

//        Console.WriteLine("Removing spaces.");
//        for (i = 0; i < s.Length; i++)
//            if (s[i] != ' ') temp += s[i];

//        return temp;
//    }

//    // Reverse a string. 
//    static string Reverse(string s)
//    {
//        string temp = "";
//        int i, j;

//        Console.WriteLine("Reversing string.");
//        for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
//            temp += s[i];

//        return temp;
//    }

//    static void Main()
//    {
//        // Construct a delegate using method group conversion. 
//        StrMod strOp = ReplaceSpaces; //use method group conversion
//        string str;

//        // Call methods through the delegate. 
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        strOp = RemoveSpaces; //use method group conversion
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        strOp = Reverse; //use method group conversion
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);

//        Console.ReadKey();
//    }
//}

/*

Pay special attention to the way that strOp is created and assigned the method
ReplaceSpaces() in this line:

StrMod strOp = ReplaceSpaces; // use method group conversion

The name of the method is assigned directly to strOp. C# automatically provides a
conversion from the method to the delegate type. This syntax can be generalized to
any situation in which a method is assigned to (or converted to) a delegate type.

Because the method group conversion syntax is simpler than the old approach, it is
used throughout the remainder of this book.

*/

#endregion