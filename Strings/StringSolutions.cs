using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace StringExercises
{
    internal class StringSolutions
    {
        // Reversing array of chars without allocating new memory to a new array
        public void ReverseString(char[] inputString)
        {
            int a_pointer = 0;
            int b_pointer = inputString.Length - 1;

            while(a_pointer <= b_pointer)
            {
                char tempA = inputString[a_pointer];
                inputString[a_pointer] = inputString[b_pointer];
                inputString[b_pointer] = tempA;

                a_pointer++;
                b_pointer--;
            }

            Console.WriteLine(inputString);
        }


        public void FirstUniqueCharacter(string input)
        {
            char[] inputChars = input.ToCharArray();
            Dictionary<char, int> occurences = new Dictionary<char, int>();

            for (int i = 0; i < inputChars.Length-1; i++)
            {
                if (!occurences.ContainsKey(inputChars[i])){
                    occurences.Add(inputChars[i], 1);
                }
                else
                {
                    occurences[inputChars[i]]++;
                }
            }

            foreach(var i in occurences)
            {
                Console.Write("[{0}:{1}], ",i.Key,i.Value);
            }

            foreach(var i in occurences)
            {
                if(i.Value == 1)
                {
                    Console.WriteLine("\nFirst unique character: {0}",i.Key);
                    break;
                }
            }

        }


        public void ValidAnagram(string s, string t)
        {
            char[] s_chars = s.ToCharArray();
            char[] t_chars = t.ToCharArray();

            if(s_chars.Length != t_chars.Length)
            {
                Console.WriteLine("The two strings don't have the same length");
                return;
            }

            Array.Sort(s_chars);
            Array.Sort(t_chars);

            bool isAnagram = true;

            for (int i = 0; i < s_chars.Length - 1; i++)
            {
                if (s_chars[i] != t_chars[i])
                {
                    isAnagram = false;
                }
            }

            Console.WriteLine("The two strings are anagrams: " + isAnagram);

        }


        public void IsPalindrome(string input)
        {
            string preparedInput = input.ToLower();
            preparedInput = preparedInput.Replace(",", "");
            preparedInput = preparedInput.Replace(":", "");
            preparedInput = preparedInput.Replace(" ", "");

            int pointer_a = 0;
            int pointer_b = preparedInput.Length - 1;

            bool isPalindrome = true;

            while (pointer_a <= pointer_b)
            {
                if (preparedInput[pointer_a] != preparedInput[pointer_b])
                {
                    isPalindrome = false;
                }

                pointer_a++;
                pointer_b--;
            }

            Console.WriteLine("The sentence is a palindrome: " + isPalindrome);
        }



        public void LongestCommonPrefix(string[] input)
        {
            string prefix = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                // While-loop'en bliver ved med at køre indtil prefix er baberet ned til en substring som findes i input[i] som herved vil returnerer 0
                while (input[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }
            }
            Console.WriteLine(prefix);

        }

    }
}
