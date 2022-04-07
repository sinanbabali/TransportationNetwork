using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationNetwork.Models.Class;

namespace TransportationNetwork.Controllers
{

    [Route("api/data")]
    [ApiController]
    public class VehicleManagementController : ControllerBase
    {
        private readonly AppDbContext _context;
        public VehicleManagementController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>Araçları Oluşturur ve Listeyi Döner</summary>
        //http://localhost:21000/api/data/newvehicles
        [HttpGet("newvehicles")]
        public List<Vehicle> NewVehicles()
        {
            var Vehicles = new List<Vehicle>();
            if (_context.Vehicles.Count() == 0)
            {

                Vehicles.Add(new Vehicle() { Id = 1, Type = VehicleType.Car, Color = VehicleColor.Green, SturdyTyre = 4, HeadLight = true });
                Vehicles.Add(new Vehicle() { Id = 2, Type = VehicleType.Car, Color = VehicleColor.Red, SturdyTyre = 3, HeadLight = true });
                Vehicles.Add(new Vehicle() { Id = 3, Type = VehicleType.Car, Color = VehicleColor.Black, SturdyTyre = 3, HeadLight = false });
                Vehicles.Add(new Vehicle() { Id = 4, Type = VehicleType.Car, Color = VehicleColor.White, SturdyTyre = 4, HeadLight = true });
                Vehicles.Add(new Vehicle() { Id = 5, Type = VehicleType.Car, Color = VehicleColor.Red, SturdyTyre = 2, HeadLight = false });

                Vehicles.Add(new Vehicle() { Id = 6, Type = VehicleType.Bus, Color = VehicleColor.Green, SturdyTyre = 4, HeadLight = true });
                Vehicles.Add(new Vehicle() { Id = 7, Type = VehicleType.Bus, Color = VehicleColor.Red, SturdyTyre = 3, HeadLight = true });
                Vehicles.Add(new Vehicle() { Id = 8, Type = VehicleType.Bus, Color = VehicleColor.Black, SturdyTyre = 3, HeadLight = false });
                Vehicles.Add(new Vehicle() { Id = 9, Type = VehicleType.Bus, Color = VehicleColor.White, SturdyTyre = 4, HeadLight = true });


                Vehicles.Add(new Vehicle() { Id = 10, Type = VehicleType.Boat, Color = VehicleColor.Green, SturdyTyre = 4, HeadLight = true });
                Vehicles.Add(new Vehicle() { Id = 11, Type = VehicleType.Boat, Color = VehicleColor.Red, SturdyTyre = 3, HeadLight = true });
                Vehicles.Add(new Vehicle() { Id = 12, Type = VehicleType.Boat, Color = VehicleColor.Black, SturdyTyre = 4, HeadLight = false });

                _context.Vehicles.AddRange(Vehicles);
                _context.SaveChanges();
            }
            else
            {
                Vehicles = GetVehicles();
            }

            return Vehicles;
        }

        /// <summary>
        /// Sistemdeki Tüm Araçları Listeler
        /// </summary>
        //http://localhost:21000/api/data/getvehicles

        [HttpGet("getvehicles")]
        public List<Vehicle> GetVehicles()
        {
            return _context.Vehicles.ToList();
        }


        /// <summary>
        /// İstenilen Araç tipine veya rengine göre filtreleme yapmayı sağlar
        /// </summary>
        /// <param name="type">Araç Tipi</param>
        /// <param name="color">Araç Rengi</param>
        //http://localhost:21000/api/data/filtervehicles?type=1&color=3

        [HttpGet("filtervehicles")]
        public List<Vehicle> FilterVehicles(int? type = null, int? color = null)
        {
            var result = _context.Vehicles.Cast<Vehicle>().ToList();

            if (type != null)
            {
                result = result.Where(x => (int)x.Type == type).ToList();
            }

            if (color != null)
            {
                result = result.Where(x => (int)x.Color == color).ToList();
            }

            return result;
        }


        /// <summary>
        /// İstenilen Araç için özellikleri değiştirmemizi sağlar
        /// </summary>
        /// <param name="id">Araç Kimliği</param>
        /// <param name="headLight">Araç Farı Açıp kapatma true açık</param>
        /// <param name="destroyTyre">Araçda kaç Lastik patlasın :)</param>
        //http://localhost:21000/api/data/UpdateVehicle?id=3&headLight=false&destroyTyre=1

        [HttpPost("UpdateVehicle")]
        public List<Vehicle> UpdateVehicle(int id, bool headLight = true, int destroyTyre = 0)
        {
            var CurrentVehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);

            if (CurrentVehicle != null)
            {
                CurrentVehicle.HeadLight = headLight;
                CurrentVehicle.SturdyTyre = destroyTyre <= CurrentVehicle.SturdyTyre ? CurrentVehicle.SturdyTyre - destroyTyre : CurrentVehicle.SturdyTyre;
                _context.Vehicles.Update(CurrentVehicle);
                _context.SaveChanges();
            }

            return GetVehicles();
        }

        /// <summary>
        /// İstenilen Aracı kimliğine göre sorgulayıp sistemden siler
        /// </summary>
        /// <param name="id">Araç Kimliği</param>
        //http://localhost:21000/api/data/DeleteVehicle?id=3

        [HttpPost("DeleteVehicle")]
        public List<Vehicle> DeleteVehicle(int id)
        {
            var CurrentVehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);

            if (CurrentVehicle != null)
            {
                _context.Vehicles.Remove(CurrentVehicle);
                _context.SaveChanges();
            }

            return GetVehicles();
        }
    }
}
