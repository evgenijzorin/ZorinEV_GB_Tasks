using System;
using System.IO;
using System.IO.Compression;
using System.Text.Json; // пространство имен для сериализации текста формата Json

namespace Task_5 // Список задач ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Действие_1 Загрузка существующего списка задач
            Console.WriteLine("Существующие задачи:");
            ShowAllTasks();
            Console.WriteLine();
            //Действие_2 Запрос требуемого действия пользователя
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите действие: \n[в] Ввести новую задачу\n[п] Показать список существующих задач\n[з] Завершить");                
                string userAnsver = Console.ReadLine();
                switch(userAnsver)
                {
                    case "В":
                    case "в":
                        Console.WriteLine();
                        MakeNewTask();
                        break;
                    case "П":
                    case "п":
                        Console.WriteLine();
                        ShowAllTasks();
                        break;
                    case "з":
                    case "З":
                        return;
                    default:
                        break;
                }
            }   
        }

        // Метод создать задачу и сохранить задачу
        static void MakeNewTask ()
        {
            int NumberTask;
            bool isDone;
            Console.WriteLine("Введите наименование задачи:");
            string userNameTask = Console.ReadLine();
            Console.WriteLine("Введите номер задачи(при этом задача будет считаться выполненной) или нажмите enter:");
            string userNumberTask = Console.ReadLine();
            if (userNumberTask != "")
            {
                NumberTask = Convert.ToInt32(userNumberTask);
                isDone = true;
            }                
            else
            {
                NumberTask = getNextNumberTask();
                isDone = false;
            }                
            if (userNameTask != "")
            {
                ToDo newToDo = new ToDo(NumberTask, userNameTask, isDone);                
                string JsonText = JsonSerialising(newToDo);
                if (!Directory.Exists("Object_Task"))
                    Directory.CreateDirectory("Object_Task");
                File.WriteAllText("Object_Task" +"\\" + "tasks"+ NumberTask +".json", JsonText);
            }
        }
        // Метод показать все задачи
        static void ShowAllTasks()
        {
            if (Directory.Exists("Object_Task")) // Существование директории 
            {
                string[] files = Directory.GetFiles("Object_Task");            // получить файлы директории
                if (files.Length != 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        var file = files[i];
                        #region Чтение Json файла
                        string tasksText = File.ReadAllText(file);
                        //Десериализация списка задач построчно в массив объектов ToDo                    
                        ToDo newTodo = JsonSerializer.Deserialize<ToDo>(tasksText);
                        string flagDone;
                        if (newTodo.IsDone)
                            flagDone = "[x]";
                        else
                            flagDone = "[ ]";
                        Console.WriteLine($"{flagDone} {newTodo.numberTask}. {newTodo.Title}.");
                        #endregion
                    }
                }
                else
                {
                    Console.WriteLine("Список задач пуст.");
                }
            }
            else
            {
                Console.WriteLine("Список задач пуст.");
            }
        }

        // Метод сериализация текста в json
        static string JsonSerialising (ToDo newToDo)
        {
            string JsonText = JsonSerializer.Serialize(newToDo);
            return JsonText;
        }

        // Метод получить следующий номер задачи
        static int getNextNumberTask()
        {
            int NextNum =0;
            if (Directory.Exists("Object_Task")) // Существование директории 
            {
                string[] files = Directory.GetFiles("Object_Task");            // получить файлы директории
                if (files.Length != 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        var file = files[i];
                        #region Чтение Json файла
                        string tasksText = File.ReadAllText(file);
                        //Десериализация списка задач построчно в массив объектов ToDo                    
                        ToDo newTodo = JsonSerializer.Deserialize<ToDo>(tasksText);
                        if (NextNum < newTodo.numberTask)
                            NextNum = newTodo.numberTask;
                        #endregion
                    }
                }
            }                
            return NextNum + 1;
        }



    }
}
