using System;
using WebMatrix.Data;


public class Category : IEntity
{
    public Category(DynamicRecord form)
    {
        this.Id = Convert.ToInt32(form["Id"]);
        this.Title = (string)form["Title"];
    }

    public int Id { get; set; }
    public string Title { get; set; }
}