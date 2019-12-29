using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new List<Sale>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
//SalesContext – your DbContext
// Product:
// ProductId
// Name(up to 50 characters, unicode)
// Quantity(real number)
// Price
// Sales

// Customer:
// CustomerId
// Name(up to 100 characters, unicode)
// Email(up to 80 characters, not unicode)
// CreditCardNumber(string)
// Sales

// Store:
// StoreId
// Name(up to 80 characters, unicode)
// Sales

// Sale:
// SaleId
// Date
// Product
// Customer
// Store