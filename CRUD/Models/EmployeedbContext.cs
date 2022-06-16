using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class EmployeedbContext:DbContext
    {
        public EmployeedbContext(DbContextOptions<EmployeedbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
    }
}
