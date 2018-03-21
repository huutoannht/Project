using System;
using System.Collections.Generic;

namespace Project.Models.EntitiesFramework
{
    public partial class TankFormMapping
    {
        public int Id { get; set; }
        public int? IdTank { get; set; }
        public int? IdForm { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Form IdFormNavigation { get; set; }
        public Tank IdTankNavigation { get; set; }
    }
}
