using System.Collections.Generic;
using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Helpers;

namespace Prog7312_MunicipalityApp_ST10299399.DataStructures
{
    // Max-Heap based priority queue for managing issues
    /// Issues with higher priority values are served first
    public class MaxHeapQueue
    {
        private List<Issue> _heap;

        // Get the number of issues in the queue
        public int Count => _heap.Count;
        public MaxHeapQueue()
        {
            _heap = new List<Issue>();
        }

        // Insert a new issue into the priority queue
        public void Insert(Issue issue)
        {
            _heap.Add(issue);
            HeapifyUp(_heap.Count - 1);
        }

        // Extract the issue with the highest priority
        public Issue ExtractMax()
        {
            // Handle empty heap
            if (_heap.Count == 0)
            {
                return null;
            }
            // Handle single element heap
            if (_heap.Count == 1)
            {
                var max = _heap[0];
                _heap.RemoveAt(0);
                return max;
            }
            // General case
            // Swap the root with the last element and remove the last element
            var maxIssue = _heap[0];
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            HeapifyDown(0);

            return maxIssue;
        }

        // Restore heap property by moving the element at index up
        private void HeapifyUp(int index)
        {
            // Calculate parent index
            int parentIndex = (index - 1) / 2;

            // Continue swapping with parent while the current node has higher priority
            // than the parent
            while (index > 0 && GetPriority(_heap[index]) > GetPriority(_heap[parentIndex]))
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        // Restore heap property by moving the element at index down
        private void HeapifyDown(int index)
        {
            // Initialize maxIndex to the current index
            int maxIndex = index;

            // Continue until the heap property is restored
            // Check left and right children
            // Swap with the child having higher priority if needed
            // Repeat until no swaps are needed
            while (true)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                if (leftChildIndex < _heap.Count && GetPriority(_heap[leftChildIndex]) > GetPriority(_heap[maxIndex]))
                {
                    maxIndex = leftChildIndex;
                }
                if (rightChildIndex < _heap.Count && GetPriority(_heap[rightChildIndex]) > GetPriority(_heap[maxIndex]))
                {
                    maxIndex = rightChildIndex;
                }
                if (maxIndex != index)
                {
                    Swap(index, maxIndex);
                    index = maxIndex;
                }
                else
                {
                    break;
                }
            }
        }

        // Swap two elements in the heap
        private void Swap(int i, int j)
        {
            // Swap elements at indices i and j
            var temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

        // Get the priority value of an issue based on its type
        // Higher returned value means higher priority
        private int GetPriority(Issue issue)
        {
            return IssuePriority.GetPriorityValue(issue.issueType);
        }

        // Get all issues in the heap as a list
        public List<Issue> GetIssues()
        {
            return new List<Issue>(_heap);
        }


    }
}
