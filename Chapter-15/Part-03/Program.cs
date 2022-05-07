#region Russian

/*

Применение методов экземпляра в качестве делегатов

В предыдущем примере использовались статические методы, но делегат может
ссылаться и на методы экземпляра, хотя для этого требуется ссылка на объект. Так,
ниже приведен измененный вариант предыдущего примера, в котором операции со
строками инкапсулируются в классе StringOps. Следует заметить, что в данном случае
может быть также использован синтаксис группового преобразования методов.

*/

// Делегаты могут ссылаться и на методы экземпляра.

using System;

//Объявить тип делегата.
delegate string StrMod(string str);

class StringOps
{
    //Заменить пробелы дефисами
    public string ReplaceSpaces(string s)
    {
        Console.WriteLine("Замена пробелов дефисами.");
        return s.Replace(' ', '-');
    }

    //Удалить пробелы
    public string RemoveSpaces(string s)
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
    public string Reverse(string s)
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
}

class DelegateTest
{
    static void Main()
    {
        StringOps so = new StringOps(); //создать экземпляр объекта класса StringOps

        //Инициализировать делегат.
        StrMod strOp = so.ReplaceSpaces;
        string str;

        //Вызвать методы с помощью делегата.
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        strOp = so.RemoveSpaces;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        strOp = so.Reverse;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);

        Console.ReadKey();
    }
}

/*

Результат выполнения этого кода получается таким же, как и в предыдущем примере,
но на этот раз делегат обращается к методам по ссылке на экземпляр объекта
класса StringOps.

*/

#endregion

#region English

/*

Using Instance Methods as Delegates

Although the preceding example used static methods, a delegate can also refer to instance
methods. It must do so, however, through an object reference. For example, here is a rewrite
of the previous example, which encapsulates the string operations inside a class called
StringOps. Notice that the method group conversion syntax can also be applied in this
situation.

*/

// Delegates can refer to instance methods, too. 

//using System; 

//// Declare a delegate type.  
//delegate string StrMod(string str);

//class StringOps
//{
//    // Replaces spaces with hyphens. 
//    public string ReplaceSpaces(string s)
//    {
//        Console.WriteLine("Replacing spaces with hyphens.");
//        return s.Replace(' ', '-');
//    }

//    // Remove spaces. 
//    public string RemoveSpaces(string s)
//    {
//        string temp = "";
//        int i;

//        Console.WriteLine("Removing spaces.");
//        for (i = 0; i < s.Length; i++)
//            if (s[i] != ' ') temp += s[i];

//        return temp;
//    }

//    // Reverse a string. 
//    public string Reverse(string s)
//    {
//        string temp = "";
//        int i, j;

//        Console.WriteLine("Reversing string.");
//        for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
//            temp += s[i];

//        return temp;
//    }
//}

//class DelegateTest
//{
//    static void Main()
//    {
//        StringOps so = new StringOps(); // create an instance of StringOps 

//        // Initialize a delegate. 
//        StrMod strOp = so.ReplaceSpaces;
//        string str;

//        // Call methods through delegates. 
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        strOp = so.RemoveSpaces;
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        strOp = so.Reverse;
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//    }
//}

/*

This program produces the same output as the first, but in this case, the delegate refers
to methods on an instance of StringOps.

*/

#endregion