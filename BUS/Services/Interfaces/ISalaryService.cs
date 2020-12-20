
using System.Collections.Generic;
using System.Threading.Tasks;
using COM.Models;

namespace BUS.Services.Interfaces
{
    public interface ISalaryService
    {
        Task<IEnumerable<Payroll>> GetPayrolls(int? index);
    }
}
