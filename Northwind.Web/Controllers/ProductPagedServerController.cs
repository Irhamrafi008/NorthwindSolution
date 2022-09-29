using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
using Northwind.Persistence;
using NorthwindServices;
using NorthwindServicesAbstraction;
using X.PagedList;
using ContentDispositionHeaderValue = System.Net.Http.Headers.ContentDispositionHeaderValue;

namespace Northwind.Web.Controllers
{
    public class ProductPagedServerController : Controller
    {
        private readonly NorthwindContext _context;
        private readonly IServiceManager _servisManager;
        private readonly IUtilityServices _utilityServices;



        public ProductPagedServerController(NorthwindContext context, IServiceManager servisManager, IUtilityServices utilityServices = null)
        {
            _context = context;
            _servisManager = servisManager;
            _utilityServices = utilityServices;
        }

        // GET: ProductPagedServer
        public async Task<IActionResult> Index(string searchString, 
            string currentFilter, int? page,int? fetchSize)
        {
            /*var northwindContext = _context.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(await northwindContext.ToListAsync());*/
           
            var pageIndex = page ?? 1;
            var pageSize = fetchSize ?? 5;
            

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            // setelah kata ViewBag bisa dilanjutkan dengan penamaan bebas, seperti ViewBag.CurrentFilter maupun 
            // ViewBag.PageSearching
            ViewBag.PageSearching = searchString;

            var productDto = await _servisManager.ProductServices
                .GetProductPaged(pageIndex, pageSize, false);
            var totalRows = productDto.Count();
            

            if (!String.IsNullOrEmpty(searchString))
            {
                productDto = productDto.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()));
            }
            var productDtoPaging =
                new StaticPagedList<ProductDto>(productDto, pageIndex, pageSize -(pageSize-1), totalRows);
            ViewBag.Pagelist = new SelectList(new List<int> { 8, 15, 20 });

            return View(productDtoPaging);
        }

        public async Task<IActionResult> CreateProductPhoto(ProductPhotoGroup productPhotoGroupDto)
        {
            if (ModelState.IsValid)
            {
                var productPhotoGrup = productPhotoGroupDto;
                var photo1 = _utilityServices.UploadSingleFile(productPhotoGrup.Photo1);
                var photo2 = _utilityServices.UploadSingleFile(productPhotoGrup.Photo2);
                var photo3 = _utilityServices.UploadSingleFile(productPhotoGrup.Photo3);
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View("Create");
        }



            /*var latesProductId = _servisManager.ProductServices.CreateProductId(productPhotoDto.ProductForCreateDto);
            if (ModelState.IsValid)
            {
                try
                {
                    var file = productPhotoDto.AllPhoto;
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if(file.Count > 0)
                    {
                        foreach (var item in file)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                item.CopyTo(stream);
                            }
                            var convertSize = (Int16)item.Length;
                            var productPhoto = new ProductPhotoCreateDto
                            {
                                PhotoFilename = fileName,
                                PhotoFileType = item.ContentType,
                                PhotoFileSize = (byte)convertSize,
                                PhotoProductId = latesProductId.ProductId
                            };
                            _servisManager.ProductPhotoServices.insert(productPhoto);
                        }
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();
        }*/

        /*public async Task<IActionResult>CreateProductPhotoos(ProductPhotoGroup productPhotoGroup)
        {
           
            var latestProductId = _servisManager.ProductServices.CreateProductId(productPhotoGroup.ProductForCreateDto);
            if (ModelState.IsValid)
            {
                try
                {
                    var file = productPhotoGroup.AllPhoto;
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if(file.Count > 0)
                    {
                        foreach (var item in file)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                item.CopyTo(stream);
                            }

                            var convertSize = (Int16)item.Length;
                            var productPhoto = new ProductPhotoCreateDto
                            {
                                PhotoFilename = fileName,
                                PhotoFileType = item.ContentType,
                                PhotoFileSize = (byte)convertSize,
                                PhotoProductId = latestProductId.ProductId
                            };
                            _servisManager.ProductPhotoServices.insert(productPhoto);
                            
                        }
                        return RedirectToAction(nameof(Index));
                        
                    }
                    
                }
                catch(Exception ex)
                {
                    throw;
                }
                
            }
            return View();

        }*/



        // GET: ProductPagedServer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductPagedServer/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: ProductPagedServer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductPagedServer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // POST: ProductPagedServer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductPagedServer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductPagedServer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
