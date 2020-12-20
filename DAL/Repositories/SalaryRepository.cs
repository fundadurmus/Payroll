using COM.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Enums;

namespace DAL.Repositories
{
    
    public class SalaryRepository : ISalaryRepository
    {
        private RPContext _context;
        public SalaryRepository(RPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payroll>> GetPayrolls(int? index)
        {
            var Workers = _context.Workers;
            
            if(index.HasValue)
            {
                Workers = (DbSet<Worker>)Workers.Where(w => w.Id == index);
            }

            return await Workers.Select(worker => new Payroll
            {
                IdentificationNumber = worker.IdentificationNumber,
                Name = worker.Name,
                Surname = worker.Surname,
                Salary = CalculateSalary(worker)
            })
            .ToListAsync();

        }
        private static double CalculateSalary(Worker worker)
        {
            switch (worker.Type)
            {
                case WorkerType.Type1:
                    if(!CheckValue(worker.MonthlySalary))
                    {
                        return 0;
                    }
                    return worker.MonthlySalary.Value;
                case WorkerType.Type2:
                    if (!CheckValue(worker.WorkDay) || !CheckValue(worker.DailySalary))
                    {
                        return 0;
                    }

                    return worker.WorkDay.Value * worker.DailySalary.Value;
                case WorkerType.Type3:
                    if (!CheckValue(worker.MonthlySalary) || !CheckValue(worker.OvertimeSalary) || !CheckValue(worker.OverTimeWorkHour))
                    {
                        return 0;
                    }
                    return worker.MonthlySalary.Value + (worker.OverTimeWorkHour.Value * worker.OvertimeSalary.Value);
                case WorkerType.Type4:
                    if (!CheckValue(worker.WorkDay) || !CheckValue(worker.DailySalary) || !CheckValue(worker.OverTimeWorkHour) || !CheckValue(worker.OvertimeSalary))
                    {
                        return 0;
                    }
                    return (worker.WorkDay.Value * worker.DailySalary.Value) + (worker.OverTimeWorkHour.Value * worker.OvertimeSalary.Value);
                default:
                    return 0;
            }
        }
        private static bool CheckValue(double? item)
        {
            return item.HasValue;
        }

    }
}
