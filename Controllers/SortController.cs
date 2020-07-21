using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Diagnostics.Debug;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algorithm.Controllers
{
    [Route("api/sort")]
    public class SortController : Controller
    {

        private static Stopwatch sw = new Stopwatch();

        [HttpGet]
        public int[] SortMain()
        {

            var array = new int[] { 999, 54, 3, 44, 33, 666, 3453, 345345, 245245, 34254235, 345, 33, 88, 665, 22 };
            Console.WriteLine("排序前:");

            foreach (var item in array)
            {
                Console.Write($"{item} ");

            }
            Console.WriteLine("");
            sw.Start();
            var returnArray = RadixSort2(array);
            sw.Stop();

            Console.WriteLine($@"排序后,用时:{sw.Elapsed}");

            foreach (var item in returnArray)
            {
                Console.Write($"{item},");

            }
            Console.WriteLine("");
            return returnArray;
        }

        #region 比较类排序
        #region 交换排序
        #region 冒泡排序
        /// <summary>
        /// 1.1 
        /// 步骤1: 比较相邻的元素。如果第一个比第二个大，就交换它们两个；
        /// 步骤2: 对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对，这样在最后的元素应该会是最大的数；
        /// 步骤3: 针对所有的元素重复以上的步骤，除了最后一个；        
        /// 步骤4: 重复步骤1 ~3，直到排序完成。
        ///     小数向前，大数向后
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public Array BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        swap(array, j, j + 1);
                    }
                }
            }
            return array;

        }
        #endregion

        #region 快速排序
        /*
         * 快速排序核心概念：分治，递归
         1.从数列中挑出一个元素，称为 “基准”（pivot）；

2.重新排序数列，所有元素比基准值小的摆放在基准前面，所有元素比基准值大的摆在基准的后面（相同的数可以到任一边）。在这个分区退出之后，该基准就处于数列的中间位置。这个称为分区（partition）操作；

3.递归地（recursive）把小于基准值元素的子数列和大于基准值元素的子数列排序。*/

        public Array QuickSort(int[] array, int? left, int? right)
        {
            left = left ?? 0;
            right = right ?? array.Length - 1;

            if (left < right)
            {
                int index = Partition(array, left.Value, right.Value);
                QuickSort(array, left, index - 1);
                QuickSort(array, index + 1, right);
            }
            return array;
        }
        /// <summary>
        /// 分区操作
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int Partition(int[] array, int left, int right)
        {
            Console.WriteLine("排序中:");
            foreach (var item in array)
            {
                if (!(item == array.Last()))
                {
                    Console.Write($"{item},");
                }
                else
                {
                    Console.WriteLine($"{item}");
                }
            }
            int povit = left;
            int index = povit + 1;
            for (int i = index; i <= right; i++)
            {
                if (array[i] < array[povit])
                {
                    swap(array, i, index);
                    index++;//index 自增的次数表示大于povit的个数
                }
            }

            swap(array, povit, index - 1);

            return index - 1;
        }

        #endregion
        #endregion

        #region 插入排序
        #region 简单插入排序
        /*
3.1 插入排序

一般来说，插入排序都采用in-place在数组上实现。具体算法描述如下：
步骤1: 从第一个元素开始，该元素可以认为已经被排序；
步骤2: 取出下一个元素，在已经排序的元素序列中从后向前扫描；
步骤3: 如果该元素（已排序）大于新元素，将该元素移到下一位置；
步骤4: 重复步骤3，直到找到已排序的元素小于或者等于新元素的位置；
步骤5: 将新元素插入到该位置后；
步骤6: 重复步骤2~5。

 */
        public Array InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int currentNum = array[i + 1];
                int preIndex = i;
                while (preIndex > 0 && array[preIndex] > currentNum)
                {
                    array[preIndex + 1] = array[preIndex];
                    preIndex--;

                }
                array[preIndex + 1] = currentNum;
            }

            return array;
        }

        #endregion
        #region 希尔排序
        /*
 * 4.1 希尔排序(缩小增量排序)

            我们来看下希尔排序的基本步骤，在此我们选择增量gap=length/2，缩小增量继续以gap = gap/2的方式，这种增量选择我们可以用一个序列来表示，{n/2,(n/2)/2…1}，称为增量序列。希尔排序的增量序列的选择与证明是个数学难题，我们选择的这个增量序列是比较常用的，也是希尔建议的增量，称为希尔增量，但其实这个增量序列不是最优的。此处我们做示例使用希尔增量。

            先将整个待排序的记录序列分割成为若干子序列分别进行直接插入排序，具体算法描述：
    步骤1：选择一个增量序列t1，t2，…，tk，其中ti>tj，tk=1；
    步骤2：按增量序列个数k，对序列进行k 趟排序；
    步骤3：每趟排序，根据对应的增量ti，将待排序列分割成若干长度为m 的子序列，分别对各子表进行直接插入排序。仅增量因子为1 时，整个序列作为一个表来处理，表长度即为整个序列的长度。
 */
        public Array ShellSort(int[] array)
        {
            int len = array.Length;
            int gap = len / 2;
            while (gap > 0)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    int currentNun = array[i];
                    int preIndex = i - gap;
                    while (preIndex >= 0 & array[preIndex] > currentNun)
                    {
                        array[preIndex + gap] = array[preIndex];
                        preIndex -= gap;
                    }
                    array[preIndex + gap] = currentNun;

                }
                gap /= 2;
            }
            return array;
        }

        #endregion
        #endregion

        #region 选择排序
        #region 简单选择排序
        /*
 * 2.1 选择排序
        n个记录的直接选择排序可经过n-1趟直接选择排序得到有序结果。具体算法描述如下：
步骤1：初始状态：无序区为R[1…n]，有序区为空；
步骤2：第i趟排序(i=1,2,3…n-1)开始时，当前有序区和无序区分别为R[1…i-1]和R(i…n）。该趟排序从当前无序区中-选出关键字最小的记录 R[k]，将它与无序区的第1个记录R交换，使R[1…i]和R[i+1…n)分别变为记录个数增加1个的新有序区和记录个数减少1个的新无序区；
步骤3：n-1趟结束，数组有序化了。

 */
        public Array SelectSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                }
                swap(array, i, minIndex);
            }
            return array;
        }

        #endregion

        #region 堆排序

        #region 堆排序
        /*
        * 以下均为从小到大排序
        * 堆排序要点：
        * 第一步是构建大顶堆(大数在根节点)，这样就可以把最大值放在根节点
        * 第二步是调整堆，将最大值与最后的子节点数据交换，将最大值放在最后，并不再参与堆的排序(将最大值放到了最后)
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public Array HeapSort(int[] array)
        {
            //1.构造大顶堆
            for (int i = array.Length / 2 - 1; i > 0; i--)
            {
                //从第一个非叶子节点从下至上，从右至左调整结构
                AdjustHeap(array, i, array.Length);
            }
            //2.调整堆结构+交换堆顶元素与末尾元素
            for (int j = array.Length - 1; j > 0; j--)
            {
                swap(array, 0, j);
                AdjustHeap(array, 0, j);
            }
            return new int[] { };
        }


        /// <summary>
        /// 构造大顶堆
        /// 从 index 开始检查并保持最大堆性质
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="i">检查的起始下标</param>
        /// <param name="length">堆大小</param>
        private void AdjustHeap(int[] arr, int i, int length)
        {
            int temp = arr[i];// 先取出当前元素i
            for (int k = i * 2 + 1; k < length; k = k * 2 + 1)//从i结点的左子结点开始，也就是2i+1处开始
            {
                if (k + 1 < length && arr[k] < arr[k + 1])//如果左子结点小于右子结点，k指向右子结点
                {
                    k++;
                }
                if (arr[k] > temp)//如果子节点大于父节点，将子节点值赋给父节点（不用进行交换）
                {
                    arr[i] = arr[k];
                    i = k;
                }
                else
                {
                    break;
                }
            }
            arr[i] = temp;
        }
        #endregion


        #region 堆排序2
        /// <summary>
        /// 最大堆调整
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="index">检查的起始下标</param>
        /// <param name="heapSize">堆的大小</param>
        private void MaxHeapify(int[] array, int index, int heapSize)
        {
            var iMax = index;
            var iLeft = 2 * index + 1;//index节点的左子节点
            var iRight = 2 * (index + 1);//index节点的右子节点

            //如果左节点大于index节点，则大值为左节点
            if (iLeft < heapSize && array[index] < array[iLeft])
            {
                iMax = iLeft;
            }
            //如果右节点大于index节点，则大值为右节点
            if (iRight < heapSize && array[iMax] < array[iRight])
            {
                iMax = iRight;
            }
            //大值不为index节点，则交换，并重新调整
            if (iMax != index)
            {
                swap(array, iMax, index);
                MaxHeapify(array, iMax, heapSize);
            }
        }

        /// <summary>
        /// 构建最大堆
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        private void builderMaxHeap(int[] array, int heapSize)
        {
            //获取非叶子节点
            var IParser = (int)Math.Floor((decimal)heapSize / 2 - 1);

            for (int i = IParser; i >= 0; i--)
            {
                MaxHeapify(array, i, heapSize);
            }
        }


        public int[] HeapSort2(int[] array)
        {
            var heapSize = array.Length - 1;
            builderMaxHeap(array, heapSize);
            for (int i = heapSize; i > 0; i--)
            {
                swap(array, 0, i);
                MaxHeapify(array, 0, i);
            }
            return array;
        }
        #endregion


        public int[] HeapSort3(int[] array)
        {
            int heapSize = array.Length - 1;//获取最大数组下标
            //构建大顶堆
            //BuilderMaxHeap3(array, heapSize);
            //for循环
            for (int i = heapSize; i >= 0; i--)
            {
                //继续构建大顶堆
                BuilderMaxHeap3(array, i);
                //将第一个数据与最后一个数据进行调整
                swap(array, 0, i);
            }
            return array;
        }
        public void BuilderMaxHeap3(int[] array, int size)
        {
            //获取最后一个非叶子节点(因为是索引，必须加+1)
            int iParser = (int)Math.Floor((decimal)((size + 1) / 2 - 1));

            //for循环
            for (int i = iParser; i >= 0; i--)
            {
                //调整大顶堆
                MaxHeapify3(array, i, size);
            }

        }

        public void MaxHeapify3(int[] array, int index, int size)
        {
            //默认最大值为index，及初始化左右子节点
            int max = index;
            int iLeft = 2 * index + 1, iRight = 2 * (index + 1);

            //获取节点中的最大值
            if (iLeft <= size && array[max] < array[iLeft])
            {
                max = iLeft;
            }
            if (iRight <= size && array[max] < array[iRight])
            {
                max = iRight;
            }
            //如果最大值不是index
            if (max != index)
            {
                //则交换数据
                swap(array, max, index);
                //继续向下调整堆(因为子节点的数据已经变更)(可能不需要)
                //MaxHeapify3(array, max, size);
            }
        }

        #endregion

        #endregion

        #region 归并排序
        #region 二路归并排序

        /*
         * 5.1 归并排序
        步骤1：把长度为n的输入序列分成两个长度为n/2的子序列；
        步骤2：对这两个子序列分别采用归并排序；
        步骤3：将两个排序好的子序列合并成一个最终的排序序列。
         */
        public Array MergeSort(int[] array)
        {

            return array;
        }

        public Array merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            for (int i = 0, j = 0, index = 0; index < result.Length; index++)
            {
                if (i >= left.Length)
                {
                    result[index] = right[j++];
                }

            }
            return result;
        }
        #endregion

        #region 多路归并排序

        #endregion
        #endregion
        #endregion

        #region 非比较排序

        #region 计数排序
        /*8.1 算法描述
        步骤1：找出待排序的数组中最大和最小的元素；
/步骤2：统计数组中每个值为i的元素出现的次数，存入数组C的第i项；
步骤3：对所有的计数累加（从C中的第一个元素开始，每一项和前一项相加）；
步骤4：反向填充目标数组：将每个元素i放在新数组的第C(i)项，每放一个元素就将C(i)减去1。
*/
        /// <summary>
        /// 求最值，初新组，正反填充数组得
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] CountingSort(int[] array)
        {
            //求最大最小值
            int min = array[0], max = array[0];
            foreach (var item in array)
            {
                max = item > max ? item : max;
                min = item < min ? item : min;
            }
            //初始化新组并赋值
            var bucket = new int[max - min + 1];//数组长度比实际个数大一
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = 0;
            }
            //正填充
            int bias = 0 - min;
            for (int i = 0; i < array.Length; i++)
            {
                bucket[array[i] + bias]++;
            }
            //反填充
            int arrayIndex = 0, bucketIndex = 0;
            while (arrayIndex < array.Length)
            {
                if (bucket[bucketIndex] != 0)
                {
                    array[arrayIndex] = bucketIndex - bias;
                    bucket[bucketIndex]--;
                    arrayIndex++;
                }
                else
                {
                    bucketIndex++;
                }
            }

            return array;

        }
        #endregion

        #region 桶排序

        public int[] BucketSort(int[] array)
        {
            return BucketSortReCursion2(array.ToList(), array.Length).ToArray();
        }

        /*
         9.1 算法描述
步骤1：人为设置一个BucketSize，作为每个桶所能放置多少个不同数值（例如当BucketSize==5时，该桶可以存放｛1,2,3,4,5｝这几种数字，但是容量不限，即可以存放100个3）；
步骤2：遍历输入数据，并且把数据一个一个放到对应的桶里去；
步骤3：对每个不是空的桶进行排序，可以使用其它排序方法，也可以递归使用桶排序；
步骤4：从不是空的桶里把排好序的数据拼接起来。 

注意，如果递归使用桶排序为各个桶排序，则当桶数量为1时要手动减小BucketSize增加下一循环桶的数量，否则会陷入死循环，导致内存溢出。
*/
        public List<int> BucketSortReCursion(List<int> array, int bucketSize)
        {
            if (array == null || array.Count < 2)
            {
                return array;
            }
            //找出最大值最小值
            int max = array[0], min = array[0];
            for (int i = 0; i < array.Count; i++)
            {
                max = array[i] > max ? array[i] : max;
                min = array[i] < min ? array[i] : min;
            }
            //初始化桶个数
            int bucketCount = (max - min) / bucketSize + 1;

            //初始化桶数组
            List<List<int>> bucketArr = new List<List<int>>(bucketCount);
            for (int i = 0; i < bucketCount; i++)
            {   
                bucketArr.Add(new List<int>());
            }

            //正填充
            for (int i = 0; i < array.Count; i++)
            {
                int index = (array[i] - min) / bucketSize;
                //对应桶添加数据
                bucketArr[index].Add(array[i]);
            }

            //反填充
            List<int> resultArr = new List<int>();
            for (int i = 0; i < bucketCount; i++)
            {
                if (bucketSize == 1)
                {
                    for (int j = 0; j < bucketArr[i].Count; j++)
                    {
                        resultArr.Add(bucketArr[i][j]);
                    }
                }
                else
                {
                    if (bucketCount == 1)
                    {
                        bucketSize--;
                    }
                    List<int> temp = BucketSortReCursion(bucketArr[i], bucketSize);
                    for (int j = 0; j < temp.Count; j++)
                    {
                        resultArr.Add(temp[j]);
                    }
                }
            }
            return resultArr;
        }

        /// <summary>
        /// 求最值，初新组，正反填充数组得
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arraySize"></param>
        /// <returns></returns>
        public List<int> BucketSortReCursion2(List<int> array, int bucketSize)
        {
            if (array == null || array.Count < 2)
            {
                return array;
            }

            //求最值
            int max = array[0], min = array[0];
            foreach (var item in array)
            {
                max = item > max ? item : max;
                min = item < min ? item : min;
            }

            //初新组(桶)
            //初始化桶数量
            int bucketCount = (max - min) / bucketSize + 1;
            var buckets = new List<List<int>>(bucketCount);
            for (int i = 0; i < bucketCount; i++)
            {
                buckets.Add(new List<int>());
            }

            //正填充
            for (int i = 0; i < array.Count; i++)
            {
                //找到对应的桶
                int index = (array[i] - min) / bucketSize;
                buckets[index].Add(array[i]);
            }
                       
            //反填充
            List<int> arrayResult = new List<int>();
            for (int i = 0; i < bucketCount; i++)
            {
                //当桶大小为1时，将桶的数据全部放入结果集
                if(bucketSize==1)
                {
                    foreach (var item in buckets[i])
                    {
                        arrayResult.Add(item);
                    }
                }
                else
                {
                    
                    if(bucketCount==1)
                    {
                        
                        bucketSize--;
                    }
                    //递归调用
                    List<int> temp = BucketSortReCursion2(buckets[i], bucketSize);
                    foreach (var item in temp)
                    {
                        arrayResult.Add(item);
                    }
                }
            }
            return arrayResult;

        }
       
        #endregion
        #region 基数排序

        public int[] RadixSort(int[] array)
        {
            if(array==null&&array.Length<2)
            {
                return array;
            }
            //求最值
            int max = array[0];
            foreach (var item in array)
            {
                max = max > item ? max : item;
            }
            //求最大值位数
            int maxDigit = 0;
            while(max!=0)
            {
                max /= 10;
                maxDigit++;
            }

            //初始化桶(十个桶，分别放(0-9)的数字)

            int mod = 10, div = 1;
            var bucketList = new List<List<int>>();
            for (int i = 0; i < mod; i++)
            {
                bucketList.Add(new List<int>());
            }

            //最大值位数
            for (int i = 0; i < maxDigit; i++)
            {
                //给桶加上对应基数的数据
                for (int j = 0; j < array.Length; j++)
                {
                    //求出对应位数的基数 例如 171%100=71 71/10=7 就是十位的基数
                    int num = (array[j] % mod) / div;
                    bucketList[num].Add(array[j]);
                }

                //将桶数据反填充到array数组中
                int index = 0;
                for (int j = 0; j < bucketList.Count; j++)
                {
                    for (int k = 0; k < bucketList[j].Count; k++)
                    {
                        array[index++] = bucketList[j][k];
                    }
                    bucketList[j].Clear();
                }

                mod *= 10;
                div *= 10;
            }
            return array;

        }

        public int[] RadixSort2(int[] array)
        {
            //求最(大)值
            int max = array[0];
            foreach (var item in array)
            {
                max = item > max ? item : max;
            }

            int maxDigit = 0;
            while(max!=0)
            {
                max /= 10;maxDigit++;
            }
            //初新桶
            var bucket = new List<List<int>>();
            for (int i = 0; i < 10; i++)
            {
                bucket.Add(new List<int>());
            }
            for (int i = 0; i < maxDigit; i++)
            {
                //正填充
                int div = (int)Math.Pow(10, (i + 1));
                foreach (var item in array)
                {
                    //获取基数
                    int radix = (item % div) / (div / 10);
                    bucket[radix].Add(item);
                }

                //反填充（//反填充要注意顺序）
                int index = 0;
                foreach (var item in bucket)
                {
                    foreach (var it in item)
                    {
                        array[index++] = it;
                        
                    }
                    item.Clear();
                }
                
            }
            return array;

        }
        #endregion
        #endregion



        /// <summary>
        /// 交换函数
        /// </summary>
        /// <param name="array">待交换数组</param>
        /// <param name="i">数组下标</param>
        /// <param name="j">数组下标</param>
        private void swap(int[] array, int i, int j)
        {
            //array[i] = array[i] + array[j];
            //array[j] = array[i] - array[j];
            //array[i] = array[i] - array[j];
            int temp = 0;
            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    }
}
