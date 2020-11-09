using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegister.Enums;
using EmployeeRegister.Models;

namespace EmployeeRegister.ViewModels
{
    public class EmployeeDepartment
    {
        //Department
        [Required]
        public int? DepartmentID { get; set; }
        public string DeptName { get; set; }

        public List<Department> departmentsEDVM { get; set; }

        //Employee
        [Required]
        public int EmployeeID { get; set; }
        
        [Required(ErrorMessage = "Введите фамилию сотрудника.")]
        [StringLength(250)]
        public string EmplSurname { get; set; }
        
        [Required(ErrorMessage = "Введите имя сотрудника.")]
        [StringLength(250)]
        public string EmplName { get; set; }
        
        [Required(ErrorMessage = "Введите отчество сотрудника.")]
        [StringLength(250)]
        
        public string EmplMiddleName { get; set; }
        
        [Required(ErrorMessage = "Введите дату приёма на работу сотрудника.")]
        public DateTime EmploymentDate { get; set; }
        
        [Required(ErrorMessage = "Выберите должность сотрудника.")]
        public Position Position { get; set; }
    }
}
