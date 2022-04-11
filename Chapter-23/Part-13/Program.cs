#region Russian

/*

Класс Monitor и блокировка

Ключевое слово lock на самом деле служит в C# быстрым способом доступа к
средствам синхронизации, определенным в классе Monitor, который находится в пространстве
имен System.Threading. В этом классе определен, в частности, ряд методов
для управления синхронизацией. Например, для получения блокировки объекта вызывается
метод Enter(), а для снятия блокировки — метод Exit(). Ниже приведены
общие формы этих методов:

public static void Enter(object obj)
public static void Exit(object obj)

где obj обозначает синхронизируемый объект. Если же объект недоступен, то после
вызова метода Enter() вызывающий поток ожидает до тех пор, пока объект не станет
доступным. Тем не менее методы Enter() и Exit() применяются редко, поскольку
оператор lock автоматически предоставляет эквивалентные средства синхронизации
потоков. Именно поэтому оператор lock оказывается "более предпочтительным" для
получения блокировки объекта при программировании на С#.

Впрочем, один метод из класса Monitor может все же оказаться полезным. Это
метод TryEnter(), одна из общих форм которого приведена ниже.

public static bool TryEnter(object obj)

Этот метод возвращает логическое значение true, если вызывающий поток получает
блокировку для объекта obj, а иначе он возвращает логическое значение false.
Но в любом случае вызывающему потоку придется ждать своей очереди. С помощью
метода TryEnter() можно реализовать альтернативный вариант синхронизации потоков,
если требуемый объект временно недоступен.

Кроме того, в классе Monitor определены методы Wait(), Pulse() и PulseAll(),
которые рассматриваются в следующем разделе.

*/

#endregion

#region English

/*

The Monitor Class and lock

The C# keyword lock is really just shorthand for using the synchronization features defined
by the Monitor class, which is defined in the System.Threading namespace. Monitor
defines several methods that control or manage synchronization. For example, to obtain a
lock on an object, call Enter( ). To release a lock, call Exit( ). The simplest form of Enter( ) is
shown here, along with the Exit( ) method:

public static void Enter(object obj)
public static void Exit(object obj)

Here, obj is the object being synchronized. If the object is not available when Enter( ) is called,
the calling thread will wait until it becomes available. You will seldom use Enter( ) or Exit( ),
however, because a lock block automatically provides the equivalent. For this reason, lock is
the preferred method of obtaining a lock on an object when programming in C#.

One method in Monitor that you may find useful on occasion is TryEnter( ). One of its
forms is shown here:

public static bool TryEnter(object obj)

It returns true if the calling thread obtains a lock on obj and false if it doesn’t. In no case
does the calling thread wait. You could use this method to implement an alternative if the
desired object is unavailable.

Monitor also defines these three methods: Wait( ), Pulse( ), and PulseAll( ). They are
described in the next section.

*/

#endregion