using System.Collections.Generic;
using System.Linq;

namespace Prog7312_MunicipalityApp_ST10299399.DataStructures
{
    public class StatusGraph
    {
        private Dictionary<string, List<string>> _adjacencyList;
        public StatusGraph()
        {
            _adjacencyList = new Dictionary<string, List<string>>
            {
                { "Reported", new List<string> { "InProgress", "Closed" } },
                { "InProgress", new List<string> { "Resolved", "Closed" } },
                { "Resolved", new List<string> { "Closed" } },
                { "Closed", new List<string> { }},
            };
        }

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
