using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Field
/// </summary>
public class Field : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }

    public Field(DynamicRecord form)
    {

    }
}