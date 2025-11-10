using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Services;
using System.Linq;

// Controller for managing issues
namespace Prog7312_MunicipalityApp_ST10299399.Controllers
{
    // Handles issue-related actions such as viewing and updating issue statuses
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        // Displays the admin dashboard with prioritized issues
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            var prioritizedIssues = _issueService.GetPriorityIssues(10);
            return View(prioritizedIssues);
        }

        // Updates the status of a specific issue
        [HttpPost]
        public IActionResult UpdateStatus(int id, string newStatus)
        {
            // Only allow access if the user is an admin
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            // Populate statuses for dropdown
            ViewBag.Statuses = Enum.GetNames(typeof(IssueStatus)).ToList();

            // Update issue status
            if (_issueService.UpdateIssueStatus(id, newStatus))
            {
                TempData["SuccessMessage"] = "Issue status updated successfully.";
            }
            // Handle failure case
            else
            {
                TempData["ErrorMessage"] = "Failed to update issue status.";
            }
            return RedirectToAction("Dashboard");
        }
    }
}
