#region Russian

/*

Полиморфизм

Полиморфизм, что по-гречески означает "множество форм", — это свойство, позволяющее
одному интерфейсу получать доступ к общему классу действий. Простым
примером полиморфизма может служить руль автомашины, который выполняет
одни и те же функции своеобразного интерфейса независимо от вида применяемого
механизма управления автомашиной. Это означает, что руль действует одинаково независимо
от вида рулевого управления: прямого действия, с усилением или реечной
передачей. Следовательно, при вращении руля влево автомашина всегда поворачивает
влево, какой бы вид управления в ней ни применялся. Главное преимущество единообразного
интерфейса заключается в том, что, зная, как обращаться с рулем, вы сумеете
водить автомашину любого типа.

Тот же самый принцип может быть применен и в программировании. Рассмотрим
для примера стек, т.е. область памяти, функционирующую по принципу "последним
пришел — первым обслужен". Допустим, что в программе требуются три разных типа
стеков: один — для целых значений, другой — для значений с плавающей точкой, третий
— для символьных значений. В данном примере алгоритм, реализующий все эти
стеки, остается неизменным, несмотря на то, что в них сохраняются разнотипные данные.
В языке, не являющемся объектно-ориентированным, для этой цели пришлось бы
создать три разных набора стековых подпрограмм с разными именами. Но благодаря
полиморфизму для реализации всех трех типов стеков в C# достаточно создать лишь
один общий набор подпрограмм. Зная, как пользоваться одним стеком, вы сумеете
воспользоваться и остальными.

В более общем смысле понятие полиморфизма нередко выражается следующим
образом: "один интерфейс — множество методов". Это означает, что для группы взаимосвязанных
действий можно разработать общий интерфейс. Полиморфизм помогает
упростить программу, позволяя использовать один и тот же интерфейс для описания
общего класса действий. Выбрать конкретное действие (т.е. метод) в каждом отдельном
случае — это задача компилятора. Программисту не нужно делать это самому. Ему
достаточно запомнить и правильно использовать общий интерфейс.

*/

#endregion

#region English

/*

Polymorphism

Polymorphism (from Greek, meaning “many forms”) is the quality that allows one interface
to access a general class of actions. A simple example of polymorphism is found in the
steering wheel of an automobile. The steering wheel (the interface) is the same no matter
what type of actual steering mechanism is used. That is, the steering wheel works the same
whether your car has manual steering, power steering, or rack-and-pinion steering. Thus,
turning the steering wheel left causes the car to go left no matter what type of steering is
used. The benefit of the uniform interface is, of course, that once you know how to operate
the steering wheel, you can drive any type of car.

The same principle can also apply to programming. For example, consider a stack
(which is a first-in, last-out list). You might have a program that requires three different
types of stacks. One stack is used for integer values, one for floating-point values, and one
for characters. In this case, the algorithm that implements each stack is the same, even
though the data being stored differs. In a non-object-oriented language, you would be
required to create three different sets of stack routines, with each set using different names.
However, because of polymorphism, in C# you can create one general set of stack routines
that works for all three specific situations. This way, once you know how to use one stack,
you can use them all.

More generally, the concept of polymorphism is often expressed by the phrase “one
interface, multiple methods.” This means that it is possible to design a generic interface to
a group of related activities. Polymorphism helps reduce complexity by allowing the same
interface to be used to specify a general class of action. It is the compiler’s job to select the
specific action (that is, method) as it applies to each situation. You, the programmer, don’t
need to do this selection manually. You need only remember and utilize the general interface.

*/

#endregion