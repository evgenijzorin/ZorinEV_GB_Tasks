using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        { // Задание №2 вывести сумму чисел введенных через пробел
            Console.WriteLine("Введите числа которые нужно суммировать, используя пробел в качестве разделителя, и ','(запятую) в качестве десятичного разделителя:");
            string numbersString = Console.ReadLine();
            Console.WriteLine($"Сумма введенных чисел = {SumStringNumber(numbersString)}");
        } 
                
        static float SumStringNumber (string numbersString)// Вернуть сумму чисел из строки чисел введенных через пробел
        {
            float sum = 0f;
            // перебор строки как массива
            string newStringNumber = "";
            for (int i = 0; i < numbersString.Length; i++)
            {
                if (numbersString[i] != ' ')
                {
                    newStringNumber = newStringNumber + numbersString[i];
                    if (i == (numbersString.Length - 1)) // для последней итерации
                    {
                        sum = sum + Convert.ToSingle(newStringNumber); // преобразовать в float
                        newStringNumber = "";
                    }
                }                
                else
                {
                    sum = sum + Convert.ToSingle(newStringNumber); // преобразовать в float
                    newStringNumber = "";
                }
            }
            return sum;
        }
    }
}
