using System;

namespace Lesson_4_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialsArray = new string[0]; // массив размерностью 0                                                   
            {// Запросс данных
                int i = 0; // счетчик итераций                
                string initials;
                while (true)
                {
                    i++;
                    Console.WriteLine("Введите фамилью:");
                    string lastName = Console.ReadLine();
                    if ((lastName == "о") || (lastName == "o") || (lastName == "0") || (lastName == "O") || (lastName == "o") || (lastName == "0") || (lastName == "O"))
                    {
                        break;
                    }
                    {
                        Console.WriteLine("Введите имя, или 'o'-прервать:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Введите отчество:");
                        string patronymic = Console.ReadLine();
                        initials = GetFullName(firstName, lastName, patronymic);
                        // Преобразовать размерность одномерного массива:
                        Array.Resize(ref initialsArray, i);
                        initialsArray[i-1] = initials;
                    }
                }
            }// Запросс данных
            {// Вывод данных ФИО на консоль
                Console.WriteLine();
                Console.WriteLine("Список введенных ФИО:");
                for (int i = 0; i < initialsArray.Length; i++)
                {
                    Console.WriteLine(initialsArray[i]);
                }
                Console.WriteLine();
            }// Вывод данных ФИО на консоль 
        }
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return lastName + " " + firstName  + " " + patronymic;
        }
    }
}
