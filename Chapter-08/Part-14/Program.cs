#region Russian

/*

Разумеется, никаких ограничений на применение параметров out в одном методе
не существует. С их помощью из метода можно возвратить сколько угодно фрагментов
информации. Рассмотрим пример применения двух параметров out. В этом примере
программы метод HasComFactor() выполняет две функции. Во-первых, он определяет
общий множитель (кроме 1) для двух целых чисел, возвращая логическое значение
true, если у них имеется общий множитель, а иначе — логическое значение false.
И во-вторых, он возвращает посредством параметров типа out наименьший и наибольший
общий множитель двух чисел, если таковые обнаруживаются.

*/

// Использовать два параметра типа out.
//using System;

//class Num
//{
//    /* Определить, имеется ли у числовых значений переменных х и y
//    общий множитель. Если имеется, то возвратить наименьший и
//    наибольший множители посредством параметров типа out. */
//    public bool HasComFactor(int x, int y, out int least, out int greatest)
//    {
//        int i;

//        int max = x < y ? x : y;

//        bool first = true;

//        least = 1;
//        greatest = 1;

//        // Найти наименьший и наибольший общий множитель.
//        for (i = 2; i <= max / 2 + 1; i++)
//        {
//            if (((y % i) == 0) & ((x % i) == 0))
//            {
//                if (first)
//                {
//                    least = i;
//                    first = false;
//                }
//                greatest = i;
//            }
//        }

//        if (least != 1) return true;
//        else return false;
//    }
//}
//class DemoOut
//{
//    static void Main()
//    {
//        Num ob = new Num();

//        int lcf, gcf;

//        if (ob.HasComFactor(231, 105, out lcf, out gcf))
//        {
//            Console.WriteLine("Наименьший общий множитель " + "чисел 231 и 105 равен " + lcf);
//            Console.WriteLine("Наибольший общий множитель " + "чисел 231 и 105 равен " + gcf);
//        }
//        else
//            Console.WriteLine("Общий множитель у чисел 231 и 105 отсутствует.");

//        if (ob.HasComFactor(35, 51, out lcf, out gcf))
//        {
//            Console.WriteLine("Наименьший общий множитель " +
//            "чисел 35 и 51 равен " + lcf);
//            Console.WriteLine("Наибольший общий множитель " +
//            "чисел 35 и 51 равен " + gcf);
//        }
//        else
//            Console.WriteLine("Общий множитель у чисел 35 и 51 отсутствует.");
//    }
//}

/*

Обратите внимание на то, что значения не присваиваются переменным lcf и gcf
в методе Main() до вызова метода HasComFactor(). Если бы параметры метода
HasComFactor() были типа ref, а не out, это привело бы к ошибке. Данный метод
возвращает логическое значение true или false, в зависимости от того, имеется ли
общий множитель у двух целых чисел. Если он имеется, то посредством параметров
типа out возвращаются наименьший и наибольший общий множитель этих чисел.

Ниже приведен результат выполнения данной программы.

Наименьший общий множитель чисел 231 и 105 равен 3
Наибольший общий множитель чисел 231 и 105 равен 21
Общий множитель у чисел 35 и 51 отсутствует.

*/

#endregion

#region English

/*

Of course, you are not limited to only one out parameter. A method can return as many
pieces of information as necessary through out parameters. Here is an example that uses
two out parameters. The method HasComFactor() performs two functions. First, it determines
if two integers have a common factor (other than 1). It returns true if they do and false
otherwise. Second, if they do have a common factor, HasComFactor() returns the least and
greatest common factors in out parameters.

*/

// Use two out parameters.
using System;

class Num
{
    /* Determine if x and v have a common divisor.
    If so, return least and greatest common factors in
    the out parameters. */
    public bool HasComFactor(int x, int y, out int least, out int greatest)
    {
        int i;

        int max = x < y ? x : y;

        bool first = true;
        least = 1;
        greatest = 1;

        // Find least and greatest common factors.
        for (i = 2; i <= max / 2 + 1; i++)
        {
            if (((y % i) == 0) & ((x % i) == 0))
            {
                if (first)
                {
                    least = i;
                    first = false;
                }
                greatest = i;
            }
        }

        if (least != 1) return true;
        else return false;
    }
}
class DemoOut
{
    static void Main()
    {
        Num ob = new Num();

        int lcf, gcf;

        if (ob.HasComFactor(231, 105, out lcf, out gcf))
        {
            Console.WriteLine("Lcf of 231 and 105 is " + lcf);
            Console.WriteLine("Gcf of 231 and 105 is " + gcf);
        }
        else
            Console.WriteLine("No common factor for 231 and 105.");
        if (ob.HasComFactor(35, 51, out lcf, out gcf))
        {
            Console.WriteLine("Lcf of 35 and 51 " + lcf);
            Console.WriteLine("Gcf of 35 and 51 is " + gcf);
        }
        else
            Console.WriteLine("No common factor for 35 and 51.");
    }
}

/*

In Main(), notice that lcf and gcf are not assigned values prior to the call to
HasComFactor( ). This would be an error if the parameters had been ref rather than
out. The method returns either true or false, depending upon whether the two integers
have a common factor. If they do, the least and greatest common factors are returned
in the out parameters. The output from this program is shown here:

Lcf of 231 and 105 is 3
Gcf of 231 and 105 is 21
No common factor for 35 and 51.

*/

#endregion