using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drogo.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public bool IsInUse { get; set; }
        public double HourlyRate { get; set; }
        public DateTime? StartedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
