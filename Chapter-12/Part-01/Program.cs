#region Russian

/*

12 ГЛАВА

Интерфейсы, структуры и перечисления

В этой главе рассматривается одно из самых важных
в C# средств: интерфейс, определяющий ряд методов
для реализации в классе. Но поскольку в самом интерфейсе
ни один из методов не реализуется, интерфейс
представляет собой чисто логическую конструкцию, описывающую
функциональные возможности без конкретной их реализации.

Кроме того, в этой главе представлены еще два типа
данных С#: структуры и перечисления. Структуры подобны
классам, за исключением того, что они трактуются как
типы значений, а не ссылочные типы. А перечисления представляют
собой перечни целочисленных констант. Структуры
и перечисления расширяют богатый арсенал средств
программирования на С#.

Интерфейсы

Иногда в объектно-ориентированном программировании
полезно определить, что именно должен делать
класс, но не как он должен это делать. Примером тому может
служить упоминавшийся ранее абстрактный метод.
В абстрактном методе определяются возвращаемый тип
и сигнатура метода, но не предоставляется его реализация.
А в производном классе должна быть обеспечена своя собственная
реализация каждого абстрактного метода, определенного
в его базовом классе. Таким образом, абстрактный
метод определяет интерфейс, но не реализацию метода. Конечно,
абстрактные классы и методы приносят известную
пользу, но положенный в их основу принцип может быть
развит далее. В C# предусмотрено разделение интерфейса класса и его реализации с
помощью ключевого слова interface.

С точки зрения синтаксиса интерфейсы подобны абстрактным классам. Но в интерфейсе
ни у одного из методов не должно быть тела. Это означает, что в интерфейсе вообще
не предоставляется никакой реализации. В нем указывается только, что именно
следует делать, но не как это делать. Как только интерфейс будет определен, он может
быть реализован в любом количестве классов. Кроме того, в одном классе может быть
реализовано любое количество интерфейсов.

Для реализации интерфейса в классе должны быть предоставлены тела (т.е. конкретные
реализации) методов, описанных в этом интерфейсе. Каждому классу предоставляется
полная свобода для определения деталей своей собственной реализации
интерфейса. Следовательно, один и тот же интерфейс может быть реализован в двух
классах по-разному. Тем не менее в каждом из них должен поддерживаться один и тот
же набор методов данного интерфейса. А в том коде, где известен такой интерфейс,
могут использоваться объекты любого из этих двух классов, поскольку интерфейс для
всех этих объектов остается одинаковым. Благодаря поддержке интерфейсов в C# может
быть в полной мере реализован главный принцип полиморфизма: один интерфейс
— множество методов.

Интерфейсы объявляются с помощью ключевого слова interface. Ниже приведена
упрощенная форма объявления интерфейса.

interface имя{
возвращаемый_тип имя_метода1(список_параметров);
возвращаемый_тип имя_метода2(список_параметров);
// ...
возвращаемый_тип имя_методаN{список_параметров);
}

где имя — это конкретное имя интерфейса. В объявлении методов интерфейса используются
только их возвращаемый_тип и сигнатура. Они, по существу, являются
абстрактными методами. Как пояснялось выше, в интерфейсе не может быть никакой
реализации. Поэтому все методы интерфейса должны быть реализованы в каждом
классе, включающем в себя этот интерфейс. В самом же интерфейсе методы неявно
считаются открытыми, поэтому доступ к ним не нужно указывать явно.

Ниже приведен пример объявления интерфейса для класса, генерирующего последовательный
ряд чисел.

*/

public interface ISeries
{
    int GetNext(); // возвратить следующее по порядку число
    void Reset(); // перезапустить
    void SetStart(int х); // задать начальное значение
}

/*

Этому интерфейсу присваивается имя ISeries. Префикс I в имени интерфейса
указывать необязательно, но это принято делать в практике программирования, чтобы
как-то отличать интерфейсы от классов. Интерфейс ISeries объявляется как public
и поэтому может быть реализован в любом классе какой угодно программы.

Помимо методов, в интерфейсах можно также указывать свойства, индексаторы и
события. Подробнее о событиях речь пойдет в главе 15, а в этой главе основное внимание
будет уделено методам, свойствам и индексаторам. Интерфейсы не могут содержать
члены данных. В них нельзя также определить конструкторы, деструкторы
или операторные методы. Кроме того, ни один из членов интерфейса не может быть
объявлен как static.

*/

#endregion


#region English

/*

12 CHAPTER

Interfaces, Structures, and Enumerations

 This chapter discusses one of C#’s most important features: the interface. An interface
defines a set of methods that will be implemented by a class. An interface does not,
itself, implement any method. Thus, an interface is a purely logical construct that
describes functionality without specifying implementation.

Also discussed in this chapter are two more C# data types: structures and enumerations.
Structures are similar to classes except that they are handled as value types rather than
reference types. Enumerations are lists of named integer constants. Structures and enumerations
contribute to the richness of the C# programming environment.

Interfaces

In object-oriented programming it is sometimes helpful to define what a class must do, but
not how it will do it. You have already seen an example of this: the abstract method. An
abstract method declares the return type and signature for a method, but provides no
implementation. A derived class must provide its own implementation of each abstract
method defined by its base class. Thus, an abstract method specifies the interface to the
method, but not the implementation. Although abstract classes and methods are useful, it is
possible to take this concept a step further. In C#, you can fully separate a class’ interface
from its implementation by using the keyword interface.

Interfaces are syntactically similar to abstract classes. However, in an interface, no
method can include a body. That is, an interface provides no implementation whatsoever.
It specifies what must be done, but not how. Once an interface is defined, any number of
classes can implement it. Also, one class can implement any number of interfaces.

To implement an interface, a class must provide bodies (implementations) for the
methods described by the interface. Each class is free to determine the details of its own
implementation. Thus, two classes might implement the same interface in different ways,
but each class still supports the same set of methods. Therefore, code that has knowledge of
the interface can use objects of either class since the interface to those objects is the same. By
providing the interface, C# allows you to fully utilize the “one interface, multiple methods”
aspect of polymorphism.

Interfaces are declared by using the interface keyword. Here is a simplified form of an
interface declaration:

interface name {
ret-type method-name1(param-list);
ret-type method-name2(param-list);
// ...
ret-type method-nameN(param-list);
}

The name of the interface is specified by name. Methods are declared using only their return
type and signature. They are, essentially, abstract methods. As explained, in an interface,
no method can have an implementation. Thus, each class that includes an interface must
implement all of the methods. In an interface, methods are implicitly public, and no explicit
access specifier is allowed.

Here is an example of an interface. It specifies the interface to a class that generates a
series of numbers.

public interface ISeries {
int GetNext(); // return next number in series
void Reset(); // restart
void SetStart(int x); // set starting value
}

The name of this interface is ISeries. Although the prefix I is not necessary, many
programmers prefix interfaces with I to differentiate them from classes. ISeries is
declared public so that it can be implemented by any class in any program.

In addition to methods, interfaces can specify properties, indexers, and events. Events
are described in Chapter 15, and we will be concerned with only methods, properties, and
indexers here. Interfaces cannot have data members. They cannot define constructors,
destructors, or operator methods. Also, no member can be declared as static.
 
 */

#endregion