using EmployeeProjectAllocationMVC.Models;

namespace EmployeeProjectAllocationMVC.GenericCollection
{
    public class EmployeeIndexer
    {
        private List<Employee> employees;

        public EmployeeIndexer(List<Employee> employees)
        {
            this.employees = employees;
        }

        public List<Employee> this[string department]
        {
            get { return this.employees.Where(e => e.EmpDepartment == department).ToList(); }
        }

        public List<Employee> this[string department, string designation]
        {
            get
            {
                return this.employees.Where(e => e.EmpDepartment == department && e.EmpDesignation == designation).ToList();
            }
        }
        
    }
}
