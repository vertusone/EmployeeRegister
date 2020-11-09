using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegister.Models;
using EmployeeRegister.Enums;
using Position = EmployeeRegister.Enums.Position;

namespace EmployeeRegister.ViewModels
{
    public class EmployeeWithList
    {
        //Employee
        [Required]
        public int EmployeeID { get; set; }
        
        [Required(ErrorMessage = "Введите фамилию сотрудника.")]
        [StringLength(250)]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Введите имя сотрудника.")]
        [StringLength(250)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Введите отчество сотрудника.")]
        [StringLength(250)]
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Введите дату приёма на работу сотрудника.")]
        public DateTime EmploymentDate { get; set; }
        
        [Required(ErrorMessage = "Выберите должность сотрудника.")]
        public Position Position { get; set; }

        //Employee's Department
        [Required]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Введите название компании.")]
        [StringLength(250)]
        public string DeptName { get; set; }

    }
}
