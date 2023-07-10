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

        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }

        public Service Service { get; set; }

        public int ServiceId { get; set; }

        public Appointment Appointment { get; set; }

        public int AppointmentId { get; set; }

        public int Mechanic { get; set; }
    }
}
