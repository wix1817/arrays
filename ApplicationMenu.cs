using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace arrays
{
    public class ApplicationMenu
    { 
        public static void Start()
        {
            DrawRule("Arrays");

            var rows = AnsiConsole.Ask<Int32>("[green]Enter the number of rows: [/]");
            var cols = AnsiConsole.Ask<Int32>("[green]Enter the number of columns: [/]");

            var array = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i,j] = AnsiConsole.Ask<Int32>("[green]Enter element: [/]");
                }
                AnsiConsole.MarkupLine("");
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    AnsiConsole.Markup($"{array[i, j]} \t");
                }
                AnsiConsole.MarkupLine("");
            }

            //Найти количество положительных отрицательных чисел в матрице
            int positive = 0;
            int negative = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] < 0)
                    {
                        negative++;
                    }
                    else if (array[i, j] > 0)
                    {
                        positive++;
                    }
                }
            }
            AnsiConsole.MarkupLine("");
            AnsiConsole.MarkupLine("Positive = {0}, Negative = {1}", positive, negative);
            AnsiConsole.MarkupLine("");

            //Сортировка элементов матрицы построчно (в двух направлениях)

            //от меньшего к большему
            for (int i = 0; i < rows; i++)
            {
                var temp = 0;
                for (int x = 0; x < cols; x++)
                {
                    for (int y = 0; y < cols - 1; y++)
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
            AnsiConsole.MarkupLine("From small to big");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    AnsiConsole.Markup($"{array[i, j]} \t");
                }
                AnsiConsole.MarkupLine("");
            }
            AnsiConsole.MarkupLine("");

            //от большего к меньшему
            for (int i = 0; i < rows; i++)
            {
                var temp = 0;
                for (int x = 0; x < cols; x++)
                {
                    for (int y = 0; y < cols - 1; y++)
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
            AnsiConsole.MarkupLine("From big to small");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    AnsiConsole.Markup($"{array[i, j]} \t");
                }
                AnsiConsole.MarkupLine("");
            }
            AnsiConsole.MarkupLine("");

            //инверсия элементов построчно

            var outputMatrix = new int[array.GetLength(0), array.GetLength(1)];
            var z = 0;
            for (int i = array.GetLength(0) - 1; i >= 0; i--)
            {
                var y = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    outputMatrix[z, y] = array[i, j];
                    y++;
                }
                z++;
            }

            AnsiConsole.MarkupLine("Inversion of elements line by line");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    AnsiConsole.Markup($"{outputMatrix[i, j]} \t");
                }
                AnsiConsole.MarkupLine("");
            }

        }

        public static void DrawRule(string ruleName)
        {
            var rule = new Rule($"[red]{ruleName}[/]");
            rule.Centered();
            AnsiConsole.Write(rule);
        }
    }

    
}
