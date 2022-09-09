// Documentation at: https://spectreconsole.net/

using ConsoleApp.Adapters;
using ConsoleApp.Game;
using Spectre.Console;

namespace ConsoleApp;

public static class Program
{
    public static void Main()
    {
        AnsiConsole.MarkupLine("Find [bold red]the[/] path...");

        StartGame();

        ShowHallOfFame();
    }
    
    private static void StartGame()
    {
        var game = new Game.Game(new CLIInteractor());

        do
        {
            var state = game.Loop();

            if (state == GameState.Won)
            {
                AnsiConsole.MarkupLine("Congratulations you [bold]won![/]");
                break;
            }

            if (state == GameState.Colder)
            {
                AnsiConsole.MarkupLine("Colder...");
            }
            else if (state == GameState.Warmer)
            {
                AnsiConsole.MarkupLine("Warmer...");
            }
        } while (true);
    }
    
    // fake, only for the purpose of UI
    private static void ShowHallOfFame()
    {
        AnsiConsole
            .Status()
            .Start("Initializing person list...", ctx =>
            {
                ctx.Status("Processing downloaded information...");
                ctx.Spinner(Spinner.Known.Star);
                ctx.SpinnerStyle(Style.Parse("green"));
                Thread.Sleep(1000);


                ctx.Status("Fetching information from shared register...");
                Thread.Sleep(1000);

                AnsiConsole.MarkupLine("Person list initialized successfully!");
            });

        var table = new Table();
        table.AddColumns(
            new TableColumn("[bold]Name[/]"),
            new TableColumn("[bold]Surname[/]"),
            new TableColumn("[bold]Age[/]"));

        foreach (var person in Person.ExampleData)
        {
            table.AddRow(person.Name, person.Surname, person.Age.ToString());
        }

        AnsiConsole.Write(table);
    }
}