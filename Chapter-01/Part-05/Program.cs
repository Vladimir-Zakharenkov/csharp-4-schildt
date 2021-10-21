#region Russian

/*

Развитие C#

С момента выпуска исходной версии 1.0 развитие C# происходило быстро. Вскоре
после версии 1.0 корпорация Microsoft выпустила версию 1.1, в которую было внесено
немало корректив, но мало значительных возможностей. Однако ситуация совершенно
изменилась после выпуска версии C# 2.0.

Появление версии 2.0 стало поворотным моментом в истории развития С#, поскольку
в нее было введено много новых средств, в том числе обобщения, частичные
типы и анонимные методы, которые основательно расширили пределы возможностей
и область применения этого языка, а также повысили его эффективность. После выпуска
версии 2.0 "упрочилось" положение С#. Ее появление продемонстрировало также
приверженность корпорации Microsoft к поддержке этого языка в долгосрочной
перспективе.

Следующей значительной вехой в истории развития C# стал выпуск версии 3.0.
В связи с внедрением многих новых свойств в версии C# 2.0 можно было ожидать некоторого
замедления в развитии С#, поскольку программистам требовалось время для
их освоения, но этого не произошло. С появлением версии 3.0 корпорация Microsoft
внедрила ряд новшеств, совершенно изменивших общее представление о программировании.
К числу этих новшеств относятся, среди прочего, лямбда-выражения, язык
интегрированных запросов (LINQ), методы расширения и неявно типизированные переменные.
Конечно, все эти новые возможности очень важны, поскольку они оказали
заметное влияние на развитие данного языка, но среди них особенно выделяются две:
язык интегрированных запросов (LINQ) и лямбда-выражения. Язык LINQ и лямбда-
выражения вносят совершенно новый акцент в программирование на C# и еще глубже
подчеркивают его ведущую роль в непрекращающейся эволюции языков программирования.

Текущей является версия C# 4.0, о которой и пойдет речь в этой книге. Эта версия
прочно опирается на три предыдущие основные версии С#, дополняя их целым рядом
новых средств. Вероятно, самыми важными среди них являются именованные и необязательные
аргументы. В частности, именованные аргументы позволяют связывать
аргумент с параметром по имени. А необязательные аргументы дают возможность
указывать для параметра используемый по умолчанию аргумент. Еще одним важным
новым средством является тип dynamic, применяемый для объявления объектов, которые
проверяются на соответствие типов во время выполнения, а не компиляции.
Кроме того, ковариантность и контравариантность параметров типа поддерживается
благодаря новому применению ключевых слов in и out. Тем, кто пользуется моделью
СОМ вообще и прикладными интерфейсами Office Automation API в частности, существенно
упрощен доступ к этим средствам, хотя они и не рассматриваются в этой
книге. В целом, новые средства, внедренные в версии C# 4.0, способствуют дальнейшей
рационализации программирования и повышают практичность самого языка С#.

Еще два важных средства, внедренных в версии 4.0 и непосредственно связанных
с программированием на С#, предоставляются не самим языком, а средой .NET
Framework 4.0. Речь идет о поддержке параллельного программирования с помощью
библиотеки распараллеливания задач (TPL) и параллельном варианте языка интегрированных
запросов (PLINQ). Оба эти средства позволяют существенно усовершенствовать
и упростить процесс создания программ, в которых применяется принцип параллелизма.
И то и другое средство упрощает создание многопоточного кода, который
масштабируется автоматически для использования нескольких процессоров, доступных
на компьютере. В настоящее время широкое распространение подучили компьютеры
с многоядерными процессорами, и поэтому возможность распараллеливать выполнение
кода среди всех доступных процессоров приобретает все большее значение
практически для всех, кто программирует на С#. В силу этого особого обстоятельства
средства TPL и PLINQ рассматриваются в данной книге.

*/

#endregion

#region English

/*

The Evolution of C#

Since its original 1.0 release, C# has been evolving at a rapid pace. Not long after C# 1.0,
Microsoft released version 1.1. It contained many minor tweaks but added no major
features. However, the situation was much different with the release of C# 2.0.

C# 2.0 was a watershed event in the lifecycle of C# because it added many new features,
such as generics, partial types, and anonymous methods, that fundamentally expanded the
scope, power, and range of the language. Version 2.0 firmly put C# at the forefront of
computer language development. It also demonstrated Microsoft’s long-term commitment
to the language.

The next major release of C# was 3.0. Because of the many new features added by C#
2.0, one might have expected the development of C# to slow a bit, just to let programmers
catch up, but this was not the case. With the release of C# 3.0, Microsoft once again put C#
on the cutting edge of language design, this time adding a set of innovative features that
redefined the programming landscape. These include lambda expressions, languageintegrated
query (LINQ), extension methods, and implicitly typed variables, among others.
Although all of the new 3.0 features were important, the two that had the most high-profile
impact on the language were LINQ and lambda expressions. They added a completely new
dimension to C# and further emphasized its lead in the ongoing evolution of computer
languages.

The current release is C# 4.0, and that is the version of C# described by this book. C# 4.0
builds on the strong foundation established by the previous three major releases, adding
several new features. Perhaps the most important are named and optional arguments. Named
arguments let you link an argument with a parameter by name. Optional arguments give you
a way to specify a default argument for a parameter. Another important new feature is the
dynamic type, which is used to declare objects that are type-checked at runtime, rather than
compile time. Covariance and contravariance support is also provided for type parameters,
which are supported by new uses of the in and out keywords. For those programmers using
the Office Automation APIs (and COM in general), access has been simplified. (Office
Automation and COM are outside the scope of this book). In general, the new 4.0 features
further streamline coding and improve the usability of C#.

There is another major feature that relates directly to C# 4.0 programming, but which
is provided by the .NET Framework 4.0. This is support for parallel programming through
two major new features. The first is the Task Parallel Library (TPL) and the second is
Parallel LINQ (PLINQ). Both of these dramatically enhance and simplify the process of
creating programs that use concurrency. Both also make it easier to create multithreaded
code that automatically scales to utilize the number of processors available in the computer.
Put directly, multicore computers are becoming commonplace, and the ability to parallelize
your code to take advantage of them is an increasingly important part of nearly every C#
programmer’s job description. Because of the significant impact the TPL and PLINQ are
having on programming, both are covered in this book.

*/

#endregion
