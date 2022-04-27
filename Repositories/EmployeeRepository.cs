using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public class EmployeeRepository
    {
        public RecruitmentContext Context { get; set; }
        public EmployeeRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
        public Employee FindEmployeeByCode(string employeeCode)
        {
            var employee = this.Context.Employees.Where(e => e.Code.Equals(employeeCode)).FirstOrDefault();
            if (employee != null)
            {
                return employee;
            }
            throw new Exception($"Employee with ID {employeeCode} doesn't exist");
        }


    }
}
