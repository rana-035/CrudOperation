using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositires
{
    public class UnitOfWork
    {
        private EntitiesContext Context;
        public GenaricRepository<Employee> EmployeeRepo { get; set; }
        public GenaricRepository<Department> DepartmentRepo { get; set; }
        public UnitOfWork(
            EntitiesContext context,
            GenaricRepository<Employee> employeeRepo,
            GenaricRepository<Department> depatmentRepo
            )
        {
            Context = context;
            EmployeeRepo = employeeRepo;
            EmployeeRepo.Context = context;
            DepartmentRepo = depatmentRepo;
            DepartmentRepo.Context = Context;
        }
        public int commit()
        {
            return Context.SaveChanges();
        }

    }
}
