using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeNow = DateTime.Now;
            File.AppendAllText("sturtup.txt", Convert.ToString(timeNow) + Environment.NewLine);
            Console.WriteLine($"Программа запущена в {timeNow}, и это время сохранено в файле sturtup.txt");
        }
    }
}
