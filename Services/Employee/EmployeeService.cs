using Entities;
using Repositires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
   public class EmployeeService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenaricRepository<Employee> EmployeeRepo;
        private GenaricRepository<Department> DepartmentRepo;

        public EmployeeService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            EmployeeRepo = UnitOfWork.EmployeeRepo;
            DepartmentRepo = UnitOfWork.DepartmentRepo;

        }
        public EmployeeEditViewModel GetByID(int ID)
        {
            return EmployeeRepo.GetByID(ID).ToEditViewModel();
        }
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return EmployeeRepo?.GetAll().Select(i => i.ToViewModel()).ToList();
        }
        public IEnumerable<EmployeeViewModel> GetFilter(int id)
        {
            return EmployeeRepo?.Get(i=>i.DepartmentID==id).Select(i => i.ToViewModel()).ToList();
        }
        public EmployeeEditViewModel Add (EmployeeEditViewModel e)
        {
            EmployeeRepo.Add(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public EmployeeEditViewModel Update(EmployeeEditViewModel e)
        {
            EmployeeRepo.Update(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public void Remove(EmployeeEditViewModel e)
        {
            var temp = DepartmentRepo.Get(i => i.ManegerID == e.ID ).Select(i=>i.ToEditViewModel()).ToList();
            if (temp != null || temp.Count()>0)
            {
                foreach( var dept in temp)
                {
                    dept.MenegerID = null;
                    DepartmentRepo.UpdateForDelete(dept.ToModel());
                    UnitOfWork.commit();
                }

            }
            EmployeeRepo.Remove(e.ToModel()) ;
            UnitOfWork.commit();

        }
    }
}
