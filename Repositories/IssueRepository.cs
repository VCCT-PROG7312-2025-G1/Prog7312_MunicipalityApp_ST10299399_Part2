using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.DataStructures;

namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        // Static tree to hold issues
        private static readonly ServiceRequestTree _issuesTree = new ServiceRequestTree();
        private static int _nextId = 1; // Static counter for unique issue IDs

        // Add a new issue to the collection
        public void AddIssue(Issue issue)
        {
            issue.Id = System.Threading.Interlocked.Increment(ref _nextId);
            _issuesTree.Insert(issue);
        }

        // Retrieve an issue by its ID
        public Issue GetIssueById(int id)
        {
            return _issuesTree.Search(id);
        }

        // Retrieve all issues in the collection
        public IEnumerable<Issue> GetAllIssues()
        {
            return _issuesTree.GetAllIssues();
        }

        // Update an existing issue
        public void UpdateIssue(Issue issue)
        {
        }
    }
}
