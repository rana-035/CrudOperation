using Entities;
using Repositires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services
{
    public class DepartmentService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenaricRepository<Department> DepartmentRepo;
        private GenaricRepository<Employee> EmployeeRepo;

        public DepartmentService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            DepartmentRepo = UnitOfWork.DepartmentRepo;
            EmployeeRepo = UnitOfWork.EmployeeRepo;
        }
        public DepartmentEditViewModel GetByID(int ID)
        {
            return DepartmentRepo.GetByID(ID).ToEditViewModel();
        }
        public IEnumerable<DepartmentViewModel> GetAll()
        {
            return DepartmentRepo.GetAll().Select(i => i.ToViewModel()).ToList();
        }
        public DepartmentEditViewModel Add(DepartmentEditViewModel e)
        {
            DepartmentRepo.Add(e.ToModel());
            UnitOfWork.commit();
            
            return e;
        }
        public DepartmentEditViewModel Update(DepartmentEditViewModel e)
        {
            DepartmentRepo.Update(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public void Remove(DepartmentEditViewModel e)
        {
            var temp = EmployeeRepo.Get(i => i.DepartmentID == e.ID).Select(i => i.ToEditViewModel()).ToList();
            if (temp != null || temp.Count() > 0)
            {
                foreach (var emp in temp)
                {
                    emp.DepartmentID = null;
                    EmployeeRepo.UpdateForDelete(emp.ToModel());
                    UnitOfWork.commit();
                }

            }
            DepartmentRepo.Remove(e.ToModel());
            UnitOfWork.commit();

        }
    }
}