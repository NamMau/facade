using AngleSharp.Dom;
using Microsoft.Graph;
using OfficeDevPnP.Core.Diagnostics.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Tạo đối tượng Facade
            TransactionFacade facade = new TransactionFacade();

            // Thêm sản phẩm
            Product product1 = new Product
            {
                ProductID = 1,
                Name = "Product A",
                Description = "Description of Product A",
                Price = 10.99,
                Stock = 100,
                CreatedAt = DateTime.Now,
                ShopID = 1
            };
            facade.AddProduct(product1);

            // Hiển thị sản phẩm
            facade.ShowProducts();

            // Tạo và lưu đơn hàng
            facade.CreateOrder(customerId: 2, totalAmount: 50.00);

            // Tạo và lưu giỏ hàng
            List<CartProduct> items = new List<CartProduct>
            {
                new CartProduct { ProductID = 1, Quantity = 2 },
                new CartProduct { ProductID = 2, Quantity = 1 }
            };
            facade.CreateShoppingCart(customerId: 123, items: items);
        }
    }
}