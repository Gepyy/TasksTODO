using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = EF_Tasks_Data.DataModels.Task;

namespace EF_Tasks_Data
{
    public interface ICRUD_Tasks
    {
        Task CreateTask(string theme, string description, DateTime deadline);
        List<Task> ReadTask();
        Task UpdateTask(int id, string newTaskTheme, string newTaskDescription, DateTime newDeadline);
        void DeleteTask(int id);
        void CheckComplete(int id);
        Task GetById(int id);
    }
}
