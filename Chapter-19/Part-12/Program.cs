#region Russian

/*

 Продолжение запроса с помощью оператора into

 При использовании в запросе оператора select или group иногда требуется сформировать
 временный результат, который будет служить продолжением запроса для получения
 окончательного результата. Такое продолжение осуществляется с помощью
 оператора into в комбинации с оператором select или group. Ниже приведена общая
 форма оператора into:

 into имя тело_запроса

 где имя обозначает конкретное имя переменной диапазона, используемой для циклического
 обращения к временному результату в продолжении запроса, на которое
 указывает тело_запроса. Когда оператор into используется вместе с оператором
 select или group, то его называют продолжением запроса, поскольку он продолжает
 запрос. По существу, продолжение запроса воплощает в себе принцип построения
 нового запроса по результатам предыдущего.

 ПРИМЕЧАНИЕ

 Существует также форма оператора into, предназначенная для использования вместе с
 оператором join, создающим групповое объединение, о котором речь пойдет далее в этой
 главе.

 Ниже приведен пример программы, в которой оператор into используется вместе
 с оператором group. Эта программа является переработанным вариантом предыдущего
 примера, в котором список веб-сайтов формируется по имени домена самого
 верхнего уровня. А в данном примере первоначальные результаты запроса сохраняются
 в переменной диапазона ws и затем отбираются для исключения всех групп, состоящих
 менее чем из трех элементов.

*/

// Использовать оператор into вместе с оператором group.

using System;
using System.Linq;

class IntiDemo
{
    static void Main()
    {
        string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
                              "hsNameD.com", "hsNameE.org", "hsNameF.org",
                              "hsNameG.tv", "hsNameH.net", "hsNameI.tv" };

        //Сформировать запрос на получение списка веб-сайтов, группируемых
        //по имени домена самого верхнего уровня, но выбрать только те группы,
        //которые состоят более чем из двух членов.
        //Здесь ws - это переменная диапазона для ряда групп,
        //возвращаемых при выполнении первой половины запроса.
        var webAddrs = from addr in websites
                       where addr.LastIndexOf('.') != -1
                       group addr by addr.Substring(addr.LastIndexOf('.'))
                     into ws
                       where ws.Count() > 2
                       select ws;

        //Выполнить запрос и вывести его результаты.
        Console.WriteLine("Домены самого верхнего уровня с более чем двумя членами.\n");

        foreach (var sites in webAddrs)
        {
            Console.WriteLine("Содержимое домена: " + sites.Key);

            foreach (var site in sites)
            {
                Console.WriteLine("\t" + site);
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}

/*

 Эта программа дает следующий результат:

 Домены самого верхнего уровня с более чем двумя членами.

 Содержимое домена: .net
 hsNameB.net
 hsNameC.net
 hsNameH.net

 Как следует из результата выполнения приведенной выше программы, по запросу
 возвращается только группа.net, поскольку это единственная группа, содержащая
 больше двух элементов.
 Обратите особое внимание в данном примере программы на следующую последовательность
 операторов в формируемом запросе.

 group addr by addr.Substring(addr.LastIndexOf('.'))
  into ws
 where ws.Count() > 2
 select ws;

 Сначала результаты выполнения оператора group сохраняются как временные
 для последующей обработки оператором where. В качестве переменной диапазона
 в данный момент служит переменная ws. Она охватывает все группы, возвращаемые
 оператором group. Затем результаты запроса отбираются в операторе where с таким
 расчетом, чтобы в конечном итоге остались только те группы, которые содержат больше
 двух членов. Для этой цели вызывается метод Count(), который является методом
 расширения и реализуется для всех объектов типа IEnumerable. Он возвращает
 количество элементов в последовательности. (Подробнее о методах расширения речь
 пойдет далее в этой главе.) А получающаяся в итоге последовательность групп возвращается
 оператором select.

*/

#endregion

#region English

/*

Use into to Create a Continuation

When using select or group, you will sometimes want to generate a temporary result that
will be used by a subsequent part of the query to produce the final result. This is called a
query continuation (or just a continuation for short), and it is accomplished through the use
of into with a select or group clause. It has the following general form:

into name query-body

where name is the name of the range variable that iterates over the temporary result and is
used by the continuing query, specified by query-body. This is why into is called a query
continuation when used with select or group—it continues the query. In essence, a query
continuation embodies the concept of building a new query that queries the results of the
preceding query.

NOTE

There is also a form of into that can be used with join, which creates a group join. This is
described later in this chapter.

Here is an example that uses into with group. The following program reworks the
GroupDemo example shown earlier, which creates a list of websites grouped by top-level
domain name. In this case, the initial results are queried by a range variable called ws. This
result is then filtered to remove all groups that have fewer than three elements.

*/

// Use into with group. 

//using System;  
//using System.Linq;  

//class IntoDemo
//{

//    static void Main()
//    {

//        string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
//                          "hsNameD.com", "hsNameE.org", "hsNameF.org",
//                          "hsNameG.tv",  "hsNameH.net", "hsNameI.tv" };

//        // Create a query that groups web sites by top-level domain name, 
//        // but select only those groups that have more than two members. 
//        // Here, ws is the range variable over the set of groups 
//        // returned when the first half of the query is executed.  
//        var webAddrs = from addr in websites
//                       where addr.LastIndexOf('.') != -1
//                       group addr by addr.Substring(addr.LastIndexOf('.'))
//                                  into ws
//                       where ws.Count() > 2
//                       select ws;

//        // Execute the query and display the results. 
//        Console.WriteLine("Top-level domains with more than 2 members.\n");

//        foreach (var sites in webAddrs)
//        {
//            Console.WriteLine("Contents of " + sites.Key + " domain:");
//            foreach (var site in sites)
//                Console.WriteLine("  " + site);
//            Console.WriteLine();
//        }

//        Console.ReadKey();
//    }
//}

/*

The following output is produced:

Top-level domains with more than 2 members.

Contents of .net domain:
hsNameB.net
hsNameC.net
hsNameH.net

As the output shows, only the .net group is returned because it is the only group that has
more than two elements.

In the program, pay special attention to this sequence of clauses in the query:

group addr by addr.Substring(addr.LastIndexOf('.'))
into ws
where ws.Count() > 2
select ws;

First, the results of the group clause are stored (creating a temporary result) and the where
clause operates on the stored results. At this point, ws will range over each group obtained
by group. Next, the where clause filters the query so the final result contains only those
groups that contain more than two members. This determination is made by calling Count(),
which is an extension method that is implemented for all IEnumerable objects. It returns the
number of elements in a sequence. (You’ll learn more about extension methods later in this
chapter.) The resulting sequence of groups is returned by the select clause.

*/

#endregion