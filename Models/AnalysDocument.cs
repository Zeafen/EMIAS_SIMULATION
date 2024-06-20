using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequests.Models;
public partial class AnalysDocument
{
    public int? IdAnalys { get; set; }

    public int IdAppointmentDocument { get; set; }

    public string Name { get; set; } = null!;

    public string Rtf { get; set; } = null!;
}