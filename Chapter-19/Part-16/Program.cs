#region Russian

/*

Анонимные типы

 В C# предоставляется средство, называемое анонимным типом и связанное непосредственно
 с LINQ. Как подразумевает само название, анонимный тип представляет
 собой класс, не имеющий имени. Его основное назначение состоит в создании объекта,
 возвращаемого оператором select. Результатом запроса нередко оказывается последовательность
 объектов, которые составляются из членов, полученных из двух или
 более источников данных (как, например, в операторе join), или же включают в себя
 подмножество членов из одного источника данных. Но в любом случае тип возвращаемого
 объекта зачастую требуется только в самом запросе и не используется в остальной
 части программы. Благодаря анонимному типу в подобных случаях отпадает необходимость
 объявлять класс, который предназначается только для хранения результата запроса.

 Анонимный тип объявляется с помощью следующей общей формы:

 new { имя_А = значение_А, имя_В = значение_В, ... }

 где имена обозначают идентификаторы, которые преобразуются в свойства, доступные
 только для чтения и инициализируемые значениями, как в приведенном ниже примере.

 new { Count = 10, Max = 100, Min = 0 }

 данном примере создается класс с тремя открытыми только для чтения свойствами:
 Count, Мах и Min, которым присваиваются значения 10, 100 и 0 соответственно.
 К этим свойствам можно обращаться по имени из другого кода. Следует заметить, что
 в анонимном типе используются инициализаторы объектов для установки их полей
 и свойств в исходное состояние. Как пояснялось в главе 8, инициализаторы объектов
 обеспечивают инициализацию объекта без явного вызова конструктора. Именно это и
 требуется для анонимных типов, поскольку явный вызов конструктора для них невозможен.
 (Напомним, что у конструкторов такое же имя, как и у их класса. Но у анонимного
 класса нет имени, а значит, и нет возможности вызвать его конструктор.)

 Итак, у анонимного типа нет имени, и поэтому для обращения к нему приходится
 использовать неявно типизированную переменную. Это дает компилятору возможность
 вывести надлежащий тип. В приведенном ниже примере объявляется переменная
 myOb, которой присваивается ссылка на объект, создаваемый в выражении анонимного типа.

 var myOb = new { Count = 10, Max = 100, Min = 0 }

 Это означает, что следующие операторы считаются вполне допустимыми.

 Console.WriteLine("Счет равен " + myOb.Count);

 if (i <= myOb.Max && i >= myOb.Min) // ...

 Напомним, что при создании объекта анонимного типа указываемые идентификаторы
 становятся свойствами, открытыми только для чтения. Поэтому их можно использовать
 в других частях кода.

 Термин анонимный тип не совсем оправдывает свое название. Ведь тип оказывается
 анонимным только для программирующего, но не для компилятора, который присваивает
 ему внутреннее имя. Следовательно, анонимные типы не нарушают принятые в
 C# правила строгого контроля типов.

 Для того чтобы стало более понятным особое назначение анонимных типов, рассмотрим
 переделанную версию программы из предыдущего раздела, посвященного
 оператору join. Напомним, что в этой программе класс Temp требовался для инкапсуляции
 результата, возвращаемого оператором join. Благодаря применению
 анонимного типа необходимость в этом классе-заполнителе отпадает, а исходный код
 программы становится менее громоздким. Результат выполнения программы при
 этом не меняется.

*/

// Использовать анонимный тип для усовершенствования
// программы, демонстрирующий применение оператора join

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

class AnonTypeDemo
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
                          select new { Name = item.Name, InStock = entry.InStock };

        Console.WriteLine("Товар\t\tНаличие\n");

        //Выполнить запрос и вывести его результаты.
        foreach (var t in inStockList)
        {
            Console.WriteLine("{0}\t\t{1}", t.Name, t.InStock);
        }

        Console.ReadKey();
    }
}

/*

 Обратите особое внимание на следующий оператор select.

 select new
       {
           Name = item.Name,
           InStock = entry.InStock
       };

 Он возвращает объект анонимного типа с двумя доступными только для чтения
 свойствами: Name и InStock. Этим свойствам присваиваются наименование товара
 и состояние его наличия на складе. Благодаря применению анонимного типа необходимость
 в упоминавшемся выше классе Temp отпадает.

 Обратите также внимание на цикл foreach, в котором выполняется запрос. Теперь
 переменная шага этого цикла объявляется с помощью ключевого слова var. Это необходимо
 потому, что у типа объекта, хранящегося в переменной inStockList, нет
 имени. Данная ситуация послужила одной из причин, по которым в C# были внедрены
 неявно типизированные переменные, поскольку они нужны для поддержки анонимных типов.

 Прежде чем продолжить изложение, следует отметить еще один заслуживающий
 внимания аспект анонимных типов. В некоторых случаях, включая и рассмотренный
 выше, синтаксис анонимного типа упрощается благодаря применению инициализатора
 проекции. В данном случае просто указывается имя самого инициализатора. Это имя
 автоматически становится именем свойства. В качестве примера ниже приведен другой
 вариант оператора select из предыдущей программы.

 select new { item.Name, entry.InStock };

 В данном примере имена свойств остаются такими же, как и прежде, а компилятор
 автоматически "проецирует" идентификаторы Name и InStock, превращая их в свойства
 анонимного типа. Этим свойствам присваиваются прежние значения, обозначаемые
 item.Name и entry.InStock соответственно.

*/

#endregion

#region English

/*

Anonymous Types

C# provides a feature called the anonymous type that directly relates to LINQ. As the name
implies, an anonymous type is a class that has no name. Its primary use is to create an object
returned by the select clause. Often, the outcome of a query is a sequence of objects that are
either a composite of two (or more) data sources (such as in the case of join) or include a
subset of the members of one data source. In either case, often the type of the object being
returned is needed only because of the query and is not used elsewhere in the program. In
this case, using an anonymous type eliminates the need to declare a class that will be used
simply to hold the outcome of the query.

An anonymous type is created through the use of this general form:

new { nameA = valueA, nameB = valueB, ... }

Here, the names specify identifiers that translate into read-only properties that are
initialized by the values. For example,

new { Count = 10, Max = 100, Min = 0 }

This creates a class type that has three public read-only properties: Count, Max, and Min.
These are given the values 10, 100, and 0, respectively. These properties can be referred to by
name by other code. Notice that an anonymous type uses object initializers to initialize the
properties. As explained in Chapter 8, object initializers provide a way to initialize an object
without explicitly invoking a constructor. This is necessary in the case of anonymous types
because there is no way to explicitly call a constructor. (Recall that constructors have the
same name as their class. In the case of an anonymous class, there is no name. So, how
would you invoke the constructor?)

Because an anonymous type has no name, you must use an implicitly typed variable to
refer to it. This lets the compiler infer the proper type. For example,

var myOb = new { Count = 10, Max = 100, Min = 0 }

creates a variable called myOb that is assigned a reference to the object created by the
anonymous type expression. This means that the following statements are legal:

Console.WriteLine("Count is " + myOb.Count);

if(i <= myOb.Max && i >= myOb.Min) // ...

Remember, when an anonymous type is created, the identifiers that you specify become
read-only public properties. Thus, they can be used by other parts of your code.

Although the term anonymous type is used, it’s not quite completely true! The type is
anonymous relative to you, the programmer. However, the compiler does give it an internal
name. Thus, anonymous types do not violate C#‘s strong type checking rules.

To fully understand the value of anonymous types, consider this rewrite of the previous
program that demonstrated join. Recall that in the previous version, a class called Temp
was needed to encapsulate the result of the join. Through the use of an anonymous type,
this “placeholder” class is no longer needed and no longer clutters the source code to the
program. The output from the program is unchanged from before.

*/

// Use an anonymous type to improve the join demo program. 

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

//class AnonTypeDemo
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
//        // produce a list of item names and availability.  
//        // Now, an anonymous type is used. 
//        var inStockList = from item in items
//                          join entry in statusList
//                            on item.ItemNumber equals entry.ItemNumber
//                          select new
//                          {
//                              Name = item.Name,
//                              InStock = entry.InStock
//                          };

//        Console.WriteLine("Item\tAvailable\n");

//        // Execute the query and display the results. 
//        foreach (var t in inStockList)
//            Console.WriteLine("{0}\t{1}", t.Name, t.InStock);

//        Console.ReadKey();
//    }
//}

/*

Pay special attention to the select clause:

select new { Name = item.Name,
InStock = entry.InStock };

It returns an object of an anonymous type that has two read-only properties, Name and
InStock. These are given the values specified by the item’s name and availability. Because
of the anonymous type, there is no longer any need for the Temp class.

One other point. Notice the foreach loop that executes the query. It now uses var to
declare the iteration variable. This is necessary because the type of the object contained in
inStockList has no name. This situation is one of the reasons that C# includes implicitly
typed variables. They are needed to support anonymous types.

Before moving on, there is one more aspect of anonymous types that warrants a mention.
In some cases, including the one just shown, you can simplify the syntax of the anonymous
type through the use of a projection initializer. In this case, you simply specify the name of
the initializer by itself. This name automatically becomes the name of the property. For
example, here is another way to code the select clause used by the preceding program:

select new { item.Name, entry.InStock };

Here, the property names are still Name and InStock, just as before. The compiler
automatically “projects” the identifiers Name and InStock, making them the property
names of the anonymous type. Also as before, the properties are given the values specified
by item.Name and entry.InStock.

*/

#endregion