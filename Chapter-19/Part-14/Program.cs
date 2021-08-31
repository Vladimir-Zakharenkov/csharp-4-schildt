#region Russian

/*

 Оператор let может также использоваться для хранения неперечислимого значения.
 В качестве примера ниже приведен более эффективный вариант формирования
 запроса в программе IntoDemo из предыдущего раздела.

*/

//using System;
//using System.Linq;

//class IntiDemo
//{
//    static void Main()
//    {
//        string[] websites = {   "hsNameA.com", "hsNameB.net", "hsNameC.net",
//                                "hsNameD.com", "hsNameE.org", "hsNameF.org",
//                                "hsNameG.tv", "hsNameH.net", "hsNameI.tv"};

//        //Сформировать запрос на получение списка веб-сайтов, группируемых
//        //по имени домена самого верхнего уровня, но выбрать только те группы,
//        //которые состоят более чем из двух членов.
//        //Здесь ws - это переменная диапазона для ряда групп,
//        //возвращаемых при выполнении первой половины запроса.
//        var webAddrs = from addr in websites
//                       let idx = addr.LastIndexOf('.')
//                       where idx != -1
//                       group addr by addr.Substring(idx)
//                     into ws
//                       where ws.Count() > 2
//                       select ws;

//        //Выполнить запрос и вывести его результаты.
//        Console.WriteLine("Домены самого верхнего уровня с более чем двумя членами.\n");

//        foreach (var sites in webAddrs)
//        {
//            Console.WriteLine("Содержимое домена: " + sites.Key);

//            foreach (var site in sites)
//            {
//                Console.WriteLine("\t" + site);
//            }

//            Console.WriteLine();
//        }

//        Console.ReadKey();
//    }
//}

/*

 В этом варианте индекс последнего вхождения символа точки в строку присваивается
 переменной idx. Данное значение затем используется в методе Substring().
 Благодаря этому исключается необходимость дважды искать символ точки в строке.

*/

#endregion

#region English

/*

You can also use a let clause to hold a non-enumerable value. For example, the following
is a more efficient way to write the query used in the IntoDemo program shown in the
preceding section.

*/

using System;
using System.Linq;

class IntoDemo
{

    static void Main()
    {

        string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
                          "hsNameD.com", "hsNameE.org", "hsNameF.org",
                          "hsNameG.tv",  "hsNameH.net", "hsNameI.tv" };

        // Create a query that groups web sites by top-level domain name, 
        // but select only those groups that have more than two members. 
        // Here, ws is the range variable over the set of groups 
        // returned when the first half of the query is executed.  
        var webAddrs = from addr in websites
                       let idx = addr.LastIndexOf('.')
                       where idx != -1
                       group addr by addr.Substring(idx)
                    into ws
                       where ws.Count() > 2
                       select ws;

        // Execute the query and display the results. 
        Console.WriteLine("Top-level domains with more than 2 members.\n");

        foreach (var sites in webAddrs)
        {
            Console.WriteLine("Contents of " + sites.Key + " domain:");
            foreach (var site in sites)
                Console.WriteLine("  " + site);
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}

/*

In this version, the index of the last occurrence of a period is assigned to idx. This value
is then used by Substring( ). This prevents the search for the period from having to be
conducted twice.

*/

#endregion