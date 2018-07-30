using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

public class JobResults : Job
{
    public string FieldTitle { get; set; }
    public string CategoryTitle { get; set; }

    public JobResults(DynamicRecord dbdata) : base(dbdata)
    {
        this.FieldTitle = (string)dbdata["Field"];
        this.CategoryTitle = (string)dbdata["Category"];
    }
}