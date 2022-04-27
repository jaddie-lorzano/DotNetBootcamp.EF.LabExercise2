using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    internal class MonthlySalaryRepository
    {
        public RecruitmentContext Context { get; set; }
        public MonthlySalaryRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
        public List<MonthlySalary> FindByEmployeeCode(string employeeCode)
        {
            return this.Context.MonthlySalaries.Where(e => e.CEmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}
