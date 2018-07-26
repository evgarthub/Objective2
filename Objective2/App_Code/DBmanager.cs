using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebMatrix.Data;

/// <summary>
/// Summary description for DBmanager
/// </summary>
public class DBmanager
{
    public Database DB { get; set; }

    public DBmanager()
    {
        this.DB = Database.Open("StarterSite");
    }

    public IEnumerable<Job> ReadData()
    {
        var command = "SELECT * FROM [Jobs]";
        var data = DB.Query(command);

        foreach (var item in data)
        {
            yield return new Job((DynamicRecord)item);
        }
    }

    public IEnumerable<Job> ReadData(string filter)
    {
        var command = "SELECT * FROM [Jobs] WHERE Title=@0 OR Category=@0 OR Field=@0 OR Education=@0";
        var data = DB.Query(command, filter);

        foreach (var item in data)
        {
            yield return new Job((DynamicRecord)item);
        }
    }

    public Job GetById(string id)
    {
        string command = "SELECT * FROM [Jobs] WHERE Id=@0";
        var item = DB.QuerySingle(command, id);
        return new Job(((DynamicRecord)item));
    }

    public void WriteData(Job job)
    {
        var command = "INSERT INTO [Jobs] ([Title],[SalaryAvarage],[English],[Category],[Field],[Keywords],[Education]) VALUES(@0, @1, @2, @3, @4, @5, @6)";
        var data = DB.Query(command, job.JobTitle, job.JobSalary, job.JobEnglish, job.JobCategory, job.JobField, job.JobKeywords, job.JobEducation);
    }

    public void UpdateData(Job job, string id)
    {
        var command = "UPDATE [Jobs] SET [Title] = @0,[SalaryAvarage] = @1,[English] = @2,[Category] = @3,[Field] = @4,[Keywords] = @5,[Education] = @6 WHERE Id = @7";
        var data = DB.Query(command, job.JobTitle, job.JobSalary, job.JobEnglish, job.JobCategory, job.JobField, job.JobKeywords, job.JobEducation, id);
    }

    public void DeleteData(string id)
    {
        string command = "DELETE FROM [Jobs] WHERE Id=@0";
        var item = DB.QuerySingle(command, id);
    }
}