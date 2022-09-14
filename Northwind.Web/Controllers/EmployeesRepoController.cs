using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Persistence;

namespace Northwind.Web.Controllers
{
    public class EmployeesRepoController : Controller
    {
        //private readonly NorthwindContext _context;
        private readonly IRepositoryManager _context;
        public EmployeesRepoController(IRepositoryManager context)
        {
            _context = context;
        }

        // GET: EmployeesRepo
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeesRepository.GetAllEmployees(false));
        }

        // GET: EmployeesRepo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var employee = await _context.Employees
                .Include(e => e.ReportsToNavigation)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);*/
            var employee = await _context.EmployeesRepository.GetEmployeeByID((int)id, false);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeesRepo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeesRepo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));*/
                _context.EmployeesRepository.insert(employee);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: EmployeesRepo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var employee = await _context.Employees.FindAsync(id);*/
            var employee = await _context.EmployeesRepository.GetEmployeeByID((int)id, true);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: EmployeesRepo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(employee);
                    await _context.SaveChangesAsync();*/
                    _context.EmployeesRepository.edit(employee);
                    await _context.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: EmployeesRepo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var employee = await _context.Employees
                .Include(e => e.ReportsToNavigation)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);*/
            var employee = await _context.EmployeesRepository.GetEmployeeByID((int)id, false);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: EmployeesRepo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();*/
            var employee = await _context.EmployeesRepository.GetEmployeeByID((int)id, false);
            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

/*        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }*/
    }
}
