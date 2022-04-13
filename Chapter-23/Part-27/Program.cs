#region Russian

/*

Запуск отдельной задачи

Многозадачность на основе потоков чаще всего организуется при программировании
на С#. Но там, где это уместно, можно организовать и многозадачность на основе
процессов. В этом случае вместо запуска другого потока в одной и той же программе
одна программа начинает выполнение другой. При программировании на C# это
делается с помощью класса Process, определенного в пространстве имен System.Diagnostics. 
В заключение этой главы вкратце будут рассмотрены особенности запуска
и управления другим процессом.

Простейший способ запустить другой процесс — воспользоваться методом
Start(), определенным в классе Process. Ниже приведена одна из самых простых
форм этого метода:

public static Process Start(string имя_файла)

где имя_файла обозначает конкретное имя файла, который должен исполняться или
же связан с исполняемым файлом.

Когда созданный процесс завершается, следует вызвать метод Close(), чтобы освободить
память, выделенную для этого процесса. Ниже приведена форма объявления
метода Close().

public void Close()

Процесс может быть прерван двумя способами. Если процесс является приложением
Windows с графическим пользовательским интерфейсом, то для прерывания
такого процесса вызывается метод CloseMainWindow(), форма которого приведена
ниже.

public bool CloseMainWindow()

Этот метод посылает процессу сообщение, предписывающее ему остановиться. Он
возвращает логическое значение true, если сообщение получено, и логическое значение
false, если приложение не имеет графического пользовательского интерфейса
или главного окна. Следует, однако, иметь в виду, что метод CloseMainWindow() служит
только для запроса остановки процесса. Если приложение проигнорирует такой
запрос, то оно не будет прервано как процесс.

Для безусловного прерывания процесса следует вызвать метод Kill(), как показано
ниже.

public void Kill()

Но методом Kill() следует пользоваться аккуратно, так как он приводит к неконтролируемому
прерыванию процесса. Любые несохраненные данные, связанные с прерываемым
процессом, будут, скорее всего, потеряны.

Для того чтобы организовать ожидание завершения процесса, можно воспользоваться
методом WaitForExit(). Ниже приведены две его формы.

public void WaitForExit()
public bool WaitForExit(int миллисекунд)

В первой форме ожидание продолжается до тех пор, пока процесс не завершится,
а во второй форме — только в течение указанного количества миллисекунд. В последнем
случае метод WaitForExit() возвращает логическое значение true, если процесс
завершился, и логическое значение false, если он все еще выполняется.

В приведенном ниже примере программы демонстрируется создание, ожидание и
закрытие процесса. В этой программе сначала запускается стандартная сервисная программа
Windows: текстовый редактор WordPad.exe, а затем организуется ожидание
завершения программы WordPad как процесса.

*/

// Продемонстрировать запуск нового процесса.

using System;
using System.Diagnostics;

class StartProcess
{
    static void Main()
    {
        Process newProc = Process.Start("C:\\Program Files (x86)\\Windows NT\\Accessories\\wordpad.exe");

        Console.WriteLine("Новый процесс запущен.");

        newProc.WaitForExit();

        newProc.Close(); // освободить выделенные ресурсы

        Console.WriteLine("Новый процесс завершен.");
    }
}

/*

При выполнении этой программы запускается стандартное приложение WordPad,
и на экране появляется сообщение "Новый процесс запущен.". Затем программа
ожидает закрытия WordPad. По окончании работы WordPad на экране появляется заключительное
сообщение "Новый процесс завершен.".

*/

#endregion

#region English

/*

Starting a Separate Task

Although thread-based multitasking is what you will use most often when programming
in C#, it is possible to utilize process-based multitasking where appropriate. When using
process-based multitasking, instead of starting another thread within the same program,
one program starts the execution of another program. In C#, you do this by using the
Process class. Process is defined within the System.Diagnostics namespace. To conclude
this chapter, a brief look at starting and managing another process is offered.

The easiest way to start another process is to use the Start() method defined by Process.
Here is one of its simplest forms:

public static Process Start(string fileName)

Here, fileName specifies the name of an executable file that will be executed or a file that is
associated with an executable.

When a process that you create ends, call Close() to free the memory associated with
that process. It is shown here:

public void Close()

You can terminate a process in two ways. If the process is a Windows GUI application,
then to terminate the process, call CloseMainWindow(), shown here:

public bool CloseMainWindow()

This method sends a message to the process, instructing it to stop. It returns true if the
message was received. It returns false if the application was not a GUI app, or does not
have a main window. Furthermore, CloseMainWindow() is only a request to shut down.
If the application ignores the request, the application will not be terminated.

To positively terminate a process, call Kill(), as shown here:

public void Kill()

Use Kill() carefully. It causes an uncontrolled termination of the process. Any unsaved data
associated with the process will most likely be lost.

You can wait for a process to end by calling WaitForExit(). Its two forms are shown here:

public void WaitForExit()
public bool WaitForExit(int milliseconds)

The first form waits until the process terminates. The second waits for only the specified
number of milliseconds. The second form returns true if the process has terminated and
false if it is still running.

The following program demonstrates how to create, wait for, and close a process. It starts
the standard Windows utility program WordPad.exe. It then waits for WordPad to end.

*/

// Starting a new process. 

//using System; 
//using System.Diagnostics; 

//class StartProcess
//{
//    static void Main()
//    {
//        Process newProc = Process.Start("wordpad.exe");

//        Console.WriteLine("New process started.");

//        newProc.WaitForExit();

//        newProc.Close(); // free resources 

//        Console.WriteLine("New process ended.");
//    }
//}

/*

When you run this program, WordPad will start, and you will see the message, “New
process started.” The program will then wait until you close WordPad. Once WordPad
has been terminated, the final message, “New process ended.”, is displayed.

*/

#endregion