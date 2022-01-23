#region Russian

/*

Литералы

В C# литералами называются постоянные значения, представленные в удобной для
восприятия форме. Например, число 100 является литералом. Сами литералы и их
назначение настолько понятны, что они применялись во всех предыдущих примерах
программ без всяких пояснений. Но теперь настало время дать им формальное объяснение.

В С# литералы могут быть любого простого типа. Представление каждого литерала
зависит от конкретного типа. Как пояснялось ранее, символьные литералы заключаются
в одинарные кавычки. Например, 'а' и '%' являются символьными литералами.

Целочисленные литералы указываются в виде чисел без дробной части. Например,
10 и -100 — это целочисленные литералы. Для обозначения литералов с плавающей
точкой требуется указывать десятичную точку и дробную часть числа. Например,
11.123 — это литерал с плавающей точкой. Для вещественных чисел с плавающей
точкой в C# допускается также использовать экспоненциальное представление.

У литералов должен быть также конкретный тип, поскольку C# является строго типизированным
языком. В этой связи возникает естественный вопрос: к какому типу
следует отнести числовой литерал, например 2,123987 или 0.23? К счастью, для ответа
на этот вопрос в C# установлен ряд простых для соблюдения правил.

Во-первых, у целочисленных литералов должен быть самый мелкий целочисленный
тип, которым они могут быть представлены, начиная с типа int. Таким образом,
у целочисленных литералов может быть один из следующих типов: int, uint, long
или ulong в зависимости от значения литерала. И во-вторых, литералы с плавающей
точкой относятся к типу double.

Если вас не устраивает используемый по умолчанию тип литерала, вы можете явно
указать другой его тип с помощью суффикса. Так, для указания типа long к литералу
присоединяется суффикс l или L. Например, 12 — это литерал типа int, a 12L — литерал
типа long. Для указания целочисленного типа без знака к литералу присоединяется
суффикс u или U. Следовательно, 100 — это литерал типа int, a 100U — литерал
типа uint. А для указания длинного целочисленного типа без знака к литералу присоединяется
суффикс ul или UL. Например, 984375UL — это литерал типа ulong.

Кроме того, для указания типа float к литералу присоединяется суффикс F или f.
Например, 10.19F — это литерал типа float. Можете даже указать тип double, присоединив
к литералу суффикс d или D, хотя это излишне. Ведь, как упоминалось выше,
по умолчанию литералы с плавающей точкой относятся к типу double.

И наконец, для указания типа decimal к литералу присоединяется суффикс m или
М. Например, 9.95М — это десятичный литерал типа decimal.

Несмотря на то что целочисленные литералы образуют по умолчанию значения
типа int, uint, long или ulong, их можно присваивать переменным типа byte,
sbyte, short или ushort, при условии, что присваиваемое значение может быть
представлено целевым типом.

*/

#endregion

#region English

/*

Literals

In C#, literals refer to fixed values that are represented in their human-readable form.
For example, the number 100 is a literal. For the most part, literals and their usage are
so intuitive that they have been used in one form or another by all the preceding sample
programs. Now the time has come to explain them formally.

C# literals can be of any simple type. The way each literal is represented depends upon
its type. As explained earlier, character literals are enclosed between single quotes. For
example, ‘a’ and ‘%’ are both character literals.

Integer literals are specified as numbers without fractional components. For example,
10 and –100 are integer literals. Floating-point literals require the use of the decimal point
followed by the number’s fractional component. For example, 11.123 is a floating-point literal.
C# also allows you to use scientific notation for floating-point numbers.

Since C# is a strongly typed language, literals, too, have a type. Naturally, this raises the
following question: What is the type of a numeric literal? For example, what is the type of
12, 123987, or 0.23? Fortunately, C# specifies some easy-to-follow rules that answer these
questions.

First, for integer literals, the type of the literal is the smallest integer type that will hold
it, beginning with int. Thus, an integer literal is either of type int, uint, long, or ulong,
depending upon its value. Second, floating-point literals are of type double.

If C#’s default type is not what you want for a literal, you can explicitly specify its type
by including a suffix. To specify a long literal, append an l or an L. For example, 12 is an
int, but 12L is a long. To specify an unsigned integer value, append a u or U. Thus, 100 is
an int, but 100U is a uint. To specify an unsigned, long integer, use ul or UL. For example,
984375UL is of type ulong.

To specify a float literal, append an F or f to the constant. For example, 10.19F is of type
float. Although redundant, you can specify a double literal by appending a D or d. (As just
mentioned, floating-point literals are double by default.)

To specify a decimal literal, follow its value with an m or M. For example, 9.95M is a
decimal literal.

*/

#endregion