using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrder.Models;
using System.Collections.Generic;
using System;

namespace VendorOrder.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      // Arrange
      string vendorName = "Test Vendor";
      string vendorDescription = "Vendor Description";

      // Act
      Vendor newVendor = new Vendor(vendorName, vendorDescription);

      // Assert
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      // Arrange
      string vendorName = "Test Vendor";
      string vendorDescription = "Vendor Description";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);

      // Act
      string result = newVendor.Name;

      // Assert
      Assert.AreEqual(vendorName, result);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      // Arrange
      string vendorName = "Test Vendor";
      string vendorDescription = "Vendor Description";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);

      // Act
      int result = newVendor.Id;

      // Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      // Arrange
      string vendorName1 = "Vendor 1";
      string vendorDescription1 = "Vendor 1 Description";
      string vendorName2 = "Vendor 2";
      string vendorDescription2 = "Vendor 2 Description";
      Vendor newVendor1 = new Vendor(vendorName1, vendorDescription1);
      Vendor newVendor2 = new Vendor(vendorName2, vendorDescription2);
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      // Act
      List<Vendor> result = Vendor.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      // Arrange
      string vendorName1 = "Vendor 1";
      string vendorDescription1 = "Vendor 1 Description";
      string vendorName2 = "Vendor 2";
      string vendorDescription2 = "Vendor 2 Description";
      Vendor newVendor1 = new Vendor(vendorName1, vendorDescription1);
      Vendor newVendor2 = new Vendor(vendorName2, vendorDescription2);

      // Act
      Vendor result = Vendor.Find(2);

      // Assert
      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      // Arrange
      string vendorName = "Test Vendor";
      string vendorDescription = "Vendor Description";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      string orderName = "Order 1";
      string orderDescription = "Order 1 Description";
      decimal orderPrice = 10.99m;
      DateTime orderDate = DateTime.Now;
      Order newOrder = new Order(orderName, orderDescription, orderPrice, orderDate);
      List<Order> newList = new List<Order> { newOrder };

      // Act
      newVendor.AddOrder(newOrder);
      List<Order> result = newVendor.Orders;

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}


