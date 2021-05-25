using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static K2FlyAssessment.Common.Enums;

namespace K2FlyAssessment.Models
{
    public partial class Flower
    {
        public FlowerState flowerState { get; set; }
        public Color color { get; set; }
        public DateTime openingTime { get; set; }
    }
}
