/*Задано текстовий файл. У файлі рядки в яких міститься осмислене текстове повідомлення. Слова повідомлення розділяються 
    пробілами та розділовими знаками Записати у новий файл всі підтексти заданого формату, підрахувати їх кількість,
    вилучити та замінити деякі з них, за вказаними параметрами користувача.
    1.5. У тексті можуть міститися адреси web-сайтів домена com.*/
using System;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Task 1");
            Console.WriteLine("1. Task 2");
            Console.WriteLine("2. Task 3");
            Console.WriteLine("2. Task 4");
            Console.WriteLine("2. Task 5 ");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Task5();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    /*Задано текстовий файл. У файлі рядки в яких міститься осмислене текстове повідомлення. Слова повідомлення розділяються 
    пробілами та розділовими знаками Записати у новий файл всі підтексти заданого формату, підрахувати їх кількість,
    вилучити та замінити деякі з них, за вказаними параметрами користувача.
    1.5. У тексті можуть міститися адреси web-сайтів домена com.*/
    static void Task1()
    {
        Console.Write("Enter input file path: ");
        string inputFilePath = Console.ReadLine();

        Console.Write("Enter output file path: ");
        string outputFilePath = Console.ReadLine();

        Console.Write("Enter search pattern: ");
        string searchPattern = @"\b\w+\.com\b";

        Console.Write("Enter replacement pattern: ");
        string replacementPattern = "HERE";

        try
        {
            string inputText = File.ReadAllText(inputFilePath);
            string replacedText = Regex.Replace(inputText, searchPattern, replacementPattern);

            File.WriteAllText(outputFilePath, replacedText);

            int count = Regex.Matches(inputText, searchPattern).Count;
            Console.WriteLine($"Total occurrences found: {count}");
            Console.WriteLine("Task completed successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
    //Видаліть із повідомлення тільки ті українські слова, які починаються на голосну літеру.
    static void Task2()
    {
        Console.Write("Enter input file path for Task2: ");
        string inputFilePath = Console.ReadLine();

        Console.Write("Enter output file path for Task2: ");
        string outputFilePath = Console.ReadLine();
        string inputText = File.ReadAllText(inputFilePath);
        string[] words = inputText.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';', '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> outputWords = new List<string>();
        foreach (string word in words)
        {
            if (!Regex.IsMatch(word, @"^[аеєиіоуАЕЄИІОУ].*", RegexOptions.IgnoreCase))
            {
                outputWords.Add(word);
            }
        }

        string outputText = string.Join(" ", outputWords);
        File.WriteAllText(outputFilePath, outputText);

        Console.WriteLine("Task2 completed successfully!");


    }
  //  Задано текст, слова в якому розділені пробілами і розділовими знаками.Розробити програму, яка вилучає в кожному слові цього тексту всі наступні входження першої літери.
    static void Task3()
    {
        Console.Write("Enter input file path for Task3: ");
        string inputFilePath = Console.ReadLine();

        Console.Write("Enter output file path for Task3: ");
        string outputFilePath = Console.ReadLine();

        string inputText = File.ReadAllText(inputFilePath);

        char firstChar = inputText[0];
        string cleanedText = firstChar + Regex.Replace(inputText.Substring(1), $"{firstChar}", "", RegexOptions.IgnoreCase);

        File.WriteAllText(outputFilePath, cleanedText);

        Console.WriteLine("Task3 completed successfully!");
    }
    //Дана послідовність із n цілих чисел. Створити файл і записати в нього всі додатні числа послідовності. Вивести вміст файлу на екран.
    static void Task4()
    { 
        string directoryPath = "C:\\Users\\Админ\\Desktop\\Csharplab1\\Lab3";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }


        Console.Write("Enter the number of integers: ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter integer {i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

       
        var positiveNumbers = numbers.Where(num => num > 0).ToArray();

        string filePath = "C:\\Users\\Админ\\Desktop\\Csharplab1\\Lab3\\four.bin";

        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            foreach (int num in positiveNumbers)
            {
                writer.Write(num);
            }
        }

        
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            Console.WriteLine("Positive numbers:");
            try
            {
                while (true)
                {
                    int num = reader.ReadInt32();
                    Console.WriteLine(num);
                }
            }
            catch (EndOfStreamException)
            {
            }
        }

        Console.WriteLine("Task completed successfully!");
    }
    static void Task5()
    {

        string studentName = "Zubko";
        string folder1Path = $"d:\\temp\\{studentName}1";
        string folder2Path = $"d:\\temp\\{studentName}2";
        string allFolderPath = "d:\\temp\\ALL";

        Directory.CreateDirectory(folder1Path);
        Directory.CreateDirectory(folder2Path);
     
        string t1FilePath = Path.Combine(folder1Path, "t1.txt");
        string t2FilePath = Path.Combine(folder1Path, "t2.txt");

        string t1Text = "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>";
        string t2Text = "<Комар Сергій Федорович, 2000 > року народження, місце проживання <м. Київ>";

        File.WriteAllText(t1FilePath, t1Text);
        File.WriteAllText(t2FilePath, t2Text);

        string t3FilePath = Path.Combine(folder2Path, "t3.txt");
        File.WriteAllText(t3FilePath, File.ReadAllText(t1FilePath) + "\n" + File.ReadAllText(t2FilePath));

        PrintFileInfo(t1FilePath);
        PrintFileInfo(t2FilePath);
        PrintFileInfo(t3FilePath);

        string moveT2FilePath = Path.Combine(folder2Path, "t2.txt");
        if (File.Exists(moveT2FilePath))
        {
            File.Delete(moveT2FilePath);
        }
        File.Move(t2FilePath, moveT2FilePath);

        string copyT1FilePath = Path.Combine(folder2Path, "t1.txt");
        File.Copy(t1FilePath, copyT1FilePath);

        if (Directory.Exists(allFolderPath))
        {
            Directory.Delete(allFolderPath, true); 
        }
        Directory.Move(folder1Path, allFolderPath);

        Directory.Delete(folder2Path, true);

        Console.WriteLine("\nFiles in All directory:");
        string[] filesInAll = Directory.GetFiles(allFolderPath);
        foreach (string file in filesInAll)
        {
            PrintFileInfo(file);
        }
    }

    static void PrintFileInfo(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        Console.WriteLine($"File: {fileInfo.Name}");
        Console.WriteLine($"Path: {fileInfo.FullName}");
        Console.WriteLine($"Size: {fileInfo.Length} bytes");
        Console.WriteLine($"Created: {fileInfo.CreationTime}");
        Console.WriteLine($"Last Modified: {fileInfo.LastWriteTime}");
        Console.WriteLine();
    }
}




