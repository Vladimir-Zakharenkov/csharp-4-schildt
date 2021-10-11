#region Russian

/*

Реализация интерфейсов

Как только интерфейс будет определен, он может быть реализован в одном или нескольких
классах. Для реализации интерфейса достаточно указать его имя после имени
класса, аналогично базовому классу. Ниже приведена общая форма реализации
интерфейса в классе.

class имя_класса : имя_интерфейса {
// тело класса
}

где имя_интерфейса — это конкретное имя реализуемого интерфейса. Если уж интерфейс
реализуется в классе, то это должно быть сделано полностью. В частности,
реализовать интерфейс выборочно и только по частям нельзя.

В классе допускается реализовывать несколько интерфейсов. В этом случае все реализуемые
в классе интерфейсы указываются списком через запятую. В классе можно
наследовать базовый класс и в тоже время реализовать один или более интерфейс.
В таком случае имя базового класса должно быть указано перед списком интерфейсов,
разделяемых запятой.

Методы, реализующие интерфейс, должны быть объявлены как public. Дело
в том, что в самом интерфейсе эти методы неявно подразумеваются как открытые,
поэтому их реализация также должна быть открытой. Кроме того, возвращаемый тип
и сигнатура реализуемого метода должны точно соответствовать возвращаемому типу
и сигнатуре, указанным в определении интерфейса.

Ниже приведен пример программы, в которой реализуется представленный ранее
интерфейс ISeries. В этой программе создается класс ByTwos, генерирующий
последовательный ряд чисел, в котором каждое последующее число на два больше
предыдущего.

*/

// Реализовать интерфейс ISeries.

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

/*

Как видите, в классе ByTwos реализуются три метода, определяемых в интерфейсе
ISeries. Как пояснялось выше, это приходится делать потому, что в классе нельзя
реализовать интерфейс частично.

*/

#endregion

#region English

/*

Implementing Interfaces

Once an interface has been defined, one or more classes can implement that interface. To
implement an interface, the name of the interface is specified after the class name in just
the same way that a base class is specified. The general form of a class that implements an
interface is shown here:

class class-name : interface-name {
// class-body
}

The name of the interface being implemented is specified in interface-name. When a class
implements an interface, the class must implement the entire interface. It cannot pick and
choose which parts to implement, for example.

A class can implement more than one interface. When a class implements more than one
interface, specify each interface in a comma-separated list. A class can inherit a base class
and also implement one or more interfaces. In this case, the name of the base class must
come first in the comma-separated list.

The methods that implement an interface must be declared public. The reason for this is
that methods are implicitly public within an interface, so their implementation must also be
public. Also, the return type and signature of the implementing method must match exactly
the return type and signature specified in the interface definition.

Here is an example that implements the ISeries interface shown earlier. It creates a class
called ByTwos, which generates a series of numbers, each two greater than the previous one.

*/

// Implement ISeries.

//class ByTwos : ISeries
//{
//    int start;
//    int val;
//    public ByTwos()
//    {
//        start = 0;
//        val = 0;
//    }
//    public int GetNext()
//    {
//        val += 2;
//        return val;
//    }
//    public void Reset()
//    {
//        val = start;
//    }
//    public void SetStart(int x)
//    {
//        start = x;
//        val = start;
//    }
//}

/*

As you can see, ByTwos implements all three methods defined by ISeries. As explained,
this is necessary since a class cannot create a partial implementation of an interface.

*/

#endregion


