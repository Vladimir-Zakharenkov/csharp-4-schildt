# region Russian

/*

 Группирование результатов с помощью оператора group

 Одним из самых эффективных средств формирования запроса является оператор
 group, поскольку он позволяет группировать полученные результаты по ключам. Используя
 последовательность сгруппированных результатов, можно без особого труда
 получить доступ ко всем данным, связанным с ключом. Благодаря этому свойству
 оператора group доступ к данным, организованным в последовательности связанных
 элементов, осуществляется просто и эффективно. Оператор group является одним из
 двух операторов, которыми может оканчиваться запрос. (Вторым оператором, завершающим
 запрос, является select.) Ниже приведена общая форма оператора group.

 group переменная_диапазона by ключ

 Этот оператор возвращает данные, сгруппированные в последовательности, причем
 каждую последовательность обозначает общий ключ.

 Результатом выполнения оператора group является последовательность, состоящая
 из элементов типа IGrouping<TKey, TElement>, т.е. обобщенного интерфейса,
 объявляемого в пространстве имен System.Linq. В этом интерфейсе определена коллекция
 объектов с общим ключом. Типом переменной запроса, возвращающего группу,
 является IEnumerable<IGrouping<TKey, TElement>>. В интерфейсе IGrouping
 определено также доступное только для чтения свойство Key, возвращающее ключ,
 связанный с каждой коллекцией.

 Ниже приведен пример, демонстрирующий применение оператора group. В коде
 этого примера сначала объявляется массив, содержащий список веб-сайтов, а затем
 формируется запрос, в котором этот список группируется по имени домена самого
 верхнего уровня, например .org или .com.

*/

// Продемонстрировать применение оператора group.

using System;
using System.Linq;

class GroupDemo
{
    static void Main()
    {
        string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
                              "hsNameD.com", "hsNameE.org", "hsNameF.org",
                              "hsNameG.tv", "hsNameH.net", "hsNameI.tv" };

        //Сформировать запрос на получение списка веб-сайтов,
        //группируемых по имени домена самого верхнего уровня.
        var webAddrs = from addr in websites
                       where addr.LastIndexOf('.') != -1
                       group addr by addr.Substring(addr.LastIndexOf('.'));

        //Выполнить запрос и вывести его результаты.
        foreach (var sites in webAddrs)
        {
            Console.WriteLine("Веб-сайты, сгруппированные по имени домена " + sites.Key);

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

 Вот к какому результату приводит выполнение этого кода.

 Веб-сайты, сгруппированные по имени домена .соm
 hsNameA.com
 hsNameD.com

 Веб-сайты, сгруппированные по имени домена .net
 hsNameB.net
 hsNameC.net
 hsNameH.net

 Веб-сайты, сгруппированные по имени домена .org
 hsNameE.org
 hsNameF.org

 Веб-сайты, сгруппированные по имени домена .tv
 hsNameG.tv
 hsNameI.tv

 Как следует из приведенного выше результата, данные, получаемые по запросу,
 группируются по имени домена самого верхнего уровня в адресе веб-сайта. Обратите
 внимание на то, как это делается в операторе group из следующего запроса.

 var webAddrs = from addr in websites
 where addr.LastlndexOf('.') != -1
 group addr by addr.Substring(addr.LastIndexOf('.'));

 Ключ в этом операторе создается с помощью методов LastIndexOf()
 и Substring(), определенных для данных типа string. (Эти методы упоминаются
 в главе 7, посвященной массивам и строкам. Вариант метода Substring(), используемый
 в данном примере, возвращает подстроку, начинающуюся с места, обозначаемого
 индексом, и продолжающуюся до конца вызывающей строки.) Индекс последней
 точки в адресе веб-сайта определяется с помощью метода LastIndexOf().
 По этому индексу в методе Substring() создается оставшаяся часть строки, в которой
 содержится имя домена самого верхнего уровня. Обратите внимание на то,
 что в операторе where отсеиваются все строки, которые не содержат точку. Метод
 LastIndexOf() возвращает - 1, если указанная подстрока не содержится в вызывающей
 строке.

 Последовательность результатов, получаемых при выполнении запроса, хранящегося
 в переменной webAddrs, представляет собой список групп, поэтому для доступа
 к каждому члену группы требуются два цикла foreach. Доступ к каждой группе осуществляется
 во внешнем цикле, а члены внутри группы перечисляются во внутреннем
 цикле. Переменная шага внешнего цикла foreach должна быть экземпляром интерфейса
 IGrouping, совместимым с ключом и типом элемента данных. В рассматриваемом
 здесь примере ключи и элементы данных относятся к типу string. Поэтому
 переменная sites шага внешнего цикла имеет тип IGrouping<string, string>,
 а переменная site шага внутреннего цикла — тип string. Ради краткости данного
 примера обе переменные объявляются неявно, хотя их можно объявить и явным образом,
 как показано ниже.

 foreach (IGrouping<string, string> sites in webAddrs)
 {
     Console.WriteLine("Веб-сайты, сгруппированные " +
     "по имени домена" + sites.Key);
     foreach (string site in sites)
         Console.WriteLine(" " + site);
     Console.WriteLine();
 }

*/

#endregion

#region English

/*

Group Results with group

One of the most powerful query features is provided by the group clause because it enables
you to create results that are grouped by keys. Using the sequence obtained from a group,
you can easily access all of the data associated with a key. This makes group an easy and
effective way to retrieve data that is organized into sequences of related items. The group
clause is one of only two clauses that can end a query. (The other is select.)

The group clause has the following general form:

group range-variable by key

It returns data grouped into sequences, with each sequence sharing the key specified by key.

The result of group is a sequence that contains elements of type IGrouping<TKey,
TElement>, which is declared in the System.Linq namespace. It defines a collection of
objects that share a common key. The type of query variable in a query that returns a group
is IEnumerable<IGrouping<TKey, TElement>>. IGrouping defines a read-only property
called Key, which returns the key associated with each sequence.

Here is an example that illustrates the use of group. It declares an array that contains a
list of websites. It then creates a query that groups the list by top-level domain name, such
as .org or .com.

*/

// Demonstrate the group clause. 

//using System;  
//using System.Linq;  

//class GroupDemo
//{

//    static void Main()
//    {

//        string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
//                          "hsNameD.com", "hsNameE.org", "hsNameF.org",
//                          "hsNameG.tv",  "hsNameH.net", "hsNameI.tv" };

//        // Create a query that groups web sites by top-level domain name. 
//        var webAddrs = from addr in websites
//                       where addr.LastIndexOf('.') != -1
//                       group addr by addr.Substring(addr.LastIndexOf('.'));

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

The output is shown here:

Web sites grouped by .com
hsNameA.com
hsNameD.com

Web sites grouped by .net
hsNameB.net
hsNameC.net
hsNameH.net

Web sites grouped by .org
hsNameE.org
hsNameF.org

Web sites grouped by .tv
hsNameG.tv
hsNameI.tv

As the output shows, the data is grouped based on the top-level domain name of a
website. Notice how this is achieved by the group clause:

var webAddrs = from addr in websites
where addr.LastIndexOf('.') != -1
group addr by addr.Substring(addr.LastIndexOf('.'));

The key is obtained by use of the LastIndexOf( ) and Substring( ) methods defined by string.
(These are described in Chapter 7. The version of Substring( ) used here returns the substring
that starts at the specified index and runs to the end of the invoking string.) The index of the
last period in a website name is found using LastIndexOf( ). Using this index, the Substring( )
method obtains the remainder of the string, which is the part of the website name that
contains the top-level domain name. One other point: Notice the use of the where clause to
filter out any strings that don’t contain a period. The LastIndexOf( ) method returns –1 if
the specified string is not contained in the invoking string.

Because the sequence obtained when webAddrs is executed is a list of groups, you will
need to use two foreach loops to access the members of each group. The outer loop obtains
each group. The inner loop enumerates the members within the group. The iteration variable
of the outer foreach loop must be an IGrouping instance compatible with the key and
element type. In the example both the keys and elements are string. Therefore, the type of
the sites iteration variable of the outer loop is IGrouping<string, string>. The type of the
iteration variable of the inner loop is string. For brevity, the example implicitly declares
these variables, but they could have been explicitly declared as shown here:

foreach(IGrouping<string, string> sites in webAddrs) {
Console.WriteLine("Web sites grouped by " + sites.Key);
foreach(string site in sites)
Console.WriteLine(" " + site);
Console.WriteLine();
}

*/

#endregion