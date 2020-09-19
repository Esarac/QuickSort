using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class Sort
    {
        //No Randomized
        public void QuickSort(int[] a, int p, int r) {
            if (p < r)
            {
                int q = Partition(a, p, r);
                QuickSort(a, p, q - 1);
                QuickSort(a, q + 1, r);
            }
        }

        public int Partition(int[] a, int p, int r)
        {
            int x = a[r];
            int i = p - 1;
            for(int j = p; j <= (r - 1); j++)
            {
                if (a[j] <= x)
                {
                    i = i + 1;

                    int aux = a[i];//Guarda
                    a[i] = a[j];
                    a[j] = aux;
                }
            }
            a[i + 1] = a[r];

            return i + 1;
        }

        //Randomized
        public void RandomQuickSort(int[] a, int p, int r)
        {
            if(p < r)
            {
                int q = RandomPartition(a, p, r);
                RandomQuickSort(a, p, q - 1);
                RandomQuickSort(a, q + 1, r);
            }
        }

        public int RandomPartition(int[] a, int p, int r)
        {
            //Random rnd = new Random();
            //int i = rnd.Next(p, r);

            //int aux = a[i];//Guarda
            //a[i] = a[r];
            //a[r] = aux;

            return Partition(a, p, r);
        }
    }
}
