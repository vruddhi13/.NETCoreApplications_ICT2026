using System;
using System.Collections.Generic;

namespace ProjectAllocationSystem_ICT2_Assignment2_38Q2.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public DateTime Datetime { get; set; }

    public virtual ICollection<ProjectAllocation> ProjectAllocations { get; set; } = new List<ProjectAllocation>();
}
