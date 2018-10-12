using DataLayer;
using System;

namespace HomeIO.Models.Entities
{
    public class Tariff : IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Unit { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public int SourceId { get; set; }
        public bool HasSourceId => SourceId != null;
    }
}