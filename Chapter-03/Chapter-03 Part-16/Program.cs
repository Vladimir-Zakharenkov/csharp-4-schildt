#region Russian

/*

Более подробное рассмотрение переменных

Переменные объявляются с помощью оператора следующей формы:

тип имя_переменной;

где тип — это тип данных, хранящихся в переменной; а имя_переменной — это ее
имя. Объявить можно переменную любого действительного типа, в том числе и описанных
выше типов значений. Важно подчеркнуть, что возможности переменной определяются
ее типом. Например, переменную типа bool нельзя использовать для хранения
числовых значений с плавающей точкой. Кроме того, тип переменной нельзя
изменять в течение срока ее существования. В частности, переменную типа int нельзя
преобразовать в переменную типа char.

Все переменные в C# должны быть объявлены до их применения. Это нужно для
того, чтобы уведомить компилятор о типе данных, хранящихся в переменной, прежде
чем он попытается правильно скомпилировать любой оператор, в котором используется
переменная. Это позволяет также осуществлять строгий контроль типов в С#.

В С# определено несколько различных видов переменных. Так, в предыдущих примерах
программ использовались переменные, называемые локальными, поскольку они
объявляются внутри метода.

Инициализация переменной

Задать значение переменной можно, в частности, с помощью оператора присваивания,
как было не раз продемонстрировано ранее. Кроме того, задать начальное значение
переменной можно при ее объявлении. Для этого после имени переменной указывается
знак равенства (=) и присваиваемое значение. Ниже приведена общая форма
инициализации переменной:

тип имя_переменной = значение;

где значение — это конкретное значение, задаваемое при создании переменной. Оно
должно соответствовать указанному типу переменной.

Ниже приведены некоторые примеры инициализации переменных.

int count = 10; // задать начальное значение 10 переменной count.
char ch = 'X' ; // инициализировать переменную ch буквенным значением X.
float f = 1.2F // переменная f инициализируется числовым значением 1,2.

Если две или более переменные одного и того же типа объявляются списком, разделяемым
запятыми, то этим переменным можно задать, например, начальное значение.

int а, b = 8 , с = 19, d; // инициализировать переменные b и с

В данном примере инициализируются только переменные b и с.

*/

#endregion

#region English

/*

A Closer Look at Variables

Variables are declared using this form of statement:

type var-name;

where type is the data type of the variable and var-name is its name. You can declare a variable
of any valid type, including the value types just described. It is important to understand that a
variable’s capabilities are determined by its type. For example, a variable of type bool cannot
be used to store floating-point values. Furthermore, the type of a variable cannot change
during its lifetime. An int variable cannot turn into a char variable, for example.

All variables in C# must be declared prior to their use. As a general rule, this is
necessary because the compiler must know what type of data a variable contains before it
can properly compile any statement that uses the variable. It also enables the compiler to
perform strict type-checking.

C# defines several different kinds of variables. The kind that we have been using are
called local variables because they are declared within a method.

Initializing a Variable

One way to give a variable a value is through an assignment statement, as you have already
seen. Another way is by giving it an initial value when it is declared. To do this, follow the
variable’s name with an equal sign and the value being assigned. The general form of
initialization is shown here:

type var-name = value;

Here, value is the value that is given to the variable when it is created. The value must be
compatible with the specified type.

Here are some examples:

int count = 10; // give count an initial value of 10
char ch = 'X'; // initialize ch with the letter X
float f = 1.2F; // f is initialized with 1.2

When declaring two or more variables of the same type using a comma-separated list,
you can give one or more of those variables an initial value. For example:

int a, b = 8, c = 19, d; // b and c have initializations

In this case, only b and c are initialized.

*/

#endregion