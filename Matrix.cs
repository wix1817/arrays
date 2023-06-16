using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays
{
    internal class Matrix
    {
        public int Rows { get; }
        public int Columns { get; }

        private readonly int[,] array;

        /// <summary>
        /// Entering the size of the matrix
        /// </summary>
        /// <param Rows="rows"></param>
        /// <param Columns="columns"></param>
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            array = new int[rows, columns];
        }

        /// <summary>
        /// Random filling of the matrix in the range (-99, 99)
        /// </summary>
        public void RandomFill()
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(-99, 99);
                }
            }
        }

        /// <summary>
        /// Manual filling of matrix elements
        /// </summary>
        /// <param FirstIndex="firstIndex"></param>
        /// <param SecondIndex="secondIndex"></param>
        /// <param Value="value"></param>
        public void ItemFill(int firstIndex, int secondIndex, int value)
        {
            array[firstIndex, secondIndex] = value;
        }

        /// <summary>
        /// Get element of matrix using indexes
        /// </summary>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        /// <returns></returns>
        public int GetElement(int firstIndex, int secondIndex)
        {
            return array[firstIndex, secondIndex];
        }

        /// <summary>
        /// Returns the number of positive elements
        /// </summary>
        /// <returns></returns>
        public int PositiveQuantity()
        {
            int positive = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (array[i, j] > 0)
                    {
                        positive++;
                    }
                }
            }

            return positive;
        }

        /// <summary>
        /// Returns the number of negative elements
        /// </summary>
        /// <returns></returns>
        public int NegativeQuantity()
        {
            int negative = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (array[i, j] < 0)
                    {
                        negative++;
                    }
                }
            }

            return negative;
        }

        /// <summary>
        /// Array sorting methods
        /// </summary>
        /// <param name="SortType"></param>
        public void Sort(int SortType)
        {
            switch (SortType)
            {
                case 0:
                {
                        for (int i = 0; i < Rows; i++)
                        {
                            var temp = 0;
                            for (int x = 0; x < Columns; x++)
                            {
                                for (int y = 0; y < Columns - 1; y++)
                                {
                                    if ((array[i, y] > array[i, y + 1]))
                                    {
                                        temp = array[i, y];
                                        array[i, y] = array[i, y + 1];
                                        array[i, y + 1] = temp;
                                    }
                                }
                            }
                        }
                        break;
                }
                case 1:
                {
                        for (int i = 0; i < Rows; i++)
                        {
                            var temp = 0;
                            for (int x = 0; x < Columns; x++)
                            {
                                for (int y = 0; y < Columns - 1; y++)
                                {
                                    if ((array[i, y] < array[i, y + 1]))
                                    {
                                        temp = array[i, y];
                                        array[i, y] = array[i, y + 1];
                                        array[i, y + 1] = temp;
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }

        public void GetTypesOfSort()
        {
            
        }

        public enum TypesOfSort
        {
            LineByLineFromLargeToSmall,
            LineByLineFromSmallToLarge
        }
    }

    
}
