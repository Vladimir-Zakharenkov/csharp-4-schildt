#region Russian

/*

Интерфейсные свойства

Аналогично методам, свойства указываются в интерфейсе вообще без тела. Ниже
приведена общая форма объявления интерфейсного свойства.

// Интерфейсное свойство
тип имя{
get;
set;
}

Очевидно, что в определении интерфейсных свойств, доступных только для чтения
или только для записи, должен присутствовать единственный аксессор: get или set
соответственно.

Несмотря на то что объявление свойства в интерфейсе очень похоже на объявление
автоматически реализуемого свойства в классе, между ними все же имеется отличие.
При объявлении в интерфейсе свойство не становится автоматически реализуемым.
В этом случае указывается только имя и тип свойства, а его реализация предоставляется
каждому реализующему классу. Кроме того, при объявлении свойства в интерфейсе
не разрешается указывать модификаторы доступа для аксессоров. Например, аксессор
set не может быть указан в интерфейсе как private.

Ниже в качестве примера приведен переделанный вариант интерфейса ISeries
и класса ByTwos, в котором свойство Next используется для получения и установки
следующего по порядку числа, которое больше предыдущего на два.

*/

// Использовать свойство в интерфейсе.

using System;

public interface ISeries
{
    // Интерфейсное свойство.
    int Next
    {
        get; // возвратить следующее по порядку число
        set; // установить следующее число
    }
}

// Реализовать интерфейс ISeries.
class ByTwos : ISeries
{
    int val;

    public ByTwos()
    {
        val = 0;
    }

    // Получить или установить значение.
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
}

// Продемонстрировать применение интерфейсного свойства.
class SeriesDemo3
{
    static void Main()
    {
        ByTwos ob = new();

        // Получить доступ к последовательному ряду чисел с помощью свойства.
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
    }
}

/*

При выполнении этого кода получается следующий результат.

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

*/

#endregion

#region English

/*

Interface Properties

Like methods, properties are specified in an interface without any body. Here is the general
form of a property specification:

// interface property
type name {
get;
set;
}

Of course, only get or set will be present for read-only or write-only properties, respectively.

Although the declaration of a property in an interface looks similar to how an autoimplemented
property is declared in a class, the two are not the same. The interface declaration
does not cause the property to be auto-implemented. It only specifies the name and type of
the property. Implementation is left to each implementing class. Also, no access modifiers
are allowed on the accessors when a property is declared in an interface. Thus, the set accessor,
for example, cannot be specified as private in an interface.

Here is a rewrite of the ISeries interface and the ByTwos class that uses a property
called Next to obtain and set the next element in the series:

*/

// Use a property in an interface.

//using System;
//public interface ISeries
//{
//    // An interface property.
//    int Next
//    {
//        get; // return the next number in series
//        set; // set next number
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
//    // Get or set value.
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
//}
//// Demonstrate an interface property.
//class SeriesDemo3
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
//            Console.WriteLine("Next value is " + ob.Next);
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

*/

#endregion