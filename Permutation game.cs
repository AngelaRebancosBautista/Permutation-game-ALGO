using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'permutationGame' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static string permutationGame(List<int> arr)
    {
         var memo = new Dictionary<string, bool>();
        return IsWinning(arr, memo) ? "Alice" : "Bob";
    }

    private static bool IsWinning(List<int> arr, Dictionary<string, bool> memo)
    {
        string key = string.Join(",", arr);
        if (memo.ContainsKey(key))
            return memo[key];

        if (IsSorted(arr))
        {
            memo[key] = false;
            return false;
        }

        for (int i = 0; i < arr.Count; i++)
        {
            var next = new List<int>(arr);
            next.RemoveAt(i);
            
            if (!IsWinning(next, memo))
            {
                memo[key] = true;
                return true;
            }
        }

        memo[key] = false;
        return false;
    }

    private static bool IsSorted(List<int> arr)
    {
        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] < arr[i - 1])
                return false;
        }
        return true;
    }
}
    

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            string result = Result.permutationGame(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
