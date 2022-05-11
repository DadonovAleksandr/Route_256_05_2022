// Приоритизация заданий (10 баллов)
// Вам надо разработать подсистему простой приоритизации заданий.
// В системе есть n заданий, i-е задание имеет важность ri (1≤ri≤10^9).
// Каждому заданию надо назначить nice-значение — целое число от 1 и более. Чем ниже это число, тем выше приоритет у задания.
// Пусть максимальное значение важности среди всех заданий равно maxr, тогда nice-значение равное 1 получат все задания с важностью maxr и те, важность которых на 1 меньше.
// После этого удалим из рассмотрения все задания с назначенным nice-значением и назначим nice-значение 2, повторив описанную выше процедуру.
// После этого удалим из рассмотрения все задания с назначенным nice-значением и назначим nice-значение 3, повторив описанную выше процедуру.
// И так далее до тех пор, пока есть хотя бы одно задание без nice-значения.
// Для каждого задания выведите его nice-значение.
// Входные данные
// В первой строке записано целое число t(1≤t≤10^4) — количество наборов входных данных в тесте.
// Далее следуют описания наборов, каждый набор задается двумя строками.
// Первая из них содержит целое число n (1≤n≤2⋅10^5) — количество заданий.
// Вторая строка содержит n целых чисел r1,r2,…,rn (1≤ri≤109) — важности заданий.
// Гарантируется, что сумма значений n в тесте не превосходит 2⋅10^5.
// Неполные решения этой задачи могут быть оценены частичным баллом.
// Выходные данные
// Для каждого набора входных данных выведите одну строку, которая содержит n чисел v1,v2,…,vn, где vi — nice-значение, которое получило задание i.
// Пример
// Входные данные
// 5
// 7
// 4 95 101 2 100 101 96
// 1
// 1000000000
// 10
// 1 2 3 4 5 6 7 8 9 10
// 13
// 3 1 4 1 5 9 2 6 5 3 5 8 9
// 2
// 1000000000 1
// Выходные данные
// 3 2 1 4 1 1 2 
// 1 
// 5 5 4 4 3 3 2 2 1 1 
// 3 4 3 4 2 1 4 2 2 3 2 1 1 
// 1 2 

using System.Diagnostics;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var startTime = Stopwatch.StartNew();

        // var t = int.Parse(Console.ReadLine());
        // for (var i = 0; i < t; i++)
        // {
            var taskCount = int.Parse(Console.ReadLine());
            var taskImportance = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();
            var taskPriority = new int[taskCount];
            var maxImportance = int.MaxValue;
            var minImportance = taskImportance.Min()+1;
            int p = 1;
            while (maxImportance > minImportance)
            {
                maxImportance = taskImportance.Where(x => x < maxImportance - 1).Max();
                //Console.WriteLine($"max: {maxImportance}");
                var indexes = taskImportance.Select((item, index) => new { Item = item, Index = index })
                    .Where(x => x.Item <= maxImportance && x.Item >= maxImportance - 1)
                    .Select(x => x.Index);
                //Console.WriteLine($"{string.Join(" ", indexes)}");
                foreach (var indx in indexes)
                {
                    taskPriority.SetValue(p, indx);
                }
                
                //Console.WriteLine($"{string.Join(" ", taskPriority)}");
                p++;
            }

            Console.WriteLine($"{string.Join(" ", taskPriority)}");
        //}

        startTime.Stop();
        Console.WriteLine($"Elapsed time = {startTime.ElapsedMilliseconds} ms");
    }
}
