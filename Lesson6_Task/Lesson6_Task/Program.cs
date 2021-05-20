using System;
using System.Diagnostics;

namespace Lesson6_Task // Диспетчер процессов
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] process = Process.GetProcesses();
            ShowProcesses(process);// показать запущенные процессы
            while (true)
            {                
                Console.WriteLine();
                Console.WriteLine($"Выберите действие: {Environment.NewLine}[o] - остановить процесс,{Environment.NewLine}[п] - показать запущенные процессы, {Environment.NewLine}[з] - завершить работу диспетчера");
                string userAnswer = Console.ReadLine();
                switch(userAnswer)
                {
                    case "o":
                    case "O":
                    case "О":
                    case "о":
                        KillProcess(process);
                        break;
                    case "П":
                    case "п":
                        ShowProcesses(process);// показать запущенные процессы
                        break;                        
                    case "З":
                    case "з":
                        return;
                        break;
                    default:
                        break;
                }                
            }
        }

        /// <summary>
        /// ShowProcesses - метод показать запущенные процессы.
        /// </summary>
        /// <param name="process"> массив запущенных процессов </param>
        static void ShowProcesses(Process[] process)
        {
            Console.WriteLine("Запущеные процессы");
            Console.WriteLine("id процесса\tИмя процесса\t\t\t\tЗанимаемая память        ");
            Console.WriteLine("=============== ======================================= =================");
            for (int i = 0; i < process.Length; i++)
            {
                var oneProcess = process[i];
                var id = oneProcess.Id.ToString();
                var name = oneProcess.ProcessName.ToString();
                var memory = oneProcess.VirtualMemorySize64;
                string tab1 = "\t\t";
                string tab2;
                #region Подбор табуляции

                if (name.Length > 39)
                    tab2 = " ";

                else if (name.Length <= 7)
                {
                    tab2 = "\t\t\t\t\t";
                }
                else if (name.Length >= 8 & name.Length < 16)
                {
                    tab2 = "\t\t\t\t";
                }
                else if (name.Length >= 16 & name.Length < 25)
                {
                    tab2 = "\t\t\t";
                }
                else if (name.Length >= 25 & name.Length < 34)
                {
                    tab2 = "\t\t";
                }
                else
                {
                    tab2 = "\t";
                }
                #endregion 
                Console.WriteLine($"{id}{tab1}{name}{tab2}{memory}"); // \t - символ табуляции
            }
        }


        /// <summary>
        /// KillProcess - метод позволяет завершить указанный пользователем процесс
        /// </summary>
        /// <param name="process"> массив существующих процессов </param>
        static void KillProcess (Process[] process)
        {
            Console.WriteLine("Укажите id процесса, или его имя чтобы завершить его");
            string idNameProcess = Console.ReadLine();
            bool OperationDone_id = false;
            for (int i = 0; i < process.Length; i++)
            {
                var oneProcess = process[i];
                var id = oneProcess.Id.ToString();
                var name = oneProcess.ProcessName.ToString();                
                if ((idNameProcess == id) || (idNameProcess == name))
                {
                    Console.WriteLine($"имя процесса - {name};{Environment.NewLine} id процесса - {id}; {Environment.NewLine} процесс запущен в - {oneProcess.StartTime}");
                    Console.WriteLine();
                    Console.WriteLine("Вы действительно хотите завершить процесс? (да/нет)");
                    string userConfirmation = Console.ReadLine();
                    if (userConfirmation == "да")
                    {
                        oneProcess.Kill();
                        OperationDone_id = true;
                        Console.WriteLine($"Указанный процесс [{name}] завершен.");
                    }
                    else
                    {
                        OperationDone_id = true;
                        Console.WriteLine($"Операция завершения процесса [{name}] прервана пользователем.");
                    }
                }                
            }
            if (OperationDone_id == false)
                Console.WriteLine($"Указанный процесс [{idNameProcess}], не найден");
        }
    }
}
