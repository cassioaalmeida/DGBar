using System;
using System.Collections.Generic;
using System.Text;

namespace DGBar.Domain.DTO
{
    public class InvoiceDTO
    {
        public int OrderId { get; set; }
        public List<InvoiceProductDTO> Products { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}
