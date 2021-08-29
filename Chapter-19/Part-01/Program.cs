#region Russian

/*
// ГЛАВА 19 LINQ

 Без сомнения, LINQ относится к одним из самых интересных
 средств языка С#. Эти средства были внедрены
 в версии C# 3.0 и явились едва ли не самым главным
 его дополнением, которое состояло не только во внесении
 совершенно нового элемента в синтаксис С#, добавлении
 нескольких ключевых слов и предоставлении больших возможностей,
 но и в значительном расширении рамок данного
 языка программирования и круга задач, которые он
 позволяет решать. Проще говоря, внедрение LINQ стало
 поворотным моментом в истории развития С#.

 Аббревиатура LINQ означает Language-Integrated Query,
 т.е. язык интегрированных запросов. Это понятие охватывает
 ряд средств, позволяющих извлекать информацию из источника
 данных. Как вам должно быть известно, извлечение
 данных составляет важную часть многих программ. Например,
 программа может получать информацию из списка
 заказчиков, искать информацию в каталоге продукции или
 получать доступ к учетному документу, заведенному на работника.
 Как правило, такая информация хранится в базе
 данных, существующей отдельно от приложения. Так, каталог
 продукции может храниться в реляционной базе данных.
 В прошлом для взаимодействия с такой базой данных
 приходилось формировать запросы на языке структурированных
 запросов (SQL). А для доступа к другим источникам
 данных, например в формате XML, требовался отдельный
 подход. Следовательно, до версии 3.0 поддержка подобных
 запросов в C# отсутствовала. Но это положение изменилось
 после внедрения LINQ.

 LINQ дополняет C# средствами, позволяющими формировать
 запросы для любого LINQ-совместимого источника данных.
 При этом синтаксис, используемый для формирования запросов, остается неизменным,
 независимо от типа источника данных. Это, в частности, означает, что синтаксис,
 требующийся для формирования запроса к реляционной базе данных, практически
 ничем не отличается от синтаксиса запроса данных, хранящихся в массиве.
 Для этой цели теперь не нужно прибегать к средствам SQL или другого внешнего по
 отношению к C# механизма извлечения данных из источника. Возможности формировать
 запросы отныне полностью интегрированы в язык С#.

 Помимо SQL, LINQ можно использовать вместе с XML-файлами и наборами данных
 ADO.NET Dataset. Не менее важным является применение LINQ вместе с массивами
 и коллекциями в C# (подробнее рассматриваемыми в главе 25). Таким образом,
 средства LINQ предоставляют, в целом, единообразный доступ к данным. И хотя такой
 принцип уже сам по себе является весьма эффективным и новаторским, преимущества
 LINQ этим не ограничиваются. LINQ предлагает осмыслить иначе и подойти по-
 другому к решению многих видов задач программирования, помимо традиционной
 организации доступа к базам данных. И в конечном итоге многие решения могут быть
 выработаны на основе LINQ.

 LINQ поддерживается целым рядом взаимосвязанных средств, включая внедренный
 в C# синтаксис запросов, лямбда-выражения, анонимные типы и методы расширения.
 О лямбда-выражениях речь уже шла в главе 15, а остальные средства рассматриваются
 в этой главе.

 ПРИМЕЧАНИЕ

 LINQ в C# — это, по сути, язык в языке. Поэтому предмет рассмотрения LINQ довольно
 обширен и включает в себя многие средства, возможности и альтернативы. Несмотря на
 то что в этой главе дается подробное описание средств LINQ, рассмотреть здесь все их возможности,
 особенности и области применения просто невозможно. Для этого потребовалась
 бы отдельная книга. В связи с этим в настоящей главе основное внимание уделяется главным
 элементам LINQ, применение которых демонстрируется на многочисленных примерах.
 А в долгосрочной перспективе LINQ представляет собой подсистему, которую придется изучать
 самостоятельно и достаточно подробно.

 Основы LINQ

 В основу LINQ положено понятие запроса, в котором определяется информация,
 получаемая из источника данных. Например, запрос списка рассылки почтовых сообщений
 заказчикам может потребовать предоставления адресов всех заказчиков,
 проживающих в конкретном городе; запрос базы данных товарных запасов — список
 товаров, запасы которых исчерпались на складе; а запрос журнала, регистрирующего
 интенсивность использования Интернета, — список наиболее часто посещаемых вебсайтов.
 И хотя все эти запросы отличаются в деталях, их можно выразить, используя
 одни и те же синтаксические элементы LINQ.

 Как только запрос будет сформирован, его можно выполнить. Это делается, в частности,
 в цикле foreach. В результате выполнения запроса выводятся его результаты.
 Поэтому использование запроса может быть разделено на две главные стадии. На первой
 стадии запрос формируется, а на второй — выполняется. Таким образом, при формировании
 запроса определяется, что именно следует извлечь из источника данных.
 А при выполнении запроса выводятся конкретные результаты.

 Для обращения к источнику данных по запросу, сформированному средствами
 LINQ, в этом источнике должен быть реализован интерфейс IEnumerable. Он имеет
 две формы: обобщенную и необобщенную. Как правило, работать с источником
 данных легче, если в нем реализуется обобщенная форма IEnumerable<T>, где Т обозначает
 обобщенный тип перечисляемых данных. Здесь и далее предполагается, что в
 источнике данных реализуется форма интерфейса IEnumerable<T>. Этот интерфейс
 объявляется в пространстве имен System.Collections.Generic. Класс, в котором
 реализуется форма интерфейса IEnumerable<T>, поддерживает перечисление, а это
 означает, что его содержимое может быть получено по очереди или в определенном
 порядке. Форма интерфейса IEnumerable<T> поддерживается всеми массивами в С#.
 Поэтому на примере массивов можно наглядно продемонстрировать основные принципы
 работы LINQ. Следует, однако, иметь в виду, что применение LINQ не ограничивается
 одними массивами.

 Простой запрос

 А теперь самое время обратиться к простому примеру использования LINQ. В приведенной
 ниже программе используется запрос для получения положительных значений,
 содержащихся в массиве целых значений.

 */

// Сформировать простой запрос LINQ.

using System;
using System.Linq;

class SimpQuery
{
    static void Main()
    {
        int[] nums = { 1, -2, 3, 0, -4, 5 };

        //Сформировать простой запрос на получение только положительных значений.
        var posNums = from n in nums
                      where n > 0
                      select n;

        Console.Write("Положительные значения в массиве: ");

        //Выполнить запрос и отобразить его результаты.
        foreach (int i in posNums)
        {
            Console.Write(i + " ");
        }

        Console.ReadKey();
    }
}

/*

 Эта программа дает следующий результат.

 Положительные значения из массива nums: 1 3 5

 Как видите, в конечном итоге отображаются только положительные значения, хранящиеся
 в массиве nums. Несмотря на всю свою простоту, этот пример наглядно демонстрирует
 основные возможности LINQ. Поэтому рассмотрим его более подробно.

 Прежде всего обратите внимание на применение в данном примере программы
 следующего оператора.

 using System.Linq;

 Для применения средств LINQ в исходный текст программы следует включить пространство
 имен System.Linq.

 Затем в программе объявляется массив nums типа int. Все массивы в C# неявным
 образом преобразуются в форму интерфейса IEnumerable<T>. Благодаря этому любой
 массив в C# может служить в качестве источника данных, извлекаемых по запросу LINQ.

 Далее объявляется запрос, по которому из массива nums извлекаются элементы
 только с положительными значениями.

 var posNums = from n in nums
 where n > 0
 select n;

 Переменная posNums называется переменной запроса. В ней хранится ссылка на ряд
 правил, определяемых в запросе. Обратите внимание на применение ключевого слова
 var для объявления переменной posNums неявным образом. Как вам должно быть
 уже известно, благодаря этому переменная posNums становится неявно типизированной.
 Такими переменными удобно пользоваться в запросах, хотя их тип можно объявить
 и явным образом (это должна быть одна из форм интерфейса IEnumerable<T>).
 Объявляемой переменной posNums в итоге присваивается выражение запроса.

 Все запросы начинаются с оператора from, определяющего два элемента. Первым
 из них является переменная диапазона, принимающая элементы из источника данных.
 В рассматриваемом здесь примере эту роль выполняет переменная n. Вторым элементом
 является источник данных (в данном случае — массив nums). Тип переменной диапазона
 выводится из источника данных. Поэтому переменная n относится к типу int.
 Ниже приведена общая форма оператора from.

from переменная_диапазона in источник_данных

 Далее следует оператор where, обозначающий условие, которому должен удовлетворять
 элемент в источнике данных, чтобы его можно было получить по запросу.
 Ниже приведена общая форма синтаксиса оператора where.

where булево_выражение

 В этой форме булево_выражение должно давать результат типа bool. Такое выражение
 иначе называется предикатом. В запросе можно указывать несколько операторов
 where. В данном примере программы используется следующий оператор where.

where n > 0

 Этот оператор будет давать истинный результат только для тех элементов массива,
 значения которых оказываются больше нуля. Выражение n > 0 будет вычисляться
 для каждого из n элементов массива n при выполнении запроса. В итоге будут получены
 только те значения, которые удовлетворяют этому условию. Иными словами,
 оператор where выполняет роль своеобразного фильтра, отбирая лишь определенные
 элементы.

 Все запросы оканчиваются оператором select или group. В данном примере
 используется оператор select, точно определяющий, что именно должно быть получено
 по запросу. В таких простых примерах запросов, как рассматриваемый здесь,
 выбирается конкретное значение диапазона. Поэтому по данному запросу возвращаются
 только те целые значения, которые удовлетворяют условию, указанному в операторе
 where. В более сложных запросах можно дополнительно уточнять, что именно
 следует выбирать.Например, по запросу списка рассылки может быть получена лишь
 фамилия адресата вместо его полного адреса. Обратите внимание на то, что оператор
 select завершается точкой с запятой, поскольку это последний оператор в запросе.
 А другие его операторы не оканчиваются точкой с запятой.

 Итак, переменная запроса posNums создана, но результаты запроса пока еще не
 получены.Дело в том, что сам запрос определяет лишь ряд конкретных правил, а результаты
 будут только после выполнения запроса.Кроме того, один и тот же запрос
 может быть выполнен два раза или больше, причем с разными результатами, если
 в промежутке между последовательно производимыми попытками выполнить один
 и тот же запрос изменяется базовый источник данных.Поэтому одного лишь объявления
 переменной запроса posNums совершенно недостаточно для того, чтобы она содержала
 результаты запроса.

 Для выполнения запроса в данном примере программы организуется следующий цикл.

 foreach(int i in posNums) Console.WriteLine(i + " ");

 В этом цикле переменная posNums указывается в качестве коллекции, к которой
 происходит обращение на каждом шаге цикла. В цикле foreach соблюдаются правила,
 определенные в запросе и доступные по ссылке из переменной posNums. На каждом
 шаге цикла возвращается очередной элемент, полученный из массива. Этот процесс
 завершается, когда запрашиваемых элементов в массиве больше не обнаружено.
 В данном примере тип int переменной шага цикла i указывается явно, поскольку по
 запросу извлекаются элементы именно этого типа. Явное указание типа переменной
 шага цикла вполне допустимо в тех случаях, когда заранее известен тип значения, выбираемого
 по запросу. Но в более сложных случаях оказывается проще, а иногда даже
 нужно, указывать тип переменной шага цикла неявным образом с помощью ключевого
 слова var.

*/

#endregion

#region English

/*

19 CHAPTER LINQ

LINQ is without question one of the most exciting features in C#. It was added by
C# 3.0, and it represented a major addition to the language. Not only did it add
an entirely new syntactic element, several new keywords, and a powerful new
capability, but also it significantly increased the scope of the language, expanding the range
of tasks to which C# can be applied. Simply put, the addition of LINQ was a pivotal event
in the evolution of C#.

LINQ stands for Language-Integrated Query. It encompasses a set of features that
lets you retrieve information from a data source. As you may know, the retrieval of data
constitutes an important part of many programs. For example, a program might obtain
information from a customer list, look up product information in a catalog, or access an
employee’s record. In many cases, such data is stored in a database that is separate from
the application. For example, a product catalog might be stored in a relational database.
In the past, interacting with such a database would involve generating queries using SQL
(Structured Query Language). Other sources of data, such as XML, required their own
approaches. Therefore, prior to C# 3.0, support for such queries was not built into C#.
The addition of LINQ changed this.

LINQ gives to C# the ability to generate queries for any LINQ-compatible data source.
Furthermore, the syntax used for the query is the same—no matter what data source is
used. This means the syntax used to query data in a relational database is the same as
that used to query data stored in an array, for example. It is not necessary to use SQL
or any other non-C# mechanism. The query capability is fully integrated into the C#
language.

In addition to using LINQ with SQL, LINQ can be used with XML files and ADO.NET
Datasets. Perhaps equally important, it can also be used with C# arrays and collections
(described in Chapter 25). Therefore, LINQ gives you a uniform way to access data in
general. This is a powerful, innovative concept in its own right, but the benefits of LINQ do
not stop there. LINQ also offers a different way to think about and approach many types of
programming tasks—not just traditional database access. As a result, many solutions can be
crafted in terms of LINQ.

LINQ is supported by a set of interrelated features, including the query syntax added to
the C# language, lambda expressions, anonymous types, and extension methods. Lambda
expressions are described in Chapter 15. The others are examined here.

NOTE

LINQ in C# is essentially a language within a language. As a result, the subject of LINQ is
quite large, involving many features, options, and alternatives. Although this chapter describes
LINQ in significant detail, it is not possible to explore all facets, nuances, and applications of this
powerful feature. To do so would require an entire book of its own. Instead, this chapter focuses
on the core elements of LINQ and presents numerous examples. Going forward, LINQ is
definitely a subsystem that you will want to study in greater detail.

LINQ Fundamentals

At LINQ’s core is the query. A query specifies what data will be obtained from a data source.
For example, a query on a customer mailing list might request the addresses of all customers
that reside in a specific city, such as Chicago or Tokyo. A query on an inventory database
might request a list of out-of-stock items. A query on a log of Internet usage could ask for a
list of the websites with the highest hit counts. Although these queries differ in their specifics,
all can be expressed using the same LINQ syntactic elements.

After a query has been created, it can be executed. One way this is done is by using the
query in a foreach loop. Executing a query causes its results to be obtained. Thus, using a
query involves two key steps. First, the form of the query is created. Second, the query is
executed. Therefore, the query defines what to retrieve from a data source. Executing the
query actually obtains the results.

In order for a source of data to be used by LINQ, it must implement the IEnumerable
interface. There are two forms of this interface: one generic, one not. In general, it is easier
if the data source implements the generic version, IEnumerable<T>, where T specifies the
type of data being enumerated. The rest of the chapter assumes that a data source implements
IEnumerable<T>. This interface is declared in System.Collections.Generic. A class that
implements IEnumerable<T> supports enumeration, which means that its contents can
be obtained one at a time, in sequence. All C# arrays implicitly support IEnumerable<T>.
Thus, arrays can be used to demonstrate the central concepts of LINQ. Understand, however,
that LINQ is not limited to arrays.

A Simple Query

At this point, it will be helpful to work through a simple LINQ example. The following
program uses a query to obtain the positive values contained in an array of integers:

*/

// Create a simple LINQ query. 

//using System;  
//using System.Linq;  

//class SimpQuery
//{
//    static void Main()
//    {

//        int[] nums = { 1, -2, 3, 0, -4, 5 };

//        // Create a query that obtains only positive numbers.  
//        var posNums = from n in nums
//                      where n > 0
//                      select n;

//        Console.Write("The positive values in nums: ");

//        // Execute the query and display the results. 
//        foreach (int i in posNums) Console.Write(i + " ");

//        Console.ReadKey();
//    }
//}

/*

This program produces the following output:

The positive values in nums: 1 3 5

As you can see, only the positive values in the nums array are displayed. Although quite
simple, this program demonstrates the key features of LINQ. Let’s examine it closely.

The first thing to notice in the program is the using directive:

using System.Linq;

To use the LINQ features, you must include the System.Linq namespace.
Next, an array of int called nums is declared. All arrays in C# are implicitly convertible
to IEnumerable<T>. This makes any C# array usable as a LINQ data source.

Next, a query is declared that retrieves those elements in nums that are positive. It is
shown here:

var posNums = from n in nums
where n > 0
select n;

The variable posNums is called the query variable. It refers to the set of rules defined by the
query. Notice it uses var to implicitly declare posNums. As you know, this makes posNums
an implicitly typed variable. In queries, it is often convenient to use implicitly typed
variables, although you can also explicitly declare the type (which must be some form
of IEnumerable<T>). The variable posNums is then assigned the query expression.

All queries begin with from. This clause specifies two items. The first is the range
variable, which will receive elements obtained from the data source. In this case, the range
variable is n. The second item is the data source, which in this case is the nums array. The
type of the range variable is inferred from the data source. In this case, the type of n is int.
Generalizing, here is the syntax of the from clause:

from range-variable in data-source

The next clause in the query is where. It specifies a condition that an element in the data
source must meet in order to be obtained by the query. Its general form is shown here:

where boolean-expression

The boolean-expression must produce a bool result. (This expression is also called a predicate.)
There can be more than one where clause in a query. In the program, this where clause is used:

where n > 0

It will be true only for an element whose value is greater than zero. This expression will be
evaluated for every n in nums when the query executes. Only those values that satisfy this
condition will be obtained. In other words, a where clause acts as a filter on the data source,
allowing only certain items through.

All queries end with either a select clause or a group clause. This example employs the
select clause. It specifies precisely what is obtained by the query. For simple queries, such as
the one in this example, the range value is selected. Therefore, it returns those integers from
nums that satisfy the where clause. In more sophisticated situations, it is possible to finely
tune what is selected. For example, when querying a mailing list, you might return just the
last name of each recipient, rather than the entire address. Notice that the select clause ends
with a semicolon. Because select ends a query, it ends the statement and requires a semicolon.
Notice, however, that the other clauses in the query do not end with a semicolon.

At this point, a query variable called posNums has been created, but no results have
been obtained. It is important to understand that a query simply defines a set of rules. It is
not until the query is executed that results are obtained. Furthermore, the same query can
be executed two or more times, with the possibility of differing results if the underlying
data source changes between executions. Therefore, simply declaring the query posNums
does not mean that it contains the results of the query.

To execute the query, the program uses the foreach loop shown here:

foreach(int i in posNums) Console.WriteLine(i + " ");

Notice that posNums is specified as the collection being iterated over. When the foreach
executes, the rules defined by the query specified by posNums are executed. With each pass
through the loop, the next element returned by the query is obtained. The process ends when
there are no more elements to retrieve. In this case, the type of the iteration variable i is
explicitly specified as int because this is the type of the elements retrieved by the query.
Explicitly specifying the type of the iteration variable is fine in this situation, since it is easy
to know the type of the value selected by the query. However, in more complicated situations,
it will be easier (or in some cases, necessary) to implicitly specify the type of the iteration
variable by using var.

*/
#endregion