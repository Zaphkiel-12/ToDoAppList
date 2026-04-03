using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementModels;

namespace TaskManagementDataService
{
    public interface ITaskDataService
    {
        void Add(Tasks task);
        List<Tasks> GetAll();
        void Delete(int index);
        void Update(int index, Tasks updated);
        void UpdateStatus(int index, string status);
        void DeleteAll();

    }
}
