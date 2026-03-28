using System;
using System.Collections.Generic;
using TaskManagementModels;
using TaskManagementDataService;

namespace TaskManagementAppService
{
    public class TasksAppService
    {
        private TaskManagementDual dataService;
        private List<Tasks> tasks;

        public TasksAppService()
        {
            TaskDBData taskdb = new TaskDBData();
            dataService = new TaskManagementDual();
            tasks = dataService.GetAll();
        }

        public void addTask(string task, string date, string time)
        {
            Tasks newTask = new Tasks
            {
                Task = task,
                Date = date,
                Time = time,
                Status = "[PENDING]"
            };

            tasks.Add(newTask);
            dataService.SaveAll(tasks);
        }

        public List<Tasks> viewTask()
        {
            tasks = dataService.GetAll();
            return tasks;
        }

        public void removeTask(int i)
        {
            if (i >= 0 && i < tasks.Count)
            {
                tasks.RemoveAt(i);
                dataService.SaveAll(tasks);
            }
        }

        public void editTask(int i, string task, string date, string time, string status)
        {
            if (i >= 0 && i < tasks.Count)
            {
                tasks[i].Task = task;
                tasks[i].Date = date;
                tasks[i].Time = time;
                tasks[i].Status = status;
                dataService.SaveAll(tasks);
            }
        }

        public void taskStatus(int i, string status)
        {
            if (i >= 0 && i < tasks.Count)
            {
                tasks[i].Status = status;
                dataService.SaveAll(tasks);
            }
        }
    }
}