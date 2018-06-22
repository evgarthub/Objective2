using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBmanager
/// </summary>
public class DBmanager
{
    public string JobTitle { get; set; }
    public int JobSalary { get; set; }
    public bool JobEnglish { get; set; }
    public string JobCategory { get; set; }
    public string JobField { get; set; }
    public string JobEducation { get; set; }

    public DBmanager(NameValueCollection form)
    {
        this.JobTitle = form["job_title"];
        this.JobSalary = Convert.ToInt32(form["job_salary"]);
        this.JobEnglish = Convert.ToBoolean(form["job_english"]);
        this.JobCategory = form["job_category"];
        this.JobField = form["job_field"];
        this.JobEducation = form["job_education"];
    }

}