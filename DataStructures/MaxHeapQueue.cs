using System.Collections.Generic;
using Prog7312_MunicipalityApp_ST10299399.Models;
using Prog7312_MunicipalityApp_ST10299399.Helpers;

namespace Prog7312_MunicipalityApp_ST10299399.DataStructures
{
    public class MaxHeapQueue
    {
        private List<Issue> _heap;

        public int Count => _heap.Count;
        public MaxHeapQueue()
        {
            _heap = new List<Issue>();
        }
       

        public void Insert(Issue issue)
        {
            _heap.Add(issue);
            HeapifyUp(_heap.Count - 1);
        }

        public Issue ExtractMax()
        {
            if (_heap.Count == 0)
            {
                return null;
            }
            if (_heap.Count == 1)
            {
                var max = _heap[0];
                _heap.RemoveAt(0);
                return max;
            }

            var maxIssue = _heap[0];
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            HeapifyDown(0);

            return maxIssue;
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && GetPriority(_heap[index]) > GetPriority(_heap[parentIndex]))
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int maxIndex = index;

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

        private void Swap(int i, int j)
        {
            var temp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = temp;
        }

        private int GetPriority(Issue issue)
        {
            return IssuePriority.GetPriorityValue(issue.issueType);
        }

        public List<Issue> GetIssues()
        {
            return new List<Issue>(_heap);
        }


    }
}
