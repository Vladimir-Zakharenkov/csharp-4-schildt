#region Russian

/*

Построчный анализ первого примера программы

Несмотря на то что пример программы Example.cs довольно краток, в нем демонстрируется
ряд ключевых средств, типичных для всех программ на С#. Проанализируем
более подробно каждую строку этой программы, начиная с ее имени.

В отличие от ряда других языков программирования, и в особенности Java, где имя
файла программы имеет большое значение, имя программы на C# может быть произвольным.
Ранее вам было предложено присвоить программе из первого примера
имя Example.cs, чтобы успешно скомпилировать и выполнить ее, но в C# файл с исходным
текстом этой программы можно было бы назвать как угодно. Например, его
можно было назвать Sample.cs, Test.cs или даже X.cs.

В файлах с исходным текстом программ на C# условно принято расширение .cs,
и это условие вы должны соблюдать. Кроме того, многие программисты называют
файлы с исходным текстом своих программ по имени основного класса, определенного
в программе. Именно поэтому в рассматриваемом здесь примере было выбрано имя
файла Example.cs. Но поскольку имена программ на C# могут быть произвольными,
то они не указываются в большинстве примеров программ, приведенных в настоящей
книге. Поэтому вы вольны сами выбирать для них имена.
Итак, анализируемая программа начинается с таких строк.

/*
Это простая программа на C#.
Назовем ее Example.cs.
*/

/*

Эти строки образуют комментарий. Как и в большинстве других языков программирования,
в C# допускается вводить комментарии в файл с исходным текстом программы.
Содержимое комментария игнорируется компилятором. Но, с другой стороны,
в комментарии дается краткое описание или пояснение работы программы для
всех, кто читает ее исходный текст. В данном случае в комментарии дается описание
программы и напоминание о том, что ее исходный файл называется Example.cs.
Разумеется, в комментариях к реальным приложениям обычно поясняется работа отдельных
частей программы или же функции конкретных средств.

В C# поддерживаются три стиля комментариев. Один из них приводится в самом
начале программы и называется многострочным комментарием. Этот стиль комментария
должен начинаться символами /* и оканчиваться символами */ /*.  Все, что находится
между этими символами, игнорируется компилятором. Как следует из его
названия, многострочный комментарий может состоять из нескольких строк.

Рассмотрим следующую строку программы.

using System;

Эта строка означает, что в программе используется пространство имен System.
В C# пространство имен определяет область объявлений. Подробнее о пространстве
имен речь пойдет далее в этой книге, а до тех пор поясним вкратце его назначение.
Благодаря пространству имен одно множество имен отделяется от других. По существу,
имена, объявляемые в одном пространстве имен, не вступают в конфликт с именами,
объявляемыми в другом пространстве имен. В анализируемой программе используется
пространство имен System, которое зарезервировано для элементов, связанных
с библиотекой классов среды .NET Framework, применяемой в С#. Ключевое
слово using просто констатирует тот факт, что в программе используются имена в заданном
пространстве имен. (Попутно обратим внимание на весьма любопытную возможность
создавать собственные пространства имен, что особенно полезно для работы,
над крупными проектами.)

Перейдем к следующей строке программы.

class Example
{
    В этой строке ключевое слово class служит для объявления вновь определяемого
класса. Как упоминалось выше, класс является основной единицей инкапсуляции
в С#, a Example — это имя класса. Определение класса начинается с открывающей
фигурной скобки({) и оканчивается закрывающей фигурной скобкой(}). Элементы,
заключенные в эти фигурные скобки, являются членами класса.Не вдаваясь пока что
в подробности, достаточно сказать, что в C# большая часть действий, выполняемых
в программе, происходит именно в классе.

Следующая строка программы содержит однострочный комментарий.

// Любая программа на C# начинается с вызова метода Main().

Это второй стиль комментариев, поддерживаемых в С#. Однострочный комментарий
начинается и оканчивается символами //. Несмотря на различие стилей комментариев,
программисты нередко пользуются многострочными комментариями для
более длинных примечаний и однострочными комментариями для коротких, построчных
примечаний к программе. (Третий стиль комментариев, поддерживаемых в С#,
применяется при создании документации и описывается в приложении А.)

Перейдем к анализу следующей строки программы.

static void Main() {

Эта строка начинается с метода Main(). Как упоминалось выше, в C# подпрограмма
называется методом. И, как поясняется в предшествующем комментарии, именно
с этой строки начинается выполнение программы. Выполнение всех приложений C#
начинается с вызова метода Main(). Разбирать полностью значение каждого элемента
данной строки пока что не имеет смысла, потому что для этого нужно знать ряд других
средств С#. Но поскольку данная строка используется во многих примерах программ,
приведенных в этой книге, то проанализируем ее вкратце.

Данная строка начинается с ключевого слова static. Метод, определяемый ключевым
словом static, может вызываться до создания объекта его класса. Необходимость
в этом объясняется тем, что метод Main() вызывается при запуске программы. Ключевое
слово void указывает на то, что метод Main() не возвращает значение. В дальнейшем
вы узнаете, что методы могут также возвращать значения. Пустые круглые скобки
после имени метода Main означают, что этому методу не передается никакой информации.
Теоретически методу Main() можно передать информацию, но в данном
примере этого не делается. И последним элементом анализируемой строки является
символ {, обозначающий начало тела метода Main(). Весь код, составляющий тело
метода, находится между открывающими и закрывающими фигурными скобками.

Рассмотрим следующую строку программы. Обратите внимание на то, что она находится
внутри метода Main().

Console.WriteLine("Простая программа на С#.");

В этой строке осуществляется вывод на экран текстовой строки "Простая программа
на C#. Сам вывод выполняется встроенным методом WriteLine(). В данном
примере метод WriteLine() выводит на экран строку, которая ему передается.
Информация, передаваемая методу, называется аргументом. Помимо текстовых строк,
метод WriteLine() позволяет выводить на экран другие виды информации. Анализируемая
строка начинается с Console — имени предопределенного класса, поддерживающего
ввод-вывод на консоль. Сочетание обозначений Console и WriteLine() указывает
компилятору на то, что метод WriteLine() является членом класса Console.
Применение в C# объекта для определения вывода на консоль служит еще одним свидетельством
объектно-ориентированного характера этого языка программирования.
Обратите внимание на то, что оператор, содержащий вызов метода WriteLine(),
оканчивается точкой с запятой, как, впрочем, и рассматривавшаяся ранее директива
using System. Как правило, операторы в C# оканчиваются точкой с запятой.
Исключением из этого правила служат блоки, которые начинаются символом {
и оканчиваются символом }. Именно поэтому строки программы с этими символами
не оканчиваются точкой с запятой. Блоки обеспечивают механизм группирования операторов
и рассматриваются далее в этой главе.

Первый символ } в анализируемой программе завершает метод Main(), а второй
— определение класса Example.

И наконец, в C# различаются прописные и строчные буквы. Несоблюдение этого
правила может привести к серьезным осложнениям. Так, если вы неумышленно наберете
main вместо Main или же writeline вместо WriteLine, анализируемая программа
окажется ошибочной. Более того, компилятор C# не предоставит возможность
выполнить классы, которые не содержат метод Main(), хотя и скомпилирует их. Поэтому
если вы неверно наберете имя метода Main, то получите от компилятора сообщение
об ошибке, уведомляющее о том, что в исполняемом файле Example.ехе не
определена точка входа.

*/

#endregion

#region English

/*

The First Sample Program, Line by Line

Although Example.cs is quite short, it includes several key features that are common to all
C# programs. Let’s closely examine each part of the program, beginning with its name.

The name of a C# program is arbitrary. Unlike some computer languages (most notably,
Java) in which the name of a program file is very important, this is not the case for C#. You
were told to call the sample program Example.cs so that the instructions for compiling and
running the program would apply, but as far as C# is concerned, you could have called the
file by another name. For example, the preceding sample program could have been called
Sample.cs, Test.cs, or even X.cs.

By convention, C# programs use the .cs file extension, and this is a convention that you
should follow. Also, many programmers call a file by the name of the principal class defined
within the file. This is why the filename Example.cs was chosen. Since the names of C#
programs are arbitrary, names won’t be specified for most of the sample programs in this
book. Just use names of your own choosing.

The program begins with the following lines:

/*
This is a simple C# program.
Call this program Example.cs.
*/

/*

This is a comment. Like most other programming languages, C# lets you enter a remark into
a program’s source file. The contents of a comment are ignored by the compiler. Instead, a
comment describes or explains the operation of the program to anyone who is reading its
source code. In this case, the comment describes the program and reminds you to call the
source file Example.cs. Of course, in real applications, comments generally explain how
some part of the program works or what a specific feature does.

C# supports three styles of comments. The one shown at the top of the program is called
a multiline comment. This type of comment must begin with /* and end with */ /*. Anything
between these two comment symbols is ignored by the compiler. As the name suggests, a
multiline comment can be several lines long.

The next line in the program is

using System;

This line indicates that the program is using the System namespace. In C#, a namespace
defines a declarative region. Although we will examine namespaces in detail later in this
book, a brief description is useful now. Through the use of namespaces, it is possible to keep
one set of names separate from another. In essence, names declared in one namespace will
not conflict with names declared in a different namespace. The namespace used by the
program is System, which is the namespace reserved for items associated with the .NET
Framework class library, which is the library used by C#. The using keyword simply states
that the program is using the names in the given namespace. (As a point of interest, it is also
possible to create your own namespaces, which is especially helpful for large projects.)

The next line of code in the program is shown here:

class Example {

This line uses the keyword class to declare that a new class is being defined. As mentioned,
the class is C#’s basic unit of encapsulation. Example is the name of the class. The class
definition begins with the opening curly brace ({) and ends with the closing curly brace (}).
The elements between the two braces are members of the class. For the moment, don’t
worry too much about the details of a class except to note that in C#, most program activity
occurs within one.

The next line in the program is the single-line comment, shown here:

// A C# program begins with a call to Main().

This is the second type of comment supported by C#. A single-line comment begins with
a // and ends at the end of the line. Although styles vary, it is not uncommon for programmers
to use multiline comments for longer remarks and single-line comments for brief, line-byline
descriptions. (The third type of comment supported by C# aids in the creation of
documentation and is described in the Appendix.)

The next line of code is shown here:

static void Main() {

This line begins the Main() method. As mentioned earlier, in C#, a subroutine is called a
method. As the comment preceding it suggests, this is the line at which the program will
begin executing. All C# applications begin execution by calling Main(). The complete
meaning of each part of this line cannot be given now, since it involves a detailed
understanding of several other C# features. However, since many of the examples in
this book will use this line of code, we will take a brief look at it here.

The line begins with the keyword static. A method that is modified by static can be
called before an object of its class has been created. This is necessary because Main() is
called at program startup. The keyword void indicates that Main() does not return a value.
As you will see, methods can also return values. The empty parentheses that follow Main
indicate that no information is passed to Main(). Although it is possible to pass information
into Main(), none is passed in this example. The last character on the line is the {. This
signals the start of Main()’s body. All of the code that comprises a method will occur
between the method’s opening curly brace and its closing curly brace.

The next line of code is shown here. Notice that it occurs inside Main().

Console.WriteLine("A simple C# program.");

This line outputs the string “A simple C# program.” followed by a new line on the screen.
Output is actually accomplished by the built-in method WriteLine(). In this case, WriteLine()
displays the string that is passed to it. Information that is passed to a method is called an
argument. In addition to strings, WriteLine() can be used to display other types of information.
The line begins with Console, which is the name of a predefined class that supports console
I/O. By connecting Console with WriteLine(), you are telling the compiler that WriteLine()
is a member of the Console class. The fact that C# uses an object to define console output is
further evidence of its object-oriented nature.

Notice that the WriteLine() statement ends with a semicolon, as does the using System
statement earlier in the program. In general, statements in C# end with a semicolon. The
exception to this rule are blocks, which begin with a { and end with a }. This is why those
lines in the program don’t end with a semicolon. Blocks provide a mechanism for grouping
statements and are discussed later in this chapter.

The first } in the program ends Main(), and the last } ends the Example class definition.

One last point: C# is case-sensitive. Forgetting this can cause serious problems. For
example, if you accidentally type main instead of Main, or writeline instead of WriteLine,
the preceding program will be incorrect. Furthermore, although the C# compiler will compile
classes that do not contain a Main() method, it has no way to execute them. So, had you
mistyped Main, you would see an error message that states that Example.exe does not have
an entry point defined.

*/

#endregion