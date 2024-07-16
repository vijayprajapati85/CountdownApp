using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countdown
{
    class CountdownGM
    {
        private const int NumOfTurns = 4;
        private List<string> dictionary = new List<string>();
        private int totalPoints = 0;
        public CountdownGM()
        {
            LoadSpellCheckDictionary("words.txt");
        }
        public void InitGame()
        {
            Console.WriteLine("Start Count down Game");

            for (int currRound = 1; currRound <= NumOfTurns; currRound++)
            {
                Console.WriteLine($"\nRound {currRound}:");
                Console.WriteLine($"\nChoose Consonants/Vowels with (,)");
                string consVowel = Console.ReadLine().ToUpper();
                string longestString = findLongestString(consVowel);
                Console.WriteLine(longestString);

                int roundPoints = CountScorePerRound(longestString);
                totalPoints += roundPoints;
                Console.WriteLine($"Your score {roundPoints} points of this round.");
            }

            Console.WriteLine($"\nRound Complete, Total points are : {totalPoints}");
        }
        private void LoadSpellCheckDictionary(string filename)
        {
            try
            {
                using (StreamReader StreamReaderObject = new StreamReader(filename))
                {
                    string line;
                    while ((line = StreamReaderObject.ReadLine()) != null)
                    {
                        dictionary.Add(line.Trim().ToUpper());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading dictionary: {ex.Message}");
            }
        }
        private int CountScorePerRound(string wordUsed)
        {
             return wordUsed.Length;
        }
        private String findLongestString(String str)
        {
            String result = "";
            int length = 0;

            foreach (string word in dictionary)
            {

                 if (length < word.Length &&
                    isSubSequence(word, str))
                {
                    result = word;
                    length = word.Length;
                }
            }
            return result;
        }
        private bool isSubSequence(String str1,String str2)
        {
            int m = str1.Length, n = str2.Length;

            int j = 0; 

            for (int i = 0; i < n && j < m; i++)
            {
                if (str1[j] == str2[i])
                {
                    j++;
                }
            }

            return (j == m);
        }
    }
}