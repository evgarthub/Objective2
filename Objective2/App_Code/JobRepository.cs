﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebMatrix.Data;

/// <summary>
/// Summary description for DBmanager
/// </summary>
public class JobRepository : RepositoryConnection, IRepository<Job>
{

    public IEnumerable<Job> FindAll()
    {
        var command = "SELECT Jobs.*, Field.Title AS Field FROM[Jobs] JOIN[Field] ON Jobs.FieldId = Field.Id";
        var data = DB.Query(command);

        foreach (var item in data)
        {
            yield return new Job((DynamicRecord)item);
        }
    }

    public IEnumerable<Job> FindAllFormated()
    {
        var command = "SELECT Jobs.*, Field.Title AS Field, Category.Title AS Category FROM[Jobs] LEFT OUTER JOIN[Field] ON Jobs.FieldId = Field.Id LEFT OUTER JOIN[Category] ON Jobs.CategoryId = Category.Id";
        var data = DB.Query(command);

        foreach (var item in data)
        {
            yield return new JobResults((DynamicRecord)item);
        }
    }

    public IEnumerable<Job> Find(string filter)
    {
        var command = "SELECT * FROM [Jobs] WHERE Title=@0 OR Category=@0 OR FieldId=@0 OR Education=@0";
        var data = DB.Query(command, filter);

        foreach (var item in data)
        {
            yield return new Job((DynamicRecord)item);
        }
    }

    public Job FindById(int Id)
    {
        string command = "SELECT Jobs.*, Field.Title AS Field FROM[Jobs] JOIN[Field] ON Jobs.FieldId = Field.Id WHERE Jobs.Id=@0";
        var item = DB.QuerySingle(command, Id);
        return new Job(((DynamicRecord)item));
    }

    public void Add(Job job)
    {
        var command = "INSERT INTO [Jobs] ([Title],[SalaryAvarage],[English],[CategoryId],[FieldId],[Keywords],[Education]) VALUES(@0, @1, @2, @3, @4, @5, @6)";
        var data = DB.Query(command, job.Title, job.Salary, job.English, job.CategoryId, job.FieldId, job.Keywords, job.Education);
    }

    public void Update(Job job) {
        var command = "UPDATE [Jobs] SET [Title] = @0,[SalaryAvarage] = @1,[English] = @2,[CategoryId] = @3,[FieldId] = @4,[Keywords] = @5,[Education] = @6 WHERE Id = @7";
        var data = DB.Query(command, job.Title, job.Salary, job.English, job.CategoryId, job.FieldId, job.Keywords, job.Education, job.Id);
    }

    public void Delete(Job job)
    {
        string command = "DELETE FROM [Jobs] WHERE Id=@0";
        DB.Query(command, job.Id);
    }

    public void Delete(string id)
    {
        string command = "DELETE FROM [Jobs] WHERE Id=@0";
        DB.Query(command, id);
    }
}