#region Russian

/*

Как пояснялось выше, интерфейс может быть реализован в любом количестве классов.
В качестве примера ниже приведен класс Primes, генерирующий ряд простых
чисел. Обратите внимание на то, реализация интерфейса ISeries в этом классе коренным
образом отличается от той, что предоставляется в классе ByTwos.

*/

// Использовать интерфейс ISeries для реализации процесса генерирования простых чисел.

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

/*

Самое любопытное, что в обоих классах, ByTwos и Primes, реализуется один и тот
же интерфейс, несмотря на то, что в них генерируются совершенно разные ряды чисел.
Как пояснялось выше, в интерфейсе вообще отсутствует какая-либо реализация,
поэтому он может быть свободно реализован в каждом классе так, как это требуется
для самого класса.

*/

#endregion

#region English

/*

As explained, any number of classes can implement an interface. For example, here is a
class called Primes that generates a series of prime numbers. Notice that its implementation
of ISeries is fundamentally different than the one provided by ByTwos.

*/

// Use ISeries to implement a series of prime numbers.
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

/*

The key point is that even though ByTwos and Primes generate completely unrelated
series of numbers, both implement ISeries. As explained, an interface says nothing about
the implementation, so each class is free to implement the interface as it sees fit.

*/

#endregion