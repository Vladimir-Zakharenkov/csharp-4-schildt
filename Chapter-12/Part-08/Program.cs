#region Russian

/*

Интерфейсные индексаторы

В интерфейсе можно также указывать индексаторы. Ниже приведена общая форма
объявления интерфейсного индексатора.

// Интерфейсный индексатор
тип_элемента this[int индекс]{
get;
set;
}

Как и прежде, в объявлении интерфейсных индексаторов, доступных только для
чтения или только для записи, должен присутствовать единственный аксессор: get
или set соответственно.

Ниже в качестве примера приведен еще один вариант реализации интерфейса
ISeries, в котором добавлен индексатор только для чтения, возвращающий i-й элемент
числового ряда.

*/

// Добавить индексатор в интерфейс.

using System;

public interface ISeries
{
    // Интерфейсное свойство
    int Next
    {
        get; // возвратить следующее по порядку число
        set; // установить следующее число
    }

    // Интерфейсный индексатор
    int this[int index]
    {
        get; // возвратить указанное в ряду число
    }
}

// Реализовать интерфейс ISeries
class ByTwos : ISeries
{
    int val;

    public ByTwos()
    {
        val = 0;
    }

    // Получить или установить значение с помощью свойства.
    public int Next
    {
        get
        {
            val += 2;
            return val;
        }
        set
        {
            val = value;
        }
    }

    public int this[int index]
    {
        get
        {
            val = 0;
            for (int i = 0; i < index; i++)
            {
                val += 2;
            }

            return val;
        }
    }
}

// Продемонстрировать применение интерфейсного индексатора.
class SeriesDemo4
{
    static void Main()
    {
        ByTwos ob = new();

        // Получить доступ к последовательному ряду числел с помощью свойства.
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Следующее число равно " + ob.Next);
        }

        Console.WriteLine("\nНачать с числа 21\n");
        ob.Next = 21;
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Следующее число равно " + ob.Next);
        }

        Console.WriteLine("\nСбросить в 0\n");
        ob.Next = 0;

        // Получить доступ к последовательному ряду чисел с помощью индексатора.
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Следующее число равно " + ob[i]);
        }
    }
}

/*

Вот к какому результату приводит выполнение этого кода.

Следующее число равно 2
Следующее число равно 4
Следующее число равно 6
Следующее число равно 8
Следующее число равно 10

Начать с числа 21

Следующее число равно 23
Следующее число равно 25
Следующее число равно 27
Следующее число равно 29
Следующее число равно 31

Сбросить в 0

Следующее число равно 0
Следующее число равно 2
Следующее число равно 4
Следующее число равно 6
Следующее число равно 8

*/

#endregion

#region English

/*

Interface Indexers

An interface can specify an indexer. A simple one-dimensional indexer declared in an
interface has this general form:

// interface indexer
element-type this[int index] {
get;
set;
}

As before, only get or set will be present for read-only or write-only indexers, respectively.
Also, no access modifiers are allowed on the accessors when an indexer is declared in an
interface.

Here is another version of ISeries that adds a read-only indexer that returns the i-th
element in the series.

 */

// Add an indexer in an interface.
//using System;
//public interface ISeries
//{
//    // An interface property.
//    int Next
//    {
//        get; // return the next number in series
//        set; // set next number
//    }
//    // An interface indexer.
//    int this[int index]
//    {
//        get; // return the specified number in series
//    }
//}

//// Implement ISeries.
//class ByTwos : ISeries
//{
//    int val;
//    public ByTwos()
//    {
//        val = 0;
//    }
//    // Get or set value using a property.
//    public int Next
//    {
//        get
//        {
//            val += 2;
//            return val;
//        }
//        set
//        {
//            val = value;
//        }
//    }
//    // Get a value using an index.
//    public int this[int index]
//    {
//        get
//        {
//            val = 0;
//            for (int i = 0; i < index; i++)
//                val += 2;
//            return val;
//        }
//    }
//}
//// Demonstrate an interface indexer.
//class SeriesDemo4
//{
//    static void Main()
//    {
//        ByTwos ob = new ByTwos();
//        // Access series through a property.
//        for (int i = 0; i < 5; i++)
//            Console.WriteLine("Next value is " + ob.Next);
//        Console.WriteLine("\nStarting at 21");
//        ob.Next = 21;
//        for (int i = 0; i < 5; i++)
//            Console.WriteLine("Next value is " +
//            ob.Next);
//        Console.WriteLine("\nResetting to 0");
//        ob.Next = 0;
//        // Access series through an indexer.
//        for (int i = 0; i < 5; i++)
//            Console.WriteLine("Next value is " + ob[i]);
//    }
//}

/*

The output from this program is shown here:

Next value is 2
Next value is 4
Next value is 6
Next value is 8
Next value is 10

Starting at 21

Next value is 23
Next value is 25
Next value is 27
Next value is 29
Next value is 31

Resetting to 0

Next value is 0
Next value is 2
Next value is 4
Next value is 6
Next value is 8

*/

#endregion