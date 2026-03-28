using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementModels;

namespace TaskManagementDataService
{
    public class TaskDataService
    {

            private List<Tasks> tasks = new List<Tasks>();

            public List<Tasks> GetAll()
            {
                return tasks;
            }

            public void SaveAll(List<Tasks> updatedTasks)
            {
                tasks = updatedTasks;
            }
        }
    }
