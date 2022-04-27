using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;

namespace EntityFramework.LabExercise2.Repositories
{
    internal class SkillRepository
    {
        public RecruitmentContext Context { get; set; }
        public SkillRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
        public Skill FindBySkillCode(string SkillCode)
        {
            return this.Context.Skills.Where(es => es.CSkillCode.Equals(SkillCode)).FirstOrDefault();
        }
    }
}
