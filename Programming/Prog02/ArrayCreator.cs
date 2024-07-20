/// <summary> 
/// Это класс, отвечающий за создание массива
/// </summary> 
public static class ArrayCreator
{
    /// <summary>
    /// Метод создания массива
    /// </summary>
    /// <param name="n">Количество элементов</param>
    /// <returns>Новый массив</returns>
    public static int[] Create(this int n) 
    // "this" изменяет конструкцию "int[] array = ArrayCreator.Create(10)" в "Program.cs",
    // которая примет вид "int[] array = 10.Create"
    {
        return new int[n];
    }

    /// <summary>
    /// Метод, собирающий массив в строку
    /// </summary>
    /// <param name="array">Массив</param>
    /// <returns>Строка с представлением массива</returns>
    public static string ConvertToString(this int[] array) // (?) метод вывода на экран
    {
        string str = $"[{String.Join(' ', array)}]";
        System.Console.WriteLine(str);
        return str;
    }

    /// <summary>
    /// Заполняет массив
    /// </summary>
    /// <param name="array">Массив</param>
    /// <param name="min">Нижняя граница диапазона генератора случайных чисел</param>
    /// <param name="max">Верхняя граница диапазона генератора случайных чисел</param>
    public static int[] Fill(this int[] array, int min = 0, int max = 10, int seed = 0)
    {
       Random random = seed == 0 ? new Random(): new Random(seed);
       return array = array.Select(item => random.Next(min, max)).ToArray();
    }
}