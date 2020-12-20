using COM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Payroll>> GetPayrolls(int? index);
        
    }
}
