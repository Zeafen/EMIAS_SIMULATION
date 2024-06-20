using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequests.Models;
public partial class Appointment
{
    public int? IdAppointment { get; set; }

    public long? Oms { get; set; }

    public int IdDoctor { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppoinmentTime { get; set; }

    public int? IdStatus { get; set; }
}