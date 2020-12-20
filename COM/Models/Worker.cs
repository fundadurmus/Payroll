using Utilities.Constants;
using Utilities.Enums;

namespace COM.Models
{
    public class Worker
    {
        protected Worker() { }
        public Worker(int id,
                        string identificationNumber, 
                        string name, 
                        string surname, 
                        WorkerType type, 
                        int? workday = null,
                        int? overTimeWorkHour = null,
                        double? dailySalary = null,
                        double? monthlySalary = null)
        {
            Id = id;
            IdentificationNumber = identificationNumber;
            Name = name;
            Surname = surname;
            Type = type;
            WorkDay = workday;
            OverTimeWorkHour = overTimeWorkHour;
            DailySalary = dailySalary;
            MonthlySalary = monthlySalary;
            OvertimeSalary = DailySalary != null ? (DailySalary / ProjectConstants.DailyWorkHour) * 1.5 : 0;//Saatlik ücretin 1.5 katı "fazla mesai ücreti"ni verir
        }
        public int Id { get; private set; }
        public string IdentificationNumber { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public WorkerType Type { get; private set; }
        public int? WorkDay { get; private set; }
        public int? OverTimeWorkHour { get; private set; }
        public double? DailySalary { get; private set; }
        public double? MonthlySalary { get; private set; }
        public double? OvertimeSalary { get; private set; }

        
    }
}
