using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace ProjectAllocationSystem_ICT2_Assignment2_38Q2.Models;

public partial class ProjectAllocation
{
    public int ProAllocateId { get; set; }

    public int EmpId { get; set; }

    public int ProjectId { get; set; }

    public DateTime AllocatedDate { get; set; }

    [ValidateNever]
    public virtual Employee Emp { get; set; } = null!;

    [ValidateNever]
    public virtual Project Project { get; set; } = null!;
}
