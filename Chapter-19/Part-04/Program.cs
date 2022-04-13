#region Russian

/*

 Как правило, в условии оператора where разрешается использовать любое допустимое
 в C# выражение, дающее булев результат. Например, в приведенной ниже программе
 определяется массив символьных строк. В ряде этих строк содержатся адреса
 Интернета. По запросу в переменой netAddrs извлекаются только те строки, которые
 содержат более четырех символов и оканчиваются на ".net". Следовательно, по данному
 запросу обнаруживаются строки, содержащие адреса Интернета с именем .net
 домена самого верхнего уровня.

*/

// Продемонстрировать применение еще одного оператора where.

using System;
using System.Linq;

class WhereDemo2
{
    static void Main()
    {
        string[] strs = { ".com", ".net", "hsNameA.com", "hsNameB.net", "test", ".network", "hsNameC.net", "hsNameD.com" };

        // Сформировать запрос на получение адресов Интернета, оканчивающихся на .net.
        var netAddrs = from addr in strs
                       where addr.Length > 4 && addr.EndsWith(".net", StringComparison.Ordinal)
                       select addr;

        // Выполнить запрос и вывести его результаты.
        foreach (var str in netAddrs)
        {
            Console.WriteLine(str);
        }

        Console.ReadKey();
    }
}

/*

 Вот к какому результату приводит выполнение этой программы.

 hsNameB.net
 hsNameC.net

 Обратите внимание на то, что в операторе where данной программы используется
 один из методов обработки символьных строк под названием EndsWith(). Он возвращает
 логическое значение true, если вызывающая его строка оканчивается последовательностью
 символов, указываемой в качестве аргумента этого метода.

*/

#endregion

#region English

/*

In general, a where condition can use any valid C# expression that evaluates to a
Boolean result. For example, the following program defines an array of strings. Several of
the strings define Internet addresses. The query netAddrs retrieves only those strings that
have more than four characters and that end with “.net”. Thus, it finds those strings that
contain Internet addresses that use the .net top-level domain name.

*/

// Demonstrate another where clause.

//using System;  
//using System.Linq;  

//class WhereDemo2
//{

//    static void Main()
//    {

//        string[] strs = { ".com", ".net", "hsNameA.com", "hsNameB.net",
//                    "test", ".network", "hsNameC.net", "hsNameD.com" };

//        Create a query that obtains Internet addresses that
//         end with .net.
//        var netAddrs = from addr in strs
//                       where addr.Length > 4 &&
//                             addr.EndsWith(".net", StringComparison.Ordinal)
//                       select addr;

//        Execute the query and display the results.
//        foreach (var str in netAddrs) Console.WriteLine(str);

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

hsNameB.net
hsNameC.net

Notice that the program makes use of one of string’s methods called EndsWith() within the
where clause. It returns true if the invoking string ends with the character sequence specified
as an argument.

*/

#endregion