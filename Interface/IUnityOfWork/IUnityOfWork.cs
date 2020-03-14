using Interface.IRepo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.IUnityOfWork
{
    public interface IUnityOfWork
    {
        IGenericRepo<Employee> genricEmployeeRepo { get; }
        Task<int> SaveAsync();
        int Save();
    }
}
