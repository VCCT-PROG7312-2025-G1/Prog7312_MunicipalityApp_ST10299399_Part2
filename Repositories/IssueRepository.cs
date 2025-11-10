using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.DataStructures;
using Prog7312_MunicipalityApp_ST10299399.Data;

namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private static readonly ServiceRequestTree _issueTree = new ServiceRequestTree();
        private static int _nextId = 1;

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
    }
}
