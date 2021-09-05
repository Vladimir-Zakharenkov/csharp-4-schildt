#region Russian

/*

Свойство IsBackground

Как упоминалось выше, в среде .NET Framework определены две разновидности
потоков: приоритетный и фоновый. Единственное отличие между ними заключается
в том, что процесс не завершится до тех пор, пока не окончится приоритетный поток,
тогда как фоновые потоки завершаются автоматически по окончании всех приоритетных
потоков. По умолчанию создаваемый поток становится приоритетным. Но его
можно сделать фоновым, используя свойство IsBackground, определенное в классе
Thread, следующим образом.

public bool IsBackground { get; set; }

Для того чтобы сделать поток фоновым, достаточно присвоить логическое значение
true свойству IsBackground. А логическое значение false указывает на то, что поток
является приоритетным.

*/

#endregion

#region English

/*

The IsBackground Property

As mentioned earlier, the .NET Framework defines two types of threads: foreground and
background. The only difference between the two is that a process won’t end until all of its
foreground threads have ended, but background threads are terminated automatically after
all foreground threads have stopped. By default, a thread is created as a foreground thread.
It can be changed to a background thread by using the IsBackground property defined by
Thread, as shown here:

public bool IsBackground { get; set; }

To set a thread to background, simply assign IsBackground a true value. A value of false
indicates a foreground thread.

*/

#endregion