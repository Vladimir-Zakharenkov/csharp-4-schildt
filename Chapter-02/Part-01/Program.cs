#region Russian

/*

ГЛАВА 2

Краткий обзор элементов C#

Наибольшие трудности в изучении языка программирования вызывает то обстоятельство, что ни
один из его элементов не существует обособленно. Напротив, все элементы языка действуют совместно. 
Такая взаимосвязанность затрудняет рассмотрение одного аспекта C# безотносительно к другому. 
Поэтому для преодоления данного затруднения в этой главе дается краткий обзор
нескольких средств языка С#, включая общую форму программы на С#, ряд основных управляющих и 
прочих операторов. Вместо того чтобы углубляться в детали, в этой главе
основное внимание уделяется лишь самым общим принципам написания любой программы на С#. 
А большинство вопросов, затрагиваемых по ходу изложения материала этой главы, более подробно 
рассматриваются в остальных главах части I.

Объектно-ориентированное программирование

Основным понятием C# является объектно-ориентированное программирование (ООП). Методика ООП 
неотделима от С#, и поэтому все программы на C# являются объектно-ориентированными хотя бы в 
самой малой степени. В связи с этим очень важно и полезно усвоить основополагающие
принципы ООП, прежде чем приступать к написанию самой простой программы на С#.

ООП представляет собой эффективный подход к программированию. Методики программирования претерпели
существенные изменения с момента изобретения компьютера, постепенно приспосабливаясь, главным 
образом, к повышению сложности программ. Когда, например, появились первые ЭВМ, программирование 
заключалось в ручном переключении на разные двоичные машинные команды с переднего
пульта управления ЭВМ. Такой подход был вполне оправданным, поскольку программы
состояли всего из нескольких сотен команд. Дальнейшее усложнение программ
привело к разработке языка ассемблера, который давал программистам возможность
работать с более сложными программами, используя символическое представление
отдельных машинных команд. Постоянное усложнение программ вызвало потребность
в разработке и внедрении в практику программирования таких языков высокого
уровня, как, например, FORTRAN и COBOL, которые предоставляли программистам
больше средств для того, чтобы как-то справиться с постоянно растущей сложностью
программ. Но как только возможности этих первых языков программирования были
полностью исчерпаны, появились разработки языков структурного программирования,
в том числе и С.

На каждом этапе развития программирования появлялись методы и инструментальные
средства для "обуздания" растущей сложности программ. И на каждом
таком этапе новый подход вбирал в себя все самое лучшее из предыдущих, знаменуя
собой прогресс в программировании. Это же можно сказать и об ООП. До ООП
многие проекты достигали (а иногда и превышали) предел, за которым структурный
подход к программированию оказывался уже неработоспособным. Поэтому для преодоления
трудностей, связанных с усложнением программ, и возникла потребность в ООП.

ООП вобрало в себя все самые лучшие идеи структурного программирования,
объединив их с рядом новых понятий. В итоге появился новый и лучший способ организации
программ. В самом общем виде программа может быть организована одним
из двух способов: вокруг кода (т.е. того, что фактически происходит) или же вокруг
данных (т.е. того, что подвергается воздействию). Программы, созданные только методами
структурного программирования, как правило, организованы вокруг кода. Такой
подход можно рассматривать "как код, воздействующий на данные".

Совсем иначе работают объектно-ориентированные программы. Они организованы
вокруг данных, исходя из главного принципа: "данные управляют доступом к коду".
В объектно-ориентированном языке программирования определяются данные и код,
которому разрешается воздействовать на эти данные. Следовательно, тип данных точно
определяет операции, которые могут быть выполнены над данными.

Для поддержки принципов ООП все объектно-ориентированные языки программирования,
в том числе и С#, должны обладать тремя общими свойствами: инкапсуляцией,
полиморфизмом и наследованием. Рассмотрим каждое из этих свойств в отдельности.

*/

#endregion

#region English

/*

CHAPTER 2

An Overview of C#

By far, the hardest thing about learning a programming language is the fact that no
element exists in isolation. Instead, the components of the language work together.
This interrelatedness makes it difficult to discuss one aspect of C# without involving
another. To help overcome this problem, this chapter provides a brief overview of several
C# features, including the general form of a C# program, some basic control statements, and
operators. It does not go into too many details, but rather concentrates on the general concepts
common to any C# program. Most of the topics discussed here are examined in greater
detail in the remaining chapters of Part I.

Object-Oriented Programming

At the center of C# is object-oriented programming (OOP). The object-oriented methodology is
inseparable from C#, and all C# programs are to at least some extent object oriented. Because
of its importance to C#, it is useful to understand OOP’s basic principles before you write
even a simple C# program.

OOP is a powerful way to approach the job of programming. Programming methodologies
have changed dramatically since the invention of the computer, primarily to accommodate
the increasing complexity of programs. For example, when computers were first invented,
programming was done by toggling in the binary machine instructions using the computer’s
front panel. As long as programs were just a few hundred instructions long, this approach
worked. As programs grew, assembly language was invented so that a programmer could
deal with larger, increasingly complex programs, using symbolic representations of the
machine instructions. As programs continued to grow, high-level languages such as
FORTRAN and COBOL were introduced that gave the programmer more tools with which
to handle complexity. When these early languages began to reach their breaking point,
structured programming languages, such as C, were invented.

At each milestone in the history of programming, techniques and tools were created to
allow the programmer to deal with increasingly greater complexity. Each step of the way,
the new approach took the best elements of the previous methods and moved forward. The
same is true of object-oriented programming. Prior to OOP, many projects were nearing (or
exceeding) the point where the structured approach no longer worked. A better way to
handle complexity was needed, and object-oriented programming was the solution.

Object-oriented programming took the best ideas of structured programming and
combined them with several new concepts. The result was a different and better way of
organizing a program. In the most general sense, a program can be organized in one of two
ways: around its code (what is happening) or around its data (what is being affected). Using
only structured programming techniques, programs are typically organized around code.
This approach can be thought of as “code acting on data.”
Object-oriented programs work the other way around. They are organized around data,
with the key principle being “data controlling access to code.” In an object-oriented language,
you define the data and the code that is permitted to act on that data. Thus, a data type
defines precisely the operations that can be applied to that data.
To support the principles of object-oriented programming, all OOP languages, including
C#, have three traits in common: encapsulation, polymorphism, and inheritance. Let’s
examine each.

*/

#endregion