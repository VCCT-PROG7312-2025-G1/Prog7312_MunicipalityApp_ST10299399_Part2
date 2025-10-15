using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.ViewModels
{
    // ViewModel for passing event data to the view
    // Contains event listings, search results, categories, and announcements
    // Used in the EventController to render the event page
    public class EventViewModel
    {
        // Sorted dictionary of events grouped by date
        // Key: Date, Value: List of Events on that date
        public SortedDictionary<DateTime, List<Event>> EventsByDate { get; set; }
        // Search results based on user queries
        // If no search is performed, contains all events
        public IEnumerable<Event> SearchResults { get; set; }
        // All unique event categories
        // Used for filtering events by category
        public HashSet<string> AllCategories { get; set; }
        // Currently selected category for filtering
        // If null or empty, no category filter is applied
        public string SelectedCategory { get; set; }
        // Queue of quick announcements to display
        // Using a queue to manage the order of announcements
        public Queue<Event> QuickAnnouncements { get; set; }

    }
}
