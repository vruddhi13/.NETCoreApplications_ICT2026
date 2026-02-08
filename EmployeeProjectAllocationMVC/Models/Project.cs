using System;
using System.Collections.Generic;

namespace EmployeeProjectAllocationMVC.Models;

public partial class Project
{
    public int ProId { get; set; }

    public string ProName { get; set; } = null!;

    public DateTime ProDatetime { get; set; }
}
