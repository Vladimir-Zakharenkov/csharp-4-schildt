#region Russian

/*

Появление Интернета и Java

Следующим важным шагом в развитии языков программирования стала разработка
Java. Работа над языком Java, который первоначально назывался Oak (Дуб), началась
в 1991 году в компании Sun Microsystems. Главной "движущей силой" в разработке Java
был Джеймс Гослинг (James Gosling), но не малая роль в работе над этим языком принадлежит
также Патрику Ноутону (Patrick Naughton), Крису Уорту (Chris Warth), Эду
Фрэнку (Ed Frank) и Майку Шеридану (Mike Sheridan).

Java представляет собой структурированный, объектно-ориентированный язык
с синтаксисом и конструктивными особенностями, унаследованными от C++. Нововведения
в Java возникли не столько в результате прогресса в искусстве программирования,
хотя некоторые успехи в данной области все же были, сколько вследствие
перемен в вычислительной среде. До появления на широкой арене Интернета большинство
программ писалось, компилировалось и предназначалось для конкретного
процессора и операционной системы. Как известно, программисты всегда стремились
повторно использовать свой код, но, несмотря на это, легкой переносимости программ
из одной среды в другую уделялось меньше внимания, чем более насущным
задачам. Тем не менее с появлением Интернета, когда в глобальную сеть связывались
разнотипные процессоры и операционные системы, застаревшая проблема переносимости
программ вновь возникла с неожиданной остротой. Для решения проблемы
переносимости потребовался новый язык, и им стал Java.

Самым важным свойством (и причиной быстрого признания) Java является способность
создавать межплатформенный, переносимый код, тем не менее, интересно
отметить, что первоначальным толчком для разработки Java послужил не Интернет,
а потребность в независящем от платформы языке, на котором можно было бы разрабатывать
программы для встраиваемых контроллеров. В 1993 году стало очевидно,
что вопросы межплатформенной переносимости, возникавшие при создании кода
для встраиваемых контроллеров, стали актуальными и при попытке написать код для
Интернета. Напомним, что Интернет — это глобальная распределенная вычислительная
среда, в которой работают и мирно "сосуществуют" разнотипные компьютеры.
И в итоге оказалось, что теми же самыми методами, которыми решалась проблема
переносимости программ в мелких масштабах, можно решать аналогичную задачу
в намного более крупных масштабах Интернета.

Переносимость программ на Java достигалась благодаря преобразованию исходного
кода в промежуточный, называемый байт-кодом. Этот байт-код затем выполнялся
виртуальной машиной Java (JVM) — основной частью исполняющей системы Java. Таким
образом, программа на Java могла выполняться в любой среде, для которой была
доступна JVM. А поскольку JVM реализуется относительно просто, то она сразу же
стала доступной для большого числа сред.

Применением байт-кода Java коренным образом отличается от С и C++, где исходный
код практически всегда компилируется в исполняемый машинный код, который,
в свою очередь, привязан к конкретному процессору и операционной системе.
Так, если требуется выполнить программу на С или C++ в другой системе, ее придется
перекомпилировать в машинный код специально для данной вычислительной среды.
Следовательно, для создания программы на С или C++, которая могла был выполняться
в различных средах, потребовалось бы несколько разных исполняемых версий этой
программы. Это оказалось бы не только непрактично, но и дорого. Изящным и рентабельным
решением данной проблемы явилось применение в Java промежуточного
кода. Именно это решение было в дальнейшем приспособлено для целей языка С#.

Как упоминалось ранее, Java происходит от С и C++. В основу этого языка положен
синтаксис С, а его объектная модель получила свое развитие из C++. И хотя код Java не
совместим с кодом С или C++ ни сверху вниз, ни снизу вверх, его синтаксис очень похож
на эти языки, что позволяет большому числу программирующих на С или C++ без
особого труда перейти на Java. Кроме того, Java построен по уже существующему образцу,
что позволило разработчикам этого языка сосредоточить основное внимание на
новых и передовых его свойствах. Как и Страуструпу при создании C++, Гослингу и его
коллегам не пришлось изобретать велосипед, т.е. разрабатывать Java как совершенно
новый язык. Более того, после создания Java языки С и C++ стали признанной основой,
на которой можно разрабатывать новые языки программирования.

*/

#endregion

#region English

/*

The Internet and Java Emerge

The next major advance in programming languages is Java. Work on Java, which was
originally called Oak, began in 1991 at Sun Microsystems. The main driving force behind
Java’s design was James Gosling. Patrick Naughton, Chris Warth, Ed Frank, and Mike
Sheridan also played a role.

Java is a structured, object-oriented language with a syntax and philosophy derived
from C++. The innovative aspects of Java were driven not so much by advances in the art
of programming (although some certainly were), but rather by changes in the computing
environment. Prior to the mainstreaming of the Internet, most programs were written,
compiled, and targeted for a specific CPU and a specific operating system. While it has
always been true that programmers like to reuse their code, the ability to port a program
easily from one environment to another took a backseat to more pressing problems.
However, with the rise of the Internet, in which many different types of CPUs and
operating systems are connected, the old problem of portability reemerged with a
vengeance. To solve the problem of portability, a new language was needed, and this
new language was Java.

Although the single most important aspect of Java (and the reason for its rapid
acceptance) is its ability to create cross-platform, portable code, it is interesting to note
that the original impetus for Java was not the Internet, but rather the need for a platformindependent
language that could be used to create software for embedded controllers. In
1993, it became clear that the issues of cross-platform portability found when creating code
for embedded controllers are also encountered when attempting to create code for the
Internet. Remember: the Internet is a vast, distributed computing universe in which many
different types of computers live. The same techniques that solved the portability problem
on a small scale could be applied to the Internet on a large scale.

Java achieved portability by translating a program’s source code into an intermediate
language called bytecode. This bytecode was then executed by the Java Virtual Machine
(JVM). Therefore, a Java program could run in any environment for which a JVM was
available. Also, since the JVM is relatively easy to implement, it was readily available for
a large number of environments.

Java’s use of bytecode differed radically from both C and C++, which were nearly
always compiled to executable machine code. Machine code is tied to a specific CPU and
operating system. Thus, if you wanted to run a C/C++ program on a different system, it
needed to be recompiled to machine code specifically for that environment. Therefore, to
create a C/C++ program that would run in a variety of environments, several different
executable versions of the program would be needed. Not only was this impractical, it was
expensive. Java’s use of an intermediate language was an elegant, cost-effective solution.
It is also a solution that C# would adapt for its own purposes.

As mentioned, Java is descended from C and C++. Its syntax is based on C, and its object
model is evolved from C++. Although Java code is neither upwardly nor downwardly
compatible with C or C++, its syntax is sufficiently similar that the large pool of existing
C/C++ programmers could move to Java with very little effort. Furthermore, because Java
built upon and improved an existing paradigm, Gosling, et al., were free to focus their
attentions on the new and innovative features. Just as Stroustrup did not need to “reinvent
the wheel” when creating C++, Gosling did not need to create an entirely new language
when developing Java. Moreover, with the creation of Java, C and C++ became an accepted
substrata upon which to base a new computer language.

*/

#endregion