using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Models;
using System.Collections.Generic;
using System.Linq;
using Prog7312_MunicipalityApp_ST10299399.Services;
using Prog7312_MunicipalityApp_ST10299399.ViewModels;

namespace Prog7312_MunicipalityApp_ST10299399.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IIssueService _issueService;

        public EventController(IEventService eventService, IIssueService issueService)
        {
            _eventService = eventService;
            _issueService = issueService;
        }

        public IActionResult Index(string query, string category)
        {
            var sortedEvents = _eventService.GetEventsByDate();

            IEnumerable<Event> searchResults;
            if (!string.IsNullOrEmpty(query) || !string.IsNullOrEmpty(category))
            {
                searchResults = _eventService.SearchEvents(query, category);
            }
            else
            {
                searchResults = sortedEvents.SelectMany(kv => kv.Value).ToList();
            }

            var allCategories = _eventService.SearchEvents(null, null)
                .Select(e => e.Category)
                .ToHashSet();

            var announcements = searchResults
                .Where(e => e.Category == "Announcement")
                .OrderByDescending(e => e.PostedDate)
                .Take(3)
                .ToList();

            Queue<Event> quickAnnouncements = new Queue<Event>(announcements);

            var viewModel = new EventViewModel
            {
                EventsByDate = sortedEvents,
                SearchResults = searchResults,
                AllCategories = allCategories
                SelectedCategory = category,
                SearchQuery = query,
                QuickAnnouncements = quickAnnouncements
            };
            return View(viewModel);

        }

        public IActionResult Recommendations()
        {
            var allIssues = _issueService.GetAllIssues();

            var issueTypesCounts = new Dictionary<string, int>();

            foreach (var issue in allIssues)
            {
                string issueType = issue.issueType;
                if (issueTypesCounts.ContainsKey(issue.issueType))
                {
                    issueTypesCounts[issue.issueType]++;
                }
                else
                {
                    issueTypesCounts[issue.issueType] = 1;
                }
            }

            string mostCommonIssueType = null;
            if (issueTypesCounts.Any())
            {
                mostCommonIssueType = issueTypesCounts.OrderByDescending(kv => kv.Value).First().Key;
            }

            string recommendedCategory = mostCommonIssueType switch
            {
                "Pothole" => "Announcement",
                "Waste Management" => "Environmental",
                "Loadshedding" => "Announcement",
                _ => "Sport"
            };

            var recommendedEvents = _eventService.SearchEvents(null, recommendedCategory)
                .OrderBy(e => e.EventDate)
                .Take(3)
                .ToList();

            ViewBag.Reason = $"Based on your reported issues, we recommend events in the '{recommendedCategory}' category.";

            return View(recommendedEvents);
        }
    }
}
