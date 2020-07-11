using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EmployeeConfiguration:EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employee");
           
            Property(i => i.Phone)
                .HasMaxLength(11)
                .IsRequired();
            Property(i => i.Address)
               .HasMaxLength(500)
               .IsRequired();
          
            HasOptional(i => i.Department)
                .WithMany(i => i.Employees)
                .HasForeignKey(i => i.DepartmentID);
            //HasMany(i => i.DepartmentManeger)
            //   .WithOptional(i => i.Maneger)
            //   .HasForeignKey(i => i.ManegerID);
            //HasOptional(i => i.DepartmentManeger)
            //   .WithRequired(i => i.Maneger)
            //   ;
            Property(i => i.DepartmentID)
              .IsOptional();

        }

    }
}
