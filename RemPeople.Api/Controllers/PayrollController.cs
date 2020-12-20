using System.Collections.Generic;
using System.Threading.Tasks;
using BUS.Services.Interfaces;
using COM.Models;
using Microsoft.AspNetCore.Mvc;

namespace RemPeopleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayrollController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public PayrollController(ISalaryService salaryService)
        {
            _salaryService = salaryService; 
        }
            
        [HttpGet]
        public async Task<IEnumerable<Payroll>> Get(int? id)
        {
            return await _salaryService.GetPayrolls(id);
        }
    }
}
