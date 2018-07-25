using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebMatrix.Data;

/// <summary>
/// Summary description for DBmanager
/// </summary>
public class Job
{
    public string JobTitle { get; set; }
    public int JobSalary { get; set; }
    public bool JobEnglish { get; set; }
    public string JobCategory { get; set; }
    public string JobField { get; set; }
    public string JobEducation { get; set; }
    public string JobKeywords { get; set; }
    public int JobId { get; set; }

    public Job(NameValueCollection form)
    {
        this.JobTitle = form["job_title"];
        this.JobSalary = Convert.ToInt32(form["job_salary"]);
        this.JobEnglish = Convert.ToBoolean(form["job_english"]);
        this.JobCategory = form["job_category"];
        this.JobField = form["job_field"];
        this.JobEducation = form["job_education"];
        this.JobKeywords = form["job_keywords"];
    }

    public Job(DynamicRecord form)
    {
        this.JobTitle = (string)form["Title"];
        this.JobSalary = Convert.ToInt32(form["SalaryAvarage"]);
        this.JobEnglish = Convert.ToBoolean(form["English"]);
        this.JobCategory = (string)form["Category"];
        this.JobField = (string)form["Field"];
        this.JobEducation = (string)form["Education"];
        this.JobKeywords = (string)form["Keywords"];
        this.JobId = Convert.ToInt32(form["Id"]);
    }
}