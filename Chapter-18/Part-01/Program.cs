#region Russian

/*

18 ГЛАВА

Обобщения

Эта глава посвящена обобщениям — одному из самых
сложных и эффективных средств С#. Любопытно,
что обобщения не вошли в первоначальную версию
1.0 и появились лишь в версии 2.0, но теперь они являются
неотъемлемой частью языка С#. Не будет преувеличением
сказать, что внедрение обобщений коренным образом изменило
характер С#. Это нововведение не только означало
появление нового элемента синтаксиса данного языка, но и
открыло новые возможности для внесения многочисленных
изменений и обновлений в библиотеку классов. И хотя после
внедрения обобщений прошло уже несколько лет, последствия
этого важного шага до сих пор сказываются на
развитии С# как языка программирования.

Обобщения как языковое средство очень важны потому,
что они позволяют создавать классы, структуры, интерфейсы,
методы и делегаты для обработки разнотипных данных
с соблюдением типовой безопасности. Как вам должно
быть известно, многие алгоритмы очень похожи по своей
логике независимо от типа данных, к которым они применяются.
Например, механизм, поддерживающий очередь,
остается одинаковым независимо от того, предназначена ли
очередь для хранения элементов типа int, string, object
или для класса, определяемого пользователем. До появления
обобщений для обработки данных разных типов приходилось
создавать различные варианты одного и того же
алгоритма. А благодаря обобщениям можно сначала выработать
единое решение независимо от конкретного типа
данных, а затем применить его к обработке данных самых
разных типов без каких-либо дополнительных усилий.

В этой главе описываются синтаксис, теория и практика применения обобщений,
а также показывается, каким образом обобщения обеспечивают типовую безопасность
в ряде случаев, которые раньше считались сложными. После прочтения настоящей
главы у вас невольно возникнет желание ознакомиться с материалом главы 25, посвященной
коллекциям, так как в ней приведено немало примеров применения обобщений
в классах обобщенных коллекций.

Что такое обобщения

Термин обобщение, по существу, означает параметризированный тип. Особая роль
параметризированных типов состоит в том, что они позволяют создавать классы,
структуры, интерфейсы, методы и делегаты, в которых обрабатываемые данные указываются
в виде параметра. С помощью обобщений можно, например, создать единый
класс, который автоматически становится пригодным для обработки разнотипных
данных. Класс, структура, интерфейс, метод или делегат, оперирующий параметризированным
типом данных, называется обобщенным, как, например, обобщенный класс
или обобщенный метод.

Следует особо подчеркнуть, что в C# всегда имелась возможность создавать обобщенный
код, оперируя ссылками типа object. А поскольку класс object является
базовым для всех остальных классов, то по ссылке типа object можно обращаться
к объекту любого типа. Таким образом, до появления обобщений для оперирования
разнотипными объектами в программах служил обобщенный код, в котором для этой
цели использовались ссылки типа object.

Но дело в том, что в таком коде трудно было соблюсти типовую безопасность, поскольку
для преобразования типа object в конкретный тип данных требовалось приведение
типов. А это служило потенциальным источником ошибок из-за того, что
приведение типов могло быть неумышленно выполнено неверно. Это затруднение позволяют
преодолеть обобщения, обеспечивая типовую безопасность, которой раньше
так недоставало. Кроме того, обобщения упрощают весь процесс, поскольку исключают
необходимость выполнять приведение типов для преобразования объекта или другого
типа обрабатываемых данных. Таким образом, обобщения расширяют возможности
повторного использования кода и позволяют делать это надежно и просто.

ПРИМЕЧАНИЕ
Программирующим на C++ и Java необходимо иметь в виду, что обобщения в C# не следует
путать с шаблонами в C++ и обобщениями в Java, поскольку это разные, хотя и похожие
средства. В действительности между этими тремя подходами к реализации обобщений существуют
коренные различия. Если вы имеете некоторый опыт программирования на C++ или
Java, то постарайтесь на основании этого опыта не делать никаких далеко идущих выводов
о том, как обобщения действуют в С#.

*/

#endregion

#region English

/*

18 CHAPTER

Generics

This chapter examines one of C#’s most sophisticated and powerful features: generics.
Interestingly, although generics are now an indispensable part of C# programming,
they were not included in the original 1.0 release. Instead, they were added by C# 2.0.
It is not an overstatement to say that the addition of generics fundamentally changed the
character of C#. Not only did it add a new syntactic element, it also added new capabilities
and resulted in many changes and upgrades to the library. Although it has been a few years
since the inclusion of generics in C#, the effects still reverberate throughout the language.

The generics feature is so important because it enables the creation of classes, structures,
interfaces, methods, and delegates that work in a type-safe manner with various kinds of
data. As you may know, many algorithms are logically the same no matter what type of
data they are being applied to. For example, the mechanism that supports a queue is the
same whether the queue is storing items of type int, string, object, or a user-defined class.
Prior to generics, you might have created several different versions of the same algorithm to
handle different types of data. Through the use of generics, you can define a solution once,
independently of any specific type of data, and then apply that solution to a wide variety of
data types without any additional effort.

This chapter describes the syntax, theory, and use of generics. It also shows how generics
provide type safety for some previously difficult cases. Once you have completed this chapter,
you will want to examine Chapter 25, which covers Collections. There you will find many
examples of generics at work in the generic collection classes.

What Are Generics?

At its core, the term generics means parameterized types. Parameterized types are important
because they enable you to create classes, structures, interfaces, methods, and delegates in
which the type of data upon which they operate is specified as a parameter. Using generics,
it is possible to create a single class, for example, that automatically works with different
types of data. A class, structure, interface, method, or delegate that operates on a parameterized
type is called generic, as in generic class or generic method.

It is important to understand that C# has always given you the ability to create generalized
code by operating through references of type object. Because object is the base class of all
other classes, an object reference can refer to any type of object. Thus, in pre-generics code,
generalized code used object references to operate on a variety of different kinds of objects.

The problem was that it could not do so with type safety because casts were needed to convert
between the object type and the actual type of the data. This was a potential source of errors
because it was possible to accidentally use an incorrect cast. Generics avoid this problem by
providing the type safety that was lacking. Generics also streamline the process because it is
no longer necessary to employ casts to translate between object and the type of data that is
actually being operated upon. Thus, generics expand your ability to re-use code, and let
you do so safely and easily.

NOTE
A Warning to C++ and Java Programmers: Although C# generics are similar to templates
in C++ and generics in Java, they are not the same as either. In fact, there are some fundamental
differences among these three approaches to generics. If you have a background in C++ or Java, it
is important to not jump to conclusions about how generics work in C#.

*/

#endregion