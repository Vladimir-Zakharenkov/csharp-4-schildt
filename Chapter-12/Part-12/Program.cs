#region Russian

/*

Структуры

Как вам должно быть уже известно, классы относятся к ссылочным типам данных.
Это означает, что объекты конкретного класса доступны по ссылке, в отличие от значений
простых типов, доступных непосредственно. Но иногда прямой доступ к объектам
как к значениям простых типов оказывается полезно иметь, например, ради повышения
эффективности программы. Ведь каждый доступ к объектам (даже самым мелким)
по ссылке связан с дополнительными издержками на расход вычислительных ресурсов
и оперативной памяти. Для разрешения подобных затруднений в C# предусмотрена
структура, которая подобна классу, но относится к типу значения, а не к ссылочному
типу данных.

Структуры объявляются с помощью ключевого слова struct и с точки зрения синтаксиса
подобны классам. Ниже приведена общая форма объявления структуры:

struct имя : интерфейсы
{
    // объявления членов
}
где имя обозначает конкретное имя структуры.

Одни структуры не могут наследовать другие структуры и классы или служить
в качестве базовых для других структур и классов. (Разумеется, структуры, как и все
остальные типы данных в С#, наследуют класс object.) Тем не менее в структуре можно
реализовать один или несколько интерфейсов, которые указываются после имени
структуры списком через запятую. Как и у классов, у каждой структуры имеются свои
члены: методы, поля, индексаторы, свойства, операторные методы и события. В структурах
допускается также определять конструкторы, но не деструкторы. В то же время
для структуры нельзя определить конструктор, используемый по умолчанию (т.е. конструктор
без параметров). Дело в том, что конструктор, вызываемый по умолчанию,
определяется для всех структур автоматически и не подлежит изменению. Такой конструктор
инициализирует поля структуры значениями, задаваемыми по умолчанию.
А поскольку структуры не поддерживают наследование, то их члены нельзя указывать
как abstract, virtual или protected.

Объект структуры может быть создан с помощью оператора new таким же образом,
как и объект класса, но в этом нет особой необходимости. Ведь когда используется
оператор new, то вызывается конструктор, используемый по умолчанию. А когда этот
оператор не используется, объект по-прежнему создается, хотя и не инициализируется.
В этом случае инициализацию любых членов структуры придется выполнить вручную.
В приведенном ниже примере программы демонстрируется применение структуры
для хранения информации о книге.

*/

// Продемонстрировать применение структуры.

using System;

// Определить структуру.
struct Book
{
    public string Author;
    public string Title;
    public int Copyright;

    public Book(string a, string t, int c)
    {
        Author = a;
        Title = t;
        Copyright = c;
    }
}

// Продемонстрировать применение структуры Book.
class StructDemo
{
    static void Main()
    {
        Book book1 = new Book("Герберт Шилдт", "Полный справочник по C# 4.0", 2010); // вызов явно заданного конструктора
        Book book2 = new Book(); // вызов конструктора по умолчанию
        Book book3; // конструктор не вызывается

        Console.WriteLine(book1.Author + ", " + book1.Title + ",(c) " + book1.Copyright);
        Console.WriteLine();

        if (book2.Title == null)
        {
            Console.WriteLine("Член book2.Title пуст.");
        }

        // А теперь ввести информацию в структуру book2.
        book2.Title = "О дивный новый мир";
        book2.Author = "Олдос Хаксли";
        book2.Copyright = 1932;

        Console.WriteLine("Структура book2 теперь содержит:\n");
        Console.WriteLine(book2.Author + ", " + book2.Title + ",(c) " + book2.Copyright);
        Console.WriteLine();

        // Console.WriteLine(book3.Title); // неверно, этот член структуры нужно сначала инициализировать

        book3.Title = "Красный шторм";

        Console.WriteLine(book3.Title); // теперь верно
    }
}

/*

При выполнении этой программы получается следующий результат.

Герберт Шилдт, Полный справочник по C# 4.0, (с) 2010
Член book2.Title пуст.
Структура bоок2 теперь содержит:

Олдос Хаксли, О дивный новый мир, (с) 1932

Красный шторм

Как демонстрирует приведенный выше пример программы, структура может быть
инициализирована с помощью оператора new для вызова конструктора или же путем
простого объявления объекта. Так, если используется оператор new, то поля структуры
инициализируются конструктором, вызываемым по умолчанию (в этом случае во всех
полях устанавливается задаваемое по умолчанию значение), или же конструктором,
определяемым пользователем. А если оператор new не используется, как это имеет
место для структуры bоок3, то объект структуры не инициализируется, а его поля
должны быть установлены вручную перед тем, как пользоваться данным объектом.

*/

#endregion

#region English

/*

Structures

As you know, classes are reference types. This means that class objects are accessed through
a reference. This differs from the value types, which are accessed directly. However, sometimes
it would be useful to be able to access an object directly, in the way that value types are. One
reason for this is efficiency. Accessing class objects through a reference adds overhead onto
every access. It also consumes space. For very small objects, this extra space might be
significant. To address these concerns, C# offers the structure. A structure is similar to a
class, but is a value type, rather than a reference type.

Structures are declared using the keyword struct and are syntactically similar to classes.
Here is the general form of a struct:

struct name : interfaces {
// member declarations
}

The name of the structure is specified by name.

Structures cannot inherit other structures or classes or be used as a base for other structures
or classes. (All structures do, however, implicitly inherit System.ValueType, which inherits
object.) However, a structure can implement one or more interfaces. These are specified after
the structure name using a comma-separated list. Like classes, structure members include
methods, fields, indexers, properties, operator methods, and events. Structures can also define
constructors, but not destructors. However, you cannot define a default (parameterless)
constructor for a structure. The reason for this is that a default constructor is automatically
defined for all structures, and this default constructor can’t be changed. The default constructor
initializes the fields of a structure to their default value. Since structures do not support
inheritance, structure members cannot be specified as abstract, virtual, or protected.

A structure object can be created using new in the same way as a class object, but it is
not required. When new is used, the specified constructor is called. When new is not used,
the object is still created, but it is not initialized. Thus, you will need to perform any
initialization manually.

Here is an example that uses a structure to hold information about a book:

*/

// Demonstrate a structure.

//using System;

//// Define a structure.
//struct Book
//{
//    public string Author;
//    public string Title;
//    public int Copyright;
//    public Book(string a, string t, int c)
//    {
//        Author = a;
//        Title = t;
//        Copyright = c;
//    }
//}
//// Demonstrate Book structure.
//class StructDemo
//{
//    static void Main()
//    {
//        Book book1 = new Book("Herb Schildt", "C# 4.0: The Complete Reference", 2010); // explicit constructor
//        Book book2 = new Book(); // default constructor
//        Book book3; // no constructor

//        Console.WriteLine(book1.Title + " by " + book1.Author + ", (c) " + book1.Copyright);
//        Console.WriteLine();

//        if (book2.Title == null) Console.WriteLine("book2.Title is null.");

//        // Now, give book2 some info.
//        book2.Title = "Brave New World";
//        book2.Author = "Aldous Huxley";
//        book2.Copyright = 1932;

//        Console.Write("book2 now contains: ");
//        Console.WriteLine(book2.Title + " by " + book2.Author + ", (c) " + book2.Copyright);
//        Console.WriteLine();

//        // Console.WriteLine(book3.Title); // error, must initialize first

//        book3.Title = "Red Storm Rising";
//        Console.WriteLine(book3.Title); // now OK
//    }
//}

/*

The output from this program is shown here:

C# 4.0: The Complete Reference by Herb Schildt, (c) 2010
book2.Title is null.
book2 now contains: Brave New World by Aldous Huxley, (c) 1932
Red Storm Rising

As the program shows, a structure can be created either by using new to invoke a
constructor or by simply declaring an object. If new is used, then the fields of the structure
will be initialized either by the default constructor, which initializes all fields to their default
value, or by a user-defined constructor. If new is not used, as is the case with book3, then
the object is not initialized, and its fields must be set prior to using the object.

*/

#endregion