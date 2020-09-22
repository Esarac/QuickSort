using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Test
    {
        //Constants
        public const int RANDOM = 0;
        public const int ASCENDING = 1;
        public const int DESCENDING = 2;

        //Attributes
        private bool randomized;
        private int order;
        private int repetitions;
        private int[] sizes;

        //Properties
        public bool Randomized
        {
            get { return randomized; }
        }

        public int Order
        {
            get { return order; }
        }

        public int Repetitions
        {
            get { return repetitions; }
        }

        public int[] Sizes
        {
            get { return sizes; }
        }

        //Constructor
        public Test(bool randomized, int order, int repetitions, int[] sizes)
        {
            this.randomized = randomized;
            this.order = order;
            this.repetitions = repetitions;
            this.sizes = sizes;
        }
    }
}
