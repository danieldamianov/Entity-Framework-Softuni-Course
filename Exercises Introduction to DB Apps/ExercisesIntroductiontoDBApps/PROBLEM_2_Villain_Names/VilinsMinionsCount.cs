using System;
using System.Collections.Generic;
using System.Text;

namespace PROBLEM_2_Villain_Names
{
    class VilinsMinionsCount
    {
        public VilinsMinionsCount(string name, int countOfMinions)
        {
            Name = name;
            CountOfMinions = countOfMinions;
        }

        public string Name { get; set; }

        public int CountOfMinions { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.CountOfMinions}";
        }
    }
}
