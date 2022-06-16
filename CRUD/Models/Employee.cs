using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Place Enter Employee Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Place Enter Employee Surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Place Enter Employee Position")]
        public string Position { get; set; }
    }
}
