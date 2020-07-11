using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DepartmentConfiguration:EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("Department");
            //HasKey(i => i.ID);
            //Property(i => i.ID)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(i => i.ID)
            //   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(i => i.Employees)
                .WithOptional(i => i.Department)
                .HasForeignKey(i => i.DepartmentID);

            HasOptional(i => i.Maneger)
                .WithMany(i => i.DepartmentManeger)
                .HasForeignKey(i => i.ManegerID);

            //HasRequired(i => i.Maneger)
            //    .WithOptional(i => i.DepartmentManeger)
            //    ;
            //Property(i => i.ManegerID)
            //   .IsOptional();
            //.HasForeignKey(i => i.ManegerID);
        }
    }
}
