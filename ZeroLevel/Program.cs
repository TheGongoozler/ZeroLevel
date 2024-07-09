using ZeroLevel;

namespace ZeroLevel
{
    class Program
    {
        public static string options = "1. Добавить задачу\n" +
                                "2. Удалить задачу\n" +
                                "3. Переключить состояние задачи (выполнено/не выполнено)\n" +
                                "4. Фильтровать задачи по состоянию\n" +
                                "5. Убрать фильтр\n" +
                                "0. Выход\n";

        /// <summary>
        /// Метод для вывода списка задач
        /// </summary>
        /// <param name="taskList">Выводимый список задач</param>
        public static void DisplayTaskList(List<Task> taskList)
        {
            
            Console.WriteLine("_____________________________");
            if (taskList.Count == 0) Console.WriteLine("Список пуст.");
            else
            {
                foreach (var task in taskList)
                {
                    Console.WriteLine("#" + task.TaskId.ToString() + " "
                                          + task.TaskContent + "\t\t"
                                          + (task.TaskStatus ? "Выполнено" : "Не выполнено"));
                }
            }
            Console.WriteLine("_____________________________");
        }

        public static void Main(String[] args)
        {
            ToDoList workList = new ToDoList();
            bool filtered = false;
            bool filterType = false;
            while (true)
            {
                Console.WriteLine("Список Задач | Фильтр: " + (filtered ? (filterType ? "Выполнено" : "Не выполнено") : "Нету"));
                if (filtered)
                {
                    DisplayTaskList(workList.FilterTasksByStatus(filterType));
                }
                else DisplayTaskList(workList.TaskList);
                Console.Write(options);
                Console.Write("Введите номер операции: ");
                int selectedOption = Convert.ToInt32(Console.ReadLine());
                switch (selectedOption)
                {
                    case 0:
                        {
                            Console.Write("Выход...");
                            return;
                        };
                    case 1:
                        {
                            Console.Write("Введите описание задачи: ");
                            string taskDescription = Console.ReadLine();
                            if (taskDescription == "")
                            {
                                Console.Write("Описание не должно быть пустым.");
                                Console.ReadLine();
                            }
                            else
                            {
                                Task newTask = new Task(taskDescription);
                                workList.AddTask(newTask);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Введите id задачи, которую желаете удалить: ");
                            int delTaskId = Convert.ToInt32(Console.ReadLine());
                            workList.RemoveTaskById(delTaskId);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Введите id задачи, состояние которой желаете изменить: ");
                            int taskId = Convert.ToInt32(Console.ReadLine());
                            workList.ToggleTaskStatusById(taskId);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Выберите фильтр (Y = Выполнено / N = Не выполнено):");
                            string chosenFilter = Console.ReadLine();
                            switch(chosenFilter)
                            {
                                case "Y":
                                    {
                                        filterType = true;
                                        filtered = true;
                                        break;
                                    }
                                case "N":
                                    {
                                        filterType = false;
                                        filtered = true;
                                        break;
                                    }
                                default:
                                    {
                                        Console.Write("Нет такого фильтра");
                                        Console.ReadLine();
                                        break;
                                    }
                            }
                            break;
                        }
                    case 5:
                        {
                            filtered = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный номер операции");
                            Console.ReadLine();
                            break;
                        }
                }
                Console.Clear();
            }
        }
    }
}