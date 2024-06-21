using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.Models;
public partial class AppointmentDocument
{
    public int? IdAppointment { get; set; }

    public int IdAppointmentDocument { get; set; }

    public string Name { get; set; } = null!;

    public string Rtf { get; set; } = null!;
}