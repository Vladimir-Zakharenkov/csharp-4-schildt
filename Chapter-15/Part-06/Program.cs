#region Russian

/*

Класс System.Delegate

Все делегаты и классы оказываются производными неявным образом от класса
System.Delegate. Как правило, членами этого класса не пользуются непосредственно,
и это не делается явным образом в данной книге. Но члены класса System.
Delegate могут оказаться полезными в ряде особых случаев.

Назначение делегатов

В предыдущих примерах был наглядно продемонстрирован внутренний механизм
действия делегатов, но эти примеры не показывают их истинное назначение. Как правило,
делегаты применяются по двум причинам. Во-первых, как упоминалось ранее
в этой главе, делегаты поддерживают события. И во-вторых, делегаты позволяют вызывать
методы во время выполнения программы, не зная о них ничего определенного
в ходе компиляции. Это очень удобно для создания базовой конструкции, допускающей
подключение отдельных программных компонентов. Рассмотрим в качестве
примера графическую программу, аналогичную стандартной сервисной программе
Windows Paint. С помощью делегата можно предоставить пользователю возможность
подключать специальные цветные фильтры или анализаторы изображений. Кроме
того, пользователь может составлять из этих фильтров или анализаторов целые последовательности.
Подобные возможности программы нетрудно обеспечить, используя делегаты.

Анонимные функции

Метод, на который ссылается делегат, нередко используется только для этой цели.
Иными словами, единственным основанием для существования метода служит то обстоятельство,
что он может быть вызван посредством делегата, но сам он не вызывается
вообще. В подобных случаях можно воспользоваться анонимной функцией, чтобы не
создавать отдельный метод. Анонимная функция, по существу, представляет собой
безымянный кодовый блок, передаваемый конструктору делегата. Преимущество анонимной
функции состоит, в частности, в ее простоте. Благодаря ей отпадает необходимость
объявлять отдельный метод, единственное назначение которого состоит в том,
что он передается делегату.

Начиная с версии 3.0, в C# предусмотрены две разновидности анонимных функций:
анонимные методы и лямбда-выражения. Анонимные методы были внедрены в C#
еще в версии 2.0, а лямбда-выражения — в версии 3.0. В целом лямбда-выражение совершенствует
принцип действия анонимного метода и в настоящее время считается
более предпочтительным для создания анонимной функции. Но анонимные методы
широко применяются в существующем коде С# и поэтому по-прежнему являются
важной составной частью С#. А поскольку анонимные методы предшествовали появлению
лямбда-выражений, то ясное представление о них позволяет лучше понять
особенности лямбда-выражений. К тому же анонимные методы могут быть использованы
в целом ряде случаев, где применение лямбда-выражений оказывается невозможным.
Именно поэтому в этой главе рассматриваются и анонимные методы, и лямбда-выражения.

Анонимные методы

Анонимный метод — один из способов создания безымянного блока кода, связанного
с конкретным экземпляром делегата. Для создания анонимного метода достаточно
указать кодовый блок после ключевого слова delegate. Покажем, как это делается,
на конкретном примере. В приведенной ниже программе анонимный метод служит
для подсчета от 0 до 5.

*/

// Продемонстрировать применение анонимного метода.

using System;

// Объявить тип делегата
delegate void CounIt();

class AnonMethDemo
{
    static void Main()
    {
        // Далее следует код для подсчета чисел, передаваемый делегату 
        // в качестве анонимного метода.
        CounIt count = delegate
        {
            // Этот кодовый блок передается делегату.
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine(i);
            };
        }; // Обратите внимание на точку с запятой

        count();

        Console.ReadKey();
    }
}

/*

В данной программе сначала объявляется тип делегата CountIt без параметров
и с возвращаемым типом void. Далее в методе Main() создается экземпляр count
делегата CountIt, которому передается кодовый блок, следующий после ключевого
слова delegate. Именно этот кодовый блок и является анонимным методом, который
будет выполняться при обращении к делегату count. Обратите внимание на то,
что после кодового блока следует точка с запятой, фактически завершающая оператор
объявления. Ниже приведен результат выполнения данной программы.

0
1
2
3
4
5

*/
#endregion

#region English

/*

System.Delegate

All delegates are classes that are implicitly derived from System.Delegate. You don’t normally
need to use its members directly, and this book makes no explicit use of System.Delegate.
However, its members may be useful in certain specialized situations.

Why Delegates

Although the preceding examples show the “how” behind delegates, they don’t really
illustrate the “why.” In general, delegates are useful for two main reasons. First, as shown
later in this chapter, delegates support events. Second, delegates give your program a way
to execute methods at runtime without having to know precisely what those methods are at
compile time. This ability is quite useful when you want to create a framework that allows
components to be plugged in. For example, imagine a drawing program (a bit like the
standard Windows Paint accessory). Using a delegate, you could allow the user to plug in
special color filters or image analyzers. Furthermore, the user could create a sequence of
these filters or analyzers. Such a scheme could be easily handled using a delegate.

Anonymous Functions

You will often find that the method referred to by a delegate is used only for that purpose.
In other words, the only reason for the method is so it can be invoked via a delegate. The
method is never called on its own. In such a case, you can avoid the need to create a
separate method by using an anonymous function. An anonymous function is, essentially, an
unnamed block of code that is passed to a delegate constructor. One advantage to using an
anonymous function is simplicity. There is no need to declare a separate method whose only
purpose is to be passed to a delegate.

Beginning with version 3.0, C# defines two types of anonymous functions: anonymous
methods and lambda expressions. The anonymous method was added by C# 2.0. The lambda
expression was added by C# 3.0. In general, the lambda expression improves on the concept
of the anonymous method and is now the preferred approach to creating an anonymous
function. However, anonymous methods are still used in legacy C# code. Therefore, it is
important to know how they work. Furthermore, anonymous methods are the precursor to
lambda expressions and a clear understanding of anonymous methods makes it easier to
understand aspects of the lambda expression. Also, there is a narrow set of cases in which
an anonymous method can be used, but a lambda expression cannot. Therefore, both
anonymous methods and lambda expressions are described in this chapter.

Anonymous Methods

An anonymous method is one way to create an unnamed block of code that is associated
with a specific delegate instance. An anonymous method is created by following the
keyword delegate with a block of code. To see how this is done, let’s begin with a simple
example. The following program uses an anonymous method that counts from 0 to 5.

*/

// Demonstrate an anonymous method. 

//using System;  

//// Declare a delegate type. 
//delegate void CountIt();

//class AnonMethDemo
//{

//    static void Main()
//    {

//        // Here, the code for counting is passed 
//        // as an anonymous method.     
//        CountIt count = delegate
//        {
//            // This is the block of code passed to the delegate. 
//            for (int i = 0; i <= 5; i++)
//                Console.WriteLine(i);
//        }; // notice the semicolon 

//        count();
//    }
//}

/*

This program first declares a delegate type called CountIt that has no parameters and
returns void. Inside Main(), a CountIt instance called count is created, and it is passed the
block of code that follows the delegate keyword. This block of code is the anonymous
method that will be executed when count is called. Notice that the block of code is followed
by a semicolon, which terminates the declaration statement. The output from the program is
shown here:

0
1
2
3
4
5

*/

#endregion