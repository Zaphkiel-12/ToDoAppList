using System;
using System.Collections.Generic;

namespace ToDoAppManagement
{


    internal class Program
    { static List<string> tasks = new List<string>();
        static void Main(string[] args)
        {
            

            bool adding = true;

            Console.WriteLine("=== Welcome to To Do List ver 1.0 !! >~< ===");
            while (adding)
            {
                Description();
                Console.Write("What do you want to do? ");

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
                        adding = false;
                        Console.WriteLine("==== Thank you for using the To Do List ver 1.0 !! >~< ====");

                        break;
                }
            }
        }
        static void Description()
        {          
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add Tasks");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Tasks");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=================================");
                Console.Write("What do you want to do? ");

            }
        static void addTask()
        {
            Console.Write("Enter a task: ");
            string task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine("Task added succesfulyy!");
        }
        static void viewTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("There is no tasks added yet!"); break;
            }
            else if (tasks.Count > 0)
            {
                Console.WriteLine(" ----- Your tasks -----");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine($"  {i + 1}. {tasks[i]}");
                    Console.WriteLine("----------------------");
                }
            }
        }
        static void removeTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("There is no tasks added yet!"); break;
            }
            else if (tasks.Count > 0)
            {
                Console.WriteLine(" ----- Your tasks -----");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine($"  {i + 1}. {tasks[i]}");
                    Console.WriteLine("----------------------");
                }
                Console.WriteLine("=================================");
                Console.Write("Enter the number of the task you want to be removed: ");
                int taskNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                if (taskNumber >= 0 && taskNumber < tasks.Count)
                {
                    tasks.RemoveAt(taskNumber);
                    Console.WriteLine("Task removed successfully!");
                }


            }
        }
        }
    }


                