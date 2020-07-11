using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositires
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext():base("CrudTask")
            {
            }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
           
            dbModelBuilder.Configurations.Add(new EmployeeConfiguration());
            dbModelBuilder.Configurations.Add(new DepartmentConfiguration());
          

        }
    }
}
