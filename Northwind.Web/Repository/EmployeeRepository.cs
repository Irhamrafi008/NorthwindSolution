using Northwind.Web.Models;
using System;
using System.Collections.Generic;

namespace Northwind.Web.Repository
{
    public class EmployeeRepository : IEmployee
    {
        public List<Employee> GetAll()
        {
            var listOfEmployee = new List<Employee>() {
                new Employee { Id=100,Name="irham rafi",BirthDate=new DateTime(2000,03,07)},
                new Employee { Id = 101, Name = "Dios", BirthDate = new DateTime(1999, 10, 04) },
                new Employee { Id = 102, Name = "Mahreza", BirthDate = new DateTime(2001, 04, 01) },
                new Employee { Id = 103, Name = "Sultan", BirthDate = new DateTime(2005, 02, 04) }
            };
            return listOfEmployee;
        }
    }
}
