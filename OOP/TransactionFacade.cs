using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
	public class TransactionFacade
	{
		private readonly ITransactionStorage _transactionStorage;
		private readonly ProductManager _productManager;

		public TransactionFacade()
		{
			_transactionStorage = new TransactionStorage();
			_productManager = ProductManager.Instance;
		}

		// Thêm sản phẩm mới vào hệ thống
		public void AddProduct(Product product)
		{
			_productManager.AddProduct(product);
		}

		// Tạo và lưu đơn hàng
		public void CreateOrder(int customerId, double totalAmount)
		{
			Order newOrder = new Order
			{
				ID = 1,
				CustomerID = customerId,
				TotalAmount = totalAmount,
				OrderStatus = "Completed",
				PaymentStatus = "Unpaid",
				PaymentMethodID = 1,
				OverDueDate = DateTime.Now.AddDays(7),
				PaidAt = DateTime.Now,
				DeliveryStatus = "Shipped",
				ShippingProviderID = 1,
			};
			_transactionStorage.SaveTransaction(newOrder);
		}

		// Tạo và lưu giỏ hàng
		public void CreateShoppingCart(int customerId, List<CartProduct> items)
		{
			ShoppingCart cart = new ShoppingCart
			{
				ID = 2,
				CustomerID = customerId,
				TotalAmount = items.Sum(item => item.Quantity * 10), // Giả sử giá mỗi sản phẩm là 10
				CreatedAt = DateTime.Now,
				Items = items
			};
			_transactionStorage.SaveTransaction(cart);
		}

		// Hiển thị các sản phẩm hiện tại
		public void ShowProducts()
		{
			var products = _productManager.GetProducts();
			foreach (var product in products)
			{
				Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: {product.Price}");
			}
		}
	}
}