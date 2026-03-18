using System;
using System.Collections.Generic;

namespace ProjectAllocationSystem_ICT2_Assignment2_38Q2.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string EmpEmail { get; set; } = null!;

    public string EmpDepartment { get; set; } = null!;

    public string EmpDesignation { get; set; } = null!;

    public virtual ICollection<ProjectAllocation> ProjectAllocations { get; set; } = new List<ProjectAllocation>();

    public override string ToString()
    {
        // This is what the string indexer will search in
        return $"{EmpName} - {EmpDepartment} - {EmpDesignation}";
    }
}
