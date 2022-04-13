#region Russian

/*

Идентификаторы

В C# идентификатор представляет собой имя, присваиваемое методу, переменной
или любому другому определяемому пользователем элементу программы. Идентификаторы
могут состоять из одного или нескольких символов. Имена переменных могут
начинаться с любой буквы алфавита или знака подчеркивания. Далее может следовать
буква, цифра или знак подчеркивания. С помощью знака подчеркивания можно повысить
удобочитаемость имени переменной, как, например, line_count. Но идентификаторы,
содержащие два знака подчеркивания подряд, например, max__value,
зарезервированы для применения в компиляторе. Прописные и строчные буквы в C#
различаются. Так, например myvar и MyVar — это разные имена переменных. Ниже
приведены некоторые примеры допустимых идентификаторов.

Test    x       У2      MaxLoad
up      _top    my_var  sample23

Помните, что идентификатор не может начинаться с цифры. Например, 12х — недействительный
идентификатор. Хорошая практика программирования требует выбирать
идентификаторы, отражающие назначение или применение именуемых элементов.

Несмотря на то что зарезервированные ключевые слова нельзя использовать в качестве
идентификаторов, в C# разрешается применять ключевое слово с предшествующим
знаком @ в качестве допустимого идентификатора. Например, @for — действительный
идентификатор. В этом случае в качестве идентификатора фактически служит
ключевое слово for, а знак @ просто игнорируется. Ниже приведен пример программы,
демонстрирующей применение идентификатора со знаком @.

*/

// Продемонстрировать применение идентификатора со знаком @.

using System;

class IdTest
{
    static void Main()
    {
        int @if; // применение ключевого слова if в качестве идентификатора

        for (@if = 0; @if < 10; @if++)
        {
            Console.WriteLine("@if равно " + @if);
        }
    }
}

/*

Приведенный ниже результат выполнения этой программы подтверждает, что @if
правильно интерпретируется в качестве идентификатора.

@if равно 0
@if равно 1
@if равно 2
@if равно 3
@if равно 4
@if равно 5
@if равно 6
@if равно 7
@if равно 8
@if равно 9

Откровенно говоря, применять ключевые слова со знаком @ в качестве идентификаторов
не рекомендуется, кроме особых случаев. Помимо того, знак @ может предшествовать
любому идентификатору, но такая практика программирования считается плохой.

Библиотека классов среды .NET Framework

В примерах программ, представленных в этой главе, применялись два встроенных
метода: WriteLine() и Write(). Как упоминалось выше, эти методы являются
членами класса Console, относящегося к пространству имен System, которое определяется
в библиотеке классов для среды .NET Framework. Ранее в этой главе пояснялось,
что среда C# опирается на библиотеку классов, предназначенную для среды
.NET Framework, чтобы поддерживать операции ввода-вывода, обработку строк, работу
в сети и графические пользовательские интерфейсы. Поэтому, вообще говоря, C#
представляет собой определенное сочетание самого языка C# и стандартных классов
.NET. Как будет показано далее, библиотека классов обеспечивает функциональные
возможности, являющиеся неотъемлемой частью любой программы на С#. Для того
чтобы научиться программировать на С#, нужно знать не только сам язык, но и уметь
пользоваться стандартными классами. Различные элементы библиотеки классов для
среды .NET Framework рассматриваются в части I этой книги, а в части II — сама
библиотека по отдельным ее составляющим.

*/

#endregion

#region English

/*

Identifiers

In C#, an identifier is a name assigned to a method, a variable, or any other user-defined
item. Identifiers can be one or more characters long. Identifiers may start with any letter
of the alphabet or an underscore. Next may be a letter, a digit, or an underscore. The
underscore can be used to enhance the readability of a variable name, as in line_count.
However, identifers containing two consecutive underscores, such as max_ _value, are
reserved for use by the compiler. Uppercase and lowercase are different; that is, to C#,
myvar and MyVar are separate names. Here are some examples of acceptable identifiers:

Test    x       У2      MaxLoad
up      _top    my_var  sample23

Remember, you can’t start an identifier with a digit. Thus, 12x is invalid, for example. Good
programming practice dictates that you choose identifiers that reflect the meaning or usage
of the items being named.

Although you cannot use any of the reserved C# keywords as identifiers, C# does allow
you to precede a keyword with an @, allowing it to be a legal identifier. For example, @for
is a valid identifier. In this case, the identifier is actually for and the @ is ignored. Here is a
program that illustrates the use of an @ identifier:

*/

// Demonstrate an @ identifier.

//using System;

//class IdTest
//{
//    static void Main()
//    {
//        int @if; // use if as an identifier

//        for (@if = 0; @if < 10; @if++)
//            Console.WriteLine("@if is " + @if);
//    }
//}

/*

The output shown here proves the @if is properly interpreted as an identifier:

@if is 0
@if is 1
@if is 2
@if is 3
@if is 4
@if is 5
@if is 6
@if is 7
@if is 8
@if is 9

Frankly, using @-qualified keywords for identifiers is not recommended, except for
special purposes. Also, the @ can precede any identifier, but this is considered bad practice.

The .NET Framework Class Library

The sample programs shown in this chapter make use of two built-in methods: WriteLine()
andWrite(). As mentioned, these methods are members of the Console class, which is part
of the System namespace, which is defined by the .NET Framework’s class library. As
explained earlier in this chapter, the C# environment relies on the .NET Framework class
library to provide support for such things as I/O, string handling, networking, and GUIs.
Thus, the C# environment as a totality is a combination of the C# language itself, plus the
.NET standard classes. As you will see, the class library provides much of the functionality
that is part of any C# program. Indeed, part of becoming a C# programmer is learning to
use these standard classes. Throughout Part I, various elements of the .NET library classes
and methods are described. Part II examines portions of the .NET library in detail.

*/

#endregion