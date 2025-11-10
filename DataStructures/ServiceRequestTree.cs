using System.Collections.Generic;
using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.DataStructures
{
    public class ServiceRequestTree
    {
        // Root node of the binary search tree
        private BinarySearchTreeNode root;

        // Constructor
        public ServiceRequestTree()
        {
            root = null;
        }

        // Insert a new issue into the tree
        public void Insert(Issue issue)
        {
            if (root == null)
            {
                root = new BinarySearchTreeNode(issue);
                return;
            }
            InsertRec(root, issue);
        }

        // Recursive helper method for insertion
        private BinarySearchTreeNode InsertRec(BinarySearchTreeNode current, Issue issue)
        {
            // Compare issues based on their IDs
            // Insert to the left if the new issue ID is smaller
            if (issue.Id < current.Data.Id)
            {
                if (current.Left == null)
                {
                    current.Left = new BinarySearchTreeNode(issue);
                }
                else
                {
                    InsertRec(current.Left, issue);
                }
            }
            // Insert to the right if the new issue ID is larger
            else if (issue.Id > current.Data.Id)
            {
                if (current.Right == null)
                {
                    current.Right = new BinarySearchTreeNode(issue);
                }
                else
                {
                    InsertRec(current.Right, issue);
                }
            }
            // Ignore if the issue ID is already present
            return current;
        }
        public Issue Search(int id)
        {
            return SearchRec(root, id);
        }
        private Issue SearchRec(BinarySearchTreeNode current, int id)
        {
            // Base case: reached a null node
            if (current == null)
            {
                return null;
            }
            // Found the issue with the matching ID
            if (id == current.Data.Id)
            {
                return current.Data;
            }
            // Search in the left subtree if the ID is smaller
            if (id < current.Data.Id)
            {
                return SearchRec(current.Left, id);
            }
            // Search in the right subtree if the ID is larger
            else
            {
                return SearchRec(current.Right, id);
            }
        }

        // Get all issues in sorted order
        // In-order traversal of the tree
        public IEnumerable<Issue> GetAllIssues()
        {
            var list = new List<Issue>();
            InOrderTraversal(root, list);
            return list;
        }
        // Recursive helper method for in-order traversal
        public void InOrderTraversal(BinarySearchTreeNode node, List<Issue> list)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, list);
                list.Add(node.Data);
                InOrderTraversal(node.Right, list);
            }
        }
    }
}
