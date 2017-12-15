using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestWordCode
{
   internal class LongestWords
	{
		private static void Main(string[] args)
		{
			
			IEnumerable<String> lines = File.ReadLines("c:\\gitclone\\Project_file.txt");
			string[] listOfWords = File.ReadAllLines("c:\\gitclone\\Project_file.txt");
			
			string longest = FindLongestWords(listOfWords);
			List<string> listOfWords2 = new List<string>();            
			for (int i = 0; i < listOfWords.Length; i++)
			{
				if (listOfWords[i] == longest)
					continue;
				else
					listOfWords2.Add(listOfWords[i].ToString());            
			}
			
			string longest2 = FindLongestWords(listOfWords2.ToArray());

			List<string> CountofWords = new List<string>();
			CountofWords = FindCountOfWordsIntheListLongestWords(listOfWords.ToArray());

			Console.WriteLine("First LongestWord:" + longest);
			Console.WriteLine("Second LongestWord:" + longest2);
			if(CountofWords.Any())
				Console.WriteLine("Total Count of Words Can be Constructed of other words:" + CountofWords.Count);
			Console.ReadLine();

		}

		public static string FindLongestWords(string[] listOfWords)
		{
			if (listOfWords == null) throw new ArgumentException("listOfWords");
			var sortedWords = listOfWords.OrderByDescending(word => word.Length).ToList();
			var dict = new HashSet<String>(sortedWords);
			foreach (var word in sortedWords)
			{
				if (isMadeOfWords(word, dict))
				{
					return word;
				}
			}
			return null;
		}

		public static List<string> FindCountOfWordsIntheListLongestWords(string[] listOfWords)
		{
			List<string> strWordsList = new List<string>();
			if (listOfWords == null) throw new ArgumentException("listOfWords");
			var sortedWords = listOfWords.OrderByDescending(word => word.Length).ToList();
			var dict = new HashSet<String>(sortedWords);
			foreach (var word in sortedWords)
			{
				if (isMadeOfWords(word, dict))
				{
					strWordsList.Add(word);
				}
			}
			return strWordsList;
		}

		private static bool isMadeOfWords(string word, HashSet<string> dict)
		{
			if (String.IsNullOrEmpty(word)) return false;
			if (word.Length == 1)
			{
				if (dict.Contains(word)) return true;
				else return false;
			}
			foreach (var pair in generatePairs(word))
			{
				if (dict.Contains(pair.Item1))
				{
					if (dict.Contains(pair.Item2))
					{
						return true;
					}
					else
					{
						return isMadeOfWords(pair.Item2, dict);
					}
				}
			}
			return false;


		}

		private static List<Tuple<string, string>> generatePairs(string word)
		{
			var output = new List<Tuple<string, string>>();
			for (int i = 1; i < word.Length; i++)
			{
				output.Add(Tuple.Create(word.Substring(0, i), word.Substring(i)));
			}
			return output;
		}
	}
}
