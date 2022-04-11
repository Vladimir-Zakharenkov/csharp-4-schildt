#region Russian

/*

Два подхода к параллельному программированию

Применяя TPL, параллелизм в программу можно ввести двумя основными способами.
Первый из них называется параллелизмом данных. При таком подходе одна операция
над совокупностью данных разбивается на два параллельно выполняемых потока
или больше, в каждом из которых обрабатывается часть данных. Так, если изменяется
каждый элемент массива, то, применяя параллелизм данных, можно организовать параллельную
обработку разных областей массива в двух или больше потоках. Нетрудно
догадаться, что такие параллельно выполняющиеся действия могут привести к значительному
ускорению обработки данных по сравнению с последовательным подходом.
Несмотря на то что параллелизм данных был всегда возможен и с помощью класса
Thread, построение масштабируемых решений средствами этого класса требовало немало
усилий и времени. Это положение изменилось с появлением библиотеки TPL, с
помощью которой масштабируемый параллелизм данных без особого труда вводится
в программу.

Второй способ ввода параллелизм называется параллелизмом задач. При таком подходе
две операции или больше выполняются параллельно. Следовательно, параллелизм
задач представляет собой разновидность параллелизма, который достигался в
прошлом средствами класса Thread. А к преимуществам, которые сулит применение
TPL, относится простота применения и возможность автоматически масштабировать
исполнение кода на несколько процессоров.

*/

#endregion

#region English

/*

Two Approaches to Parallel Programming

When using the TPL, there are two basic ways in which you can add parallelism to a program.
The first is called data parallelism. With this approach, one operation on a collection of data is
broken into two or more concurrent threads of execution, each operating on a portion of the
data. For example, if a transformation is applied to each element in an array, then through the
use of data parallelism, it is possible for two or more threads to be operating on different
ranges of the array concurrently. As you can imagine, such parallel actions could result in
substantial increases in speed over a strictly sequential approach. Although data parallelism
has always been possible by using the Thread class, it was difficult and time-consuming to
construct scalable solutions. The TPL changes this. With the TPL, scalable data parallelism is
easy to add to your program.

The second way to add parallelism is through the use of task parallelism. This approach
executes two or more operations concurrently. Thus, task parallelism is the type of parallelism
that has been accomplished in the past via the Thread class. The advantages that the TPL
adds are ease-of-use and the ability to automatically scale execution to multiple processors.

*/

#endregion