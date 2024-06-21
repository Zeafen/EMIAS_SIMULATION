using System;
using System.Collections.Generic;

namespace EMIAS_API.Models;

public partial class Doctor
{
    public int? IdDoctor { get; set; }

    public string SurName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int IdSpeciality { get; set; }

    public string EnterPassword { get; set; } = null!;

    public string WorkAddress { get; set; } = null!;
}
