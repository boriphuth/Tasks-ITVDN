using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls;

namespace Async_Sort
{
    public delegate void Handler(object sender, SendStateEventArgs e);

    public class Model
    {
        public Model()
        {
            this.array1 = InitializeArray(array1);
            this.array1.CopyTo(array2, 0);
            this.array1.CopyTo(array3, 0);
            positions = InitializePositions(positions);
            
        }
     
        public event Handler SendArray1;
        public event Handler SendArray2;
        public event Handler SendArray3;

        public const int MAX = 500;
        Random random = new Random();
       
        int[] array1 = new int[MAX];
        int[] array2 = new int[MAX];
        int[] array3 = new int[MAX];
        int[] positions = new int[MAX];

        //--------------------Initialize Array--------------------------------
        public int[] InitializePositions(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            return array;
        }

        public int[] InitializeArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, array.Length);
            }
            return array;
        }

        //------------------------Send Start Arrays---------------------------------------------
        public void OnSendStart(object sender,SendStateEventArgs e)
        {
            SendArray1(this, new SendStateEventArgs(array1, positions));
            SendArray2(this, new SendStateEventArgs(array2, positions));
            SendArray3(this, new SendStateEventArgs(array3, positions));
        }

        

        //--------------------------------SortBubble--------------------------------------------
        public bool SortBubble()
        {                       
                int temp = 0;

                for (int write = 0; write < array1.Length; write++)
                {
                    for (int sort = 0; sort < array1.Length - 1; sort++)
                    {
                        if (array1[sort] > array1[sort + 1])
                        {
                            temp = array1[sort + 1];
                            array1[sort + 1] = array1[sort];
                            array1[sort] = temp;

                            SendArray1(this, new SendStateEventArgs(array1, positions));
                       }
                    }                
            }
            return true;
        }

        public async Task<bool> OnSendSort()
        {
            return await Task.Run(() => SortBubble());
        }

        //---------------------------SortInsertion--------------------------------------------------

        public bool SortInsertion()
        {
            for (int i = 0; i < array2.Length - 1; i++)
            {
                int j = i + 1;

                while (j > 0)
                {
                    if (array2[j - 1] > array2[j])
                    {
                        int temp = array2[j - 1];
                        array2[j - 1] = array2[j];
                        array2[j] = temp;
                        SendArray2(this, new SendStateEventArgs(array2, positions));
                    }
                    j--;
                    
                }
                
            }
            return true;
        }

        public async Task<bool> OnSendSort2()
        {
            return await Task.Run(() => SortInsertion());
        }

        //------------------------------------SortQuick-----------------------------------------------
        public async Task<bool> OnSendSort3()
        {
            return await Task.Run(() => SortQuick(array3,0,array3.Length-1));
        }
        public bool SortQuick(int[] a, int l, int r)
        {
            int temp;
            int x = a[l + (r - l) / 2];
            //запись эквивалентна (l+r)/2, 
            //но не вызввает переполнения на больших данных
            int i = l;
            int j = r;
            //код в while обычно выносят в процедуру particle
            while (i <= j)
            {
                while (a[i] < x) i++;
                while (a[j] > x) j--;
                if (i <= j)
                {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;

                    SendArray3(this, new SendStateEventArgs(a, positions));
                }
            }
            if (i < r)
                SortQuick(a, i, r);

            if (l < j)
                SortQuick(a, l, j);
            return true;
        }
    }
}
