using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegister.Enums;

namespace EmployeeRegister.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }
        
        [StringLength(250)]
        [Required(ErrorMessage = "Введите фамилию сотрудника.")]
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

        public int? DeptID { get; set; }
        public Department Department { get; set; }
    }
}
