#region Russian

/*

Неоднократное выполнение запросов

 Итак, в запросе определяются правила, по которым извлекаются данные, но этого
 явно недостаточно для получения результатов, поскольку запрос должен быть выполнен,
 причем это может быть сделано несколько раз. Если же в промежутке между последовательно
 производимыми попытками выполнить один и тот же запрос источник
 данных изменяется, то получаемые результаты могут отличаться. Поэтому как только
 запрос определен, его выполнение будет всегда давать только самые последние результаты.
 Обратимся к конкретному примеру. Ниже приведен другой вариант рассматриваемой
 здесь программы, где содержимое массива nums изменяется в промежутке
 между двумя последовательно производимыми попытками выполнить один и тот же
 запрос, хранящийся в переменной posNums.

*/

//Сформировать простой запрос.
using System;
using System.Linq;
using System.Collections.Generic;

class SimpQuery
{
    static void Main()
    {
        int[] nums = { 1, -2, 3, 0, -4, 5 };

        //Сформировать простой запрос на получение только положительных значений.
        IEnumerable<int> posNums = from n in nums
                                   where n > 0
                                   select n;

        Console.Write("Положительные значения из массива nums: ");

        //Выполнить запрос и отобразить его результаты.
        foreach (int i in posNums)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("\n");

        //Внести изменения в массив nums.
        nums[1] = 99;

        Console.Write("Положительные значения из массива nums\n" + "после изменения в нем: ");

        //Выполнить запрос второй раз.
        foreach (int i in posNums)
        {
            Console.Write(i + " ");
        }

        Console.ReadKey();
    }
}

/*

 Вот к какому результату приводит выполнение этой программы.

 Положительные значения из массива nums: 1 3 5
 Задать значение 99 для элемента массива nums[l].

 Положительные значения из массива nums
 после изменений в нем: 1 99 3 5

 Как следует из результата выполнения приведенной выше программы, значение
 элемента массива nums[1] изменилось с -2 на 99, что и отражают результаты повторного
 выполнения запроса. Этот важный момент следует подчеркнуть особо. Каждая
 попытка выполнить запрос приносит свои результаты, получаемые при перечислении
 текущего содержимого источника данных. Поэтому если источник данных претерпевает
 изменения, то могут измениться и результаты выполнения запроса. Преимущества
 такого подхода к обработке запросов весьма значительны. Так, если по запросу получается
 список необработанных заказов в Интернет-магазине, то при каждой попытке
 выполнить запрос желательно получить сведения обо всех заказах, включая и только
 что введенные.

*/

#endregion

#region English

/*

A Query Can Be Executed More Than Once

Because a query defines a set of rules that are used to retrieve data, but does not, itself,
produce results, the same query can be run multiple times. If the data source changes
between runs, then the results of the query may differ. Therefore, once you define a query,
executing it will always produce the most current results. Here is an example. In the
following version of the preceding program, the contents of the nums array are changed
between two executions of posNums:

*/

// Create a simple query. 

//using System;  
//using System.Linq;  
//using System.Collections.Generic; 

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

//        Console.WriteLine("\n");

//        // Change nums. 
//        Console.WriteLine("\nSetting nums[1] to 99.");
//        nums[1] = 99;

//        Console.Write("The positive values in nums after change: ");

//        // Execute the query a second time. 
//        foreach (int i in posNums) Console.Write(i + " ");

//        Console.ReadKey();
//    }
//}

/*

The following output is produced:

The positive values in nums: 1 3 5
Setting nums[1] to 99.

The positive values in nums after change: 1 99 3 5

As the output confirms, after the value in nums[1] was changed from –2 to 99, the result
of rerunning the query reflects the change. This is a key point that must be emphasized.
Each execution of a query produces its own results, which are obtained by enumerating the
current contents of the data source. Therefore, if the data source changes, so, too, might the
results of executing a query. The benefits of this approach are quite significant. For example,
if you are obtaining a list of pending orders for an online store, then you want each execution
of your query to produce all orders, including those just entered.

*/

#endregion