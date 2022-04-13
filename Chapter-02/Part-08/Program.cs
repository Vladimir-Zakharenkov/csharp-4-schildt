#region Russian

/*

Обработка синтаксических ошибок

Если вы только начинаете изучать программирование, то вам следует научиться
правильно истолковывать (и реагировать на) ошибки, которые могут появиться при
попытке скомпилировать программу. Большинство ошибок компиляции возникает
в результате опечаток при наборе исходного текста программы. Все программисты
рано или поздно обнаруживают, что при наборе исходного текста программы очень
легко сделать опечатку. Правда, если вы наберете что-нибудь неправильно, компилятор
выдаст соответствующее сообщение о синтаксической ошибке при попытке скомпилировать
вашу программу. В таком сообщении обычно указывается номер строки исходного
текста программы, где была обнаружена ошибка, а также кратко описывается
характер ошибки.

Несмотря на всю полезность сообщений о синтаксических ошибках, выдаваемых
компилятором, они иногда вводят в заблуждение. Ведь компилятор C# пытается извлечь
какой-то смысл из исходного текста, как бы он ни был набран. Именно по этой
причине ошибка, о которой сообщает компилятор, не всегда отражает настоящую
причину возникшего затруднения. Неумышленный пропуск открывающей фигурной
скобки после метода Main() в рассмотренном выше примере программы приводит
к появлению приведенной ниже последовательности сообщений об ошибках при
компиляции данной программы компилятором командной строки csc. (Аналогичные
ошибки появляются при компиляции в интегрированной среде разработки Visual
Studio.)

EX1.CS(12, 21) : ошибка CS1002: ; ожидалось
ЕХ1.CS(13, 22) : ошибка CS1519: Недопустимая лексема '(' в
объявлении члена класса, структуры или интерфейса
EX1.CS(15, 1) : ошибка CS1022: Требуется определение типа
или пространства имен либо признак конца файла

Очевидно, что первое сообщение об ошибке нельзя считать верным, поскольку пропущена
не точка с запятой, а фигурная скобка. Два других сообщения об ошибках вносят
такую же путаницу.

Из всего изложенного выше следует, что если программа содержит синтаксическую
ошибку, то сообщения компилятора не следует понимать буквально, поскольку
они могут ввести в заблуждение. Для выявления истинной причины ошибки может
потребоваться критический пересмотр сообщения об ошибке. Кроме того, полезно
проанализировать несколько строк кода, предшествующих той строке, в которой обнаружена
сообщаемая ошибка. Иногда об ошибке сообщается лишь через несколько
строк после того места, где она действительно произошла.

*/

#endregion

#region English

/*

Handling Syntax Errors

If you are new to programming, it is important to learn how to interpret and respond to errors
that may occur when you try to compile a program. Most compilation errors are caused by
typing mistakes. As all programmers soon find out, accidentally typing something incorrectly
is quite easy. Fortunately, if you type something wrong, the compiler will report a syntax error
message when it tries to compile your program. This message gives you the line number at
which the error is found and a description of the error itself.

Although the syntax errors reported by the compiler are, obviously, helpful, they
sometimes can also be misleading. The C# compiler attempts to make sense out of your
source code no matter what you have written. For this reason, the error that is reported
may not always reflect the actual cause of the problem. In the preceding program, for
example, an accidental omission of the opening curly brace after the Main() method
generates the following sequence of errors when compiled by the csc command-line
compiler. (Similar errors are generated when compiling using the IDE.)

Example.CS(12,21): error CS1002: ; expected
Example.CS(13,22): error CS1519: Invalid token '(' in class, struct, or
interface member declaration
Example.CS(15,1): error CS1022: Type or namespace definition, or
end-of-file expected

Clearly, the first error message is completely wrong, because what is missing is not a
semicolon, but a curly brace. The second two messages are equally confusing.

The point of this discussion is that when your program contains a syntax error, don’t
necessarily take the compiler’s messages at face value. They may be misleading. You may need
to “second guess” an error message in order to find the problem. Also, look at the last few lines
of code immediately preceding the one in which the error was reported. Sometimes an error
will not be reported until several lines after the point at which the error really occurred.

*/

#endregion