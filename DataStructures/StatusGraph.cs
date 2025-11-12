using System.Collections.Generic;
using System.Linq;

namespace Prog7312_MunicipalityApp_ST10299399.DataStructures
{
    // Graph representing valid status transitions for issues
    public class StatusGraph
    {
        // Adjacency list to represent the graph
        private Dictionary<string, List<string>> _adjacencyList;
        // Constructor to initialize the graph with valid transitions
        public StatusGraph()
        {
            // Define valid status transitions
            _adjacencyList = new Dictionary<string, List<string>>
            {
                { "Reported", new List<string> { "InProgress", "Closed" } },
                { "InProgress", new List<string> { "Resolved", "Closed" } },
                { "Resolved", new List<string> { "Closed" } },
                { "Closed", new List<string> { }},
            };
        }

        // Method to check if a transition is valid
        public bool IsValidTransition(string currentStatus, string newStatus)
        {
            if (!_adjacencyList.ContainsKey(currentStatus))
            {
                 return false;
            }

            var possibleTransitions = _adjacencyList[currentStatus];
            return possibleTransitions.Any(p => p.Equals(newStatus, StringComparison.OrdinalIgnoreCase));
        }
    }
}
