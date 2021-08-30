#region Russian

/*

 Подробное рассмотрение оператора select

 Оператор select определяет конкретный тип элементов, получаемых по запросу.
 Ниже приведена его общая форма.

 select выражение

 В предыдущих примерах оператор select использовался для возврата переменной
 диапазона. Поэтому выражение в нем просто обозначало имя переменной диапазона.
 Но применение оператора select не ограничивается только этой простой
 функцией. Он может также возвращать отдельную часть значения переменной диапазона,
 результат выполнения некоторой операции или преобразования переменной
 диапазона и даже новый тип объекта, конструируемого из отдельных фрагментов информации,
 извлекаемой из переменной диапазона. Такое преобразование исходных
 данных называется проецированием.

 Начнем рассмотрение других возможностей оператора select с приведенной
 ниже программы. В этой программе выводятся квадратные корни положительных
 значений, содержащихся в массиве типа double.

*/

// Использовать оператор select для возврата квадратных корней всех
// положительных значений, содержащихся в массиве типа double.

using System;
using System.Linq;

class SelecttDemo
{
    static void Main()
    {
        double[] nums = { -10.0, 16.4, 12.125, 100.85, -2.2, 25.25, -3.5 };

        // Сформировать запрос на получение квадратных корней всех положительных значений,
        // содержащихся в массиве nums.
        var sqwRoots = from n in nums
                       where n > 0
                       select Math.Sqrt(n);

        Console.WriteLine("Квадратные корни положительных значений,\n" +
            "округленных до двух десятичных цифр:");

        // Выполнить запрос и вывести его результаты.
        foreach (var r in sqwRoots)
        {
            Console.WriteLine("{0:#.##}", r);
        }

        Console.ReadKey();
    }
}

/*

 Эта программа дает следующий результат.

 Квадратные корни положительных значений,
 округленные до двух десятичных цифр:
 4.05
 3.48
 10.04
 5.02

 Обратите особое внимание в данном примере запроса на следующий оператор
 select.

 select Math.Sqrt(n);

 Он возвращает квадратный корень значения переменной диапазона. Для этого значение
 переменной диапазона передается методу Math.Sqrt(), который возвращает
 квадратный корень своего аргумента. Это означает, что последовательность результатов,
 получаемых при выполнении запроса, будет содержать квадратные корни положительных
 значений, хранящихся в массиве nums. Если обобщить этот принцип, то
 его эффективность станет вполне очевидной. Так, с помощью оператора select можно
 сформировать любой требующийся тип последовательности результатов, исходя из
 значений, получаемых из источника данных.

*/

#endregion

#region English

/*

A Closer Look at select

The select clause determines what type of elements are obtained by a query. Its general
form is shown here:

select expression

So far we have been using select to return the range variable. Thus, expression has simply
named the range variable. However, select is not limited to this simple action. It can return
a specific portion of the range variable, the result of applying some operation or transformation
to the range variable, or even a new type of object that is constructed from pieces of the
information retrieved from the range variable. This is called projecting.

To begin examining the other capabilities of select, consider the following program. It
displays the square roots of the positive values contained in an array of double values.

*/

// Use select to return the square root of all positive values 
// in an array of doubles. 

//using System;  
//using System.Linq;  

//class SelectDemo
//{

//    static void Main()
//    {

//        double[] nums = { -10.0, 16.4, 12.125, 100.85, -2.2, 25.25, -3.5 };

//        // Create a query that returns the square roots of the  
//        // positive values in nums. 
//        var sqrRoots = from n in nums
//                       where n > 0
//                       select Math.Sqrt(n);

//        Console.WriteLine("The square roots of the positive values" +
//                          " rounded to two decimal places:");

//        // Execute the query and display the results. 
//        foreach (double r in sqrRoots) Console.WriteLine("{0:#.##}", r);

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

The square roots of the positive values rounded to two decimal places:
4.05
3.48
10.04
5.02

In the query, pay special attention to the select clause:

select Math.Sqrt(n);

It returns the square root of the range variable. It does this by obtaining the result of passing
the range variable to Math.Sqrt( ), which returns the square root of its argument. This means
that the sequence obtained when the query is executed will contain the square roots of the
positive values in nums. If you generalize this concept, the power of select becomes apparent.
You can use select to generate any type of sequence you need, based on the values obtained
from the data source.

*/

#endregion