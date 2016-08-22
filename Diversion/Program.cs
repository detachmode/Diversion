using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Diversion
{

    public class Diversion
    {
        public List<string> permutations;
        private readonly int bitcount;


        public Diversion(int bitcount)
        {
            this.bitcount = bitcount;
            this.permutations = new List<string>();
            PermutationProduced += PermutationConsumer;
        }


        //event Action<string> 


        public List<string> CreatePermutationIterative(int size)
        {
            List<string> workingList;

            workingList = CreateInitialList();

            var liste = ModifyList(workingList, iterations: 3, newList: x => x.Select(AddAusrufezeichen).ToList());

            workingList = ModifyList(workingList, iterations: size-1, newList: NextBiggerPermutations);

            return workingList;
        }
        
        private string AddAusrufezeichen(string y)
        {
            string str = "_";
            for (int i = 1; i <= y.Length; i++)
            {
                str += i.ToString();
            }
            str += "_";

            return y + str;
        }

        private List<string> ModifyList(List<string> theList, int iterations, Func<List<string>, List<string>> newList)
        {
            for (int i = 0; i < iterations ; i++)
            {
                theList = newList(theList);
            }
            return theList;
        }

        public List<string> NextBiggerPermutations(List<string> workingList)
        {
            var list1 = workingList.Select(x => x + "0").ToList();
            var list2 = workingList.Select(x => x + "1").ToList();

            list1.AddRange(list2);

            return list1;
        }

        private static List<string> CreateInitialList()
        {
            List<string> workingList = new List<string>() { "0", "1" };
            return workingList;
        }

        //private static List<string> AddCharToAllStrings(List<string> workingList, char c)
        //{
        //    var list1 = new List<string>();
        //    foreach (string s in workingList)
        //    {
        //        list1.Add(s + c);
        //    }
        //    return list1;
        //}


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
