using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts.Dto.Category;
using Northwind.Domain.Base;

namespace Northwind.Web.Controllers
{
    public class ClientSideController : Controller
    {
        public IRepositoryManager _repositoryManager;

        public ClientSideController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public JsonResult GetTotalProductByCategory()
        {
            var result = _repositoryManager.ProductRepository.GetTotalProductBycategory();
            return Json(result);
        }

        public IActionResult IndexJS()
        {
            return View();
        }

        public IActionResult IndexJQuery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostCategory([FromBody] CategoryForCreateDto categoryForCreateDto)
        {
            var categoryDto = categoryForCreateDto;
            var result = new JsonResult(null)
            {
                Value = "succeed"
            };
            return Ok(result);

        }

        public IActionResult IndexChart()
        {
            return View();
        }


    }
}
