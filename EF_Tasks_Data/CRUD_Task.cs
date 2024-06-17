using EF_Tasks_Data.DataModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = EF_Tasks_Data.DataModels.Task;
namespace EF_Tasks_Data
{
    //Create CRUD operations for Database, also check SQL Injection
    public class CRUD_Task:ICRUD_Tasks
    {
        public Task CreateTask(string theme, string description, DateTime deadline)
        {
            using (Context Mycontext = new Context())
            {
                Task item = new Task
                {
                    TaskTheme = theme,
                    Description = description,
                    DeadLine = deadline,
                    CheckComplete = false,
                    
                };

                Mycontext.Tasks.Add(item);
                Mycontext.SaveChanges();
                return item;
            }
        }

        public List<Task> ReadTask()
        {
            using (Context Mycontext = new Context())
            {
                List<Task> allTasks = Mycontext.Tasks.ToList();
                //foreach (Task task in allTasks)
                //{
                //    Console.WriteLine($"Task ID: {task.TaskID}, Theme: {task.TaskTheme}, Description: {task.Description}, Deadline: {task.DeadLine}, Complete? {task.CheckComplete}");
                //}
                return allTasks;
            }
        }

        public Task UpdateTask(int id, string newTaskTheme, string newTaskDescription, DateTime newDeadline)
        {
            using (Context Mycontext = new Context())
            {
                Task existingTask = Mycontext.Tasks.Find(id);
                if (existingTask != null)
                {
                    existingTask.TaskTheme = newTaskTheme;
                    existingTask.Description = newTaskDescription;
                    existingTask.DeadLine = newDeadline;
                    Mycontext.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Task with ID {id} not found.");
                }
                return existingTask;
            }
        }

        public void DeleteTask(int id)
        {
            using (Context Mycontext = new Context())
            {
                Task taskToDelete = Mycontext.Tasks.Find(id);

                if (taskToDelete != null)
                {
                    Mycontext.Tasks.Remove(taskToDelete);
                    Mycontext.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Task with ID {id} not found.");
                }
            }
        }

        public void CheckComplete(int id)
        {
            using (Context Mycontext = new Context())
            {
                Task taskComplete = Mycontext.Tasks.Find(id);

                if (taskComplete != null && taskComplete.CheckComplete == false)
                {
                    taskComplete.CheckComplete = true;
                    Mycontext.SaveChanges();
                }
                else if(taskComplete.CheckComplete == true)
                {
                    taskComplete.CheckComplete = false;
                    Mycontext.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Task with ID {id} not found.");
                }
            }
        }

        public Task GetById(int id)
        {
            using (Context Mycontext = new Context())
            {
                Task existingTask = Mycontext.Tasks.Find(id);

                if (existingTask != null)
                {
                    return existingTask;
                }
                else
                {
                    Console.WriteLine($"Task with ID {id} not found.");
                    return null;
                }
            }
        }
    }
}
