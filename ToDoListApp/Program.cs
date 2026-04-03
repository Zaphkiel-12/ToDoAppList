using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TaskManagementAppService;
using TaskManagementModels;
namespace ToDoAppManagement
{
    internal class Program
    {
        static TasksAppService taskAppService = new TasksAppService();

        static void Main(string[] args)
        {


            bool adding = true;

            Console.WriteLine("=== Welcome to To Do List ver 3.0 !! >~< ===");
            while (adding)
            {
                Description();
                int choice = AskNumber("[QUESTION] What do you want to do: ", 1, 7);
                

                switch (choice)
                {
                    case 1:
                        addTask(); break;
                    case 2:
                        viewTask();
                        break;
                    case 3:
                        removeTask();
                        break;
                    case 4:
                        editTask(); break;
                    case 5:
                        taskStatus(); break;
                    case 6:
                        RemoveAllTasks(); break;
                    case 7:
                        adding = false;
                        Console.WriteLine("==== Thank you for using the To Do List ver 3.0 !! >~< ===="); break;
                }
            }
        }
        static void Description()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("1. ADD TASK");
            Console.WriteLine("2. VIEW TASKS");
            Console.WriteLine("3. REMOVE TASK");
            Console.WriteLine("4. EDIT TASK");
            Console.WriteLine("5. UPDATE TASK'S STATUS");
            Console.WriteLine("6. REMOVE ALL TASKS");
            Console.WriteLine("7. EXIT");
            Console.WriteLine("=================================");

        }
        static void addTask()
        {
            bool adding = true;
            while (adding)
            {
                Console.Write("Enter a task: ");
                string task = Console.ReadLine();

                Console.Write("Enter what date (MM/DD/YYYY): ");
                string day = Console.ReadLine();

                Console.Write("Enter what time of the day (am/pm): ");
                string time = Console.ReadLine();

                taskAppService.addTask(task, day, time);

                Console.WriteLine("\n === Task added succesfully!=== \n");
                char ch;


                adding = AskYesNo("[QUESTION] Do you wish to add more (y/n): ");
                        Console.WriteLine();
            }
        }
        static void viewTask()
        {
            var tasks = taskAppService.viewTask();
            if (tasks.Count == 0)
            {
                Console.WriteLine("\n === There is no tasks added yet!=== \n");
            }
            else if (tasks.Count > 0)
            {
                Console.WriteLine(" ----- Your tasks -----");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("TASK # " + (i + 1) + ": " + tasks[i].Task);
                    Console.WriteLine("     DATE: " + tasks[i].Date);
                    Console.WriteLine("     TIME: " + tasks[i].Time);
                    Console.WriteLine("     STATUS: " + tasks[i].Status);
                    Console.WriteLine("---------------------------------");
                }
            }
        }
        static void removeTask()
        {
            var tasks = taskAppService.viewTask();
            bool reLoop = true;

            if (tasks.Count == 0)
            {
                Console.WriteLine("\n There is no tasks added yet! \n"); return;
            }
            else if (tasks.Count > 0)
            {
                viewTask();
            }

            Console.WriteLine("=================================");

            while (reLoop)
            {
                int choice = AskNumber("Enter the number of the task you want to be removed: ", 1, tasks.Count);

                Console.WriteLine($"\n You have chosen to remove the task: {tasks[choice - 1].Task} \n");


                if (AskYesNo("[WARNING] Are you sure you want this to be permanently deleted (y/n): "))
                {
                    taskAppService.removeTask(choice - 1);
                    Console.WriteLine("\n Task is removed successfully \n");
                }
                else
                {
                    Console.WriteLine("\n Task is not removed successfully \n");
                }

                reLoop = AskYesNo("[QUESTION] Do you want to remove other tasks too (y/n): ");

            }
        }


        static void editTask()
        {
            var tasks = taskAppService.viewTask();
            viewTask();

            int choice = AskNumber("[QUESTION] Enter the task number you want to edit: ", 1, tasks.Count);
            int index = choice - 1;

            if (choice >= 0 && choice < tasks.Count)
            {
                Console.Write("New Task: ");
                tasks[index].Task = Console.ReadLine();
                Console.Write("New Date (MM/DD/YYYY): ");
                tasks[index].Date = Console.ReadLine();
                Console.Write("New Time (AM/PM): ");
                tasks[index].Time = Console.ReadLine();

                Console.WriteLine("=================================");
                Console.WriteLine("\n === Task is updated successfully!!=== \n ");

                taskAppService.editTask(index, tasks[index].Task, tasks[index].Date, tasks[index].Time);
            }
            else
            {
                Console.WriteLine("\n[WARNING] Invalid task number. Please try again !! \n");
            }
        }
        static void taskStatus()
        {
            var tasks = taskAppService.viewTask();
            bool restart = true;
            viewTask();

            int choice = AskNumber("[QUESTION] Enter the task number you want to add a status from: ", 1, tasks.Count);
            int index = choice - 1;

            if (choice >= 0 && choice < tasks.Count)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("1. Pending");
                Console.WriteLine("2. Ongoing");
                Console.WriteLine("3. Completed");
                Console.WriteLine("4. Cancelled");
                Console.WriteLine("=================================");
                Console.Write("[QUESTION] Enter the status of the current task: ");
                
                int numChoice = Convert.ToInt32(Console.ReadLine());

                switch (numChoice)
                {
                    case 1:
                        tasks[index].Status = "[PENDING] ";
                        Console.WriteLine("\n === The task is currently marked as pending.=== \n "); break;
                    case 2:
                        tasks[index].Status = "[ONGOING] ";
                        Console.WriteLine("\n === The task is currently marked as in progress.=== \n"); break;
                    case 3:
                        tasks[index].Status = "[COMPLETED] ";
                        Console.WriteLine("\n === The task is currently marked as completed.=== \n"); break;
                    case 4:
                        tasks[index].Status = "[CANCELLED] ";
                        Console.WriteLine("\n === The task is currently marked as dropped.=== \n"); break;
                }
                taskAppService.taskStatus(index, tasks[index].Status);
            }
        }

        static void RemoveAllTasks()
        {
           AskYesNo("[WARNING] Are you sure you want to permanently delete all tasks (y/n): ");
            taskAppService.clearAllTasks();
            Console.WriteLine("\n === All tasks are removed successfully. === \n");
        }
        static bool AskYesNo(string question)
        {
            while (true)
            {
                Console.Write(question);
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine(); 

                if (ch == 'y' || ch == 'Y')
                    return true;

                if (ch == 'n' || ch == 'N')
                    return false;

                Console.WriteLine("\n[WARNING] Invalid choice. Please enter Y or N only.\n");
            }
        }

        static int AskNumber(string question, int min, int max)
        {
            while (true)
            {
                Console.Write(question);

                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (num >= min && num <= max)
                        return num;
                }

                Console.WriteLine("\n[WARNING] Invalid input. Please enter a corresponding number.\n");
            }
        }

    }
}


                