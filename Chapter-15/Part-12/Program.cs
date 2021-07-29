#region Russian

/*

И в заключение рассмотрим еще один пример, демонстрирующий блочное лямбда-выражение 
в действии. Ниже приведен вариант первого примера из этой главы, измененного
с целью использовать блочные лямбда-выражения вместо автономных методов
для выполнения различных операций со строками.

*/

// Первый пример применения делегатов, переделанный с целью использовать блочные лямбда-выражения.

using System;

//Объявить тип делегата.
delegate string StrMod(string str);

class UseStatementLambdas
{
    static void Main()
    {
        // Создать делегаты, ссылающиеся на лямбда-выражения,
        // выполняющие различные операции с символьными строками.

        //Заменить пробелы дефисами

        StrMod ReplaceSpaces = s =>
        {
            Console.WriteLine("Замена пробелов дефисами."); ;
            return s.Replace(' ', '-');
        };


        //Удалить пробелы
        StrMod RemoveSpaces = s =>
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
        };

        //Обратить строку
        StrMod Reverse = s =>
        {
            string temp = "";
            int i;

            Console.WriteLine("Обращение строки.");
            for (i = s.Length - 1; i >= 0; i--)
            {
                temp += s[i];
            }

            return temp;
        };

        string str;

        // Обратиться к лямбда-выражениям с помощью делегатов.

        StrMod strOp = ReplaceSpaces;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        strOp = RemoveSpaces;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        strOp = Reverse;
        str = strOp("Это простой тест.");
        Console.WriteLine("Результирующая строка: " + str);

        Console.ReadKey();
    }
}

/*

Результат выполнения кода этого примера оказывается таким же, как и в первом
примере применения делегатов.

Замена пробелов дефисами.
Результирующая строка: Это-простой-тест.

Удаление пробелов.
Результирующая строка: Этопростойтест.

Обращение строки.
Результирующая строка: .тсет йотсорп отЭ

*/

#endregion

#region English

/*

Before concluding, it is worthwhile to see another example that shows the statement
lambda in action. The following program reworks the first delegate example in this chapter
so it uses statement lambdas (rather than standalone methods) to accomplish various string
modifications:

*/

// The first delegate example rewritten to use  
// statement lambdas. 

//using System; 

//// Declare a delegate type.  
//delegate string StrMod(string s);

//class UseStatementLambdas
//{

//    static void Main()
//    {
//        // Create delegates that refer to lambda expressions 
//        // that perform various string modifications. 

//        // Replaces spaces with hyphens. 
//        StrMod ReplaceSpaces = s =>
//        {
//            Console.WriteLine("Replacing spaces with hyphens.");
//            return s.Replace(' ', '-');
//        };

//        // Remove spaces. 
//        StrMod RemoveSpaces = s =>
//        {
//            string temp = "";
//            int i;

//            Console.WriteLine("Removing spaces.");
//            for (i = 0; i < s.Length; i++)
//                if (s[i] != ' ') temp += s[i];

//            return temp;
//        };


//        // Reverse a string. 
//        StrMod Reverse = s =>
//        {
//            string temp = "";
//            int i, j;

//            Console.WriteLine("Reversing string.");
//            for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
//                temp += s[i];

//            return temp;
//        };

//        string str;

//        // Call methods through the delegate. 
//        StrMod strOp = ReplaceSpaces;
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        strOp = RemoveSpaces;
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        strOp = Reverse;
//        str = strOp("This is a test.");
//        Console.WriteLine("Resulting string: " + str);

//        Console.ReadKey();
//    }
//}

/*

The output, which is the same as the original version, is shown here:

Replacing spaces with hyphens.
Resulting string: This-is-a-test.

Removing spaces.
Resulting string: Thisisatest.

Reversing string.
Resulting string: .tset a si sihT

*/

#endregion