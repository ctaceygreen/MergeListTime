using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public static void Main(string[] args)
    {
        solution(new int[] { 1000, 350, 300, 250, 100, 100 });
    }
    public static int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        //Best solution is to always merge the two smallest available lists, and continue

        if(A.Length == 0)
        {
            return 0;
        }

        if(A.Length == 1)
        {
            return A[0];
        }

        // Sort the array

        Array.Sort(A);

        int runningTotal = A[0] + A[1];
        //Compare the two smallest in A with the running total. Take the two smallest elements of this and sum them

        int smallestArrayIndex = 2;
        while(smallestArrayIndex < A.Length)
        {
            int smallestInArray = A[smallestArrayIndex];
            if (smallestArrayIndex + 1 < A.Length)
            {
                int nextSmallestInArray = A[smallestArrayIndex + 1];

                if (runningTotal <= nextSmallestInArray)
                {
                    //Then we're fine, the smallest two are these two
                    runningTotal += runningTotal + smallestInArray;
                    smallestArrayIndex++;
                }
                else
                {
                    //Running total is larger than two smallest, so we need to add these two smallest first, then add these to the running total
                    int smallestSum = smallestInArray + nextSmallestInArray;
                    runningTotal += runningTotal + smallestSum;
                    smallestArrayIndex += 2; // Shift twice as we have covered both of these
                }
            }
            else
            {
                runningTotal += runningTotal + smallestInArray;
                smallestArrayIndex++;
            }
        }
        return runningTotal;
    }
}