using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EF_Tasks_Data.DataModels
{
    public class Task
    {
        //Create Model for Task
        public int TaskID { get; set; }
        public string TaskTheme { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public bool CheckComplete { get; set; }
    }
}
