using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Department:BaseModel
    {
        public int? ManegerID { get; set; } = null;
        public virtual Employee Maneger { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
