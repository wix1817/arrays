using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace arrays
{
    public class ApplicationMenu : IMenu
    { 
        public static void Start()
        {
            DrawRule("Arrays");
            MatrixMenu.Start();
            var rows = AnsiConsole.Ask<Int32>("[green]Enter the number of rows: [/]");
            var cols = AnsiConsole.Ask<Int32>("[green]Enter the number of columns: [/]");

            var array = new Matrix(rows, cols);
            //var array = new int[rows, cols];

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        AnsiConsole.Markup($"{array[i, j]} \t");
            //    }
            //    AnsiConsole.MarkupLine("");
            //}

            ////Найти количество положительных отрицательных чисел в матрице
            //int positive = 0;
            //int negative = 0;
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        if (array[i, j] < 0)
            //        {
            //            negative++;
            //        }
            //        else if (array[i, j] > 0)
            //        {
            //            positive++;
            //        }
            //    }
            //}
            //AnsiConsole.MarkupLine("Positive = {0}, Negative = {1}", positive, negative);

            ////Сортировка элементов матрицы построчно (в двух направлениях)

            ////от меньшего к большему
            //for (int i = 0; i < rows; i++)
            //{
            //    var temp = 0;
            //    for (int x = 0; x < cols; x++)
            //    {
            //        for (int y = 0; y < cols - 1; y++)
            //        {
            //            if ((array[i, y] > array[i, y + 1]))
            //            {
            //                temp = array[i, y];
            //                array[i, y] = array[i, y + 1];
            //                array[i, y + 1] = temp;
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        AnsiConsole.Markup($"{array[i, j]} \t");
            //    }
            //    AnsiConsole.MarkupLine("");
            //}

            ////от большего к меньшему
            //for (int i = 0; i < rows; i++)
            //{
            //    var temp = 0;
            //    for (int x = 0; x < cols; x++)
            //    {
            //        for (int y = 0; y < cols - 1; y++)
            //        {
            //            if ((array[i, y] < array[i, y + 1]))
            //            {
            //                temp = array[i, y];
            //                array[i, y] = array[i, y + 1];
            //                array[i, y + 1] = temp;
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        AnsiConsole.Markup($"{array[i, j]} \t");
            //    }
            //    AnsiConsole.MarkupLine("");
            //}

            ////инверсия элементов построчно

            ////преобразование из двумерного в зубчатый
            //int[][] zub = new int[cols][];
            //for (int i = 0; i < cols; i++)
            //{
            //    zub[i] = new int[rows];
            //    for (int j = 0; j < rows; j++)
            //    {
            //        zub[i][j] = array[i,j];
            //    }
            //}

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        AnsiConsole.Markup($"{zub[i][j]} \t");
            //    }
            //    AnsiConsole.MarkupLine("");
            //}

            //инверсия построчно
            //if (rows % 2 == 0)
            //{
            //    var temp = new int[rows];
            //    var incr = 1;
            //    for (int i = 0; i < rows / 2; i++)
            //    {
            //        temp = zub[i];
            //        zub[i] = zub[rows - incr];
            //        zub[rows - incr] = temp;
            //        incr++;
            //    }
            //}
            //else
            //{
            //    var temp = new int[rows];
            //    var incr = 1;
            //    for (int i = 0; i < (cols - 1) / 2; i++)
            //    {
            //        temp = zub[i];
            //        zub[i] = zub[rows - incr];
            //        zub[rows - incr] = temp;
            //        incr++;
            //    }
            //}

            //var outputMatrix = new int[array.GetLength(0), array.GetLength(1)];
            //var z = 0;
            //for (int i = array.GetLength(0) - 1; i >= 0; i--)
            //{
            //    var y = 0;
            //    for (int j = 0; j < array.GetLength(1); j++)
            //    {
            //        outputMatrix[z, y] = array[i, j];
            //        y++;
            //    }
            //    z++;
            //}


            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        AnsiConsole.Markup($"{outputMatrix[i, j]} \t");
            //    }
            //    AnsiConsole.MarkupLine("");
            //}

        }

        public static void DrawRule(string ruleName)
        {
            var rule = new Rule($"[red]{ruleName}[/]");
            rule.Centered();
            AnsiConsole.Write(rule);
        }
    }

    
}
