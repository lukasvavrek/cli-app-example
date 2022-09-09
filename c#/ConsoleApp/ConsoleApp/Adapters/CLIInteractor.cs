using ConsoleApp.Game;
using Spectre.Console;

namespace ConsoleApp.Adapters;

// ReSharper disable once IdentifierTypo
// ReSharper disable once InconsistentNaming
public class CLIInteractor : IDirectionSelector
{
    public Direction GetNextDirection()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Where do you want to go?")
                .AddChoices(new[]
                {
                    "Up", "Down", "Left", "Right"
                }));

        return Enum.Parse<Direction>(choice);
    }
}