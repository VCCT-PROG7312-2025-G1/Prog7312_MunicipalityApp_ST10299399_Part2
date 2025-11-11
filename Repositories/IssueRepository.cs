using Prog7312_MunicipalityApp_ST10299399.DataStructures;
using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private static readonly ServiceRequestTree _issueTree = new ServiceRequestTree();
        private static int _nextId = 0;
        private static bool _isSeeded = false; // Flag to ensure seeding happens only once

        // Add a new issue to the collection
        public void AddIssue(Issue issue)
        {
            issue.Id = System.Threading.Interlocked.Increment(ref _nextId);
            _issueTree.Insert(issue);
        }

        // Retrieve an issue by its ID
        public Issue GetIssueById(int id)
        {
            return _issueTree.Search(id);
        }

        // Retrieve all issues in the collection
        public IEnumerable<Issue> GetAllIssues()
        {
            return _issueTree.GetAllIssues();
        }

        // Update an existing issue
        public void UpdateIssue(Issue issue)
        {
        }

        
        public IssueRepository()
        {
            // Seed initial data only once
            if (!_isSeeded)
            {
                SeededIssues();
                _isSeeded = true;
            }
        }

        // Seed the repository with initial data
        private void SeededIssues()
        {
            var initialIssues = new List<Issue>
            {
                new Issue
                {
                    Id = 1,
                    issueType = "Pothole",
                    issueDescription = "Large pothole on Main St.",
                    issueDate = DateTime.Now.AddDays(-5),
                    issueStatus = IssueStatus.Reported.ToString(),

                },
                new Issue
                {
                    Id = 2,
                    issueType = "Streetlight",
                    issueDescription = "Streetlight not working on 5th Ave.",
                    issueDate = DateTime.Now.AddDays(-3),
                    issueStatus = IssueStatus.InProgress.ToString(),
                },
                new Issue
                {
                    Id = 3,
                    issueType = "Graffiti",
                    issueDescription = "Graffiti on wall near park.",
                    issueDate = DateTime.Now.AddDays(-1),
                    issueStatus = IssueStatus.Resolved.ToString(),
                }
            };
            foreach (var issue in initialIssues)
            {
                _issueTree.Insert(issue);
            }
        }

    }
}
