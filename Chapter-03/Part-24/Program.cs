#region Russian

/*

Преобразование типов в выражениях

Помимо операций присваивания, преобразование типов происходит и в самих выражениях.
В выражении можно свободно смешивать два или более типа данных, при
условии их совместимости друг с другом. Например, в одном выражении допускается
применение типов short и long, поскольку оба типа являются числовыми. Когда
в выражении смешиваются разные типы данных, они преобразуются в один и тот же
тип по порядку следования операций.

Преобразования типов выполняются по принятым в C# правилам продвижения типов.
Ниже приведен алгоритм, определяемый этими правилами для операций с двумя
операндами.

ЕСЛИ один операнд имеет тип decimal, ТО и второй операнд продвигается
к типу decimal (но если второй операнд имеет тип float или double, результат
будет ошибочным).

ЕСЛИ один операнд имеет тип double, ТО и второй операнд продвигается
к типу double.

ЕСЛИ один операнд имеет тип float, ТО и второй операнд продвигается к типу
float.

ЕСЛИ один операнд имеет тип ulong, ТО и второй операнд продвигается
к типу ulong (но если второй операнд имеет тип sbyte, short, int или long,
результат будет ошибочным).

ЕСЛИ один операнд имеет тип long, ТО и второй операнд продвигается к типу
long.

ЕСЛИ один операнд имеет тип uint, а второй — тип sbyte, short или int, ТО
оба операнда продвигаются к типу long.

ЕСЛИ один операнд имеет тип uint, ТО и второй операнд продвигается к типу
uint.
ИНАЧЕ оба операнда продвигаются к типу int.

Относительно правил продвижения типов необходимо сделать ряд важных замечаний.
Во-первых, не все типы могут смешиваться в выражении. В частности, неявное
преобразование типа float или double в тип decimal невозможно, как, впрочем,
и смешение типа ulong с любым целочисленным типом со знаком. Для смешения
этих типов требуется явное их приведение.

Во-вторых, особого внимания требует последнее из приведенных выше правил. Оно
гласит: если ни одно из предыдущих правил не применяется, то все операнды продвигаются
к типу int. Следовательно, все значения типа char, sbyte, byte, ushort
и short продвигаются к типу int в целях вычисления выражения. Такое продвижение
типов называется целочисленным. Это также означает, что результат выполнения всех
арифметических операций будет иметь тип не ниже int.

Следует иметь в виду, что правила продвижения типов применяются только к значениям,
которыми оперируют при вычислении выражения. Так, если значение переменной
типа byte продвигается к типу int внутри выражения, то вне выражения эта
переменная по-прежнему относится к типу byte. Продвижение типов затрагивает
только вычисление выражения.

Но продвижение типов может иногда привести к неожиданным результатам. Если,
например, в арифметической операции используются два значения типа byte, то происходит
следующее. Сначала операнды типа byte продвигаются к типу int. А затем
выполняется операция, дающая результат типа int. Следовательно, результат выполнения
операции, в которой участвуют два значения типа byte, будет иметь тип int.
Но ведь это не тот результат, который можно было бы с очевидностью предположить.
Рассмотрим следующий пример программы.

*/

// Пример неожиданного результата продвижения типов!
using System;
class PromDemo
{
    static void Main()
    {
        byte b;
        b = 10;

        b = (byte)(b * b); // Необходимо приведение типов!!
        Console.WriteLine("b: " + b);
    }
}

/*

Как ни странно, но когда результат вычисления выражения b*b присваивается обратно
переменной b, то возникает потребность в приведении к типу byte! Объясняется это
тем, что в выражении b*b значение переменной b продвигается к типу int и поэтому не
может быть присвоено переменной типа byte без приведения типов. Имейте это обстоятельство
в виду, если получите неожиданное сообщение об ошибке несовместимости
типов в выражениях, которые, на первый взгляд, кажутся совершенно правильными.

Аналогичная ситуация возникает при выполнении операций с символьными операндами.
Например, в следующем фрагменте кода требуется обратное приведение
к типу char, поскольку операнды ch1 и ch2 в выражении продвигаются к типу int.

char ch1 = 'a', ch2 = 'b';
ch1 = (char) (ch1 + ch2);

Без приведения типов результат сложения операндов ch1 и ch2 будет иметь тип
int, и поэтому его нельзя присвоить переменной типа char.

Продвижение типов происходит и при выполнении унарных операций, например
с унарным минусом. Операнды унарных операций более мелкого типа, чем int(byte,
sbyte, short и ushort), т.е. с более узким диапазоном представления чисел, продвигаются
к типу int. То же самое происходит и с операндом типа char. Кроме того,
если выполняется унарная операция отрицания значения типа uint, то результат продвигается
к типу long.

*/

#endregion

#region English

/*

Type Conversion in Expressions

In addition to occurring within an assignment, type conversions also take place within an
expression. In an expression, you can freely mix two or more different types of data as long
as they are compatible with each other. For example, you can mix short and long within an
expression because they are both numeric types. When different types of data are mixed
within an expression, they are converted to the same type, on an operation-by-operation basis.

The conversions are accomplished through the use of C#’s type promotion rules. Here is
the algorithm that they define for binary operations:

IF one operand is a decimal, THEN the other operand is promoted to decimal
(unless it is of type fl oat or double, in which case an error results).

ELSE IF one operand is a double, the second is promoted to double.

ELSE IF one operand is a fl oat, the second is promoted to float.

ELSE IF one operand is a ulong, the second is promoted to ulong (unless it is
of type sbyte, short, int, or long, in which case an error results).

ELSE IF one operand is a long, the second is promoted to long.

ELSE IF one operand is a uint and the second is of type sbyte, short, or int,
both are promoted to long.

ELSE IF one operand is a uint, the second is promoted to uint.

ELSE both operands are promoted to int.

There are a couple of important points to be made about the type promotion rules. First,
not all types can be mixed in an expression. Specifically, there is no implicit conversion from
float or double to decimal, and it is not possible to mix ulong with any signed integer type.
To mix these types requires the use of an explicit cast.

Second, pay special attention to the last rule. It states that if none of the preceding rules
applies, then all other operands are promoted to int. Therefore, in an expression, all char,
sbyte, byte, ushort, and short values are promoted to int for the purposes of calculation.
This is called integer promotion. It also means that the outcome of all arithmetic operations
will be no smaller than int.

It is important to understand that type promotions only apply to the values operated
upon when an expression is evaluated. For example, if the value of a byte variable is
promoted to int inside an expression, outside the expression, the variable is still a byte.
Type promotion only affects the evaluation of an expression.

Type promotion can, however, lead to somewhat unexpected results. For example, when
an arithmetic operation involves two byte values, the following sequence occurs. First, the
byte operands are promoted to int. Then the operation takes place, yielding an int result.
Thus, the outcome of an operation involving two byte values will be an int. This is not what
you might intuitively expect. Consider the following program.

*/

// A promotion surprise!
//using System;
//class PromDemo
//{
//    static void Main()
//    {
//        byte b;
//        b = 10;

//        b = (byte)(b * b); // cast needed!!
//        Console.WriteLine("b: " + b);
//    }
//}

/*

Somewhat counterintuitively, a cast to byte is needed when assigning b * b back to b! The
reason is because in b * b, the value of b is promoted to int when the expression is evaluated.
Thus, b * b results in an int value, which cannot be assigned to a byte variable without a
cast. Keep this in mind if you get unexpected type-incompatibility error messages on
expressions that would otherwise seem perfectly correct.

This same sort of situation also occurs when performing operations on chars. For
example, in the following fragment, the cast back to char is needed because of the
promotion of ch1 and ch2 to int within the expression

char ch1 = 'a', ch2 = 'b';
ch1 = (char) (ch1 + ch2);

Without the cast, the result of adding ch1 to ch2 would be int, which can’t be assigned to
a char.

Type promotions also occur when a unary operation, such as the unary –, takes place.
For the unary operations, operands smaller than int (byte, sbyte, short, and ushort) are
promoted to int. Also, a char operand is converted to int. Furthermore, if a uint value is
negated, it is promoted to long.

*/

#endregion