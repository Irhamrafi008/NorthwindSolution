using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IEmployeesRepository
    {

        Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
        Task<Employee> GetEmployeeByID(int id, bool trackChanges);
        void insert(Employee employee);
        void edit(Employee employee);
        void remove(Employee employee);
    }
}
