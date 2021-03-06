﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickSort;

namespace QuickSortTest
{
    [TestClass]
    public class SortTest
    {
        //Tested Class
        private Sort sort;

        //Scenes
        [TestInitialize]
        public void Initialize()
        {
            sort = new Sort();
        }

        //Tests
        [TestMethod]
        public void TestQuickSort()
        {
            //Small
            int[] small = { 5, 2, 3, 1, 4 };

            sort.QuickSort(small, 0, small.Length - 1);
            for (int i = 0; i < small.Length - 1; i++)
            {
                Assert.IsTrue(small[i] <= small[i + 1]);
            }

            //Big
            int[] big = new int[1000];
            for (int i = 0; i < big.Length; i++)
            {
                big[i] = 1000 - i;
                Console.WriteLine(big[i]);
            }

            sort.QuickSort(big, 0, big.Length - 1);
            for (int i = 0; i < big.Length - 1; i++)
            {
                Assert.IsTrue(big[i] < big[i + 1]);
            }

            //Random
            int[] random = new int[100];
            Random r = new Random();
            for (int i = 0; i < random.Length; i++)
            {
                random[i] = r.Next(1, 101);
            }

            sort.QuickSort(random, 0, random.Length - 1);
            for (int i = 0; i < random.Length - 1; i++)
            {
                Assert.IsTrue(random[i] <= random[i + 1]);
            }
        }

        [TestMethod]
        public void TestRandomQuickSort()
        {
            //Small
            int[] small = { 5, 2, 3, 1, 4 };

            sort.RandomQuickSort(small, 0, small.Length - 1);
            for (int i = 0; i < small.Length - 1; i++)
            {
                Assert.IsTrue(small[i] <= small[i + 1]);
            }

            //Big
            int[] big = new int[1000];
            for (int i = 0; i < big.Length; i++)
            {
                big[i] = 1000 - i;
            }

            sort.RandomQuickSort(big, 0, big.Length - 1);
            for (int i = 0; i < big.Length - 1; i++)
            {
                Assert.IsTrue(big[i] < big[i + 1]);
            }

            //Random
            int[] random = new int[100];
            Random r = new Random();
            for (int i = 0; i < random.Length; i++)
            {
                random[i] = r.Next(1, 101);
            }

            sort.RandomQuickSort(random, 0, random.Length - 1);
            for (int i = 0; i < random.Length - 1; i++)
            {
                Assert.IsTrue(random[i] <= random[i + 1]);
            }
        }

    }
}
