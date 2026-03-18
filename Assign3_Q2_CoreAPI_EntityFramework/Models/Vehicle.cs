using System;
using System.Collections.Generic;

namespace Assign3_Q2_CoreAPI_EntityFramework.Models;

public partial class Vehicle
{
    public int VId { get; set; }

    public string VBrand { get; set; } = null!;

    public string VModel { get; set; } = null!;

    public int VYear { get; set; }

    public string VColor { get; set; } = null!;

    public decimal VPrice { get; set; }
}
