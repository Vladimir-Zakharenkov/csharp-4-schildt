#region Russian

/*

Последствия неперехвата исключений

Перехват одного из стандартных исключений, как в приведенных выше примерах,
дает еще одно преимущество: он исключает аварийное завершение программы. Как
только исключение будет сгенерировано, оно должно быть перехвачено каким-то фрагментом
кода в определенном месте программы. Вообще говоря, если исключение не
перехватывается в программе, то оно будет перехвачено исполняющей системой. Но
дело в том, что исполняющая система выдаст сообщение об ошибке и прервет выполнение
программы. Так, в приведенном ниже примере программы исключение в связи
с выходом индекса за границы массива не перехватывается.

*/

// Предоставить исполняющей системе C# возможность самой обрабатывать ошибки.

using System;

class NotHandled
{
    static void Main()
    {
        int[] nums = new int[4];

        Console.WriteLine("До генерирования исключения");

        // Сгенерировать исключение в связи с выходом индекса за границы массива.
        for (int i = 0; i < 10; i++)
        {
            nums[i] = i;

            Console.WriteLine("nums[{0}] : {1}", i, nums[i]);
        }
    }
}

/*

Когда возникает ошибка индексирования массива, выполнение программы прерывается
и выдается следующее сообщение об ошибке.

Необработанное исключение: System.IndexOutOfRangeException:
Индекс находился вне границ массива.
в NotHandled.Main() в <имя_файла>:строка 16

Это сообщение уведомляет об обнаружении в методе NotHandled.Main() необработанного
исключения типа System.IndexOutOfRangeException, которое связано
с выходом индекса за границы массива.

Такие сообщения об ошибках полезны для отладки программы, но, по меньше
мере, нежелательны при ее использовании на практике! Именно поэтому так важно
организовать обработку исключительных ситуаций в самой программе.

*/

#endregion

#region English

/*

The Consequences of an Uncaught Exception

Catching one of the standard exceptions, as the preceding program does, has a side benefit:
It prevents abnormal program termination. When an exception is thrown, it must be caught
by some piece of code, somewhere. In general, if your program does not catch an exception,
it will be caught by the runtime system. The trouble is that the runtime system will report
an error and terminate the program. For instance, in this example, the index out-of-bounds
exception is not caught by the program:

*/

// Let the C# runtime system handle the error. 

//using System; 

//class NotHandled
//{
//    static void Main()
//    {
//        int[] nums = new int[4];

//        Console.WriteLine("Before exception is generated.");

//        // Generate an index out-of-bounds exception. 
//        for (int i = 0; i < 10; i++)
//        {
//            nums[i] = i;
//            Console.WriteLine("nums[{0}]: {1}", i, nums[i]);
//        }

//    }
//}

/*

When the array index error occurs, execution is halted and the following error message
is displayed:

Unhandled Exception: System.IndexOutOfRangeException:
Index was outside the bounds of the array.
at NotHandled.Main()

Although such a message is useful while debugging, you would not want others to see it, to
say the least! This is why it is important for your program to handle exceptions itself.

*/

#endregion