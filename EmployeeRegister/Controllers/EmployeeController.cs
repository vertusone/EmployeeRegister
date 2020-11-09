using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EmployeeRegister.Models;
using EmployeeRegister.ViewModels;

namespace EmployeeRegister.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ILogger<EmployeeController> _logger;

        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context, ILogger<EmployeeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.Include(e => e.Department);
            List<EmployeeDepartment> employeeDepartmentsLists = new List<EmployeeDepartment>();
            EmployeeDepartment ed;
            foreach (var item in employees)
            {
                ed = new EmployeeDepartment();
                ed.EmployeeID = item.EmployeeID;
                ed.EmplSurname = item.Surname;
                ed.EmplName = item.Name;
                ed.EmplMiddleName = item.MiddleName;
                ed.EmploymentDate = item.EmploymentDate;
                ed.Position = item.Position;
                if (item.Department == null)
                {
                    ed.DeptName = "";
                }
                else
                {
                    ed.DeptName = item.Department.Name;
                }


                employeeDepartmentsLists.Add(ed);
            }

            return View(employeeDepartmentsLists);
        }

        [HttpGet]
        public ViewResult AddEmployee()
        {
            List<Department> departments = _context.Departments.ToList();

            EmployeeDepartment ed = new EmployeeDepartment();
            ed.departmentsEDVM = new List<Department>();
            foreach (var item in departments)
            {
                ed.departmentsEDVM.Add(item);
            }
            ed.EmploymentDate = DateTime.Now;
            return View(ed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(EmployeeDepartment employeeDep)
        {
            List<Department> departments = _context.Departments.ToList();
            employeeDep.departmentsEDVM = new List<Department>();
            foreach (var item in departments)
            {
                employeeDep.departmentsEDVM.Add(item);
            }

            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.DeptID = employeeDep.DepartmentID;
                employee.EmployeeID = employeeDep.EmployeeID;
                employee.Surname = employeeDep.EmplSurname;
                employee.Name = employeeDep.EmplName;
                employee.MiddleName = employeeDep.EmplMiddleName;
                employee.EmploymentDate = employeeDep.EmploymentDate;
                employee.Position = employeeDep.Position;
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDep);

        }

        [HttpGet]
        public IActionResult DetailEmployee(int id)
        {
            var emp = _context.Employees.Include(e => e.Department).Where(e => e.EmployeeID == id).FirstOrDefault();
            EmployeeWithList ewzl = new EmployeeWithList();
            ewzl.EmployeeID = emp.EmployeeID;
            ewzl.Surname = emp.Surname;
            ewzl.Name = emp.Name;
            ewzl.MiddleName = emp.MiddleName;
            ewzl.Position = emp.Position;
            ewzl.EmploymentDate = emp.EmploymentDate;
            if (emp.Department == null)
            {
                ewzl.DeptName = "";
            }
            else
            {
                ewzl.DeptName = emp.Department.Name;
            }
            return View(ewzl);
        }

        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            Employee emp = _context.Employees.Find(id);
            List<Department> departments = _context.Departments.ToList();
            EmployeeDepartment ed;

            ed = new EmployeeDepartment();
            ed.EmployeeID = emp.EmployeeID;
            ed.EmplSurname = emp.Surname;
            ed.EmplName = emp.Name;
            ed.EmplMiddleName = emp.MiddleName;
            ed.Position = emp.Position;
            ed.EmploymentDate = emp.EmploymentDate;
            ed.DepartmentID = emp.DeptID;
            ed.departmentsEDVM = new List<Department>();
            if (emp.Department == null)
            {
                ed.DeptName = "";
            }
            else
            {
                ed.DeptName = emp.Department.Name;
                ed.departmentsEDVM.Add(emp.Department);
            }

            foreach (var item in departments)
            {
                if (item.DepartmentID != emp.DeptID)
                {
                    ed.departmentsEDVM.Add(item);
                }
            }

            return View(ed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployee(int id, EmployeeDepartment employeeDep)
        {
            List<Department> departments = _context.Departments.ToList();

            Employee employee = new Employee();
            employee.EmployeeID = employeeDep.EmployeeID;
            employee.Surname = employeeDep.EmplSurname;
            employee.Name = employeeDep.EmplName;
            employee.MiddleName = employeeDep.EmplMiddleName;
            employee.EmploymentDate = employeeDep.EmploymentDate;
            employee.Position = employeeDep.Position;
            employee.DeptID = employeeDep.DepartmentID;
            employeeDep.departmentsEDVM = new List<Department>();

            foreach (var item in departments)
            {
                employeeDep.departmentsEDVM.Add(item);
            }

            if (id != employeeDep.EmployeeID)
            {
                return Content("ID неверный.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExist(id))
                    {
                        return Content("Работник не существует");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDep);
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            Employee empl = _context.Employees.Find(id);
            _context.Employees.Remove(empl);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool EmployeeExist(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
