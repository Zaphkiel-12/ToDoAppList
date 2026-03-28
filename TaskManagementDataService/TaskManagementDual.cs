using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementModels;

namespace TaskManagementDataService
{
    public class TaskManagementDual
    {
            private TaskJsonData json;
            private TaskDBData sql;

            public TaskManagementDual()
            {
                json = new TaskJsonData();
                sql = new TaskDBData();
            }

            public List<Tasks> GetAll()
            {
  
                return sql.GetAll();
            }

            public void SaveAll(List<Tasks> tasks)
            {

                sql.SaveAll(tasks);

     
                json.SaveAll(tasks);
            }
        }
    }