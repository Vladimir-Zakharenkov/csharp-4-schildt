#region Russian

/*

 Объединение двух последовательностей с помощью оператора join

 Когда приходится иметь дело с базами данных, то зачастую требуется формировать
 последовательность, увязывающую данные из разных источников. Например,
 в Интернет-магазине может быть организована одна база данных, связывающая наименование
 товара с его порядковым номером, и другая база данных, связывающая порядковый
 номер товара с состоянием его запасов на складе. В подобной ситуации может
 возникнуть потребность составить список, в котором состояние запасов товаров на
 складе отображается по их наименованию, а не порядковому номеру. Для этой цели
 придется каким-то образом "увязать" данные из двух разных источников (баз данных).
 И это нетрудно сделать с помощью такого средства LINQ, как оператор join.

 Ниже приведена общая форма оператора join (совместно с оператором from).

 from переменная_диапазона_А in источник_данных_А
 join переменная_диапазона_В in источник_данных_В
 on переменная_диапазона_А.свойство equals переменная_диапазона_В.свойство

 Применяя оператор join, следует иметь в виду, что каждый источник должен содержать
 общие данные, которые можно сравнивать. Поэтому в приведенной выше
 форме этого оператора источник_данных_А и источник_данных_В должны иметь
 нечто общее, что подлежит сравнению. Сравниваемые элементы данных указываются
 в части on данного оператора. Поэтому если переменная_диапазона_А.свойство
 и переменная_диапазона_B.свойство равны, то эти элементы данных "увязываются"
 успешно. По существу, оператор join выполняет роль своеобразного фильтра,
 отбирая только те элементы данных, которые имеют общее значение.
 Как правило, оператор join возвращает последовательность, состоящую из данных,
 полученных из двух источников. Следовательно, с помощью оператора join можно
 сформировать новый список, состоящий из элементов, полученных из двух разных
 источников данных. Это дает возможность организовать данные по-новому.
 Ниже приведена программа, в которой создается класс Item, инкапсулирующий
 наименование товара и его порядковый номер. Затем в этой программе создается
 еще один класс InStockStatus, связывающий порядковый номер товара с булевым
 свойством, которое указывает на наличие или отсутствие товара на складе. И наконец,
 в данной программе создается класс Temp с двумя полями: строковым(string) и
 булевым(bool). В объектах этого класса будут храниться результаты запроса. В этом
 запросе оператор join используется для получения списка, в котором наименование
 товара связывается с состоянием его запасов на складе.

*/

// Продемонстрировать применение оператора join.

using System;
using System.Linq;

//Класс, связывающий наименование товара с его порядковым номером.
class Item
{
    public string Name { get; set; }
    public int ItemNumber { get; set; }

    public Item(string n, int inum)
    {
        Name = n;
        ItemNumber = inum;
    }
}

//Класс, связывающий наименование товара с состоянием его запасов на складе.
class InStockStatus
{
    public int ItemNumber { get; set; }
    public bool InStock { get; set; }

    public InStockStatus(int n, bool b)
    {
        ItemNumber = n;
        InStock = b;
    }
}

//Класс, инкапсулирующий наименование товара и
//состояние его запасов на складе.
class Temp
{
    public string Name { get; set; }
    public bool InStock { get; set; }

    public Temp(string n, bool b)
    {
        Name = n;
        InStock = b;
    }
}

class JoinDemo
{
    static void Main()
    {
        Item[] items =
        {
            new Item("Кусачки", 1424),
            new Item("Тиски", 7892),
            new Item("Молоток", 8534),
            new Item("Пила", 6411)
        };

        InStockStatus[] statusList =
        {
            new InStockStatus(1424, true),
            new InStockStatus(7892, false),
            new InStockStatus(8534, true),
            new InStockStatus(6411, true)
        };

        //Сформировать запрос, объединяющий объекты классов Item
        //и InStockStatus для составления списка наименований товаров
        //и их наличия на складе. Обратите внимание на формирование
        //последовательности объектов класса Temp.
        var inStockList = from item in items
                          join entry in statusList
                          on item.ItemNumber equals entry.ItemNumber
                          select new Temp(item.Name, entry.InStock);

        Console.WriteLine("Товар\t\tНаличие\n");

        //Выполнить запрос и вывести его результаты.
        foreach (Temp t in inStockList)
        {
            Console.WriteLine("{0}\t\t{1}", t.Name, t.InStock);
        }

        Console.ReadKey();
    }

}

/*

 Эта программа дает следующий результат.

 Товар    Наличие

 Кусачки  True
 Тиски    False
 Молоток  True
 Пила     True

 Для того чтобы стал понятнее принцип действия оператора join, рассмотрим каждую
 строку запроса из приведенной выше программы по порядку. Этот запрос начинается,
 как обычно, со следующего оператора from.

 var inStockList = from item in items

 В этом операторе указывается переменная диапазона item для источника данных
 items, который представляет собой массив объектов класса Item. В классе Item инкапсулируются
 наименование товара и порядковый номер товара, хранящегося на
 складе.

 Далее следует приведенный ниже оператор join.

 join entry in statusList
 on item.ItemNumber equals entry.ItemNumber

 В этом операторе указывается переменная диапазона entry для источника данных
 statusList, который представляет собой массив объектов класса InStockStatus,
 связывающего порядковый номер товара с состоянием его запасов на складе. Следовательно,
 у массивов items и statusList имеется общее свойство: порядковый номер
 товара. Именно это свойство используется в части on/equals оператора join для
 описания связи, по которой из двух разных источников данных выбираются наименования
 товаров, когда их порядковые номера совпадают.

 И наконец, оператор select возвращает объект класса Temp, содержащий наименование
 товара и состояние его запасов на складе.

select new Temp(item.Name, entry.InStock);

 Таким образом, последовательность результатов, получаемая по данному запросу,
 состоит из объектов типа Temp.

 Рассмотренный здесь пример применения оператора join довольно прост. Тем не
 менее этот оператор поддерживает и более сложные операции с источниками данных.
 Например, используя совместно операторы into и join, можно создать групповое
 объединение, чтобы получить результат, состоящий из первой последовательности и
 группы всех совпадающих элементов из второй последовательности. (Соответствующий
 пример будет приведен далее в этой главе.) Как правило, время и усилия, затраченные
 на полное освоение оператора join, окупаются сторицей, поскольку он дает
 возможность распознавать данные во время выполнения программы. Это очень ценная
 возможность. Но она становится еще ценнее, если используются анонимные типы, о
 которых речь пойдет в следующем разделе.

*/

#endregion

#region English

/*

Join Two Sequences with join

When working with databases, it is common to want to create a sequence that correlates
data from two different data sources. For example, an online store might have one database
that associates the name of an item with its item number, and a second database that
associates the item number with its in-stock status. Given this situation, you might want to
generate a list that shows the in-stock status of items by name, rather than by item number.
You can do this by correlating the data in the two databases. Such an action is easy to
accomplish in LINQ through the use of the join clause.

The general form of join is shown here (in context with the from):

from range-varA in data-sourceA
join range-varB in data-sourceB
on range-varA.property equals range-varB.property

The key to using join is to understand that each data source must contain data in common,
and that the data can be compared for equality. Thus, in the general form, data-sourceA and
data-sourceB must have something in common that can be compared. The items being
compared are specified by the on section. Thus, when range-varA.property is equal to rangevarB.
property, the correlation succeeds. In essence, join acts like a filter, allowing only those
elements that share a common value to pass through.

When using join, often the sequence returned is a composite of portions of the two data
sources. Therefore, join lets you generate a new list that contains elements from two different
data sources. This enables you to organize data in a new way.

The following program creates a class called Item, which encapsulates an item’s name
with its number. It creates another class called InStockStatus, which links an item number
with a Boolean property that indicates whether or not the item is in stock. It also creates a
class called Temp, which has two fields: one string and one bool. Objects of this class will
hold the result of the query. The query uses join to produce a list in which an item’s name
is associated with its in-stock status.

*/

// Demonstrate join. 

//using System;  
//using System.Linq;  

//// A class that links an item name with its number. 
//class Item
//{
//    public string Name { get; set; }
//    public int ItemNumber { get; set; }

//    public Item(string n, int inum)
//    {
//        Name = n;
//        ItemNumber = inum;
//    }
//}

//// A class that links an item number with its in-stock status. 
//class InStockStatus
//{
//    public int ItemNumber { get; set; }
//    public bool InStock { get; set; }

//    public InStockStatus(int n, bool b)
//    {
//        ItemNumber = n;
//        InStock = b;
//    }
//}

//// A class that encapsulates a name with its status. 
//class Temp
//{
//    public string Name { get; set; }
//    public bool InStock { get; set; }

//    public Temp(string n, bool b)
//    {
//        Name = n;
//        InStock = b;
//    }
//}

//class JoinDemo
//{
//    static void Main()
//    {

//        Item[] items = {
//         new Item("Pliers", 1424),
//         new Item("Hammer", 7892),
//         new Item("Wrench", 8534),
//         new Item("Saw", 6411)
//    };

//        InStockStatus[] statusList = {
//         new InStockStatus(1424, true),
//         new InStockStatus(7892, false),
//         new InStockStatus(8534, true),
//         new InStockStatus(6411, true)
//    };


//        // Create a query that joins Item with InStockStatus to 
//        // produce a list of item names and availability. Notice 
//        // that a sequence of Temp objects is produced. 
//        var inStockList = from item in items
//                          join entry in statusList
//                            on item.ItemNumber equals entry.ItemNumber
//                          select new Temp(item.Name, entry.InStock);

//        Console.WriteLine("Item\tAvailable\n");

//        // Execute the query and display the results. 
//        foreach (Temp t in inStockList)
//            Console.WriteLine("{0}\t{1}", t.Name, t.InStock);

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

Item    Available

Pliers  True
Hammer  False
Wrench  True
Saw     True

To understand how join works, let’s walk through each line in the query. The query
begins in the normal fashion with this from clause:

var inStockList = from item in items

This clause specifies that item is the range variable for the data source specified by items.
The items array contains objects of type Item, which encapsulate a name and a number for
an inventory item.

Next comes the join clause shown here:

join entry in statusList
on item.ItemNumber equals entry.ItemNumber

This clause specifies that entry is the range variable for the statusList data source. The
statusList array contains objects of type InStockStatus, which link an item number with
its status. Thus, items and statusList have a property in common: the item number. This
is used by the on/equals portion of the join clause to describe the correlation. Thus, join
matches items from the two data sources when their item numbers are equal.

Finally, the select clause returns a Temp object that contains an item’s name along with
its in-stock status:

select new Temp(item.Name, entry.InStock);

Therefore, the sequence obtained by the query consists of Temp objects.

Although the preceding example is fairly straightforward, join supports substantially
more sophisticated operations. For example, you can use into with join to create a group
join, which creates a result that consists of an element from the first sequence and a group of
all matching elements from the second sequence. (You’ll see an example of this a bit later in
this chapter.) In general, the time and effort needed to fully master join is well worth the
investment because it gives you the ability to reorganize data at runtime. This is a powerful
capability. This capability is made even more powerful by the use of anonymous types,
described in the next section.

*/

#endregion