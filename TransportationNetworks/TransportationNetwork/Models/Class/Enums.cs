using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TransportationNetwork.Models.Class
{
    public enum VehicleType
    {
        ///<summary>Araba</summary>
        [Description("Araba")]
        Car = 1,
        ///<summary>Otobüs</summary>
        [Description("Otobüs")]
        Bus = 2,
        ///<summary>Tekne</summary>
        [Description("Tekne")]
        Boat = 3
    }

    public enum VehicleColor
    {
        ///<summary>Kırmızı</summary>
        [Description("Kırmızı")]
        Red = 1,
        ///<summary>Mavi</summary>
        [Description("Mavi")]
        Blue = 2,
        ///<summary>Siyah</summary>
        [Description("Siyah")]
        Black = 3,
        ///<summary>Beyaz</summary>
        [Description("Beyaz")]
        White = 4,
        ///<summary>Yeşil</summary>
        [Description("Yeşil")]
        Green =5
    }
}
