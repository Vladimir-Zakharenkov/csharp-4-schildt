#region Russian

/*

Некоторые возможности вывода

До сих пор при выводе с помощью метода WriteLine() данные отображались
в формате, используемом по умолчанию. Но в среде .NET Framework определен достаточно
развитый механизм форматирования, позволяющий во всех деталях управлять
выводом данных. Форматированный ввод-вывод подробнее рассматривается далее
в этой книге, а до тех пор полезно ознакомиться с некоторыми возможностями форматирования.
Они позволяют указать, в каком именно виде следует выводить значения
с помощью метода WriteLine(). Благодаря этому выводимый результат выглядит
более привлекательно. Следует, однако, иметь в виду, что механизм форматирования
поддерживает намного больше возможностей, а не только те, которые рассматриваются
в этом разделе.

При выводе списков данных в предыдущих примерах программ каждый элемент
списка приходилось отделять знаком +, как в следующей строке.

Console.WriteLine("Вы заказали " + 2 + " предмета по цене $" + 3 + " каждый.");

Конечно, такой способ вывода числовой информации удобен, но он не позволяет
управлять внешним видом выводимой информации. Например, при выводе значения
с плавающей точкой нельзя определить количество отображаемых десятичных разрядов.
Рассмотрим оператор

Console.WriteLine("Деление 10/3 дает: " + 10.0/3.0);

который выводит следующий результат.

Деление 10/3 дает: 3.33333333333333

В одних случаях такого вывода может оказаться достаточно, а в других — он просто
недопустим. Например, в финансовых расчетах после десятичной точки принято
указывать лишь два десятичных разряда.

Для управления форматированием числовых данных служит другая форма метода
WriteLine(), позволяющая встраивать информацию форматирования, как показано
ниже.

WriteLine("форматирующая строка", arg0, arg1, ... , argN);

В этой форме аргументы метода WriteLine() разделяются запятой, а не знаком +.
А форматирующая строка состоит из двух элементов: обычных печатаемых символов,
предназначенных для вывода в исходном виде, а также спецификаторов формата. Последние
указываются в следующей общей форме:

{argnum, width: fmt}

где argnum — номер выводимого аргумента, начиная с нуля; width — минимальная
ширина поля; fmt — формат. Параметры width и fmt являются необязательными.

Если во время выполнения в форматирующей строке встречается спецификатор
формата, то вместо него подставляется и отображается соответствующий аргумент,
обозначаемый параметром argnum. Таким образом, местоположение спецификатора
формата в форматирующей строке определяет место отображения соответствующих
данных. Параметры width и fmt указывать необязательно. Это означает, что в своей
простейшей форме спецификатор формата обозначает конкретный отображаемый
аргумент. Например, спецификатор {0} обозначает аргумент arg0, спецификатор
{1} — аргумент arg1 и т.д.

Начнем с самого простого примера. При выполнение оператора

Console.WriteLine("В феврале {0} или {1} дней.", 28, 29);

получается следующий результат.

В феврале 28 или 29 дней

Как видите, значение 28 подставляется вместо спецификатора {0}, а значение 29 —
вместо спецификатора {1}. Следовательно, спецификаторы формата обозначают место
в строке, где отображаются соответствующие аргументы (в данном случае — значения
28 и 29). Кроме того, обратите внимание на то, что дополнительные значения
разделяются запятой, а не знаком +.

Ниже приведен видоизмененный вариант предыдущего оператора, в котором указывается
ширина полей.

Console.WriteLine("В феврале {0,10} или {1,5} дней.", 28, 29);

Выполнение этого оператора дает следующий результат.

В феврале         28 или    29 дней.

Как видите, неиспользуемые части полей заполнены пробелами. Напомним, что
минимальная ширина поля определяется параметром width. Если требуется, она может
быть превышена при выводе результата.

Разумеется, аргументы, связанные с командой форматирования, не обязательно
должны быть константами. Ниже приведен пример программы, которая выводит таблицу
результатов возведения чисел в квадрат и куб. В ней команды форматирования
используются для вывода соответствующих значений.

*/

// Применить команды форматирования.

using System;

class DisplayOptionss
{
    static void Main()
    {
        int i;

        Console.WriteLine("Число\tКвадрат\tКуб");

        for (i = 1; i < 10; i++)
        {
            Console.WriteLine("{0}\t{1}\t{2}", i, i * i, i * i * i);
        }
    }
}

/*

Результат выполнения этой программы выглядит следующим образом.
Число   Квадрат     Куб
1       1           1
2       4           8
3       9           27
4       16          64
5       25          125
6       36          216
7       49          343
8       64          512
9       81          729

*/

#endregion

#region English

/*

Some Output Options

Up to this point, when data has been output using a WriteLine() statement, it has been
displayed using the default format. However, the .NET Framework defines a sophisticated
formatting mechanism that gives you detailed control over how data is displayed. Although
formatted I/O is covered in detail later in this book, it is useful to introduce some formatting
options at this time. Using these options, you will be able to specify the way values look
when output via a WriteLine() statement. Doing so enables you to produce more appealing
output. Keep in mind that the formatting mechanism supports many more features than
described here.

When outputting lists of data, you have been separating each part of the list with a plus
sign, as shown here:

Console.WriteLine("You ordered " + 2 + " items at $" + 3 + " each.");

While very convenient, outputting numeric information in this way does not give you any
control over how that information appears. For example, for a floating-point value, you
can’t control the number of decimal places displayed. Consider the following statement:

Console.WriteLine("Here is 10/3: " + 10.0/3.0);

It generates this output:

Here is 10/3: 3.33333333333333

Although this might be fine for some purposes, displaying so many decimal places could
be inappropriate for others. For example, in financial calculations, you will usually want to
display two decimal places.

To control how numeric data is formatted, you will need to use a second form of
WriteLine(), shown here, which allows you to embed formatting information:

WriteLine(“format string”, arg0, arg1, ... , argN);

In this version, the arguments to WriteLine() are separated by commas and not + signs. The
format string contains two items: regular, printing characters that are displayed as-is, and
format specifiers. Format specifiers take this general form:

{argnum, width: fmt}

Here, argnum specifies the number of the argument (starting from zero) to display. The
minimum width of the field is specified by width, and the format is specified by fmt. The
width and fmt are optional.

During execution, when a format specifier is encountered in the format string, the
corresponding argument, as specified by argnum, is substituted and displayed. Thus, the
position of a format specification within the format string determines where its matching
data will be displayed. Both width and fmt are optional. Therefore, in its simplest form, a
format specifier simply indicates which argument to display. For example, {0} indicates
arg0, {1} specifies arg1, and so on.

Let’s begin with a simple example. The statement

Console.WriteLine("February has {0} or {1} days.", 28, 29);

produces the following output:

February has 28 or 29 days.

As you can see, the value 28 is substituted for {0}, and 29 is substituted for {1}. Thus, the
format specifiers identify the location at which the subsequent arguments, in this case 28
and 29, are displayed within the string. Furthermore, notice that the additional values are
separated by commas, not + signs.

Here is a variation of the preceding statement that specifies minimum field widths:

Console.WriteLine("February has {0,10} or {1,5} days.", 28, 29);

It produces the following output:

February has         28 or    29 days.

As you can see, spaces have been added to fill out the unused portions of the fields.
Remember, a minimum field width is just that: the minimum width. Output can exceed
that width if needed.

Of course, the arguments associated with a format command need not be constants. For
example, this program displays a table of squares and cubes. It uses format commands to
output the values.

*/

// Use format commands.

//using System;

//class DisplayOptions
//{
//    static void Main()
//    {
//        int i;
//        Console.WriteLine("Value\tSquared\tCubed");
//        for (i = 1; i < 10; i++)
//            Console.WriteLine("{0}\t{1}\t{2}", i, i * i, i * i * i);
//    }
//}

/*

The output is shown here:

Value   Squared     Cubed
1       1           1
2       4           8
3       9           27
4       16          64
5       25          125
6       36          216
7       49          343
8       64          512
9       81          729

*/

#endregion