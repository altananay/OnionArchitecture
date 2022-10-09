using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? productName { get; set; }
        public double unitPrice { get; set; }
        public int unitsInStock { get; set; }
    }
}