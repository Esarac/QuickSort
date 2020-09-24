using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = "../../results/result.csv";

            var tests = new List<Test>();

            //NOT RANDOM
                //ASCENDING
            tests.Add(new Test(false, Test.ASCENDING, 10));
            tests.Add(new Test(false, Test.ASCENDING, 100));
            tests.Add(new Test(false, Test.ASCENDING, 1000));
            tests.Add(new Test(false, Test.ASCENDING, 10000));
                //DESCENDING
            tests.Add(new Test(false, Test.DESCENDING, 10));
            tests.Add(new Test(false, Test.DESCENDING, 100));
            tests.Add(new Test(false, Test.DESCENDING, 1000));
            tests.Add(new Test(false, Test.DESCENDING, 10000));
                //RANDOM
            tests.Add(new Test(false, Test.RANDOM, 10));
            tests.Add(new Test(false, Test.RANDOM, 100));
            tests.Add(new Test(false, Test.RANDOM, 1000));
            tests.Add(new Test(false, Test.RANDOM, 10000));
            //NOT RANDOM
                //ASCENDING
            tests.Add(new Test(true, Test.ASCENDING, 10));
            tests.Add(new Test(true, Test.ASCENDING, 100));
            tests.Add(new Test(true, Test.ASCENDING, 1000));
            tests.Add(new Test(true, Test.ASCENDING, 10000));
                //DESCENDING
            tests.Add(new Test(true, Test.DESCENDING, 10));
            tests.Add(new Test(true, Test.DESCENDING, 100));
            tests.Add(new Test(true, Test.DESCENDING, 1000));
            tests.Add(new Test(true, Test.DESCENDING, 10000));
                //RANDOM
            tests.Add(new Test(true, Test.RANDOM, 10));
            tests.Add(new Test(true, Test.RANDOM, 100));
            tests.Add(new Test(true, Test.RANDOM, 1000));
            tests.Add(new Test(true, Test.RANDOM, 10000));

            TestManager testManager = new TestManager(tests, path);

            new Thread(() => { testManager.RunTests(); }, 10485760).Start();
        }
    }
}
