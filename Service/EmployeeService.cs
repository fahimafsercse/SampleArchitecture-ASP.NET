using Helper;
using Interface.IService;
using Interface.IUnityOfWork;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IUnityOfWork unityOfWork;
        public EmployeeService( IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }
        public async Task<ResponseModel> SaveEmployee(Employee employee)
        {
            try {
                if (employee.Id == 0)
                {
                    employee.Created = DateTime.Now;
                    employee.Modified = DateTime.Now;
                    employee.Active = true;
                    employee.Editor = 1;
                    employee.Author = 1;
                }
                else
                {
                    employee.Modified = DateTime.Now;
                    employee.Active = true;
                    employee.Editor = 1;
                }
                unityOfWork.genricEmployeeRepo.Insert(employee);
                await unityOfWork.SaveAsync();
                return HelperClass.Response(true, GlobalDeclaration._savedSuccesfully, null);
            }
            catch (Exception e)
            {
                return HelperClass.Response(false, GlobalDeclaration._internalServerError, null);
            }
            

        }
        public async Task<ResponseModel> GetEmployeeById(long id)
        {
            try
            {
                Employee employee = await unityOfWork.genricEmployeeRepo.Get(id);
                return HelperClass.Response(true, GlobalDeclaration._savedSuccesfully, employee);
            }
            catch(Exception e)
            {
                return HelperClass.Response(false, GlobalDeclaration._internalServerError, null);
            }
            
        }
        public async Task<ResponseModel> GetAllEmployee()
        {
            try
            {
                List<Employee> employees = await unityOfWork.genricEmployeeRepo.GetAll();
                return HelperClass.Response(true, GlobalDeclaration._savedSuccesfully, employees);
            }
            catch(Exception ex)
            {
                return HelperClass.Response(false, GlobalDeclaration._internalServerError, null);
            }
            
        }
    }
}