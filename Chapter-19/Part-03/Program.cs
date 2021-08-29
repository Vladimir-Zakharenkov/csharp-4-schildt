#region Russian

/*

 Связь между типами данных в запросе

 Как показывает предыдущий пример, запрос включает в себя переменные, типы
 которых связаны друг с другом. К их числу относятся переменная запроса, переменная
 диапазона и источник данных. Соблюсти соответствие этих типов данных очень важно,
 но в то же время нелегко — по крайней мере, так кажется на первый взгляд, поэтому
 данный вопрос заслуживает более пристального внимания.

 Тип переменной диапазона должен соответствовать типу элементов, хранящихся
 в источнике данных. Следовательно, тип переменной диапазона зависит от типа
 источника данных. Как правило, тип переменной диапазона может быть выведен
 средствами С#. Но выводимость типов может быть осуществлена при условии, что
 в источнике данных реализована форма интерфейса IEnumerable<T>, где Т обозначает
 тип элементов в источнике данных. (Как упоминалось выше, форма интерфейса
 IEnumerable<T> реализуется во всех массивах, как, впрочем, и во многих других источниках
 данных.) Но если в источнике данных реализован необобщенный вариант
 интерфейса IEnumerable, то тип переменной диапазона придется указывать явно.
 И это делается в операторе from. Ниже приведен пример явного объявления типа
int переменной диапазона n.

 var posNums = from int n in nums
 // ...

 Очевидно, что явное указание типа здесь не требуется, поскольку все массивы неявно
 преобразуются в форму интерфейса IEnumerable<T>, которая позволяет вывести
 тип переменной диапазона.

 Тип объекта, возвращаемого по запросу, представляет собой экземпляр интерфейса
 IEnumerable<T>, где Т — тип получаемых элементов. Следовательно, тип переменной
 запроса должен быть экземпляром интерфейса IEnumerable<T>, а значение
 Т должно определяться типом значения, указываемым в операторе select. В предыдущих
 примерах значению Т соответствовал тип int, поскольку переменная n имела
 тип int. (Как пояснялось выше, переменная n относится к типу int, потому что элементы
 именно этого типа хранятся в массиве nums.) С учетом явного указания типа
 IEnumerable<int> упомянутый выше запрос можно было бы составить следующим образом.

 IEnumerable<int> posNums = from n in nums
 where n > 0
 select n;

 Следует иметь в виду, что тип элемента, выбираемого оператором select, должен
 соответствовать типу аргумента, передаваемого форме интерфейса IEnumerable<T>,
 используемой для объявления переменной запроса. Зачастую при объявлении переменных
 запроса используется ключевое слово var вместо явного указания ее типа,
 поскольку это дает компилятору возможность самому вывести соответствующий тип
 данной переменной из оператора select. Как будет показано далее в этой главе, такой
 подход оказывается особенно удобным в тех случаях, когда оператор select возвращает
 из источника данных нечто более существенное, чем отдельный элемент.

 Когда запрос выполняется в цикле foreach, тип переменной шага цикла должен
 быть таким же, как и тип переменной диапазона. В предыдущих примерах тип этой
 переменной указывался явно как int. Но имеется и другая возможность: предоставить
 компилятору самому вывести тип данной переменной, и для этого достаточно указать
 ее тип как var. Как будет показано далее в этой главе, ключевое слово var приходится
 использовать и в тех случаях, когда тип данных просто неизвестен.

 Общая форма запроса

 У всех запросов имеется общая форма, основывающаяся на ряде приведенных ниже
 контекстно-зависимых ключевых слов.

 ascending        by        descending      equals
 from             group     in              into
 join             let       on              orderby
 select           where

Среди них лишь приведенные ниже ключевые слова используются в начале операторов запроса.

 from     group       join        let
 orderby  select      where

 Запрос должен начинаться с ключевого слова from и оканчиваться ключевым словом
 select или group. Оператор select определяет тип значения, перечисляемого
 по запросу, а оператор group возвращает данные группами, причем каждая группа
 может перечисляться по отдельности. Как следует из приведенных выше примеров,
 в операторе where указываются критерии, которым должен удовлетворять искомый
 элемент, чтобы быть полученным по запросу. А остальные операторы позволяют уточнить
 запрос. Все они рассматриваются далее по порядку.

 Отбор запрашиваемых значений с помощью оператора where

 Как пояснялось выше, оператор where служит для отбора данных, возвращаемых
 по запросу. В предыдущих примерах этот оператор был продемонстрирован в своей
 простейшей форме, в которой для отбора данных используется единственное условие.
 Однако для более тщательного отбора данных можно задать несколько условий
 и, в частности, в нескольких операторах where. В качестве примера рассмотрим следующую
 программу, в которой из массива выводятся только те значения, которые положительны
 и меньше 10.

*/

// Использовать несколько операторов where.

using System;
using System.Linq;

class TowWheres
{
    static void Main()
    {
        int[] nums = { 1, -2, 3, -3, 0, -8, 12, 19, 6, 9, 10 };

        //Сформировать запрос на получение положительных значений меньше 10.
        var posNums = from n in nums
                      where n > 0
                      where n < 10
                      select n;

        Console.Write("Положительные значения меньшие 10: ");

        // Выполняем запрос и выводим результаты.
        foreach (int i in posNums)
        {
            Console.Write(i + " ");
        }

        Console.ReadKey();
    }
}

/*

 Эта программа дает следующий результат.

 Положительные значения меньше 10: 1 3 6 9

 Как видите, по данному запросу извлекаются только положительные значения
 меньше. 10. Этот результат достигается благодаря двум следующим операторам where.

 where n > 0
 where n < 10

 Условие в первом операторе where требует, чтобы элемент массива был больше
 нуля. А условие во втором операторе where требует, чтобы элемент массива был меньше
 10. Следовательно, запрашиваемый элемент массива должен находиться в пределах
 от 1 до 9 (включительно), чтобы удовлетворять обоим условиям.

 В таком применении двух операторов where для отбора данных нет ничего дурного,
 но аналогичного эффекта можно добиться с помощью более компактно составленного
 условия в единственном операторе where. Ниже приведен тот же самый запрос,
 переформированный по этому принципу.

 var posNums = from n in nums
 where n > 0 & n < 10
 select n;

*/

#endregion

#region English

/*

How the Data Types in a Query Relate 

As the preceding examples have shown, a query involves variables whose types relate to
one another. These are the query variable, the range variable, and the data source. Because
the correspondence among these types is both important and a bit confusing at first, they
merit a closer look.

The type of the range variable must agree with the type of the elements stored in the
data source. Thus, the type of the range variable is dependent upon the type of the data
source. In many cases, C# can infer the type of the range variable. As long as the data source
implements IEnumerable<T>, the type inference can be made because T describes the type
of the elements in the data source. However, if the data source implements the non-generic
version of IEnumerable, then you will need to explicitly specify the type of the range
variable. This is done by specifying its type in the from clause. For example, assuming
the preceding examples, this shows how to explicitly declare n to be an int:

var posNums = from int n in nums
// ...

Of course, the explicit type specification is not needed here because all arrays are implicitly
convertible to IEnumerable<T>, which enables the type of the range variable to be inferred.

The type of object returned by a query is an instance of IEnumerable<T>, where T is
the type of the elements. Thus, the type of the query variable must be an instance of
IEnumerable<T>. The value of T is determined by the type of the value specified by the
select clause. In the case of the preceding examples, T is int because n is an int. (As explained,
n is an int because int is the type of elements stored in nums.) Therefore, the query could
have been written like this, with the type explicitly specified as IEnumerable <int>:

IEnumerable<int> posNums = from n in nums
where n > 0
select n;

The key point is that the type of the item selected by select must agree with the type
argument passed to IEnumerable<T> used to declare the query variable. Often query
variables use var rather than explicitly specifying the type because this lets the compiler
infer the proper type from the select clause. As you will see, this approach is particularly
useful when select returns something other than an individual element from the data source.

When a query is executed by the foreach loop, the type of the iteration variable must
be the same as the type specified by the select clause. In the preceding examples, this type
was explicitly specified as int, but you can let the compiler infer the type by declaring this
variable as var. As you will see, there are also some cases in which var must be used because
the data type has no name.

The General Form of a Query

All queries share a general form, which is based on a set of contextual keywords, shown here:

 ascending        by        descending      equals
 from             group     in              into
 join             let       on              orderby
 select           where

Of these, the following begin query clauses:

 from     group       join        let
 orderby  select      where

A query must begin with the keyword from and end with either a select or group clause.
The select clause determines what type of value is enumerated by the query. The group
clause returns the data by groups, with each group being able to be enumerated individually.
As the preceding examples have shown, the where clause specifies criteria that an item
must meet in order for it to be returned. The remaining clauses help you fine-tune a query.
The follows sections examine each query clause.

Filter Values with where
As explained, where is used to filter the data returned by a query. The preceding examples
have shown only its simplest form, in which a single condition is used. A key point to
understand is that you can use where to filter data based on more than one condition. One
way to do this is through the use of multiple where clauses. For example, consider the
following program that displays only those values in the array that are both positive and
less than 10:

*/

// Use multiple where clauses. 

//using System;  
//using System.Linq;  

//class TwoWheres
//{
//    static void Main()
//    {

//        int[] nums = { 1, -2, 3, -3, 0, -8, 12, 19, 6, 9, 10 };

//        // Create a query that obtains positive values less than 10.  
//        var posNums = from n in nums
//                      where n > 0
//                      where n < 10
//                      select n;

//        Console.Write("The positive values less than 10: ");

//        // Execute the query and display the results. 
//        foreach (int i in posNums) Console.Write(i + " ");

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

The positive values less than 10: 1 3 6 9

As you can see, only positive values less than 10 are retrieved. This outcome is achieved by
the use of the following two where clauses:

where n > 0
where n < 10

The first where requires that an element be greater than zero. The second requires the
element to be less than 10. Thus, an element must be between 1 and 9 (inclusive) to satisfy
both clauses.

Although it is not wrong to use two where clauses as just shown, the same effect can be
achieved in a more compact manner by using a single where in which both tests are combined
into a single expression. Here is the query rewritten to use this approach:

var posNums = from n in nums
where n > 0 && n < 10
select n;


*/

#endregion
