using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Repositories;

// Service for managing events
// Implements IEventService interface
// Uses an event repository for data access
namespace Prog7312_MunicipalityApp_ST10299399.Services
{
    // Implements methods for event-related operations
    public class EventService : IEventService
    {
        // Event repository for data access
        private readonly IEventRepository _eventRepository;
        // Constructor to initialize the service with the event repository
        public EventService(IEventRepository eventRepository)
        {
            // Initialize the event repository
            _eventRepository = eventRepository;
        }

        // Retrieves events grouped by date
        public SortedDictionary<DateTime, List<Event>> GetEventsByDate()
        {
            // Get all events from the repository
            var allEvents = _eventRepository.GetAllEvents().ToList();
            // Group events by date using a sorted dictionary
            var sortedEvents = new SortedDictionary<DateTime, List<Event>>();

            // Iterate through all events and group them by their event date
            foreach (var eventItem in allEvents)
            {
                DateTime dateKey = eventItem.EventDate.Date;
                if (!sortedEvents.ContainsKey(dateKey))
                {
                    sortedEvents[dateKey] = new List<Event>();
                }
                sortedEvents[dateKey].Add(eventItem);
            }
            return sortedEvents;
        }

        // Searches events based on a query and category
        public IEnumerable<Event> SearchEvents(string query, string category)
        {
            var allEvents = _eventRepository.GetAllEvents();
            var results = allEvents.AsQueryable();

            // Filter events based on the search query and category
            if (!string.IsNullOrEmpty(query))
            {
                results = results.Where(e => e.Title.Contains(query) || e.Description.Contains(query));
            }
            // If a specific category is selected, filter events by that category
            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                results = results.Where(e => e.Category == category);
            }
            return results.OrderBy(e => e.EventDate).ToList();
        }
        // Posts a new event
        public void PostNewEvent(Event newEvent)
        {
            newEvent.PostedDate = DateTime.Now;
            _eventRepository.AddEvent(newEvent);
        }
    }
}
