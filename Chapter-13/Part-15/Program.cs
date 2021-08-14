#region Russian

/*

Перехват исключений производных классов

При попытке перехватить типы исключений, относящихся как к базовым, так
и к производным классам, следует особенно внимательно соблюдать порядок следования
операторов catch, поскольку перехват исключения базового класса будет совпадать
с перехватом исключений любых его производных классов. Например, класс
Exception является базовым для всех исключений, и поэтому вместе с исключением
типа Exception могут быть перехвачены и все остальные исключения производных от
него классов. Конечно, для более четкого перехвата всех исключений можно воспользоваться
упоминавшейся ранее формой оператора catch без указания конкретного типа
исключения. Но вопрос перехвата исключений производных классов становится весьма
актуальным и в других ситуациях, особенно при создании собственных исключений.

Если требуется перехватывать исключения базового и производного классов, то
первым по порядку должен следовать оператор catch, перехватывающий исключение
производного класса. Это правило необходимо соблюдать потому, что при перехвате
исключения базового класса будут также перехвачены исключения всех производных
от него классов. Правда, это правило соблюдается автоматически: если первым расположить
в коде оператор catch, перехватывающий исключение базового класса, то
во время компиляции этого кода будет выдано сообщение об ошибке.

В приведенном ниже примере программы создаются два класса исключений:
ExceptA и ExceptB. Класс ExceptA является производным от класса Exception,
а класс ExceptB — производным от класса ExceptA. Затем в программе генерируются
исключения каждого типа. Ради краткости в классах специальных исключений предоставляется
только один конструктор, принимающий символьную строку, описывающую
исключение. Но при разработке программ коммерческого назначения в классах
специальных исключений обычно требуется предоставлять все четыре конструктора,
определяемых в классе Exception.

*/

// Исключения производных классов должны появляться до исключений базового класса.

using System;

// Создать класс исключения.
class ExceptA : Exception
{
    public ExceptA(string str) : base(str) { }

    public override string ToString()
    {
        return Message;
    }
}

// Создать класс исключения производный от класса ExceptA.
class ExceptB : ExceptA
{
    public ExceptB(string str) : base(str) { }
    public override string ToString()
    {
        return Message;
    }
}

class OrderMatters
{
    static void Main()
    {
        for (int x = 0; x < 3; x++)
        {
            try
            {
                if (x == 0)
                {
                    throw new ExceptA("Перехват исключения типа ExceptA");
                }
                else if (x == 1)
                {
                    throw new ExceptB("Перехват исключения типа ExceptB");
                }
                else { throw new Exception(); }
            }
            catch (ExceptB exc)
            {
                Console.WriteLine(exc);
            }
            catch (ExceptA exc)
            {
                Console.WriteLine(exc);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        Console.ReadKey();
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

Перехват исключения типа ExceptA.
Перехват исключения типа ExceptB.
System.Exception: Выдано исключение типа "System.Exception".
в OrderMatters.Main() в <имя_файла>:строка 36

Обратите внимание на порядок следования операторов catch. Именно в таком порядке
они и должны выполняться. Класс ExceptB является производным от класса
ExceptA, поэтому исключение типа ExceptB должно перехватываться до исключения
типа ExceptA. Аналогично, исключение типа Exception (т.е. базового класса для всех
исключений) должно перехватываться последним. Для того чтобы убедиться в этом,
измените порядок следования операторов catch. В итоге это приведет к ошибке во
время компиляции.

Полезным примером использования оператора catch, перехватывающего исключения
базового класса, служит перехват всей категории исключений. Допустим, что
создается ряд исключений для управления некоторым устройством. Если сделать их
классы производными от общего базового класса, то в тех приложениях, где необязательно
выяснять конкретную причину возникшей ошибки, достаточно перехватывать
исключение базового класса и тем самым исключить ненужное дублирование кода.

*/

#endregion

#region English

/*

Catching Derived Class Exceptions

You need to be careful how you order catch clauses when trying to catch exception types that
involve base and derived classes, because a catch for a base class will also match any of its
derived classes. For example, because the base class of all exceptions is Exception, catching
Exception catches all possible exceptions. Of course, using catch without an exception type
provides a cleaner way to catch all exceptions, as described earlier. However, the issue of
catching derived class exceptions is very important in other contexts, especially when you
create exceptions of your own.

If you want to catch exceptions of both a base class type and a derived class type, put
the derived class first in the catch sequence. This is necessary because a base class catch will
also catch all derived classes. Fortunately, this rule is self-enforcing because putting the base
class first causes a compile-time error.

The following program creates two exception classes called ExceptA and ExceptB.
ExceptA is derived from Exception. ExceptB is derived from ExceptA. The program then
throws an exception of each type. For brevity, the custom exceptions supply only one
constructor (which takes a string that describes the exception). But remember, in commercial
code, your custom exception classes will normally provide all four of the constructors
defined by Exception.

*/

// Derived exceptions must appear before base class exceptions. 

//using System; 

//// Create an exception. 
//class ExceptA : Exception
//{
//    public ExceptA(string message) : base(message) { }

//    public override string ToString()
//    {
//        return Message;
//    }
//}

//// Create an exception derived from ExceptA 
//class ExceptB : ExceptA
//{
//    public ExceptB(string message) : base(message) { }

//    public override string ToString()
//    {
//        return Message;
//    }
//}

//class OrderMatters
//{
//    static void Main()
//    {
//        for (int x = 0; x < 3; x++)
//        {
//            try
//            {
//                if (x == 0) throw new ExceptA("Caught an ExceptA exception");
//                else if (x == 1) throw new ExceptB("Caught an ExceptB exception");
//                else throw new Exception();
//            }
//            catch (ExceptB exc)
//            {
//                Console.WriteLine(exc);
//            }
//            catch (ExceptA exc)
//            {
//                Console.WriteLine(exc);
//            }
//            catch (Exception exc)
//            {
//                Console.WriteLine(exc);
//            }
//        }

//        Console.ReadKey();
//    }
//}

/*

The output from the program is shown here:

Caught an ExceptA exception
Caught an ExceptB exception
System.Exception: Exception of type 'System.Exception' was thrown.
at OrderMatters.Main()

Notice the type and order of the catch clauses. This is the only order in which they can
occur. Since ExceptB is derived from ExceptA, the catch for ExceptB must be before the one
for ExceptA. Similarly, the catch for Exception (which is the base class for all exceptions)
must appear last. To prove this point for yourself, try rearranging the catch clauses. Doing
so will result in a compile-time error.

One good use of a base class catch clause is to catch an entire category of exceptions. For
example, imagine you are creating a set of exceptions for some device. If you derive all of
the exceptions from a common base class, then applications that don’t need to know precisely
what problem occurred could simply catch the base class exception, avoiding the unnecessary
duplication of code.

*/

#endregion