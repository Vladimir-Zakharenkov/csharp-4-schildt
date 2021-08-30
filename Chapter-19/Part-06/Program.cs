#region Russian

/*
 
 Зачастую сортировка результатов запроса проводится по единственному критерию.

 Тем не менее для сортировки по нескольким критериям служит приведенная ниже
 форма оператора orderby.

 orderby элемент_А направление, элемент_В направление, элемент_С направление, ...

 В данной форме элемент_А обозначает конкретный элемент, по которому проводится
 основная сортировка; элемент_В — элемент, по которому производится сортировка
 каждой группы эквивалентных элементов; элемент_С — элемент, по которому
 производится сортировка всех этих групп, и т.д. Таким образом, каждый последующий
 элемент обозначает дополнительный критерий сортировки. Во всех этих критериях
 указывать направление сортировки необязательно, но по умолчанию сортировка проводится
 по нарастающей. Ниже приведен пример программы, в которой сортировка
 информации о банковских счетах осуществляется по трем критериям: фамилии, имени
 и остатку на счете.

*/

// Сортировать результаты запроса по нескольким критериям, используя оператор orderby.

using System;
using System.Linq;
using System.Text;

class Account
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public double Balance { get; private set; }
    public string AccountNumber { get; private set; }

    public Account(string fn, string ln, string accnum, double b)
    {
        FirstName = fn;
        LastName = ln;
        AccountNumber = accnum;
        Balance = b;
    }
}

class OrderbyDemo
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode; // Для отображения символов Unicode в консоле.

        // Сформировать исходные данные.
        Account[] accounts = { new Account("Tom", "Smith", "132CK", 100.23),
                           new Account("Tom", "Smith", "132CD", 10000.00),
                           new Account("Ralph", "Jones", "436CD", 1923.85),
                           new Account("Ralph", "Jones", "454MM", 987.132),
                           new Account("Ted", "Krammer", "897CD", 3223.19),
                           new Account("Ralph", "Jones", "434CK", -123.32),
                           new Account("Sara", "Smith", "543MM", 5017.40),
                           new Account("Sara", "Smith", "547CD", 34955.79),
                           new Account("Sara", "Smith", "843CK", 345.00),
                           new Account("Albert", "Smith", "445CK", -213.67),
                           new Account("Betty", "Krammer","968MM", 5146.67),
                           new Account("Carl", "Smith", "078CD", 15345.99),
                           new Account("Jenny", "Jones", "108CK", 10.98)
                         };

        // Сформировать запрос на получение сведений о банковских счетах в отсортированном порядке.
        // Отсортировать эти сведения сначала по фамилии, затем по имени и, наконец, по остатку на счете.
        var accInfo = from acc in accounts
                      orderby acc.LastName, acc.FirstName, acc.Balance
                      select acc;

        Console.WriteLine("Счета в отсортированном порядке: ");

        string str = "";

        // Выполнить запрос и вывести его результаты.
        foreach (Account acc in accInfo)
        {
            if (str != acc.FirstName)
            {
                Console.WriteLine();
                str = acc.FirstName;
            }

            Console.WriteLine("{0}, {1}\tНомер счета: {2}, {3,10:C}", acc.LastName, acc.FirstName, acc.AccountNumber, acc.Balance);
        }

        Console.ReadKey();
    }
}

/*

 Ниже приведен результат выполнения этой программы.

 Счета в отсортированном порядке:

 Джонс, Дженни Номер счета: 108СК, $10.98

 Джонс, Ральф Номер счета: 434СК, $123.32
 Джонс, Ральф Номер счета: 454ММ, $987.13
 Джонс, Ральф Номер счета: 436CD, $1,923.85

 Краммер, Бетти Номер счета: 968ММ, $5,146.67

 Краммер, Тед Номер счета: 897CD, $3,223.19

 Смит, Альберт Номер счета: 445СК, $213.67

 Смит, Карл Номер счета: 078CD, $15,345.99

 Смит, Сара Номер счета: 843СК, $345.00
 Смит, Сара Номер счета: 543ММ, $5,017.40
 Смит, Сара Номер счета: 547CD, $34,955.79

 Смит, Том Номер счета: 132СК, $100.23
 Смит, Том Номер счета: 132CD, $10,000.00

 Внимательно проанализируем оператор orderby в следующем запросе из приведенной
 выше программы.

 var accInfo = from acc in accounts
 orderby acc.LastName, acc.FirstName, acc.Balance
 select acc;

 Сортировка результатов этого запроса осуществляется следующим образом. Сначала
 результаты сортируются по фамилии, затем элементы с одинаковыми фамилиями
 сортируются по имени. И наконец, группы элементов с одинаковыми фамилиями и
 именами сортируются по остатку на счете. Именно поэтому список счетов вкладчиков
 по фамилии Джонс выглядит так.

 Джонс, Дженни Номер счета: 108СК, $10.98
 Джонс, Ральф Номер счета: 434СК, $123.32
 Джонс, Ральф Номер счета: 454ММ, $987.13
 Джонс, Ральф Номер счета: 436CD, $1,923.85

 Как показывает результат выполнения данного запроса, список счетов отсортирован
 сначала по фамилии, затем по имени и, наконец, по остатку на счете.

 Используя несколько критериев, можно изменить на обратный порядок любой сортировки
 с помощью ключевого слова descending. Например, результаты следующего
 запроса будут выведены по убывающей остатков на счетах.

 var accInfo = from acc in accounts
 orderby acc.LastName, acc.FirstName, acc.Balance descending
 select acc;

 В этом случае список счетов вкладчиков по фамилии Джонс будет выглядеть так,
 как показано ниже.

 Джонс, Дженни Номер счета: 108СК, $10.98
 Джонс, Ральф Номер счета: 436CD, $1,923.85
 Джонс, Ральф Номер счета: 454ММ, $987.13
 Джонс, Ральф Номер счета: 434СК, $123.32

 Как видите, теперь счета вкладчика по фамилии Ральф Джонс выводятся по убывающей:
 от наибольшей до наименьшей суммы остатка на счете.

*/

#endregion

#region English

/*

Although sorting on a single criterion is often what is needed, you can use orderby to
sort on multiple items by using this form:

orderby sort-onA direction, sort-onB direction, sort-onC direction, …

In this form, sort-onA is the item on which the primary sorting is done. Then, each group of
equivalent items is sorted on sort-onB, and each of those groups is sorted on sort-onC, and so
on. Thus, each subsequent sort-on specifies a “then by” item on which to sort. In all cases,
direction is optional, defaulting to ascending. Here is an example that uses three sort criteria
to sort bank account information by last name, then by first name, and finally by account
balance:

*/

// Sort on multiple criteria with orderby. 

//using System;  
//using System.Linq;  

//class Account
//{
//    public string FirstName { get; private set; }
//    public string LastName { get; private set; }
//    public double Balance { get; private set; }
//    public string AccountNumber { get; private set; }

//    public Account(string fn, string ln, string accnum, double b)
//    {
//        FirstName = fn;
//        LastName = ln;
//        AccountNumber = accnum;
//        Balance = b;
//    }
//}

//class OrderbyDemo
//{

//    static void Main()
//    {

//        // Create some data. 
//        Account[] accounts = { new Account("Tom", "Smith", "132CK", 100.23),
//                           new Account("Tom", "Smith", "132CD", 10000.00),
//                           new Account("Ralph", "Jones", "436CD", 1923.85),
//                           new Account("Ralph", "Jones", "454MM", 987.132),
//                           new Account("Ted", "Krammer", "897CD", 3223.19),
//                           new Account("Ralph", "Jones", "434CK", -123.32),
//                           new Account("Sara", "Smith", "543MM", 5017.40),
//                           new Account("Sara", "Smith", "547CD", 34955.79),
//                           new Account("Sara", "Smith", "843CK", 345.00),
//                           new Account("Albert", "Smith", "445CK", -213.67),
//                           new Account("Betty", "Krammer","968MM", 5146.67),
//                           new Account("Carl", "Smith", "078CD", 15345.99),
//                           new Account("Jenny", "Jones", "108CK", 10.98)
//                         };

//        // Create a query that obtains the accounts in sorted order. 
//        // Sorting first by last name, then within same last names, by  
//        // by first name, and finally by account balance. 
//        var accInfo = from acc in accounts
//                      orderby acc.LastName, acc.FirstName, acc.Balance
//                      select acc;

//        Console.WriteLine("Accounts in sorted order: ");

//        string str = "";

//        // Execute the query and display the results. 
//        foreach (Account acc in accInfo)
//        {
//            if (str != acc.FirstName)
//            {
//                Console.WriteLine();
//                str = acc.FirstName;
//            }

//            Console.WriteLine("{0}, {1}\tAcc#: {2}, {3,10:C}",
//                              acc.LastName, acc.FirstName,
//                              acc.AccountNumber, acc.Balance);
//        }

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

Accounts in sorted order:

Jones, Jenny Acc#: 108CK, $10.98

Jones, Ralph Acc#: 434CK, ($123.32)
Jones, Ralph Acc#: 454MM, $987.13
Jones, Ralph Acc#: 436CD, $1,923.85

Krammer, Betty Acc#: 968MM, $5,146.67

Krammer, Ted Acc#: 897CD, $3,223.19

Smith, Albert Acc#: 445CK, ($213.67)

Smith, Carl Acc#: 078CD, $15,345.99

Smith, Sara Acc#: 843CK, $345.00
Smith, Sara Acc#: 543MM, $5,017.40
Smith, Sara Acc#: 547CD, $34,955.79

Smith, Tom Acc#: 132CK, $100.23
Smith, Tom Acc#: 132CD, $10,000.00

In the query, look closely at how the orderby clause is written:

var accInfo = from acc in accounts
orderby acc.LastName, acc.FirstName, acc.Balance
select acc;

Here is how it works. First, the results are sorted by last name, and then entries with the
same last name are sorted by the first name. Finally, groups of entries with the same first
and last name are sorted by the account balance. This is why the list of accounts under the
name Jones is shown in this order:

Jones, Jenny Acc#: 108CK, $10.98

Jones, Ralph Acc#: 434CK, ($123.32)
Jones, Ralph Acc#: 454MM, $987.13
Jones, Ralph Acc#: 436CD, $1,923.85

As the output confirms, the list is sorted by last name, then by first name, and finally by
account balance.

When using multiple criteria, you can reverse the condition of any sort by applying
the descending option. For example, this query causes the results to be shown in order
of decreasing balance:

var accInfo = from acc in accounts
orderby x.LastName, x.FirstName, x.Balance descending
select acc;

When using this version, the list of Jones entries will be displayed like this:

Jones, Jenny Acc#: 108CK, $10.98

Jones, Ralph Acc#: 436CD, $1,923.85
Jones, Ralph Acc#: 454MM, $987.13
Jones, Ralph Acc#: 434CK, ($123.32)

As you can see, now the accounts for Ralph Jones are displayed from greatest to least.

*/

#endregion..