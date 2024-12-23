using System.Collections.Generic;

namespace EFCoreSQLiteDemo.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string OrderDate { get; set; }
        public List<OrderDetailViewModel> Details { get; set; }
    }

    public class OrderDetailViewModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}