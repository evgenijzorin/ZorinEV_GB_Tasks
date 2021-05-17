using System;
using System.IO;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите произвольный набор чисел, от 0 до 255, используя пробел в качестве разделителя:");
            string userText = Console.ReadLine();
            // Перевести строку в массив
            string[] userTextArray = userText.Split(' ');
            // перевести строковый массив в массив byte массив
            byte[] userNumArray = new byte[userTextArray.Length];// создать массив
            for(int i = 0; i < userTextArray.Length; i++)
            {
                userNumArray[i] = Convert.ToByte(userTextArray[i]);
            }
            File.WriteAllBytes("user_numbers.bin", userNumArray); // сохранить файл
            Console.WriteLine("Файл user_numbers.bin с числами, которые вы ввели, сохранен");
            // File.ReadAllBytes("user_numbers.bin");            
        }
    }
}
