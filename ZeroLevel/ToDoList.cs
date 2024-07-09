using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroLevel
{
    internal class ToDoList
    {
        private List<Task> taskList;
        public List<Task> TaskList
        { 
            get => taskList;
        }

        private int lastTaskId;

        /// <summary>
        /// Конструктор, создает объект класса <see cref="ToDoList"/>
        /// </summary>
        public ToDoList()
        {
            this.taskList = new List<Task>();
            lastTaskId = 0;
        }

        /// <summary>
        /// Конструктор, создает объект класса <see cref="ToDoList"/>
        /// </summary>
        /// <param name="taskList">Список задач</param>
        public ToDoList(List<Task> taskList)
        {
            this.taskList = taskList;
        }

        /// <summary>
        /// Метод для добавления новой задачи
        /// </summary>
        /// <param name="newTask">Добавляемая задача</param>
        public void AddTask(Task newTask)
        {
            newTask.TaskId = ++lastTaskId;
            taskList.Add(newTask);
        }

        /// <summary>
        /// Метод для удаления задачи по id
        /// </summary>
        /// <param name="delTaskId">id удаляемой задачи</param>
        public void RemoveTaskById(int delTaskId)
        {
            Task delTask = taskList.FirstOrDefault(task => task.TaskId == delTaskId);
            if (delTask != null)
            {
                taskList.Remove(delTask);
            }
        }

        /// <summary>
        /// Метод для переключения состояния задачи по id
        /// </summary>
        /// <param name="taskId">id задачи, состояние которой нужно переключить</param>
        public void ToggleTaskStatusById(int taskId)
        {
            taskList.FirstOrDefault(task => task.TaskId == taskId)?.ToggleTaskStatus();
        }

        /// <summary>
        /// Метод для фильтрации списка задачь по состоянию
        /// </summary>
        /// <param name="filterStatus">Статус, по которому нужно отфильтровать список</param>
        public List<Task> FilterTasksByStatus(bool filterStatus)
        {
            List<Task> FilteredTaskList = TaskList.Where(task => task.TaskStatus == filterStatus).ToList();
            return FilteredTaskList;
        }
    }
}
