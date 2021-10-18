#region Russian

/*

О назначении структур

В связи с изложенным выше возникает резонный вопрос: зачем в C# включена
структура, если она обладает более скромными возможностями, чем класс? Ответ на
этот вопрос заключается в повышении эффективности и производительности программ.
Структуры относятся к типам значений, и поэтому ими можно оперировать
непосредственно, а не по ссылке. Следовательно, для работы со структурой вообще не
требуется переменная ссылочного типа, а это означает в ряде случаев существенную
экономию оперативной памяти. Более того, работа со структурой не приводит к ухудшению
производительности, столь характерному для обращения к объекту класса.
Ведь доступ к структуре осуществляется непосредственно, а к объектам — по ссылке,
поскольку классы относятся к данным ссылочного типа. Косвенный характер доступа
к объектам подразумевает дополнительные издержки вычислительных ресурсов на
каждый такой доступ, тогда как обращение к структурам не влечет за собой подобные
издержки. И вообще, если нужно просто сохранить группу связанных вместе данных,
не требующих наследования и обращения по ссылке, то с точки зрения производительности
для них лучше выбрать структуру.

Ниже приведен еще один пример, демонстрирующий применение структуры на
практике. В этом примере из области электронной коммерции имитируется запись
транзакции. Каждая такая транзакция включает в себя заголовок пакета, содержащий
номер и длину пакета. После заголовка следует номер счета и сумма транзакции. Заголовок
пакета представляет собой самостоятельную единицу информации, и поэтому
он организуется в отдельную структуру, которая затем используется для создания записи
транзакции или же информационного пакета любого другого типа.

*/

// Структуры удобны для группирования небольших объемов данных.

using System;

// Определить структуру пакета.
struct PacketHeader
{
    public uint PackNum; // номер пакета
    public ushort PackLen; // длина пакета
}

// Использовать структуру PacketHeader для создания записи
// траннзакции в сфере электронной коммерции.

class Transaction
{
    static uint transacNum = 0;
    PacketHeader ph; // ввести структуру PacketHeader в класс Transaction
    string accountNum;
    double amount;


    public Transaction(string acc, double val)
    {
        // создать заголовок пакета
        ph.PackNum = transacNum++;
        ph.PackLen = 512; // произвольная длина

        accountNum = acc;
        amount = val;
    }

    // Сымитировать транзакцию.
    public void sendTransaction()
    {
        Console.WriteLine("Пакет #: " + ph.PackNum +
                        ", Длина: " + ph.PackLen +
                        ",\n Счет #: " + accountNum +
                        ", Сумма: {0:C}\n", amount);
    }
}

// Продемонстрировать применение структуры в виде пакета транзакции.
class PacketDemo
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Transaction t = new Transaction("31243", -100.12);
        Transaction t2 = new Transaction("AB4655", 345.25);
        Transaction t3 = new Transaction("8475-09", 9800.00);

        t.sendTransaction();
        t2.sendTransaction();
        t3.sendTransaction();
    }
}

/*

Вот к какому результату может привести выполнение этого кода.

Пакет #: 0, Длина: 512,
    Счет #: 31243, Сумма: ($100.12)

Пакет #: 1, Длина: 512,
    Счет #: АВ4655, Сумма: $345.25

Пакет #: 2, Длина: 512,
    Счет #: 8475-09, Сумма: $9,800.00

Структура PacketHeader оказывается вполне пригодной для формирования заголовка
пакета транзакции, поскольку в ней хранится очень небольшое количество данных,
не используется наследование и даже не содержатся методы. Кроме того, работа
со структурой PacketHeader не влечет за собой никаких дополнительных издержек,
связанных со ссылками на объекты, что весьма характерно для класса. Следовательно,
структуру PacketHeader можно использовать для записи любой транзакции, не снижая
эффективность данного процесса.

Любопытно, что в С++ также имеются структуры и используется ключевое слово
struct. Но эти структуры отличаются от тех, что имеются в С#. Так, в C++ структура
относится к типу класса, а значит, структура и класс в этом языке практически равноценны
и отличаются друг от друга лишь доступом по умолчанию к их членам, которые
оказываются закрытыми для класса и открытыми для структуры. А в С# структура относится
к типу значения, тогда как класс — к ссылочному типу.

*/

#endregion

#region English

/*

Why Structures?

At this point, you might be wondering why C# includes the struct since it seems to be a
less-capable version of a class. The answer lies in efficiency and performance. Because
structures are value types, they are operated on directly rather than through a reference.
Thus, a struct does not require a separate reference variable. This means that less memory
is used in some cases. Furthermore, because a struct is accessed directly, it does not suffer
from the performance loss that is inherent in accessing a class object. Because classes are
reference types, all access to class objects is through a reference. This indirection adds
overhead to every access. Structures do not incur this overhead. In general, if you need
to simply store a group of related data, but don’t need inheritance and don’t need to operate
on that data through a reference, then a struct can be a more efficient choice.

Here is another example that shows how a structure might be used in practice. It
simulates an e-commerce transaction record. Each transaction includes a packet header that
contains the packet number and the length of the packet. This is followed by the account
number and the amount of the transaction. Because the packet header is a self-contained
unit of information, it is organized as a structure. This structure can then be used to create
a transaction record, or any other type of information packet.

*/

// Structures are good when grouping small amounts of data.

//using System;

//// Define a packet structure.
//struct PacketHeader
//{
//    public uint PackNum; // packet number
//    public ushort PackLen; // length of packet
//}
//// Use PacketHeader to create an e-commerce transaction record.
//class Transaction
//{
//    static uint transacNum = 0;
//    PacketHeader ph; // incorporate PacketHeader into Transaction
//    string accountNum;
//    double amount;
//    public Transaction(string acc, double val)
//    {
//        // create packet header
//        ph.PackNum = transacNum++;
//        ph.PackLen = 512; // arbitrary length
//        accountNum = acc;
//        amount = val;
//    }
//    // Simulate a transaction.
//    public void sendTransaction()
//    {
//        Console.WriteLine("Packet #: " + ph.PackNum +
//        ", Length: " + ph.PackLen +
//        ",\n Account #: " + accountNum +
//        ", Amount: {0:C}\n", amount);
//    }
//}
//// Demonstrate Packet.
//class PacketDemo
//{
//    static void Main()
//    {
//        Transaction t = new Transaction("31243", -100.12);
//        Transaction t2 = new Transaction("AB4655", 345.25);
//        Transaction t3 = new Transaction("8475-09", 9800.00);
//        t.sendTransaction();
//        t2.sendTransaction();
//        t3.sendTransaction();
//    }
//}

/*

The output from the program is shown here:

Packet #: 0, Length: 512,
    Account #: 31243, Amount: ($100.12)

Packet #: 1, Length: 512,
    Account #: AB4655, Amount: $345.25

Packet #: 2, Length: 512,
    Account #: 8475-09, Amount: $9,800.00

PacketHeader is a good choice for a struct because it contains only a small amount of data
and does not use inheritance or even contain methods. As a structure, PacketHeader does
not incur the additional overhead of a reference, as a class would. Thus, any type of
transaction record can use PacketHeader without affecting its efficiency.

As a point of interest, C++ also has structures and uses the struct keyword. However,
C# and C++ structures are not the same. In C++, struct defines a class type. Thus, in C++,
struct and class are nearly equivalent. (The difference has to do with the default access of
their members, which is private for class and public for struct.) In C#, a struct defines a
value type, and a class defines a reference type.

*/

#endregion