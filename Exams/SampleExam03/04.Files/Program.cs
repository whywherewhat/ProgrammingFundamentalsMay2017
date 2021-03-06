﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split(new char[] {';', '\\'}, StringSplitOptions.RemoveEmptyEntries);
                
                string root = tokens[0];
                string fileName = tokens[tokens.Length - 2];
                long fileSize = long.Parse(tokens[tokens.Length - 1]);

                if (! data.ContainsKey(root))
                {
                    data.Add(root, new Dictionary<string, long>());
                }

                if (! data[root].ContainsKey(fileName))
                {
                    data[root].Add(fileName, fileSize);
                }
                else
                {
                    data[root][fileName] = fileSize;
                }

            }

            string searchFile = Console.ReadLine();

            string[] searchTokens = searchFile.Split(new string[] {" in "}, StringSplitOptions.RemoveEmptyEntries);
            string extension = "." + searchTokens[0];
            string searchDir = searchTokens[1];
            bool isAccessed = false;

            if (! data.ContainsKey(searchDir))
            {
                Console.WriteLine($"No");
                return;
            }

            foreach (KeyValuePair<string, long> rootFilePair in data[searchDir].OrderByDescending(size => size.Value).ThenBy(name => name.Key))
            {
                string file = rootFilePair.Key;
                if (file.Contains($"{extension}"))
                {
                    Console.WriteLine($"{file} - {rootFilePair.Value} KB");
                    isAccessed = true;
                }
            }
            if (! isAccessed)
            {
                Console.WriteLine($"No");
            }

        }
    }
}
