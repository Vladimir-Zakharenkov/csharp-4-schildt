#region Russian

/*

Применение интерфейсных ссылок

Как это ни покажется странным, но в C# допускается объявлять переменные ссылочного
интерфейсного типа, т.е. переменные ссылки на интерфейс. Такая переменная
может ссылаться на любой объект, реализующий ее интерфейс. При вызове метода
для объекта посредством интерфейсной ссылки выполняется его вариант, реализованный
в классе данного объекта. Этот процесс аналогичен применению ссылки на базовый
класс для доступа к объекту производного класса, как пояснялось в главе 11.

В приведенном ниже примере программы демонстрируется применение интерфейсной
ссылки. В этой программе переменная ссылки на интерфейс используется с
целью вызвать методы для объектов обоих классов — ByTwos и Primes. Для ясности в
данном примере показаны все части программы, собранные в единый файл.

*/

// Продемонстрировать интерфейсные ссылки.

using System;

// Определить интерфейс.
public interface ISeries
{
    int GetNext(); // возвратить следующее по порядку число
    void Reset(); // перезапустить
    void SetStart(int x); // задать начальное значение
}

// Использовать интерфейс ISeries для реализации процесса
// генерирования последовательного ряда чисел, в котором каждое
// последующее число на два больше предыдущего.
class ByTwos : ISeries
{
    int start;
    int val;

    public ByTwos()
    {
        start = 0;
        val = 0;
    }

    public int GetNext()
    {
        val += 2;
        return val;
    }

    public void Reset()
    {
        val = start;
    }

    public void SetStart(int x)
    {
        start = x;
        val = start;
    }
}

// Использовать интерфейс ISeries для реализации
// процесса генерирования простых чисел.
class Primes : ISeries
{
    int start;
    int val;

    public Primes()
    {
        start = 2;
        val = 2;
    }

    public int GetNext()
    {
        int i, j;
        bool isprime;

        val++;

        for (i = val; i < 1000000; i++)
        {
            isprime = true;

            for (j = 2; j <= i / j; j++)
            {
                if ((i % j) == 0)
                {
                    isprime = false;
                    break;
                }
            }

            if (isprime)
            {
                val = i;
                break;
            }
        }

        return val;
    }

    public void Reset()
    {
        val = start;
    }

    public void SetStart(int x)
    {
        start = x;
        val = start;
    }
}

class SeriesDemo2
{
    static void Main()
    {
        ByTwos twoOb = new();
        Primes primeOb = new();

        ISeries ob;

        for (int i = 0; i < 5; i++)
        {
            ob = twoOb;
            Console.WriteLine("Следующее четное число равно " + ob.GetNext());

            ob = primeOb;
            Console.WriteLine("Следующее простое число равно " + ob.GetNext());
        }
    }
}

/*

Вот к какому результату приводит выполнение этой программы:

Следующее четное число равно 2
Следующее простое число равно 3
Следующее четное число равно 4
Следующее простое число равно 5
Следующее четное число равно 6
Следующее простое число равно 7
Следующее четное число равно 8
Следующее простое число равно 11
Следующее четное число равно 10
Следующее простое число равно 13

В методе Main() переменная ob объявляется для ссылки на интерфейс ISeries.
Это означает, что в ней могут храниться ссылки на объект любого класса, реализующего
интерфейс ISeries. В данном случае она служит для ссылки на объекты twoOb и
primeOb классов ByTwos и Primes соответственно, в которых реализован интерфейс
ISeries.

И еще одно замечание: переменной ссылки на интерфейс доступны только методы,
объявленные в ее интерфейсе. Поэтому интерфейсную ссылку нельзя использовать для
доступа к любым другим переменным и методам, которые не поддерживаются объектом
класса, реализующего данный интерфейс.

*/

#endregion

#region English

/*

Using Interface References

You might be somewhat surprised to learn that you can declare a reference variable of an
interface type. In other words, you can create an interface reference variable. Such a variable
can refer to any object that implements its interface. When you call a method on an object
through an interface reference, it is the version of the method implemented by the object
that is executed. This process is similar to using a base class reference to access a derived
class object, as described in Chapter 11.

The following example illustrates the use of an interface reference. It uses the same
interface reference variable to call methods on objects of both ByTwos and Primes. For
clarity, it shows all pieces of the program, assembled into a single file.

*/

// Demonstrate interface references.

//using System;
//// Define the interface.
//public interface ISeries
//{
//    int GetNext(); // return next number in series
//    void Reset(); // restart
//    void SetStart(int x); // set starting value
//}
//// Use ISeries to implement a series in which each
//// value is two greater than the previous one.
//class ByTwos : ISeries
//{
//    int start;
//    int val;

//    public ByTwos()
//    {
//        start = 0;
//        val = 0;
//    }
//    public int GetNext()
//    {
//        val += 2;
//        return val;
//    }
//    public void Reset()
//    {
//        val = start;
//    }
//    public void SetStart(int x)
//    {
//        start = x;
//        val = start;
//    }
//}
//// Use ISeries to implement a series of prime numbers.
//class Primes : ISeries
//{
//    int start;
//    int val;
//    public Primes()
//    {
//        start = 2;
//        val = 2;
//    }
//    public int GetNext()
//    {
//        int i, j;
//        bool isprime;
//        val++;
//        for (i = val; i < 1000000; i++)
//        {
//            isprime = true;
//            for (j = 2; j <= i / j; j++)
//            {
//                if ((i % j) == 0)
//                {
//                    isprime = false;
//                    break;
//                }
//            }
//            if (isprime)
//            {
//                val = i;
//                break;
//            }
//        }
//        return val;
//    }
//    public void Reset()
//    {
//        val = start;
//    }

//    public void SetStart(int x)
//    {
//        start = x;
//        val = start;
//    }
//}
//class SeriesDemo2
//{
//    static void Main()
//    {
//        ByTwos twoOb = new ByTwos();
//        Primes primeOb = new Primes();
//        ISeries ob;
//        for (int i = 0; i < 5; i++)
//        {
//            ob = twoOb;
//            Console.WriteLine("Next ByTwos value is " +
//            ob.GetNext());
//            ob = primeOb;
//            Console.WriteLine("Next prime number is " +
//            ob.GetNext());
//        }
//    }
//}

/*

The output from the program is shown here:

Next ByTwos value is 2
Next prime number is 3
Next ByTwos value is 4
Next prime number is 5
Next ByTwos value is 6
Next prime number is 7
Next ByTwos value is 8
Next prime number is 11
Next ByTwos value is 10
Next prime number is 13

In Main( ), ob is declared to be a reference to an ISeries interface. This means that it can be
used to store references to any object that implements ISeries. In this case, it is used to refer
to twoOb and primeOb, which are objects of type ByTwos and Primes, respectively, which
both implement ISeries.

One other point: An interface reference variable has knowledge only of the methods
declared by its interface declaration. Thus, an interface reference cannot be used to access
any other variables or methods that might be supported by the object.

*/

#endregion