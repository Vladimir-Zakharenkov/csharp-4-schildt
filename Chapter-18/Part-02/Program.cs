#region Russian

/*

Простой пример обобщений

Начнем рассмотрение обобщений с простого примера обобщенного класса. В приведенной
ниже программе определяются два класса. Первым из них является обобщенный
класс Gen, вторым — класс GenericsDemo, в котором используется класс Gen.

*/

// Простой пример обобщенного класса.

using System;

// В приведенном ниже классе Gen параметр типа Т заменяется
// реальным типом данных при создании объекта типа Gen.
class Gen<T>
{
    T ob; // объявить переменную типа Т

    // Обратите внимание на то, что у этого конструктора имеется параметр типа Т.
    public Gen(T о)
    {
        ob = о;
    }

    // Возвратить переменную экземпляра ob, которая относится к типу Т.
    public T GetOb()
    {
        return ob;
    }

    // Показать тип Т.
    public void ShowType()
    {
        Console.WriteLine("К типу T относится " + typeof(T));
    }
}

// Продемонстрировать применение обобщенного класса.
class GenericsDemo
{
    static void Main()
    {
        // Создать переменную ссылки на объект Gen типа int.
        Gen<int> iOb;

        // Создать объект типа Gen<int> и присвоить ссылку на него переменной iOb.
        iOb = new Gen<int>(102);

        // Показать тип данных, хранящихся в переменной iOb.
        iOb.ShowType();

        // Получить значение переменной iOb.
        int v = iOb.GetOb();
        Console.WriteLine("Значение: " + v);

        Console.WriteLine();

        // Создать объект типа Gen для строк.
        Gen<string> strOb = new Gen<string>("Обобщения повышают эффективность.");

        // Показать тип данных, хранящихся в переменной strOb.
        strOb.ShowType();

        // Получить значение переменной strOb.
        string str = strOb.GetOb();
        Console.WriteLine("Значение: " + str);

        Console.ReadKey();
    }
}

/*

Эта программа дает следующий результат.

К типу Т относится System.Int32
Значение: 102

К типу Т относится System.String
Значение: Обобщения повышают эффективность.

Внимательно проанализируем эту программу. Прежде всего обратите внимание на
объявление класса Gen в приведенной ниже строке кода:

class Gen<T> {

где Т — это имя параметра типа. Это имя служит в качестве метки-заполнителя конкретного
типа, который указывается при создании объекта класса Gen. Следовательно,
имя Т используется в классе Gen всякий раз, когда требуется параметр типа. Обратите
внимание на то, что имя Т заключается в угловые скобки (< >). Этот синтаксис можно
обобщить: всякий раз, когда объявляется параметр типа, он указывается в угловых
скобках. А поскольку параметр типа используется в классе Gen, то такой класс считается
обобщенным.

В объявлении класса Gen можно указывать любое имя параметра типа, но по традиции
выбирается имя Т. К числу других наиболее употребительных имен параметров
типа относятся V и Е. Вы, конечно, вольны использовать и более описательные имена,
например TValue или ТКеу. Но в этом случае первой в имени параметра типа принято
указывать прописную букву Т.

Далее имя Т используется для объявления переменной ob, как показано в следующей
строке кода.

Т ob; // объявить переменную типа Т

Как пояснялось выше, имя параметра типа Т служит меткой-заполнителем конкретного
типа, указываемого при создании объекта класса Gen. Поэтому переменная
ob будет иметь тип, привязываемый к Т при получении экземпляра объекта класса Gen.
Так, если вместо Т указывается тип string, то в экземпляре данного объекта переменная
ob будет иметь тип string.

А теперь рассмотрим конструктор класса Gen.

public Gen(Т о) {
ob = о;
}
Как видите, параметр о этого конструктора относится к типу Т. Это означает, что
конкретный тип параметра о определяется типом, привязываемым к Т при создании
объекта класса Gen. А поскольку параметр о и переменная экземпляра ob относятся
к типу Т, то после создания объекта класса Gen их конкретный тип окажется одним и
тем же.

С помощью параметра типа Т можно также указывать тип, возвращаемый методом,
как показано ниже на примере метода GetOb().

public Т GetOb() {
return ob;
}

Переменная ob также относится к типу Т, поэтому ее тип совпадает с типом, возвращаемым
методом GetOb().

Метод ShowType() отображает тип параметра Т, передавая его оператору typeof.
Но поскольку реальный тип подставляется вместо Т при создании объекта класса Gen,
то оператор typeof получит необходимую информацию о конкретном типе.

В классе GenericsDemo демонстрируется применение обобщенного класса Gen.
Сначала в нем создается вариант класса Gen для типа int.

Gen<int> iOb;

Внимательно проанализируем это объявление. Прежде всего обратите внимание на
то, что тип int указывается в угловых скобках после имени класса Gen. В этом случае
int служит аргументом типа, привязанным к параметру типа Т в классе Gen. В данном
объявлении создается вариант класса Gen, в котором тип Т заменяется типом int везде,
где он встречается. Следовательно, после этого объявления int становится типом
переменной ob и возвращаемым типом метода GetOb().

В следующей строке кода переменной iOb присваивается ссылка на экземпляр
объекта класса Gen для варианта типа int.

iOb = new Gen<int>(102);

Обратите внимание на то, что при вызове конструктора класса Gen указывается также
аргумент типа int. Это необходимо потому, что переменная (в данном случае —
iOb), которой присваивается ссылка, относится к типу Gen<int>. Поэтому ссылка, возвращаемая
оператором new, также должна относиться к типу Gen<int>. В противном
случае во время компиляции возникнет ошибка. Например, приведенное ниже присваивание
станет причиной ошибки во время компиляции.

iOb = new Gen<double>(118.12); // Ошибка!

Переменная iOb относится к типу Gen<int> и поэтому не может использоваться
для ссылки на объект типа Gen<double>. Такой контроль типов относится к одним из
главных преимуществ обобщений, поскольку он обеспечивает типовую безопасность.

Затем в программе отображается тип переменной ob в объекте iOb — тип System.
Int32. Это структура .NET, соответствующая типу int. Далее значение переменной ob
получается в следующей строке кода.

int v = iOb.GetOb();

Возвращаемым для метода GetOb() является тип Т, который был заменен на тип
int при объявлении переменной iOb, и поэтому метод GetOb() возвращает значение
того же типа int. Следовательно, данное значение может быть присвоено переменной
v типа int.

Далее в классе GenericsDemo объявляется объект типа Gen<string>.

Gen<string> strOb = new Gen<string>("Обобщения повышают эффективность.");

В этом объявлении указывается аргумент типа string, поэтому в объекте класса Gen
вместо Т подставляется тип string. В итоге создается вариант класса Gen для типа string,
как демонстрируют остальные строки кода рассматриваемой здесь программы.

Прежде чем продолжить изложение, следует дать определение некоторым терминам.
Когда для класса Gen указывается аргумент типа, например int или string, то
создается так называемый в C# закрыто сконструированный тип. В частности, Gen<int>
является закрыто сконструированным типом. Ведь, по существу, такой обобщенный
тип, как Gen<T>, является абстракцией. И только после того, как будет сконструирован
конкретный вариант, например Gen<int>, создается конкретный тип. А конструкция, 
подобная Gen<T>, называется в C# открыто сконструированным типом, поскольку
в ней указывается параметр типа Т, но не такой конкретный тип, как int.

В С# чаще определяются такие понятия, как открытый и закрытый типы. Открытым
типом считается такой параметр типа или любой обобщенный тип, для которого
аргумент типа является параметром типа или же включает его в себя. А любой тип, не
относящийся к открытому, считается закрытым. Сконструированным типом считается
такой обобщенный тип, для которого предоставлены все аргументы типов. Если все
эти аргументы относятся к закрытым типам, то такой тип считается закрыто сконструированным.
А если один или несколько аргументов типа относятся к открытым типам,
то такой тип считается открыто сконструированным.

*/

#endregion

#region English

/*

A Simple Generics Example

Let’s begin with a simple example of a generic class. The following program defines two
classes. The first is the generic class Gen, and the second is GenericsDemo, which uses Gen.

*/

// A simple generic class.  

//using System; 

//// In the following Gen class, T is a type parameter 
//// that will be replaced by a real type when an object 
//// of type Gen is created. 
//class Gen<T>
//{
//    T ob; // declare a variable of type T 

//    // Notice that this constructor has a parameter of type T. 
//    public Gen(T o)
//    {
//        ob = o;
//    }

//    // Return ob, which is of type T. 
//    public T GetOb()
//    {
//        return ob;
//    }

//    // Show type of T. 
//    public void ShowType()
//    {
//        Console.WriteLine("Type of T is " + typeof(T));
//    }
//}

//// Demonstrate the generic class. 
//class GenericsDemo
//{
//    static void Main()
//    {
//        // Create a Gen reference for int. 
//        Gen<int> iOb;

//        // Create a Gen<int> object and assign its reference to iOb. 
//        iOb = new Gen<int>(102);

//        // Show the type of data used by iOb. 
//        iOb.ShowType();

//        // Get the value in iOb. 
//        int v = iOb.GetOb();
//        Console.WriteLine("value: " + v);

//        Console.WriteLine();

//        // Create a Gen object for strings. 
//        Gen<string> strOb = new Gen<string>("Generics add power.");

//        // Show the type of data stored in strOb. 
//        strOb.ShowType();

//        // Get the value in strOb. 
//        string str = strOb.GetOb();
//        Console.WriteLine("value: " + str);

//        Console.ReadKey();
//    }
//}

/*

The output produced by the program is shown here:

Type of T is System.Int32
value: 102

Type of T is System.String
value: Generics add power.

Let’s examine this program carefully.

First, notice how Gen is declared by the following line.

class Gen<T> {

Here, T is the name of a type parameter. This name is used as a placeholder for the actual
type that will be specified when a Gen object is created. Thus, T is used within Gen whenever
the type parameter is needed. Notice that T is contained within < >. This syntax can be
generalized. Whenever a type parameter is being declared, it is specified within angle brackets.
Because Gen uses a type parameter, Gen is a generic class.

In the declaration of Gen, there is no special significance to the name T. Any valid
identifier could have been used, but T is traditional. Other commonly used type parameter
names include V and E. Of course, you can also use descriptive names for type parameters,
such as TValue or TKey. When using a descriptive name, it is common practice to use T as
the first letter.

Next, T is used to declare a variable called ob, as shown here:

T ob; // declare a variable of type T

As explained, T is a placeholder for the actual type that will be specified when a Gen object
is created. Thus, ob will be a variable of the type bound to T when a Gen object is instantiated.
For example, if type string is specified for T, then in that instance, ob will be of type string.

Now consider Gen’s constructor:
public Gen(T o) {
ob = o;
}

Notice that its parameter, o, is of type T. This means that the actual type of o is determined
by the type bound to T when a Gen object is created. Also, because both the parameter o
and the instance variable ob are of type T, they will both be of the same actual type when a
Gen object is created.

The type parameter T can also be used to specify the return type of a method, as is the
case with the GetOb() method, shown here:

public T GetOb() {
return ob;
}

Because ob is also of type T, its type is compatible with the return type specified by GetOb().

The ShowType() method displays the type of T by passing T to the typeof operator.
Because a real type will be substituted for T when an object of type Gen is created, typeof
will obtain type information about the actual type.

The GenericsDemo class demonstrates the generic Gen class. It first creates a version of
Gen for type int, as shown here:

Gen<int> iOb;

Look closely at this declaration. First, notice that the type int is specified within the angle
brackets after Gen. In this case, int is a type argument that is bound to Gen’s type parameter,
T. This creates a version of Gen in which all uses of T are replaced by int. Thus, for this
declaration, ob is of type int, and the return type of GetOb() is of type int.

The next line assigns to iOb a reference to an instance of an int version of the Gen class:

iOb = new Gen<int>(102);

Notice that when the Gen constructor is called, the type argument int is also specified. This
is necessary because the type of the variable (in this case iOb) to which the reference is being
assigned is of type Gen<int>. Thus, the reference returned by new must also be of type
Gen<int>. If it isn’t, a compile-time error will result. For example, the following assignment
will cause a compile-time error:

iOb = new Gen<double>(118.12); // Error!

Because iOb is of type Gen<int>, it can’t be used to refer to an object of Gen<double>. This
type checking is one of the main benefits of generics because it ensures type safety.

The program then displays the type of ob within iOb, which is System.Int32. This is the
.NET structure that corresponds to int. Next, the program obtains the value of ob by use of
the following line:

int v = iOb.GetOb();

Because the return type of GetOb() is T, which was replaced by int when iOb was declared,
the return type of GetOb() is also int. Thus, this value can be assigned to an int variable.

Next, GenericsDemo declares an object of type Gen<string>:

Gen<string> strOb = new Gen<string>("Generics add power.");

Because the type argument is string, string is substituted for T inside Gen. This creates a
string version of Gen, as the remaining lines in the program demonstrate.

Before moving on, a few terms need to be defined. When you specify a type argument
such as int or string for Gen, you are creating what is referred to in C# as a closed constructed
type. Thus, Gen<int> is a closed constructed type. In essence, a generic type, such as
Gen<T>, is an abstraction. It is only after a specific version, such as Gen<int>, has been
constructed that a concrete type has been created. In C# terminology, a construct such as
Gen<T> is called an open constructed type, because the type parameter T (rather than an
actual type, such as int) is specified.

More generally, C# defines the concepts of an open type and a closed type. An open type is
a type parameter or any generic type whose type argument is (or involves) a type parameter.
Any type that is not an open type is a closed type. A constructed type is a generic type for
which all type arguments have been supplied. If those type arguments are all closed types,
then it is a closed constructed type. If one or more of those type arguments are open types,
it is an open constructed type.

*/

#endregion