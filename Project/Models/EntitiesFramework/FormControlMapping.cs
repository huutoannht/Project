using System;
using System.Collections.Generic;

namespace Project.Models.EntitiesFramework
{
    public partial class FormControlMapping
    {
        public int Id { get; set; }
        public int? IdForm { get; set; }
        public int? IdControl { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
