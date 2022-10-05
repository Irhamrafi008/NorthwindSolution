using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Models;
using Northwind.Persistence;
using NorthwindServicesAbstraction;

namespace Northwind.Web.Controllers
{
    public class OrdersServicesController : Controller
    {
        private readonly NorthwindContext _context;
        private readonly IServiceManager _serviceContext;

        public OrdersServicesController(NorthwindContext context, IServiceManager serviceContext = null)
        {
            _context = context;
            _serviceContext = serviceContext;
        }

        // GET: OrdersServices
        public async Task<IActionResult> Index()
        {
            /* var northwindContext = _context.Orders.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.ShipViaNavigation);
             return View(await northwindContext.ToListAsync());*/
            var ordersDto = await _serviceContext.OrdersServices.GetAllOrders(false);
            return View(ordersDto);
        }

        // GET: OrdersServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == id);*/
            var order = await _serviceContext.OrdersServices.GetAllOrders(false);
            
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: OrdersServices/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "CompanyName");
            return View();
        }

        // POST: OrdersServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,EmployeeId,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                /* var orderMDL = await _serviceContext.OrdersServices.GetAllOrders(false);
                 _serviceContext.OrdersServices.Insert(orderMDL);*/
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", order.EmployeeId);
            ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "CompanyName", order.ShipVia);
            return View(order);
        }

        // GET: OrdersServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var order = await _context.Orders.FindAsync(id);*/
            var order = await _serviceContext.OrdersServices.GetAllOrderById((int)id, true);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", order.EmployeeId);
            ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "CompanyName", order.ShipVia);
            return View(order);
        }

        // POST: OrdersServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,EmployeeId,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(order);
                    await _context.SaveChangesAsync();*/
                    _serviceContext.OrdersServices.GetAllOrderById((int)id, true);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!OrderExists(order.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", order.EmployeeId);
            ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "CompanyName", order.ShipVia);
            return View(order);
        }

        // GET: OrdersServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == id);*/
            var order = await _serviceContext.OrdersServices.GetAllOrderById((int)id, false);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: OrdersServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();*/
            var orders = await _serviceContext.OrdersServices.GetAllOrderById((int)id, false);
            _serviceContext.OrdersServices.Remove(orders);
            return RedirectToAction(nameof(Index));
        }


    }
}
