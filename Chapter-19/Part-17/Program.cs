#region Russian

/*

 Создание группового объединения

 Как пояснялось ранее, оператор into можно использовать вместе с оператором
 join для создания группового объединения, образующего последовательность, в которой
 каждый результат состоит из элементов данных из первой последовательности и группы
 всех совпадающих элементов из второй последовательности. Примеры группового
 объединения не приводились выше потому, что в этом объединении нередко применяется
 анонимный тип. Но теперь, когда представлены анонимные типы, можно обратиться
 к простому примеру группового объединения.

 В приведенном ниже примере программы групповое объединение используется
 для составления списка, в котором различные транспортные средства (автомашины,
 суда и самолеты) организованы по общим для них категориям транспорта: наземного,
 морского, воздушного и речного. В этой программе сначала создается класс
 Transport, связывающий вид транспорта с его классификацией. Затем в методе
 Main() формируются две входные последовательности. Первая из них представляет
 собой массив символьных строк, содержащих названия общих категорий транспорта:
 наземного, морского, воздушного и речного, а вторая — массив объектов типа
 Transport, инкапсулирующих различные транспортные средства. Полученное в итоге
 групповое объединение используется для составления списка транспортных средств,
 организованных по соответствующим категориям.

*/

// Продемонстрировать применение простого группового объединения.

using System;
using System.Linq;

//Этот класс связывает наименование вида транспорта,
//например поезда, с общей классификацией транспорта:
//наземного, морского, воздушного или речного.
class Transport
{
    public string Name { get; set; }
    public string How { get; set; }

    public Transport(string n, string h)
    {
        Name = n;
        How = h;
    }
}

class GroupJoinDemo
{
    static void Main()
    {
        //Массив классификации видов транспорта.
        string[] travelTypes =
        {
            "Воздушный",
            "Морской",
            "Наземный",
            "Речной"
        };

        //Массив видов транспорта.
        Transport[] transports =
        {
            new Transport("велосипед","Наземный"),
            new Transport("аэростат","Воздушный"),
            new Transport("лодка","Речной"),
            new Transport("самолет","Воздушный"),
            new Transport("каноэ","Речной"),
            new Transport("биплан","Воздушный"),
            new Transport("автомашина","Наземный"),
            new Transport("судно","Морской"),
            new Transport("поезд","Наземный")
        };

        //Сформировать запрос, в котором групповое
        //объединение используется для составления списка
        //видов транспорта по соответствующим категориям.
        var byHow = from how in travelTypes
                    join trans in transports
                    on how equals trans.How
                    into lst
                    select new { How = how, Tlist = lst };

        //Выполнить запрос и вывести его результаты.
        foreach (var t in byHow)
        {
            Console.WriteLine("К категории <{0} транспорт> относится:", t.How);

            foreach (var m in t.Tlist)
            {
                Console.WriteLine(" " + m.Name);
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}

/*

 Ниже приведен результат выполнения этой программы.

 К категории <Воздушный транспорт> относится:
 аэростат
 самолет
 биплан
 К категории <Морской транспорт> относится:
 судно
 К категории <Наземный транспорт> относится:
 велосипед
 автомашина
 поезд
 К категории <Речной транспорт> относится:
 лодка
 каноэ

 Главной частью данной программы, безусловно, является следующий запрос.

 var byHow = from how in travelTypes
 join trans in transports
 on how equals trans.How
 into lst
 select new { How = how, Tlist = lst };

 Этот запрос формируется следующим образом. В операторе from используется
 переменная диапазона how для охвата всего массива travelTypes. Напомним, что
 массив travelTypes содержит названия общих категорий транспорта: воздушного,
 наземного, морского и речного. Каждый вид транспорта объединяется в операторе
 join со своей категорией. Например, велосипед, автомашина и поезд объединяются
 с наземным транспортом. Но благодаря оператору into для каждой категории транспорта
 в операторе join составляется список видов транспорта, относящихся к данной
 категории. Этот список сохраняется в переменной lst. И наконец, оператор select
 возвращает объект анонимного, типа, инкапсулирующий каждое значение переменной
 how (категории транспорта) вместе со списком видов транспорта. Именно поэтому
 для вывода результатов запроса требуются два цикла foreach.

 foreach(var t in byHow) {
     Console.WrifeLine("К категории <{0} транспорт> относится:", t.How);
     foreach (var m in t.Tlist)
         Console.WriteLine(" " + m.Name);
     Console.WriteLine();
 }

 Во внешнем цикле получается объект, содержащий наименование общей категории
 транспорта, и список видов транспорта, относящихся к этой категории. А во внутреннем
 цикле выводятся отдельные виды транспорта.

*/

#endregion

#region English

/*

Create a Group Join

As mentioned earlier, you can use into with join to create a group join, which creates a
sequence in which each entry in the result consists of an entry from the first sequence and
a group of all matching elements from the second sequence. No example was presented
then because often a group join makes use of an anonymous type. Now that anonymous
types have been covered, an example of a simple group join can be given.

The following example uses a group join to create a list in which various transports, such
as cars, boats, and planes, are organized by their general transportation category, which is
land, sea, or air. The program first creates a class called Transport that links a transport type
with its classification. Inside Main( ), it creates two input sequences. The first is an array of
strings that contains the names of the general means by which one travels, which are land,
sea, and air. The second is an array of Transport, which encapsulates various means of
transportation. It then uses a group join to produce a list of transports that are organized
by their category.

*/

// Demonstrate a simple group join. 

//using System;  
//using System.Linq;  

//// This class links the name of a transport, such as Train, 
//// with its general classification, such as land, sea , or air. 
//class Transport
//{
//    public string Name { get; set; }
//    public string How { get; set; }

//    public Transport(string n, string h)
//    {
//        Name = n;
//        How = h;
//    }
//}

//class GroupJoinDemo
//{
//    static void Main()
//    {

//        // An array of transport classifications. 
//        string[] travelTypes = {
//         "Air",
//         "Sea",
//         "Land"
//    };

//        // An array of transports. 
//        Transport[] transports = {
//         new Transport("Bicycle", "Land"),
//         new Transport("Balloon", "Air"),
//         new Transport("Boat", "Sea"),
//         new Transport("Jet", "Air"),
//         new Transport("Canoe", "Sea"),
//         new Transport("Biplane", "Air"),
//         new Transport("Car", "Land"),
//         new Transport("Cargo Ship", "Sea"),
//         new Transport("Train", "Land")
//    };

//        // Create a query that uses a group join to produce 
//        // a list of item names and IDs organized by category. 
//        var byHow = from how in travelTypes
//                    join trans in transports
//                    on how equals trans.How
//                    into lst
//                    select new { How = how, Tlist = lst };

//        // Execute the query and display the results. 
//        foreach (var t in byHow)
//        {
//            Console.WriteLine("{0} transportation includes:", t.How);

//            foreach (var m in t.Tlist)
//                Console.WriteLine("  " + m.Name);

//            Console.WriteLine();
//        }

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

Air transportation includes:
Balloon
Jet
Biplane

Sea transportation includes:
Boat
Canoe
Cargo Ship

Land transportation includes:
Bicycle
Car
Train

The key part of the program is, of course, the query, which is shown here:

var byHow = from how in travelTypes
join trans in transports
on how equals trans.How
into lst
select new { How = how, Tlist = lst };

Here is how it works. The from statement uses how to range over the travelTypes array.
Recall that travelTypes contains an array of the general travel classifications: air, land, and
sea. The join clause joins each travel type with those transports that use that type. For
example, the type Land is joined with Bicycle, Car, and Train. However, because of the into
clause, for each travel type, the join produces a list of the transports that use that travel
type. This list is represented by lst. Finally, select returns an anonymous type that encapsulates
each value of how (the travel type) with a list of transports. This is why the two foreach
loops shown here are needed to display the results of the query:

foreach(var t in byHow) {
Console.WriteLine("{0} transportation includes:", t.How);
foreach(var m in t.Tlist)
Console.WriteLine(" " + m.Name);
Console.WriteLine();
}

The outer loop obtains an object that contains the name of the travel type and the list of the
transports for that type. The inner loop displays the individual transports.

*/

#endregion