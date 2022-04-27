using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework.LabExercise2.Models
{
    [Table("AnnualSalary")]
    public partial class AnnualSalary
    {
        [Key]
        [Column("cEmployeeCode")]
        [StringLength(6)]
        public string EmployeeCode { get; set; }
        [Column("mAnnualSalary", TypeName = "money")]
        public decimal? mAnnualSalary { get; set; }
        [Key]
        [Column("siYear")]
        public short Year { get; set; }

        [ForeignKey(nameof(EmployeeCode))]
        [InverseProperty(nameof(Employee.AnnualSalaries))]
        public virtual Employee CEmployeeCodeNavigation { get; set; }
    }
}
