#region Russian

/*

ГЛАВА 1

СОЗДАНИЕ C#

C# является основным языком разработки программ на платформе .NET корпорации
Microsoft. В нем удачно сочетаются испытанные средства программирования с самыми 
последними новшествами и предоставляется возможность для эффективного
и очень практичного написания программ, предназначенных для вычислительной среды 
современных предприятий. Это, без сомнения, один из самых важных языков программирования
XXI века.

Назначение этой главы — представить C# в его историческом контексте, упомянув 
и те движущие силы, которые способствовали его созданию, выработке его конструктивных
особенностей и определили его влияние на другие языки программирования. Кроме того, 
в этой главе поясняется взаимосвязь С# со средой .NET Framework. Как станет ясно
из дальнейшего материала, C# и .NET Framework совместно образуют весьма изящную среду 
программирования.

Генеалогическое дерево C#

Языки программирования не существуют в пустоте. Напротив, они тесно связаны
друг с другом таким образом, что на каждый новый язык оказывают в той или иной
форме влияние его предшественники. Этот процесс сродни перекрестному опылению,
в ходе которого свойства одного языка приспосабливаются к другому языку, полезные
нововведения внедряются в существующий контекст, а устаревшие конструкции удаляются.
Таким путем развиваются языки программирования и совершенствуется искусство
программирования. И в этом отношении C# не является исключением.

У языка программирования C# "богатое наследство". Он является прямым наследником
двух самых удачных языков программирования: С и C++. Он также имеет тесные
родственные связи с еще одним языком: Java. Ясное представление об этих взаимосвязях
имеет решающее значение для понимания С#. Поэтому сначала определим, какое
место занимает C# среди этих трех языков.

Язык С - начало современной эпохи программирования

Создание С знаменует собой начало современной эпохи программирования. Язык
С был разработан Деннисом Ритчи (Dennis Ritchie) в 1970-е годы для программирования
на мини-ЭВМ DEC PDP-11 под управлением операционной системы Unix. Несмотря
на то что в ряде предшествовавших языков, в особенности Pascal, был достигнут
значительный прогресс, именно С установил тот образец, которому до сих пор следуют
в программировании.

Язык С появился в результате революции в структурном программировании
в 1960-е годы. До появления структурного программирования писать большие программы
было трудно, поскольку логика программы постепенно вырождалась в так называемый
"макаронный" код — запутанный клубок безусловных переходов, вызовов и
возвратов, которые трудно отследить. В структурированных языках программирования
этот недостаток устранялся путем ввода строго определенных управляющих операторов,
подпрограмм с локальными переменными и других усовершенствований. Благодаря
применению методов структурного программирования сами программы стали
более организованными, надежными и управляемыми.

И хотя в то время существовали и другие структурированные языки программирования,
именно в С впервые удалось добиться удачного сочетания эффективности,
изящества и выразительности. Благодаря своему краткому, но простому синтаксису
в сочетании с принципом, ставившим во главу угла программиста, а не сам язык, С быстро
завоевал многих сторонников. Сейчас уже нелегко представить себе, что С оказался
своего рода "струей свежего воздуха", которого так не хватало программистам.
В итоге С стал самым распространенным языком структурного программирования
в 1980-е годы.

Но даже у такого достойного языка, как С, имелись свои ограничения. К числу самых
труднопреодолимых его ограничений относится неспособность справиться с большими
программами. Как только проект достигает определенного масштаба, язык С
тут же ставит предел, затрудняющий понимание и сопровождение программ при их
последующем разрастании. Конкретный предел зависит от самой программы, программиста
и применяемых инструментальных средств, тем не менее, всегда существует
"порог", за которым программа на С становится неуправляемой.

*/

#endregion

#region English

/*

CHAPTER 1

The Creation of C#

C# is Microsoft’s premier language for .NET development. It leverages time-tested
features with cutting-edge innovations and provides a highly usable, efficient way
to write programs for the modern enterprise computing environment. It is, by any
measure, one of the most important languages of the twenty-first century.

The purpose of this chapter is to place C# into its historical context, including the forces
that drove its creation, its design philosophy, and how it was influenced by other computer
languages. This chapter also explains how C# relates to the .NET Framework. As you will
see, C# and the .NET Framework work together to create a highly refined programming
environment.

C#’s Family Tree

Computer languages do not exist in a void. Rather, they relate to one another, with each
new language influenced in one form or another by the ones that came before. In a process
akin to cross-pollination, features from one language are adapted by another, a new
innovation is integrated into an existing context, or an older construct is removed. In
this way, languages evolve and the art of programming advances. C# is no exception.

C# inherits a rich programming legacy. It is directly descended from two of the world’s
most successful computer languages: C and C++. It is closely related to another: Java.
Understanding the nature of these relationships is crucial to understanding C#. Thus, we
begin our examination of C# by placing it in the historical context of these three languages.

C: The Beginning of the Modern Age of Programming

The creation of C marks the beginning of the modern age of programming. C was invented
by Dennis Ritchie in the 1970s on a DEC PDP-11 that used the UNIX operating system.
While some earlier languages, most notably Pascal, had achieved significant success, it
was C that established the paradigm that still charts the course of programming today.

C grew out of the structured programming revolution of the 1960s. Prior to structured
programming, large programs were difficult to write because the program logic tended
to degenerate into what is known as “spaghetti code,” a tangled mass of jumps, calls, and
returns that is difficult to follow. Structured languages addressed this problem by adding
well-defined control statements, subroutines with local variables, and other improvements.
Through the use of structured techniques programs became better organized, more reliable,
and easier to manage.

Although there were other structured languages at the time, C was the first to successfully
combine power, elegance, and expressiveness. Its terse, yet easy-to-use syntax coupled with
its philosophy that the programmer (not the language) was in charge quickly won many
converts. It can be a bit hard to understand from today’s perspective, but C was a breath of
fresh air that programmers had long awaited. As a result, C became the most widely used
structured programming language of the 1980s.

However, even the venerable C language had its limits. One of the most troublesome
was its inability to handle large programs. The C language hits a barrier once a project
reaches a certain size, and after that point, C programs are difficult to understand and
maintain. Precisely where this limit is reached depends upon the program, the programmer,
and the tools at hand, but there is always a threshold beyond which a C program becomes
unmanageable.

*/

#endregion