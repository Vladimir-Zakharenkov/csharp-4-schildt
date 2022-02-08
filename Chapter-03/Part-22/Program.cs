#region Russian

/*

Преобразование и приведение типов

В программировании нередко значения переменных одного типа присваиваются
переменным другого типа. Например, в приведенном ниже фрагменте кода целое значение
типа int присваивается переменной с плавающей точкой типа float.

int i;
float f;

i = 10;
f = i; // присвоить целое значение переменной типа float

Если в одной операции присваивания смешиваются совместимые типы данных,
то значение в правой части оператора присваивания автоматически преобразуется
в тип, указанный в левой его части. Поэтому в приведенном выше фрагменте кода
значение переменной i сначала преобразуется в тип float, а затем присваивается
переменной f. Но вследствие строгого контроля типов далеко не все типы данных
в С# оказываются полностью совместимыми, а следовательно, не все преобразования
типов разрешены в неявном виде. Например, типы bool и int несовместимы.
Правда, преобразование несовместимых типов все-таки может быть осуществлено
путем приведения. Приведение типов, по существу, означает явное их преобразование.
В этом разделе рассматривается как автоматическое преобразование, так и приведение
типов.

Автоматическое преобразование типов

Когда данные одного типа присваиваются переменной другого типа, неявное преобразование
типов происходит автоматически при следующих условиях:

• оба типа совместимы;
• диапазон представления чисел целевого типа шире, чем у исходного типа.

Если оба эти условия удовлетворяются, то происходит расширяющее преобразование.
Например, тип int достаточно крупный, чтобы вмещать в себя все действительные
значения типа byte, а кроме того, оба типа, int и byte, являются совместимыми целочисленными
типами, и поэтому для них вполне возможно неявное преобразование.

Числовые типы, как целочисленные, так и с плавающей точкой, вполне совместимы
друг с другом для выполнения расширяющих преобразований. Так, приведенная ниже
программа составлена совершенно правильно, поскольку преобразование типа long
в тип double является расширяющим и выполняется автоматически.

*/

// Продемонстрировать неявное преобразование типа long в тип double.
using System;
class LtoD
{
    static void Main()
    {
        long L;
        double D;

        L = 100123285L;
        D = L;

        Console.WriteLine("L и D: " + L + " " + D);
    }
}

/*

Если тип long может быть преобразован в тип double неявно, то обратное преобразование
типа double в тип long неявным образом невозможно, поскольку оно
не является расширяющим. Следовательно, приведенный ниже вариант предыдущей
программы составлен неправильно.

 */

// *** Эта программа не может быть скомпилирована. ***
//using System;
//class LtoD
//{
//    static void Main()
//    {
//        long L;
//        double D;

//        D = 100123285.0;
//        L = D; // Недопустимо!!!

//        Console.WriteLine("L и D: " + L + " " + D);
//    }
//}


/*

Помимо упомянутых выше ограничений, не допускается неявное взаимное преобразование
типов decimal и float или double, а также числовых типов и char или
bool. Кроме того, типы char и bool несовместимы друг с другом.

*/

#endregion

#region English

/*

Type Conversion and Casting

In programming, it is common to assign one type of variable to another. For example, you
might want to assign an int value to a float variable, as shown here:

int i;
float f;

i = 10;
f = i; // assign an int to a float

When compatible types are mixed in an assignment, the value of the right side is
automatically converted to the type of the left side. Thus, in the preceding fragment, the
value in i is converted into a float and then assigned to f. However, because of C#’s strict
type-checking, not all types are compatible, and thus, not all type conversions are implicitly
allowed. For example, bool and int are not compatible. Fortunately, it is still possible to
obtain a conversion between incompatible types by using a cast. A cast performs an explicit
type conversion. Both automatic type conversion and casting are examined here.
Automatic Conversions

When one type of data is assigned to another type of variable, an implicit type conversion
will take place automatically if

• The two types are compatible.
• The destination type has a range that is greater than the source type.

When these two conditions are met, a widening conversion takes place. For example, the int
type is always large enough to hold all valid byte values, and both int and byte are compatible
integer types, so an implicit conversion can be applied.

For widening conversions, the numeric types, including integer and floating-point
types, are compatible with each other. For example, the following program is perfectly
valid since long to double is a widening conversion that is automatically performed.

*/

// Demonstrate implicit conversion from long to double.
//using System;
//class LtoD
//{
//    static void Main()
//    {
//        long L;
//        double D;

//        L = 100123285L;
//        D = L;

//        Console.WriteLine("L and D: " + L + " " + D);
//    }
//}

/*

Although there is an implicit conversion from long to double, there is no implicit
conversion from double to long since this is not a widening conversion. Thus, the following
version of the preceding program is invalid:

*/

// *** This program will not compile. ***
//using System;
//class LtoD
//{
//    static void Main()
//    {
//        long L;
//        double D;

//        D = 100123285.0;
//        L = D; // Illegal!!!

//        Console.WriteLine("L and D: " + L + " " + D);
//    }
//}

/*

In addition to the restrictions just described, there are no implicit conversions between
decimal and float or double, or from the numeric types to char or bool. Also, char and bool
are not compatible with each other.

*/

#endregion