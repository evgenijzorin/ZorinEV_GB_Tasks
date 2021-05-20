using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    /// <summary>
    /// ToDo  - класс описывющий задачу.
    /// </summary>
    public class ToDo
    {
        // свойства класса 
        public int numberTask { get; set; }
        public string Title { get; set;}

        public bool IsDone { get; set; }

        // Методы класса
        /// <summary>
        /// ToDo  - метод конструктор. Создает задачу.
        /// </summary>
        /// <param name="isDone_m">Завершена ли задача: True|False</param>
        /// <param name="title_m">Наименование задачи.  </param>
        /// <param name="numberTask_m">Номер задачи</param>
        public ToDo (int numberTask_m, string title_m, bool isDone_m)
        {
            numberTask = numberTask_m;
            Title = title_m;
            IsDone = isDone_m;
        }
        // Метод конструктор по умолчанию (конструктор без параметров)
        public ToDo()
        {
            numberTask = 0;
            Title = "";
            IsDone = false;
        }
    }
}
