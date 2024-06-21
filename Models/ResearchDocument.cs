using System;
using System.Collections.Generic;

namespace EMIAS_API.Models;

public partial class ResearchDocument
{
    public int? IdResearch { get; set; }

    public int IdAppointmentDocument { get; set; }

    public string Name { get; set; } = null!;

    public string Rtf { get; set; } = null!;

    public byte[]? Attachment { get; set; }
}
