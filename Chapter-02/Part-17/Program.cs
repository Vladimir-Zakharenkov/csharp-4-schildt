#region Russian

/*

Точка с запятой и оформление исходного текста программы

В C# точка с запятой обозначает конец оператора. Это означает, что каждый оператор
в отдельности должен оканчиваться точкой с запятой.

Как вы уже знаете, кодовый блок представляет собой набор логически связанных
операторов, заключенных в фигурные скобки. Блок не оканчивается точкой с запятой,
поскольку он состоит из группы операторов. Вместо этого окончание кодового блока
обозначается закрывающей фигурной скобкой.

В С# конец строки не означает конец оператора — о его окончании свидетельствует
только точка с запятой. Именно поэтому оператор можно поместить в любой части
строки. Например, на языке C# строки кода

х = у;
у = у + 1;
Console.WriteLine(х + " " + у);

означают то же самое, что и строка кода

х = у; у = у + 1; Consо1е.WriteLine(х + " " + у);

Более того, составные элементы оператора можно располагать в отдельных строках.
Например, следующий фрагмент кода считается в C# вполне допустимым.

Console.WriteLine("Это длинная строка вывода" +
            х + у + z +
            "дополнительный вывод");

Такое разбиение длинных строк нередко применяется для того, чтобы сделать исходный
текст программы более удобным для чтения. Оно помогает также исключить
заворачивание слишком длинных строк.

Возможно, вы уже обратили внимание на то, что в предыдущих примерах программ
некоторые операторы были набраны с отступом. В C# допускается свободная
форма записи. Это означает, что взаимное расположение операторов в строке не
имеет особого значения. Но с годами в программировании сложился общепринятый
стиль оформления исходного текста программ с отступами, что существенно облегчает
чтение этого текста. Именно этому стилю следуют примеры программ в данной книге,
что рекомендуется делать и вам. В соответствии с этим стилем следует делать отступ
(в виде нескольких пробелов) после каждой открывающей фигурной скобки и возвращаться
назад после закрывающей фигурной скобки. А для некоторых операторов даже
требуется дополнительный отступ, но об этом речь пойдет далее.

*/

#endregion

#region English

/*

Semicolons, Positioning, and Indentation

In C#, the semicolon signals the end of a statement. That is, each individual statement must
end with a semicolon.

As you know, a block is a set of logically connected statements that are surrounded by
opening and closing braces. A block is not terminated with a semicolon. Since a block is a
group of statements, it makes sense that a block is not terminated by a semicolon; instead,
the end of the block is indicated by the closing brace.

C# does not recognize the end of the line as the end of a statement—only a semicolon
terminates a statement. For this reason, it does not matter where on a line you put a
statement. For example, to C#,

x = y;
y = y + 1;
Console.WriteLine(x + " " + y);

is the same as

x = y; y = y + 1; Console.WriteLine(x + " " + y);

Furthermore, the individual elements of a statement can also be put on separate lines. For
example, the following is perfectly acceptable:

Console.WriteLine("This is a long line of output" +
        x + y + z +
        "more output");

Breaking long lines in this fashion is often used to make programs more readable. It can also
help prevent excessively long lines from wrapping.

You may have noticed in the previous examples that certain statements were indented.
C# is a free-form language, meaning that it does not matter where you place statements
relative to each other on a line. However, over the years, a common and accepted
indentation style has developed that allows for very readable programs. This book
follows that style, and it is recommended that you do so as well. Using this style, you
indent one level after each opening brace and move back out one level after each closing
brace. There are certain statements that encourage some additional indenting; these will
be covered later.

*/

#endregion