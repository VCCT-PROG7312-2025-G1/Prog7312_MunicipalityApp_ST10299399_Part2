using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Repositories;
using Prog7312_MunicipalityApp_ST10299399.DataStructures;
using Prog7312_MunicipalityApp_ST10299399.Helpers;

namespace Prog7312_MunicipalityApp_ST10299399.Services
{
    // Service implementation for issue management
    public class IssueService : IIssueService
    {
        // Dependency injection for repository
        private readonly IIssueRepository _issueRepository;
        private static readonly StatusGraph _statusGraph = new StatusGraph();
        // Constructor to initialize repository
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        // Reports a new issue
        public void ReportNewIssue(Issue issue)
        {
            // Business logic can be added here before adding the issue
            issue.issueDate = DateTime.Now;
            issue.issueStatus = IssueStatus.Reported.ToString();

            _issueRepository.AddIssue(issue);
        }
        // Retrieves issue details by ID
        public Issue GetIssueDetails(int id)
        {
            return _issueRepository.GetIssueById(id);
        }
        // Retrieves all issues
        public IEnumerable<Issue> GetAllIssues()
        {
            return _issueRepository.GetAllIssues();
        }

        // Updates the status of an existing issue
        public void UpdateIssueStatus(int id, string newStatus)
        {
            var issueToUpdate = _issueRepository.GetIssueById(id);
            if (issueToUpdate != null)
            {
                issueToUpdate.issueStatus = newStatus;
                _issueRepository.UpdateIssue(issueToUpdate);
            }
        }


        // Retrieves top priority issues based on a max-heap
        // Priority is determined by custom logic in GetPriority method
        public IEnumerable<Issue> GetPriorityIssues(int count)
        {
            // Retrieve all issues from the repository
            var allIssues = _issueRepository.GetAllIssues();
            var heap = new MaxHeapQueue();
            // Insert all issues into the max-heap
            foreach (var issue in allIssues)
            {
                heap.Insert(issue);
            }
            // Extract the top 'count' priority issues
            var priorityIssues = new List<Issue>();
            // Ensure we do not exceed the number of available issues
            for (int i = 0; i < count && heap.Count > 0; i++)
            {
                priorityIssues.Add(heap.ExtractMax());
            }
            return priorityIssues;
        }


        public bool UpdateIssueStatus(int id, string newStatus)
        {
            var issueToUpdate = _issueRepository.GetIssueById(id);
            if (issueToUpdate == null)
            {
                return false; 
            }

            string currentStatus = issueToUpdate.issueStatus;
            if (!_statusGraph.IsValidTransition(currentStatus, newStatus))
            {
                return false;
            }

            issueToUpdate.issueStatus = newStatus;
            _issueRepository.UpdateIssue(issueToUpdate);
            return true;
        }
    }
}
