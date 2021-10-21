#region Russian

/*

Связь C# со средой .NET Framework

Несмотря на то что C# является самодостаточным языком программирования, у него
имеется особая взаимосвязь со средой выполнения .NET Framework. Наличие такой взаимосвязи
объясняется двумя причинами. Во-первых, C# первоначально предназначался
для создания кода, который должен выполняться в среде .NET Framework. И во-вторых,
используемые в C# библиотеки определены в среде .NET Framework. На практике это
означает, что C# и .NET Framework тесно связаны друг с другом, хотя теоретически C#
можно отделить от среды .NET Framework. В связи с этим очень важно иметь хотя бы
самое общее представление о среде .NET Framework и ее значении для С#.

О среде NET Framework

Назначение .NET Framework — служить средой для поддержки разработки и выполнения
сильно распределенных компонентных приложений. Она обеспечивает совместное
использование разных языков программирования, а также безопасность, переносимость
программ и общую модель программирования для платформы Windows.
Что же касается взаимосвязи с С#, то среда .NET Framework определяет два очень
важных элемента. Первым из них является общеязыковая среда выполнения (Common
Language Runtime — CLR). Это система, управляющая выполнением программ. Среди
прочих преимуществ — CLR как составная часть среды .NET Framework поддерживает
многоязыковое программирование, а также обеспечивает переносимость и безопасное
выполнение программ.

Вторым элементом среды .NET Framework является библиотека классов. Эта библиотека
предоставляет программе доступ к среде выполнения. Так, если требуется
выполнить операцию ввода-вывода, например вывести что-нибудь на экран, то для
этой цели используется библиотека классов .NET. Для тех, кто только начинает изучать
программирование, понятие класса может оказаться незнакомым. Оно подробно
разъясняется далее в этой книге, а пока достаточно сказать, что класс — это объектно-
ориентированная конструкция, помогающая организовать программы. Если программа
ограничивается средствами, определяемыми в библиотеке классов .NET, то
такая программа может выполняться везде, где поддерживается среда выполнения
.NET. А поскольку в C# библиотека классов .NET используется автоматически, то программы
на С# заведомо оказываются переносимыми во все имеющиеся среды .NET
Framework.

Принцип действия CLR

Среда CLR управляет выполнением кода .NET. Действует она по следующему принципу.
Результатом компиляции программы на C# является не исполняемый код, а
файл, содержащий особого рода псевдокод, называемый Microsoft Intermediate Language,
MSIL (промежуточный язык Microsoft). Псевдокод MSIL определяет набор переносимых
инструкций, не зависящих от конкретного процессора. По существу, MSIL определяет
переносимый язык ассемблера. Следует, однако, иметь в виду, что, несмотря на
кажущееся сходство псевдокода MSIL с байт-кодом Java, это все же разные понятия.

Назначение CLR — преобразовать промежуточный код в исполняемый код по
ходу выполнения программы. Следовательно, всякая программа, скомпилированная
в псевдокод MSIL, может быть выполнена в любой среде, где имеется реализация CLR.
Именно таким образом отчасти достигается переносимость в среде .NET Framework.

Псевдокод MSIL преобразуется в исполняемый код с помощью JIT-компилятора.
Сокращение JIT означает точно в срок и отражает оперативный характер данного компилятора.
Процесс преобразования кода происходит следующим образом. При выполнении
программы среда CLR активизирует JIT-компилятор, который преобразует
псевдокод MSIL в собственный код системы по требованию для каждой части программы.
Таким образом, программа на C# фактически выполняется как собственный
код, несмотря на то, что первоначально она скомпилирована в псевдокод MSIL. Это
означает, что такая программа выполняется так же быстро, как и в том случае, когда
она исходно скомпилирована в собственный код, но в то же время она приобретает все
преимущества переносимости псевдокода MSIL.

Помимо псевдокода MSIL, при компилировании программы на С# получаются
также метаданные, которые служат для описания данных, используемых в программе,
а также обеспечивают простое взаимодействие одного кода с другим. Метаданные содержатся
в том же файле, что и псевдокод MSIL.

Управляемый и неуправляемый код

Как правило, при написании программы на C# формируется так называемый
управляемый код. Как пояснялось выше, такой код выполняется под управлением среды
CLR, и поэтому на него накладываются определенные ограничения, хотя это и дает ряд
преимуществ. Ограничения накладываются и удовлетворятся довольно просто: 
компилятор должен сформировать файл MSIL, предназначенный для выполнения в среде
CLR, используя при этом библиотеку классов .NET, — и то и другое обеспечивается
средствами С#. Ко многим преимуществам управляемого кода относятся, в частности,
современные способы управления памятью, возможность программирования на разных
языках, повышение безопасности, поддержка управления версиями и четкая организация
взаимодействия программных компонентов.

В отличие от управляемого кода, неуправляемый код не выполняется в среде CLR.
Следовательно, до появления среды .NET Framework во всех программах для Windows
применялся неуправляемый код. Впрочем, управляемый и неуправляемый коды могут
взаимодействовать друг с другом, а значит, формирование управляемого кода в С#
совсем не означает, что на его возможность взаимодействия с уже существующими
программами накладываются какие-то ограничения.

Общеязыковая спецификация

Несмотря на все преимущества, которые среда CLR дает управляемому коду,
для максимального удобства его использования вместе с программами, написанными
на других языках, он должен подчинятся общеязыковой спецификации (Common
Language Specification — CLS), которая определяет ряд общих свойств для разных
.NET-совместимых языков. Соответствие CLS особенно важно при создании программных
компонентов, предназначенных для применения в других языках. В CLS в качестве
подмножества входит общая система типов (Common Type System — CTS), в которой
определяются правила, касающиеся типов данных. И разумеется, в C# поддерживается
как CLS, так и CTS.

*/

#endregion

#region English

/*

How C# Relates to the .NET Framework

Although C# is a computer language that can be studied on its own, it has a special
relationship to its runtime environment, the .NET Framework. The reason for this is twofold.
First, C# was initially designed by Microsoft to create code for the .NET Framework. Second,
the libraries used by C# are the ones defined by the .NET Framework. Thus, even though it
is theoretically possible to separate C# the language from the .NET environment, the two are
closely linked. Because of this, it is important to have a general understanding of the .NET
Framework and why it is important to C#.

What Is the .NET Framework?

The .NET Framework defines an environment that supports the development and execution
of highly distributed, component-based applications. It enables differing computer languages
to work together and provides for security, program portability, and a common programming
model for the Windows platform. As it relates to C#, the .NET Framework defines two very
important entities. The first is the Common Language Runtime (CLR). This is the system that
manages the execution of your program. Along with other benefits, the Common Language
Runtime is the part of the .NET Framework that enables programs to be portable, supports
mixed-language programming, and provides for secure execution.

The second entity is the .NET class library. This library gives your program access to the
runtime environment. For example, if you want to perform I/O, such as displaying something
on the screen, you will use the .NET class library to do it. If you are new to programming,
then the term class may be new. Although it is explained in detail later in this book, for now
a brief definition will suffice: a class is an object-oriented construct that helps organize
programs. As long as your program restricts itself to the features defined by the .NET class
library, your programs can run anywhere that the .NET runtime system is supported. Since
C# automatically uses the .NET Framework class library, C# programs are automatically
portable to all .NET environments.

How the Common Language Runtime Works

The Common Language Runtime manages the execution of .NET code. Here is how it
works: When you compile a C# program, the output of the compiler is not executable code.
Instead, it is a file that contains a special type of pseudocode called Microsoft Intermediate
Language (MSIL). MSIL defines a set of portable instructions that are independent of any
specific CPU. In essence, MSIL defines a portable assembly language. One other point:
although MSIL is similar in concept to Java’s bytecode, the two are not the same.

It is the job of the CLR to translate the intermediate code into executable code when a
program is run. Thus, any program compiled to MSIL can be run in any environment for
which the CLR is implemented. This is part of how the .NET Framework achieves portability.

Microsoft Intermediate Language is turned into executable code using a JIT compiler.
“JIT” stands for “Just-In-Time.” The process works like this: When a .NET program is
executed, the CLR activates the JIT compiler. The JIT compiler converts MSIL into native
code on demand as each part of your program is needed. Thus, your C# program actually
executes as native code even though it is initially compiled into MSIL. This means that your
program runs nearly as fast as it would if it had been compiled to native code in the first
place, but it gains the portability benefits of MSIL. Also, during compilation, code
verification takes place to ensure type safety (unless a security policy has been established
that avoids this step).

In addition to MSIL, one other thing is output when you compile a C# program:
metadata. Metadata describes the data used by your program and enables your code to
interact easily with other code. The metadata is contained in the same file as the MSIL.

Managed vs. Unmanaged Code

In general, when you write a C# program, you are creating what is called managed code.
Managed code is executed under the control of the Common Language Runtime, as just
described. Because it is running under the control of the CLR, managed code is subject to
certain constraints—and derives several benefits. The constraints are easily described and
met: the compiler must produce an MSIL file targeted for the CLR (which C# does) and use
the .NET class library (which C# does). The benefits of managed code are many, including
modern memory management, the ability to mix languages, better security, support for
version control, and a clean way for software components to interact.

The opposite of managed code is unmanaged code. Unmanaged code does not execute
under the Common Language Runtime. Thus, Windows programs prior to the creation of
the .NET Framework use unmanaged code. It is possible for managed code and unmanaged
code to work together, so the fact that C# generates managed code does not restrict its ability
to operate in conjunction with preexisting programs.

The Common Language Specification

Although all managed code gains the benefits provided by the CLR, if your code will be
used by other programs written in different languages, then, for maximum usability, it
should adhere to the Common Language Specification (CLS). The CLS describes a set of
features that different .NET-compatible languages have in common. CLS compliance is
especially important when creating software components that will be used by other
languages. The CLS includes a subset of the Common Type System (CTS). The CTS defines
the rules concerning data types. Of course, C# supports both the CLS and the CTS.

*/

#endregion