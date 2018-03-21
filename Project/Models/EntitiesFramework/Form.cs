using System;
using System.Collections.Generic;

namespace Project.Models.EntitiesFramework
{
    public partial class Form
    {
        public Form()
        {
            TankFormMapping = new HashSet<TankFormMapping>();
        }

        public int Id { get; set; }
        public string NameForm { get; set; }
        public int? IdControl { get; set; }
        public string NameControl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string NameField { get; set; }

        public ICollection<TankFormMapping> TankFormMapping { get; set; }
    }
}
