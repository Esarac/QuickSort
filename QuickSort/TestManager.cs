using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace QuickSort
{
    class TestManager
    {
        //Attributes
        private List<Test> tests;
        private Sort sort;
        private List<string> rows;

        //Aux
        private int rowNumber;

        //Constructor
        public TestManager(List<Test> tests)
        {
            this.tests = tests;
            sort = new Sort();
            rows = new List<string>();
        }

        //Methods
        public void RunTests()
        {
            foreach(Test test in tests)
            {
                for(int i = 0; i < test.Repetitions; i++)
                {
                    RunTest(test);
                }
            }
        }


        public void RunTest(Test test)
        {
            foreach(int size in test.Sizes)
            {
                var list = SortList(CreateList(size), test.Order);
                var timeCounter = RunQuickSort(test.Randomized, list);
            }
        }

        //These methods allows creating the list with random numbers and sort them in the specified order.
        public List<int> CreateList(int size)
        {
            var list = new List<int>();

            for (int i = 0; i < size; i++)
            {
                list.Add(new Random().Next(1, (int) Math.Pow(10, 9)));
            }

            return list;
        }

        public List<int> SortList(List<int> list, int order)
        {

            if (order == 1)
            {
                list.Sort();
            }
            else if (order == 2)
            {
                list.Sort((a, b) => b.CompareTo(a));
            }

            return list;
        }

        //This method allows taking the execution time
        public Stopwatch RunQuickSort(bool randomized, List<int> list)
        {
            var timeCounter = new Stopwatch();

            if (randomized)
            {
                timeCounter.Start();
                sort.RandomQuickSort(list.ToArray(), 0, list.Count);
                timeCounter.Stop();
            }
            else
            {
                timeCounter.Start();
                sort.QuickSort(list.ToArray(), 0, list.Count);
                timeCounter.Stop();
            }

            return timeCounter;
        }
    }
}
