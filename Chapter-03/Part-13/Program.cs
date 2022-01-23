#region Russian

/*

Шестнадцатеричные литералы

Вам, вероятно, известно, что в программировании иногда оказывается проще пользоваться
системой счисления по основанию 16, чем по основанию 10. Система счисления
по основанию 16 называется шестнадцатеричной. В ней используются числа от 0 до 9,
а также буквы от А до F, которыми обозначаются десятичные числа 10, 11, 12, 13,
14 и 15. Например, десятичному числу 16 соответствует шестнадцатеричное число 10.
Вследствие того что шестнадцатеричные числа применяются в программировании довольно
часто, в C# разрешается указывать целочисленные литералы в шестнадцатеричном
формате. Шестнадцатеричные литералы должны начинаться с символов 0х,
т.е. нуля и последующей латинской буквы "икс". Ниже приведены некоторые примеры
шестнадцатеричных литералов.

count = 0xFF; // 255 в десятичной системе
incr = 0x1а; // 26 в десятичной системе

Управляющие последовательности символов

Большинство печатаемых символов достаточно заключить в одинарные кавычки,
но набор в текстовом редакторе некоторых символов, например возврата каретки, вызывает
особые трудности. Кроме того, ряд других символов, в том числе одинарные
и двойные кавычки, имеют специальное назначение в С#, поэтому их нельзя использовать 
непосредственно. По этим причинам в C# предусмотрены специальные управляющие
последовательности символов, иногда еще называемые константами с обратной
косой чертой (табл. 3.2). Такие последовательности применяются вместо тех символов,
которых они представляют.

Таблица 3.2. Управляющие последовательности символов

Управляющая последовательность  Описание
\a                              Звуковой сигнал (звонок)
\b                              Возврат на одну позицию
\f                              Перевод страницы (переход на новую страницу)
\n                              Новая строка (перевод строки)
\r                              Возврат каретки
\t                              Горизонтальная табуляция
\v                              Вертикальная табуляция
\0                              Пустой символ
\'                              Одинарная кавычка
\"                              Двойная кавычка
\\                              Обратная косая черта

Например, в следующей строке кода переменной ch присваивается символ табуляции.

ch = '\t';

А в приведенном ниже примере кода переменной ch присваивается символ одинарной
кавычки.

ch = '\'';

*/

#endregion

#region English

/*

Hexadecimal Literals

As you probably know, in programming it is sometimes easier to use a number system based
on 16 instead of 10. The base 16 number system is called hexadecimal and uses the digits 0
through 9 plus the letters A through F, which stand for 10, 11, 12, 13, 14, and 15. For example,
the hexadecimal number 10 is 16 in decimal. Because of the frequency with which hexadecimal
numbers are used, C# allows you to specify integer literals in hexadecimal format. A
hexadecimal literal must begin with 0x (a 0 followed by an x). Here are some examples:

count = 0xFF; // 255 in decimal
incr = 0x1a; // 26 in decimal

Character Escape Sequences

Enclosing character literals in single quotes works for most printing characters, but a few
characters, such as the carriage return, pose a special problem when a text editor is used.
In addition, certain other characters, such as the single and double quotes, have special
meaning in C#, so you cannot use them directly. For these reasons, C# provides special
escape sequences, sometimes referred to as backslash character constants, shown in Table 3-2.
These sequences are used in place of the characters they represent.

For example, this assigns ch the tab character:

ch = '\t';

The next example assigns a single quote to ch:

ch = '\'';

Escape Sequence Description
\a              Alert (bell)
\b              Backspace
\f              Form feed
\n              New line (linefeed)
\r              Carriage return
\t              Horizontal tab
\v              Vertical tab
\0              Null
\'              Single quote
\"              Double quote
\\              Backslash

TABLE 3-2   Character Escape Sequences

*/

#endregion