using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.LabExercise2.Repositories
{
    public class PositionRepository
    {
        public RecruitmentContext Context { get; set; }
        public PositionRepository(RecruitmentContext context)
        {
            this.Context = context;
        }
        public Position FindByEmployeeCode(string employeeCode)
        {
            var position = this.Context.Positions.Where(x => x.CPositionCode.Equals(employeeCode)).FirstOrDefault();
            if (position != null)
            {
                return position;
            }
            throw new Exception($"Position with code {employeeCode} doesn't exist");
        }
    }
}
