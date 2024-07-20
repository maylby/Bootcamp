// Буткемп. Программирование
// Урок 2. Алгоритмы в C# . Эффективность алгоритма
// https://gb.ru/lessons/375187

// using static ArrayCreator; 
// using static ArrayMath;

// В файле "Program.cs" не работает функция "<summary>" 
// (информирование об элементах из файла "ArrayCreator.cs")
// В VSCode лектора, в видео уроке, "<summary>" функционирует, у меня нет.
// В наборе файлов в VSCode лектора есть файл с эмблемой "Visual Studio 2022"
// Возможно, корректная работа "<summary>" в видео уроке связана с "Visual Studio 2022"
// Но в лекции об этой связи ничего не сказано

// int[] array = Create(10); // Вариант 1, с "using static ArrayCreator"
// int[] array = ArrayCreator.Create(10); // Вариант 2, без "using static ArrayCreator"

int[] array = 5.Create(); // Вариант 3, с "this" в "public static int[] Create(this int n)"
                // .Fill(1, 10, 100); // <- Не работает.
                // array.ConvertToStringAndPrintToTerminal(); // <- Не работает.
                // Требуется определение типа или пространства имен, 
                // либо признак конца файла.
// Данная конструкция у меня не работать, т.к. связь с "ArrayCreator.cs" частичная

Console.WriteLine($"BadGetSum: {array.BadGetSum()}");
Console.WriteLine($"BadGetSum: {array.GoodGetSum()}");

// Console.WriteLine(array.ConvertToString()); // метод прописан в "ArrayCreator.cs"
// Но нет коннекта между файлами "ArrayCreator.cs" и "Program.cs"
// Данная запись, у меня не работает.
// VSCode сообщает: "Не удалось найти выполняемый проект"

