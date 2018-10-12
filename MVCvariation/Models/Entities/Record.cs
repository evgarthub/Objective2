using DataLayer;
using System;

namespace HomeIO.Models.Entities
{
    public class Record : IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int CurrentValue { get; set; }
        public DateTime Date { get; set; }
    }
}