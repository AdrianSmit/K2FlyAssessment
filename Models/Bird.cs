using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static K2FlyAssessment.Common.Enums;

namespace K2FlyAssessment.Models
{
    public partial class Bird
    {
        public BirdState birdState { get; set; }
        public List<Flower> flower { get; set; }
    }
}
