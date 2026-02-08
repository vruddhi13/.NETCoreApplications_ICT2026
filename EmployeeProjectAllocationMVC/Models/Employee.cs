using System;
using System.Collections.Generic;

namespace EmployeeProjectAllocationMVC.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string EmpEmail { get; set; } = null!;

    public string EmpDesignation { get; set; } = null!;

    public string EmpDepartment { get; set; } = null!;

    public virtual ICollection<ProjectAllocation> ProjectAllocations { get; set; } = new List<ProjectAllocation>();
}
