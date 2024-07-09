using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroLevel
{
    internal class Task
    {
        private int taskId;
        public int TaskId
        {
            get => taskId;
            set => taskId = value;
        }

        private string taskContent;
        public string TaskContent
        {
            get => taskContent;
        }

        private bool taskStatus;
        public bool TaskStatus
        {
            get => taskStatus;
        }

        /// <summary>
        /// Конструктор, создает объект класса <see cref="Task"/>
        /// </summary>
        /// <param name="taskContent">Текстовое содержание задачи</param>
        public Task(string taskContent)
        {
            this.taskId = taskId;
            this.taskContent = taskContent;
            taskStatus = false;
        }

        /// <summary>
        /// Метод для переключения состояния задачи
        /// </summary>
        public void ToggleTaskStatus()
        {
            taskStatus = !taskStatus;
        }
    }
}
