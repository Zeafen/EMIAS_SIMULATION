using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequests.Models;
public partial class Speciality
{
    public int? IdSpeciality { get; set; }

    public string Name { get; set; } = null!;

    public string ImagePath { get; set; } = null!;
}