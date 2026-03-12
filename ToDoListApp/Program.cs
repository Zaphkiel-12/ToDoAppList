using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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

            Console.WriteLine("=== Welcome to To Do List ver 1.0 !! >~< ===");
            while (adding)
            {
                Description();
                Console.Write("[QUESTION] What do you want to do? ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("=================================");

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
                        adding = false;
                        Console.WriteLine("==== Thank you for using the To Do List ver 1.0 !! >~< ====");

                        break;
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
            Console.WriteLine("6. EXIT");
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

                Console.WriteLine("\n Task added succesfully! \n");

                Console.Write("[QUESTION] Do you wish to add more (y/n): ");
                char ch = Console.ReadKey().KeyChar;
                    if (ch == 'y' || ch == 'Y')
                    {
                    Console.WriteLine();
                    }
                    else if (ch == 'n' || ch == 'N')
                    {
                    Console.WriteLine();
                    adding = false;
                    }
                    else
                    {
                    adding = false;
                    Console.WriteLine("\n Invalid Choice. Please try again.\n");
                    }
                    
            }
        }
        static void viewTask()
        {
            var tasks = taskAppService.viewTask();
            if (tasks.Count == 0)
            {
                Console.WriteLine("\n There is no tasks added yet! \n");
            }
            else if (tasks.Count > 0)
            {
                Console.WriteLine(" ----- Your tasks -----");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("TASK # " + (i + 1)+ ": " + tasks[i].Task);
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
            } else if (tasks.Count > 0)
            {
                viewTask();
            }

                Console.WriteLine("=================================");

                while (reLoop)
                {
                    Console.Write("Enter the number of the task you want to be removed: ");
                    int choice = Convert.ToInt32(Console.ReadLine()) - 1;

                    Console.Write("[WARNING] Are you sure you want this to be permanently deleted (y/n): ");
                    char ch2 = Console.ReadKey().KeyChar;

                    switch (ch2)
                    {
                    case 'y':
                    case 'Y':
                            Console.WriteLine();
                            taskAppService.removeTask(choice);
                            Console.WriteLine("\n Task removed successfully! \n");
                            break;
                    case 'n':
                    case 'N':
                            reLoop = false;
                            Console.WriteLine("\n Task is not removed. Returning to main menu... \n");
                            break;
                    default:
                            reLoop = false;
                            Console.WriteLine("\n Invalid Choice. Please try again.");
                            break;
                    }
                
                    Console.Write("[QUESTION] Do you want to continue removing other tasks (y/n): ");
                    char ch = Console.ReadKey().KeyChar;

                    if (ch == 'y' || ch == 'Y')
                    {
                        Console.WriteLine();
                    }

                    else if (ch == 'n' || ch == 'N')
                    {
                        reLoop = false;
                        Console.WriteLine();
                    }
                    else
                    {
                        reLoop = false;
                        Console.WriteLine("\n Invalid Choice. Please try again.");
                    }
                }
            }

        
        static void editTask()
        {
            var tasks = taskAppService.viewTask();
            viewTask();

            Console.Write("Enter the task number you want to edit: ");
            int choice = Convert.ToInt32(Console.ReadLine()) - 1;

            if (choice >= 0 && choice < tasks.Count)
            {
                Console.Write("New Task: ");
                tasks[choice].Task = Console.ReadLine();
                Console.Write("New Day: ");
                tasks[choice].Date = Console.ReadLine();
                Console.Write("New Time: ");
                tasks[choice].Time = Console.ReadLine();

                Console.WriteLine("\n Task is updated successfully!! \n ");
            }
            else
            {
                Console.WriteLine("\n Invalid task number. Please try again !! \n");
            }
        }
        static void taskStatus()
        {
            var tasks = taskAppService.viewTask();
            bool restart = true;
            viewTask();

            while (restart)
            {
                Console.Write("Enter task number you want to add a status from: ");
                int choice = Convert.ToInt32(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < tasks.Count)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("1. Pending");
                    Console.WriteLine("2. Ongoing");
                    Console.WriteLine("3. Completed");
                    Console.WriteLine("4. Cancelled");
                    Console.WriteLine();
                    Console.Write("Enter the status of the current task: ");
                    int numChoice = Convert.ToInt32(Console.ReadLine());

                    switch (numChoice)
                    {
                        case 1:
                            tasks[choice].Status = "[PENDING] ";
                            Console.WriteLine("\n === The task is currently marked as pending.=== \n "); break;
                        case 2:
                            tasks[choice].Status = "[ONGOING] ";
                            Console.WriteLine("\n === The task is currently marked as in progress.=== \n"); break;
                        case 3:
                            tasks[choice].Status = "[COMPLETED] ";
                            Console.WriteLine("\n === The task is currently marked as completed.=== \n"); break;
                        case 4:
                            tasks[choice].Status = "[CANCELLED] ";
                            Console.WriteLine("\n === The task is currently marked as dropped.=== \n"); break;
                    }
                }
                Console.Write("[QUESTION] Do you wish to update the status of the other tasks (y/n): ");
                char ch = Console.ReadKey().KeyChar;

                if (ch == 'y' || ch == 'Y')
                {
                    Console.WriteLine();
                }
                else if (ch == 'n' || ch == 'N')
                {
                    restart = false;
                    Console.WriteLine();
                }
                else
                {
                    restart = false;
                    Console.WriteLine("\n Invalid Choice. Please try again.");
                }
                
                }
            }
        }
    }


                