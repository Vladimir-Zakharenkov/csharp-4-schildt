#region Russian

/*

23 ГЛААВА

Многопоточное программирование.
Часть первая: основы

Среди многих замечательных свойств языка С# особое место принадлежит поддержке многопоточного программирования.
Многопоточная программа состоит из двух иди более частей, выполняемых параллельно. Каждая
часть такой программы называется потоком и определяет отдельный путь выполнения команд. Таким образом,
многопоточная обработка является особой формой многозадачности.

Многопоточное программирование опирается на целый ряд средств, предусмотренных для этой цели в самом
языке С#, а также на классы, определенные в среде .NET Framework. Благодаря встроенной в C# поддержке 
многопоточной обработки сводятся к минимуму или вообще устраняются многие трудности, связанные с организацией
многопоточной обработки в других языках программирования. Как станет ясно из дальнейшего, поддержка в C#
многопоточной обработки четко организована и проста для понимания.

С выпуском версии 4.0 в среде .NET Framework появились два важных дополнения, имеющих отношение к многопоточным
приложениям. Первым из них является TPL (Task Parallel Library — Библиотека распараллеливания задач),
а вторым — PLINQ (Parallel LINQ — Параллельный язык интегрированных запросов). Оба дополнения поддерживают
параллельное программирование и позволяют использовать преимущества, предоставляемые многопроцессорными
(многоядерными) компьютерами в отношении обработки данных. Кроме того, библиотека TPL упрощает
создание многопоточных приложений и управление ими. В силу этого многопоточная обработка, опирающаяся на 
TPL, рекомендуется теперь как основной подход к разработке многопоточных приложений.
Тем не менее накопленный опыт создания исходной многопоточной подсистемы по-прежнему имеет значение 
по целому ряду причин. Во-первых, уже существует немалый объем унаследованного кода, в котором применяется 
первоначальный подход к многопоточной обработке. Если приходится работать с таким кодом или сопровождать
его, то нужно знать, как работает исходная многопоточная система. Во-вторых, в коде, опирающемся на TPL, 
могут по-прежнему использоваться элементы исходной многопоточной системы, и особенно ее средства синхронизации. 
И в-третьих, несмотря на то что сама библиотека TPL основывается на абстракции, называемой задачей,
она по-прежнему неявно опирается на потоки и потоковые средства, описываемые в этой главе. Поэтому для полного 
усвоения и применения TPL потребуются твердые знания материала, излагаемого в этой главе.

И наконец, следует особо подчеркнуть, что многопоточная обработка представляет собой довольно обширную тему, 
и поэтому подробное ее изложение выходит за рамки этой книги. В этой и последующей главах представлен лишь 
беглый обзор данной темы и демонстрируется ряд основополагающих методик. Следовательно, материал
этих глав может служить введением в эту важную тему и основанием для дальнейшего ее самостоятельного изучения.

*/

#endregion

#region English

/*

23 CHAPTER

Multithreaded Programming, 
Part One

Although C# contains many exciting features, one of its most powerful is its built-in
support for multithreaded programming. A multithreaded program contains two or
more parts that can run concurrently. Each part of such a program is called a thread,
and each thread defines a separate path of execution. Thus, multithreading is a specialized
form of multitasking.

Multithreaded programming relies on a combination of features defined by the C#
language and by classes in the .NET Framework. Because support for multithreading is
built into C#, many of the problems associated with multithreading in other languages are
minimized or eliminated. As you will see, C#’s support of multithreading is both clean and
easy to understand.

With the release of version 4.0 of the .NET Framework, two important additions were
made that relate to multithreaded applications. The first is the Task Parallel Library (TPL),
and the other is Parallel LINQ (PLINQ). Both provide support for parallel programming,
and both can take advantage of multiple-processor (multicore) computers. In addition, the
TPL streamlines the creation and management of multithreaded applications. Because of
this, TPL-based multithreading is now the recommended approach for multithreading in
most cases. However, a working knowledge of the original multithreading subsystem is still
important for several reasons. First, there is much preexisting (legacy) code that uses the
original approach. If you will be working on or maintaining this code, you need to know
how the original threading system operated. Second, TPL-based code may still use elements
of the original threading system, especially its synchronization features. Third, although the
TPL is based on an abstraction called the task, it still implicitly relies on threads and the
thread-based features described here. Therefore, to fully understand and utilize the TPL,
a solid understanding of the material in this chapter is needed.

Finally, it is important to state that multithreading is a very large topic. It is far beyond
the scope of this book to cover it in detail. This and the following chapter present an
overview of the topic and show several fundamental techniques. Thus, it serves as an
introduction to this important topic and provides a foundation upon which you can build.

*/

#endregion
