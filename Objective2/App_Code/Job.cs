using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebMatrix.Data;

/// <summary>
/// Summary description for DBmanager
/// </summary>
public class Job : IEntity
{
    public string Title { get; set; }
    public int Salary { get; set; }
    public bool English { get; set; }
    public int CategoryId { get; set; }
    public int FieldId { get; set; }
    public string Education { get; set; }
    public string Keywords { get; set; }
    public int Id { get; set; }

    public Job(NameValueCollection form)
    {
        this.Title = form["job_title"];
        this.Salary = Convert.ToInt32(form["job_salary"]);
        this.English = Convert.ToBoolean(form["job_english"]);
        this.CategoryId = Convert.ToInt32(form["job_category"]);
        this.Education = form["job_education"];
        this.Keywords = form["job_keywords"];
        this.FieldId = Convert.ToInt32(form["job_field"]);
    }

    public Job(DynamicRecord dbdata)
    {
        this.Title = (string)dbdata["Title"];
        this.Salary = Convert.ToInt32(dbdata["SalaryAvarage"]);
        this.English = Convert.ToBoolean(dbdata["English"]);
        this.CategoryId = Convert.ToInt32(dbdata["CategoryId"]);
        this.Education = (string)dbdata["Education"];
        this.Keywords = (string)dbdata["Keywords"];
        this.Id = Convert.ToInt32(dbdata["Id"]);
        this.FieldId = Convert.ToInt32(dbdata["FieldId"]);
    }
}