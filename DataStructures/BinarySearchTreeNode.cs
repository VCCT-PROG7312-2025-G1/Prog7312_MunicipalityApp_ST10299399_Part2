using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.DataStructures
{
    // Node class for the binary search tree
    public class BinarySearchTreeNode
    {
        // Data stored in the node
        public Issue Data { get; set; }
        // Left and right child nodes
        public BinarySearchTreeNode Left { get; set; }
        public BinarySearchTreeNode Right { get; set; }
        public BinarySearchTreeNode(Issue issue)
        {
            Data = issue;
            Left = null;
            Right = null;
        }

    }
}
