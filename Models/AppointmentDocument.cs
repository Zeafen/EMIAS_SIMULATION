using System;
using System.Collections.Generic;

namespace EMIAS_API.Models;

public partial class AppointmentDocument
{
    public int? IdAppointment { get; set; }

    public int IdAppointmentDocument { get; set; }

    public string Name { get; set; } = null!;

    public string Rtf { get; set; } = null!;
}
