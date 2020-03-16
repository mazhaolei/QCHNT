using System;
using System.Collections.Generic;

namespace QCHNT.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Area { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
    }
}
