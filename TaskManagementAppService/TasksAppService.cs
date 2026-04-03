using System;
using System.Collections.Generic;
using TaskManagementModels;
using TaskManagementDataService;

namespace TaskManagementAppService
{
    public class TasksAppService
    {
        TaskDataService dataService = new TaskDataService(new TaskDBData());
        private List<Tasks> tasks;

        public TasksAppService()
        {
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
            dataService.Add(newTask);
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
                var task = tasks[i];
                tasks.RemoveAt(i);
                dataService.Delete(task.Id);
            }
        }

        public void editTask(int i, string taskname, string date, string time)
        {
            if (i >= 0 && i < tasks.Count)
            {
                var task = tasks[i];
                tasks[i].Task = taskname;
                tasks[i].Date = date;
                tasks[i].Time = time;
                dataService.Update(task.Id, task);
            }
        }

        public void taskStatus(int i, string status)
        {
            if (i >= 0 && i < tasks.Count)
            {
                var task = tasks[i];
                tasks[i].Status = status;
                dataService.UpdateStatus(task.Id, status);
            }
        }

        public void clearAllTasks()
        {
            tasks.Clear();
            dataService.DeleteAll();
        }
    }
}