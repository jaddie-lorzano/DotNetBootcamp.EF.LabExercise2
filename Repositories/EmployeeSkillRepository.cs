using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    internal class EmployeeSkillRepository
    {
        public RecruitmentContext Context { get; set; }
        public EmployeeSkillRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
        public List<EmployeeSkill> FindByEmployeeCode(string employeeCode)
        {
            return this.Context.EmployeeSkills.Where(e => e.CEmployeeCode.Equals(employeeCode)).ToList();
        }
    }
}
