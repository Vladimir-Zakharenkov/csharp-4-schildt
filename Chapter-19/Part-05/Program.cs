#region Russian

/*

 Сортировка результатов запроса с помощью оператора orderby

 Зачастую результаты запроса требуют сортировки. Допустим, что требуется получить
 список просроченных счетов по порядку остатка на счету: от самого большого до
 самого малого или же список имен заказчиков в алфавитном порядке. Независимо от
 преследуемой цели, результаты запроса можно очень легко отсортировать, используя
 такое средство LINQ, как оператор orderby.

 Оператор orderby можно использовать для сортировки результатов запроса по
 одному или нескольким критериям. Рассмотрим для начала самый простой случай
 сортировки по одному элементу. Ниже приведена общая форма оператора orderby
 для сортировки результатов запроса по одному критерию:

 orderby элемент порядок

 где элемент обозначает конкретный элемент, по которому проводится сортировка.
 Это может быть весь элемент, хранящийся в источнике данных, или только часть одного
 поля в данном элементе. А порядок обозначает порядок сортировки по нарастающей
 или убывающей с обязательным добавлением ключевого слова ascending или
 descending соответственно. По умолчанию сортировка проводится по нарастающей,
 и поэтому ключевое слово ascending, как правило, не указывается.

 Ниже приведен пример программы, в которой оператор orderby используется
 для извлечения значений из массива типа int по нарастающей.

*/

// Продемонстрировать применение оператора orderby.

using System;
using System.Linq;

class OrderByDemo
{
    static void Main()
    {
        int[] nums = { 10, -19, 4, 7, 2, -5, 0 };

        //Сформировать запрос для получения значений в отсортированном порядке.
        var posNums = from n in nums
                      orderby n
                      select n;

        Console.Write("Значения по нарастающей: ");

        //Выполнить запрос и вывести его результаты.
        foreach (int i in posNums)
        {
            Console.Write(i + " ");
        }

        Console.ReadKey();
    }
}

/*

 При выполнении этой программы получается следующий результат.

 Значения по нарастающей: -19 - 5 0 2 4 7 10

 Для того чтобы изменить порядок сортировки по нарастающей на сортировку по
 убывающей, достаточно указать ключевое слово descending, как показано ниже.

 var posNums = from n in nums
 orderby n descending
 select n;

Попробовав выполнить этот запрос, вы получите значения в обратном порядке.

*/

#endregion

#region English

/*

Sort Results with orderby

Often you will want the results of a query to be sorted. For example, you might want to
obtain a list of past-due accounts, in order of the remaining balance, from greatest to least.
Or, you might want to obtain a customer list, alphabetized by name. Whatever the purpose,
LINQ gives you an easy way to produce sorted results: the orderby clause.

You can use orderby to sort on one or more criteria. We will begin with the simplest
case: sorting on a single item. The general form of orderby that sorts based on a single
criterion is shown here:

orderby sort-on how

The item on which to sort is specified by sort-on. This can be as inclusive as the entire element
stored in the data source or as restricted as a portion of a single field within the element.
The value of how determines if the sort is ascending or descending, and it must be either
ascending or descending. The default direction is ascending, so you won’t normally specify
ascending.

Here is an example that uses orderby to retrieve the values in an int array in ascending
order:

*/

// Demonstrate orderby. 

//using System;  
//using System.Linq;  

//class OrderbyDemo
//{

//    static void Main()
//    {

//        int[] nums = { 10, -19, 4, 7, 2, -5, 0 };

//        // Create a query that obtains the values in sorted order. 
//        var posNums = from n in nums
//                      orderby n
//                      select n;

//        Console.Write("Values in ascending order: ");

//        // Execute the query and display the results. 
//        foreach (int i in posNums) Console.Write(i + " ");

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

Values in ascending order: -19 -5 0 2 4 7 10

To change the order to descending, simply specify the descending option, as shown here:

var posNums = from n in nums
orderby n descending
select n;

If you try this, you will see that the order of the values is reversed.

*/

#endregion