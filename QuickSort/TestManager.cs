using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class TestManager
    {
        //Attributes
        private List<Test> tests;
        private List<string> rows;

        //Constructor
        public TestManager(List<Test> tests)
        {
            this.tests = tests;
        }

        //Methods
        public void RunTests()
        {
            foreach(Test test in tests)
            {
                for(int i = 0; i < test.Repetitions; i++)
                {

                }
            }
        }


        public void RunTest()
        {

        }

        public List<Int32> CreateList(int size)
        {
            return null;
        }
    }
}
