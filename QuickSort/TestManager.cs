using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace QuickSort
{
    class TestManager
    {
        //Constants
        public const int MAX_VALUE = 1000000000;
        public const int MIN_VALUE = 1;

        //Attributes
        private List<Test> tests;
        private string path;
        private Sort sort;
        private List<string> rows;

        //Aux
        private int rowNumber;

        //Constructor
        public TestManager(List<Test> tests, string path)
        {
            this.tests = tests;
            this.path = path;
            sort = new Sort();
            rows = new List<string>();
            rowNumber = 1;
            GenerateHeader();
        }

        //Methods
        public void RunTests()
        {
            foreach (Test test in tests)
            {
                for (int i = 0; i < test.Repetitions; i++)
                {
                    RunTest(test);
                }
            }

            ExportResults();
        }

        private void RunTest(Test test)
        {
            foreach (int size in test.Sizes)
            {
                var list = SortList(CreateList(size), test.Order);
                var timeCounter = RunQuickSort(test.Randomized, list);
                AddLine(test, timeCounter, size);
            }
        }

        //These methods allows creating the list with random numbers and sort them in the specified order.
        private List<int> CreateList(int size)
        {
            var list = new List<int>();

            for (int i = 0; i < size; i++)
            {
                list.Add(new Random().Next(MIN_VALUE, MAX_VALUE));
            }

            return list;
        }

        private List<int> SortList(List<int> list, int order)
        {

            if (order == Test.ASCENDING)
            {
                list.Sort();
            }
            else if (order == Test.DESCENDING)
            {
                list.Sort((a, b) => b.CompareTo(a));
            }

            return list;
        }

        //This method allows taking the execution time
        private Stopwatch RunQuickSort(bool randomized, List<int> list)
        {
            var timeCounter = new Stopwatch();

            if (randomized)
            {
                timeCounter.Start();
                sort.RandomQuickSort(list.ToArray(), 0, list.Count-1);
                timeCounter.Stop();
            }
            else
            {
                timeCounter.Start();
                sort.QuickSort(list.ToArray(), 0, list.Count-1);
                timeCounter.Stop();
            }

            return timeCounter;
        }

        //This method creates a row of the table.
        private void AddLine(Test test, Stopwatch timer, int size)
        {
            var variant = test.Randomized ? "Randomized" : "Normal";

            var state = "Random";

            if (test.Order == Test.DESCENDING)
                state = "Descending";
            else if (test.Order == Test.ASCENDING)
                state = "Ascending";


            var elapsed = timer.Elapsed;

            rows.Add(string.Format("{0},{1},{2},{3},{4:0.###}", rowNumber, variant, state, size, elapsed.TotalMilliseconds));

            int total = tests.Count * test.Sizes.Length * test.Repetitions;

            Console.WriteLine(string.Format("{0}/{1} rows added", rowNumber, total));
            
            rowNumber++;
        }

        private void ExportResults()
        {
            Console.WriteLine("Start writing");
            File.WriteAllLines(path, rows);
        }

        //Generators
        private void GenerateHeader() => rows.Add("TEST,VARIANT,STATE,SIZE,TIME (In Ms)");
    }
}
