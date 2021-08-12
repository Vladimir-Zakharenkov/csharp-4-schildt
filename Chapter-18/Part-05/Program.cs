#region Russian

/*

Ограниченные типы

В предыдущих примерах параметры типа можно было заменить любым типом
данных. Например, в следующей строке кода объявляется любой тип, обозначаемый
как Т.

class Gen<T> {

Это означает, что вполне допустимо создавать объекты класса Gen, в которых тип Т
заменяется типом int, double, string, FileStream или любым другим типом данных.
Во многих случаях отсутствие ограничений на указание аргументов типа считается
вполне приемлемым, но иногда оказывается полезно ограничить круг типов, которые
могут быть указаны в качестве аргумента типа.

Допустим, что требуется создать метод, оперирующий содержимым потока, включая
объекты типа FileStream или MemoryStream. На первый взгляд, такая ситуация
идеально подходит для применения обобщений, но при этом нужно каким-то образом
гарантировать, что в качестве аргументов типа будут использованы только типы
потоков, но не int или любой другой тип. Кроме того, необходимо как-то уведомить
компилятор о том, что методы, определяемые в классе потока, будут доступны для
применения. Так, в обобщенном коде должно быть каким-то образом известно, что
в нем может быть вызван метод Read().

Для выхода из подобных ситуаций в C# предусмотрены ограниченные типы. Указывая
параметр типа, можно наложить определенное ограничение на этот параметр. Это
делается с помощью оператора where при указании параметра типа:

class имя_класса<параметр_типа> where параметр_типа : ограничения { // ...

где ограничения указываются списком через запятую.

В C# предусмотрен ряд ограничений на типы данных.

• Ограничение на базовый класс, требующее наличия определенного базового класса
в аргументе типа. Это ограничение накладывается указанием имени требуемого
базового класса. Разновидностью этого ограничения является неприкрытое
ограничение типа, при котором на базовый класс указывает параметр типа, а не
конкретный тип. Благодаря этому устанавливается взаимосвязь между двумя
параметрами типа.

• Ограничение на интерфейс, требующее реализации одного или нескольких интерфейсов
аргументом типа. Это ограничение накладывается указанием имени
требуемого интерфейса.

• Ограничение на конструктор, требующее предоставить конструктор без параметров
в аргументе типа. Это ограничение накладывается с помощью оператора
new().

• Ограничение ссылочного типа, требующее указывать аргумент ссылочного типа с
помощью оператора class.

• Ограничение типа значения, требующее указывать аргумент типа значения с помощью
оператора struct.

Среди всех этих ограничений чаще всего применяются ограничения на базовый
класс и интерфейс, хотя все они важны в равной степени. Каждое из этих ограничений
рассматривается далее по порядку.

Применение ограничения на базовый класс

Ограничение на базовый класс позволяет указывать базовый класс, который должен
наследоваться аргументом типа. Ограничение на базовый класс служит двум главным
целям. Во-первых, оно позволяет использовать в обобщенном классе те члены базового
класса, на которые указывает данное ограничение. Это дает, например, возможность
вызвать метод или обратиться к свойству базового класса. В отсутствие ограничения на
базовый класс компилятору ничего не известно о типе членов, которые может иметь
аргумент типа. Накладывая ограничение на базовый класс, вы тем самым даете компилятору
знать, что все аргументы типа будут иметь члены, определенные в этом базовом
классе.

И во-вторых, ограничение на базовый класс гарантирует использование только
тех аргументов типа, которые поддерживают указанный базовый класс. Это означает,
что для любого ограничения, накладываемого на базовый класс, аргумент типа
должен обозначать сам базовый класс или производный от него класс. Если же попытаться
использовать аргумент типа, не соответствующий указанному базовому
классу или не наследующий его, то в результате возникнет ошибка во время компиляции.

Ниже приведена общая форма наложения ограничения на базовый класс, в которой
используется оператор where:

where Т : имя_базового_класса

где T обозначает имя параметра типа, а имя_базового_класса — конкретное имя
ограничиваемого базового класса. Одновременно в этой форме ограничения может
быть указан только один базовый класс.

В приведенном ниже простом примере демонстрируется механизм наложения
ограничения на базовый класс.

*/

// Простой пример, демонстрирующий механизм наложения ограничения на базовый класс.

using System;

class A
{
    public void Hello()
    {
        Console.WriteLine("Hello");
    }
}

// Класс В наследует класс А.
class B : A { }

// Класс С не наследует класс А.
class C { }

// В силу ограничения на базовый класс во всех аргументах типа,
// передаваемых классу Test, должен присутствовать базовый класс А.
class Test<T> where T : A
{
    T obj;

    public Test(T о)
    {
        obj = о;
    }

    public void SayHello()
    {
        // Метод Hello() вызывается, поскольку он объявлен в базовом классе А.
        obj.Hello();
    }
}
class BaseClassConstraintDemo
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        C с = new C();

        // Следующий код вполне допустим, поскольку класс А указан как базовый.
        Test<A> t1 = new Test<A>(a);

        t1.SayHello();

        // Следующий код вполне допустим, поскольку класс В наследует от класса А.
        Test<B> t2 = new Test<B>(b);

        t2.SayHello();

        // Следующий код недопустим, поскольку класс С не наследует от класса А.
        // Test<C> t3 = new Test<C>(c); // Ошибка!
        // t3.SayHello(); // Ошибка!

        Console.ReadKey();
    }
}

/*

В данном примере кода класс А наследуется классом В, но не наследуется классом
С. Обратите также внимание на то, что в классе А объявляется метод Hello(), а класс
Test объявляется как обобщенный следующим образом.

class Test<T> where Т : А {

Оператор where в этом объявлении накладывает следующее ограничение: любой
аргумент, указываемый для типа Т, должен иметь класс А в качестве базового.

А теперь обратите внимание на то, что в классе Test объявляется метод
SayHello(), как показано ниже.

public void SayHello() {
// Метод Hello() вызывается, поскольку он объявлен в базовом классе А.
obj.Hello();
}

Этот метод вызывает в свою очередь метод Hello() для объекта obj типа Т. Любопытно,
что единственным основанием для вызова метода Hello() служит следующее
требование ограничения на базовый класс: любой аргумент типа, привязанный к типу
Т, должен относиться к классу А или наследовать от класса А, в котором объявлен метод
Hello(). Следовательно, любой допустимый тип Т будет также определять метод
Hello(). Если бы данное ограничение на базовый класс не было наложено, то компилятору
ничего не было бы известно о том, что метод Hello() может быть вызван для
объекта типа Т. Убедитесь в этом сами, удалив оператор where из объявления обобщенного
класса Test. В этом случае программа не подлежит компиляции, поскольку
теперь метод Hello() неизвестен.

Помимо разрешения доступа к членам базового класса, ограничение на базовый
класс гарантирует, что в качестве аргументов типа могут быть переданы только те типы
данных, которые наследуют базовый класс. Именно поэтому приведенные ниже строки
кода закомментированы.

// Test<C> t3 = new Test<C>(c); // Ошибка!
// t3.SayHello(); // Ошибка!

Класс С не наследует от класса А, и поэтому он не может использоваться в качестве
аргумента типа при создании объекта типа Test. Убедитесь в этом сами, удалив символы
комментария и попытавшись перекомпилировать этот код.

Прежде чем продолжить изложение дальше, рассмотрим вкратце два последствия
наложения ограничения на базовый класс. Во-первых, это ограничение разрешает доступ
к членам базового класса из обобщенного класса. И во-вторых, оно гарантирует
допустимость только тех аргументов типа, которые удовлетворяют данному ограничению,
обеспечивая тем самым типовую безопасность.

*/

#endregion

#region English

/*

Constrained Types

In the preceding examples, the type parameters could be replaced by any type. For example,
given this declaration

class Gen<T> {

any type can be specified for T. Thus, it is legal to create Gen objects in which T is replaced
by int, double, string, FileStream, or any other type. Although having no restrictions on the
type argument is fine for many purposes, sometimes it is useful to limit the types that can
be used as a type argument. For example, you might want to create a method that operates
on the contents of a stream, including a FileStream or MemoryStream. This situation seems
perfect for generics, but you need some way to ensure that only stream types are used as
type arguments. You don’t want to allow a type argument of int, for example. You also need
some way to tell the compiler that the methods defined by a stream will be available for use.
For example, your generic code needs some way to know that it can call the Read( ) method.

To handle such situations, C# provides constrained types. When specifying a type parameter,
you can specify a constraint that the type parameter must satisfy. This is accomplished through
the use of a where clause when specifying the type parameter, as shown here:

class class-name<type-param> where type-param : constraints { // ...

Here, constraints is a comma-separated list of constraints.

C# defines the following types of constraints.

• You can require that a certain base class be present in a type argument by using a
base class constraint. This constraint is specified by naming the desired base class.
There is a variation of this constraint, called a naked type constraint, in which a type
parameter (rather than an actual type) specifies the base class. This enables you to
establish a relationship between two type parameters.

• You can require that one or more interfaces be implemented by a type argument by
using an interface constraint. This constraint is specified by naming the desired interface.

• You can require that the type argument supply a parameterless constructor. This is
called a constructor constraint. It is specified by new().

• You can specify that a type argument be a reference type by specifying the reference
type constraint: class.

• You can specify that the type argument be a value type by specifying the value type
constraint: struct.

Of these constraints, the base class constraint and the interface constraint are probably
the most often used, but all are important. Each constraint is examined in the following
sections.

Using a Base Class Constraint

The base class constraint enables you to specify a base class that a type argument must
inherit. A base class constraint serves two important purposes. First, it lets you use the
members of the base class specified by the constraint within the generic class. For example,
you can call a method or use a property of the base class. Without a base class constraint,
the compiler has no way to know what type of members a type argument might have. By
supplying a base class constraint, you are letting the compiler know that all type arguments
will have the members defined by that base class.

The second purpose of a base class constraint is to ensure that only type arguments that
support the specified base class are used. This means that for any given base class constraint,
the type argument must be either the base class, itself, or a class derived from that base class.
If you attempt to use a type argument that does not match or inherit the specified base class,
a compile-time error will result.

The base class constraint uses this form of the where clause:

where T : base-class-name

Here, T is the name of the type parameter, and base-class-name is the name of the base class.
Only one base class can be specified.

Here is a simple example that demonstrates the base class constraint mechanism:

*/



#endregion