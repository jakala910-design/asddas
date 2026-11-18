using System;

namespace CSharpTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Устанавливаем кодировку для корректного отображения кириллицы
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine(" ВЫБЕРИТЕ НОМЕР ЗАДАНИЯ (1-15) ");
                Console.WriteLine(" 0 - Выход из программы       ");
                Console.WriteLine("==============================");
                Console.Write("Ваш выбор: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Ошибка! Введите число от 0 до 15.");
                    continue;
                }

                if (choice == 0) break;

                Console.Clear();
                switch (choice)
                {
                    case 1: Task1_Factorial(); break;
                    case 2: Task2_DigitCount(); break;
                    case 3: Task3_DigitSum(); break;
                    case 4: Task4_ReverseNumber(); break;
                    case 5: Task5_IsPrime(); break;
                    case 6: Task6_PrimesUpToN(); break;
                    case 7: Task7_GCD(); break;
                    case 8: Task8_ArrayAverage(); break;
                    case 9: Task9_SecondMax(); break;
                    case 10: Task10_ReverseArrayInPlace(); break;
                    case 11: Task11_CountVowels(); break;
                    case 12: Task12_Palindrome(); break;
                    case 13: Task13_RPSGame(); break;
                    case 14: Task14_GuessNumber(); break;
                    case 15: Task15_StudentsSystem(); break;
                    default: Console.WriteLine("Такого задания нет!"); break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // 1. Факториал числа
        static void Task1_Factorial()
        {
            Console.WriteLine("--- 1. Факториал числа ---");
            Console.Write("Введите N: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                long result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
                Console.WriteLine($"Факториал: {result}");
            }
            else
            {
                Console.WriteLine("Введите корректное неотрицательное целое число.");
            }
        }

        // 2. Количество цифр в числе
        static void Task2_DigitCount()
        {
            Console.WriteLine("--- 2. Количество цифр в числе ---");
            Console.Write("Введите число: ");
            if (long.TryParse(Console.ReadLine(), out long number))
            {
                if (number == 0)
                {
                    Console.WriteLine("Количество цифр: 1");
                    return;
                }

                number = Math.Abs(number);
                int count = 0;
                while (number > 0)
                {
                    number /= 10;
                    count++;
                }
                Console.WriteLine($"Количество цифр: {count}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        // 3. Сумма цифр числа
        static void Task3_DigitSum()
        {
            Console.WriteLine("--- 3. Сумма цифр числа ---");
            Console.Write("Введите число: ");
            if (long.TryParse(Console.ReadLine(), out long number))
            {
                number = Math.Abs(number);
                long sum = 0;
                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                Console.WriteLine($"Сумма цифр: {sum}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        // 4. Перевернуть число
        static void Task4_ReverseNumber()
        {
            Console.WriteLine("--- 4. Перевернуть число ---");
            Console.Write("Введите число: ");
            if (long.TryParse(Console.ReadLine(), out long number))
            {
                bool isNegative = number < 0;
                number = Math.Abs(number);
                long reversed = 0;

                while (number > 0)
                {
                    long digit = number % 10;
                    reversed = reversed * 10 + digit;
                    number /= 10;
                }

                if (isNegative) reversed = -reversed;
                Console.WriteLine($"Перевернутое число: {reversed}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        // 5. Проверка простого числа
        static void Task5_IsPrime()
        {
            Console.WriteLine("--- 5. Проверка простого числа ---");
            Console.Write("Введите число: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number <= 1)
                {
                    Console.WriteLine("Число не простое (должно быть больше 1)");
                    return;
                }

                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) Console.WriteLine("Число простое");
                else Console.WriteLine("Число не простое");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        // 6. Все простые числа до N
        static void Task6_PrimesUpToN()
        {
            Console.WriteLine("--- 6. Все простые числа до N ---");
            Console.Write("Введите N: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 2)
            {
                Console.Write("Простые числа: ");
                for (int i = 2; i <= n; i++)
                {
                    bool isPrime = true;
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime) Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Введите N >= 2.");
            }
        }

        // 7. НОД двух чисел (Алгоритм Евклида)
        static void Task7_GCD()
        {
            Console.WriteLine("--- 7. НОД двух чисел ---");
            Console.Write("Первое число: ");
            if (int.TryParse(Console.ReadLine(), out int a))
            {
                Console.Write("Второе число: ");
                if (int.TryParse(Console.ReadLine(), out int b))
                {
                    a = Math.Abs(a);
                    b = Math.Abs(b);
                    while (b != 0)
                    {
                        int temp = b;
                        b = a % b;
                        a = temp;
                    }
                    Console.WriteLine($"НОД: {a}");
                }
            }
        }

        // 8. Среднее значение массива
        static void Task8_ArrayAverage()
        {
            Console.WriteLine("--- 8. Среднее значение массива ---");
            int[] array = { 10, 20, 30, 40, 50 };
            Console.Write("Массив: ");
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine();

            double sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            double average = sum / array.Length;
            Console.WriteLine($"Среднее: {average}");
        }

        // 9. Второе максимальное число массива
        static void Task9_SecondMax()
        {
            Console.WriteLine("--- 9. Второе максимальное число массива ---");
            int[] array = { 15, 8, 27, 10, 27, 21 }; // Тест на одинаковые максимальные значения
            Console.Write("Массив: ");
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine();

            if (array.Length < 2)
            {
                Console.WriteLine("В массиве недостаточно элементов.");
                return;
            }

            int max = int.MinValue;
            int secondMax = int.MinValue;

            foreach (int num in array)
            {
                if (num > max)
                {
                    secondMax = max;
                    max = num;
                }
                else if (num > secondMax && num < max)
                {
                    secondMax = num;
                }
            }

            if (secondMax == int.MinValue)
                Console.WriteLine("Все элементы массива равны между собой.");
            else
                Console.WriteLine($"Второе максимальное: {secondMax}");
        }

        // 10. Перевернуть массив на месте
        static void Task10_ReverseArrayInPlace()
        {
            Console.WriteLine("--- 10. Перевернуть массив на месте ---");
            int[] array = { 1, 2, 3, 4, 5 };
            Console.Write("Было:  ");
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine();

            for (int i = 0; i < array.Length / 2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }

            Console.Write("Стало: ");
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine();
        }

        // 11. Подсчёт гласных в строке
        static void Task11_CountVowels()
        {
            Console.WriteLine("--- 11. Подсчёт гласных в строке ---");
            Console.Write("Введите строку: ");
            string input = Console.ReadLine() ?? "";
            string lowerInput = input.ToLower();
            string vowels = "аеёиоуыэюя";
            int count = 0;

            foreach (char c in lowerInput)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            Console.WriteLine($"Количество гласных: {count}");
        }

        // 12. Проверка палиндрома
        static void Task12_Palindrome()
        {
            Console.WriteLine("--- 12. Проверка палиндрома ---");
            Console.Write("Введите слово: ");
            string input = Console.ReadLine()?.Trim() ?? "";
            string text = input.ToLower();

            bool isPalindrome = true;
            int length = text.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (text[i] != text[length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome && text.Length > 0)
                Console.WriteLine("Палиндром");
            else
                Console.WriteLine("Не палиндром");
        }

        // 13. Камень, ножницы и бумага
        static void Task13_RPSGame()
        {
            Console.WriteLine("--- 13. Камень, ножницы и бумага ---");
            Console.WriteLine("Выберите: 1 - Камень, 2 - Ножницы, 3 - Бумага");
            Console.Write("Ваш выбор (1-3): ");

            if (int.TryParse(Console.ReadLine(), out int userChoice) && userChoice >= 1 && userChoice <= 3)
            {
                string[] options = { "Камень", "Ножницы", "Бумага" };
                Random rand = new Random();
                int compChoice = rand.Next(1, 4); // от 1 до 3

                Console.WriteLine($"Ваш выбор: {options[userChoice - 1]}");
                Console.WriteLine($"Компьютер: {options[compChoice - 1]}");

                if (userChoice == compChoice)
                {
                    Console.WriteLine("Ничья!");
                }
                else if ((userChoice == 1 && compChoice == 2) ||
                         (userChoice == 2 && compChoice == 3) ||
                         (userChoice == 3 && compChoice == 1))
                {
                    Console.WriteLine("Вы победили!");
                }
                else
                {
                    Console.WriteLine("Компьютер победил!");
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }

        // 14. Угадай число - 7 попыток
        static void Task14_GuessNumber()
        {
            Console.WriteLine("--- 14. Угадай число (от 1 до 100, 7 попыток) ---");
            Random rand = new Random();
            int secretNumber = rand.Next(1, 101);
            int maxAttempts = 7;
            bool win = false;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.Write($"Попытка {attempt}/{maxAttempts}: ");
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    if (guess == secretNumber)
                    {
                        Console.WriteLine($"Вы угадали за {attempt} попыток!");
                        win = true;
                        break;
                    }
                    else if (guess < secretNumber)
                    {
                        Console.WriteLine("Загаданное число больше.");
                    }
                    else
                    {
                        Console.WriteLine("Загаданное число меньше.");
                    }
                }
                else
                {
                    Console.WriteLine("Введите корректное число.");
                    attempt--; // не засчитывать неверный ввод как попытку
                }
            }

            if (!win)
            {
                Console.WriteLine($"Вы проиграли! Загаданное число было: {secretNumber}");
            }
        }

        // 15. Мини-система студентов
        static void Task15_StudentsSystem()
        {
            Console.WriteLine("--- 15. Мини-система студентов ---");
            string[] names = { "Али", "Анна", "Максим", "Иван", "Ольга" };
            double[] grades = { 85.0, 92.0, 71.0, 78.5, 95.0 };

            Console.WriteLine("Список студентов:");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{names[i]} — {grades[i]}");
            }

            // Вычисление средней оценки
            double sum = 0;
            double maxGrade = grades[0];
            int bestIndex = 0;

            for (int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
                if (grades[i] > maxGrade)
                {
                    maxGrade = grades[i];
                    bestIndex = i;
                }
            }

            double average = sum / grades.Length;

            // Подсчет студентов с оценкой выше среднего
            int countAboveAverage = 0;
            foreach (double grade in grades)
            {
                if (grade > average)
                {
                    countAboveAverage++;
                }
            }

            Console.WriteLine($"\nСредняя оценка: {average:F1}");
            Console.WriteLine($"Лучший студент: {names[bestIndex]} — {grades[bestIndex]}");
            Console.WriteLine($"Выше среднего: {countAboveAverage}");
        }
    }
}