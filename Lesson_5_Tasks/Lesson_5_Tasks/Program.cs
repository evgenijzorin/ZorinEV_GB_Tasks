using System;
using System.IO;



namespace Task_1 // Ввести с клавиатуры текст и сохранить в текстовом файле
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите произвольный текст, затем нажмите Enter:");
            string userText = Console.ReadLine();
            File.WriteAllText("user note.txt", userText); // сохранить файл
            if (File.Exists("user note.txt"))
                Console.WriteLine("Файл с текстом который вы ввели сохранен, в каталоге назначенном по умолчинию");            
        }
    }
}
