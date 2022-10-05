using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetails;
using Northwind.Contracts.Dto.Product;
using NorthwindServicesAbstraction;
using System;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
{
    public class ProductOnSaleController : Controller
    {
        private IServiceManager _serviceManager;

        public ProductOnSaleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        // GET: ProductOnSaleConttroller
        public async Task<ActionResult> Index()
        {
            var productOnSales = await _serviceManager.ProductServices.GetProductOnSales(false);
            return View(productOnSales);
        }

        // GET: ProductOnSaleConttroller/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var salesOnProduct = await _serviceManager.ProductServices.GetAllProductOnSalesById((int)id, false);
            if (salesOnProduct == null)
            {
                return NotFound();
            }
            return View(salesOnProduct);
        }

        [HttpPost]
        public async Task<IActionResult>CreateOrder(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var productMdl = productDto;
                var orderMdl = new OrdersForCreateDto
                {
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(3)
                };
                var orderDetail = new OrderDetailsForCreateDto
                {

                    ProductId = productMdl.ProductId,
                    UnitPrice = (decimal)productMdl.UnitPrice,
                    Quantity = 0,
                    Discount = 0
                };
                _serviceManager.ProductServices.CreateOrder(orderMdl, orderDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }



        public async Task<ActionResult> CartItem(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var salesOnProduct = await _serviceManager.ProductServices.GetAllProductOnSalesById((int)id, false);
            if (salesOnProduct == null)
            {
                return NotFound();
            }
            return View(salesOnProduct);
        }
        // GET: ProductOnSaleConttroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductOnSaleConttroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductOnSaleConttroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductOnSaleConttroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductOnSaleConttroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductOnSaleConttroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
