using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using COM.Models;
using System.Linq;
using Utilities.Enums;

namespace DAL
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RPContext(
                serviceProvider.GetRequiredService<DbContextOptions<RPContext>>()))
            {
                if (context.Workers.Any())
                {
                    return;   // Data was already seeded
                }

                context.Workers.AddRange(
                    new Worker(1, "11111111110", "Funda", "Durmuş", WorkerType.Type1, monthlySalary: 10000),
                    new Worker(2, "11111111112", "Berat", "Durmuş", WorkerType.Type2, workday: 30, dailySalary: 250),
                    new Worker(3, "11111111114", "İnci", "Durmuş", WorkerType.Type3, monthlySalary: 7500, overTimeWorkHour: 16, dailySalary: 300),
                    new Worker(4, "11111111116", "Seda", "Gönül", WorkerType.Type4, 30, 10, 250));

                context.SaveChanges();
            }
        }
    }
}
