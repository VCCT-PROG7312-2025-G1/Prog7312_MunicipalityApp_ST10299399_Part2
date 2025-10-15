using Prog7312_MunicipalityApp_ST10299399.Models;
using System.Collections.Generic;

// Service interface for managing events
// Defines methods for retrieving, searching, and posting events
namespace Prog7312_MunicipalityApp_ST10299399.Services
{
    // Interface for Event service
    // Provides methods for event-related operations
    public interface IEventService
    {
        // Retrieves events grouped by date
        // Returns a sorted dictionary with dates as keys and lists of events as values
        SortedDictionary<DateTime, List<Event>> GetEventsByDate();

        // Searches events based on a query and category
        // Returns a list of events that match the search criteria
        IEnumerable<Event> SearchEvents(string query, string category);

        // Posts a new event
        void PostNewEvent(Event newEvent);
    }
}
