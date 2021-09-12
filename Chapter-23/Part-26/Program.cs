#region Russian

/*

Дополнительные средства многопоточной обработки, внедренные в версии .NET Framework 4.0

В версии .NET Framework 4.0 внедрен ряд новых средств многопоточной обработки,
которые могут оказаться весьма полезными. Самым важным среди них является новая
система отмены. В этой системе поддерживается механизм отмены потока простым,
вполне определенным и структурированным способом. В основу этого механизма положено
понятие признака отмены, с помощью которого указывается состояние отмены
потока. Признаки отмены поддерживаются в классе CancellationTokenSource и в
структуре CancellationToken. Система отмены полностью интегрирована в новую
библиотеку распараллеливания задач (TPL), и поэтому она подробнее рассматривается
вместе с TPL в главе 24.

В класс System.Threading добавлена структура SpinWait, предоставляющая методы
SpinOnce() и SpinUntil(), которые обеспечивают более полный контроль над
ожиданием в состоянии занятости. Вообще говоря, структура SpinWait оказывается
непригодной для однопроцессорных систем. А для многопроцессорных систем она
применяется в цикле. Еще одним элементом, связанным с ожиданием в состоянии занятости,
является структура SpinLock, которая применяется в цикле ожидания до тех
пор, пока не станет доступной блокировка. В класс Thread добавлен метод Yield(),
который просто выдает остаток кванта времени, выделенного потоку. Ниже приведена
общая форма объявления этого метода.

public static bool Yield()

Этот метод возвращает логическое значение true, если происходит переключение
контекста. В отсутствие другого потока, готового для выполнения, переключение контекста
не произойдет.

Рекомендации по многопоточному программированию

Для эффективного многопоточного программирования самое главное — мыслить
категориями параллельного, а не последовательного выполнения кода. Так, если в
одной программе имеются две подсистемы, которые могут работать параллельно, их
следует организовать в отдельные потоки. Но делать это следует очень внимательно
и аккуратно, поскольку если создать слишком много потоков, то тем самым можно
значительно снизить, а не повысить производительность программы. Следует также
иметь в виду дополнительные издержки, связанные с переключением контекста. Так,
если создать слишком много потоков, то на смену контекста уйдет больше времени
ЦП, чем на выполнение самой программы! И наконец, для написания нового кода,
предназначенного для многопоточной обработки, рекомендуется пользоваться библиотекой
распараллеливания задач (TPL), о которой речь пойдет в следующей главе.


*/

#endregion

#region English

/*

Additional Multithreading Features Added by .NET 4.0

Version 4.0 of the .NET Framework adds new multithreading features that you might find
useful. The most important is the new cancellation system. The cancellation system supports
a mechanism by which a thread can be cancelled easily in a well-defined, structured way. It
is based on the concept of a cancellation token, which is used to specify the cancellation state
of a thread. Cancellation tokens are supported by the CancellationTokenSource class and
the CancellationToken structure. Because the cancellation system is fully integrated into the
new Task Parallel Library, it is described in Chapter 24, where the TPL is discussed.

System.Threading adds a structure called SpinWait. It provides the methods SpinOnce()
and SpinUntil() that give you greater control over spin waiting. In general, on single
processor systems, SpinWait will yield. On multiprocessor systems, it will use a loop. Another
spin-related element is the SpinLock, which uses a loop to wait until a lock is available.
The Thread class adds a method called Yield() that simply yields the remainder of a
thread’s timeslice. It is shown here:

public static bool Yield()

It returns true if a context switch occurred, and false otherwise. A context switch will not
occur if there is not another thread that is ready to run.

Multithreading Tips

The key to effectively utilizing multithreading is to think concurrently rather than serially. For
example, when you have two subsystems within a program that can execute concurrently,
consider making them into individual threads. A word of caution is in order, however. If you
create too many threads, you can actually degrade your program’s performance rather than
enhance it. Remember, there is some overhead associated with context switching. If you create
too many threads, more CPU time will be spent changing contexts than in executing your
program! Finally, for new code consider using the Task Parallel Library to accomplish
multithreading.

*/

#endregion