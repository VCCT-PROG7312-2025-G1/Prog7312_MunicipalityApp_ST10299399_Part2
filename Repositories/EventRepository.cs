using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Data;

// Repository for managing Event data
// Implements IEventRepository interface
// Uses Entity Framework Core for data access
namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    // Implements methods for accessing and manipulating event data
    // Interacts with the AppDbContext to perform database operations
    // Provides methods to get all events and add new events
    public class EventRepository : IEventRepository
    {
        // Database context for accessing event data
        private readonly AppDbContext _context;

        // Constructor to initialize the repository with the database context
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        // Retrieves all events from the database, ordered by event date
        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events.OrderBy(e => e.EventDate).ToList();
        }

        // Adds a new event to the database and saves changes
        public void AddEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
        }
    }
}
