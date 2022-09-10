using Microsoft.AspNetCore.Mvc;
using Northwind.Web.Models;
using Northwind.Web.Repository;
using System;
using System.Collections.Generic;

namespace Northwind.Web.Controllers
{
    public class EmployeeController : Controller
    {
        //use depedency injection
        private readonly IEmployee _IEmployee;

        public EmployeeController(IEmployee iEmployee)
        {
            _IEmployee = iEmployee;
        }

        public IActionResult ListEmployee()
        {
           
            //var listOfEmployee = new List<Employee> () {
            //    new Employee { Id=100,Name="irham rafi",BirthDate=new DateTime(2000,03,07)}, 
            //    new Employee { Id = 102, Name = "Dios", BirthDate = new DateTime(1999, 10, 04) },
            //    new Employee { Id = 103, Name = "Mahreza", BirthDate = new DateTime(2001, 04, 01) }
            //};
            return View("ListEmployee",_IEmployee.GetAll());
        }
    }
}
