using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;

namespace QuickSort
{
    class TestManager
    {
        //Constants
        public const int REPETITIONS = 2;
        public const int MAX_VALUE = 1000000000;
        public const int MIN_VALUE = 1;

        //Attributes
        private List<Test> tests;
        private Sort sort;
        private string path;
        private List<string> rows;

        //Aux
        private int rowNumber;
        private int [,][] testArray;

        //Constructor
        public TestManager(List<Test> tests, string path)
        {
            //CSV
            this.path = path;
            rows = new List<string>();
            //Treatments
            this.tests = tests;
            //Sort
            sort = new Sort();
            //Aux
            rowNumber = 1;

            GenerateHeader();
        }

        //Methods
                //Test
        public void RunTests()//Ya
        {
            GenerateTestArrays();

            foreach (Test test in tests)
            {
                for (int i = 0; i < REPETITIONS; i++)
                {
                    RunTest(test);
                }
            }

            ExportResults();
        }

        private void GenerateTestArrays(){
            testArray = new int[3,5][];
            Random randomClass = new Random();

            for(int i = 0; i< tests.Count; i++)
            {
                int iOrder = tests[i].Order;
                int iSize = ((int) Math.Log10((double) tests[i].Size)) - 1;

                testArray[iOrder, iSize] = new int[tests[i].Size];
                int[] actualArray = testArray[iOrder, iSize];

                switch (iOrder)
                {
                    case 1:
                        for (int j=0; j < actualArray.Length; j++)
                        {
                            actualArray[j] = randomClass.Next(MIN_VALUE, MAX_VALUE);
                        }
                        break;
                    case 2:
                        for (int j = 0; j < actualArray.Length; j++)
                        {
                            actualArray[j] = j+1;
                        }
                        break;
                    case 3:
                        for (int j = 0; j < actualArray.Length; j++)
                        {
                            actualArray[j] = actualArray.Length - j;
                        }
                        break;
                }

            }
        }

        private void RunTest(Test test)
        {
            int iSize = ((int)Math.Log10((double)test.Size)) - 1;
            var timeCounter = RunQuickSort(test.Randomized, ( (int[]) testArray[test.Order, iSize].Clone() ));
            AddLine(test, timeCounter);
        }

        //This method allows taking the execution time
        private Stopwatch RunQuickSort(bool randomized, int[] list)
        {
            var timeCounter = new Stopwatch();

            if (randomized)
            {
                timeCounter.Start();
                sort.RandomQuickSort(list, 0, list.Length-1);
                timeCounter.Stop();
            }
            else
            {
                timeCounter.Start();
                sort.QuickSort(list, 0, list.Length-1);
                timeCounter.Stop();
            }

            return timeCounter;
        }

            //CSV
        //This method creates a row of the table.
        private void AddLine(Test test, Stopwatch timer)
        {
            var variant = test.Randomized ? "Randomized" : "Normal";

            var state = "Random";

            if (test.Order == Test.DESCENDING)
                state = "Descending";
            else if (test.Order == Test.ASCENDING)
                state = "Ascending";


            var elapsed = timer.Elapsed;

            rows.Add(string.Format("{0},{1},{2},{3},{4:0.###}", rowNumber, variant, state, test.Size, elapsed.TotalMilliseconds.ToString("G", CultureInfo.InvariantCulture)));

            int total = tests.Count * REPETITIONS;

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
