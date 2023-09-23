using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorOrder.Models;
using System;

namespace VendorOrder.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
        {
            Order.ClearAll();
        }

        [TestMethod]
        public void OrderConstructor_CreatesInstanceOfOrder_Order()
        {
            // Arrange
            Order newOrder = new Order("Test Order", "Test Description", 10.99m, DateTime.Now);

            // Act & Assert
            Assert.AreEqual(typeof(Order), newOrder.GetType());
        }

        [TestMethod]
        public void Getters_ReturnsOrderProperties()
        {
            // Arrange
            string name = "Test Order";
            string description = "Test Description";
            decimal price = 10.99m;
            DateTime date = DateTime.Now;
            Order newOrder = new Order(name, description, price, date);

            // Act & Assert
            Assert.AreEqual(name, newOrder.Name);
            Assert.AreEqual(description, newOrder.Description);
            Assert.AreEqual(price, newOrder.Price);
            Assert.AreEqual(date, newOrder.OrderDate);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyList_OrderList()
        {
            // Arrange & Act
            var result = Order.GetAll();

            // Assert
            CollectionAssert.AreEqual(new System.Collections.Generic.List<Order>(), result);
        }

        [TestMethod]
        public void GetAll_ReturnsOrders_OrderList()
        {
            // Arrange
            Order newOrder1 = new Order("Order 1", "Description 1", 10.99m, DateTime.Now);
            Order newOrder2 = new Order("Order 2", "Description 2", 20.49m, DateTime.Now);

            // Act
            var result = Order.GetAll();

            // Assert
            CollectionAssert.AreEqual(new System.Collections.Generic.List<Order> { newOrder1, newOrder2 }, result);
        }
  }
}