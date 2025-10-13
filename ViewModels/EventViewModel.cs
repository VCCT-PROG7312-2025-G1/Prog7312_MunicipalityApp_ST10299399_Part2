using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.ViewModels
{
    public class EventViewModel
    {
        public SortedDictionary<DateTime, List<Event>> EventsByDate { get; set; }
        public IEnumerable<Event> SearchResults { get; set; }
        public HashSet<string> AllCategories { get; set; }
        public string SelectedCategory { get; set; }
        public string SearchQuery { get; set; }
        public Queue<Event> QuickAnnouncements { get; set; }

    }
}
