#region Russian

/*

Получение производных классов исключений

Несмотря на то что встроенные исключения охватывают наиболее распространенные
программные ошибки, обработка исключительных ситуаций в C# не ограничивается
только этими ошибками. В действительности одна из сильных сторон принятого
в C# подхода к обработке исключительных ситуаций состоит в том, что в этом языке
допускается использовать исключения, определяемые пользователем, т.е. тем, кто программирует
на С#. В частности, такие специальные исключения можно использовать
для обработки ошибок в собственном коде, а создаются они очень просто. Для этого
достаточно определить класс, производный от класса Exception. В таких классах совсем
не обязательно что-то реализовывать — одного только их существования в системе
типов уже достаточно, чтобы использовать их в качестве исключений.

ПРИМЕЧАНИЕ
В прошлом специальные исключения создавались как производные от класса
Application.Exception, поскольку эта иерархия классов была первоначально зарезервирована
для исключений прикладного характера. Но теперь корпорация Microsoft не рекомендует
этого делать, а вместо этого получать исключения, производные от класса Exception.
Именно по этой причине данный подход и рассматривается в настоящей книге.

Создаваемые пользователем классы будут автоматически получать свойства и методы,
определенные в классе Exception и доступные для них. Разумеется, любой из этих
членов класса Exception можно переопределить в создаваемых классах исключений.

Когда создается собственный класс исключений, то, как правило, желательно, чтобы
в нем поддерживались все конструкторы, определенные в классе Exception. В простых
специальных классах исключений этого нетрудно добиться, поскольку для этого
достаточно передать подходящие аргументы соответствующему конструктору класса
Exception, используя ключевое слово base. Но формально нужно предоставить только
те конструкторы, которые фактически используются в программе.

Рассмотрим пример программы, в которой используется исключение специального
типа. Напомним, что в конце главы 10 был разработан класс RangeArray, поддерживающий
одномерные массивы, в которых начальный и конечный индексы определяются
пользователем. Так, например, вполне допустимым считается массив, индексируемый
в пределах от -5 до 27. Если же индекс выходил за границы массива, то для обработки
этой ошибки в классе RangeArray была определена специальная переменная.
Такая переменная устанавливалась и проверялась после каждой операции обращения
к массиву в коде, использовавшем класс RangeArray. Безусловно, такой подход к обработке
ошибок "неуклюж" и чреват дополнительными ошибками. В приведенном
ниже улучшенном варианте класса RangeArray обработка ошибок нарушения границ
массива выполняется более изящным и надежным способом с помощью специально
генерируемого исключения.

*/

// Использовать специальное исключение для обработки ошибок при обращении
// к массиву класса RangeArray.

using System;

// Создать исключение для класса RangeArray.
class RangeArrayException : Exception
{
    // Реализовать все конструкторы класса Exception.
    // Такие конструкторы просто реализуют конструктор базового класса.
    // А поскольку класс исключения RangeArrayException ничего
    // не добавляет к классу Exception, то никаких дополнительных
    // действий не требуется.

    public RangeArrayException() : base() { }

    public RangeArrayException(string str) : base(str) { }

    public RangeArrayException(string str, Exception inner) : base(str, inner) { }

    protected RangeArrayException(System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc) { }

    // Переопределить метод ToString() для класса исключения RangeArrayException.
    public override string ToString()
    {
        return Message;
    }
}

// Улучшенный вариант класса RangeArray.
class RangeArray
{
    // Закрытые данные.
    int[] a; // ссылка на базовый массив
    int lowerBound; // наименьший индекс
    int upperBound; // наибольший индекс

    // Автоматически реализуемое и доступное только для чтения свойство Length.
    public int Length { get; private set; }

    // Построить массив по заданному размеру
    public RangeArray(int low, int high)
    {
        high++;
        if (high <= low)
        {
            throw new RangeArrayException("Верхний индекс должен быть больше нижнего.");
        }
        a = new int[high - low];
        Length = high - low;

        lowerBound = low;
        upperBound = --high;
    }

    // Это индексатор для класса RangeArray.
    public int this[int index]
    {
        // Это аксессор get.
        get
        {
            if (ok(index))
            {
                return a[index - lowerBound];
            }
            else
            {
                throw new RangeArrayException("Ошибка нарушения границ");
            }
        }

        // Это аксессор set.
        set
        {
            if (ok(index))
            {
                a[index - lowerBound] = value;
            }
            else
            {
                throw new RangeArrayException("Ошибка нарушения границ");
            }
        }
    }

    // Возвратить логическое значение true, если
    // индекс находится в установленных границах.
    private bool ok(int index)
    {
        if (index >= lowerBound & index <= upperBound)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

// Продемонстрировать применение массива с произвольно 
// задаваемыми пределами индексирования.
class RangeArrayDemo
{
    static void Main()
    {
        try
        {
            RangeArray ra = new RangeArray(-5, 5);
            RangeArray ra2 = new RangeArray(1, 10);

            // Использовать объект ra в качестве массива.
            Console.WriteLine("Длина массива ra: " + ra.Length);

            for (int i = -5; i <= 5; i++)
            {
                ra[i] = i;
            }

            Console.Write("Содержимое массива ra: ");
            for (int i = -5; i <= 5; i++)
            {
                Console.Write(ra[i] + " ");
            }

            Console.WriteLine("\n");

            // Использовать объект ra в качестве массива.
            Console.WriteLine("Длина массива ra2: " + ra2.Length);

            for (int i = 1; i <= 10; i++)
            {
                ra2[i] = i;
            }

            Console.Write("Содержимое массива ra2: ");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(ra2[i] + " ");
            }

            Console.WriteLine("\n");
        }
        catch (RangeArrayException exc)
        {
            Console.WriteLine(exc);
        }

        // А теперь продемонстрировать обработку некоторых ошибок.
        Console.WriteLine("Сгенерировать ошибки нарушения границ.");

        // Использовать неверно заданный конструктор.
        try
        {
            RangeArray ra3 = new RangeArray(100, -10); // Ошибка!
        }
        catch (RangeArrayException exc)
        {
            Console.WriteLine(exc);
        }

        // Использовать неверно заданный индекс.
        try
        {
            RangeArray ra3 = new RangeArray(-2, 2);

            for (int i = -2; i <= 2; i++)
            {
                ra3[i] = i;
            }

            Console.Write("Содержимое массива ra3: ");
            for (int i = -2; i <= 10; i++) // Сгенерировать ошибку нарушения границ
            {
                Console.Write(ra3[i] + " ");
            }
        }
        catch (RangeArrayException exc)
        {
            Console.WriteLine(exc);
        }

        Console.ReadKey();
    }
}

/*

После выполнения этой программы получается следующий результат.

Длина массива ra: 11
Содержимое массива ra: -5 -4 -3 -2 -1 0 1 2 3 4 5

Длина массива ra2: 10
Содержимое массива ra2: 1 2 3 4 5 6 7 8 9 10

Сгенерировать ошибки нарушения границ.
Нижний индекс не меньше верхнего.
Содержимое массива ra3: -2 -1 0 1 2 Ошибка нарушения границ.

Когда возникает ошибка нарушения границ массива класса RangeArray, генерируется
объект типа RangeArrayException. В классе RangeArray это может произойти
в трех следующих местах: в аксессоре get индексатора, в аксессоре set индексатора
и в конструкторе класса RangeArray. Для перехвата этих исключений подразумевается,
что объекты типа RangeArray должны быть сконструированы и доступны из
блока try, что и продемонстрировано в приведенной выше программе. Используя
специальное исключение для сообщения об ошибках, класс RangeArray теперь действует
как один из встроенных в C# типов данных, и поэтому он может быть полностью
интегрирован в механизм обработки ошибок, обнаруживаемых в программе.

Обратите внимание на то, что в теле конструкторов класса исключения
RangeArrayException отсутствуют какие-либо операторы, но вместо этого они просто
передают свои аргументы классу Exception, используя ключевое слово base. Как
пояснялось ранее, в тех случаях, когда производный класс исключений не дополняет
функции базового класса, весь процесс создания исключений можно поручить конструкторам
класса Exception. Ведь производный класс исключений совсем не обязательно
должен чем-то дополнять функции, наследуемые от класса Exception.

Прежде чем переходить к дальнейшему чтению, попробуйте немного поэкспериментировать
с приведенной выше программой. В частности, попробуйте закомментировать
переопределение метода ToString() и понаблюдайте за результатами. Кроме того, попытайтесь
создать исключение, используя конструктор, вызываемый по умолчанию, и
посмотрите, какое сообщение при этом сформируется стандартными средствами С#.

*/

#endregion

#region English

/*

Deriving Exception Classes

Although C#’s built-in exceptions handle most common errors, C#’s exception-handling
mechanism is not limited to these errors. In fact, part of the power of C#’s approach to
exceptions is its ability to handle exception types that you create. You can use custom
exceptions to handle errors in your own code. Creating an exception is easy. Just define
a class derived from Exception. Your derived classes don’t need to actually implement
anything—it is their existence in the type system that allows you to use them as exceptions.

NOTE
In the past, custom exceptions were derived from ApplicationException since this is the
hierarchy that was originally reserved for application-related exceptions. However, Microsoft
no longer recommends this. Instead, at the time of this writing, Microsoft recommends deriving
custom exceptions from Exception. For this reason, this approach is used here.

The exception classes that you create will automatically have the properties and methods
defined by Exception available to them. Of course, you can override one or more of these
members in exception classes that you create.

When creating your own exception class, you will generally want your class to support
all of the constructors defined by Exception. For simple custom exception classes, this is
easy to do because you can simply pass along the constructor’s arguments to the corresponding
Exception constructor via base. Of course, technically, you need to provide only those
constructors actually used by your program.

Here is an example that makes use of a custom exception type. At the end of Chapter 10
an array class called RangeArray was developed. As you may recall, RangeArray supports
single-dimensional int arrays in which the starting and ending index is specified by the
user. For example, an array that ranges from –5 to 27 is perfectly legal for a RangeArray.
In Chapter 10, if an index was out of range, a special error variable defined by RangeArray
was set. This meant that the error variable had to be checked after each operation by the
code that used RangeArray. Of course, such an approach is error-prone and clumsy. A far
better design is to have RangeArray throw a custom exception when a range error occurs.
This is precisely what the following version of RangeArray does:

*/

// Use a custom Exception for RangeArray errors. 

//using System;  

//// Create a RangeArray exception. 
//class RangeArrayException : Exception
//{
//    /* Implement all of the Exception constructors. Notice that 
//       the constructors simply execute the base class constructor. 
//       Because NonIntResultException adds nothing to Exception, 
//       there is no need for any further actions. */
//    public RangeArrayException() : base() { }
//    public RangeArrayException(string message) : base(message) { }
//    public RangeArrayException(string message, Exception innerException) :
//      base(message, innerException)
//    { }
//    protected RangeArrayException(
//      System.Runtime.Serialization.SerializationInfo info,
//      System.Runtime.Serialization.StreamingContext context) :
//        base(info, context)
//    { }

//    // Override ToString for RangeArrayException. 
//    public override string ToString()
//    {
//        return Message;
//    }
//}

//// An improved version of RangeArray. 
//class RangeArray
//{
//    // Private data. 
//    int[] a; // reference to underlying array   
//    int lowerBound; // smallest index 
//    int upperBound; // largest index 

//    // An auto-implemented, read-only Length property. 
//    public int Length { get; private set; }

//    // Construct array given its size.  
//    public RangeArray(int low, int high)
//    {
//        high++;
//        if (high <= low)
//        {
//            throw new RangeArrayException("Low index not less than high.");
//        }
//        a = new int[high - low];
//        Length = high - low;

//        lowerBound = low;
//        upperBound = --high;
//    }

//    // This is the indexer for RangeArray.  
//    public int this[int index]
//    {
//        // This is the get accessor.  
//        get
//        {
//            if (ok(index))
//            {
//                return a[index - lowerBound];
//            }
//            else
//            {
//                throw new RangeArrayException("Range Error.");
//            }
//        }

//        // This is the set accessor. 
//        set
//        {
//            if (ok(index))
//            {
//                a[index - lowerBound] = value;
//            }
//            else throw new RangeArrayException("Range Error.");
//        }
//    }

//    // Return true if index is within bounds.  
//    private bool ok(int index)
//    {
//        if (index >= lowerBound & index <= upperBound) return true;
//        return false;
//    }
//}

//// Demonstrate the index-range array.  
//class RangeArrayDemo
//{
//    static void Main()
//    {
//        try
//        {
//            RangeArray ra = new RangeArray(-5, 5);
//            RangeArray ra2 = new RangeArray(1, 10);

//            // Demonstrate ra. 
//            Console.WriteLine("Length of ra: " + ra.Length);

//            for (int i = -5; i <= 5; i++)
//                ra[i] = i;

//            Console.Write("Contents of ra: ");
//            for (int i = -5; i <= 5; i++)
//                Console.Write(ra[i] + " ");

//            Console.WriteLine("\n");

//            // Demonstrate ra2. 
//            Console.WriteLine("Length of ra2: " + ra2.Length);

//            for (int i = 1; i <= 10; i++)
//                ra2[i] = i;

//            Console.Write("Contents of ra2: ");
//            for (int i = 1; i <= 10; i++)
//                Console.Write(ra2[i] + " ");

//            Console.WriteLine("\n");

//        }
//        catch (RangeArrayException exc)
//        {
//            Console.WriteLine(exc);
//        }

//        // Now, demonstrate some errors. 
//        Console.WriteLine("Now generate some range errors.");

//        // Use an invalid constructor. 
//        try
//        {
//            RangeArray ra3 = new RangeArray(100, -10); // Error 
//        }
//        catch (RangeArrayException exc)
//        {
//            Console.WriteLine(exc);
//        }

//        // Use an invalid index. 
//        try
//        {
//            RangeArray ra3 = new RangeArray(-2, 2);

//            for (int i = -2; i <= 2; i++)
//                ra3[i] = i;

//            Console.Write("Contents of ra3: ");
//            for (int i = -2; i <= 10; i++) // generate range error 
//                Console.Write(ra3[i] + " ");

//        }
//        catch (RangeArrayException exc)
//        {
//            Console.WriteLine(exc);
//        }

//        Console.ReadKey();
//    }
//}

/*

The output from the program is shown here:

Length of ra: 11
Contents of ra: -5 -4 -3 -2 -1 0 1 2 3 4 5

Length of ra2: 10
Contents of ra2: 1 2 3 4 5 6 7 8 9 10

Now generate some range errors.
Low index not less than high.
Contents of ra3: -2 -1 0 1 2 Range Error.

When a range error occurs, RangeArray throws an object of type RangeArrayException.
Notice there are three places in RangeArray that this might occur: in the get indexer accessor,
in the set indexer accessor, and by the RangeArray constructor. To catch these exceptions
implies that RangeArray objects must be constructed and accessed from within a try block,
as the program illustrates. By using an exception to report errors, RangeArray now acts like
one of C#’s built-in types and can be fully integrated into a program’s exception-handling
mechanism.

Notice that none of the RangeArrayException constructors provide any statements
in their body. Instead, they simply pass their arguments along to Exception via base. As
explained, in cases in which your exception class does not add any functionality, you can
simply let the Exception constructors handle the process. There is no requirement that your
derived class add anything to what is inherited from Exception.

Before moving on, you might want to experiment with this program a bit. For example,
try commenting-out the override of ToString() and observe the results. Also, try creating an
exception using the default constructor, and observe what C# generates as its default message.

*/

#endregion