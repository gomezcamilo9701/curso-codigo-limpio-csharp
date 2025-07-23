using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int selectedMenu = 0;
            do
            {
                selectedMenu = ShowMainMenu();
                if (selectedMenu == (int)MenuOptionEnum.MenuAdd)
                {
                    ShowMenuAdd();
                }
                else if (selectedMenu == (int)MenuOptionEnum.MenuRemove)
                {
                    ShowMenuRemove();
                }
                else if (selectedMenu == (int)MenuOptionEnum.MenuShowList)
                {
                    ShowMenuTaskList();
                }
            } while (selectedMenu != (int)MenuOptionEnum.MenuExit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowMenuTaskList();
                
                string taskNumberToRemove = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskNumberToRemove) - 1;

                if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
                {
                    Console.WriteLine("Numero de tarea seleccionado no es valido");
                    return;
                }

                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string taskItem = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + taskItem + " eliminada");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskItem = Console.ReadLine();
                TaskList.Add(taskItem);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al añadir la tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                ShowMenu();
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("----------------------------------------");
            var indexTask = 0;
            TaskList.ForEach(t => Console.WriteLine(++indexTask + ". " + t));
            Console.WriteLine("----------------------------------------");
        }
    }
}
