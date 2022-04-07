using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportationNetwork.Models.Class
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public VehicleColor Color { get; set; }
        public int? SturdyTyre { get; set; }
        public bool? HeadLight { get; set; }
    }
}
