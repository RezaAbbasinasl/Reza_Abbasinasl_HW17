using Microsoft.AspNetCore.Mvc;
using Reza_Abbasinasl_HW17.DAL;
using Reza_Abbasinasl_HW17.Models;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace Reza_Abbasinasl_HW17.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        StaffDAL staffDAL = new StaffDAL();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Staff(string StoreId, string StoreName)
        {
            var staff = staffDAL.GetAll();
            if (!string.IsNullOrEmpty(StoreId))
            {
                staff = staff.Where(x => x.Store_Id.ToString().Contains(StoreId)).ToList();
            }
            if (!string.IsNullOrEmpty(StoreName))
            {
                staff = staff.Where(x => x.Store_Name.Contains(StoreName)).ToList();
            }
            return View(staff);
        }
        OrderDAL orderDAL = new OrderDAL();
        public IActionResult SearchRegisteredOrders(int OrderId)
        {
            var order = orderDAL.RegisteredOrders(OrderId);
            return View(order);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
