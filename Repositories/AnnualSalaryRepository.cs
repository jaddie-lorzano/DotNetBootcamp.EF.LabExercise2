using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;

namespace EntityFramework.LabExercise2.Repositories
{
    internal class AnnualSalaryRepository
    {
        public RecruitmentContext Context { get; set; }
        public AnnualSalaryRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
        public List<AnnualSalary> FindByEmployeeCode(string employeeCode)
        {
            return this.Context.AnnualSalaries.Where(e => e.EmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}
