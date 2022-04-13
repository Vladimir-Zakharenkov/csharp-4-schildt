#region Russian

/*

Различение обобщенных типов по аргументам типа

Что касается обобщенных типов, то следует иметь в виду, что ссылка на один конкретный
вариант обобщенного типа не совпадает по типу с другим вариантом того же
самого обобщенного типа. Так, если ввести в приведенную выше программу следующую
строку кода, то она не будет скомпилирована.

iOb = strOb; // Неверно!

Несмотря на то что обе переменные, iOb и strOb, относятся к типу Gen<T>, они
ссылаются на разные типы, поскольку у них разные аргументы.

Повышение типовой безопасности с помощью обобщений

В связи с изложенным выше возникает следующий резонный вопрос: если аналогичные
функциональные возможности обобщенного класса Gen можно получить и без
обобщений, просто указав объект как тип данных и выполнив надлежащее приведение
типов, то какая польза от того, что класс Gen делается обобщенным? Ответ на этот вопрос
заключается в том, что обобщения автоматически обеспечивают типовую безопасность
всех операций, затрагивающих класс Gen. В ходе выполнения этих операций
обобщения исключают необходимость обращаться к приведению типов и проверять
соответствие типов в коде вручную.

Для того чтобы стали более понятными преимущества обобщений, рассмотрим
сначала программу, в которой создается необобщенный аналог класса Gen.

*/

// Класс NonGen является полным функциональным аналогом
// класса Gen, но без обобщений.

using System;

class NonGen
{
    object ob; // переменная ob теперь относится к типу object

    // Передать конструктору ссылку на объект типа object.
    public NonGen(object о)
    {
        ob = о;
    }

    // Возвратить объект типа object.
    public object GetOb()
    {
        return ob;
    }

    // Показать тип переменной ob.
    public void ShowType()
    {
        Console.WriteLine("Тип переменной ob: " + ob.GetType());
    }
}

// Продемонстрировать применение необобщенного класса.
class NonGenDemo
{
    static void Main()
    {
        NonGen iOb;

        // Создать объект класса NonGen.
        iOb = new NonGen(102);

        // Показать тип данных, хранящихся в переменной iOb.
        iOb.ShowType();

        // Получить значение переменной iOb.
        // На этот раз потребуется приведение типов.
        int v = (int)iOb.GetOb();
        Console.WriteLine("Значение: " + v);

        Console.WriteLine();

        // Создать еще один объект класса NonGen .
        NonGen strOb = new NonGen("Тест на необобщенность");

        // Показать тип данных, хранящихся в переменной strOb.
        strOb.ShowType();

        // Получить значение переменной strOb.
        // И в этом случае требуется приведение типов.
        String str = (string)strOb.GetOb();
        Console.WriteLine("Значение: " + str);

        // Этот код компилируется, но он принципиально неверный!
        iOb = strOb;

        // Следующая строка кода приводит к исключительной
        // ситуации во время выполнения.
        // v = (int) iOb.GetOb(); // Ошибка при выполнении!

        Console.ReadKey();
    }
}

/*

При выполнении этой программы получается следующий результат.

Тип переменной ob: System.Int32
Значение: 102

Тип переменной ob: System.String
Значение: Тест на необобщенность

Как видите, результат выполнения этой программы такой же, как и у предыдущей
программы.

В этой программе обращает на себя внимание ряд любопытных моментов. Прежде
всего, тип Т заменен везде, где он встречается в классе NonGen. Благодаря этому в классе
NonGen может храниться объект любого типа, как и в обобщенном варианте этого
класса. Но такой подход оказывается непригодным по двум причинам. Во-первых, для
извлечения хранящихся данных требуется явное приведение типов. И во-вторых, многие
ошибки несоответствия типов не могут быть обнаружены вплоть до момента выполнения
программы. Рассмотрим каждую из этих причин более подробно.

Начнем со следующей строки кода.

int v = (int) iOb.GetOb();

Теперь возвращаемым типом метода GetOb() является object, а следовательно,
для распаковки значения, возвращаемого методом GetOb(), и его последующего сохранения
в переменной v требуется явное приведение к типу int. Если исключить
приведение типов, программа не будет скомпилирована. В обобщенной версии этой
программы приведение типов не требовалось, поскольку тип int указывался в качестве
аргумента типа при создании объекта iOb. А в необобщенной версии этой программы
потребовалось явное приведение типов. Но это не только неудобно, но и чревато
ошибками.

А теперь рассмотрим следующую последовательность кода в конце анализируемой
здесь программы.

// Этот код компилируется, но он принципиально неверный!
iOb = strOb;

// Следующая строка кода приводит к исключительной
// ситуации во время выполнения.
// v = (int) iOb.GetOb(); // Ошибка при выполнении!

В этом коде значение переменной strOb присваивается переменной iOb. Но переменная
strOb ссылается на объект, содержащий символьную строку, а не целое значение.
Такое присваивание оказывается верным с точки зрения синтаксиса, поскольку
все ссылки на объекты класса NonGen одинаковы, а значит, по ссылке на один объект
класса NonGen можно обращаться к любому другому объекту класса NonGen. Тем не
менее такое присваивание неверно с точки зрения семантики, как показывает следующая
далее закомментированная строка кода. В этой строке тип, возвращаемый методом
GetOb(), приводится к типу int, а затем предпринимается попытка присвоить
полученное в итоге значение переменной int. К сожалению, в отсутствие обобщений
компилятор не сможет выявить подобную ошибку. Вместо этого возникнет исключительная
ситуация во время выполнения, когда будет предпринята попытка приведения
к типу int. Для того чтобы убедиться в этом, удалите символы комментария в начале
данной строки кода, скомпилируйте, а затем выполните программу. При ее выполнении
возникнет ошибка.

Упомянутая выше ситуация не могла бы возникнуть, если бы в программе использовались
обобщения. Компилятор выявил бы ошибку в приведенной выше последовательности
кода, если бы она была включена в обобщенную версию программы, и сообщил
бы об этой ошибке, предотвратив тем самым серьезный сбой, приводящий
к исключительной ситуации при выполнении программы. Возможность создавать
типизированный код, в котором ошибки несоответствия типов выявляются во время
компиляции, является главным преимуществом обобщений. Несмотря на то что в C#
всегда имелась возможность создавать "обобщенный" код, используя ссылки на объекты,
такой код не был типизированным, т.е. не обеспечивал типовую безопасность, а его
неправильное применение могло привести к исключительным ситуациям во время
выполнения. Подобные ситуации исключаются благодаря обобщениям. По существу,
обобщения переводят ошибки при выполнении в разряд ошибок при компиляции.
В этом и заключается основная польза от обобщений.

В рассматриваемой здесь необобщенной версии программы имеется еще один
любопытный момент. Обратите внимание на то, как тип переменной ob экземпляра
класса NonGen создается с помощью метода ShowType() в следующей строке кода.

Console.WriteLine("Тип переменной ob: " + ob.GetType());

Как пояснялось в главе 11, в классе object определен ряд методов, доступных для
всех типов данных. Одним из них является метод GetType(), возвращающий объект
класса Туре, который описывает тип вызывающего объекта во время выполнения. Следовательно,
конкретный тип объекта, на который ссылается переменная ob, становится
известным во время выполнения, несмотря на то, что тип переменной ob указан
в исходном коде как object. Именно поэтому в среде CLR будет сгенерировано исключение
при попытке выполнить неверное приведение типов во время выполнения
программы.

*/

#endregion

#region English

/*

Generic Types Differ Based on Their Type Arguments

A key point to understand about generic types is that a reference of one specific version of a
generic type is not type-compatible with another version of the same generic type. For example,
assuming the program just shown, the following line of code is in error and will not compile:

iOb = strOb; // Wrong!

Even though both iOb and strOb are of type Gen<T>, they are references to different types
because their type arguments differ.

How Generics Improve Type Safety

At this point, you might be asking yourself the following question. Given that the same
functionality found in the generic Gen class can be achieved without generics, by simply
specifying object as the data type and employing the proper casts, what is the benefit of
making Gen generic? The answer is that generics automatically ensure the type safety of all
operations involving Gen. In the process, generics eliminate the need for you to use casts
and type-check code by hand.

To understand the benefits of generics, first consider the following program that creates
a non-generic equivalent of Gen:

*/

// NonGen is functionally equivalent to Gen but does not use generics. 

//using System; 

//class NonGen
//{
//    object ob; // ob is now of type object 

//    // Pass the constructor a reference of type object. 
//    public NonGen(object o)
//    {
//        ob = o;
//    }

//    // Return type object. 
//    public object GetOb()
//    {
//        return ob;
//    }

//    // Show type of ob.  
//    public void ShowType()
//    {
//        Console.WriteLine("Type of ob is " + ob.GetType());
//    }
//}

//// Demonstrate the non-generic class.  
//class NonGenDemo
//{
//    static void Main()
//    {
//        NonGen iOb;

//        // Create NonGen object. 
//        iOb = new NonGen(102);

//        // Show the type of data stored in iOb. 
//        iOb.ShowType();

//        // Get the value in iOb. 
//        // This time, a cast is necessary. 
//        int v = (int)iOb.GetOb();
//        Console.WriteLine("value: " + v);

//        Console.WriteLine();

//        // Create another NonGen object and store a string in it. 
//        NonGen strOb = new NonGen("Non-Generics Test");

//        // Show the type of data stored strOb. 
//        strOb.ShowType();

//        // Get the value of strOb. 
//        // Again, notice that a cast is necessary.  
//        String str = (string)strOb.GetOb();
//        Console.WriteLine("value: " + str);

//        // This compiles, but is conceptually wrong! 
//        iOb = strOb;

//        // The following line results in a run-time exception. 
//        // v = (int) iOb.GetOb(); // run-time error! 

//        Console.ReadKey();
//    }
//}

/*

This program produces the following output:

Type of ob is System.Int32
value: 102

Type of ob is System.String
value: Non-Generics Test

As you can see, the output is similar to the previous version of the program.

There are several things of interest in this version. First, notice that NonGen replaces all
uses of T with object. This makes NonGen able to store any type of object, as can the generic
version. However, this approach is bad for two reasons. First, explicit casts must be employed
to retrieve the stored data. Second, many kinds of type mismatch errors cannot be found
until runtime. Let’s look closely at each problem.

We will begin with this line:

int v = (int) iOb.GetOb();

Because the return type of GetOb() is now object, the cast to int is necessary to enable
the value returned by GetOb() to be unboxed and stored in v. If you remove the cast, the
program will not compile. In the generic version of the program, this cast was not needed
because int was specified as a type argument when iOb was constructed. In the non-generic
version, the cast must be employed. This is not only an inconvenience, but a potential
source of error.

Now, consider the following sequence from near the end of the program:

// This compiles, but is conceptually wrong!
iOb = strOb;

// The following line results in a runtime exception.
// v = (int) iOb.GetOb(); // runtime error!

Here, strOb is assigned to iOb. However, strOb refers to an object that contains a string, not
an integer. This assignment is syntactically valid because all NonGen references are the same,
and any NonGen reference can refer to any other NonGen object. However, the statement is
semantically wrong, as the commented-out line shows. In that line, the return type of GetOb()
is cast to int and then an attempt is made to assign this value to v. The trouble is that iOb
now refers to an object that stores a string, not an int. Unfortunately, without generics, the
compiler won’t catch this error. Instead, a runtime exception will occur when the cast to int
is attempted. To see this for yourself, try removing the comment symbol from the start of
the line and then compiling and running the program. A runtime error will occur.

The preceding sequence can’t occur when generics are used. If this sequence were
attempted in the generic version of the program, the compiler would catch it and report
an error, thus preventing a serious bug that results in a runtime exception. The ability to
create type-safe code in which type-mismatch errors are caught at compile time is a key
advantage of generics. Although using object references to create “generic” code has always
been possible in C#, that code was not type-safe and its misuse could result in runtime
exceptions. Generics prevent this from occurring. In essence, through generics, what
were once runtime errors have become compile-time errors. This is a major benefit.

There is one other point of interest in the NonGen program. Notice how the type of the
NonGen instance variable ob is obtained by ShowType():

Console.WriteLine("Type of ob is " + ob.GetType());

Recall from Chapter 11 that object defines several methods that are available to all data types.
One of these methods is GetType(), which returns a Type object that describes the type of
the invoking object at runtime. Thus, even though the type of ob is specified as object in the
program’s source code, at runtime, the actual type of object being referred to is known. This
is why the CLR will generate an exception if you try an invalid cast during program execution.

*/

#endregion