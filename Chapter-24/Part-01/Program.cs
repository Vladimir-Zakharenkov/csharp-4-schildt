#region Russian

/*

24 ГЛАВА

Многопоточное программирование.

Часть вторая: библиотека TPL

Вероятно, самым главным среди новых средств, внедренных в версию 4.0 среды .NET Framework, является
библиотека распараллеливания задач (TPL). Эта библиотека усовершенствует многопоточное программирование
двумя основными способами. Во-первых, она упрощает создание и применение многих потоков. И во-вторых, она
позволяет автоматически использовать несколько процессоров. Иными словами, TPL открывает возможности для
автоматического масштабирования приложений с целью эффективного использования ряда доступных процессоров.
Благодаря этим двух особенностям библиотеки TPL она рекомендуется в большинстве случаев к применению
для организации многопоточной обработки.

Еще одним средством параллельного программирования, внедренным в версию 4.0 среды .NET Framework,
является параллельный язык интегрированных запросов (PLINQ). Язык PLINQ дает возможность составлять запросы,
для обработки которых автоматически используется несколько процессоров, а также принцип параллелизма,
когда это уместно. Как станет ясно из дальнейшего, запросить параллельную обработку запроса очень просто. 
Следовательно, с помощью PLINQ можно без особого труда внедрить параллелизм в запрос.

Главной причиной появления таких важных новшеств, как TPL и PLINQ, служит возросшее значение параллелизма
в современном программировании. В настоящее время многоядерные процессоры уже стали обычным явлением.
Кроме того, постоянно растет потребность в повышении производительности программ. Все это, в свою очередь,
вызвало растущую потребность в механизме, который позволял бы с выгодой использовать несколько процессов 
для повышения производительности программного обеспечения. Но дело в том, что в прошлом это было не
так-то просто сделать ясным и допускающим масштабирование способом. Изменить это положение, собственно, 
и призваны TPL и PLINQ. Ведь они дают возможность легче (и безопаснее) использовать системные ресурсы.

Библиотека TPL определена в пространстве имен System.Threading.Tasks.
Но для работы с ней обычно требуется также включать в программу класс System.Threading, 
поскольку он поддерживает синхронизацию и другие средства многопоточной
обработки, в том числе и те, что входят в класс Interlocked.

В этой главе рассматривается и TPL, и PLINQ. Следует, однако, иметь в виду, что
и та и другая тема довольно обширны. Поэтому в этой главе даются самые основы и
рассматриваются некоторые простейшие способы применения TPL и PLINQ. Таким
образом, материал этой главы послужит вам в качестве удобной отправной точки для
дальнейшего изучения TPL и PLINQ. Если параллельное программирование входит в
сферу ваших интересов, то именно эти средства .NET Framework вам придется изучить
более основательно.

ПРИМЕЧАНИЕ
Несмотря на то что применение TPL и PLINQ рекомендуется теперь для разработки большинства
многопоточных приложений, организация многопоточной обработки на основе
класса Thread, представленного в главе 23, по-прежнему находит широкое распространение.
Кроме того, многое из того, что пояснялось в главе 23, применимо и к TPL. Поэтому
усвоение материала главы 23 все еще необходимо для полного овладения особенностями
организации многопоточной обработки на С#.

*/

#endregion

#region English

/*

24 CHAPTER

Multithreading, Part Two:

Exploring the Task Parallel Library and PLINQ

Perhaps the most important new feature added to the .NET Framework by version 4.0
is the Task Parallel Library (TPL). This library enhances multithreaded programming
in two important ways. First, it simplifies the creation and use of multiple threads.
Second, it automatically makes use of multiple processors. In other words, by using the TPL
you enable your applications to automatically scale to make use of the number of available
processors. These two features make the TPL the recommended approach to multithreading
in most cases.

Another parallel programming feature added by .NET 4.0 is PLINQ, which stands for
Parallel Language Integrated Query. PLINQ enables you to write queries that automatically
make use of multiple processors and parallelism when appropriate. As you will see, it is
trivially easy to request parallel execution of a query. Thus, through the use of PLINQ, it
is possible to add parallelism to a query with little effort.

The primary reason that TPL and PLINQ are such important advances is because of the
growing importance of parallelism in modern programming. Today, multicore processors
are becoming commonplace. Furthermore, the demand for better program performance
is increasing. As a result, there has been a growing need for a mechanism that enables
software to take advantage of multiple processors to increase performance. The trouble is
that in the past, it was not always easy to do so in a clean, scalable manner. The TPL and
PLINQ change this, making it easier (and safer) to best utilize system resources.

The TPL is defined in the System.Threading.Tasks namespace. However, when working
with the TPL, you will also often need to include System.Threading because it provides
support for synchronization and other multithreading features such as the Interlocked class.

This chapter explores both the TPL and PLINQ. Understand, however, that these are
large topics, and it is not possible to cover them in detail. Instead, the fundamentals of each
is described and several basic techniques are demonstrated. Thus, the information in this
chapter will help you get started. If you will be focusing on parallel programming, then
these are areas of the .NET framework that you will want to study in greater detail.

*/

#endregion