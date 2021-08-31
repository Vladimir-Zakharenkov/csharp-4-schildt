#region Russian

/*

 Методы запроса

 Синтаксис запроса, описанный в предыдущих разделах, применяется при формировании
 большинства запросов в С#. Он удобен, эффективен и компактен, хотя и не
 является единственным способом формирования запросов. Другой способ состоит
 в использовании методов запроса, которые могут вызываться для любого перечислимого
 объекта, например массива.

 Основные методы запроса

 Методы запроса определяются в классе System.Linq.Enumerable и реализуются
 в виде методов расширения функций обобщенной формы интерфейса IEnumerable<T>.
 (Методы запроса определяются также в классе System.Linq.Queryable, расширяющем
 функции обобщенной формы интерфейса IQueryable<T>, но этот интерфейс
 в настоящей главе не рассматривается.) Метод расширения дополняет функции другого
 класса, но без наследования. Поддержка методов расширения была внедрена в версию
 C# 3.0 и более подробно рассматривается далее в этой главе. А до тех пор достаточно
 сказать, что методы запроса могут вызываться только для тех объектов, которые
 реализуют интерфейс IEnumerable<T>.

 В классе Enumerable предоставляется немало методов запроса, но основными считаются
 те методы, которые соответствуют описанным ранее операторам запроса. Эти
 методы перечислены ниже вместе с соответствующими операторами запроса. Следует,
 однако, иметь в виду, что эти методы имеют также перегружаемые формы, а здесь они
 представлены лишь в самой простой своей форме. Но именно эта их форма используется
 чаще всего.

 Оператор запроса     Эквивалентный метод запроса
 select               Select(selector)
 where                Where(predicate)
 orderby              OrderBy(keySelector) или OrderByDescending(keySelector)
 join                 Join(inner, outerKeySelector, innerKeySelector, resultSelector)
 group                GroupBy(keySelector)


 За исключением метода Join(), остальные методы запроса принимают единственный
 аргумент, который представляет собой объект некоторой разновидности
 обобщенного типа Func<T, TResult>. Это тип встроенного делегата, объявляемый
 следующим образом:

 delegate TResult Func<in Т, out TResult>(T arg)

 где TResult обозначает тип результата, который дает делегат, а Т — тип элемента.
 В методах запроса аргументы selector, predicate или keySelector определяют
 действие, которое предпринимает метод запроса. Например, в методе Where() аргумент
 prediсаte определяет порядок отбора данных в запросе. Каждый метод запроса
 возвращает перечислимый объект. Поэтому результат выполнения одного метода запроса
 можно использовать для вызова другого, соединяя эти методы в цепочку.

 Метод Join() принимает четыре аргумента. Первый аргумент (inner) представляет
 собой ссылку на вторую объединяемую последовательность, а первой является последовательность,
 для которой вызывается метод Join(). Селектор ключа для первой последовательности
 передается в качестве аргумента outerKeySelector, а селектор ключа для
 второй последовательности — в качестве аргумента LnnerKeySelector. Результат объединения
 обозначается как аргумент resultSelector. Аргумент outerKeySelector
 имеет тип Func<TOuter, ТКеу>, аргумент innerKeySelector — тип Func<TInner, ТКеу>,
 тогда как аргумент resultSelector — тип Func<TOuter, Tinner, TResult>,
 где TOuter — тип элемента из вызывающей последовательности; Tinner — тип элемента
 из передаваемой последовательности; TResult — тип элемента из объединяемой
 в итоге последовательности, возвращаемой в виде перечислимого объекта.

 Аргумент метода запроса представляет собой метод, совместимый с указываемой
 формой делегата Func, но он не обязательно должен быть явно объявляемым методом.
 На самом деле вместо него чаще всего используется лямбда-выражение. Как пояснялось
 в главе 15, лямбда-выражение обеспечивает более простой, но эффективный
 способ определения того, что, по существу, является анонимным методом, а компилятор
 C# автоматически преобразует лямбда-выражение в форму, которая может быть
 передана в качестве параметра делегату Func. Благодаря тому что лямбда-выражения
 обеспечивают более простой и рациональный способ программирования, они используются
 во всех примерах, представленных далее в этом разделе.

 Формирование запросов с помощью методов запроса

 Используя методы запроса одновременно с лямбда-выражениями, можно формировать
 запросы, вообще не пользуясь синтаксисом, предусмотренным в C# для запросов.
 Вместо этого достаточно вызвать соответствующие методы запроса. Обратимся
 сначала к простому примеру. Он представляет собой вариант первого примера программы
 из этой главы, переделанный с целью продемонстрировать применение методов
 запроса Where() и Select() вместо соответствующих операторов.

*/


// Использовать методы запроса для формирования простого запроса.
// Это переделанный вариант первого примера программы из настоящей главы.

using System;
using System.Linq;

class SimpQuery
{
    static void Main()
    {
        int[] nums = { 1, -2, 3, 0, -4, 5 };

        //Использовать методы Where() и Select()
        //для формирования простого запроса.
        var posNums = nums.Where(n => n > 0).Select(r => r);

        Console.Write("Положительные значения из массива nums: ");

        //Выполнить запрос и вывести его результаты.
        foreach (int i in posNums)
        {
            Console.Write(" " + i);
        }

        Console.ReadKey();
    }
}

/*

 Эта версия программы дает такой же результат, как и исходная.

 Положительные значения из массива nums: 1 3 5

 Обратите особое внимание в данной программе на следующую строку кода.

 var posNums = nums.Where(n => n > 0).Select(r => r);

 В этой строке кода формируется запрос, сохраняемый в переменной posNums. По
 этому запросу, в свою очередь, формируется последовательность положительных значений,
 извлекаемых из массива nums. Для этой цели служит метод Where(), отбирающий
 запрашиваемые значения, а также метод Select(), избирательно формирующий
 из этих значений окончательный результат. Метод Where() может быть вызван для
 массива nums, поскольку во всех массивах реализуется интерфейс IEnumerable<T>,
 поддерживающий методы расширения запроса.

 Формально метод Select() в рассматриваемом здесь примере не нужен, поскольку
 это простой запрос. Ведь последовательность, возвращаемая методом Where(), уже
 содержит конечный результат. Но окончательный выбор можно сделать и по более
 сложному критерию, как это было показано ранее на примерах использования синтаксиса
 запросов. Так, по приведенному ниже запросу из массива nums возвращаются
 положительные значения, увеличенные на порядок величины.

 var posNums = nums.Where(n => n > 0).Select(r => r * 10);

 Как и следовало ожидать, в цепочку можно объединять и другие операции над данными,
 получаемыми по запросу. Например, по следующему запросу выбираются положительные
 значения, которые затем сортируются по убывающей и возвращаются в
 виде результирующей последовательности:

 var posNums = nums.Where(n => n > 0).OrderByDescending(j => j);

 где выражение j => j обозначает, что упорядочение зависит от входного параметра,
 который является элементом данных из последовательности, получаемой из метода Where().

*/

#endregion

#region English

/*

The Query Methods

The query syntax described by the preceding sections is the way you will probably write
most queries in C#. It is convenient, powerful, and compact. It is, however, not the only way
to write a query. The other way is to use the query methods. These methods can be called on
any enumerable object, such as an array.

The Basic Query Methods

The query methods are defined by System.Linq.Enumerable and are implemented as
extension methods that extend the functionality of IEnumerable<T>. (Query methods are
also defined by System.Linq.Queryable, which extends the functionality of IQueryable<T>,
but this interface is not used in this chapter.) An extension method adds functionality to
another class, but without the use of inheritance. Support for extension methods is relatively
new, being added by C# 3.0, and we will look more closely at them later in this chapter. For
now, it is sufficient to understand that query methods can be called only on an object that
implements IEnumerable<T>.

The Enumerable class provides many query methods, but at the core are those that
correspond to the query keywords described earlier. These methods are shown here, along
with the keywords to which they relate. Understand that these methods have overloaded
forms and only their simplest form is shown. However, this is also the form that you will
often use.

Query Keyword       Equivalent Query Method
select              Select(selector)
where               Where(predicate)
orderby             OrderBy(keySelector) or OrderByDescending(keySelector)
join                Join(inner, outerKeySelector, innerKeySelector, resultSelector)
group               GroupBy(keySelector)

Except for Join( ), these query methods take one argument, which is an object of some
form of the generic type Func<T, TResult>. This is a built-in delegate type that is declared
like this:

delegate TResult Func<in T, out TResult>(T arg)

Here, TResult specifies the result type of the delegate and T specifies the element type.
In these query methods, the selector, predicate, or keySelector argument determines what
action the query method takes. For example, in the case of Where(), it determines how the
query filters the data. Each of these query methods returns an enumerable object. Thus,
the result of one can be used to execute a call on another, allowing the methods to be
chained together.

The Join() method takes four arguments. The first is a reference to the second sequence
to be joined. The first sequence is the one on which Join() is called. The key selector for the
first sequence is passed via outerKeySelector, and the key selector for the second sequence is
passed via innerKeySelector. The result of the join is described by resultSelector. The type of
outerKeySelector is Func<TOuter, TKey>, and the type of innerKeySelector is Func<TInner,
TKey>. The resultSelector argument is of type Func<TOuter, TInner, TResult>. Here,
TOuter is the element type of the invoking sequence; TInner is the element type of the
passed sequence; and TResult is the type of the resulting elements. An enumerable object
is returned that contains the result of the join.

Although an argument to a query method such as Where() is a method compatible with
the specified form of the Func delegate, it does not need to be an explicitly declared method.
In fact, most often it won’t be. Instead, you will usually use a lambda expression. As explained
in Chapter 15, a lambda expression offers a streamlined, yet powerful way to define what
is, essentially, an anonymous method. The C# compiler automatically converts a lambda
expression into a form that can be passed to a Func parameter. Because of the convenience
offered by lambda expressions, they are used by all of the examples in this section.

Create Queries by Using the Query Methods

By using the query methods in conjunction with lambda expressions, it is possible to create
queries that do not use the C# query syntax. Instead, the query methods are called. Let’s
begin with a simple example. It reworks the first program in this chapter so that it uses calls
to Where() and Select() rather than the query keywords.
*/

// Use the query methods to create a simple query. 
// This is a reworked version of the first program in this chapter. 

//using System;  
//using System.Linq;  

//class SimpQuery
//{
//    static void Main()
//    {

//        int[] nums = { 1, -2, 3, 0, -4, 5 };

//        // Use Where() and Select() to create a simple query. 
//        var posNums = nums.Where(n => n > 0).Select(r => r);

//        Console.Write("The positive values in nums: ");

//        // Execute the query and display the results. 
//        foreach (int i in posNums) Console.Write(i + " ");

//        Console.ReadKey();
//    }
//}

/*

The output, shown here, is the same as the original version:

The positive values in nums: 1 3 5

In the program, pay special attention to this line:

var posNums = nums.Where(n => n > 0).Select(r => r);

This creates a query called posNums that creates a sequence of the positive values in nums.
It does this by use of the Where() method (to filter the values) and Select( ) (to select the
values). The Where() method can be invoked on nums because all arrays implement
IEnumerable<T>, which supports the query extension methods.

Technically, the Select() method in the preceding example is not necessary because in
this simple case, the sequence returned by Where() already contains the result. However,
you can use more sophisticated selection criteria, just as you did with the query syntax. For
example, this query returns the positive values in nums increased by an order of magnitude:

var posNums = nums.Where(n => n > 0).Select(r => r * 10);

As you might expect, you can chain together other operations. For example, this query
selects the positive values, sorts them into descending order, and returns the resulting
sequence:

var posNums = nums.Where(n => n > 0).OrderByDescending(j => j);

Here, the expression j => j specifies that the ordering is dependent on the input parameter,
which is an element from the sequence obtained from Where().

*/

#endregion