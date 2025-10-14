using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Models;
using System.Collections.Generic;
using System.Linq;
using Prog7312_MunicipalityApp_ST10299399.Services;
using Prog7312_MunicipalityApp_ST10299399.ViewModels;

// Controller for managing events
namespace Prog7312_MunicipalityApp_ST10299399.Controllers
{
    // Handles event-related actions such as listing, searching, and recommending events
    public class EventController : Controller
    {
        // Services for event and issue management
        private readonly IEventService _eventService;
        private readonly IIssueService _issueService;

        // Constructor injecting event and issue services
        public EventController(IEventService eventService, IIssueService issueService)
        {
            _eventService = eventService;
            _issueService = issueService;
        }
        // Displays the main event page with optional search and category filtering
        public IActionResult Index(string query, string category)
        {
            // Retrieve events sorted by date
            var sortedEvents = _eventService.GetEventsByDate();

            // Perform search if query or category is provided
            IEnumerable<Event> searchResults;
            if (!string.IsNullOrEmpty(query) || !string.IsNullOrEmpty(category))
            // Search events based on query and category
            {
                searchResults = _eventService.SearchEvents(query, category);
            }
            else
            {
                searchResults = sortedEvents.SelectMany(kv => kv.Value).ToList();
            }
            // Get all unique event categories
            var allCategories = _eventService.SearchEvents(null, null)
                .Select(e => e.Category)
                .ToHashSet();
            // Get the latest 3 announcements
            var announcements = searchResults
                .Where(e => e.Category == "Announcement")
                .OrderByDescending(e => e.PostedDate)
                .Take(3)
                .ToList();
            // Use a queue to manage quick announcements
            Queue<Event> quickAnnouncements = new Queue<Event>(announcements);

            // Prepare the view model with all necessary data
            // Return the view with the populated view model
            var viewModel = new EventViewModel
            {
                EventsByDate = sortedEvents,
                SearchResults = searchResults,
                AllCategories = allCategories,
                SelectedCategory = category,
                SearchQuery = query,
                QuickAnnouncements = quickAnnouncements
            };
            return View(viewModel);

        }

        // Provides event recommendations based on reported issues
        public IActionResult Recommendations()
        {
            // Analyze reported issues to determine the most common issue type
            var allIssues = _issueService.GetAllIssues();
            // Count occurrences of each issue type
            var issueTypesCounts = new Dictionary<string, int>();
            // Tally issue types
            foreach (var issue in allIssues)
            {
                string issueType = issue.issueType;
                // Increment count for the issue type
                if (issueTypesCounts.ContainsKey(issue.issueType))
                {
                    issueTypesCounts[issue.issueType]++;
                }
                else
                {
                    issueTypesCounts[issue.issueType] = 1;
                }
            }
            // Determine the most frequently reported issue type
            string mostCommonIssueType = null;
            // Get the issue type with the highest count
            if (issueTypesCounts.Any())
            {
                // Select the issue type with the maximum count
                mostCommonIssueType = issueTypesCounts.OrderByDescending(kv => kv.Value).First().Key;
            }

            // Map issue types to event categories for recommendations
            string recommendedCategory = mostCommonIssueType switch
            {
                "Pothole" => "Announcement",
                "Waste Management" => "Environmental",
                "Loadshedding" => "Announcement",
                _ => "Sport"
            };

            // Fetch events in the recommended category
            var recommendedEvents = _eventService.SearchEvents(null, recommendedCategory)
                .OrderBy(e => e.EventDate)
                .Take(3)
                .ToList();

            // Pass recommendation reason to the view
            ViewBag.Reason = $"Based on your reported issues, we recommend events in the '{recommendedCategory}' category.";

            return View(recommendedEvents);
        }


        private bool IsUserAdmin()
        {
            var role = HttpContext.Session.GetString("Role");
            return role == "Admin";
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            if (!IsUserAdmin())
            {
                TempData["ErrorMessage"] = "You must be an admin to create events.";
                return RedirectToAction("Login", "Login");
            }
            return View(new Event());
        }

        [HttpPost]
        public IActionResult CreateEvent(Event newEvent)
        {
            if (!IsUserAdmin())
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid)
            {
                _eventService.PostNewEvent(newEvent);
                TempData["SuccessMessage"] = "Event created successfully!";
                return RedirectToAction("Index");
            }
            return View(newEvent);
        }
    }
}
