#region Russian

/*

Подробное рассмотрение класса Exception

В приведенных выше примерах исключения только перехватывались, но никакой
существенной обработке они не подвергались. Как пояснялось выше, в операторе
catch допускается указывать тип и переменную исключения. Переменная получает
ссылку на объект исключения. Во всех исключениях поддерживаются члены, определенные
в классе Exception, поскольку все исключения являются производными от
этого класса. В этом разделе будет рассмотрен ряд наиболее полезных членов и конструкторов
класса Exception и приведены конкретные примеры использования переменной
исключения.

В классе Exception определяется ряд свойств. К числу самых интересных относятся
три свойства: Message, StackTrace и TargetSite. Все эти свойства доступны
только для чтения. Свойство Message содержит символьную строку, описывающую
характер ошибки; свойство StackTrace — строку с вызовами стека, приведшими к исключительной
ситуации, а свойство TargetSite получает объект, обозначающий метод,
сгенерировавший исключение.

Кроме того, в классе Exception определяется ряд методов. Чаще всего приходится
пользоваться методом ToString(), возвращающим символьную строку с описанием
исключения. Этот метод автоматически вызывается, например, при отображении исключения
с помощью метода WriteLine().

Применение всех трех упомянутых выше свойств и метода из класса Exception
демонстрируется в приведенном ниже примере программы.

*/

// Использовать члены класса Exception.

using System;

class ExcTest
{
    public static void GenException()
    {
        int[] nums = new int[4];

        Console.WriteLine("До генерирования исключения.");

        // Сгенерировать исключение в связи с выходом за границы массива.
        for (int i = 0; i < 10; i++)
        {
            nums[i] = i;
            Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
        }

        Console.WriteLine("Не подлежит выводу");
    }
}

class UseExcept
{
    static void Main()
    {
        try
        {
            ExcTest.GenException();
        }
        catch (IndexOutOfRangeException exc)
        {
            Console.WriteLine("Стандартное сообщение таково: ");
            Console.WriteLine(exc); // вызвать метод ToString()
            Console.WriteLine("Свойство StackTrace: " + exc.StackTrace);
            Console.WriteLine("Свойство Message: " + exc.Message);
            Console.WriteLine("Свойство TargetSite: " + exc.TargetSite);
        }

        Console.WriteLine("После блока перехвата исключения.");

        Console.ReadKey();
    }
}

/*

При выполнении этой программы получается следующий результат.

До генерирования исключения.
nums[0]: 0
nums[1]: 1
nums[2]: 2
nums[3]: 3
Стандартное сообщение таково: System.IndexOutOfRangeException: Индекс находился
вне границ массива.
в ExcTest.genException() в <имя_файла>:строка 15
в UseExcept.Main() в <имя_файла>:строка 29
Свойство StackTrace: в ExcTest.genException() в <имя_файла>:строка 15
в UseExcept.Main()в <имя_файла>:строка 29
Свойство Message: Индекс находился вне границ массива.
Свойство TargetSite: Void genException()
После блока перехвата исключения.

В классе Exception определяются четыре следующих конструктора.

public Exception()

public Exception(string сообщение)

public Exception(string сообщение, Exception внутреннее_исключение)

protected Exception(System.Runtime.Serialization.SerializationInfo информация,
        System.Runtime.Serialization.StreamingContext контекст)

Первый конструктор используется по умолчанию. Во втором конструкторе указывается
строка сообщение, связанная со свойством Message, которое имеет отношение
к генерируемому исключению. В третьем конструкторе указывается так называемое
внутреннее исключение. Этот конструктор используется в том случае, когда
одно исключение порождает другое, причем внутреннее_исключение обозначает
первое исключение, которое будет пустым, если внутреннее исключение отсутствует.
(Если внутреннее исключение присутствует, то оно может быть получено из свойства
InnerException, определяемого в классе Exception.) И последний конструктор обрабатывает
исключения, происходящие дистанционно, и поэтому требует десериализации.

Следует также заметить, что в четвертом конструкторе класса Exception типы
SerializationInfo и StreamingContext относятся к пространству имен System.
Runtime.Serialization.

*/

#endregion

#region English

/*

A Closer Look at the Exception Class

Up to this point, we have been catching exceptions, but we haven’t been doing anything
with the exception object itself. As explained earlier, a catch clause allows you to specify an
exception type and a variable. The variable receives a reference to the exception object. Since
all exceptions are derived from Exception, all exceptions support the members defined by
Exception. Here we will examine several of its most useful members and constructors, and
put the exception variable to use.

Exception defines several properties. Three of the most interesting are Message,
StackTrace, and TargetSite. All are read-only. Message contains a string that describes the
nature of the error. StackTrace contains a string that contains the stack of calls that lead to
the exception. TargetSite obtains an object that specifies the method that generated the
exception.

Exception also defines several methods. One that you will often use is ToString(),
which returns a string that describes the exception. ToString() is automatically called
when an exception is displayed via WriteLine(), for example.
The following program demonstrates these properties and this method:

*/

// Using Exception members. 

//using System; 

//class ExcTest
//{
//    public static void GenException()
//    {
//        int[] nums = new int[4];

//        Console.WriteLine("Before exception is generated.");

//        // Generate an index out-of-bounds exception. 
//        for (int i = 0; i < 10; i++)
//        {
//            nums[i] = i;
//            Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
//        }

//        Console.WriteLine("this won't be displayed");
//    }
//}

//class UseExcept
//{
//    static void Main()
//    {

//        try
//        {
//            ExcTest.GenException();
//        }
//        catch (IndexOutOfRangeException exc)
//        {
//            Console.WriteLine("Standard message is: ");
//            Console.WriteLine(exc); // calls ToString() 
//            Console.WriteLine("Stack trace: " + exc.StackTrace);
//            Console.WriteLine("Message: " + exc.Message);
//            Console.WriteLine("TargetSite: " + exc.TargetSite);
//        }
//        Console.WriteLine("After catch block.");

//        Console.ReadKey();
//    }
//}

/*

The output from this program is shown here:

Before exception is generated.
nums[0]: 0
nums[1]: 1
nums[2]: 2
nums[3]: 3
Standard message is:
System.IndexOutOfRangeException: Index was outside the bounds of the array.
at ExcTest.GenException()
at UseExcept.Main()
Stack trace: at ExcTest.GenException()
at UseExcept.Main()
Message: Index was outside the bounds of the array.
TargetSite: Void GenException()
After catch block.

Exception defines the following four constructors:

public Exception()

public Exception(string message)

public Exception(string message, Exception innerException)

protected Exception(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)

The first is the default constructor. The second specifies the string associated with the
Message property associated with the exception. The third specifies what is called an inner
exception. It is used when one exception gives rise to another. In this case, innerException
specifies the first exception, which will be null if no inner exception exists. (The inner exception,
if it exists, can be obtained from the InnerException property defined by Exception.) The
last constructor handles exceptions that occur remotely and require deserialization.

One other point: In the fourth Exception constructor shown above, notice that the types
SerializationInfo and StreamingContext are contained in the System.Runtime.Serialization
namespace.

*/

#endregion