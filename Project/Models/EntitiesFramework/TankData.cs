using System;
using System.Collections.Generic;

namespace Project.Models.EntitiesFramework
{
    public partial class TankData
    {
        public int Id { get; set; }
        public int? IdTank { get; set; }
        public string IdFormTankMapping { get; set; }
        public string Data { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Tank IdTankNavigation { get; set; }
    }
}
