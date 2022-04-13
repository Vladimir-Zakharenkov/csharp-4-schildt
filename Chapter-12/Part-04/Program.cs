#region Russian

/*

В классах, реализующих интерфейсы, разрешается и часто практикуется определять
их собственные дополнительные члены. В качестве примера ниже приведен другой
вариант класса ByTwos, в который добавлен метод GetPrevious(), возвращающий
предыдущее значение.

*/

// Реализовать интерфейс ISeries и добавить в класс ByTwos метод GetPrevious().

class ByTwos : ISeries
{
    int start;
    int val;
    int prev;

    public ByTwos()
    {
        start = 0;
        val = 0;
        prev = -2;
    }

    public int GetNext()
    {
        prev = val;
        val += 2;
        return val;
    }

    public void Reset()
    {
        val = start;
        prev = start - 2;
    }

    public void SetStart(int x)
    {
        start = x;
        val = start;
        prev = val - 2;
    }

    // Метод, не указанный в интерфейсе ISeries.
    public int GetPrevious()
    {
        return prev;
    }
}

/*

Как видите, для того чтобы добавить метод GetPrevious(), потребовалось внести
изменения в реализацию методов, определяемых в интерфейсе ISeries. Но поскольку
интерфейс для этих методов остается прежним, то такие изменения не вызывают
никаких осложнений и не нарушают уже существующий код. В этом и заключается
одно из преимуществ интерфейсов.

*/

#endregion

#region English

/*

It is both permissible and common for classes that implement interfaces to define
additional members of their own. For example, the following version of ByTwos adds
the method GetPrevious(), which returns the previous value:

*/

// Implement ISeries and add GetPrevious().
//class ByTwos : ISeries
//{
//    int start;
//    int val;
//    int prev;
//    public ByTwos()
//    {
//        start = 0;
//        val = 0;
//        prev = -2;
//    }

//    public int GetNext()
//    {
//        prev = val;
//        val += 2;
//        return val;
//    }
//    public void Reset()
//    {
//        val = start;
//        prev = start - 2;
//    }
//    public void SetStart(int x)
//    {
//        start = x;
//        val = start;
//        prev = val - 2;
//    }

//    // A method not specified by ISeries.
//    public int GetPrevious()
//    {
//        return prev;
//    }
//}

/*

Notice that the addition of GetPrevious() required a change to the implementations of the
methods defined by ISeries. However, since the interface to those methods stays the same,
the change is seamless and does not break preexisting code. This is one of the advantages
of interfaces.

*/

#endregion