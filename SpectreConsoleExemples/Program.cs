using Spectre.Console;

var table = new Table().Centered();

AnsiConsole.Live(table)
    .Start(ctx =>
    {
        table.AddColumn("Foo");
        ctx.Refresh();
        Thread.Sleep(1000);

        table.AddColumn("Bar");
        ctx.Refresh();
        Thread.Sleep(1000);
    });

table = new Table().Centered();

await AnsiConsole.Live(table)
    .StartAsync(async ctx =>
    {
        table.AddColumn("Foo");
        ctx.Refresh();
        await Task.Delay(1000);

        table.AddColumn("Bar");
        ctx.Refresh();
        await Task.Delay(1000);
    });

table = new Table().Centered();
table.Title("[yellow]Star Wars Movies[/]");

table.AddColumn("Release date");
table.AddColumn("Title");
table.AddColumn(new TableColumn("Budget").RightAligned());
table.AddColumn(new TableColumn("[green]Opening Weekend[/]").RightAligned());
table.AddColumn(new TableColumn("[blue]Box office[/]").RightAligned());

var rows = new (string, string, string, string, string)[]
{
    ("May 25, 1977", "Star Wars Ep. IV", "$11,000,000", "$1,554,475", "$775,398,007"),
    ("May 21, 1980", "Star Wars Ep. V", "$18,000,000", "$4,910,483", "$547,969,004"),
    ("May 25, 1983", "Star Wars Ep. VI", "$32,500,000", "$23,019,618", "$475,106,177"),
    ("May 19, 1999", "Star Wars Ep. I", "$115,000,000", "$64,810,870", "$1,027,044,677"),
    ("May 16, 2002", "Star Wars Ep. II", "$115,000,000", "$80,027,814", "$649,436,358"),
    ("May 19, 2005", "Star Wars Ep. III", "$113,000,000", "$108,435,841", "$850,035,635"),
    ("Dec 18, 2015", "Star Wars Ep. VII", "$245,000,000", "$247,966,675", "$2,068,223,624"),
    ("Dec 15, 2017", "Star Wars Ep. VIII", "$317,000,000", "$220,009,584", "$1,333,539,889"),
    ("Dec 20, 2019", "Star Wars Ep. IX", "$245,000,000", "$177,383,864", "$1,074,114,248"),
};

AnsiConsole.Live(table)
    .AutoClear(false) // garde le tableau final affiché
    .Overflow(VerticalOverflow.Ellipsis)
    .Cropping(VerticalOverflowCropping.Bottom)
    .Start(ctx =>
    {
        // Ajout progressif des lignes
        foreach (var row in rows)
        {
            table.AddRow(row.Item1, row.Item2, row.Item3, row.Item4, row.Item5);
            ctx.Refresh();
            Thread.Sleep(400);
        }

        // Ligne vide
        table.AddEmptyRow();
        ctx.Refresh();
        Thread.Sleep(400);

        // Totaux
        table.AddRow("", "",
            "[red]$1,633,000,000[/]",
            "[green]$928,119,224[/]",
            "[blue]$10,318,030,576[/]");
        ctx.Refresh();
        Thread.Sleep(600);

        // Légende finale
        table.Caption("[grey]THE END[/]");
        ctx.Refresh();
    });