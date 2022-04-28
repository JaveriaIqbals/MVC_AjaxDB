using Microsoft.EntityFrameworkCore;
using MVC_AjaxFunc.Models;

namespace MVC_AjaxFunc.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; } 
    }
}
