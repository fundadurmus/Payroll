using BUS.Services.Interfaces;
using COM.Models;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUS.Services
{

    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository) 
        {
            _salaryRepository = salaryRepository; 
        }

        public async Task<IEnumerable<Payroll>> GetPayrolls(int? index)
        {
            return await _salaryRepository.GetPayrolls(index);
        }

    }
}
