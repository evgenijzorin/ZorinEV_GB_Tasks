using System;

namespace Task_3
{
    class Program
    {
        enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter,
            nothing
        } // сезоны
        static void Main(string[] args)
        {
            Season UserMonth;
            while (true)
            {
                Console.WriteLine("Укажите номер месяца от 1 до 12 целым числом:");
                int userNumberMonth = Convert.ToInt32(Console.ReadLine());
                if ((userNumberMonth < 13) & (userNumberMonth > 0))
                {
                    UserMonth = getSeasonByNomber(userNumberMonth);
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12, попробуйте еще раз.");
                }   
            }
            Console.WriteLine();
            Console.WriteLine($"Введенный месяц соответствует времени года {UserMonth}");

        }
        static Season getSeasonByNomber(int userNumberMonth) // Определить месяц по номеру
        {
            Season month;
            switch (userNumberMonth)
            {
                case 1:
                case 2:
                    month = Season.Winter;
                    break;
                case 3:
                case 4:
                case 5:
                    month = Season.Spring;
                    break;
                case 6:
                case 7:
                case 8:
                    month = Season.Summer;
                    break;
                case 9:
                case 10:
                case 11:
                    month = Season.Autumn;
                    break;
                case 12:
                    month = Season.Winter;
                    break;
                default:
                    month = Season.nothing;
                    break;
            }
            return month;

        }

    }
}
