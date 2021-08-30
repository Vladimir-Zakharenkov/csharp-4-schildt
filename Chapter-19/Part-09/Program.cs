#region Russian

/*

 Одной из самых эффективных для оператора select является возможность возвращать
 последовательность результатов, содержащую элементы данных, формируемые
 во время выполнения запроса. В качестве примера рассмотрим еще одну программу.
 В ней определяется класс ContactInfo, в котором хранится имя, адрес электронной
 почты и номер телефона адресата. Кроме того, в этой программе определяется класс
 EmailAddress, использовавшийся в предыдущем примере. В методе Main() создается
 массив объектов типа ContactInfo, а затем объявляется запрос, в котором источником
 данных служит этот массив, но возвращаемая последовательность результатов
 содержит объекты типа EmailAddress. Таким образом, типом последовательности
 результатов, возвращаемой оператором select, является класс EmailAddress, а не
 класс ContactInfo, причем его объекты создаются во время выполнения запроса.

*/

// Использовать запрос для получения последовательности объектов
// типа EmailAddresses из списка объектов типа ContactInfo.

using System;
using System.Linq;

class ContactInfo
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public ContactInfo(string n, string a, string p)
    {
        Name = n;
        Email = a;
        Phone = p;
    }
}

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

class SelectDemo3
{
    static void Main()
    {
        ContactInfo[] contacts =
        {
            new ContactInfo ("Герберт","Herb@HerbertSchildt.com","555-1010"),
            new ContactInfo ("Том","Tom@HerbertSchildt.com","555-1101"),
            new ContactInfo ("Сара","Sara@HerbertSchildt.com","555-0110")
        };

        //Сформировать запрос на получение объектов типа EmailAddress.
        var emailList = from entry in contacts
                        select new EmailAddress(entry.Name, entry.Email);

        Console.WriteLine("Список адресов электронной почты:\n");

        //Выполнить запрос и вывести его результаты.
        foreach (EmailAddress e in emailList)
        {
            Console.WriteLine(" {0}: {1}", e.Name, e.Address);
        }

        Console.ReadLine();
    }
}

/*

 Ниже приведен результат выполнения этой программы.

 Список адресов электронной почты:
 Герберт: Herb @HerbSchildt.com
 Том: Tom @HerbSchildt.com
 Сара: Sara @HerbSchildt.com

 Обратите особое внимание в данном запросе на следующий оператор select.

 select new EmailAddress(entry.Name, entry.Email);

 В этом операторе создается новый объект типа EmailAddress, содержащий имя
 и адрес электронной почты, получаемые из объекта типа ContactInfo, хранящегося
 в массиве contacts. Но самое главное, что новые объекты типа EmailAddress создаются
 в операторе select во время выполнения запроса.

*/

#endregion

#region English

/*

One of the more powerful features of select is its ability to return a sequence that contains
elements created during the execution of the query. For example, consider the following
program. It defines a class called ContactInfo, which stores a name, e-mail address, and
telephone number. It also defines the EmailAddress class used by the preceding example.
Inside Main( ), an array of ContactInfo is created. Then, a query is declared in which the
data source is an array of ContactInfo, but the sequence returned contains EmailAddress
objects. Thus, the type of the sequence returned by select is not ContactInfo, but rather
EmailAddress, and these objects are created during the execution of the query.

*/

// Use a query to obtain a sequence of EmailAddresses 
// from a list of ContactInfo. 

//using System;  
//using System.Linq;  

//class ContactInfo
//{
//    public string Name { get; set; }
//    public string Email { get; set; }
//    public string Phone { get; set; }

//    public ContactInfo(string n, string a, string p)
//    {
//        Name = n;
//        Email = a;
//        Phone = p;
//    }
//}

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

//class SelectDemo3
//{
//    static void Main()
//    {

//        ContactInfo[] contacts = {
//         new ContactInfo("Herb", "Herb@HerbSchildt.com", "555-1010"),
//         new ContactInfo("Tom", "Tom@HerbSchildt.com", "555-1101"),
//         new ContactInfo("Sara", "Sara@HerbSchildt.com", "555-0110")
//    };

//        // Create a query that creates a list of EmailAddress objects. 
//        var emailList = from entry in contacts
//                        select new EmailAddress(entry.Name, entry.Email);

//        Console.WriteLine("The e-mail list is");

//        // Execute the query and display the results. 
//        foreach (EmailAddress e in emailList)
//            Console.WriteLine("  {0}: {1}", e.Name, e.Address);

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

The e-mail list is
Herb: Herb@HerbSchildt.com
Tom: Tom@HerbSchildt.com
Sara: Sara@HerbSchildt.com

In the query, pay special attention to the select clause:

select new EmailAddress(entry.Name, entry.Email);

It creates a new EmailAddress object that contains the name and e-mail address obtained
from a ContactInfo object in the contacts array. The key point is that new EmailAddress
objects are created by the query in its select clause, during the query’s execution.

*/

#endregion