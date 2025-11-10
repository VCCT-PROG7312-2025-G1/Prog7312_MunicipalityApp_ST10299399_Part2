using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.DataStructures;
using Prog7312_MunicipalityApp_ST10299399.Data;

namespace Prog7312_MunicipalityApp_ST10299399.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly AppDbContext _context;

        public IssueRepository(AppDbContext context)
        {
            _context = context;
        }

        // Add a new issue to the collection
        public void AddIssue(Issue issue)
        {
            _context.Issues.Add(issue);
            _context.SaveChanges();
        }

        // Retrieve an issue by its ID
        public Issue GetIssueById(int id)
        {
            return _context.Issues.Find(id);
        }

        // Retrieve all issues in the collection
        public IEnumerable<Issue> GetAllIssues()
        {
            return _context.Issues.OrderByDescending(i => i.issueDate).ToList();
        }

        // Update an existing issue
        public void UpdateIssue(Issue issue)
        {
            _context.Issues.Update(issue);
            _context.SaveChanges();
        }

        public IEnumerable<Issue> GetIssuesByStatus(string status)
        {
            return _context.Issues.Where(i => i.issueStatus == status).ToList();
        }
    }
}
