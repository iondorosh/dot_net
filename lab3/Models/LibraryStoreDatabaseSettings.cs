namespace lab3.Models;

public class LibraryStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PersonsCollectionName { get; set; } = null!;
}
