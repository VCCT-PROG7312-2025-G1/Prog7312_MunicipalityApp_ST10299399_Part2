using Prog7312_MunicipalityApp_ST10299399.DataStructures;
using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private static readonly ServiceRequestTree _issueTree = new ServiceRequestTree();
        private static int _nextId = 6;
        private static bool _isSeeded = false; // Flag to ensure seeding happens only once

        // Add a new issue to the collection
        public void AddIssue(Issue issue)
        {
            issue.Id = _nextId++;
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
        // These seeded issues was done with the use of github copilot just to make easy
        private void SeededIssues()
        {
            var initialIssues = new List<Issue>
            {
                new Issue
                {
                    Id = 1,
                    issueType = "Pothole",
                    issueLocation = "Main St.",
                    issueDescription = "Large pothole on Main St.",
                    issueDate = DateTime.Now.AddDays(-5),
                    issueStatus = IssueStatus.Reported.ToString(),

                },
                new Issue
                {
                    Id = 2,
                    issueType = "Streetlight",
                    issueLocation = "5th Ave.",
                    issueDescription = "Streetlight not working on 5th Ave.",
                    issueDate = DateTime.Now.AddDays(-3),
                    issueStatus = IssueStatus.InProgress.ToString(),
                },
                new Issue
                {
                    Id = 3,
                    issueType = "Garbage",
                    issueLocation = "Central Park",
                    issueDescription = "Overflowing garbage bin in park.",
                    issueDate = DateTime.Now.AddDays(-1),
                    issueStatus = IssueStatus.Resolved.ToString(),
                },
                new Issue
                {
                    Id = 4,
                    issueType = "Water Leak",
                    issueLocation = "Elm St.",
                    issueDescription = "Water leak on Elm St.",
                    issueDate = DateTime.Now.AddDays(-2),
                    issueStatus = IssueStatus.Reported.ToString(),
                },
                new Issue
                {
                    Id = 5,
                    issueType = "Loadshedding",
                    issueLocation = "Downtown",
                    issueDescription = "Frequent loadshedding in area.",
                    issueDate = DateTime.Now.AddDays(-4),
                    issueStatus = IssueStatus.InProgress.ToString(),
                }
            };
            foreach (var issue in initialIssues)
            {
                _issueTree.Insert(issue);
            }
        }

    }
}