using System;

class Program
{
    static void Main(string[] args)
    {
        // Задаем исходный массив строк
        string[] originalArray = new string[0];

        bool typing = true;
        while (typing)
        {
            Console.WriteLine("Введите элемент массива: ");
            Console.WriteLine("Для завершения заполнения нажмите клавишу end");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key != ConsoleKey.End)
            {
                string input = Console.ReadLine();

                // Создаем новый массив на один элемент больше
                string[] newArray = new string[originalArray.Length + 1];
                originalArray.CopyTo(newArray, 0); // Копируем существующие элементы
                newArray[originalArray.Length] = input; // Добавляем новый элемент
                originalArray = newArray;
            }
            else
            {
                typing = false;
            }
        }

        // Получаем массив строк, удовлетворяющих условию
        string[] filteredArray = FilterArrayByLength(originalArray, 3);

        // Выводим результат
        Console.WriteLine("[\"" + string.Join("\", \"", filteredArray) + "\"]");
    }

    static string[] FilterArrayByLength(string[] array, int maxLength)
    {
        // Сначала считаем, сколько элементов удовлетворяют условию
        int count = 0;
        foreach (string item in array)
        {
            if (item.Length <= maxLength)
            {
                count++;
            }
        }

        // Создаем массив нужного размера
        string[] result = new string[count];

        // Заполняем массив подходящими строками
        int index = 0;
        foreach (string item in array)
        {
            if (item.Length <= maxLength && index < count)
            {
                result[index] = item;
                index++;
            }
        }

        return result;
    }
}
