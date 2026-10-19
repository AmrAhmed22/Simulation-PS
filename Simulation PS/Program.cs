
using System.Runtime.CompilerServices;
using System.Text;

namespace Simulation_PS
{
    internal class Program
    {
        // Assignment 1
        public int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> found = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                found[nums[i]] = i;
            }

            int l = 0, r = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int x = target - nums[i];

                if (found.ContainsKey(x) && found[x] != i)
                {
                    l = i;
                    r = found[x];
                    break;
                }
            }

            return new int[] { l, r };
        }




        // Assignment 2

        public void ReverseString(char[] s)
        {
            int first = 0;
            int last = s.Length - 1;

            char temp;
            while (first < last)
            {
                temp = s[first];
                s[first] = s[last];
                s[last] = temp;

                first++;
                last--;
            }

        }



        // Assignment 3
        public int SingleNumber(int[] nums)
        {
            int num = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                num ^= nums[i];
            }

            return num;

        }


        // Assignment 4


        public bool IsAnagram(string s, string t)
        {

            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> count = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (count.ContainsKey(c))
                    count[c]++;
                else
                    count[c] = 1;

            }

            foreach (var c in t)
            {
                if (!count.ContainsKey(c))
                    return false;

                count[c]--;

                if (count[c] < 0)
                    return false;

            }

            return true;

        }


        public int GCD(int L, int R)
        {

            int temp;

            while (R != 0)
            {
                temp = L;
                L = R;
                R = temp % R;
            }

            return L;

        }



        public string GcdOfStrings(string str1, string str2)
        {
            return (str1 + str2 == str2 + str1) ? str1.Substring(0, GCD(str2.Length, str1.Length)) : "";
        }




        // Assignment 5 OOP 



        // Time  complexity O(NlogN) 
        // Space complexity O(1) 

        // This solution as we learned (two pointers) in the workshop.
        public int MaxOperations_Sort(int[] nums, int k)
        {

            Array.Sort(nums);

            int left = 0;
            int right = nums.Length - 1;
            int operations = 0;

            while (left < right)
            {


                if (nums[left] + nums[right] == k)
                {
                    operations++;
                    left++;
                    right--;
                }
                else if (nums[left] + nums[right] < k)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return operations;

        }




        // Time  complexity O(N) 
        // Space complexity O(N)

        // better answer (without sorting)
        public int MaxOperations_Dictionary(int[] nums, int k)
        {

            Dictionary<int, int> mynums = new Dictionary<int, int>();


            foreach (var n in nums)
            {
                if (!mynums.ContainsKey(n))
                {
                    mynums[n] = 1;
                }
                else
                {
                    mynums[n] += 1;
                }

            }


            int operations = 0;


            int val;
            int secondnum;

            foreach (var n in nums)
            {
                if (mynums[n] == 0)
                {
                    continue;
                }

                mynums[n] -= 1;

                secondnum = k - n;

                if (mynums.TryGetValue(secondnum, out val) && val > 0)
                {
                    operations++;

                    mynums[secondnum] = val - 1;
                }


            }

            return operations;


        }







        // Assignment 6 OOP 

        // Time  complexity O(N) 
        // Space complexity O(1) 

        public int MaxVowels(string s, int k)
        {
            bool isvowel(char c)
            {
                return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
            }

            int vowels = 0;

            for (int i = 0; i < k; i++)
            {
                if (isvowel(s[i]))
                    vowels++;
            }

            int maxvowels = vowels;

            for (int i = k; i < s.Length; i++)
            {
                if (isvowel(s[i]))
                    vowels++;
                if (isvowel(s[i - k]))
                    vowels--;

                if (vowels > maxvowels)
                    maxvowels = vowels;
            }

            return maxvowels;
        }




        //Workshop


        public int LongestOnes_Shrinking(int[] nums, int k)
        {

            int left = 0;
            int maxOnes = 0;
            int zeroCount = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    zeroCount++;
                }

                while (zeroCount > k)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }
                    left++;
                }

                int currentWindowSize = right - left + 1;

                if (currentWindowSize > maxOnes)
                {
                    maxOnes = currentWindowSize;
                }

            }

            return maxOnes;
        }



        public int LongestOnes_NonShrinking(int[] nums, int k)
        {
            int left = 0;
            int right = 0;

            for (; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    k--;
                }

                if (k < 0)
                {
                    if (nums[left] == 0)
                    {
                        k++;
                    }
                    left++;
                }
            }

            return right - left;
        }



        public bool IncreasingTriplet(int[] nums)
        {



            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach (int num in nums)
            {
                if (num <= first)
                {
                    first = num;
                }
                else if (num <= second)
                {
                    second = num;
                }
                else
                {

                    return true;
                }
            }

            return false;
        }




        public string LongestCommonPrefix(string[] strs)
        {
            int minWordLength = strs[0].Length;

            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i].Length < minWordLength)
                {
                    minWordLength = strs[i].Length;
                }
            }
            StringBuilder result = new StringBuilder();
            int p = 0;

            // p here for characters
            while (p < minWordLength)
            {
                char c = strs[0][p];
                bool isCommon = true;

                // i here for words
                for (int i = 1; i < strs.Length; i++)
                {
                    if (c != strs[i][p])
                    {
                        isCommon = false;
                        break;
                    }
                }
                if (!isCommon) break;
                result.Append(c);
                p++;
            }

            return result.ToString();
        }


        public string ReverseWords(string s)
        {


            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(words);

            return string.Join(" ", words);
        }


        static void Main(string[] args)
        {


        }



    }
}
