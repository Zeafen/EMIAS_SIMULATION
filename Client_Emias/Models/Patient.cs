using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.Models;
public partial class Patient
{
    public long? Oms { get; set; }

    public string SurName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Address { get; set; } = null!;

    public string? LivingAddress { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Nickname { get; set; }
}