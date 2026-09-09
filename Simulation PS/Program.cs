
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

        static void Main(string[] args)
        {






        }
    }
}
