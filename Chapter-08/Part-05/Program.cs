#region Russian

/*

Рассмотрим класс Stack более подробно. В начале этого класса объявляются две
следующие переменные экземпляра.

// Эти члены класса являются закрытыми.
    char[] stck; // массив, содержащий стек
    int tos; // индекс вершины стека

Массив stck предоставляет базовые средства для хранения данных в стеке (в данном
случае — символов). Обратите внимание на то, что память для этого массива не
распределяется. Это делается в конструкторе класса Stack. А член tos данного класса
содержит индекс вершины стека.

Оба члена, tos и stck, являются закрытыми, и благодаря этому соблюдается принцип
"последним пришел — первым обслужен". Если же разрешить открытый доступ
к члену stck, то элементы стека окажутся доступными не по порядку. Кроме того,
член tos содержит индекс вершины стека, где находится первый обслуживаемый в
стеке элемент, и поэтому манипулирование членом tos в коде, находящемся за пределами
класса Stack, следует исключить, чтобы не допустить разрушение самого стека.
Но в то же время члены stck и tos доступны пользователю класса Stack косвенным
образом с помощью различных отрытых методов, описываемых ниже.

Рассмотрим далее конструктор класса Stack.

// Построить пустой класс Stack для реализации стека заданного размера.
    public Stack(int size) {
    stck = new char[size]; // распределить память для стека
    tos = 0;
    }

Этому конструктору передается требуемый размер стека. Он распределяет память
для базового массива и устанавливает значение переменной tos в нуль. Следовательно,
нулевое значение переменной tos указывает на то, что стек пуст.

Открытый метод Push() помещает конкретный элемент в стек, как показано ниже.

// Поместить символы в стек.
    public void Push(char ch) {
        if (tos==stck.Length) {
            Console.WriteLine(" - Стек заполнен.");
            return;
        }
    stck[tos] = ch;
    tos++;
    }

Элемент, помещаемый в стек, передается данному методу в качестве параметра ch.
Перед тем как поместить элемент в стек, выполняется проверка на наличие свободного
места в базовом массиве, а именно: не превышает ли значение переменной tos длину
массива stck. Если свободное место в массиве stck есть, то элемент сохраняется в нем
по индексу, хранящемуся в переменной tos, после чего значение этой переменной
инкрементируется. Таким образом, в переменной tos всегда хранится индекс следующего
свободного элемента массива stck.

*/

#endregion

#region English

/*

Let’s examine this class closely. The Stack class begins by declaring these two instance
variables:

// These members are private.
    char[] stck; // holds the stack
    int tos; // index of the top of the stack

The stck array provides the underlying storage for the stack, which in this case holds
characters. Notice that no array is allocated. The allocation of the actual array is handled
by the Stack constructor. The tos member holds the index of the top of the stack.

Both the tos and stck members are private. This enforces the last-in, first-out stack
mechanism. If public access to stck were allowed, then the elements on the stack could
be accessed out of order. Also, since tos holds the index of the top element in the stack,
manipulations of tos by code outside the Stack class must be prevented in order to avoid
corruption of the stack. Access to stck and tos is available, indirectly, to the user of Stack
through the various public methods described shortly.

The stack constructor is shown next:

// Construct an empty Stack given its size.
    public Stack(int size) {
        stck = new char[size]; // allocate memory for stack
        tos = 0;
    }

The constructor is passed the desired size of the stack. It allocates the underlying array and
sets tos to zero. Thus, a zero value in tos indicates that the stack is empty.

The public Push( ) method puts an element onto the stack. It is shown here:

// Push characters onto the stack.
    public void Push(char ch) {
        if(tos==stck.Length) {
            Console.WriteLine(" -- Stack is full.");
            return;
        }
        stck[tos] = ch;
        tos++;
    }

The element to be pushed onto the stack is passed in ch. Before the element is added to
the stack, a check is made to ensure that there is still room in the underlying array. This is
done by making sure that tos does not exceed the length of stck. If there is still room, the
element is stored in stck at the index specified by tos, and then tos is incremented. Thus,
tos always contains the index of the next free element in stck.

*/

#endregion