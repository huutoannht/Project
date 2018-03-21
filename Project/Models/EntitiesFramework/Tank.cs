using System;
using System.Collections.Generic;

namespace Project.Models.EntitiesFramework
{
    public partial class Tank
    {
        public Tank()
        {
            TankData = new HashSet<TankData>();
            TankFormMapping = new HashSet<TankFormMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<TankData> TankData { get; set; }
        public ICollection<TankFormMapping> TankFormMapping { get; set; }
    }
}
