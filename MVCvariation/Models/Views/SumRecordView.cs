using HomeIO.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeIO.Models.Views
{
    public class SumRecordView
    {
        public double Amount { get; set; }
        public double Cost { get; set; }
        public double[] Tariff { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string Unit { get; set; }
        public RecordView PrevRecord { get; set; }
        public RecordView Record { get; set; }
        public TimeSpan Period { get; set; }
        public TimeSpan Days { get; set; }


        public SumRecordView(IList<RecordView> records)
        {
            this.Record = records[0];
            this.Period = DateTime.Now - Record.Date;
            this.Days = DateTime.Now - Record.Date;
            this.Amount = Record.CurrentValue;
            this.TypeId = Record.TypeId;

            if (records.Count > 1) {
                this.PrevRecord = records[1];
                this.Period = Record.Date - PrevRecord.Date;
                this.Amount = Record.CurrentValue - PrevRecord.CurrentValue;
            }
            
            this.TypeName = Record.TypeName;
            this.Tariff = Record.Tariff.Split(',').Select(Double.Parse).ToArray();
            
            this.Unit = Record.Unit;

            switch (TypeName.ToLower()) {
                case "electricity":
                    if (this.Amount <= 100)
                    {
                        this.Cost = this.Amount * this.Tariff[0];
                    }
                    else {
                        this.Cost = 100 * this.Tariff[0] + (this.Amount - 100) * this.Tariff[1];
                    }
                    break;
                case "maintenance":
                    this.Cost = this.Tariff[0];
                    break;
                default:
                    this.Cost = this.Tariff[0] * this.Amount;
                    break;
            }

            this.Cost = Math.Round(this.Cost, 2);
        }
    }
}