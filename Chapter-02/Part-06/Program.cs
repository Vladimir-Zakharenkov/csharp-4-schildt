#region Russian

/*

Применение компилятора командной строки csc.ехе

Для коммерческой разработки программ вам, скорее всего, придется пользоваться
интегрированной средой Visual Studio, хотя для некоторых читателей более удобным
может оказаться компилятор, работающий в режиме командной строки, особенно
для компилирования и выполнения примеров программ, приведенных в этой
книге. Объясняется это тем, что для работы над отдельной программой не нужно
создавать целый проект. Для этого достаточно написать программу, а затем скомпилировать
и выполнить ее, причем все это делается из командной строки. Таким
образом, если вы умеете пользоваться окном Командная строка (Command Prompt)
и его интерфейсом в Windows, то компилятор командной строки окажется для вас
более простым и оперативным инструментальным средством, чем интегрированная
среда разработки.

ПРЕДОСТЕРЕЖЕНИЕ
Если вы не знаете, как пользоваться окном Командная строка, то вам лучше работать
в интегрированной среде разработки Visual Studio. Ведь пытаться усвоить одновременно
команды интерфейса Командная строка и элементы языка C# не так-то просто, несмотря
на то, что запомнить эти команды совсем нетрудно.

Для написания и выполнения программ на C# с помощью компилятора командной
строки выполните следующую несложную процедуру.

1. Введите исходный текст программы, используя текстовый редактор.
2. Скомпилируйте программу с помощью компилятора csc.ехе.
3. Выполните программу.

Ввод исходного текста программы

Исходный текст примеров программ, приведенных в этой книге, доступен для загрузки
по адресу www.mhprofessional.com. Но при желании вы можете сами ввести
исходный текст этих программ вручную. Для этого воспользуйтесь избранным
текстовым редактором, например Notepad. Но не забывайте, что вы должны создать
файлы, содержащие простой, а не отформатированный текст, поскольку информация
форматирования текста, сохраняемая в файле для обработки текста, может помешать
нормальной работе компилятора С#. Введя исходный текст программы, присвойте ее
файлу имя Example.cs.

Компилирование программы

Для компилирования программы на C# запустите на выполнение компилятор
csc.ехе, указав имя исходного файла в командной строке.

С:\>csc Example.cs

Компилятор csc создаст файл Example.ехе, содержащий версию MSIL данной
программы. Несмотря на то что псевдокод MSIL не является исполняемым кодом, он
содержится в исполняемом файле с расширением .ехе. Среда CLR автоматически вызывает
JIT-компилятор при попытке выполнить файл Example.ехе. Следует, однако,
иметь в виду, что если попытаться выполнить файл Example.ехе (или любой другой
исполняемый файл, содержащий псевдокод MSIL) на том компьютере, где среда .NET
Framework не установлена, то программа не будет выполнена, поскольку на этом компьютере
отсутствует среда CLR.

ПРИМЕЧАНИЕ
Прежде чем запускать на выполнение компилятор csc.ехе, откройте окно Командная
строка, настроенное под Visual Studio. Для этого проще всего выбрать команду 
Visual Studio→Инструменты Visual Studio→Командная строка Visual Studio 
(Visual Studio→Visual Studio Tools→Visual Studio Command Prompt) из меню 
Пуск→Все программы (Start→All Programs) на панели задач Windows. Кроме того, вы можете открыть 
ненастроенное окно Командная строка, а затем выполнить командный файл vsvars32.bat, входящий
в состав Visual Studio.

Выполнение программы

Для выполнения программы введите ее имя в командной строке следующим образом.

С:\>Ехаmрlе

В результате выполнения программы на экране появится такая строка.

Простая программа на С#.

*/

#endregion

#region Russian

/*

Using csc.exe, the C# Command-Line Compiler

Although the Visual Studio IDE is what you will probably be using for your commercial
projects, some readers will find the C# command-line compiler more convenient, especially
for compiling and running the sample programs shown in this book. The reason is that you
don’t have to create a project for the program. You can simply create the program and then
compile it and run it—all from the command line. Therefore, if you know how to use the
Command Prompt window and its command-line interface, using the command-line
compiler will be faster and easier than using the IDE.

CAUTION
If you are not familiar with the Command Prompt window, then it is probably better to
use the Visual Studio IDE. Although the Command Prompt is not difficult to master, trying to
learn both the Command Prompt and C# at the same time will be a challenging experience.

To create and run programs using the C# command-line compiler, follow these three steps:

1. Enter the program using a text editor.
2. Compile the program using csc.exe.
3. Run the program.

Entering the Program

The source code for programs shown in this book is available at www.mhprofessional.com.
However, if you want to enter the programs by hand, you are free to do so. In this case, you
must enter the program into your computer using a text editor, such as Notepad. Remember,
you must create text-only files, not formatted word-processor files, because the format
information in a word processor file will confuse the C# compiler. When entering the
program, call the file Example.cs.

Compiling the Program

To compile the program, execute the C# compiler, csc.exe, specifying the name of the source
file on the command line, as shown here:

C:\>csc Example.cs

The csc compiler creates a file called Example.exe that contains the MSIL version of the
program. Although MSIL is not executable code, it is still contained in an exe file. The
Common Language Runtime automatically invokes the JIT compiler when you attempt to
execute Example.exe. Be aware, however, that if you try to execute Example.exe (or any
other exe file that contains MSIL) on a computer for which the .NET Framework is not
installed, the program will not execute because the CLR will be missing.

NOTE
Prior to running csc.exe you will need to open a Command Prompt window that is
configured for Visual Studio. The easiest way to do this is to select Visual Studio Command
Prompt under Visual Studio Tools in the Start menu. Alternatively, you can start an
unconfigured Command Prompt window and then run the batch file vsvars32.bat, which
is provided by Visual Studio.

Running the Program

To actually run the program, just type its name on the command line, as shown here:

C:\>Example

When the program is run, the following output is displayed:

A simple C# program.

*/

#endregion