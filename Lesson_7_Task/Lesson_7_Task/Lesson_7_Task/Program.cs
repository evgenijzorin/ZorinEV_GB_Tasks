using System;

namespace Lesson_7_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вычислит расстояние между двумя точками по координатам.");
            Console.WriteLine("Введите координаты первой точки x y, разделитель - пробел, десятичный разделитель ',' ");
            string coord1 = Console.ReadLine();
            Console.WriteLine("Введите координаты второй точки x y:");
            string coord2 = Console.ReadLine();
            // Перевести строку в массив
            string[] coord1Array = coord1.Split(' ');
            var x1C = coord1Array[0];
            var x1 = Convert.ToDouble(x1C);
            double y1 = Convert.ToDouble(coord1Array[1]);
            string[] coord2Array = coord2.Split(' ');
            double x2 = Convert.ToDouble(coord2Array[0]);
            double y2 = Convert.ToDouble(coord2Array[1]);
            double rezult = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine($"расстояние между точками a[{x1}, {y1}] и b[{x2}, {y2}] = [{rezult}]");
        }
    }
}
