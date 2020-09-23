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
            int[] sizes = { 10, 100, 1000, 10000, 100000};
            int repetitions = 1;
            var path = @"";
            
            Test testOne = new Test(false, Test.ASCENDING, repetitions, sizes);
            Test testTwo = new Test(true, Test.ASCENDING, repetitions, sizes);
            Test testThree = new Test(false, Test.DESCENDING, repetitions, sizes);
            Test testFour = new Test(true, Test.DESCENDING, repetitions, sizes);
            Test testFive = new Test(false, Test.RANDOM, repetitions, sizes);
            Test testSix = new Test(true, Test.RANDOM, repetitions, sizes);

            var tests = new List<Test>();

            tests.Add(testOne);
            tests.Add(testTwo);
            tests.Add(testThree);
            tests.Add(testFour);
            tests.Add(testFive);
            tests.Add(testSix);

            TestManager testManager = new TestManager(tests, path);

            new Thread(() => { testManager.RunTests(); }, 10485760).Start();
        }
    }
}
