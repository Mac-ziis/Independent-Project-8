using Microsoft.AspNetCore.Mvc;
using VendorOrder.Models;
using System;
using System.Collections.Generic;

namespace VendorOrder.Controllers
{
  public class OrdersController : Controller
  {

    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders/createorder")] 
    public ActionResult CreateOrder(int vendorId, string orderName, string orderDescription, decimal orderPrice, DateTime orderDate)
    {
      Vendor vendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderName, orderDescription, orderPrice, orderDate);
      vendor.AddOrder(newOrder);

      return RedirectToAction("Show", "Vendors", new { vendorId = vendor.Id });
    }
  }
}
