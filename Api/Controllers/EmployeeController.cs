using Interface.IService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
    
        [Route("SaveEmployee")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveEmployee(Employee employee)
        {
            return Ok(await  employeeService.SaveEmployee(employee));
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IHttpActionResult> GetAllEmployee()
        {
            return Ok(await employeeService.GetAllEmployee());
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IHttpActionResult> GetEmployeeById(long id)
        {
            return Ok(await employeeService.GetEmployeeById(id));
        }

    }
       
}
