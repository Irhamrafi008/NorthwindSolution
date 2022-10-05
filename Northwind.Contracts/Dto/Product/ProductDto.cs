using Northwind.Contracts.Dto.OrderDetails;
using Northwind.Contracts.Dto.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Product
{
    public enum SortOrder { ascending = 0, descending = 1 }
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set; }
        [Display(Name = "Unit Stock")]
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual CategoryDto CategoryDto { get; set; }

        public virtual ProductPhotoGroup ProductPhotoGrup { get; set; }
        public virtual ICollection<ProductPhotoDto> ProductPhotos { get; set; }
        public virtual ICollection<OrderDetailsDto> OrderDetailsDto { get; set; }
        public virtual SuppliersDto SuppliersDto { get; set; }
    }
}
