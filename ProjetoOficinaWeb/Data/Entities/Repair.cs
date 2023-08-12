using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Repair : IEntity
    {
        public int Id { get; set; }

        public string  Vehicle { get; set; }

        public string  VehicleId { get; set; }

        public string Service { get; set; }

        public string ServiceId { get; set; }

        public string  Appointment { get; set; }

        public string AppointmentId { get; set; }

        public string Mechanic { get; set; }
    }
}
