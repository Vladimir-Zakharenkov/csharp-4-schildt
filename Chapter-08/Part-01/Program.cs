#region Russian

/*

8 ГЛАВА

Подробнее о методах и классах

В данной главе возобновляется рассмотрение классов
и методов. Оно начинается с пояснения механизма
управления доступом к членам класса. А затем обсуждаются
такие вопросы, как передача и возврат объектов,
перегрузка методов, различные формы метода Main(),
рекурсия и применение ключевого слова static.

Управление доступом к членам класса

Поддержка свойства инкапсуляции в классе дает два
главных преимущества. Во-первых, класс связывает данные
с кодом. Это преимущество использовалось в предыдущих
примерах программ, начиная с главы 6. И во-вторых, класс
предоставляет средства для управления доступом к его членам.
Именно эта, вторая преимущественная особенность
и будет рассмотрена ниже.

В языке С#, по существу, имеются два типа членов класса:
открытые и закрытые, хотя в действительности дело обстоит
немного сложнее. Доступ к открытому члену свободно
осуществляется из кода, определенного за пределами
класса. Именно этот тип члена класса использовался в рассматривавшихся
до сих пор примерах программ. А закрытый
член класса доступен только методам, определенным
в самом классе. С помощью закрытых членов и организуется
управление доступом.

Ограничение доступа к членам класса является основополагающим
этапом объектно-ориентированного программирования,
поскольку позволяет исключить неверное
использование объекта. Разрешая доступ к закрытым 
данным только с помощью строго определенного ряда методов, можно предупредить
присваивание неверных значений этим данным, выполняя, например, проверку диапазона
представления чисел. Для закрытого члена класса нельзя задать значение непосредственно
в коде за пределами класса. Но в то же время можно полностью управлять
тем, как и когда данные используются в объекте. Следовательно, правильно реализованный
класс образует некий "черный ящик", которым можно пользоваться, но внутренний
механизм его действия закрыт для вмешательства извне.

*/

#endregion

#region English

/*

8 CHAPTER

A Closer Look at Methods and Classes

This chapter resumes the examination of classes and methods. It begins by explaining
how to control access to the members of a class. It then discusses the passing and
returning of objects, method overloading, the various forms of Main(), recursion,
and the use of the keyword static.

Controlling Access to Class Members

with code. You have been taking advantage of this aspect of the class since Chapter 6.
Second, it provides the means by which access to members can be controlled. It is this
second feature that is examined here.

Although C#’s approach is a bit more sophisticated, in essence, there are two basic
types of class members: public and private. A public member can be freely accessed by code
defined outside of its class. This is the type of class member that we have been using up to
this point. A private member can be accessed only by methods defined by its class. It is
through the use of private members that access is controlled.

Restricting access to a class’ members is a fundamental part of object-oriented programming
because it helps prevent the misuse of an object. By allowing access to private data only
through a well-defined set of methods, you can prevent improper values from being assigned
to that data—by performing a range check, for example. It is not possible for code outside
the class to set the value of a private member directly. You can also control precisely how
and when the data within an object is used. Thus, when correctly implemented, a class
creates a “black box” that can be used, but the inner workings of which are not open to
tampering.

*/

#endregion