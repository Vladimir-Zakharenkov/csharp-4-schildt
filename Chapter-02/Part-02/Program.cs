#region Russian

/*

Инкапсуляция

Инкапсуляция — это механизм программирования, объединяющий вместе код
и данные, которыми он манипулирует, исключая как вмешательство извне, так и неправильное
использование данных. В объектно-ориентированном языке данные и код
могут быть объединены в совершенно автономный черный ящик. Внутри такого ящика
находятся все необходимые данные и код. Когда код и данные связываются вместе подобным
образом, создается объект. Иными словами, объект — это элемент, поддерживающий
инкапсуляцию.

В объекте код, данные или же и то и другое могут быть закрытыми или же открытыми.
Закрытые данные или код известны и доступны только остальной части
объекта. Это означает, что закрытые данные или код недоступны части программы,
находящейся за пределами объекта. Если же данные или код оказываются открытыми,
то они доступны другим частям программы, хотя и определены внутри объекта. Как
правило, открытые части объекта служат для организации управляемого интерфейса
с закрытыми частями.

Основной единицей инкапсуляции в C# является класс, который определяет форму
объекта. Он описывает данные, а также код, который будет ими оперировать. В C#
описание класса служит для построения объектов, которые являются экземплярами
класса. Следовательно, класс, по существу, представляет собой ряд схематических описаний
способа построения объекта.

Код и данные, составляющие вместе класс, называют членами. Данные, определяемые
классом, называют полями, или переменными экземпляра. А код, оперирующий
данными, содержится в функциях-членах, самым типичным представителем которых
является метод. В C# метод служит в качестве аналога подпрограммы. (К числу других
функций-членов относятся свойства, события и конструкторы.) Таким образом, методы
класса содержат код, воздействующий на поля, определяемые этим классом.

*/

#endregion

#region English

/*

Encapsulation

Encapsulation is a programming mechanism that binds together code and the data it
manipulates, and that keeps both safe from outside interference and misuse. In an objectoriented
language, code and data can be bound together in such a way that a self-contained
black box is created. Within the box are all necessary data and code. When code and data are
linked together in this fashion, an object is created. In other words, an object is the device
that supports encapsulation.

Within an object, the code, data, or both may be private to that object or public. Private code
or data is known to and accessible by only another part of the object. That is, private code or
data cannot be accessed by a piece of the program that exists outside the object. When code
or data is public, other parts of your program can access it even though it is defined within
an object. Typically, the public parts of an object are used to provide a controlled interface to
the private elements.

C#’s basic unit of encapsulation is the class. A class defines the form of an object. It specifies
both the data and the code that will operate on that data. C# uses a class specification to
construct objects. Objects are instances of a class. Thus, a class is essentially a set of plans
that specify how to build an object.

Collectively, the code and data that constitute a class are called its members. The data
defined by the class is referred to as fields. The terms member variables and instance variables
also are used. The code that operates on that data is contained within function members, of
which the most common is the method. Method is C#’s term for a subroutine. (Other
function members include properties, events, and constructors.) Thus, the methods of
a class contain code that acts on the fields defined by that class.

*/

#endregion