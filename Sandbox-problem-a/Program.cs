// Напишите программу, которая выводит сумму двух целых чисел.

// Входные данные
// В первой строке входных данных содержится целое число t (1≤t≤104) — количество наборов входных данных в тесте.
// Далее следуют описания t наборов входных данных, один набор в строке.
// В первой (и единственной) строке набора записаны два целых числа a и b (−1000≤a,b≤1000).

// Выходные данные
// Для каждого набора входных данных выведите сумму двух заданных чисел, то есть a+b.

// Пример
// Входные данные
// 5
// 256 42
// 1000 1000
// -1000 1000
// -1000 1000
// 20 22

// Выходные данные
// 298
// 2000
// 0
// 0
// 42

using System.Diagnostics;
using System.Text;

var startTime = Stopwatch.StartNew();

var t = int.Parse(Console.ReadLine());
StringBuilder result = new StringBuilder();
for (var i = 0; i < t; i++)
{
    var parts = Console.ReadLine().Split(" ");
    result.Append($"{int.Parse(parts[0]) + int.Parse(parts[1])}\n");
}
Console.WriteLine(result);

startTime.Stop();
Console.WriteLine($"Elapsed time = {startTime.ElapsedMilliseconds} ms");