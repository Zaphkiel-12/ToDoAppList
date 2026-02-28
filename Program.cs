using System;
using System.Collections.Generic;

namespace ToDoAppManagement { 


    internal class Program
{
    static void Main(string[] args)
    {
        List<string> tasks = new List<string>();

        bool adding = true;


        Console.WriteLine("=== Welcome to To Do List ver 1.0 !! >~< ===");
        while (adding)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("1. Add Tasks");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Remove Tasks");
            Console.WriteLine("4. Exit");
            Console.WriteLine("=================================");
            Console.Write("What do you want to do? ");
            
                int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=================================");
                switch (choice) {
                case 1:

                    Console.Write("Enter a task: ");
                    string task = Console.ReadLine();
                    tasks.Add(task);
                    Console.WriteLine("Task added succesfulyy!"); break;

                case 2:

                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("There is no tasks added yet!"); break;
                    }
                    else if (tasks.Count > 0)
                    {
                        Console.WriteLine("Your tasks: ");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tasks[i]}");
                        }
                    }
                    break;
                case 3:
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("There is no tasks added yet!"); break;
                    }
                    else if (tasks.Count > 0)
                    {
                        Console.WriteLine("Your tasks: ");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tasks[i]}");
                        }
                        Console.Write("Enter the number of the task you want to be removed: ");
                        int taskNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (taskNumber >= 0 && taskNumber < tasks.Count)
                        {
                            tasks.RemoveAt(taskNumber);
                            Console.WriteLine("Task removed successfully!");
                        }


                    } break;
                 case 4:
                        adding = false;
                        Console.WriteLine("==== Thank you for using the To Do List ver 1.0 !! >~< ====");

                        break;
            }
        }
    } } }