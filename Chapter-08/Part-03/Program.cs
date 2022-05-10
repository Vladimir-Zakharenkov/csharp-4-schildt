#region Russian

/*

Организация закрытого и открытого доступа

Правильная организация закрытого и открытого доступа — залог успеха в объектно-
ориентированном программировании. И хотя для этого не существует твердо установленных
правил, ниже перечислен ряд общих принципов, которые могут служить
в качестве руководства к действию.

• Члены, используемые только в классе, должны быть закрытыми.

• Данные экземпляра, не выходящие за определенные пределы значений, должны
быть закрытыми, а при организации доступа к ним с помощью открытых методов
следует выполнять проверку диапазона представления чисел.

• Если изменение члена приводит к последствиям, распространяющимся за пределы
области действия самого члена, т.е. оказывает влияние на другие аспекты объекта,
то этот член должен быть закрытым, а доступ к нему — контролируемым.

• Члены, способные нанести вред объекту, если они используются неправильно,
должны быть закрытыми. Доступ к этим членам следует организовать с помощью
открытых методов, исключающих неправильное их использование.

• Методы, получающие и устанавливающие значения закрытых данных, должны
быть открытыми.

• Переменные экземпляра допускается делать открытыми лишь в том случае,
если нет никаких оснований для того, чтобы они были закрытыми.

Разумеется, существует немало ситуаций, на которые приведенные выше принципы
не распространяются, а в особых случаях один или несколько этих принципов
могут вообще нарушаться. Но в целом, следуя этим правилам, вы сможете создавать
объекты, устойчивые к попыткам неправильного их использования.

*/

#endregion

#region English

/*

Applying Public and Private Access

The proper use of public and private access is a key component of successful object-oriented
programming. Although there are no hard and fast rules, here are some general principles
that serve as guidelines:

• Members of a class that are used only within the class itself should be private.

• Instance data that must be within a specific range should be private, with access
provided through public methods that can perform range checks.

• If changing a member can cause an effect that extends beyond the member itself
(that is, affects other aspects of the object), that member should be private, and
access to it should be controlled.

• Members that can cause harm to an object when improperly used should be private.
Access to these members should be through public methods that prevent improper
usage.

• Methods that get and set the values of private data must be public.

• Public instance variables are permissible when there is no reason for them to be
private.

Of course, there are many nuances that the preceding rules do not address, and special
cases cause one or more rules to be violated. But, in general, if you follow these rules, you
will be creating resilient objects that are not easily misused.

*/

#endregion