using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementModels;

namespace TaskManagementDataService
{
    public class TaskDataService
    {
        ITaskDataService _dataService;

        public TaskDataService(ITaskDataService dataService)
        {
            _dataService = dataService;
        }

        public void Add(Tasks task)
        {
            _dataService.Add(task);
        }

        public List<Tasks> GetAll()
        {
            return _dataService.GetAll();
        }

        public void Delete(int index)
        {
            _dataService.Delete(index);
        }

        public void Update(int index, Tasks updated)
        {
            _dataService.Update(index, updated);
        }

        public void UpdateStatus(int index, string status)
        {
            _dataService.UpdateStatus(index, status);
        }

        public void DeleteAll()
        {
            _dataService.DeleteAll();
        }
    }
}
