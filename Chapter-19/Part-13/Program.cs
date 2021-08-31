#region Russian

/*

 Применение оператора let для создания временной переменной в запросе

 Иногда возникает потребность временно сохранить некоторое значение в самом
 запросе. Допустим, что требуется создать переменную перечислимого типа, которую
 можно будет затем запросить, или же сохранить некоторое значение, чтобы в дальнейшем
 использовать его в операторе where. Независимо от преследуемой цели, эти
 виды функций могут быть осуществлены с помощью оператора let. Ниже приведена
 общая форма оператора let:

 let имя = выражение

 где имя обозначает идентификатор, получающий значение, которое дает выражение.
 Тип имени выводится из типа выражения.

 В приведенном ниже примере программы демонстрируется применение оператора
 let для создания еще одного перечислимого источника данных. В качестве входных
 данных в запрос вводится массив символьных строк, которые затем преобразуются в
 массивы типа char. Для этой цели служит еще один метод обработки строк, называемый
 ToCharArray() и возвращающий массив, содержащий символы в строке. Полученный
 результат присваивается переменной chrArray, которая затем используется
 во вложенном операторе from для извлечения отдельных символов из массива. И наконец,
 полученные символы сортируются в запросе, и из них формируется результирующая
 последовательность.

*/

// Использовать оператор let в месте с вложенным оператором from.

using System;
using System.Linq;

class LetDemo
{
    static void Main()
    {
        string[] strs = { "alpha", "beta", "gamma" };

        //Сформировать запрос на получение символов, возвращаемых из
        //строк в отсортированной последовательности. Обратите внимание
        //на применение вложенного оператора from.
        var chrs = from str in strs
                   let chrArray = str.ToCharArray()
                   from ch in chrArray
                   orderby ch
                   select ch;

        Console.WriteLine("Отдельные символы отсортированные по порядку:");

        //Выполнить запрос и вывести его результаты.
        foreach (char c in chrs)
        {
            Console.Write(c + " ");
        }

        Console.ReadKey();
    }
}

/*

 Вот к какому результату приводит выполнение этой программы.

 Отдельные символы, отсортированные по порядку:
 a a a a a b e g h l m m p t

 Обратите внимание в данном примере программы на то, что в операторе let переменной
 chrArray присваивается ссылка на массив, возвращаемый методом str.ToCharArray().

 let chrArray = str.ToCharArray()

 После оператора let переменная chrArray может использоваться в остальных
 операторах, составляющих запрос. А поскольку все массивы в C# преобразуются в тип
 IEnumerable<T>, то переменную chrArray можно использовать в качестве источника
 данных для запроса во втором, вложенном операторе from. Именно это и происходит
 в рассматриваемом здесь примере, где вложенный оператор from служит для перечисления
 в массиве отдельных символов, которые затем сортируются по нарастающей
 и возвращаются в виде конечного результата.

*/

#endregion

#region English

/*

Use let to Create a Variable in a Query

In a query, you will sometimes want to retain a value temporarily. For example, you might
want to create an enumerable variable that can, itself, be queried. Or, you might want to
store a value that will be used later on in a where clause. Whatever the purpose, these types
of actions can be accomplished through the use of let.

The let clause has this general form:

let name = expression

Here, name is an identifier that is assigned the value of expression. The type of name is
inferred from the type of the expression.

Here is an example that shows how let can be used to create another enumerable data
source. The query takes as input an array of strings. It then converts those strings into char
arrays. This is accomplished by use of another string method called ToCharArray( ), which
returns an array containing the characters in the string. The result is assigned to a variable
called chrArray, which is then used by a nested from clause to obtain the individual characters
in the array. The query then sorts the characters and returns the resulting sequence.

*/


// Use a let clause and a nested from clause. 

//using System;  
//using System.Linq;  

//class LetDemo
//{

//    static void Main()
//    {

//        string[] strs = { "alpha", "beta", "gamma" };

//        // Create a query that obtains the characters in the 
//        // strings, returned in sorted order. Notice the use 
//        // of a nested from clause. 
//        var chrs = from str in strs
//                   let chrArray = str.ToCharArray()
//                   from ch in chrArray
//                   orderby ch
//                   select ch;

//        Console.WriteLine("The individual characters in sorted order:");

//        // Execute the query and display the results. 
//        foreach (char c in chrs) Console.Write(c + " ");

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

The individual characters in sorted order:
a a a a a b e g h l m m p t

In the program, notice how the let clause assigns to chrArray a reference to the array
returned by str.ToCharArray( ):

let chrArray = str.ToCharArray()

After the let clause, other clauses can make use of chrArray. Furthermore, because all arrays
in C# are convertible to IEnumerable<T>, chrArray can be used as a data source for a second,
nested from clause. This is what happens in the example. It uses the nested from to enumerate
the individual characters in the array, sorting them into ascending sequence and returning
the result.

*/

#endregion