#region Russian

/*

 Ниже приведена программа, демонстрирующая другое применение оператора
 select. В этой программе сначала создается класс EmailAddress, содержащий два
 свойства. В первом из них хранится имя адресата, а во втором — адрес его электронной
 почты. Затем в этой программе создается массив, содержащий несколько элементов
 данных типа EmailAddress. И наконец, в данной программе создается список, состоящий
 только из адресов электронной почты, извлекаемых по запросу.

*/

// Возвратить часть значения переменной диапазона.

using System;
using System.Linq;

class EmailAddress
{
    public string Name { get; set; }
    public string Address { get; set; }

    public EmailAddress(string n, string a)
    {
        Name = n;
        Address = a;
    }
}

class SelectDemo2
{
    static void Main()
    {
        EmailAddress[] addrs =
        {
            new EmailAddress("Герберт", "Herb@HerbertSchildt.com"),
            new EmailAddress("Том", "Tom@HerbertSchildt.com"),
            new EmailAddress("Сара", "Sara@HerbertSchildt.com")
        };

        //Сформировать запрос на получение адресов электронной почты.
        var eAddrs = from entry in addrs
                     select entry.Address;

        Console.WriteLine("Адреса электронной почты:\n");

        //Выполнить запрос и вывести его результаты.
        foreach (string s in eAddrs)
        {
            Console.WriteLine(" " + s);
        }

        Console.ReadKey();
    }
}

/*

 Вот к какому результату приводит выполнение этой программы.

 Адреса электронной почты:
 Herb @HerbSchildt.com
 Tom @HerbSchildt.com
 Sara@HerbSchildt.com

 Обратите особое внимание на следующий оператор select.

select entry.Address;

 Вместо полного значения переменной диапазона этот оператор возвращает лишь
 его адресную часть (Address). Это означает, что по данному запросу возвращается
 последовательность символьных строк, а не объектов типа EmailAddress. Именно
 поэтому переменная s указывается в цикле foreach как string. Ведь как пояснялось
 ранее, тип последовательности результатов, возвращаемых по запросу, определяется
 типом значения, возвращаемым оператором select.

*/

#endregion

#region English

/*

Here is a program that shows another way to use select. It creates a class called
EmailAddress that contains two properties. The first holds a person’s name. The second
contains an e-mail address. The program then creates an array that contains several
EmailAddress entries. The program uses a query to obtain a list of just the e-mail
addresses by themselves.

*/

// Return a portion of the range variable.

//using System;  
//using System.Linq;  

//class EmailAddress
//{
//    public string Name { get; set; }
//    public string Address { get; set; }

//    public EmailAddress(string n, string a)
//    {
//        Name = n;
//        Address = a;
//    }
//}

//class SelectDemo2
//{
//    static void Main()
//    {

//        EmailAddress[] addrs = {
//         new EmailAddress("Herb", "Herb@HerbSchildt.com"),
//         new EmailAddress("Tom", "Tom@HerbSchildt.com"),
//         new EmailAddress("Sara", "Sara@HerbSchildt.com")
//    };

//        // Create a query that selects e-mail addresses.  
//        var eAddrs = from entry in addrs
//                     select entry.Address;

//        Console.WriteLine("The e-mail addresses are");

//        // Execute the query and display the results. 
//        foreach (string s in eAddrs) Console.WriteLine("  " + s);

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

The e-mail addresses are
Herb@HerbSchildt.com
Tom@HerbSchildt.com
Sara@HerbSchildt.com

Pay special attention to the select clause:

select entry.Address;

Instead of returning the entire range variable, it returns only the Address portion. This
fact is evidenced by the output. This means the query returns a sequence of strings, not a
sequence of EmailAddress objects. This is why the foreach loop specifies s as a string. As
explained, the type of sequence returned by a query is determined by the type of value
returned by the select clause.

*/

#endregion