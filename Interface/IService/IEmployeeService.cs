using Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.IService
{
    public interface IEmployeeService
    {
        Task<ResponseModel> SaveEmployee(Employee employee);
        Task<ResponseModel> GetEmployeeById(long id);
        Task<ResponseModel> GetAllEmployee();
    }
}
