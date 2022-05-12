#region Russian

/*

Практический пример организации управления доступом

Для чтобы стали понятнее особенности внутреннего механизма управления доступом,
обратимся к конкретному примеру. Одним из самых характерных примеров
объектно-ориентированного программирования служит класс, реализующий стек —
структуру данных, воплощающую магазинный список, действующий по принципу
"первым пришел — последним обслужен". Свое название он получил по аналогии
со стопкой тарелок, стоящих на столе. Первая тарелка в стопке является в то же время
последней использовавшейся тарелкой.

Стек служит классическим примером объектно-ориентированного программирования
потому, что он сочетает в себе средства хранения информации с методами доступа
к ней. Для реализации такого сочетания отлично подходит класс, в котором члены,
обеспечивающие хранение информации в стеке, должны быть закрытыми, а методы
доступа к ним — открытыми. Благодаря инкапсуляции базовых средств хранения информации
соблюдается определенный порядок доступа к отдельным элементам стека
из кода, в котором он используется.

Для стека определены две основные операции: поместить данные в стек и извлечь
их оттуда. Первая операция помещает значение на вершину стека, а вторая — извлекает
значение из вершины стека. Следовательно, операция извлечения является безвозвратной:
как только значение извлекается из стека, оно удаляется и уже недоступно
в стеке.

В рассматриваемом здесь примере создается класс Stack, реализующий функции
стека. В качестве базовых средств для хранения данных в стеке служит закрытый массив.
А операции размещения и извлечения данных из стека доступны с помощью открытых
методов класса Stack. Таким образом, открытые методы действуют по упомянутому
выше принципу "последним пришел — первым обслужен". Как следует из
приведенного ниже кода, в классе Stack сохраняются символы, но тот же самый механизм
может быть использован и для хранения данных любого другого типа.

*/

// Класс для хранения символов в стеке.

using System;
class Stack
{
    // Эти члены класса являются закрытыми.
    char[] stck;    // массив, содержащий стек
    int tos;        // индекс вершины стека
                    // Построить пустой класс Stack для реализации стека заданного размера.
    public Stack(int size)
    {
        stck = new char[size]; // распределить память для стека
        tos = 0;
    }

    // Поместить символы в стек.
    public void Push(char ch)
    {
        if (tos == stck.Length)
        {
            Console.WriteLine(" - Стек заполнен.");
            return;
        }
        stck[tos] = ch;
        tos++;
    }

    // Извлечь символ из стека.
    public char Pop()
    {
        if (tos == 0)
        {
            Console.WriteLine(" - Стек пуст.");
            return (char)0;
        }
        tos--;
        return stck[tos];
    }

    // Возвратить значение true, если стек заполнен.
    public bool IsFull()
    {
        return tos == stck.Length;
    }

    // Возвратить значение true, если стек пуст.
    public bool IsEmpty()
    {
        return tos == 0;
    }

    // Возвратить общую емкость стека.
    public int Capacity()
    {
        return stck.Length;
    }

    // Возвратить количество объектов, находящихся в данный момент в стеке.
    public int GetNum()
    {
        return tos;
    }
}

#endregion

#region English

/*

Controlling Access: A Case Study

To better understand the “how and why” behind access control, a case study is useful. One
of the quintessential examples of object-oriented programming is a class that implements a
stack. As you probably know, a stack is a data structure that implements a last-in, first-out
list. Its name comes from the analogy of a stack of plates on a table. The first plate on the
table is the last one to be used.

A stack is a classic example of object-oriented programming because it combines storage
for information along with the methods that access that information. Thus, a stack is a data
engine that enforces the last-in, first-out usage. Such a combination is an excellent choice for
a class in which the members that provide storage for the stack are private, and public methods
provide access. By encapsulating the underlying storage, it is not possible for code that uses
the stack to access the elements out of order.

A stack defines two basic operations: push and pop. A push puts a value onto the top of
the stack. A pop removes a value from the top of the stack. Thus, a pop is consumptive; once
a value has been popped off the stack, it has been removed and cannot be accessed again.
The example shown here creates a class called Stack that implements a stack. The
underlying storage for the stack is provided by a private array. The push and pop operations
are available through the public methods of the Stack class. Thus, the public methods enforce
the last-in, first-out mechanism. As shown here, the Stack class stores characters, but the
same mechanism could be used to store any type of data:

*/

// A stack class for characters.
using System;

class Stack
{
    // These members are private.
    char[] stck;    // holds the stack
    int tos;        // index of the top of the stack
                    // Construct an empty Stack given its size.

    public Stack(int size)
    {
        stck = new char[size]; // allocate memory for stack
        tos = 0;
    }

    // Push characters onto the stack.
    public void Push(char ch)
    {
        if (tos == stck.Length)
        {
            Console.WriteLine(" -- Stack is full.");
            return;
        }
        stck[tos] = ch;
        tos++;
    }

    // Pop a character from the stack.
    public char Pop()
    {
        if (tos == 0)
        {
            Console.WriteLine(" -- Stack is empty.");
            return (char)0;
        }
        tos--;
        return stck[tos];
    }

    // Return true if the stack is full.
    public bool IsFull()
    {
        return tos == stck.Length;
    }

    // Return true if the stack is empty.
    public bool IsEmpty()
    {
        return tos == 0;
    }

    // Return total capacity of the stack.
    public int Capacity()
    {
        return stck.Length;
    }

    // Return number of objects currently on the stack.
    public int GetNum()
    {
        return tos;
    }
}

#endregion