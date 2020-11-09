using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegister.Models
{
    public class Department
    {
        [Required]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Введите название компании.")]
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(3)]
        public string Description { get; set; }

        //Navigational Property
        public ICollection<Employee> Employees { get; set; }
        
    }
}
