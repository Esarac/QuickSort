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
        private int size;

        //Properties
        public bool Randomized
        {
            get { return randomized; }
        }

        public int Order
        {
            get { return order; }
        }

        public int Size
        {
            get { return size; }
        }

        //Constructor
        public Test(bool randomized, int order, int size)
        {
            this.randomized = randomized;
            this.order = order;
            this.size = size;
        }
    }
}
