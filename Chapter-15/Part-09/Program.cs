#region Russian

/*

Применение внешних переменных в анонимных методах

Локальная переменная, в область действия которой входит анонимный метод, называется
внешней переменной. Такие переменные доступны для использования в анонимном
методе. И в этом случае внешняя переменная считается захваченной. Захваченная
переменная существует до тех пор, пока захвативший ее делегат не будет собран
в "мусор". Поэтому если локальная переменная, которая обычно прекращает свое существование
после выхода из кодового блока, используется в анонимном методе, то
она продолжает существовать до тех пор, пока не будет уничтожен делегат, ссылающийся
на этот метод.

Захват локальной переменной может привести к неожиданным результатам. В качестве
примера рассмотрим еще один вариант программы подсчета с суммированием
чисел. В данном варианте объект CountIt конструируется и возвращается статическим
методом Counter(). Этот объект использует переменную sum, объявленную в охватывающей
области действия метода Counter(), а не самого анонимного метода. Поэтому
переменная sum захватывается анонимным методом. Метод Counter() вызывается
в методе Main() для получения объекта CountIt, а следовательно, переменная sum не
уничтожается до самого конца программы.

*/

// Продемонстрировать применение захваченной переменной.

using System;

// Этот делегат возвращает значение типа int и принимает аргумент типа int.
delegate int CountIt(int end);

class VarCapture
{
    static CountIt Counter()
    {
        int sum = 0;

        // Здесь подсчитанная сумма сохраняется в переменной sum.
        CountIt ctObj = delegate (int end)
        {
            for (int i = 0; i <= end; i++)
            {
                Console.WriteLine(i);
                sum += i;
            }
            return sum;
        };

        return ctObj;
    }

    static void Main()
    {
        // Получить результат подсчета.
        CountIt count = Counter();

        int result;

        result = count(3);
        Console.WriteLine("Сумма 3 равна " + result);
        Console.WriteLine();

        result = count(5);
        Console.WriteLine("Сумма 5 равна " + result);

        Console.ReadKey();
    }
}

/*

Ниже приведен результат выполнения этой программы. Обратите особое внимание
на суммарное значение.

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
Сумма 5 равна 21

Как видите, подсчет по-прежнему выполняется как обычно. Но обратите внимание
на то, что сумма 5 теперь равна 21, а не 15! Дело в том, что переменная sum захватывается
объектом ctObj при его создании в методе Counter(). Это означает, что она
продолжает существовать вплоть до уничтожения делегата count при "сборке мусора"
в самом конце программы. Следовательно, ее значение не уничтожается после возврата
из метода Counter() или при каждом вызове анонимного метода, когда происходит
обращение к делегату count в методе Main().

Несмотря на то что применение захваченных переменных может привести к довольно
неожиданным результатам, как в приведенном выше примере, оно все же
логически обоснованно. Ведь когда анонимный метод захватывает переменную, она
продолжает существовать до тех пор, пока используется захватывающий ее делегат.
В противном случае захваченная переменная оказалась бы неопределенной, когда она
могла бы потребоваться делегату.

*/

#endregion

#region English

/*

Use Outer Variables with Anonymous Methods

A local variable or parameter whose scope includes an anonymous method is called an
outer variable. An anonymous method has access to and can use these outer variables. When
an outer variable is used by an anonymous method, that variable is said to be captured. A
captured variable will stay in existence at least until the delegate that captured it is subject
to garbage collection. Thus, even though a local variable will normally cease to exist when
its block is exited, if that local variable is being used by an anonymous method, then
that variable will stay in existence at least until the delegate referring to that method is
destroyed.

The capturing of a local variable can lead to unexpected results. For example, consider
this version of the counting program. As in the previous version, the summation of the
count is computed. However, in this version, a CountIt object is constructed and returned
by a static method called Counter( ). This object uses the variable sum, which is declared in
the enclosing scope provided by Counter( ), rather than in the anonymous method, itself.
Thus, sum is captured by the anonymous method. Inside Main( ), Counter( ) is called to
obtain a CountIt object. Thus, sum will not be destroyed until the program finishes.

*/

// Demonstrate a captured variable. 

//using System;  

//// This delegate returns int and takes an int argument. 
//delegate int CountIt(int end);

//class VarCapture
//{

//    static CountIt Counter()
//    {
//        int sum = 0;

//        // Here, a summation of the count is stored 
//        // in the captured variable sum. 
//        CountIt ctObj = delegate (int end)
//        {
//            for (int i = 0; i <= end; i++)
//            {
//                Console.WriteLine(i);
//                sum += i;
//            }
//            return sum;
//        };
//        return ctObj;
//    }

//    static void Main()
//    {
//        // Get a counter. 
//        CountIt count = Counter();

//        int result;

//        result = count(3);
//        Console.WriteLine("Summation of 3 is " + result);
//        Console.WriteLine();

//        result = count(5);
//        Console.WriteLine("Summation of 5 is " + result);

//        Console.ReadKey();
//    }
//}

/*

The output is shown here. Pay special attention to the summation value.

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
Summation of 5 is 21

As you can see, the count still proceeds normally. However, notice the summation value for
5. It shows 21 instead of 15! The reason for this is that sum is captured by ctObj when it is
created by the Counter() method. This means it remains in existence until count is subject
to garbage collection at the end of the program. Thus, its value is not destroyed when
Counter() returns or with each call to the anonymous method when count is called in Main().

Although captured variables can result in rather counterintuitive situations, such as the
one just shown, it makes sense if you think about it a bit. The key point is that when an
anonymous method captures a variable, that variable cannot go out of existence until the
delegate that captures it is no longer being used. If this were not the case, then the captured
variable could be undefined when it is needed by the delegate.

*/

#endregion