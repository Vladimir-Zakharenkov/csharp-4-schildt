#region Russian

/*

 Синтаксис запросов и методы запроса

 Как пояснялось в предыдущем разделе, запросы в C# можно формировать двумя
 способами, используя синтаксис запросов или методы запроса. Любопытно, что оба
 способа связаны друг с другом более тесно, чем кажется, глядя на исходный код программы.
 Дело в том, что синтаксис запросов компилируется в вызовы методов запроса.
 Поэтому код

 where х < 10

 будет преобразован компилятором в следующий вызов.

 Where(х => х < 10)

 Таким образом, оба способа формирования запросов в конечном итоге сходятся на
 одном и том же.

 Но если оба способа оказываются в конечном счете равноценными, то какой из них
 лучше для программирования на С#? В целом, рекомендуется чаще пользоваться синтаксисом
 запросов, поскольку он полностью интегрирован в язык С#, поддерживается
 соответствующими ключевыми словами и синтаксическим конструкциями.

 Дополнительные методы расширения, связанные с запросами

 Помимо методов, соответствующих операторам запроса, поддерживаемым в С#, имеется
 ряд других методов расширения, связанных с запросами и зачастую оказывающих
 помощь в формировании запросов. Эти методы предоставляются в среде .NET Framework
 определены для интерфейса IEnumerable<T> в классе Enumerable. Ниже приведены
 наиболее часто используемые методы расширения, связанные с запросами. Многие
 из них могут перегружаться, поэтому они представлены лишь в самой общей форме.

 Метод             Описание
 All(predicate)    Возвращает логическое значение true, если все элементы в последовательности
                   удовлетворяют условию, задаваемому параметром predicate
 Any(predicate)    Возвращает логическое значение true, если любой элемент в последовательности
                   удовлетворяет условию, задаваемому параметром predicate
 Average()         Возвращает среднее всех значений в числовой последовательности
 Contains(value)   Возвращает логическое значение true, если в последовательности
                   содержится указанный объект
 Count()           Возвращает длину последовательности, т.е. количество составляющих ее элементов
 First()           Возвращает первый элемент в последовательности
 Last()            Возвращает последний элемент в последовательности
 Max()             Возвращает максимальное значение в последовательности
 Min()             Возвращает минимальное значение в последовательности
 Sum()             Возвращает сумму значений в числовой последовательности

 Метод Count() уже демонстрировался ранее в этой главе. А в следующей программе
 демонстрируются остальные методы расширения, связанные с запросами.

*/

// Использовать ряд методов расширения, определенных в классе Enumerable.

using System;
using System.Linq;

class ExtMethod
{
    static void Main()
    {
        int[] nums = { 3, 1, 2, 5, 4 };

        Console.WriteLine("Минимальное значение равно " + nums.Min());
        Console.WriteLine("Максимальное значение равно " + nums.Max());

        Console.WriteLine("Первое значение равно " + nums.First());
        Console.WriteLine("Последнее значение равно " + nums.Last());

        Console.WriteLine("Суммарное значение равно " + nums.Sum());
        Console.WriteLine("Среднее значение равно " + nums.Average());

        if (nums.All(n => n > 0))
        {
            Console.WriteLine("Все значения больше нуля.");
        }

        if (nums.Any(n => (n % 2) == 0))
        {
            Console.WriteLine("По крайне мере одно значение является четным.");
        }

        if (nums.Contains(3))
        {
            Console.WriteLine("Массив содержит значение 3.");
        }

        Console.ReadKey();
    }
}

/*

 Вот к какому результату приводит выполнение этой программы.

 Минимальное значение равно 1
 Максимальное значение равно 5
 Первое значение равно 3
 Последнее значение равно 4
 Суммарное значение равно 15
 Среднее значение равно 3
 Все значения больше нуля.
 По крайней мере одно значение является четным
 Массив содержит значение 3.

*/

#endregion

#region English

/*

Query Syntax vs. Query Methods

As the preceding section has explained, C# has two ways of creating queries: the query
syntax and the query methods. What is interesting, and not readily apparent by simply
looking at a program’s source code, is that the two approaches are more closely related than
you might at first assume. The reason is that the query syntax is compiled into calls to the
query methods. Thus, when you write something like

where x < 10

the compiler translates it into

Where(x => x < 10)

Therefore, the two approaches to creating a query ultimately lead to the same place.

Given that the two approaches are ultimately equivalent, the following question
naturally arises: Which approach is best for a C# program? The answer: In general, you
will want to use the query syntax. It is fully integrated into the C# language, supported
by keywords and syntax, and is cleaner.

More Query-Related Extension Methods

In addition to the methods that correspond to the query keywords supported by C#, the
.NET Framework provides several other query-related extension methods that are often
helpful in a query. These query-related methods are defined for IEnumerable<T> by
Enumerable. Here is a sampling of several commonly used methods. Because many of
the methods are overloaded, only their general form is shown.

Method              Description
All(predicate)      Returns true if all elements in a sequence satisfy a specified condition.
Any(predicate)      Returns true if any element in a sequence satisfies a specified condition.
Average()           Returns the average of the values in a numeric sequence.
Contains(value)     Returns true if the sequence contains the specified object.
Count()             Returns the length of a sequence. This is the number of elements that it contains.
First()             Returns the first element in a sequence.
Last()              Returns the last element in a sequence.
Max()               Returns the maximum value in a sequence.
Min()               Returns the minimum value in a sequence.
Sum()               Returns the summation of the values in a numeric sequence.

You have already seen Count() in action earlier in this chapter. Here is a program that
demonstrates the others:

*/

// Use several of the extension methods defined by Enumerable. 

//using System;  
//using System.Linq;  

//class ExtMethods
//{
//    static void Main()
//    {

//        int[] nums = { 3, 1, 2, 5, 4 };

//        Console.WriteLine("The minimum value is " + nums.Min());
//        Console.WriteLine("The maximum value is " + nums.Max());

//        Console.WriteLine("The first value is " + nums.First());
//        Console.WriteLine("The last value is " + nums.Last());

//        Console.WriteLine("The sum is " + nums.Sum());
//        Console.WriteLine("The average is " + nums.Average());

//        if (nums.All(n => n > 0))
//            Console.WriteLine("All values are greater than zero.");

//        if (nums.Any(n => (n % 2) == 0))
//            Console.WriteLine("At least one value is even.");

//        if (nums.Contains(3))
//            Console.WriteLine("The array contains 3.");

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

The minimum value is 1
The maximum value is 5
The first value is 3
The last value is 4
The sum is 15
The average is 3
All values are greater than zero.
At least one value is even.
The array contains 3.

*/

#endregion