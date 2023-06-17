using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace arrays
{
    internal class MatrixMenu
    {
        public static void Start()
        {
            var isTryAgain = false;
            do
            {
                AnsiConsole.Clear();
                var rule = new Rule("[red]Arrays[/]");
                AnsiConsole.Write(rule);

                AnsiConsole.MarkupLine("Enter [green]size[/] of matrix: ");
                var rows = AnsiConsole.Ask<Int32>("[green]Enter the number of rows: [/]");
                var cols = AnsiConsole.Ask<Int32>("[green]Enter the number of columns: [/]");

                Matrix matrix = new Matrix(rows, cols);

                rule.Title = "[red]Filling[/]";
                AnsiConsole.Write(rule);

                var fillingOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select matrix [green]filling[/] option")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to select filling method)[/]")
                        .AddChoices(new[]
                        {
                            "Random", "Manual"
                        }));
                if (fillingOption == "Random")
                {
                    matrix.RandomFill();
                }
                else
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            matrix.ItemFill(i, j, AnsiConsole.Ask<Int32>($"Enter [green]{i},{j}[/] item: "));
                        }
                    }
                }

                DrawMatrix(rows, cols, matrix);

                rule.Title = "[red]Options[/]";
                AnsiConsole.Write(rule);

                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select [green]action[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to select filling method)[/]")
                        .AddChoices(new[]
                        {
                            "1: Find the number of positive/negative numbers in the matrix",
                            "2: Sorting matrix elements line by line (in two directions)",
                            "3: Inversion of matrix elements line by line"
                        }));

                switch (option.First())
                {
                    case '1':
                    {
                        AnsiConsole.MarkupLine($"Number of positive elements: {matrix.PositiveQuantity()}");
                        AnsiConsole.MarkupLine($"Number of negative elements: {matrix.NegativeQuantity()} \n");
                        break;
                    }
                    case '2':
                    {
                        DrawMatrix(rows, cols, matrix, "Origin");

                        var sortType = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("Select type of [green]sort[/]")
                                .PageSize(10)
                                .MoreChoicesText("[grey](Move up and down to select sort type)[/]")
                                .AddChoices(new[] {
                                    "1: BubbleSort from big to small",
                                    "2: BubbleSort from small to big",
                                    "3: Counting sort from small to big",
                                    "4: Counting sort from big to small"
                                })).First();

                        matrix.Sort((int)Char.GetNumericValue(sortType));
                        DrawMatrix(rows, cols, matrix, "Sorted");
                        break;
                    }
                    case '3':
                    {
                        DrawMatrix(rows, cols, matrix, "Origin");
                        matrix.InverseLineByLine();
                        DrawMatrix(rows, cols, matrix, "Inverse");
                        break;
                    }
                }

                if (!AnsiConsole.Confirm("[green]Want to try again with new matrix? [/]"))
                {
                    AnsiConsole.MarkupLine("Ok... :(");
                    isTryAgain = false;
                }
                else isTryAgain = true;
                
            } while (isTryAgain);

        }

        public static void DrawMatrix(int rows, int cols, Matrix matrix)
        {
            AnsiConsole.MarkupLine(GetMatrixInText(rows, cols, matrix));
        }

        public static void DrawMatrix(int rows, int cols, Matrix matrix, string title)
        {
            AnsiConsole.MarkupLine(title);
            AnsiConsole.MarkupLine(GetMatrixInText(rows, cols, matrix));
        }

        public static string GetMatrixInText(int rows, int cols, Matrix matrix)
        {
            StringBuilder matrixInText = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrixInText.Append($"{matrix.GetElement(i, j)} \t");
                }

                matrixInText.Append("\n");
            }
            return matrixInText.ToString();
        }

    }
}
