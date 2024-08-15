using Microsoft.EntityFrameworkCore;
using ToDoListProject.Models;

namespace ToDoListProject.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {         
        }
        public DbSet<TaskList> MyProperty { get; set; }
    }
}
