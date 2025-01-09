using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.DAO
{
    public class Product
    {
        private String productID;
        private String productName;
        private int quantity;
        private decimal purchasePrice;


        public Product(string productID, string productName, int quantity, decimal purchasePrice)
        {
            this.productID = productID;
            this.productName = productName;
            this.quantity = quantity;
            this.purchasePrice = purchasePrice;
        }

        public string ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
    }
}
