#region Russian

/*

 Режимы выполнения запросов: отложенный и немедленный

 В LINQ запросы выполняются в двух разных режимах: немедленном и отложенном.
 Как пояснялось ранее в этой главе, при формировании запроса определяется ряд правил,
 которые не выполняются вплоть до оператора цикла foreach. Это так называемое
 отложенное выполнение.

 Но если используются методы расширения, дающие результат, отличающийся от
 последовательности, то запрос должен быть выполнен для получения этого результата.

 Рассмотрим, например, метод расширения Count(). Для того чтобы этот метод
 возвратил количество элементов в последовательности, необходимо выполнить запрос,
 и это делается автоматически при вызове метода Count(). В этом случае имеет
 место немедленное выполнение, когда запрос выполняется автоматически для получения
 требуемого результата. Таким образом, запрос все равно выполняется, даже если он не
 используется явно в цикле foreach.

 Ниже приведен простой пример программы для получения количества положительных
 элементов, содержащихся в последовательности.

*/

// Использовать режим немедленного выполнения запроса.

using System;
using System.Linq;

class ImmediateExec
{
    static void Main()
    {
        int[] nums = { 1, -2, 3, 0, -4, 5 };

        //Сформировать запрос на получение количества
        //положительных значений в массиве nums.
        int len = (from n in nums
                   where n > 0
                   select n).Count();

        Console.WriteLine("Количество положительных значений в массиве nums: " + len);

        Console.ReadKey();
    }
}

/*

 Эта программа дает следующий результат.

 Количество положительных значений в массиве nums: 3

 Обратите внимание на то, что цикл foreach не указан в данной программе явным
 образом. Вместо этого запрос выполняется автоматически благодаря вызову метода
 расширения Count().

 Любопытно, что запрос из приведенной выше программы можно было бы сформировать
 и следующим образом.

 var posNums = from n in nums
 where n > 0
 select n;
 int len = posNums.Count(); // запрос выполняется здесь

 В данном случае метод Count() вызывается для переменной запроса. И в этот момент
 запрос выполняется для получения подсчитанного количества.

 К числу других методов расширения, вызывающих немедленное выполнение запроса,
 относятся методы ТоАrray() и ToList(). Оба этих метода расширения определены
 в классе Enumerable. Метод ToArray() возвращает результаты запроса в массиве,
 а метод ToList() — результаты запроса в форме коллекции List. (Подробнее
 о коллекциях речь пойдет в главе 25.) В обоих случаях для получения результатов выполняется
 запрос. Например, в следующем фрагменте кода сначала получается массив
 результатов, сформированных по приведенному выше запросу в переменной posNums,
 а затем эти результаты выводятся на экран.

 int[] pnums = posNum.ТоАrrау(); // запрос выполняется здесь
 foreach (int i in pnums)
    Console.Write(i + " ");

*/

#endregion

#region English

/*

Deferred vs. Immediate Query Execution

In LINQ, queries have two different modes of execution: immediate and deferred. As
explained early in this chapter, a query defines a set of rules that are not actually executed
until a foreach statement executes. This is called deferred execution.

However, if you use one of the extension methods that produces a non-sequence result,
then the query must be executed to obtain that result. For example, consider the Count()
method. In order for Count() to return the number of elements in the sequence, the query
must be executed, and this is done automatically when Count() is called. In this case,
immediate execution takes place, with the query being executed automatically in order to
obtain the result. Therefore, even though you don’t explicitly use the query in a foreach
loop, the query is still executed.

Here is a simple example. It obtains the number of positive elements in the sequence.

*/

// Use immediate execution.

//using System;  
//using System.Linq;  

//class ImmediateExec
//{
//    static void Main()
//    {

//        int[] nums = { 1, -2, 3, 0, -4, 5 };

//        // Create a query that obtains the number of positive 
//        // values in nums. 
//        int len = (from n in nums
//                   where n > 0
//                   select n).Count();

//        Console.WriteLine("The number of positive values in nums: " + len);

//        Console.ReadKey();
//    }
//}

/*

The output is

The number of positive values in nums: 3

In the program, notice that no explicit foreach loop is specified. Instead, the query
automatically executes because of the call to Count().

As a point of interest, the query in the preceding program could also have been written
like this:

var posNums = from n in nums
where n > 0
select n;
int len = posNums.Count(); // query executes here

In this case, Count() is called on the query variable. At that point, the query is executed to
obtain the count.

Other methods that cause immediate execution of a query include ToArray() and
ToList(). Both are extension methods defined by Enumerable. ToArray() returns the results
of a query in an array. ToList() returns the results of a query in the form of a List collection.
(See Chapter 25 for a discussion of collections.) In both cases, the query is executed to obtain
the results. For example, the following sequence obtains an array of the results generated by
the posNums query just shown. It then displays the results.

int[] pnums = posNum.ToArray(); // query executes here

foreach(int i in pnums)
Console.Write(i + " ");

*/

#endregion
