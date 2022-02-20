#region Russian

/*

Приведение несовместимых типов

Несмотря на всю полезность неявных преобразований типов, они неспособны удовлетворить
все потребности в программировании, поскольку допускают лишь расширяющие
преобразования совместимых типов. А во всех остальных случаях приходится
обращаться к приведению типов. Приведение — это команда компилятору преобразовать
результат вычисления выражения в указанный тип. А для этого требуется явное
преобразование типов. Ниже приведена общая форма приведения типов.

(целевой_тип) выражение

Здесь целевой_тип обозначает тот тип, в который желательно преобразовать указанное
выражение. Рассмотрим для примера следующее объявление переменных.

double х, у;

Если результат вычисления выражения х/у должен быть типа int, то следует записать
следующее.

(int) (х / у)

Несмотря на то что переменные х и у относятся к типу double, результат вычисления
выражения х/у преобразуется в тип int благодаря приведению. В данном примере
выражение х/у следует непременно указывать в скобках, иначе приведение к типу
int будет распространяться только на переменную х, а не на результат ее деления на
переменную у. Приведение типов в данном случае требуется потому, что неявное преобразование
типа double в тип int невозможно.

Если приведение типов приводит к сужающему преобразованию, то часть информации
может быть потеряна. Например, в результате приведения типа long к типу int
часть информации потеряется, если значение типа long окажется больше диапазона
представления чисел для типа int, поскольку старшие разряды этого числового значения
отбрасываются. Когда же значение с плавающей точкой приводится к целочисленному,
то в результате усечения теряется дробная часть этого числового значения. Так,
если присвоить значение 1,23 целочисленной переменной, то в результате в ней останется
лишь целая часть исходного числа (1), а дробная его часть (0,23) будет потеряна.

В следующем примере программы демонстрируется ряд преобразований типов,
требующих приведения. В этом примере показан также ряд ситуаций, в которых приведение
типов становится причиной потери данных.

*/

// Продемонстрировать приведение типов.

//using System;
//class CastDemo
//{
//    static void Main()
//    {
//        double x, y;
//        byte b;
//        int i;
//        char ch;
//        uint u;
//        short s;
//        long l;

//        x = 10.0;
//        y = 3.0;

//        // Приведение типа double к типу int, дробная часть числа теряется.
//        i = (int)(x/y);
//        Console.WriteLine("Целочисленный результат деления х / у: " + i);
//        Console.WriteLine();

//        // Приведение типа int к типу byte без потери данных,
//        i = 255;
//        b = (byte)i;
//        Console.WriteLine("b после присваивания 255: " + b +
//        " -- без потери данных.");

//        // Приведение типа int к типу byte с потерей данных,
//        i = 257;
//        b = (byte)i;
//        Console.WriteLine("b после присваивания 257: " + b +
//        " -- с потерей данных.");
//        Console.WriteLine();

//        // Приведение типа uint к типу short без потери данных.
//        u = 32000;
//        s = (short)u;
//        Console.WriteLine("s после присваивания 32000: " +
//        s + " -- без потери данных.");

//        // Приведение типа uint к типу short с потерей данных,
//        u = 64000;
//        s = (short)u;
//        Console.WriteLine("s после присваивания 64000: " +
//        s + " -- с потерей данных.");
//        Console.WriteLine();

//        // Приведение типа long к типу uint без потери данных.
//        l = 64000;
//        u = (uint)l;
//        Console.WriteLine("u после присваивания 64000: " + u +
//        " -- без потери данных.");

//        // Приведение типа long к типу uint с потерей данных.
//        l = -12;
//        u = (uint)l;
//        Console.WriteLine("и после присваивания -12: " + u +
//        " -- с потерей данных.");
//        Console.WriteLine();

//        // Приведение типа int к типу char,
//        b = 88; // код ASCII символа X
//        ch = (char)b;
//        Console.WriteLine("ch после присваивания 88: " + ch);
//    }
//}

/*
 
Вот какой результат дает выполнение этой программы.

Целочисленный результат деления х / у: 3

b после присваивания 255: 255 -- без потери данных.
b после присваивания 257: 1 -- с потерей данных.

s после присваивания 32000: 32000 -- без потери данных.
s после присваивания 64000: -1536 -- с потерей данных.

u после присваивания 64000: 64000 -- без потери данных.
u после присваивания -12: 4294967284 -- с потерей данных.

ch после присваивания 88: X

Рассмотрим каждую операцию присваивания в представленном выше примере
программы по отдельности. Вследствие приведения результата деления х/у к типу
int отбрасывается дробная часть числа, а следовательно, теряется часть информации.

Когда переменной b присваивается значение 255, то информация не теряется, поскольку
это значение входит в диапазон представления чисел для типа byte. Но когда
переменной b присваивается значение 257, то часть информации теряется, поскольку
это значение превышает диапазон представления чисел для типа byte. Приведение
типов требуется в обоих случаях, поскольку неявное преобразование типа int в тип
byte невозможно.

Когда переменной s типа short присваивается значение 32 000 переменной и типа
uint, потери данных не происходит, поскольку это значение входит в диапазон представления
чисел для типа short. Но в следующей операции присваивания переменная
и имеет значение 64 000, которое оказывается вне диапазона представления чисел
для типа short, и поэтому данные теряются. Приведение типов требуется в обоих
случаях, поскольку неявное преобразование типа uint в тип short невозможно.

Далее переменной u присваивается значение 64 000 переменной l типа long.
В этом случае данные не теряются, поскольку значение 64 000 оказывается вне диапазона
представления чисел для типа uint. Но когда переменной u присваивается значение
-12, данные теряются, поскольку отрицательные числа также оказываются вне
диапазона представления чисел для типа uint. Приведение типов требуется в обоих
случаях, так как неявное преобразование типа long в тип uint невозможно.

И наконец, когда переменной char присваивается значение типа byte, информация
не теряется, но приведение типов все же требуется.

*/

#endregion

#region English

/*

Casting Incompatible Types

Although the implicit type conversions are helpful, they will not fulfill all programming
needs because they apply only to widening conversions between compatible types. For all
other cases you must employ a cast. A cast is an instruction to the compiler to convert the
outcome of an expression into a specified type. Thus, it requests an explicit type conversion.
A cast has this general form:

(target-type) expression

Here, target-type specifies the desired type to convert the specified expression to. For
example, given

double x, y;

if you want the type of the expression x/y to be int, you can write

(int) (x / y)

Here, even though x and y are of type double, the cast converts the outcome of the expression
to int. The parentheses surrounding x / y are necessary. Otherwise, the cast to int would
apply only to the x and not to the outcome of the division. The cast is necessary here
because there is no implicit conversion from double to int.

When a cast involves a narrowing conversion, information might be lost. For example,
when casting a long into an int, information will be lost if the long’s value is greater than
the range of an int because its high-order bits are removed. When a floating-point value is
cast to an integer type, the fractional component will also be lost due to truncation. For
example, if the value 1.23 is assigned to an integer, the resulting value will simply be 1.
The 0.23 is lost.

The following program demonstrates some type conversions that require casts. It also
shows some situations in which the casts cause data to be lost.

*/

// Demonstrate casting.
using System;
class CastDemo
{
    static void Main()
    {
        double x, y;
        byte b;
        int i;
        char ch;
        uint u;
        short s;
        long l;
        x = 10.0;
        y = 3.0;

        // Cast double to int, fractional component lost.
        i = (int)(x / y);
        Console.WriteLine("Integer outcome of x / y: " + i);
        Console.WriteLine();

        // Cast an int into a byte, no data lost.
        i = 255;
        b = (byte)i;
        Console.WriteLine("b after assigning 255: " + b +
        " -- no data lost.");

        // Cast an int into a byte, data lost.
        i = 257;
        b = (byte)i;
        Console.WriteLine("b after assigning 257: " + b +
        " -- data lost.");
        Console.WriteLine();

        // Cast a uint into a short, no data lost.
        u = 32000;
        s = (short)u;
        Console.WriteLine("s after assigning 32000: " + s +
        " -- no data lost.");

        // Cast a uint into a short, data lost.
        u = 64000;
        s = (short)u;
        Console.WriteLine("s after assigning 64000: " + s +
        " -- data lost.");
        Console.WriteLine();

        // Cast a long into a uint, no data lost.
        l = 64000;
        u = (uint)l;
        Console.WriteLine("u after assigning 64000: " + u +
        " -- no data lost.");

        // Cast a long into a uint, data lost.
        l = -12;
        u = (uint)l;
        Console.WriteLine("u after assigning -12: " + u +
        " -- data lost.");
        Console.WriteLine();

        // Cast an int into a char.
        b = 88; // ASCII code for X
        ch = (char)b;
        Console.WriteLine("ch after assigning 88: " + ch);
    }
}

/*

The output from the program is shown here:

Integer outcome of x / y: 3

b after assigning 255: 255 -- no data lost.
b after assigning 257: 1 -- data lost.

s after assigning 32000: 32000 -- no data lost.
s after assigning 64000: -1536 -- data lost.

u after assigning 64000: 64000 -- no data lost.
u after assigning -12: 4294967284 -- data lost.

ch after assigning 88: X

Let’s look at each assignment. The cast of (x / y) to int results in the truncation of the
fractional component, and information is lost.

No loss of information occurs when b is assigned the value 255 because a byte can hold
the value 255. However, when the attempt is made to assign b the value 257, information
loss occurs because 257 exceeds a byte’s range. In both cases the casts are needed because
there is no implicit conversion from int to byte.

When the short variable s is assigned the value 32,000 through the uint variable u, no
data is lost because a short can hold the value 32,000. However, in the next assignment, u
has the value 64,000, which is outside the range of a short, and data is lost. In both cases the
casts are needed because there is no implicit conversion from uint to short.

Next, u is assigned the value 64,000 through the long variable l. In this case, no data is
lost because 64,000 is within the range of a uint. However, when the value –12 is assigned
to u, data is lost because a uint cannot hold negative numbers. In both cases the casts are
needed because there is no implicit conversion from long to uint.

Finally, no information is lost, but a cast is needed when assigning a byte value to
a char.
*/

#endregion