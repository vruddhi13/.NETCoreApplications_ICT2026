using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace EmployeeProjectAllocationMVC.Models;

public partial class ProjectAllocation
{
    public int ProAllocateId { get; set; }

    public int EmpId { get; set; }

    
    public int ProId { get; set; }

    public DateTime AllocationDate { get; set; }

    [ValidateNever]
    public virtual Employee Emp { get; set; } = null!;
    
    [ValidateNever]
    public virtual Project Pro { get; set; } = null!;
}
