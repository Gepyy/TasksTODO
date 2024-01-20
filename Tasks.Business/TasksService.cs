using EF_Tasks_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Business
{
    public class TasksService:ITaskService
    {
        public readonly ICRUD_Tasks _tasksRepo;
        public TasksService(ICRUD_Tasks tasksRepo)
        {
            _tasksRepo = tasksRepo;
        }
        public List<TasksDTO> ReadTasks()
        {
            var tasks = _tasksRepo.ReadTask();
            List<TasksDTO> listDTO = new List<TasksDTO>();
            foreach (var task in tasks)
            {
                listDTO.Add(new TasksDTO()
                {
                    TaskID = task.TaskID,
                    TaskTheme = task.TaskTheme,
                    Description = task.Description,
                    DeadLine = task.DeadLine,
                });
            }
            return listDTO;
        }
        public void CreateTasks(string theme, string description, DateTime deadline)
        {
            _tasksRepo.CreateTask(theme, description, deadline);
        }
        public void UpdateTasks(int id, string theme, string description, DateTime deadline)
        {
            _tasksRepo.UpdateTask(id, theme, description, deadline);
        }
        public void DeleteTasks(int id)
        {
            _tasksRepo.DeleteTask(id);
        }
        public void CheckComplete(int id)
        {
            _tasksRepo.CheckComplete(id);
        }
        public TasksDTO GetById(int id)
        {
            var temp = _tasksRepo.GetById(id);
            TasksDTO obj = new TasksDTO
            {
                TaskID = temp.TaskID,
                TaskTheme = temp.TaskTheme,
                Description = temp.Description,
                DeadLine = temp.DeadLine
            };
            return obj;
        }
    }

    public interface ITaskService
    {
        List<TasksDTO> ReadTasks();
        void CreateTasks(string theme, string description, DateTime deadline);
        void UpdateTasks(int id, string theme, string description, DateTime deadline);
        void DeleteTasks(int id);
        void CheckComplete(int id);
        TasksDTO GetById(int id);
    }
}
