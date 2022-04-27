using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using EntityFramework.LabExercise2.Repositories;

namespace EntityFramework.LabExercise2
{
    class Program
    {
        static void FindEmployee(EmployeeRepository repository, string employeeCode)
        {
            var employee = repository.FindEmployeeByCode(employeeCode);
            Console.WriteLine(
                $"Employee Code: {employee.Code}\n" +
                $"   Last Name: {employee.VLastName}\n" +
                $"   First Name: {employee.VFirstName}\n" +
                $"   BirthDate: {employee.DBirthDate}\n");
        }
        static void FindPosition(
            PositionRepository positionRepository, 
            EmployeeRepository employeeRepository,
            string employeeCode)
        {
            var employee = employeeRepository.FindEmployeeByCode(employeeCode);
            var position = positionRepository.FindByEmployeeCode(employee.CCurrentPosition);
            Console.WriteLine($"    Position: {position.VDescription}");
        }
        static void FindAnnualSalaries(AnnualSalaryRepository repository, string employeeCode)
        {
            Console.WriteLine("     Annual Salaries by Year");
            List<AnnualSalary> annualSalaries = repository.FindByEmployeeCode(employeeCode);
            foreach (AnnualSalary annualSalary in annualSalaries)
            {
                Console.WriteLine(
                    $"        - Year: {annualSalary.Year} " +
                    $"| Salary: {annualSalary.mAnnualSalary}");
            }
        }
        static void FindMonthlySalaries(MonthlySalaryRepository repository, string employeeCode)
        {
            Console.WriteLine("     Monthly Salaries by Pay Date");
            List<MonthlySalary> monthlySalaries = repository.FindByEmployeeCode(employeeCode);
            foreach (MonthlySalary monthlySalary in monthlySalaries)
            {
                Console.WriteLine(
                    $"        - Pay Date: {monthlySalary.DPayDate} " +
                    $"| Salary: {monthlySalary.MMonthlySalary}" +
                    $"| Referral Bonus: {monthlySalary.MReferralBonus}");
            }
        }
        static void FindEmployeeSkills(
            EmployeeSkillRepository employeeSkillRepository,
            SkillRepository skillRepository,
            string employeeCode)
        {
            Console.WriteLine("     Skills");
            List<EmployeeSkill> employeeSkills = employeeSkillRepository.FindByEmployeeCode(employeeCode);
            foreach (EmployeeSkill employeeSkill in employeeSkills)
            {
                Skill skill = skillRepository.FindBySkillCode(employeeSkill.CSkillCode);
                Console.WriteLine($"        - {skill.VSkill}");
            }
        }
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");

            using RecruitmentContext context = new(dbConnectionString);
            Console.Write("Insert Employee Code: \n\n");
            string employeeCode = Console.ReadLine();

            EmployeeRepository employeeRepository = new(context);
            PositionRepository positionRepository = new(context);
            AnnualSalaryRepository annualSalaryRepository = new(context);
            MonthlySalaryRepository monthlySalaryRepository = new(context);
            EmployeeSkillRepository employeeSkillRepository = new(context);
            SkillRepository skillRepository = new(context);

            FindEmployee(employeeRepository, employeeCode);
            FindPosition(positionRepository, employeeRepository, employeeCode);
            FindAnnualSalaries(annualSalaryRepository, employeeCode);
            FindMonthlySalaries(monthlySalaryRepository, employeeCode);
            FindEmployeeSkills(employeeSkillRepository, skillRepository, employeeCode);
        }
    }
}
