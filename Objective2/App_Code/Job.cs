using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebMatrix.Data;

/// <summary>
/// Summary description for DBmanager
/// </summary>
public class Job : IEntity
{
    public string JobTitle { get; set; }
    public int JobSalary { get; set; }
    public bool JobEnglish { get; set; }
    public string JobCategory { get; set; }
    public Field JobField { get; set; }
    public int JobFieldId { get; set; }
    public string JobEducation { get; set; }
    public string JobKeywords { get; set; }
    public int Id { get; set; }

    public Job(NameValueCollection form)
    {
        this.JobTitle = form["job_title"];
        this.JobSalary = Convert.ToInt32(form["job_salary"]);
        this.JobEnglish = Convert.ToBoolean(form["job_english"]);
        this.JobCategory = form["job_category"];
        this.JobFieldId = Convert.ToInt32(form["job_field"]);
        this.JobEducation = form["job_education"];
        this.JobKeywords = form["job_keywords"];
        this.JobField = new Field(JobFieldId);
    }

    public Job(DynamicRecord form)
    {
        this.JobTitle = (string)form["Title"];
        this.JobSalary = Convert.ToInt32(form["SalaryAvarage"]);
        this.JobEnglish = Convert.ToBoolean(form["English"]);
        this.JobCategory = (string)form["Category"];
        this.JobFieldId = Convert.ToInt32(form["FieldId"]);
        this.JobEducation = (string)form["Education"];
        this.JobKeywords = (string)form["Keywords"];
        this.Id = Convert.ToInt32(form["Id"]);
        this.JobField = new Field(JobFieldId);
    }
}