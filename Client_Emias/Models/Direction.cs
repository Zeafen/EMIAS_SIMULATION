using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Emias.Models;
public partial class Direction
{
    public int? IdDirection { get; set; }

    public int IdSpeciality { get; set; }

    public long? Oms { get; set; }
}