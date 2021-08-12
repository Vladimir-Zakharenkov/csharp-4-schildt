#region Russian

/*

Генерирование исключений вручную

В приведенных выше примерах перехватывались исключения, генерировавшиеся
исполняющей системой автоматически. Но исключение может быть сгенерировано
и вручную с помощью оператора throw. Ниже приведена общая форма такого генерирования:

throw exceptOb;

где в качестве exceptOb должен быть обозначен объект класса исключений, производного
от класса Exception.

Ниже приведен пример программы, в которой демонстрируется применение оператора
throw для генерирования исключения DivideByZeroException.

*/

// Сгенерировать исключение вручную.

using System;

class ThrowDemo
{
    static void Main()
    {
        try
        {
            Console.WriteLine("До генерирования исключения.");

            throw new DivideByZeroException();
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Исключение перехвачено");
        }

        Console.WriteLine("После пары операторов try/catch.");

        Console.ReadKey();
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

До генерирования исключения.
Исключение перехвачено.
После пары операторов try/catch.

Обратите внимание на то, что исключение DivideByZeroException было сгенерировано
с использованием ключевого слова new в операторе throw. Не следует
забывать, что в данном случае генерируется конкретный объект, а следовательно, он
должен быть создан перед генерированием исключения. Это означает, что сгенерировать
исключение только по его типу нельзя. В данном примере для создания объекта
DivideByZeroException был автоматически вызван конструктор, используемый по
умолчанию, хотя для генерирования исключений доступны и другие конструкторы.

*/

#endregion

#region English

/*

Throwing an Exception

The preceding examples have been catching exceptions generated automatically by the
runtime system. However, it is possible to throw an exception manually by using the throw
statement. Its general form is shown here:

throw exceptOb;

The exceptOb must be an object of an exception class derived from Exception.
Here is an example that illustrates the throw statement by manually throwing a
DivideByZeroException:

*/

// Manually throw an exception. 

//using System; 

//class ThrowDemo
//{
//    static void Main()
//    {
//        try
//        {
//            Console.WriteLine("Before throw.");
//            throw new DivideByZeroException();
//        }
//        catch (DivideByZeroException)
//        {
//            Console.WriteLine("Exception caught.");
//        }
//        Console.WriteLine("After try/catch statement.");

//        Console.ReadKey();
//    }
//}

/*

The output from the program is shown here:

Before throw.
Exception caught.
After try/catch statement.

Notice how the DivideByZeroException was created using new in the throw statement.
Remember, throw throws an object. Thus, you must create an object for it to throw. That
is, you can’t just throw a type. In this case, the default constructor is used to create a
DivideByZeroException object, but other constructors are available for exceptions.

Most often, exceptions that you throw will be instances of exception classes that you
created. As you will see later in this chapter, creating your own exception classes allows you
to handle errors in your code as part of your program’s overall exception-handling strategy

*/

#endregion