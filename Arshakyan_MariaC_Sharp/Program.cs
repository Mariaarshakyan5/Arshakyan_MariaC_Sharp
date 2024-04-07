using System;
using System.Diagnostics;

namespace TemplateMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorter selectionSorter = new SelectionSorter();
            Sorter mergeSorter = new MergeSorter();
            Sorter shellSorter = new ShellSorter();

            Stopwatch selectionStopwatch = new Stopwatch();
            Stopwatch mergeStopwatch = new Stopwatch();
            Stopwatch shellStopwatch = new Stopwatch();

            selectionStopwatch.Start();
            selectionSorter.Sort();
            selectionStopwatch.Stop();

            mergeStopwatch.Start();
            mergeSorter.Sort();
            mergeStopwatch.Stop();

            shellStopwatch.Start();
            shellSorter.Sort();
            shellStopwatch.Stop();

            Console.WriteLine("Execution time for Selection Sort: " + selectionStopwatch.ElapsedMilliseconds + " milliseconds");
            Console.WriteLine("Execution time for Merge Sort: " + mergeStopwatch.ElapsedMilliseconds + " milliseconds");
            Console.WriteLine("Execution time for Shell Sort: " + shellStopwatch.ElapsedMilliseconds + " milliseconds");

            Console.ReadLine();
        }
    }


    abstract class Sorter
    {
        protected int size = 6;
        protected int[] array = { 57, 40, 7, 17, 60, 93 };

        public void Sort()
        {
            PrintArray(array);
            Console.WriteLine();

            for (int gap = GetGapValue(array); CheckGap(gap); MoveGap(ref gap))
            {
                for (int i = GetIValue(gap); CheckI(i, array); MoveI(ref i))
                {
                    int index = i;
                    int temp = array[i];
                    int j;
                    for (j = GetJValue(i); CheckJ1(j, array, gap) && CheckJ2(j, gap, array, temp); MoveJ(ref j, gap))
                    {
                        if (Condition(array, j, temp))
                        {
                            Swap(array, ref temp, ref index, j, gap);
                        }
                    }
                    Swap1(array, temp, index, i);
                    Swap2(array, temp, j);
                }
            }
            PrintArray(array);
            Console.WriteLine();
        }

        public void PrintArray(int[] array)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] > 9)
                {
                    Console.Write(array[i] + " ");
                }
                else
                {
                    Console.Write(array[i] + "  ");
                }
            }
        }

        protected abstract int GetGapValue(int[] array);
        protected abstract bool CheckGap(int gap);
        protected abstract void MoveGap(ref int gap);
        protected abstract int GetIValue(int gap);
        protected abstract bool CheckI(int i, int[] array);
        protected abstract void MoveI(ref int i);
        protected abstract int GetJValue(int i);
        protected abstract bool CheckJ1(int j, int[] array, int gap);
        protected abstract bool CheckJ2(int j, int gap, int[] array, int temp);
        protected abstract void MoveJ(ref int j, int gap);
        protected abstract void Swap(int[] array, ref int temp, ref int index, int j, int gap);
        protected abstract void Swap1(int[] array, int temp, int index, int i);
        protected abstract void Swap2(int[] array, int temp, int j);
        protected abstract bool Condition(int[] array, int j, int temp);
    }

    class SelectionSorter : Sorter
    {
        protected override int GetGapValue(int[] array)
        {
            return 1;
        }

        protected override bool CheckGap(int gap)
        {
            return gap > 0;
        }

        protected override void MoveGap(ref int gap)
        {
            gap /= 2;
        }

        protected override int GetIValue(int gap)
        {
            return gap - 1;
        }

        protected override bool CheckI(int i, int[] array)
        {
            return i < array.Length - 1;
        }

        protected override void MoveI(ref int i)
        {
            i++;
        }

        protected override int GetJValue(int i)
        {
            return i + 1;
        }

        protected override bool CheckJ1(int j, int[] array, int gap)
        {
            return j < array.Length;
        }

        protected override bool CheckJ2(int j, int gap, int[] array, int temp)
        {
            return true;
        }

        protected override void MoveJ(ref int j, int gap)
        {
            j++;
        }

        protected override void Swap(int[] array, ref int temp, ref int index, int j, int gap)
        {
            temp = array[j];
            index = j;
        }

        protected override void Swap1(int[] array, int temp, int index, int i)
        {
            array[index] = array[i];
            array[i] = temp;
        }

        protected override void Swap2(int[] array, int temp, int j)
        {
            return;
        }

        protected override bool Condition(int[] array, int j, int temp)
        {
            return temp > array[j];
        }
    }

    class MergeSorter : Sorter
    {
        protected override int GetGapValue(int[] array)
        {
            // Not used in Merge Sort
            return 0;
        }

        protected override bool CheckGap(int gap)
        {
            // Not used in Merge Sort
            return false;
        }

        protected override void MoveGap(ref int gap)
        {
            // Not used in Merge Sort
        }

        protected override int GetIValue(int gap)
        {
            // Not used in Merge Sort
            return 0;
        }

        protected override bool CheckI(int i, int[] array)
        {
            // Not used in Merge Sort
            return false;
        }

        protected override void MoveI(ref int i)
        {
            // Not used in Merge Sort
        }

        protected override int GetJValue(int i)
        {
            // Not used in Merge Sort
            return 0;
        }

        protected override bool CheckJ1(int j, int[] array, int gap)
        {
            // Not used in Merge Sort
            return false;
        }

        protected override bool CheckJ2(int j, int gap, int[] array, int temp)
        {
            // Not used in Merge Sort
            return false;
        }

        protected override void MoveJ(ref int j, int gap)
        {
            // Not used in Merge Sort
        }

        protected override void Swap(int[] array, ref int temp, ref int index, int j, int gap)
        {
            // Not used in Merge Sort
        }

        protected override void Swap1(int[] array, int temp, int index, int i)
        {
            // Not used in Merge Sort
        }

        protected override void Swap2(int[] array, int temp, int j)
        {
            // Not used in Merge Sort
        }

        protected override bool Condition(int[] array, int j, int temp)
        {
            // Not used in Merge Sort
            return false;
        }
    }

    class ShellSorter : Sorter
    {
        protected override int GetGapValue(int[] array)
        {
            return array.Length / 2;
        }

        protected override bool CheckGap(int gap)
        {
            return gap > 0;
        }

        protected override void MoveGap(ref int gap)
        {
            gap /= 2;
        }

        protected override int GetIValue(int gap)
        {
            return gap;
        }

        protected override bool CheckI(int i, int[] array)
        {
            return i < array.Length;
        }

        protected override void MoveI(ref int i)
        {
            i++;
        }

        protected override int GetJValue(int i)
        {
            return i;
        }

        protected override bool CheckJ1(int j, int[] array, int gap)
        {
            return j >= gap;
        }

        protected override bool CheckJ2(int j, int gap, int[] array, int temp)
        {
            return array[j - gap] > temp;
        }

        protected override void MoveJ(ref int j, int gap)
        {
            j -= gap;
        }

        protected override void Swap(int[] array, ref int temp, ref int index, int j, int gap)
        {
            array[j] = array[j - gap];
        }

        protected override void Swap1(int[] array, int temp, int index, int i)
        {
            // Not used in Shell Sort
        }

        protected override void Swap2(int[] array, int temp, int j)
        {
            array[j] = temp;
        }

        protected override bool Condition(int[] array, int j, int temp)
        {
            // Not used in Shell Sort
            return false;
        }
    }
}