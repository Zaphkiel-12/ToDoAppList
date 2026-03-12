using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using TaskManagementModels;

namespace TaskManagementAppService
{
    public class TasksAppService
    {
        private List<Tasks> tasks = new List<Tasks>();

        public void addTask(string task, string date, string time)
        {
            Tasks newTask = new Tasks();
            {
                newTask.Task = task;
                newTask.Date = date;
                newTask.Time = time;
                newTask.Status = "PENDING";
            }
            tasks.Add(newTask);
        }
        public List<Tasks> viewTask()
        {
            return tasks;
        }
        public void removeTask(int i)
        {
            if (i >= 0 && i < tasks.Count)
            {
                tasks.RemoveAt(i);
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
            }
        }
        public void taskStatus(int i, string status)
        {
            if (i >= 0 && i < tasks.Count)
            {
                tasks[i].Status = status;
            }
        }
    }
}