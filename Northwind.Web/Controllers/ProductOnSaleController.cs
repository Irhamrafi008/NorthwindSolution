using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetails;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
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
        [Authorize(Roles ="Administrator")]
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
        public async Task<IActionResult>AddToCart(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                // create order dan order detail baru, jika costumer belum melakukan order
                var productMdl = productDto;
                var orderMdl = new OrdersForCreateDto
                {
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(3),
                    CustomerId = "IAM"
                    
                };
                var orders = await _serviceManager.OrdersServices.FilterCustId(orderMdl.CustomerId, false);
                if(orders == null)
                {
                    var createOrder = _serviceManager.OrdersServices.createOrderId(orderMdl);
                    var orderDetail = new OrderDetailsForCreateDto
                    {

                        ProductId = productMdl.ProductId,
                        OrderId = createOrder.OrderId,
                        UnitPrice = (decimal)productMdl.UnitPrice,
                        Quantity = Convert.ToInt16(productMdl.QuantityPerUnit),
                        Discount = 0
                    };
                    _serviceManager.OrdersDetailsServices.Insert(orderDetail);
                    return RedirectToAction("Checkout", new { id = createOrder.OrderId });
                }

                //orderId, productId, shippedDateNull
                else
                {
                    OrderDetailsDto orderDetails = new OrderDetailsDto();
                    orderDetails = await _serviceManager.OrdersDetailsServices.GetOrderDetails(orders.OrderId,productMdl.ProductId, false);
                    if(orders.ShippedDate == null)
                    {
                        var orderDetail = new OrderDetailsForCreateDto
                        {
                            ProductId = productMdl.ProductId,
                            OrderId = orders.OrderId,
                            Quantity = Convert.ToInt16(productMdl.QuantityPerUnit),
                            UnitPrice = (decimal)productMdl.UnitPrice * Convert.ToInt16(productMdl.QuantityPerUnit),
                            Discount = 0
                        };
                        if(orderDetails != null)
                        {
                            //melakukan edit jika product yang di order sama
                            if(orderDetails.ProductId == productMdl.ProductId)
                            {
                                var newQuantity = Convert.ToInt16(productMdl.QuantityPerUnit);
                                orderDetails.OrderId = orderDetail.OrderId;
                                orderDetails.ProductId = orderDetail.ProductId;
                                orderDetails.Quantity += newQuantity;
                                orderDetails.UnitPrice += (decimal)productMdl.UnitPrice * newQuantity;
                                _serviceManager.OrdersDetailsServices.Edit(orderDetails);
                                return RedirectToAction("CartItem", "OrderDetails", new {});
                            }
                        }
                        else
                        {
                            _serviceManager.OrdersDetailsServices.Insert(orderDetail);
                            return RedirectToAction("Index");
                        }
                        _serviceManager.OrdersDetailsServices.Insert(orderDetail);
                        return RedirectToAction("index");
                    }
                    else
                    {
                        var createOrder = _serviceManager.OrdersServices.createOrderId(orderMdl);
                        var orderDetail = new OrderDetailsForCreateDto
                        {
                            ProductId = productMdl.ProductId,
                            OrderId = createOrder.OrderId,
                            UnitPrice = (decimal)productMdl.UnitPrice,
                            Quantity = Convert.ToInt16(productMdl.QuantityPerUnit),
                            Discount = 0
                        };
                        _serviceManager.OrdersDetailsServices.Insert(orderDetail);
                        return RedirectToAction("Checkout", new { id = createOrder.OrderId });
                    }
                }
                
            }
            return View(productDto);
        }

        public async Task<IActionResult> BuyNow (ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var productMdl = productDto;
                var orderMdl = new OrdersForCreateDto
                {
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(3),
                    CustomerId = "IAM"
                };
                var order = _serviceManager.OrdersServices.createOrderId(orderMdl);
                var orderDetail = new OrderDetailsForCreateDto
                {
                    ProductId = productMdl.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = (decimal)productMdl.UnitPrice,
                    Quantity = Convert.ToInt16(productMdl.QuantityPerUnit),
                    Discount = 0
                };
                _serviceManager.OrdersDetailsServices.Insert(orderDetail);
                return RedirectToAction("Checkout", new { id = orderDetail.OrderId });
            }
            return View();
        }


        public async Task<ActionResult> Checkout (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productMDl = await _serviceManager.OrdersServices.GetOrderById((int)id, false);
            if (productMDl == null)
            {
                return NotFound();
            }
            return View(productMDl);
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
