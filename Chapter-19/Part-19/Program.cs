#region Russian

/*

 В приведенном ниже примере демонстрируется применение метода запроса
 GroupBy(). Это измененный вариант представленного ранее примера.

*/

// Продемонстрировать применение метода запроса GroupBy().
// Это переработанный вариант примера, представленного ранее
// для демонстрации синтаксиса запросов.

using System;
using System.Linq;

class GroupByDemo
{
    static void Main()
    {
        string[] websites = {
            "hsNameA.com", "hsNameB.net", "hsNameC.net",
            "hsNameD.com", "hsNameE.org", "hsNameF.org",
            "hsNameG.tv",  "hsNameH.net", "hsNameI.tv" };

        //Использовать методы запроса для группирования
        //веб-сайтов по имени домена самого верхнего уровня.
        var webAddrs = websites.Where(w => w.LastIndexOf('.') != -1).
            GroupBy(x => x.Substring(x.LastIndexOf(".")));

        //Выполнить запрос и вывести его результаты.
        foreach (var sites in webAddrs)
        {
            Console.WriteLine("Веб-сайты, сгруппированные по имени домена " + sites.Key);

            foreach (var site in sites)
            {
                Console.WriteLine(" " + site);
            }

            Console.WriteLine();

        }

        Console.ReadKey();
    }
}

/*

 Эта версия программы дает такой же результат, как и предыдущая. Единственное
 отличие между ними заключается в том, как формируется запрос. В данной версии
 для этой цели используются методы запроса.

Рассмотрим другой пример. Но сначала приведем еще раз запрос из представленного
ранее примера применения оператора join.

 var inStockList = from item in items
 join entry in statusList
 on item.ItemNumber equals entry.ItemNumber
 select new Temp(item.Name, entry.InStock);

 По этому запросу формируется последовательность, состоящая из объектов, инкапсулирующих
 наименование товара и состояние его запасов на складе. Вся эта информация
 получается путем объединения двух источников данных: items и statusList.
 Ниже приведен переделанный вариант данного запроса, в котором вместо синтаксиса,
 предусмотренного в C# для запросов, используется метод запроса Join().

 Использовать метод запроса Join() для составления списка
 наименований товаров и состояния их запасов на складе.

 var inStockList = items.Join(statusList,
 k1 => k1.ItemNumber,
 k2 => k2.ItemNumber,
 (k1, k2) => new Temp(k1.Name, k2.InStock) );

 В данном варианте именованный класс Temp используется для хранения результирующего
 объекта, но вместо него можно воспользоваться анонимным типом. Такой
 вариант запроса приведен ниже.

 var inStockList = items.Join(statusList,
 k1 => k1.ItemNumber,
 k2 => k2.ItemNumber,
 (k1, k2) => new { k1.Name, k2.InStock } );

*/

#endregion

#region English

/*

Here is an example that demonstrates the GroupBy() method. It reworks the group
example shown earlier.

*/

// Demonstrate the GroupBy() query method. 
// This program reworks the earlier version that used 
// the query syntax. 

//using System;  
//using System.Linq;  

//class GroupByDemo
//{

//    static void Main()
//    {

//        string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
//                              "hsNameD.com", "hsNameE.org", "hsNameF.org",
//                              "hsNameG.tv",  "hsNameH.net", "hsNameI.tv" };

//        // Use query methods to group web sites by top-level domain name. 
//        var webAddrs = websites.Where(w => w.LastIndexOf('.') != 1).
//               GroupBy(x => x.Substring(x.LastIndexOf('.')));

//        // Execute the query and display the results. 
//        foreach (var sites in webAddrs)
//        {
//            Console.WriteLine("Web sites grouped by " + sites.Key);
//            foreach (var site in sites)
//                Console.WriteLine("  " + site);
//            Console.WriteLine();
//        }

//        Console.ReadKey();
//    }
//}

/*

This version produces the same output as the earlier version. The only difference is how the
query is created. In this version, the query methods are used.
Here is another example. Recall the join query used in the JoinDemo example shown
earlier:

var inStockList = from item in items
join entry in statusList
on item.ItemNumber equals entry.ItemNumber
select new Temp(item.Name, entry.InStock);

This query produces a sequence that contains objects that encapsulate the name and the instock
status of an inventory item. This information is synthesized from joining the two lists
items and statusList. The following version reworks this query so that it uses the Join( )
method rather than the C# query syntax:

// Use Join() to produce a list of item names and status.
var inStockList = items.Join(statusList,
k1 => k1.ItemNumber,
k2 => k2.ItemNumber,
(k1, k2) => new Temp(k1.Name, k2.InStock) );

Although this version uses the named class called Temp to hold the resulting object, an
anonymous type could have been used instead. This approach is shown next:

var inStockList = items.Join(statusList,
k1 => k1.ItemNumber,
k2 => k2.ItemNumber,
(k1, k2) => new { k1.Name, k2.InStock} );

*/

#endregion