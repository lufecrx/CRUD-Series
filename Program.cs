using CRUD_Series.src;

SerieRepository repository = new SerieRepository();

string option = OptionUser();

while (option.ToUpper() != "X")
{
    switch (option)
    {
        case "1":
            ListSeries();
            break;
        case "2":
            InsertSerie();
            break;
        case "3":
            UpdateSerie();
            break;
        case "4":
            RemoveSerie();
            break;
        case "5":
            ViewSerie();
            break;
        case "C":
            Console.Clear();
            break;

        default:
            Console.WriteLine("Error");
            break;
    }

    option = OptionUser();
}

void ListSeries()
{
    Console.WriteLine("List series");

    var list = repository.Array();

    if (list.Count == 0)
    {
        Console.WriteLine("Empty");
        return;
    }

    foreach (var serie in list)
    {
        var deletedSerie = serie.returnDeleted();
        if (!deletedSerie)
        {
            Console.WriteLine("#ID {0}: - {1}", serie.returnId(), serie.returnTitle());
        };
    }
}

void InsertSerie()
{
    Console.WriteLine("Insert new serie");

    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
    foreach (int i in Enum.GetValues(typeof(GenreEnum)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GenreEnum), i));
    }
    Console.Write("Select Genre: ");
    int entryGenre = int.Parse(Console.ReadLine());

    Console.Write("Enter the series title: ");
    string entryTitle = Console.ReadLine();

    Console.Write("Enter the series release year: ");
    int entryYear = int.Parse(Console.ReadLine());

    Console.Write("Enter the series description: ");
    string entryDescription = Console.ReadLine();

    SerieClass newSerie = new SerieClass(Id: repository.NextId(),
                                Genre: (GenreEnum)entryGenre,
                                Title: entryTitle,
                                Year: entryYear,
                                Description: entryDescription);

    repository.Insert(newSerie);
}

void UpdateSerie()
{
    Console.WriteLine("Update series");
    Console.WriteLine("Enter the ID series: ");
    int indexSerie = int.Parse(Console.ReadLine());


    foreach (int i in Enum.GetValues(typeof(GenreEnum)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GenreEnum), i));
    }
    Console.Write("Select Genre: ");
    int entryGenre = int.Parse(Console.ReadLine());

    Console.Write("Enter the series title: ");
    string entryTitle = Console.ReadLine();

    Console.Write("Enter the series release year: ");
    int entryYear = int.Parse(Console.ReadLine());

    Console.Write("Enter the series description: ");
    string entryDescription = Console.ReadLine();

    SerieClass updateSerie = new SerieClass(Id: indexSerie,
                                Genre: (GenreEnum)entryGenre,
                                Title: entryTitle,
                                Year: entryYear,
                                Description: entryDescription);

    repository.Update(indexSerie, updateSerie);
}

void RemoveSerie()
{
    Console.WriteLine("Remove series");
    Console.WriteLine("Enter the ID series: ");
    int indexSerie = int.Parse(Console.ReadLine());

    repository.Delete(indexSerie);
}

void ViewSerie()
{
    ListSeries();
    Console.Write("Enter the ID series: ");
    int indexSerie = int.Parse(Console.ReadLine());

    var serie = repository.ReturnForId(indexSerie);

    Console.WriteLine(serie);
}

static string OptionUser()
{
    Console.WriteLine();
    Console.WriteLine("Welcome to CRUD Series!!");
    Console.WriteLine("Enter the desired option:");

    Console.WriteLine("1- List series");
    Console.WriteLine("2- Insert new serie");
    Console.WriteLine("3- Update serie");
    Console.WriteLine("4- Remove serie");
    Console.WriteLine("5- View serie");
    Console.WriteLine("C- Clean screen");
    Console.WriteLine("X- Exit");

    string option = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return option;

}