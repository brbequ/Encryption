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

class Solution
{

    // Complete the encryption function below.
    static string encryption(string s)
    {
        // Strip spaces from the input string
        string compressed = String.Concat(s.Where(c => !Char.IsWhiteSpace(c)));

        // Calculate the rows and columns of a grid
        int rows = (int)Math.Floor(Math.Sqrt(compressed.Length));
        int cols = (int)Math.Ceiling(Math.Sqrt(compressed.Length));
        if (rows * cols < compressed.Length)
        {
            if (rows < cols)
                rows++;
            else
                cols++;
        }

        // Use a StringBuilder to assemble the 'encrypted' string
        StringBuilder encrypted = new StringBuilder();

        for (int col = 0; col < cols; col++)
        {
            // Walk down the rows of the column appending the character
            for (int row = 0; row < rows; row++)
            {
                if (col + row * cols < compressed.Length)
                    encrypted.Append(compressed[col + row * cols]);
            }

            // Add a space after every column except the last one
            if (col < cols - 1)
                encrypted.Append(' ');
        }

        return encrypted.ToString();
    }

    static void Main(string[] args)
    {
        string s = "if man was meant to stay on the ground god would have given us roots";
        s = "chillout";
        string result = encryption(s);

        Console.WriteLine(result);
    }
}
