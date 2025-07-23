List<string> TaskList = new List<string>();

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
/// <summary>
/// Show the main menu 
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
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

void ShowMenuRemove()
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
            Console.WriteLine($"Tarea {taskItem} eliminada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuAdd()
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

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        ShowMenu();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void ShowMenu()
{
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;
    TaskList.ForEach(task => Console.WriteLine($"{++indexTask} . {task}"));
    Console.WriteLine("----------------------------------------");
}

public enum MenuOptionEnum
{
    MenuAdd = 1,
    MenuRemove = 2,
    MenuShowList = 3,
    MenuExit = 4
}
