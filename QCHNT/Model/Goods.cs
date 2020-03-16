using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Goods
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string GoodsName { get; set; }
        public string Print { get; set; }
        public DateTime? Date { get; set; }
    }
}
