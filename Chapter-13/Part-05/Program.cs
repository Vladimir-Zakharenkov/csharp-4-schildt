#region Russian

/*

Обработка исключительных ситуаций - “изящный” способ устранения программных ошибок

Одно из главных преимуществ обработки исключительных ситуаций заключается
в том, что она позволяет вовремя отреагировать на ошибку в программе и затем продолжить
ее выполнение. В качестве примера рассмотрим еще одну программу, в которой
элементы одного массива делятся на элементы другого. Если при этом происходит
деление на нуль, то генерируется исключение DivideByZeroException. Обработка
подобной исключительной ситуации заключается в том, что программа уведомляет
об ошибке и затем продолжает свое выполнение. Таким образом, попытка деления
на нуль не приведет к аварийному завершению программы из-за ошибки при ее выполнении.
Вместо этого ошибка обрабатывается "изящно", не прерывая выполнение
программы.

*/

// Изящно обработать исключительную ситуацию и продолжить выполнение программы.
using System;

class ExcDemo3
{
    static void Main()
    {
        int[] numer = { 4, 8, 16, 32, 64, 128 };
        int[] denom = { 2, 0, 4, 4, 0, 8 };

        for (int i = 0; i < numer.Length; i++)
        {
            try
            {
                Console.WriteLine(numer[i] + " / " + denom[i] + " равно " + numer[i] / denom[i]);
            }
            catch (DivideByZeroException)
            {
                // Перехватить исключение.
                Console.WriteLine("Делить на ноль нельзя!");
            }
        }

        Console.ReadKey();
    }
}

/*

Ниже приведен результат выполнения этой программы.

4/2 равно 2
Делить на нуль нельзя!
16/4 равно 4
32/4 равно 8
Делить на нуль нельзя!
128 / 8 равно 16

Из данного примера следует еще один важный вывод: как только исключение обработано,
оно удаляется из системы. Поэтому в приведенной выше программе проверка
ошибок в блоке try начинается снова на каждом шаге цикла for, при условии, что все
предыдущие исключительные ситуации были обработаны. Это позволяет обрабатывать
в программе повторяющиеся ошибки.

*/

#endregion

#region English

/*

Exceptions Let You Handle Errors Gracefully

One of the key benefits of exception handling is that it enables your program to respond
to an error and then continue running. For example, consider the following example that
divides the elements of one array by the elements of another. If a division-by-zero occurs, a
DivideByZeroException is generated. In the program, this exception is handled by reporting
the error and then continuing with execution. Thus, attempting to divide by zero does not
cause an abrupt runtime error resulting in the termination of the program. Instead, it is
handled gracefully, allowing program execution to continue.

*/

// Handle error gracefully and continue. 

//using System; 

//class ExcDemo3
//{
//    static void Main()
//    {
//        int[] numer = { 4, 8, 16, 32, 64, 128 };
//        int[] denom = { 2, 0, 4, 4, 0, 8 };

//        for (int i = 0; i < numer.Length; i++)
//        {
//            try
//            {
//                Console.WriteLine(numer[i] + " / " +
//                                  denom[i] + " is " +
//                                  numer[i] / denom[i]);
//            }
//            catch (DivideByZeroException)
//            {
//                // Catch the exception. 
//                Console.WriteLine("Can't divide by Zero!");
//            }
//        }
//    }
//}

/*

The output from the program is shown here:

4 / 2 is 2
Can't divide by Zero!
16 / 4 is 4
32 / 4 is 8
Can't divide by Zero!
128 / 8 is 16

This example makes another important point: Once an exception has been handled, it is
removed from the system. Therefore, in the program, each pass through the loop enters the
try block anew—any prior exceptions have been handled. This enables your program to
handle repeated errors.

*/

#endregion