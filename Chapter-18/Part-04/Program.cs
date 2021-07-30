#region Russian

/*

Обобщенный класс с двумя параметрами типа

В классе обобщенного типа можно указать два или более параметра типа. В этом
случае параметры типа указываются списком через запятую. В качестве примера ниже
приведен класс TwoGen, являющийся вариантом класса Gen с двумя параметрами
типа.

*/

// Простой обобщенный класс с двумя параметрами типа Т и V.

using System;
class TwoGen<T, V>
{
    T ob1;
    V ob2;

    // Обратите внимание на то, что в этом конструкторе
    // указываются параметры типа Т и V.
    public TwoGen(T o1, V о2)
    {
        ob1 = o1;
        ob2 = о2;
    }

    // Показать типы Т и V.
    public void ShowTypes()
    {
        Console.WriteLine("К типу T относится " + typeof(T));
        Console.WriteLine("К типу V относится " + typeof(V));
    }

    public T Getobj1()
    {
        return ob1;
    }

    public V GetObj2()
    {
        return ob2;
    }
}

// Продемонстрировать применение обобщенного класса с двумя параметрами типа.
class SimpGen
{
    static void Main()
    {
        TwoGen<int, string> tgObj = new TwoGen<int, string>(119, "Альфа Бета Гамма");

        // Показать типы.
        tgObj.ShowTypes();

        // Получить и вывести значения.
        int v = tgObj.Getobj1();
        Console.WriteLine("Значение: " + v);
        string str = tgObj.GetObj2();
        Console.WriteLine("Значение: " + str);

        Console.ReadKey();
    }
}

/*

Эта программа дает следующий результат.

К типу Т относится System.Int32
К типу V относится System.String
Значение: 119
Значение: Альфа Бета Гамма

Обратите внимание на то, как объявляется класс TwoGen.

class TwoGen<T, V> {

В этом объявлении указываются два параметра типа Т и V, разделенные запятой.
А поскольку у класса TwoGen два параметра типа, то при создании объекта этого класса
необходимо указывать два соответствующих аргумента типа, как показано ниже.

TwoGen<int, string> tgObj = new TwoGen<int, string>(119, "Альфа Бета Гамма");

В данном случае вместо Т подставляется тип int, а вместо V — тип string.

В представленном выше примере указываются аргументы разного типа, но они могут
быть и одного типа. Например, следующая строка кода считается вполне допустимой.

TwoGen<string, string> х = new TwoGen<string, string> ("Hello", "Goodbye");

В этом случае оба типа, Т и V, заменяются одним и тем же типом, string. Ясно,
что если бы аргументы были одного и того же типа, то два параметра типа были бы
не нужны.

Общая форма обобщенного класса

Синтаксис обобщений, представленных в предыдущих примерах, может быть сведен
к общей форме. Ниже приведена общая форма объявления обобщенного класса.

class имя_класса<список_параметров_типа> { // ...

А вот как выглядит синтаксис объявления ссылки на обобщенный класс.

имя_класса<список_аргументов_типа> имя_переменной = new имя_класса<список_параметров_типа> (список_аргументов_конструктора);

*/

#endregion

#region English

/*

A Generic Class with Two Type Parameters

You can declare more than one type parameter in a generic type. To specify two or more
type parameters, simply use a comma-separated list. For example, the following TwoGen
class is a variation of the Gen class that has two type parameters:

*/

// A simple generic class with two type parameters: T and V. 

//using System; 

//class TwoGen<T, V>
//{
//    T ob1;
//    V ob2;

//    // Notice that this constructor has parameters of type T and V. 
//    public TwoGen(T o1, V o2)
//    {
//        ob1 = o1;
//        ob2 = o2;
//    }

//    // Show types of T and V. 
//    public void showTypes()
//    {
//        Console.WriteLine("Type of T is " + typeof(T));
//        Console.WriteLine("Type of V is " + typeof(V));
//    }

//    public T getob1()
//    {
//        return ob1;
//    }

//    public V GetObj2()
//    {
//        return ob2;
//    }
//}

//// Demonstrate two generic type parameters. 
//class SimpGen
//{
//    static void Main()
//    {

//        TwoGen<int, string> tgObj =
//          new TwoGen<int, string>(119, "Alpha Beta Gamma");

//        // Show the types. 
//        tgObj.showTypes();

//        // Obtain and show values. 
//        int v = tgObj.getob1();
//        Console.WriteLine("value: " + v);

//        string str = tgObj.GetObj2();
//        Console.WriteLine("value: " + str);

//        Console.ReadKey();
//    }
//}

/*

The output from this program is shown here:

Type of T is System.Int32
Type of V is System.String
value: 119
value: Alpha Beta Gamma

Notice how TwoGen is declared:

class TwoGen<T, V> {

It specifies two type parameters: T and V, separated by a comma. Because it has two type
parameters, two type arguments must be specified when a TwoGen object is created, as
shown here:

TwoGen<int, string> tgObj = new TwoGen<int, string>(119, "Alpha Beta Gamma");

In this case, int is substituted for T and string is substituted for V.

Although the two type arguments differ in this example, it is possible for both types to
be the same. For example, the following line of code is valid:

TwoGen<string, string> x = new TwoGen<string, string>("Hello", "Goodbye");

In this case, both T and V would be of type string. Of course, if the type arguments were
always the same, then two type parameters would be unnecessary.

*/

#endregion