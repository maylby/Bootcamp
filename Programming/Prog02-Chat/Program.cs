// Буткемп. Программирование
// Урок 2. Алгоритмы в C# . Эффективность алгоритма
// https://gb.ru/lessons/375187

// Азат Гарипов  •  14 октября 2023 в 14:24

using System.Diagnostics;

int[] array = ArrayCreator.Create(1_000_000).FillRandom(seed:0);
// array.ConsoleWrite();

int m = 10_000;

Stopwatch sw = new Stopwatch();

sw.Start();
int sum1 = array.GetSum(m);
sw.Stop();
Console.WriteLine($"GetSum({m}):\t\t{sum1}; elapsed: {sw.ElapsedMilliseconds}.");

sw.Restart();
int sum2 = array.GetSumFast(m);
sw.Stop();
Console.WriteLine($"GetSumFast({m}):\t{sum2}; elapsed: {sw.ElapsedMilliseconds}.");

/// <summary>
/// Класс для создания массива
/// </summary>
public static class ArrayCreator
{
    /// <summary>
    /// Метод создания пустого массива.
    /// </summary>
    /// <param name="n">Длина массива.</param>
    /// <returns>Новый массив.</returns>
    public static int[] Create(int n)
    {
        return new int[n];
    }
    /// <summary>
    /// Возвращает строку перечисления элементов массива.
    /// </summary>
    /// <param name="array">Массив целых чисел.</param>
    /// <param name="separator">Разделитель значений.</param>
    /// <returns>Строка перечисления элементов.</returns>
    public static string ConvertToString(this int[] array, char separator = ' ')
    {
        return $"[{String.Join(separator, array)}]";
    }
    /// <summary>
    /// Записывает в консоль значения массива.
    /// </summary>
    /// <param name="array">Массив целых чисел.</param>
    public static void ConsoleWrite(this int[] array)
    {
        Console.WriteLine(array.ConvertToString());
    }
    /// <summary>
    /// Заполняет массив случайными числами в диапазоне [min, max).
    /// </summary>
    /// <param name="array">Массив целых чисел.</param>
    /// <param name="min">Минимальное значение (включительное).</param>
    /// <param name="max">Максимальное значение (исключительно).</param>
    /// <param name="seed">Параметр для генерации случайного числа (для seed=0 используется случайное значение).</param>
    public static int[] FillRandom(this int[] array, int min = 0, int max = 10, int seed = 0)
    {
        Random r = seed == 0 ? new Random() : new Random(seed);
        return array = array.Select(item => r.Next(min, max)).ToArray();
    }
}

public static class ArrayMath
{
    /// <summary>
    /// Возвращает максимальную сумму m последовательных элементов массива.
    /// </summary>
    /// <param name="array">Массив целых чисел.</param>
    /// <param name="m">Число суммируемых элементов.</param>
    /// <returns>Максимальная сумма m последовательных элементов.</returns>
    public static int GetSum(this int[] array, int m = 3)
    {
        int size = array.Length;
        if (size < m) return 0;
        int max = 0;
        for (int i = 0; i <= size - m; i++)
        {
            int t = 0;
            for (int j = i; j < i + m; j++)
            {
                t += array[j];
            }
            if (t > max) max = t;
        }
        return max;
    }
    /// <summary>
    /// Возвращает максимальную сумму m последовательных элементов массива.
    /// </summary>
    /// <param name="array">Массив целых чисел.</param>
    /// <param name="m">Число суммируемых элементов.</param>
    /// <returns>Максимальная сумма m последовательных элементов.</returns>
    public static int GetSumFast(this int[] array, int m = 3)
    {
        int size = array.Length;
        if (size < m) return 0;
        int max = 0;
        for (int i = 0; i < m; i++)
        {
            max += array[i];
        }
        int sum = max;
        for (int i = 1; i <= size - m; i++)
        {
            sum = sum - array[i - 1] + array[i + m - 1];
            if (sum > max) max = sum;
        }
        return max;
    }
}
