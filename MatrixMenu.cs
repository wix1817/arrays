using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace arrays
{
    internal class MatrixMenu : IMenu
    {
        public static void Start()
        {
            DrawRule("Filling");

            var rows = AnsiConsole.Ask<Int32>("[green]Enter the number of rows: [/]");
            var cols = AnsiConsole.Ask<Int32>("[green]Enter the number of columns: [/]");

            Matrix matrix = new Matrix(rows, cols);

            var fillingOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select matrix [green]filling[/] option")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to select filling method)[/]")
                    .AddChoices(new[] {
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
                        matrix.ItemFill(i, j, AnsiConsole.Ask<Int32>($"[green]Enter [{i},{j}]item: [/]"));
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    AnsiConsole.Markup($"{matrix.GetElement(i, j)} \t");
                }
                AnsiConsole.MarkupLine("");
            }

            var sortOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select [green]action[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to select filling method)[/]")
                    .AddChoices(new[] {
                        "1: Find the number of positive/negative numbers in the matrix",
                        "2: Sorting matrix elements line by line (in two directions)",
                        "3: Inversion of matrix elements line by line"
                    }));

            switch (sortOption.First())
            {
                case '1':
                {
                    AnsiConsole.MarkupLine($"Number of positive elements{matrix.PositiveQuantity()}");
                    AnsiConsole.MarkupLine($"Number of negative elements{matrix.NegativeQuantity()}");
                        break;
                }
                case '2':
                {
                    break;
                }
                case '3':
                {
                    break;
                }
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
