#region Russian

/*

Использование модификаторов ref и out для ссылок на объекты

Применение модификаторов ref и out не ограничивается только передачей значений
обычных типов. С их помощью можно также передавать ссылки на объекты. Если
модификатор ref или out указывает на ссылку, то сама ссылка передается по ссылке.
Это позволяет изменить в методе объект, на который указывает ссылка. Рассмотрим в
качестве примера следующую программу, в которой ссылочные параметры типа ref
служат для смены объектов, на которые указывают ссылки.

*/

// Поменять местами две ссылки.
//using System;

//class RefSwap
//{
//    int a, b;

//    public RefSwap(int i, int j)
//    {
//        a = i;
//        b = j;
//    }

//    public void Show()
//    {
//        Console.WriteLine("a: {0}, b: {1}", a, b);
//    }

//    // Этот метод изменяет свои аргументы.
//    public void Swap(ref RefSwap ob1, ref RefSwap ob2)
//    {
//        RefSwap t;
//        t = ob1;
//        ob1 = ob2;
//        ob2 = t;
//    }
//}
//class RefSwapDemo
//{
//    static void Main()
//    {
//        RefSwap x = new RefSwap(1, 2);
//        RefSwap у = new RefSwap(3, 4);

//        Console.Write("x до вызова: ");
//        x.Show();

//        Console.Write("у до вызова: ");
//        у.Show();

//        Console.WriteLine();

//        // Смена объектов, на которые ссылаются аргументы х и у.
//        x.Swap(ref x, ref у);

//        Console.Write("х после вызова: ");
//        x.Show();

//        Console.Write("у после вызова: ");
//        у.Show();
//    }
//}

/*

При выполнении этой программы получается следующий результат.

х до вызова: а: 1, b: 2
у до вызова: а: 3, b: 4

х после вызова: а: 3, b: 4
у после вызова: а: 1, b: 2

В данном примере в методе Swap() выполняется смена объектов, на которые ссылаются
два его аргумента. До вызова метода Swap() аргумент х ссылается на объект,
содержащий значения 1 и 2, тогда как аргумент у ссылается на объект, содержащий
значения 3 и 4. А после вызова метода Swap() аргумент х ссылается на объект, содержащий
значения 3 и 4, тогда как аргумент у ссылается на объект, содержащий значения
1 и 2. Если бы не параметры типа ref, то перестановка в методе Swap() не имела
бы никаких последствий за пределами этого метода. Для того чтобы убедиться в этом,
исключите параметры типа ref из метода Swap().

*/

#endregion

#region English

/*

Use ref and out on References

The use of ref and out is not limited to the passing of value types. They can also be used
when a reference is passed. When ref or out modifies a reference, it causes the reference,
itself, to be passed by reference. This allows a method to change what object the reference
refers to. Consider the following program, which uses ref reference parameters to exchange
the objects to which two references are referring:

*/

// Swap two references.
using System;

class RefSwap
{
    int a, b;

    public RefSwap(int i, int j)
    {
        a = i;
        b = j;
    }

    public void Show()
    {
        Console.WriteLine("a: {0}, b: {1}", a, b);
    }

    // This method changes its arguments.
    public void Swap(ref RefSwap ob1, ref RefSwap ob2)
    {
        RefSwap t;
        t = ob1;
        ob1 = ob2;
        ob2 = t;
    }
}

class RefSwapDemo
{
    static void Main()
    {
        RefSwap x = new RefSwap(1, 2);
        RefSwap y = new RefSwap(3, 4);

        Console.Write("x before call: ");
        x.Show();

        Console.Write("y before call: ");
        y.Show();

        Console.WriteLine();

        // Exchange the objects to which x and y refer.
        x.Swap(ref x, ref y);

        Console.Write("x after call: ");
        x.Show();

        Console.Write("y after call: ");
        y.Show();
    }
}

/*

The output from this program is shown here:

x before call: a: 1, b: 2
y before call: a: 3, b: 4

x after call: a: 3, b: 4
y after call: a: 1, b: 2

In this example, the method Swap() exchanges the objects to which the two arguments to
Swap() refer. Before calling Swap(), x refers to an object that contains the values 1 and 2,
and y refers to an object that contains the values 3 and 4. After the call to Swap(), x refers to
the object that contains the values 3 and 4, and y refers to the object that contains the values
1 and 2. If ref parameters had not been used, then the exchange inside Swap() would have
had no effect outside Swap(). You might want to prove this by removing ref from Swap().

*/

#endregion