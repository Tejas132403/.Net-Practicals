using Microsoft.AspNetCore.Mvc;
using StudentCampusPortal.DAL;
using StudentCampusPortal.Models;
using System.Diagnostics;
using System.Linq;

namespace StudentCampusPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceRequestDAL _dal;

        public HomeController(ServiceRequestDAL dal)
        {
            _dal = dal;
        }

        public IActionResult Index()
        {
            var allRequests = _dal.GetAll();

            ViewBag.TotalCount = allRequests.Count;
            ViewBag.PendingCount = allRequests.Count(r => r.Status.Equals("Pending", System.StringComparison.OrdinalIgnoreCase));
            ViewBag.InProgressCount = allRequests.Count(r => r.Status.Equals("In Progress", System.StringComparison.OrdinalIgnoreCase));
            ViewBag.CompletedCount = allRequests.Count(r => r.Status.Equals("Completed", System.StringComparison.OrdinalIgnoreCase));

            // Return recent 5 requests to show on home dashboard
            var recentRequests = allRequests.Take(5).ToList();
            return View(recentRequests);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
