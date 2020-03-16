using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class Carnumber
    {
        public int Id { get; set; }
        public int? CameraNo { get; set; }
        public string CarNumber1 { get; set; }
        public int? Flag { get; set; }
        public DateTime? Date { get; set; }
    }
}
