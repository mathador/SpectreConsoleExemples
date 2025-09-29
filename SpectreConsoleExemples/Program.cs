using Spectre.Console;

AnsiConsole.Write(new Markup("[bold yellow]Hello[/] [red]World![/]"));
AnsiConsole.WriteLine();


var table = new Table();
table.AddColumn(new TableColumn(new Markup("[yellow]Foo[/]")));
table.AddColumn(new TableColumn("[blue]Bar[/]"));
AnsiConsole.Write(table);


AnsiConsole.MarkupLine("[link=https://spectreconsole.net]Spectre Console Documentation[/]");