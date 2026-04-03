using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementModels;

namespace TaskManagementDataService
{
    public class TaskManagementInMemoryData : ITaskDataService
    {
        public List<Tasks> tasks = new List<Tasks>();


        public void Add(Tasks task)
        {
            tasks.Add(task);
        }

        public List<Tasks> GetAll()
        {
            return tasks;
        }

        public void Delete(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
            }
        }

        public void Update(int index, Tasks updated)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index] = updated;
            }
        }

        public void UpdateStatus(int index, string status)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].Status = status;
            }
        }

        public void DeleteAll()
        {
            tasks.Clear();
        }
    }
}