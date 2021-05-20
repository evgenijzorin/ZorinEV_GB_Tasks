using System;
using System.IO;

namespace Task_4 // Сохранить дерево каталогов и файлов по заданному пути в текстовый файл с рекурсией и без
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите cсуществующий путь по которому надо выстроить визуализацию дерева,\n к  примеру: C:\\Program Files\\Microsoft Office");
            string userPathText = Console.ReadLine();//debug// string userPathText = "C:\\Program Files\\GeoSkill";
            // Составить дерево в файле
            MakeTree(userPathText);
            Console.WriteLine("Файл с визуализацией дерева сохранен в каталоге по умолчанию под именем user_Tree.txt");
        }

        // Метод Составление дерева
        static void MakeTree(string userPathText)
        {
            // Перевести строку в массив
            string[] userPathArray = userPathText.Split('\\');
            string parseDirectory = userPathArray[0] + "\\";   // рассматриваемоя директория
            string spaseLine = ""; // маркировка отступов (пробелов)
            // для корневого каталога:
            spaseLine = GetSpaseLine(spaseLine, parseDirectory);
            File.AppendAllText("user_Tree.txt", parseDirectory + Environment.NewLine);
            GetfilesAndDir(userPathText, parseDirectory, 0, spaseLine);
        }

        // Метод: получить содержимое директории
        static void GetfilesAndDir(string userPathText, string parsedPath, int numberDirectory, string spaseLine)
        {
            // обработка содержимого корневого каталога:
            string nextDirectory;
            if (userPathText.Split('\\').Length > numberDirectory + 1)
                nextDirectory = userPathText.Split('\\')[numberDirectory + 1];
            else
                nextDirectory = "";
            string[] files = Directory.GetFiles(parsedPath);            // получить файлы директории
            string[] directorys = Directory.GetDirectories(parsedPath); // получить каталоги директории
            // Соединить два массива
            string[] filesAndDir = new string[directorys.Length + files.Length];
            directorys.CopyTo(filesAndDir, 0);
            files.CopyTo(filesAndDir, directorys.Length);
            // записать имена файлов в файл
            for (int i1 = 0; i1 < filesAndDir.Length; i1++)
            {
                string LinePath = filesAndDir[i1];
                string[] fileDirName = LinePath.Split('\\');
                string name = fileDirName[fileDirName.Length - 1]; // текущий файл или каталог
                if (name == nextDirectory)
                {                    
                    File.AppendAllText("user_Tree.txt", spaseLine + name + Environment.NewLine);                    
                    GetfilesAndDir(userPathText, LinePath, numberDirectory + 1, GetSpaseLine(spaseLine, name));
                }                    
                else
                {
                    if (i1 == 0)
                    {                        
                        File.AppendAllText("user_Tree.txt", spaseLine + name + Environment.NewLine); // для первой итерации записываем имя корневого каталога
                    }    
                        
                    else
                    {                        
                        File.AppendAllText("user_Tree.txt", spaseLine + name + Environment.NewLine); // выводим последний элемент массива c отступами пробелами
                    }
                        
                }
            }
        }

        // Метод получение строки пробелов, соответствующей длине переданной строки
        static string GetSpaseLine(string spaseLine, string line)
        {
            string lineSpase = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (i == line.Length - 1)
                    lineSpase = lineSpase + "|";
                else
                    lineSpase = lineSpase + "-";
            }
            return spaseLine + lineSpase;
        }
    }
}
