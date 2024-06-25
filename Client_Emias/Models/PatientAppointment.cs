using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.Models
{
    public class PatientAppointment
    {
        public int? IdAppointment { get; set; }

        public long? Oms { get; set; }

        public int IdDoctor { get; set; }

        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppoinmentTime { get; set; }

        public int? IdStatus { get; set; }

        public string SurName { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Patronymic { get; set; }

        public string FullName => $"{SurName} {Name} {Patronymic}";

    }
}
