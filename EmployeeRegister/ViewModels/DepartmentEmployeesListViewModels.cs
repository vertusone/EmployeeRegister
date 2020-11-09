using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegister.Models;

namespace EmployeeRegister.ViewModels
{
    public class DepartmentEmployeesListViewModels
    {
        //Department
        [Required]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Введите название компании.")]
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }

        //List of employees assigned to company department
        public List<Employee> EmployeesList { get; set; }
    }
}
