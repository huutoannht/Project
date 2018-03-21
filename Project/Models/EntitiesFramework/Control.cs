using System;
using System.Collections.Generic;

namespace Project.Models.EntitiesFramework
{
    public partial class Control
    {
        public int Id { get; set; }
        public string NameControl { get; set; }
        public bool? IsRequired { get; set; }
        public string Type { get; set; }
        public string NameChild { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
