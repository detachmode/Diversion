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

        public Diversion()
        {
            permutations = new List<string>();
        }
        public int find_matching_combinations(int bitcount)
        {
            createPermutations(bitcount);
            filteroutNotMatchingElements();

            return permutations.Count;
        }

        public void filteroutNotMatchingElements()
        {
            throw new NotImplementedException();
        }

        public void createPermutations(int bitcount)
        {
            createPermutationsRecursive(bitcount, "");
        }


        public void createPermutationsRecursive(int bitcount, string str)
        {
            appendBitRecursiveAndFinallyAddToPermutations(str, "0", bitcount);
            appendBitRecursiveAndFinallyAddToPermutations(str, "1", bitcount);
        }


        public event Action<string, int> addToCombination;


        public void appendBitRecursiveAndFinallyAddToPermutations(string str, string thechar, int bitcount)
        {
            if (bitcount == 0)
            {
                permutations.Add(str);
                return;
            }   
                   
            str += thechar;
            createPermutationsRecursive(--bitcount, str);

        }

    }








    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
