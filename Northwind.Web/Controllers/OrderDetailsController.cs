    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetails;
using Northwind.Domain.Models;
using Northwind.Persistence;
using NorthwindServicesAbstraction;

namespace Northwind.Web.Controllers
{
    public class OrderDetailsController : Controller
    {
        private IServiceManager _context;

        public OrderDetailsController(IServiceManager context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var orderDetails = _context.OrdersDetailsServices.GetAllOrderDetails(false);
            return View(orderDetails);
        }

        public async Task<IActionResult> CartItem()
        {
            var customerID = "IAM";
            var itemCart = await _context.OrdersDetailsServices.GetAllChartItem(customerID, false);
            return View(itemCart);
        }

        public async Task<IActionResult> Checkout (List<OrderDetailsDto> orderDetailsDtos)
        {
            OrderDetailsDto orderDetail = new OrderDetailsDto();
            foreach (var item in orderDetailsDtos)
            {
                orderDetail.ProductId = item.ProductId;
                orderDetail.OrderId = item.OrderId;
                orderDetail.Quantity = item.Quantity;
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetail.Discount = 0;
                _context.OrdersDetailsServices.Edit(orderDetail);
            }

            OrdersDto ordersDto = new OrdersDto
            {
                OrderId = orderDetail.OrderId,
                CustomerId = "IAM",
                ShippedDate = DateTime.Now
            };
            _context.OrdersServices.Edit(ordersDto);

            return RedirectToAction("Index","ProductOnSale",new {area=""});
            

        }


        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrdersDetailsServices.GetOrderDetailsById((int)id, false);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public async Task<IActionResult> Create()
        {
            /* ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
             ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
             return View();*/
            var product = await _context.ProductServices.GetAllProduct(false);
            ViewData["ProductId"] = new SelectList(product, "ProductId", "ProductName");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,UnitPrice,Quantity,Discount")] OrderDetailsForCreateDto orderDetail)
        {
            if (ModelState.IsValid)
            {
                /* _context.Add(orderDetail);
                 await _context.SaveChangesAsync();*/
                _context.OrdersDetailsServices.Insert(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            var product = await _context.ProductServices.GetAllProduct(false);
            ViewData["ProductId"] = new SelectList(product, "ProductId", "ProductName", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrdersDetailsServices.GetOrderDetailsById((int)id, true);
            if (orderDetail == null)
            {
                return NotFound();
            }
            var product = await _context.ProductServices.GetAllProduct(false);
            ViewData["ProductId"] = new SelectList(product, "ProductId", "ProductName", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductId,UnitPrice,Quantity,Discount")] OrderDetailsDto orderDetail)
        {
            if (id != orderDetail.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.OrdersDetailsServices.Edit(orderDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
 
                    throw;
                    
                }
               
            }
            var product = await _context.ProductServices.GetAllProduct(false);
            ViewData["ProductId"] = new SelectList(product, "ProductId", "ProductName", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrdersDetailsServices.GetOrderDetailsById((int)id, false);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetails = await _context.OrdersDetailsServices.GetOrderDetailsById((int)id, false);
            _context.OrdersDetailsServices.Remove(orderDetails);
            return RedirectToAction(nameof(Index));
        }


    }
}
