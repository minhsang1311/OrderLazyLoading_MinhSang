using Microsoft.AspNetCore.Mvc;
using EFCoreSQLiteDemo.Data;
using EFCoreSQLiteDemo.Models.ViewModels;
using System.Linq;

namespace EFCoreSQLiteDemo.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders
                .Select(o => new OrderViewModel
                {
                    OrderId = o.Id,
                    UserName = o.User.Name,
                    OrderDate = o.OrderDate.ToShortDateString(),
                    Details = o.OrderDetails.Select(od => new OrderDetailViewModel
                    {
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice
                    }).ToList()
                }).ToList();

            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.Id,
                    UserName = o.User.Name,
                    OrderDate = o.OrderDate.ToShortDateString(),
                    Details = o.OrderDetails.Select(od => new OrderDetailViewModel
                    {
                        ProductName = od.Product.Name,
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice
                    }).ToList()
                }).FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}