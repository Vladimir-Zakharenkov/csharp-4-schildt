#region Russian

/*

Ковариантность и контравариантность

Делегаты становятся еще более гибкими средствами программирования благодаря
двум свойствам: ковариантности и контравариантности. Как правило, метод, передаваемый
делегату, должен иметь такой же возвращаемый тип и сигнатуру, как и делегат.
Но в отношении производных типов это правило оказывается не таким строгим благодаря
ковариантности и контравариантности. В частности, ковариантность позволяет
присвоить делегату метод, возвращаемым типом которого служит класс, производный
от класса, указываемого в возвращаемом типе делегата. А контравариантность позволяет
присвоить делегату метод, типом параметра которого служит класс, являющийся
базовым для класса, указываемого в объявлении делегата.

Ниже приведен пример, демонстрирующий ковариантность и контравариантность.

*/

// Продемонстрировать ковариантность и контравариантность.

using System;

class X
{
    public int Val;
}

// Класс Y, производный от класса X.
class Y : X
{

}

// Этот делегат возвращает объект класса X и принимает объект класса Y в качестве параметра.
delegate X ChangeIt(Y obj);

class CoContraVariance
{
    // Этот метод возвращает объект класса X и имеет объект класса X в качестве параметра.
    static X IncrA(X obj)
    {
        X temp = new X();
        temp.Val = obj.Val + 1;
        return temp;
    }

    // Этот метод возвращает объект класса Y и имеет объект класса Y в качестве параметра.
    static Y IncrB(Y obj)
    {
        Y temp = new Y();
        temp.Val = obj.Val + 1;
        return temp;
    }

    static void Main()
    {
        Y Yob = new Y();
        // В данном случае параметром метода IncrA является объект класса X,
        // а параметром делегата ChangeIt - объект класса Y.
        // Но благодаря контравариантности следующая строка кода вполне допустима.
        ChangeIt change = IncrA;

        X Xob = change(Yob);

        Console.WriteLine("Xob: " + Xob.Val);

        // В этом случае возвращаемым типом метода IncrB служит объект класса Y,
        // а возвращаемым типом делегата ChangeIt - объект класса X.
        // Но благодаря ковариантности следующая строка кода оказывается вполне допустимой.
        change = IncrB;

        Yob = (Y)change(Yob);

        Console.WriteLine("Yob: " + Yob.Val);

        Console.ReadKey();
    }
}

/*

Вот к какому результату приводит выполнение этого кода.

Xob: 1
Yob: 1

В данном примере класс Y является производным от класса X. А делегат ChangeIt
объявляется следующим образом.

delegate X ChangeIt(Y obj);

Делегат возвращает объект класса X и принимает в качестве параметра объект класса
Y. А методы IncrA() и IncrB() объявляются следующим образом.

static X IncrA(X obj)
static Y IncrB(Y obj)

Метод IncrA() принимает объект класса X в качестве параметра и возвращает
объект того же класса. А метод IncrB() принимает в качестве параметра объект класса
Y и возвращает объект того же класса. Но благодаря ковариантности и контравариантности
любой из этих методов может быть передан делегату ChangeIt, что и демонстрирует
рассматриваемый здесь пример.

Таким образом, в строке

ChangeIt change = IncrA;

метод IncrA() может быть передан делегату благодаря контравариантности, так как
объект класса X служит в качестве параметра метода IncrA(), а объект класса Y —
в качестве параметра делегата ChangeIt. Но метод и делегат оказываются совместимыми
в силу контравариантности, поскольку типом параметра метода, передаваемого
делегату, служит класс, являющийся базовым для класса, указываемого в качестве типа
параметра делегата.

Приведенная ниже строка кода также является вполне допустимой, но на этот раз
благодаря ковариантности.

change = IncrB;

В данном случае возвращаемым типом для метода IncrB() служит класс Y, а для
делегата — класс X. Но поскольку возвращаемый тип метода является производным
классом от возвращаемого типа делегата, то оба оказываются совместимыми в силу
ковариантности.

*/

#endregion

#region English

/*

Covariance and Contravariance

There are two features that add flexibility to delegates: covariance and contravariance. Normally,
the method that you pass to a delegate must have the same return type and signature as the
delegate. However, covariance and contravariance relax this rule slightly, as it pertains to
derived types. Covariance enables a method to be assigned to a delegate when the method’s
return type is a class derived from the class specified by the return type of the delegate.
Contravariance enables a method to be assigned to a delegate when a method’s parameter
type is a base class of the class specified by the delegate’s declaration.

Here is an example that illustrates both covariance and contravariance:

*/

// Demonstrate covariance and contravariance. 

//using System;  

//class X
//{
//    public int Val;
//}

//// Y is derived from X. 
//class Y : X { }

//// This delegate returns X and takes a Y argument. 
//delegate X ChangeIt(Y obj);

//class CoContraVariance
//{

//    // This method returns X and has an X parameter. 
//    static X IncrA(X obj)
//    {
//        X temp = new X();
//        temp.Val = obj.Val + 1;
//        return temp;
//    }

//    // This method returns Y and has an Y parameter. 
//    static Y IncrB(Y obj)
//    {
//        Y temp = new Y();
//        temp.Val = obj.Val + 1;
//        return temp;
//    }

//    static void Main()
//    {
//        Y Yob = new Y();

//        // In this case, the parameter to IncrA 
//        // is X and the parameter to ChangeIt is Y. 
//        // Because of contravariance, the following 
//        // line is OK. 
//        ChangeIt change = IncrA;

//        X Xob = change(Yob);

//        Console.WriteLine("Xob: " + Xob.Val);

//        // In the next case, the return type of 
//        // IncrB is Y and the return type of  
//        // ChangeIt is X. Because of covariance, 
//        // the following line is OK. 
//        change = IncrB;

//        Yob = (Y)change(Yob);

//        Console.WriteLine("Yob: " + Yob.Val);

//        Console.ReadKey();
//    }
//}

/*

The output from the program is shown here:

Xob: 1
Yob: 1

In the program, notice that class Y is derived from class X. Next, notice that the delegate
ChangeIt is declared like this:

delegate X ChangeIt(Y obj);

ChangeIt returns X and has a Y parameter. Next, notice that the methods IncrA( ) and
IncrB( ) are declared as shown here:

static X IncrA(X obj)
static Y IncrB(Y obj)

The IncrA( ) method has an X parameter and returns X. The IncrB( ) method has a Y
parameter and returns Y. Given covariance and contravariance, either of these methods
can be passed to ChangeIt, as the program illustrates.

Therefore, this line

ChangeIt change = IncrA;

uses contravariance to enable IncrA( ) to be passed to the delegate because IncrA( ) has an X
parameter, but the delegate has a Y parameter. This works because, with contravariance, if
the parameter type of the method passed to a delegate is a base class of the parameter type
used by the delegate, then the method and the delegate are compatible.

The next line is also legal, but this time it is because of covariance:

change = IncrB;

In this case, the return type of IncrB( ) is Y, but the return type of ChangeIt is X. However,
because the return type of the method is a class derived from the return type of the delegate,
the two are compatible.

*/

#endregion