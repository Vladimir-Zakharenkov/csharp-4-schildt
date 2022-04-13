#region Russian

/*

 Деревья выражений

 Еще одним средством, связанным с LINQ, является дерево выражений, которое представляет
 лямбда-выражение в виде данных. Это означает, что само лямбда-выражение
 нельзя выполнить, но можно преобразовать в исполняемую форму. Деревья выражений
 инкапсулируются в классе System.Linq.Expressions.Expression<TDelegate>.
 Они оказываются пригодными в тех случаях, когда запрос выполняется вне программы,
 например средствами SQL в базе данных. Если запрос представлен в виде данных,
 то его можно преобразовать в формат, понятный для базы данных. Этот процесс выполняется,
 например, средствами LINQ to SQL в интегрированной среде разработки
 Visual Studio. Таким образом, деревья выражений способствуют поддержке в C# различных
 баз данных.

 Для получения исполняемой формы дерева выражений достаточно вызвать метод
 Compile(), определенный в классе Expression. Этот метод возвращает ссылку, которая
 может быть присвоена делегату для последующего выполнения. А тип делегата
 может быть объявлен собственным или же одним из предопределенных типов делегата
 Func в пространстве имен System. Две формы делегата Func уже упоминались
 ранее при рассмотрении методов запроса, но существует и другие его формы.

 Деревьям выражений присуще следующее существенное ограничение: они могут
 представлять только одиночные лямбда-выражения. С их помощью нельзя представить
 блочные лямбда-выражения.

 Ниже приведен пример программы, демонстрирующий конкретное применение
 дерева выражений. В этой программе сначала создается дерево выражений, данные
 которого представляют метод, определяющий, является ли одно целое число множителем
 другого. Затем это дерево выражений компилируется в исполняемый код. И наконец,
 в этой программе демонстрируется выполнение скомпилированного кода.

*/

// Пример простого дерева выражений.

using System;
using System.Linq;
using System.Linq.Expressions;

class SimpleExpTree
{
    static void Main()
    {
        //Представить лямбда-выражение в виде данных.
        Expression<Func<int, int, bool>> IsFactorExp = (n, d) => (d != 0) ? (n % d) == 0 : false;

        //Скомпилировать данные выражения в исполняемый код.
        Func<int, int, bool> IsFactor = IsFactorExp.Compile();

        //Выполнить выражение.
        if (IsFactor(10, 5))
        {
            Console.WriteLine("Число 5 является множителем 10.");
        }

        if (IsFactor(10, 7))
        {
            Console.WriteLine("Число 7 является множителем 10.");
        }
        else
        {
            Console.WriteLine("Число 7 не является множителем 10.");
        }

        Console.ReadKey();
    }
}

/*

 Вот к какому результату приводит выполнение этой программы.

 Число 5 является множителем 10.
 Число 7 не является множителем 10.

 Данный пример программы наглядно показывает два основных этапа применения
 дерева выражений. Сначала в ней создается дерево выражений с помощью следующего оператора.

 Expression<Func<int, int, bool>> IsFactorExp = (n, d) => (d != 0) ? (n % d) == 0 : false;

 В этом операторе конструируется представление лямбда-выражения в оперативной
 памяти. Как пояснялось выше, это представление доступно по ссылке, присваиваемой
 делегату IsFactorExp. А в следующем операторе данные выражения преобразуются
 в исполняемый код.

Func<int, int, bool> IsFactor = IsFactorExp.Compile();

 После выполнения этого оператора делегат IsFactorExp может быть вызван, чтобы
 определить, является ли одно целое число множителем другого.

 Обратите также внимание на то, что <Func<int, int, bool> обозначает тип
 делегата. В этой форме делегата Func указываются два параметра типа int и возвращаемый
 тип bool. В рассматриваемой здесь программе использована именно эта
 форма делегата Func, совместимая с лямбда-выражениями, поскольку для выражения
 требуются два параметра. Для других лямбда-выражений могут подойти иные
 формы делегата Func в зависимости от количества требуемых параметров. Вообще
 говоря, конкретная форма делегата Func должна удовлетворять требованиям лямбда-выражения.

*/

#endregion

#region English

/*

Expression Trees

Another LINQ-related feature is the expression tree. An expression tree is a representation
of a lambda expression as data. Thus, an expression tree, itself, cannot be executed. It can,
however, be converted into an executable form. Expression trees are encapsulated by the
System.Linq.Expressions.Expression<TDelegate> class. Expression trees are useful in
situations in which a query will be executed by something outside the program, such as a
database that uses SQL. By representing the query as data, the query can be converted into a
format understood by the database. This process is used by the LINQ to SQL feature provided
by Visual C#, for example. Thus, expression trees help C# support a variety of data sources.

You can obtain an executable form of an expression tree by calling the Compile()
method defined by Expression. It returns a reference that can be assigned to a delegate and
then executed. You can declare your own delegate type or use one of the predefined Func
delegate types defined within the System namespace. Two forms of the Func delegate were
mentioned earlier, when the query methods were described, but there are several others.

Expression trees have one key restriction: Only expression lambdas can be represented
by expression trees. They cannot be used to represent statement lambdas.

Here is a simple example of an expression tree in action. It creates an expression tree
whose data represents a method that determines if one integer is a factor of another. It then
compiles the expression tree into executable code. Finally, it demonstrates the compiled code.

*/

// A simple expression tree.

//using System;  
//using System.Linq;  
//using System.Linq.Expressions;  

//class SimpleExpTree
//{
//    static void Main()
//    {

//        // Represent a lambda expression as data. 
//        Expression<Func<int, int, bool>>
//          IsFactorExp = (n, d) => (d != 0) ? (n % d) == 0 : false;

//        // Compile the expression data into executable code. 
//        Func<int, int, bool> IsFactor = IsFactorExp.Compile();

//        // Execute the expression. 
//        if (IsFactor(10, 5))
//            Console.WriteLine("5 is a factor of 10.");

//        if (!IsFactor(10, 7))
//            Console.WriteLine("7 is not a factor of 10.");

//        Console.ReadKey();
//    }
//}

/*

The output is shown here:

5 is a factor of 10.
7 is not a factor of 10.

The program illustrates the two key steps in using an expression tree. First, it creates an
expression tree by using this statement:

Expression<Func<int, int, bool>>
IsFactorExp = (n, d) => (d != 0) ? (n % d) == 0 : false;

This constructs a representation of a lambda expression in memory. As explained, this
representation is data, not code. This representation is referred to by IsFactorExp. The
following statement converts the expression data into executable code:

Func<int, int, bool> IsFactor = IsFactorExp.Compile();

After this statement executes, the IsFactor delegate can be called to determine if one value is
a factor of another.

One other point: Notice that Func<int, int, bool> indicates the delegate type. This form
of Func specifies two parameters of type int and a return type of bool. This is the form of
Func that is compatible with the lambda expression used in the program because that
expression requires two parameters. Other lambda expressions may require different forms
of Func, based on the number of parameters they require. In general, the specific form of
Func must match the requirements of the lambda expression.

*/

#endregion