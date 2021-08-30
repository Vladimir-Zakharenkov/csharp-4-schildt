#region Russian

/*

 Применение вложенных операторов from

 Запрос может состоять из нескольких операторов from, которые оказываются в
 этом случае вложенными. Такие операторы from находят применение в тех случаях,
 когда по запросу требуется получить данные из двух разных источников. Рассмотрим
 простой пример, в котором два вложенных оператора from используются в запросе
 для циклического обращения к элементам двух разных массивов символов. В итоге
 по такому запросу формируется последовательность результатов, содержащая все возможные
 комбинации двух наборов символов.

*/

// Использовать два вложенных оператора from для составления списка
// всех возможных сочетаний букв А, В и С с буквами X, Y и Z.

using System;
using System.Linq;

//Этот класс содержит результат запроса.
class ChrPair
{
    public char First;
    public char Second;

    public ChrPair(char c, char c2)
    {
        First = c;
        Second = c2;
    }
}

class MultipleFroms
{
    static void Main()
    {
        char[] chrs = { 'A', 'B', 'C' };
        char[] chrs2 = { 'X', 'Y', 'Z' };

        //В первом операторе from организуется циклическое обращение
        //к массиву символов chrs, а во втором операторе from -
        //циклическое обращение к массиву символов chrs2.
        var pairs = from ch1 in chrs
                    from ch2 in chrs2
                    select new ChrPair(ch1, ch2);

        Console.WriteLine("Все сочетания букв ABC и XYZ: ");

        foreach (var p in pairs)
        {
            Console.WriteLine("{0} {1}", p.First, p.Second);
        }

        Console.ReadKey();
    }
}

/*

 Выполнение этого кода приводит к следующему результату.

 Все сочетания букв ABC и XYZ:
 А X
 A Y
 A Z
 В X
 В Y
 В Z
 С X
 С Y
 С Z

 Этот пример кода начинается с создания класса ChrPair, в котором содержатся
 результаты запроса. Затем в нем создаются два массива, chrs и chrs2, и, наконец,
 формируется следующий запрос для получения всех возможных комбинаций двух последовательностей
 результатов.

 var pairs = from ch1 in chrs
 from ch2 in chrs2
 select new ChrPair(ch1, ch2);

 Во вложенных операторах from организуется циклическое обращение к обоим
 массивам символов, chrs и chrs2. Сначала из массива chrs получается символ, сохраняемый
 в переменной ch1. Затем перечисляется содержимое массива chrs2. На
 каждом шаге циклического обращения во внутреннем операторе from символ из
 массива chrs2 сохраняется в переменной сh2 и далее выполняется оператор select.
 В результате выполнения оператора select создается новый объект типа ChrPair,
 содержащий пару символов, которые сохраняются в переменных ch1 и ch2 на каждом
 шаге циклического обращения к массиву во внутреннем операторе from. А в конечном
 итоге получается объект типа ChrPair, содержащий все возможные сочетания извлекаемых
 символов.

 Вложенные операторы from применяются также для циклического обращения к
 источнику данных, который содержится в другом источнике данных. Соответствующий
 пример приведен в разделе "Применение оператора let для создания временной
 переменной в запросе" далее в этой главе.

*/

#endregion

#region English

/*

Use Nested from Clauses

A query can contain more than one from clause. Thus, a query can contain nested from
clauses. One common use of a nested from clause is found when a query needs to obtain
data from two different sources. Here is a simple example. It uses two from clauses to
iterate over two different character arrays. It produces a sequence that contains all possible
combinations of the two sets of characters.

*/


// Use two from clauses to create a list of all 
// possible combinations of the letters A, B, and C 
// with the letters X, Y, and Z. 

//using System;  
//using System.Linq;  


//// This class holds the result of the query. 
//class ChrPair
//{
//    public char First;
//    public char Second;

//    public ChrPair(char c, char c2)
//    {
//        First = c;
//        Second = c2;
//    }
//}

//class MultipleFroms
//{
//    static void Main()
//    {

//        char[] chrs = { 'A', 'B', 'C' };
//        char[] chrs2 = { 'X', 'Y', 'Z' };

//        // Notice that the first from iterates over chrs and 
//        // the second from iterates over chrs2. 
//        var pairs = from ch1 in chrs
//                    from ch2 in chrs2
//                    select new ChrPair(ch1, ch2);

//        Console.WriteLine("All combinations of ABC with XYZ: ");

//        foreach (var p in pairs)
//            Console.WriteLine("{0} {1}", p.First, p.Second);
//    }
//}

/*

The output is shown here:

All combinations of ABC with XYZ:
A X
A Y
A Z
B X
B Y
B Z
C X
C Y
C Z

The program begins by creating a class called ChrPair that will hold the results of the
query. It then creates two character arrays, called chrs and chrs2. It uses the following query
to produce all possible combinations of the two sequences:

var pairs = from ch1 in chrs
from ch2 in chrs2
select new ChrPair(ch1, ch2);

The nested from clauses cause both chrs and chrs2 to be iterated over. Here is how it works.
First, a character is obtained from chrs and stored in ch1. Then, the chrs2 array is enumerated.
With each iteration of the inner from, a character from chrs2 is stored in ch2 and the select
clause is executed. The result of the select clause is a new object of type ChrPair that contains
the character pair ch1, ch2 produced by each iteration of the inner from. Thus, a ChrPair is
produced in which each possible combination of characters is obtained.

Another common use of a nested from is to iterate over a data source that is contained
within another data source. An example of this is found in the section, “Use let to Create
a Variable in a Query,” later in this chapter.

*/

#endregion