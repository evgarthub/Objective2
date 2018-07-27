using WebMatrix.Data;

/// <summary>
/// Summary description for RepositoryConnection
/// </summary>
public class RepositoryConnection
{
    public Database DB { get; set; }

    public RepositoryConnection()
    {
        this.DB = Database.Open("StarterSite");
    }
}