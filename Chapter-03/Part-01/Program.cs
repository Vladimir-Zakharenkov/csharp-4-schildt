#region Russian

/*

ГЛАВА 3

Типы данных, литералы и переменные

В этой главе рассматриваются три основополагающих
элемента С#: типы данных, литералы и переменные.
В целом, типы данных, доступные в языке программирования,
определяют те виды задач, для решения которых
можно применять данный язык. Как и следовало ожидать,
в C# предоставляется богатый набор встроенных типов данных,
что делает этот язык пригодным для самого широкого
применения. Любой из этих типов данных может служить
для создания переменных и констант, которые в языке C#
называются литералами.

О значении типов данных

Типы данных имеют особенное значение в С#, поскольку
это строго типизированный язык. Это означает, что все
операции подвергаются строгому контролю со стороны
компилятора на соответствие типов, причем недопустимые
операции не компилируются. Следовательно, строгий контроль
типов позволяет исключить ошибки и повысить надежность
программ. Для обеспечения контроля типов все
переменные, выражения и значения должны принадлежать
к определенному типу. Такого понятия, как "бестиповая"
переменная, в данном языке программирования вообще не
существует. Более того, тип значения определяет те операции,
которые разрешается выполнять над ним. Операция,
разрешенная для одного типа данных, может оказаться недопустимой
для другого.

ПРИМЕЧАНИЕ
В версии C# 4.0 внедрен новый тип данных, называемый dynamic и приводящий
к отсрочке контроля типов до времени выполнения, вместо того чтобы производить подобный
контроль во время компиляции. Поэтому тип dynamic является исключением из обычного
правила контроля типов во время компиляции. Подробнее о типе dynamic речь пойдет
в главе 17.

Типы значений в C#

В C# имеются две общие категории встроенных типов данных: типы значений и ссылочные
типы. Они отличаются по содержимому переменной. Если переменная относится
к типу значения, то она содержит само значение, например 3,1416 или 212.
А если переменная относится к ссылочному типу, то она содержит ссылку на значение.
Наиболее распространенным примером использования ссылочного типа является
класс, но о классах и ссылочных типах речь пойдет далее в этой книге. А здесь рассматриваются
типы значений.

В основу языка C# положены 13 типов значений, перечисленных в табл. 3.1. Все они
называются простыми типами, поскольку состоят из единственного значения. (Иными
словами, они не состоят из двух или более значений.) Они составляют основу системы
типов С#, предоставляя простейшие, низкоуровневые элементы данных, которыми
можно оперировать в программе. Простые типы данных иногда еще называют примитивными.

Таблица. 3.1. Типы значений в C#

Тип         Значение
bool        Логический, предоставляет два значения: “истина” или “ложь”
byte        8-разрядный целочисленный без знака
char        Символьный
decimal     Десятичный (для финансовых расчетов)
double      С плавающей точкой двойной точности
float       С плавающей точкой одинарной точности
int         Целочисленный
long        Длинный целочисленный
sbyte       8-разрядный целочисленный со знаком
short       Короткий целочисленный
uint        Целочисленный без знака
ulong       Длинный целочисленный без знака
ushort      Короткий целочисленный без знака

В C# строго определены пределы и характер действия каждого типа значения.
Исходя из требований к переносимости программ, C# не допускает в этом отношении
никаких компромиссов. Например, тип int должен быть одинаковым во всех средах
выполнения. Но в этом случае отпадает необходимость переписывать код для конкретной
платформы. И хотя строгое определение размерности типов значений может
стать причиной незначительного падения производительности в некоторых средах, эта
мера необходима для достижения переносимости программ.

ПРИМЕЧАНИЕ
Помимо простых типов, в C# определены еще три категории типов значений: перечисления,
структуры и обнуляемые типы. Все они рассматриваются далее в этой книге.

*/

#endregion

#region English

/*

CHAPTER 3

Data Types, Literals, and Variables

This chapter examines three fundamental elements of C#: data types, literals, and
variables. In general, the types of data that a language provides define the kinds of
problems to which the language can be applied. As you might expect, C# offers a rich
set of built-in data types, which makes C# suitable for a wide range of applications. You can
create variables of any of these types, and you can specify constants of each type, which in
the language of C# are called literals.

Why Data Types Are Important

Data types are especially important in C# because it is a strongly typed language. This
means that, as a general rule, all operations are type-checked by the compiler for type
compatibility. Illegal operations will not be compiled. Thus, strong type-checking helps
prevent errors and enhances reliability. To enable strong type-checking, all variables,
expressions, and values have a type. There is no concept of a “typeless” variable, for
example. Furthermore, a value’s type determines what operations are allowed on it.
An operation allowed on one type might not be allowed on another.

NOTE
C# 4.0 adds a new data type called dynamic, which causes type checking to be deferred until
runtime, rather than occurring at compile time. Thus, the dynamic type is an exception to C#’s
normal compile-time type checking. The dynamic type is discussed in Chapter 17.

C#’s Value Types

C# contains two general categories of built-in data types: value types and reference types. The
difference between the two types is what a variable contains. For a value type, a variable
holds an actual value, such 3.1416 or 212. For a reference type, a variable holds a reference
to the value. The most commonly used reference type is the class, and a discussion of classes
and reference types is deferred until later in this book. The value types are described here.

At the core of C# are the 13 value types shown in Table 3-1. Collectively, these are
referred to as the simple types. They are called simple types because they consist of a single
value. (In other words, they are not a composite of two or more values.) They form the
foundation of C#’s type system, providing the basic, low-level data elements upon which
a program operates. The simple types are also sometimes referred to as primitive types.

Type            Meaning

bool            Represents true/false values
byte            8-bit unsigned integer
char            Character
decimal         Numeric type for financial calculations
double          Double-precision floating point
float           Single-precision floating point
int             Integer
long            Long integer
sbyte           8-bit signed integer
short           Short integer
uint            An unsigned integer
ulong           An unsigned long integer
ushort          An unsigned short integer

TABLE 3-1 The C# Value Types

C# strictly specifies a range and behavior for each value type. Because of portability
requirements, C# is uncompromising on this account. For example, an int is the same in all
execution environments. There is no need to rewrite code to fit a specific platform. Although
strictly specifying the size of the value types may cause a small loss of performance in some
environments, it is necessary in order to achieve portability.

NOTE
In addition to the simple types, C# defines three other categories of value types. These are
enumerations, structures, and nullable types, all of which are described later in this book.

*/


#endregion