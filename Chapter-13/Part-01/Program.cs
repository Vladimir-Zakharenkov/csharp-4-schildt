#region Russian

/*

13 ГЛАВА
Обработка исключительных ситуаций

Исключительная ситуация, или просто исключение, происходит во время выполнения. 
Используя подсистему обработки исключительных ситуаций в С#,
можно обрабатывать структурированным и контролируемым образом ошибки, возникающие 
при выполнении программы. Главное преимущество обработки исключительных
ситуаций заключается в том, что она позволяет автоматизировать
получение большей части кода, который раньше приходилось вводить в любую крупную программу
вручную для обработки ошибок. Так, если программа написана на языке программирования 
без обработки исключительных ситуаций, то при неудачном выполнении
методов приходится возвращать коды ошибок, которые необходимо проверять вручную при каждом 
вызове метода. Это не только трудоемкий, но и чреватый ошибками процесс.
Обработка исключительных ситуаций рационализирует весь процесс обработки ошибок, позволяя 
определить в программе блок кода, называемый обработчиком исключений
и выполняющийся автоматически, когда возникает ошибка. Это избавляет от необходимости 
проверять вручную, насколько удачно или неудачно завершилась конкретная
операция либо вызов метода. Если возникнет ошибка, она будет обработана соответствующим 
образом обработчиком ошибок.

Обработка исключительных ситуаций важна еще и потому, что в С# определены стандартные исключения для
типичных программных ошибок, например деление на нуль или выход индекса за границы массива. 
Для реагирования на подобные ошибки в программе должно быть организовано отслеживание и обработка 
соответствующих исключительных ситуаций. Ведь в конечном счете для успешного программирования
на C# необходимо научиться умело пользоваться подсистемой обработки исключительных
ситуаций.

Класс System.Exception

В C# исключения представлены в виде классов. Все классы исключений должны
быть производными от встроенного в C# класса Exception, являющегося частью пространства
имен System. Следовательно, все исключения являются подклассами класса Exception.

К числу самых важных подклассов Exception относится класс SystemException.
Именно от этого класса являются производными все исключения, генерируемые исполняющей
системой C# (т.е. системой CLR). Класс SystemException ничего не добавляет
к классу Exception, а просто определяет вершину иерархии стандартных исключений.

В среде .NET Framework определено несколько встроенных исключений, являющихся
производными от класса SystemException. Например, при попытке выполнить
деление на нуль генерируется исключение DivideByZeroException. Как будет
показано далее в этой главе, в C# можно создавать собственные классы исключений,
производные от класса Exception.

Основы обработки исключительных ситуаций

Обработка исключительных ситуаций в C# организуется с помощью четырех ключевых
слов: try, catch, throw и finally. Они образуют взаимосвязанную подсистему,
в которой применение одного из ключевых слов подразумевает применение другого.
На протяжении всей этой главы назначение и применение каждого из упомянутых
выше ключевых слов будет рассмотрено во всех подробностях. Но прежде необходимо
дать общее представление о роли каждого из них в обработке исключительных ситуаций.
Поэтому ниже кратко описан принцип их действия.

Операторы программы, которые требуется контролировать на появление исключений,
заключаются в блок try. Если внутри блока try возникает исключительная ситуация,
генерируется исключение. Это исключение может быть перехвачено и обработано
каким-нибудь рациональным способом в коде программы с помощью оператора, обозначаемого
ключевым словом catch. Исключения, возникающие на уровне системы,
генерируются исполняющей системой автоматически. А для генерирования исключений
вручную служит ключевое слово throw. Любой код, который должен быть непременно
выполнен после выхода из блока try, помещается в блок finally.

Применение пары ключевых слов try и catch

Основу обработки исключительных ситуаций в C# составляет пара ключевых слов
try и catch. Эти ключевые слова действуют совместно и не могут быть использованы
порознь. Ниже приведена общая форма определения блоков try/catch для обработки
исключительных ситуаций:

try {
// Блок кода, проверяемый на наличие ошибок.
}
catch (ExcepType1 exOb) {
// Обработчик исключения типа ExcepTypel.
}
catch (ExcepType2 exOb) {
// Обработчик исключения типа ExcepType2.
}

где ЕхсерТуре — это тип возникающей исключительной ситуации. Когда исключение
генерируется оператором try, оно перехватывается составляющим ему пару оператором
catch, который затем обрабатывает это исключение. В зависимости от типа
исключения выполняется и соответствующий оператор catch. Так, если типы генерируемого
исключения и того, что указывается в операторе catch, совпадают, то выполняется
именно этот оператор, а все остальные пропускаются. Когда исключение
перехватывается, переменная исключения exOb получает свое значение.

На самом деле указывать переменную ехОb необязательно. Так, ее необязательно
указывать, если обработчику исключений не требуется доступ к объекту исключения,
что бывает довольно часто. Для обработки исключения достаточно и его типа. Именно
поэтому во многих примерах программ, приведенных в этой главе, переменная ехОb
опускается.

Следует, однако, иметь в виду, что если исключение не генерируется, то блок оператора
try завершается как обычно, и все его операторы catch пропускаются. Выполнение
программы возобновляется с первого оператора, следующего после завершающего
оператора catch. Таким образом, оператор catch выполняется лишь в том случае,
если генерируется исключение.

Простой пример обработки исключительной ситуации

Рассмотрим простой пример, демонстрирующий отслеживание и перехватывание
исключения. Как вам должно быть уже известно, попытка индексировать массив за его
границами приводит к ошибке. Когда возникает подобная ошибка, система CLR генерирует
исключение IndexOutOfRangeException, которое определено как стандартное
для среды .NET Framework. В приведенной ниже программе такое исключение
генерируется намеренно и затем перехватывается.

*/

// Продемонстрировать обработку исключительной ситуации.

using System;
class ExcDemol
{
    static void Main()
    {
        int[] nums = new int[4];
        try
        {
            Console.WriteLine("До генерирования исключения.");

            // Сгенерировать исключение в связи с выходом индекса за границы массива.
            for (int i = 0; i < 10; i++)
            {
                nums[i] = i;
                Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
            }

            Console.WriteLine("Не подлежит выводу");
        }
        catch (IndexOutOfRangeException)
        {
            // Перехватить исключение
            Console.WriteLine("Индекс вышел за границы массива!");
        }

        Console.WriteLine("После блока перехвата исключения.");

        Console.ReadKey();
    }
}

/*

При выполнении этой программы получается следующий результат.

До генерирования исключения.
nums[0]: 0
nums[1]: 1
nums[2]: 2
nums[3]: 3
Индекс вышел за границы массива!
После блока перехвата исключения.

В данном примере массив nums типа int состоит из четырех элементов. Но в цикле
for предпринимается попытка проиндексировать этот массив от 0 до 9, что и приводит
к появлению исключения IndexOutOfRangeException, когда происходит обращение
к элементу массива по индексу 4.

Несмотря на всю свою краткость, приведенный выше пример наглядно демонстрирует
ряд основных моментов процесса обработки исключительных ситуаций.
Во-первых, код, который требуется контролировать на наличие ошибок, содержится в
блоке try. Во-вторых, когда возникает исключительная ситуация (в данном случае —
при попытке проиндексировать массив nums за его границами в цикле for), в блоке
try генерируется исключение, которое затем перехватывается в блоке catch. В этот
момент выполнение кода в блоке try завершается и управление передается блоку
catch. Это означает, что оператор catch не вызывается специально, а выполнение
кода переходит к нему автоматически. Следовательно, оператор, содержащий метод
WriteLine() и следующий непосредственно за циклом for, где происходит выход
индекса за границы массива, вообще не выполняется. А в задачу обработчика исключений
входит исправление ошибки, приведшей к исключительной ситуации, чтобы
продолжить выполнение программы в нормальном режиме.

Обратите внимание на то, что в операторе catch указан только тип исключения
(в данном случае — IndexOutOfRangeException), а переменная исключения отсутствует.
Как упоминалось ранее, переменную исключения требуется указывать лишь
в том случае, если требуется доступ к объекту исключения. В ряде случаев значение
объекта исключения может быть использовано обработчиком исключений для получения
дополнительной информации о самой ошибке, но зачастую для обработки
исключительной ситуации достаточно просто знать, что она произошла. Поэтому
переменная исключения нередко отсутствует в обработчиках исключений, как в рассматриваемом
здесь примере.

Как пояснялось ранее, если исключение не генерируется в блоке try, то блок catch
не выполняется, а управление программой передается оператору, следующему после
блока catch. Для того чтобы убедиться в этом, замените в предыдущем примере программы
строку кода

for(int i=0; i < 10; i++) {

на строку

for(int i=0; i < nums.Length; i++) {

Теперь индексирование массива не выходит за его границы в цикле for. Следовательно,
никакого исключения не генерируется и блок catch не выполняется.

*/

#endregion

#region English

/*

13 CHAPTER
Exception Handling

An exception is an error that occurs at runtime. Using C#’s exception-handling
subsystem, you can, in a structured and controlled manner, handle runtime errors.
A principal advantage of exception handling is that it automates much of the errorhandling
code that previously had to be entered “by hand” into any large program. For
example, in a computer language without exception handling, error codes must be returned
when a method fails, and these values must be checked manually each time the method is
called. This approach is both tedious and error-prone. Exception handling streamlines errorhandling
by allowing your program to define a block of code, called an exception handler,
that is executed automatically when an error occurs. It is not necessary to manually check
the success or failure of each specific operation or method call. If an error occurs, it will be
processed by the exception handler.

Exception handling is also important because C# defines standard exceptions for common
program errors, such as divide-by-zero or index-out-of-range. To respond to these errors,
your program must watch for and handle these exceptions. In the final analysis, to be a
successful C# programmer means that you are fully capable of navigating C#’s exceptionhandling
subsystem.

The System.Exception Class

In C#, exceptions are represented by classes. All exception classes must be derived from the
built-in exception class Exception, which is part of the System namespace. Thus, all exceptions
are subclasses of Exception.

One very important subclass of Exception is SystemException. This is the exception
class from which all exceptions generated by the C# runtime system (that is, the CLR) are
derived. SystemException does not add anything to Exception. It simply defines the top
of the standard exceptions hierarchy.

The .NET Framework defines several built-in exceptions that are derived from
SystemException. For example, when a division-by-zero is attempted, a DivideByZeroException
exception is generated. As you will see later in this chapter, you can create your own
exception classes by deriving them from Exception.

Exception-Handling Fundamentals

C# exception handling is managed via four keywords: try, catch, throw, and finally.
They form an interrelated subsystem in which the use of one implies the use of another.
Throughout the course of this chapter, each keyword is examined in detail. However, it
is useful at the outset to have a general understanding of the role each plays in exception
handling. Briefly, here is how they work.

Program statements that you want to monitor for exceptions are contained within a
try block. If an exception occurs within the try block, it is thrown. Your code can catch this
exception using catch and handle it in some rational manner. System-generated exceptions
are automatically thrown by the runtime system. To manually throw an exception, use the
keyword throw. Any code that absolutely must be executed upon exiting from a try block is
put in a finally block.

Using try and catch

At the core of exception handling are try and catch. These keywords work together, and you
can’t have a catch without a try. Here is the general form of the try/catch exception-handling
blocks:

try {
// block of code to monitor for errors
}
catch (ExcepType1 exOb) {
// handler for ExcepType1
}
catch (ExcepType2 exOb) {
// handler for ExcepType2
}...

Here, ExcepType is the type of exception that has occurred. When an exception is thrown,
it is caught by its corresponding catch clause, which then processes the exception. As the
general form shows, more than one catch clause can be associated with a try. The type of
the exception determines which catch is executed. That is, if the exception type specified
by a catch matches that of the exception, then that catch is executed (and all others are
bypassed). When an exception is caught, the exception variable exOb will receive its value.

Actually, specifying exOb is optional. If the exception handler does not need access to the
exception object (as is often the case), there is no need to specify exOb. The exception type
alone is sufficient. For this reason, many of the examples in this chapter will not specify exOb.

Here is an important point: If no exception is thrown, then a try block ends normally,
and all of its catch clauses are bypassed. Execution resumes with the first statement
following the last catch. Thus, a catch is executed only if an exception is thrown.

A Simple Exception Example

Here is a simple example that illustrates how to watch for and catch an exception. As you
know, it is an error to attempt to index an array beyond its boundaries. When this error
occurs, the CLR throws an IndexOutOfRangeException, which is a standard exception
defined by the .NET Framework. The following program purposely generates such an
exception and then catches it:

*/

// Demonstrate exception handling. 

//using System; 

//class ExcDemo1
//{
//    static void Main()
//    {
//        int[] nums = new int[4];

//        try
//        {
//            Console.WriteLine("Before exception is generated.");

//            // Generate an index out-of-bounds exception. 
//            for (int i = 0; i < 10; i++)
//            {
//                nums[i] = i;
//                Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
//            }

//            Console.WriteLine("this won't be displayed");
//        }
//        catch (IndexOutOfRangeException)
//        {
//            // Catch the exception. 
//            Console.WriteLine("Index out-of-bounds!");
//        }
//        Console.WriteLine("After catch block.");

//        Console.ReadKey();
//    }
//}

/*

This program displays the following output:

Before exception is generated.
nums[0]: 0
nums[1]: 1
nums[2]: 2
nums[3]: 3
Index out-of-bounds!
After catch block.

Notice that nums is an int array of four elements. However, the for loop tries to index nums
from 0 to 9, which causes an IndexOutOfRangeException to occur when an index value of
4 is tried.

Although quite short, the preceding program illustrates several key points about exception
handling. First, the code that you want to monitor for errors is contained within a try block.
Second, when an exception occurs (in this case, because of the attempt to index nums
beyond its bounds inside the for loop), the exception is thrown out of the try block and
caught by the catch. At this point, control passes to the catch block, and the try block is
terminated. That is, catch is not called. Rather, program execution is transferred to it. Thus,
theWriteLine() statement following the out-of-bounds index will never execute. After the
catch block executes, program control continues with the statements following the catch.
Thus, it is the job of your exception handler to remedy the problem that caused the
exception so program execution can continue normally.

Notice that no exception variable is specified in the catch clause. Instead, only the type
of the exception (IndexOutOfRangeException in this case) is required. As mentioned, an
exception variable is needed only when access to the exception object is required. In some
cases, the value of the exception object can be used by the exception handler to obtain
additional information about the error, but in many cases, it is sufficient to simply know
that an exception occurred. Thus, it is not unusual for the catch variable to be absent in the
exception handler, as is the case in the preceding program.

As explained, if no exception is thrown by a try block, no catch will be executed and
program control resumes after the catch. To confirm this, in the preceding program, change
the for loop from

for(int i=0; i < 10; i++) {

to

for(int i=0; i < nums.Length; i++) {

Now, the loop does not overrun nums’ boundary. Thus, no exception is generated, and the
catch block is not executed.

*/

#endregion