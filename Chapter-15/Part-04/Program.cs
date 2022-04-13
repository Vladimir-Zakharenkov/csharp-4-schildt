#region Russian

/*

Групповая адресация

Одним из самых примечательных свойств делегата является поддержка групповой
адресации. Попросту говоря, групповая адресация — это возможность создать список,
или цепочку вызовов, для методов, которые вызываются автоматически при обращении
к делегату. Создать такую цепочку нетрудно. Для этого достаточно получить экземпляр
делегата, а затем добавить методы в цепочку с помощью оператора + или +=.
Для удаления метода из цепочки служит оператор - или -=. Если делегат возвращает
значение, то им становится значение, возвращаемое последним методом в списке вызовов.
Поэтому делегат, в котором используется групповая адресация, обычно имеет
возвращаемый тип void.

Ниже приведен пример групповой адресации. Это переработанный вариант
предыдущих примеров, в котором тип значений, возвращаемых методами манипулирования
строками, изменен на void, а для возврата измененной строки в вызывающую
часть кода служит параметр типа ref. Благодаря этому методы оказываются более
приспособленными для групповой адресации.

*/

// Продемонстрировать групповую адресацию.

using System;

//Объявить тип делегата.
delegate void StrMod(ref string str);

class MultiCastDemo
{
    //Заменить пробелы дефисами.
    static void ReplaceSpaces(ref string s)
    {
        Console.WriteLine("Замена пробелов дефисами.");
        s = s.Replace(' ', '-');
    }

    //Удалить пробелы.
    static void RemoveSpaces(ref string s)
    {
        Console.WriteLine("Удаление пробелов.");
        string temp = "";

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
            {
                temp += s[i];
            }
        }

        s = temp;
    }

    //Обратить строку.
    static void Reverse(ref string s)
    {
        string temp = "";

        Console.WriteLine("Обращение строки.");
        for (int i = s.Length - 1; i >= 0; i--)
        {
            temp += s[i];
        }

        s = temp;
    }

    static void Main()
    {
        //Сконструировать делегаты.
        StrMod strOp;
        StrMod replaceSp = ReplaceSpaces;
        StrMod removeSp = RemoveSpaces;
        StrMod reverseStr = Reverse;

        string str = "Это простой тест.";

        //Организовать групповую адресацию.
        strOp = replaceSp;
        strOp += reverseStr;

        //Обратиться к делегату с групповой адресацией.
        strOp(ref str);
        Console.WriteLine("Результирующая строка: " + str);
        Console.WriteLine();

        //Удалить метод замены пробелов и добавить метод удаления пробелов
        strOp -= replaceSp;
        strOp += removeSp;
        str = "Это простой тест."; //восстановить исходную строку

        //Обратиться к делегату с групповой адресацией.
        strOp(ref str);
        Console.WriteLine("Результирующая строка: " + str);

        Console.ReadKey();
    }
}

/*

Выполнение этого кода приводит к следующему результату.

Замена пробелов дефисами.
Обращение строки.
Результирующая строка: .тсет-йотсорп-отЭ

Обращение строки.
Удаление пробелов.
Результирующая строка: .тсетйотсорпотЭ

В методе Main() из рассматриваемого здесь примера кода создаются четыре экземпляра
делегата. Первый из них, strOp, является пустым, а три остальных ссылаются на
конкретные методы видоизменения строки. Затем организуется групповая адресация
для вызова методов RemoveSpaces() и Reverse(). Это делается в приведенных ниже
строках кода.

strOp = replaceSp;
strOp += reverseStr

Сначала делегату strOp присваивается ссылка replaceSp, а затем с помощью оператора
+= добавляется ссылка reverseStr. При обращении к делегату strOp вызываются
оба метода, заменяя пробелы дефисами и обращая строку, как и показывает
приведенный выше результат.

Далее ссылка replaceSp удаляется из цепочки вызовов в следующей строке кода:

strOp -= replaceSp;

и добавляется ссылка removeSp в строке кода.

strOp += removeSp;

После этого вновь происходит обращение к делегату strOp. На этот раз обращается
строка с удаленными пробелами.

Цепочки вызовов являются весьма эффективным механизмом, поскольку они позволяют
определить ряд методов, выполняемых единым блоком. Благодаря этому
улучшается структура некоторых видов кода. Кроме того, цепочки вызовов имеют особое
значение для обработки событий, как станет ясно в дальнейшем.

*/

#endregion

#region English

/*

Multicasting

One of the most exciting features of a delegate is its support for multicasting. In simple
terms, multicasting is the ability to create an invocation list, or chain, of methods that will be
automatically called when a delegate is invoked. Such a chain is very easy to create. Simply
instantiate a delegate, and then use the + or += operator to add methods to the chain. To
remove a method, use – or – =. If the delegate returns a value, then the value returned by
the last method in the list becomes the return value of the entire delegate invocation. Thus,
a delegate that makes use of multicasting will often have a void return type.

Here is an example of multicasting. Notice that it reworks the preceding examples by
changing the string manipulation method’s return type to void and using a ref parameter to
return the altered string to the caller. This makes the methods more appropriate for multicasting.

*/

// Demonstrate multicasting.  

//using System; 

//// Declare a delegate type.  
//delegate void StrMod(ref string str);

//class MultiCastDemo
//{
//    // Replaces spaces with hyphens. 
//    static void ReplaceSpaces(ref string s)
//    {
//        Console.WriteLine("Replacing spaces with hyphens.");
//        s = s.Replace(' ', '-');
//    }

//    // Remove spaces. 
//    static void RemoveSpaces(ref string s)
//    {
//        string temp = "";
//        int i;

//        Console.WriteLine("Removing spaces.");
//        for (i = 0; i < s.Length; i++)
//            if (s[i] != ' ') temp += s[i];

//        s = temp;
//    }

//    // Reverse a string. 
//    static void Reverse(ref string s)
//    {
//        string temp = "";

//        Console.WriteLine("Reversing string.");
//        for (int i = s.Length - 1; i >= 0; i--)
//            temp += s[i];

//        s = temp;
//    }

//    static void Main()
//    {
//        // Construct delegates. 
//        StrMod strOp;
//        StrMod replaceSp = ReplaceSpaces;
//        StrMod removeSp = RemoveSpaces;
//        StrMod reverseStr = Reverse;
//        string str = "This is a test";

//        // Set up multicast. 
//        strOp = replaceSp;
//        strOp += reverseStr;

//        // Call multicast. 
//        strOp(ref str);
//        Console.WriteLine("Resulting string: " + str);
//        Console.WriteLine();

//        // Remove replace and add remove. 
//        strOp -= replaceSp;
//        strOp += removeSp;

//        str = "This is a test."; // reset string 

//        // Call multicast. 
//        strOp(ref str);
//        Console.WriteLine("Resulting string: " + str);

//        Console.ReadKey();
//    }
//}

/*

Here is the output:

Replacing spaces with hyphens.
Reversing string.
Resulting string: tset-a-si-sihT

Reversing string.
Removing spaces.
Resulting string: .tsetasisihT

In Main(), four delegate instances are created. One, strOp, is null. The other three refer to
specific string modification methods. Next, a multicast is created that calls RemoveSpaces()
and Reverse(). This is accomplished via the following lines:

strOp = replaceSp;
strOp += reverseStr;

First, strOp is assigned replaceSp. Next, using +=, reverseStr is added. When strOp
is invoked, both methods are invoked, replacing spaces with hyphens and reversing the
string, as the output illustrates.

Next, replaceSp is removed from the chain, using this line:

strOp -= replaceSp;

and removeSP is added using this line:

strOp += removeSp;

Then, strOp is again invoked. This time, spaces are removed and the string is reversed.

Delegate chains are a powerful mechanism because they allow you to define a set of
methods that can be executed as a unit. This can increase the structure of some types of
code. Also, as you will soon see, delegate chains have a special value to events.

 */

#endregion