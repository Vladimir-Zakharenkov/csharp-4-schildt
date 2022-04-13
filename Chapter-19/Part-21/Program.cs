#region Russian

/*

 Методы расширения, связанные с запросами, можно также использовать в самом
 запросе, основываясь на синтаксисе запросов, предусмотренном в С#. И в действительности
 это делается очень часто. Например, метод Average() используется в приведенной
 ниже программе для получения последовательности, состоящей только из тех
 значений, которые оказываются меньше среднего всех значений в массиве.

*/


// Использовать метод Average() вместе с синтаксисом запросов.

using System;
using System.Linq;

class ExtMethods2
{
    static void Main()
    {
        int[] nums = { 1, 2, 4, 8, 6, 9, 10, 3, 6, 7 };

        var ltAvg = from n in nums
                    let x = nums.Average()
                    where n < x
                    select n;

        Console.WriteLine("Среднее значение равно " + nums.Average());

        Console.Write("Значения меньше среднего: ");

        //Выполнить запрос и вывести его результаты.
        foreach (int i in ltAvg)
        {
            Console.Write(i + " ");
        }

        Console.ReadKey();
    }
}

/*

 При выполнении этой программы получается следующий результат.

 Среднее значение равно 5.6
 Значения меньше среднего: 1 2 4 3

 Обратите особое внимание в этой программе на следующий код запроса.

 var ltAvg = from n in nums
 let x = nums.Average()
 where n<x
 select n;

 Как видите, переменной x в операторе let присваивается среднее всех значений
 в массиве nums. Это значение получается в результате вызова метода Average() для
 массива nums.

*/

#endregion

#region English

/*

You can also use the query-related extension methods within a query based on the C#
query syntax. In fact, it is quite common to do so. For example, this program uses Average()
to obtain a sequence that contains only those values that are less than the average of the
values in an array.

*/

// Use Average() with the query syntax. 

//using System;  
//using System.Linq;  

//class ExtMethods2
//{
//    static void Main()
//    {

//        int[] nums = { 1, 2, 4, 8, 6, 9, 10, 3, 6, 7 };

//        var ltAvg = from n in nums
//                    let x = nums.Average()
//                    where n < x
//                    select n;

//        Console.WriteLine("The average is " + nums.Average());

//        Console.Write("These values are less than the average: ");

//        // Execute the query and display the results. 
//        foreach (int i in ltAvg) Console.Write(i + " ");

//        Console.ReadKey();
//    }
//}


/*

The output is shown here:

The average is 5.6
These values are less than the average: 1 2 4 3

Pay special attention to the query:

var ltAvg = from n in nums
let x = nums.Average()
where n < x
select n;

Notice in the let statement, x is set equal to the average of the values in nums. This value is
obtained by calling Average() on nums.

*/

#endregion


