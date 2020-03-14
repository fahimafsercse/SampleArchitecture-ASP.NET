using Interface.IRepo;
using Interface.IUnityOfWork;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Repository.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly Entities context;

        public UnityOfWork(Entities context)
        {
            this.context = context;
        }

        private IGenericRepo<Employee> EmployeegenericRepo;


        public IGenericRepo<Employee> genricEmployeeRepo
        {
            get
            {
                if (this.EmployeegenericRepo == null)
                {
                    this.EmployeegenericRepo = new GenericRepo<Employee>(context);
                }
                return EmployeegenericRepo;
            }
        }





        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}