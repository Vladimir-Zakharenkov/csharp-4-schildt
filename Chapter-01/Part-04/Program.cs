#region Russian

/*

Создание C#

Несмотря на то что в Java успешно решаются многие вопросы переносимости программ
в среде Интернета, его возможности все же ограничены. Ему, в частности, недостает
межъязыковой возможности взаимодействия, называемой также многоязыковым
программированием. Это возможность кода, написанного на одном языке, без труда 
взаимодействовать с кодом, написанным на другом языке. Межъязыковая возможность
взаимодействия требуется для построения крупных, распределенных программных
систем. Она желательна также для создания отдельных компонентов программ, поскольку
наиболее ценным компонентом считается тот, который может быть использован
в самых разных языках программирования и в самом большом числе операционных
сред.

Другой возможностью, отсутствующей в Java, является полная интеграция с платформой
Windows. Несмотря на то что программы на Java могут выполняться в среде
Windows, при условии, что установлена виртуальная машина Java, среды Java
и Windows не являются сильно связанными. А поскольку Windows является самой
распространенной операционной системой во всем мире, то отсутствие прямой поддержки
Windows является существенным недостатком Java.

Для удовлетворения этих и других потребностей программирования корпорация
Microsoft разработала в конце 1990-х годов язык C# как часть общей стратегии .NET.
Впервые он был выпущен в виде альфа-версии в середине 2000 года. Главным разработчиком
C# был Андерс Хейльсберг — один из ведущих в мире специалистов по языкам
программирования, который может похвалиться рядом заметных достижений
в данной области. Достаточно сказать, что в 1980-е годы он был автором очень удачной
и имевшей большое значение разработки — языка Turbo Pascal, изящная реализация
которого послужила образцом для создания всех последующих компиляторов.

Язык C# непосредственно связан с С, C++ и Java. И это не случайно. Ведь это три самых
широко распространенных и признанных во всем мире языка программирования.
Кроме того, на момент создания C# практически все профессиональные программисты
уже владели С, C++ или Java. Благодаря тому что C# построен на столь прочном и
понятном основании, перейти на этот язык из С, C++ или Java не представляло особого
труда. А поскольку и Хейльсбергу не нужно (да и нежелательно) было изобретать велосипед,
то он мог сосредоточиться непосредственно на усовершенствованиях и нововведениях
в С#.

Родственные связи C# и Java более сложные. Как пояснялось выше, Java также происходит
от С и C++ и обладает общим с ними синтаксисом и объектной моделью. Как
и Java, C# предназначен для получения переносимого кода, но C# не происходит непосредственно
от Java. Напротив, C# и Java — это близкие, но не кровные родственники,
имеющие общих предков, но во многом отличающиеся друг от друга. Впрочем, если
вы знаете Java, то многие понятия C# окажутся вам знакомыми. С другой стороны,
если вам в будущем придется изучать Java, то многие понятия, усвоенные в С#, могут
быть легко распространены и на Java.

В C# имеется немало новых средств, которые будут подробно рассмотрены на
страницах этой книги, но самое важное из них связано со встроенной поддержкой
программных компонентов. В действительности C# может считаться компонентноориентированным
языком программирования, поскольку в него внедрена встроенная
поддержка написания программных компонентов. Например, в состав C# входят
средства прямой поддержки таких составных частей программных компонентов, как
свойства, методы и события. Но самой важной компонентно-ориентированной особенностью
этого языка, вероятно, является возможность работы в безопасной среде
многоязыкового программирования.

*/

#endregion

#region English

/*

The Creation of C#

While Java successfully addresses many of the issues surrounding portability in the Internet
environment, there are still features that it lacks. One is cross-language interoperability, also
called mixed-language programming. This is the ability for the code produced by one language
to work easily with the code produced by another. Cross-language interoperability is needed
for the creation of large, distributed software systems. It is also desirable for programming
software components because the most valuable component is one that can be used by the
widest variety of computer languages, in the greatest number of operating environments.

Another feature lacking in Java is full integration with the Windows platform. Although
Java programs can be executed in a Windows environment (assuming that the Java Virtual
Machine has been installed), Java and Windows are not closely coupled. Since Windows is
the mostly widely used operating system in the world, lack of direct support for Windows
is a drawback to Java.

To answer these and other needs, Microsoft developed C#. C# was created at Microsoft
late in the 1990s and was part of Microsoft’s overall .NET strategy. It was first released in its
alpha version in the middle of 2000. C#’s chief architect was Anders Hejlsberg. Hejlsberg is
one of the world’s leading language experts, with several notable accomplishments to his
credit. For example, in the 1980s he was the original author of the highly successful and
influential Turbo Pascal, whose streamlined implementation set the standard for all future
compilers.

C# is directly related to C, C++, and Java. This is not by accident. These are three of
the most widely used—and most widely liked—programming languages in the world.
Furthermore, at the time of C#’s creation, nearly all professional programmers knew C,
C++, and/or Java. By building C# upon a solid, well-understood foundation, C# offered an
easy migration path from these languages. Since it was neither necessary nor desirable for
Hejlsberg to “reinvent the wheel,” he was free to focus on specific improvements and
innovations.

The family tree for C# is shown in Figure 1-1. The grandfather of C# is C. From C, C#
derives its syntax, many of its keywords, and its operators. C# builds upon and improves
the object model defined by C++. If you know C or C++, then you will feel at home with C#.

C# and Java have a bit more complicated relationship. As explained, Java is also
descended from C and C++. It too shares the C/C++ syntax and object model. Like Java,
C# is designed to produce portable code. However, C# is not descended from Java.
Instead, C# and Java are more like cousins, sharing a common ancestry, but differing in
many important ways. The good news, though, is that if you know Java, then many C#
concepts will be familiar. Conversely, if in the future you need to learn Java, then many
of the things you learn about C# will carry over.

C# contains many innovative features that we will examine at length throughout the
course of this book, but some of its most important relate to its built-in support for software
components. In fact, C# has been characterized as being a component-oriented language
because it contains integral support for the writing of software components. For example,
C# includes features that directly support the constituents of components, such as properties,
methods, and events. However, C#’s ability to work in a secure, mixed-language environment
is perhaps its most important component-oriented feature.

*/

#endregion