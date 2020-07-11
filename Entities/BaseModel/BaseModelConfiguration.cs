﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BaseModelConfiguration:EntityTypeConfiguration<BaseModel> 
    {
        public BaseModelConfiguration()
        {
            HasKey(i => i.ID);
            Property(i => i.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name)
                .HasMaxLength(500)
                .IsRequired();
        }
       
    }
}
