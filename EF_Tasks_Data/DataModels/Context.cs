using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Tasks_Data.DataModels
{
    //connect database to this aplication
    public class Context:DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-UCR071K;Initial Catalog=TaskDB;Integrated Security=True;Encrypt=false;");
        }
    }
}
