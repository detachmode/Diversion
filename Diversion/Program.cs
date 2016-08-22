using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diversion
{

    public class Diversion
    {
        public List<string> permutations;
        private readonly int bitcount;
        List<string> workingList;

        public Diversion(int bitcount)
        {
            this.bitcount = bitcount;
            this.permutations = new List<string>();
            PermutationProduced += PermutationConsumer;
        }


        //event Action<string> 


        public List<string> CreatePermutationIterative(int size, Action<List<string>> buildPermutationFunc)
        {
            workingList = CreateInitialList();

            for (int i = 0; i < size - 1; i++)
            {
                workingList = AddNextBiggerPermutations(workingList);
            }

            return workingList;
        }

        private static List<string> CreateInitialList()
        {
            List<string> workingList = new List<string>() { "0", "1" };
            return workingList;
        }

        public List<string> AddNextBiggerPermutations(List<string> workingList)
        {
            var list1 = AddCharToAllStrings(workingList, '0');
            var list2 = AddCharToAllStrings(workingList, '1');

            list1.AddRange(list2);

            return list1;
        }

        private static List<string> AddCharToAllStrings(List<string> workingList, char c)
        {
            var list1 = new List<string>();
            foreach (string s in workingList)
            {
                list1.Add(s + c);
            }
            return list1;
        }


        private void PermutationConsumer(string str, int stillMissing)
        {
            if (stillMissing == 0)
                permutations.Add(str);
            else
                createNextBiggerPermutation(str, stillMissing);
        }

        public int find_matching_combinations()
        {
            createPermutations();
            filteroutNotMatchingElements();

            return permutations.Count;
        }

        public void filteroutNotMatchingElements()
        {
            throw new NotImplementedException();
        }

        public void createPermutations()
        {
            createNextBiggerPermutation("", this.bitcount);
        }


        public void createNextBiggerPermutation(string str, int stillMissing)
        {
            PermutationProduced?.Invoke(str + "0", --stillMissing);
            PermutationProduced?.Invoke(str + "1", --stillMissing);
        }

        public event Action<string, int> PermutationProduced;

    }








    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
