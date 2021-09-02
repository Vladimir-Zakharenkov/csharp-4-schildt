#region Russian

/*

Основы многопоточной обработки

Различают две разновидности многозадачности: на основе процессов и на основе
потоков. В связи с этим важно понимать отличия между ними. Процесс фактически
представляет собой исполняемую программу. Поэтому многозадачность на основе процессов
— это средство, благодаря которому на компьютере могут параллельно выполняться
две программы и более. Так, многозадачность на основе процессов позволяет
одновременно выполнять программы текстового редактора, электронных таблиц и
просмотра содержимого в Интернете. При организации многозадачности на основе
процессов программа является наименьшей единицей кода, выполнение которой может
координировать планировщик задач.

Поток представляет собой координируемую единицу исполняемого кода. Своим
происхождением этот термин обязан понятию "поток исполнения". При организации
многозадачности на основе потоков у каждого процесса должен быть по крайней мере
один поток, хотя их может быть и больше. Это означает, что в одной программе одновременно
могут решаться две задачи и больше. Например, текст может форматироваться
в редакторе текста одновременно с его выводом на печать, при условии, что оба
эти действия выполняются в двух отдельных потоках.

Отличия в многозадачности на основе процессов и потоков могут быть сведены к
следующему: многозадачность на основе процессов организуется для параллельного
выполнения программ, а многозадачность на основе потоков — для параллельного выполнения
отдельных частей одной программы.

Главное преимущество многопоточной обработки заключается в том, что она позволяет
писать программы, которые работают очень эффективно благодаря возможности
выгодно использовать время простоя, неизбежно возникающее в ходе выполнения
большинства программ. Как известно, большинство устройств ввода-вывода, будь то
устройства, подключенные к сетевым портам, накопители на дисках или клавиатура,
работают намного медленнее, чем центральный процессор (ЦП). Поэтому большую
часть своего времени программе приходится ожидать отправки данных на устройство
ввода-вывода или приема информации из него. А благодаря многопоточной обработке
программа может решать какую-нибудь другую задачу во время вынужденного
простоя. Например, в то время как одна часть программы отправляет файл через
соединение с Интернетом, другая ее часть может выполнять чтение текстовой информации,
вводимой с клавиатуры, а третья — осуществлять буферизацию очередного
блока отправляемых данных.

Поток может находиться в одном из нескольких состояний. В целом, поток может
быть выполняющимся; готовым к выполнению, как только он получит время и ресурсы
ЦП; приостановленным, т.е. временно не выполняющимся; возобновленным в дальнейшем;
заблокированным в ожидании ресурсов для своего выполнения; а также завершенным,
когда его выполнение окончено и не может быть возобновлено.

В среде .NET Framework определены две разновидности потоков: приоритетный
и фоновый. По умолчанию создаваемый поток автоматически становится приоритетным,
но его можно сделать фоновым. Единственное отличие приоритетных потоков от
фоновых заключается в том, что фоновый поток автоматически завершается, если в его
процессе остановлены все приоритетные потоки.

В связи с организацией многозадачности на основе потоков возникает потребность
в особого рода режиме, который называется синхронизацией и позволяет координировать
выполнение потоков вполне определенным образом. Для такой синхронизации
в C# предусмотрена отдельная подсистема, основные средства которой рассматриваются
в этой главе.

Все процессы состоят хотя бы из одного потока, который обычно называют основным,
поскольку именно с него начинается выполнение программы. Следовательно,
в основном потоке выполнялись все приведенные ранее примеры программ. Из основного
потока можно создать другие потоки.

В языке C# и среде .NET Framework поддерживаются обе разновидности многозадачности:
на основе процессов и на основе потоков. Поэтому средствами C# можно
создавать как процессы, так и потоки, а также управлять и теми и другими. Для
того чтобы начать новый процесс, от программирующего требуется совсем немного
усилий, поскольку каждый предыдущий процесс совершенно обособлен от последующего.
Намного более важной оказывается поддержка в C# многопоточной
обработки, благодаря которой упрощается написание высокопроизводительных,
многопоточных программ на C# по сравнению с некоторыми другими языками программирования.

Классы, поддерживающие многопоточное программирование, определены в пространстве
имен System.Threading. Поэтому любая многопоточная программа на C#
включает в себя следующую строку кода.

using System.Threading;

*/

#endregion

#region English

/*

Multithreading Fundamentals

There are two distinct types of multitasking: process-based and thread-based. It is important
to understand the difference between the two. A process is, in essence, a program that is
executing. Thus, process-based multitasking is the feature that allows your computer to run
two or more programs concurrently. For example, process-based multitasking allows you to
run a word processor at the same time you are using a spreadsheet or browsing the Internet.
In process-based multitasking, a program is the smallest unit of code that can be dispatched
by the scheduler.

A thread is a dispatchable unit of executable code. The name comes from the concept of a
“thread of execution.” In a thread-based multitasking environment, all processes have at least
one thread, but they can have more. This means that a single program can perform two or
more tasks at once. For instance, a text editor can be formatting text at the same time that it
is printing, as long as these two actions are being performed by two separate threads.
The differences between process-based and thread-based multitasking can be
summarized like this: Process-based multitasking handles the concurrent execution of
programs. Thread-based multitasking deals with the concurrent execution of pieces of the
same program.

The principal advantage of multithreading is that it enables you to write very efficient
programs because it lets you utilize the idle time that is present in most programs. As you
probably know, most I/O devices, whether they be network ports, disk drives, or the
keyboard, are much slower than the CPU. Thus, a program will often spend a majority
of its execution time waiting to send or receive information to or from a device. By using
multithreading, your program can execute another task during this idle time. For example,
while one part of your program is sending a file over the Internet, another part can be
reading keyboard input, and still another can be buffering the next block of data to send.
A thread can be in one of several states. In general terms, it can be running. It can be ready
to run as soon as it gets CPU time. A running thread can be suspended, which is a temporary
halt to its execution. It can later be resumed. A thread can be blocked when waiting for a
resource. A thread can be terminated, in which case its execution ends and cannot be resumed.
The .NET Framework defines two types of threads: foreground and background. By default,
when you create a thread, it is a foreground thread, but you can change it to a background
thread. The only difference between foreground and background threads is that a background
thread will be automatically terminated when all foreground threads in its process have
stopped.

Along with thread-based multitasking comes the need for a special type of feature
called synchronization, which allows the execution of threads to be coordinated in certain
well-defined ways. C# has a complete subsystem devoted to synchronization, and its key
features are also described here.

All processes have at least one thread of execution, which is usually called the main
thread because it is the one that is executed when your program begins. Thus, the main
thread is the thread that all of the preceding example programs in the book have been
using. From the main thread, you can create other threads.

C# and the .NET Framework support both process-based and thread-based
multitasking. Thus, using C#, you can create and manage both processes and threads.
However, little programming effort is required to start a new process because each process
is largely separate from the next. Rather, it is C#’s support for multithreading that is
important. Because support for multithreading is built in, C# makes it easier to construct
high-performance, multithreaded programs than do some other languages.

The classes that support multithreaded programming are defined in the System.Threading
namespace. Thus, you will usually include this statement at the start of any multithreaded
program:

using System.Threading;

*/

#endregion