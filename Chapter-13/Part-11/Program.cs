#region Russian

/*

Использование блока finally

Иногда требуется определить кодовый блок, который будет выполняться после выхода
из блока try/catch. В частности, исключительная ситуация может возникнуть
в связи с ошибкой, приводящей к преждевременному возврату из текущего метода.
Но в этом методе мог быть открыт файл, который нужно закрыть, или же установлено
сетевое соединение, требующее разрывания. Подобные ситуации нередки в программировании,
и поэтому для их разрешения в C# предусмотрен удобный способ: воспользоваться
блоком finally.

Для того чтобы указать кодовый блок, который должен выполняться после блока
try/catch, достаточно вставить блок finally в конце последовательности операторов
try/catch. Ниже приведена общая форма совместного использования блоков try/
catch и finally.

try {
// Блок кода, предназначенный для обработки ошибок.
}
catch (ExcepType1 exOb) {
// Обработчик исключения типа ExcepType1.
}
catch (ExcepType2 ехОb) {
// Обработчик исключения типа ЕхсерТуре2.
}
finally {
// Код завершения обработки исключений.
}

Блок finally будет выполняться всякий раз, когда происходит выход из блока try/
catch, независимо от причин, которые к этому привели. Это означает, что если блок
try завершается нормально или по причине исключения, то последним выполняется
код, определяемый в блоке finally. Блок finally выполняется и в том случае, если
любой код в блоке try или в связанных с ним блоках catch приводит к возврату из
метода.

Ниже приведен пример применения блока finally.

*/

// Использовать блок finally.

using System;

class UseFinally
{
    public static void GenException(int what)
    {
        int t;
        int[] nums = new int[2];

        Console.WriteLine("Получить " + what);

        try
        {
            switch (what)
            {
                case 0:
                    t = 10 / what; // сгенерировать ошибку из-за деления на ноль
                    break;
                case 1:
                    nums[4] = 4; // сгенерировать ошибку индексирования массива
                    break;
                case 2:
                    return; // возврат из блока try
            }
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Делить на ноль нельзя!");
            return; // возврат из блока catch
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Совпадающий элемент не найден.");
        }
        finally
        {
            Console.WriteLine("После выхода из блока try.");
        }
    }
}

class FinalllyDemo
{
    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            UseFinally.GenException(i);
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}

/*

Вот к какому результату приводит выполнение этой программы.

Получить 0
Делить на нуль нельзя
После выхода из блока try.

Получить 1
Совпадающий элемент не найден.
После выхода из блока try.

Получить 2
После выхода из блока try.

Как следует из приведенного выше результата, блок finally выполняется независимо
от причины выхода из блока try.

И еще одно замечание: с точки зрения синтаксиса блок finally следует после блока
try, и формально блоки catch для этого не требуются. Следовательно, блок finally
можно ввести непосредственно после блока try, опустив блоки catch. В этом случае
блок finally начнет выполняться сразу же после выхода из блока try, но исключения
обрабатываться не будут.

*/

#endregion

#region English

/*

Using finally

Sometimes you will want to define a block of code that will execute when a try/catch block
is left. For example, an exception might cause an error that terminates the current method,
causing its premature return. However, that method may have opened a file or a network
connection that needs to be closed. Such types of circumstances are common in programming,
and C# provides a convenient way to handle them: finally.

To specify a block of code to execute when a try/catch block is exited, include a finally
block at the end of a try/catch sequence. The general form of a try/catch that includes
finally is shown here:

try {
// block of code to monitor for errors
}
catch (ExcepType1 exOb) {
// handler for ExcepType1
}
catch (ExcepType2 exOb) {
// handler for ExcepType2
}...
finally {
// finally code
}

The finally block will be executed whenever execution leaves a try/catch block, no
matter what conditions cause it. That is, whether the try block ends normally, or because
of an exception, the last code executed is that defined by finally. The finally block is also
executed if any code within the try block or any of its catch blocks returns from the method.

Here is an example of finally:

*/

// Use finally. 

//using System; 

//class UseFinally
//{
//    public static void GenException(int what)
//    {
//        int t;
//        int[] nums = new int[2];

//        Console.WriteLine("Receiving " + what);
//        try
//        {
//            switch (what)
//            {
//                case 0:
//                    t = 10 / what; // generate div-by-zero error 
//                    break;
//                case 1:
//                    nums[4] = 4; // generate array index error. 
//                    break;
//                case 2:
//                    return; // return from try block 
//            }
//        }
//        catch (DivideByZeroException)
//        {
//            Console.WriteLine("Can't divide by Zero!");
//            return; // return from catch 
//        }
//        catch (IndexOutOfRangeException)
//        {
//            Console.WriteLine("No matching element found.");
//        }
//        finally
//        {
//            Console.WriteLine("Leaving try.");
//        }
//    }
//}

//class FinallyDemo
//{
//    static void Main()
//    {

//        for (int i = 0; i < 3; i++)
//        {
//            UseFinally.GenException(i);
//            Console.WriteLine();
//        }
//    }
//}

/*

Here is the output produced by the program:

Receiving 0
Can't divide by Zero!
Leaving try.

Receiving 1
No matching element found.
Leaving try.

Receiving 2
Leaving try.

As the output shows, no matter how the try block is exited, the finally block is executed.

One other point: Syntactically, when a finally block follows a try block, no catch clauses
are technically required. Thus, you can have a try followed by a finally with no catch
clauses. In this case, the finally block is executed when the try exits, but no exceptions
are handled.

*/

#endregion