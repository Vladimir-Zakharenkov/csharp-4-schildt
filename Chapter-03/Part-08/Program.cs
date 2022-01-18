#region Russian

/*

Символы

В C# символы представлены не 8-разрядным кодом, как во многих других языках
программирования, например C++, а 16-разрядным кодом, который называется уникодом
(Unicode). В уникоде набор символов представлен настолько широко, что он охватывает
символы практически из всех естественных языков на свете. Если для многих
естественных языков, в том числе английского, французского и немецкого, характерны
относительно небольшие алфавиты, то в ряде других языков, например китайском,
употребляются довольно обширные наборы символов, которые нельзя представить
8-разрядным кодом. Для преодоления этого ограничения в C# определен тип char,
представляющий 16-разрядные значения без знака в пределах от 0 до 65 535. При этом
стандартный набор символов в 8-разрядном коде ASCII является подмножеством уникода
в пределах от 0 до 127. Следовательно, символы в коде ASCII по-прежнему остаются
действительными в С#.

Для того чтобы присвоить значение символьной переменной, достаточно заключить
это значение (т.е. символ) в одинарные кавычки. Так, в приведенном ниже фрагменте
кода переменной ch присваивается символ X.

char ch;
ch = 'X';

Значение типа char можно вывести на экран с помощью метода WriteLine().
Например, в следующей строке кода на экран выводится значение переменной ch.

Console.WriteLine("Значение ch равно: " + ch);

Несмотря на то что тип char определен в C# как целочисленный, его не следует
путать со всеми остальными целочисленными типами. Дело в том, что в C# отсутствует
автоматическое преобразование символьных значений в целочисленные и обратно.
Например, следующий фрагмент кода содержит ошибку.

char ch;
ch = 88; // ошибка, не выйдет

Ошибочность приведенного выше фрагмента кода объясняется тем, что 88 — это
целое значение, которое не преобразуется автоматически в символьное. При попытке
скомпилировать данный фрагмент кода будет выдано соответствующее сообщение об
ошибке. Для того чтобы операция присваивания целого значения символьной переменной
оказалась допустимой, необходимо осуществить приведение типа, о котором
речь пойдет далее в этой главе.

*/

#endregion

#region English

/*

Characters

In C#, characters are not 8-bit quantities like they are in many other computer languages,
such as C++. Instead, C# uses a 16-bit character type called Unicode. Unicode defines a
character set that is large enough to represent all of the characters found in all human
languages. Although many languages, such as English, French, and German, use relatively
small alphabets, some languages, such as Chinese, use very large character sets that cannot
be represented using just 8 bits. To address this situation, in C#, char is an unsigned 16-bit
type having a range of 0 to 65,535. The standard 8-bit ASCII character set is a subset of
Unicode and ranges from 0 to 127. Thus, the ASCII characters are still valid C# characters.

A character variable can be assigned a value by enclosing the character inside single
quotes. For example, this assigns X to the variable ch:

char ch;
ch = 'X';

You can output a char value using a WriteLine( ) statement. For example, this line outputs
the value in ch:

Console.WriteLine("This is ch: " + ch);

Although char is defined by C# as an integer type, it cannot be freely mixed with integers
in all cases. This is because there are no automatic type conversions from integer to char.
For example, the following fragment is invalid:

char ch;
ch = 88; // error, won't work

The reason the preceding code will not work is that 10 is an integer value, and it won’t
automatically convert to a char. If you attempt to compile this code, you will see an error
message. To make the assignment legal, you would need to employ a cast, which is
described later in this chapter.

*/

#endregion