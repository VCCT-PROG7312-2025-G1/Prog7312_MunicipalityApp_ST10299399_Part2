using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.DataStructures
{
    public class BinarySearchTreeNode
    {
        public Issue Data { get; set; }
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
