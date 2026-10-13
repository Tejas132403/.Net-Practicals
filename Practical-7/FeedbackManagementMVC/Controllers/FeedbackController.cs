using System.Web.Mvc;
using FeedbackManagementMVC.Models;

namespace FeedbackManagementMVC.Controllers
{
    public class FeedbackController : Controller
    {
        // Display Feedback Form
        public ActionResult Index()
        {
            return View();
        }

        // Submit Feedback
        [HttpPost]
        public ActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                return View("Submitted", feedback);
            }

            return View(feedback);
        }
    }
}