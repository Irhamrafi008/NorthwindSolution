using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto
{
    public class ProductDtoss
    {
        public long? ProductID { get; set; }
        public string Name { get; set; }

        [Required]
        [StringLength(50,ErrorMessage ="Description Cannot be longer than 50 Character.")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Please select Image")]
        public IFormFile Foto { get; set; }

        [Column(TypeName = "decimal(15,2")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        public int CategoryID { get; set; }


    }
}
