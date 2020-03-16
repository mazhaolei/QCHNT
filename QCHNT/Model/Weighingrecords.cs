using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Weighingrecords
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string WeightListNumber { get; set; }
        public string CarNumber { get; set; }
        public string Icnumber { get; set; }
        public string GoodsName { get; set; }
        public double? RoughWeight { get; set; }
        public double? TareWeight { get; set; }
        public double? NetWeight { get; set; }
        public string ContractNumber { get; set; }
        public string Operator { get; set; }
        public string TareWeightTime { get; set; }
        public string RoughWeightTime { get; set; }
        public string FinishMark { get; set; }
        public string SupplyUnit { get; set; }
        public string ReceiveUnit { get; set; }
        public DateTime? InsertTime { get; set; }
        public string CarDriver { get; set; }
        public double? TotalContract { get; set; }
        public double? ContractReduction { get; set; }
        public double? ResidualContract { get; set; }
    }
}
