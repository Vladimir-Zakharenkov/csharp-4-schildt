#region Russian

/*

Возврат значения из анонимного метода

Анонимный метод может возвращать значение. Для этой цели служит оператор
return, действующий в анонимном методе таким же образом, как и в именованном
методе. Как и следовало ожидать, тип возвращаемого значения должен быть совместим
с возвращаемым типом, указываемым в объявлении делегата. В качестве примера
ниже приведен код, выполняющий подсчет с суммированием и возвращающий
результат.

*/

// Продемонстрировать применение анонимного метода, возвращающего значение.

using System;

// Этот делегат возвращает значение.
delegate int CounIt(int end);

class AnonMethDemo3
{
    static void Main()
    {
        int result;

        // Здесь конечное значение для подсчета перелается анонимному методу.
        // А возвращается сумма подсчитанных чисел.
        CounIt count = delegate (int end)
        {
            int sum = 0;

            for (int i = 0; i <= end; i++)
            {
                Console.WriteLine(i);
                sum += i;
            }

            return sum; // возвратить значение из анонимного метода
        };

        result = count(3);
        Console.WriteLine("Сумма 3 равна " + result);
        Console.WriteLine();

        result = count(5);
        Console.WriteLine("Сумма 5 равна " + result);

        Console.ReadKey();
    }
}

/*

В этом варианте кода суммарное значение возвращается кодовым блоком, связанным
с экземпляром делегата count. Обратите внимание на то, что оператор return
применяется в анонимном методе таким же образом, как и в именованном методе.
Ниже приведен результат выполнения данного кода.

0
1
2
3
Сумма 3 равна 6

0
1
2
3
4
5
Сумма 5 равна 15

*/

#endregion

#region English

/*

Return a Value from an Anonymous Method

An anonymous method can return a value. The value is returned by use of the return
statement, which works the same in an anonymous method as it does in a named method.
As you would expect, the type of the return value must be compatible with the return type
specified by the delegate. For example, here the code that performs the count also computes
the summation of the count and returns the result:

*/

// Demonstrate an anonymous method that returns a value. 

//using System;  

//// This delegate returns a value. 
//delegate int CountIt(int end);

//class AnonMethDemo3
//{

//    static void Main()
//    {
//        int result;

//        // Here, the ending value for the count 
//        // is passed to the anonymous method.   
//        // A summation of the count is returned. 
//        CountIt count = delegate (int end)
//        {
//            int sum = 0;

//            for (int i = 0; i <= end; i++)
//            {
//                Console.WriteLine(i);
//                sum += i;
//            }
//            return sum; // return a value from an anonymous method 
//        };

//        result = count(3);
//        Console.WriteLine("Summation of 3 is " + result);
//        Console.WriteLine();

//        result = count(5);
//        Console.WriteLine("Summation of 5 is " + result);

//        Console.ReadKey();
//    }
//}

/*

In this version, the value of sum is returned by the code block that is associated with the
count delegate instance. Notice that the return statement is used in an anonymous method
in just the same way that it is used in a named method. The output is shown here:

0
1
2
3
Summation of 3 is 6

0
1
2
3
4
5
Summation of 5 is 15

*/

#endregion