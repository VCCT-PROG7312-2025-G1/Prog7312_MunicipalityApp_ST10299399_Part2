using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    // Interface for Event repository
    // Defines methods for accessing and manipulating event data
    public interface IEventRepository
    {
        // Retrieves all events from the data source
        IEnumerable<Event> GetAllEvents();
        // Adds a new event to the data source
        void AddEvent(Event newEvent);

    }
}
