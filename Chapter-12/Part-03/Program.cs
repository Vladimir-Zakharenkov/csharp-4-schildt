#region Russian

/*

Ниже приведен код класса, в котором демонстрируется применение класса ByTwos,
реализующего интерфейс ISeries.

*/

// Продемонстрировать применение класса ByTwos, реализующего интерфейс.

using System;

class SeriesDemo
{
    public interface ISeries
    {
        int GetNext(); // возвратить следующее по порядку число
        void Reset(); // перезапустить
        void SetStart(int х); // задать начальное значение
    }

    class ByTwos : ISeries
    {
        int start;
        int val;

        public ByTwos()
        {
            start = 0;
            val = 0;
        }

        public int GetNext()
        {
            val += 2;
            return val;
        }

        public void Reset()
        {
            val = start;
        }

        public void SetStart(int x)
        {
            start = x;
            val = start;
        }
    }

    static void Main()
    {
        ByTwos ob = new();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Следующее число равно " + ob.GetNext());
        }

        Console.WriteLine("\nСбросить\n");
        ob.Reset();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Следующее число равно " + ob.GetNext());
        }

        Console.WriteLine("\nНачать с числа 100\n");
        ob.SetStart(100);

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Следующее число равно " + ob.GetNext());
        }
    }
}

/*

Для того чтобы скомпилировать код класса SeriesDemo, необходимо включить
в компиляцию файлы, содержащие интерфейс ISeries, а также классы ByTwos и
SeriesDemo. Компилятор автоматически скомпилирует все три файла и сформирует
из них окончательный исполняемый файл. Так, если эти файлы называются ISeries.cs, 
ByTwos.cs и SeriesDemo.cs, то программа будет скомпилирована в следующей
командной строке:

>csc SeriesDemo.cs ISeries.cs ByTwos.cs

В интегрированной среде разработки Visual Studio для этой цели достаточно ввести
все три упомянутых выше файла в конкретный проект С#. Кроме того, все три компилируемых
элемента (интерфейс и оба класса) допускается включать в единый файл.

Ниже приведен результат выполнения скомпилированного кода.

Следующее число равно 2
Следующее число равно 4
Следующее число равно 6
Следующее число равно 8
Следующее число равно 10

Сбросить.

Следующее число равно 2
Следующее число равно 4
Следующее число равно 6
Следующее число равно 8
Следующее число равно 10

Начать с числа 100.

Следующее число равно 102
Следующее число равно 104
Следующее число равно 106
Следующее число равно 108
Следующее число равно 110

*/

#endregion

#region English

/*

Here is a class that demonstrates ByTwos:

*/

// Demonstrate the ISeries interface.
//using System;

//class SeriesDemo
//{
//    public interface ISeries
//    {
//        int GetNext(); // return next number in series
//        void Reset(); // restart
//        void SetStart(int x); // set starting value
//    }

//    class ByTwos : ISeries
//    {
//        int start;
//        int val;
//        public ByTwos()
//        {
//            start = 0;
//            val = 0;
//        }
//        public int GetNext()
//        {
//            val += 2;
//            return val;
//        }
//        public void Reset()
//        {
//            val = start;
//        }
//        public void SetStart(int x)
//        {
//            start = x;
//            val = start;
//        }
//    }

//    static void Main()
//    {
//        ByTwos ob = new();

//        for (int i = 0; i < 5; i++)
//            Console.WriteLine("Next value is " + ob.GetNext());

//        Console.WriteLine("\nResetting\n");
//        ob.Reset();

//        for (int i = 0; i < 5; i++)
//            Console.WriteLine("Next value is " + ob.GetNext());

//        Console.WriteLine("\nStarting at 100\n");
//        ob.SetStart(100);
//        for (int i = 0; i < 5; i++)
//            Console.WriteLine("Next value is " + ob.GetNext());
//    }
//}

/*

To compile SeriesDemo, you must include the files that contain ISeries, ByTwos, and
SeriesDemo in the compilation. The compiler will automatically compile all three files to
create the final executable. For example, if you called these files ISeries.cs, ByTwos.cs, and
SeriesDemo.cs, then the following command line will compile the program:

>csc SeriesDemo.cs ISeries.cs ByTwos.cs

If you are using the Visual Studio IDE, simply add all three files to your C# project. One
other point: It is perfectly valid to put all three of these classes in the same file, too.

The output from this program is shown here:

Next value is 2
Next value is 4
Next value is 6
Next value is 8
Next value is 10

Resetting

Next value is 2
Next value is 4
Next value is 6
Next value is 8
Next value is 10

Starting at 100

Next value is 102
Next value is 104
Next value is 106
Next value is 108
Next value is 110

*/

#endregion