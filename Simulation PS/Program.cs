
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
                last --;
            }
    
        }



        // Assignment 3
        public int SingleNumber(int[] nums)
        {
            int num=nums[0];

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
            return (str1 + str2 == str2 + str1) ? str1.Substring(0,GCD(str2.Length, str1.Length)) : "";
        }



        static void Main(string[] args)
        {






        }
    }
}
