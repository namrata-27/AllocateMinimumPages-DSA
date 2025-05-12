using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AllocateMinimumPages
{
    public class PageAllocation
    {
        // Function to check if books can be allocated to
       // all k students without exceeding 'pageLimit'
        private bool check(int[] arr, int k, int pageLimit)
        {

            // Starting from the first student
            int cnt = 1;
            int pageSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {

                // If adding the current book exceeds the page 
                // limit, assign the book to the next student
                if (pageSum + arr[i] > pageLimit)
                {
                    cnt++;
                    pageSum = arr[i];
                }
                else
                {
                    pageSum += arr[i];
                }
            }

            // If books can assigned to less than k students then
            // it can be assigned to exactly k students as well
            return (cnt <= k);
        }

        public int findPages(int[] arr, int k)
        {

            // If number of students are more than total books
            // then allocation is not possible
            if (k > arr.Length)
                return -1;

            // Minimum and maximum possible page limits
            int minPageLimit = arr.Max();
            int maxPageLimit = arr.Sum();

            // Iterating over all possible page limits
            for (int i = minPageLimit; i <= maxPageLimit; i++)
            {

                // Return the first page limit with we can
                // allocate books to all k students
                if (check(arr, k, i))
                    return i;
            }

            return -1;
        }


    }
}
