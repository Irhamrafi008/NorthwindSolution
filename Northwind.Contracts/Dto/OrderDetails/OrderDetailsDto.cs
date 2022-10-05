﻿using Northwind.Contracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.OrderDetails
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

       /* public virtual Order Order { get; set; }*/
        public virtual ProductDto ProductDto { get; set; }
    }
}