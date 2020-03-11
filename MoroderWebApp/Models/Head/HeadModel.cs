using Kraftwerk.ValueObjects.Head;
using Moroder.Business.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoroderWebApp.Models.Head
{
    public class HeadModel
    {
        public HeadRotation HeadRotation { get; set; }
        public string HeadRotationDescription => HeadRotation.GetDescription();
        public HeadInclination HeadInclination { get; set; }
        public string HeadInclinationDescription => HeadInclination.GetDescription();
    }
}
