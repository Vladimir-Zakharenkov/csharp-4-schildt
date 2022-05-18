#region Russian

/*

Для извлечения элемента из стека вызывается открытый метод Pop(), приведенный
ниже.

// Извлечь символ из стека.
    public char Pop() {
        if(tos==0) {
            Console.WriteLine(" - Стек пуст.");
            return (char) 0;
        }
        tos--;
        return stck[tos];
    }

В этом методе сначала проверяется значение переменной tos. Если оно равно
нулю, значит, стек пуст. В противном случае значение переменной tos декрементируется,
и затем из стека возвращается элемент по указанному индексу.

Несмотря на то что для реализации стека достаточно методов Push() и Pop(), полезными
могут оказаться и другие методы. Поэтому в классе Stack определены еще
четыре метода: IsFull(), IsEmpty(), Capacity() и GetNum(). Эти методы предоставляют
всю необходимую информацию о состоянии стека и приведены ниже.

// Возвратить значение true, если стек заполнен.
    public bool IsFull() {
    return tos==stck.Length;
    }

// Возвратить значение true, если стек пуст.
    public bool IsEmpty() (
    return tos==0;
    }

// Возвратить общую емкость стека.
    public int Capacity() {
    return stck.Length;
    }

// Возвратить количество объектов, находящихся в данный момент в стеке.
    public int GetNum() {
    return tos;
    }

Метод IsFull() возвращает логическое значение true, если стек заполнен, а иначе
— логическое значение false.

Метод IsEmpty() возвращает логическое значение true, если стек пуст, 
а иначе — логическое значение false.

Для получения общей емкости стека (т.е. общего числа элементов, которые могут в нем храниться) 
достаточно вызвать метод Capacity(), а для получения количества элементов, хранящихся 
в настоящий момент в стеке, — метод GetNum().

Польза этих методов состоит в том, что для получения информации, которую они предоставляют, 
требуется доступ к закрытой переменной tos. Кроме того, они служат наглядными примерами 
организации безопасного доступа к закрытым членам класса с помощью открытых методов.

*/

#endregion

#region English

/*

To remove an element from the stack, call the public method Pop(). It is shown here:

// Pop a character from the stack.
    public char Pop() {
        if(tos==0) {
            Console.WriteLine(" -- Stack is empty.");
            return (char) 0;
        }
        tos--;
        return stck[tos];
    }

Here, the value of tos is checked. If it is zero, the stack is empty. Otherwise, tos is
decremented, and the element at that index is returned.

Although Push() and Pop() are the only methods needed to implement a stack, some
others are quite useful, and the Stack class defines four more. These are IsFull(), IsEmpty(),
Capacity(), and GetNum(), and they provide information about the state of the stack. They
are shown here:

// Return true if the stack is full.
    public bool IsFull() {
        return tos==stck.Length;
    }

// Return true if the stack is empty.
    public bool IsEmpty() {
        return tos==0;
    }

// Return total capacity of the stack.
    public int Capacity() {
        return stck.Length;
    }

// Return number of objects currently on the stack.
    public int GetNum() {
        return tos;
    }

The IsFull() method returns true when the stack is full and false otherwise. The IsEmpty()
method returns true when the stack is empty and false otherwise. To obtain the total capacity
of the stack (that is, the total number of elements it can hold), call Capacity(). To obtain the
number of elements currently stored on the stack, call GetNum(). These methods are useful
because the information they provide requires access to tos, which is private. They are also
examples of how public methods can provide safe access to private members.
*/

#endregion