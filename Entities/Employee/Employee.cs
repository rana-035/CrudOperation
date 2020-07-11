using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee:BaseModel
    {
       // public int ID { get; set; }
        //public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? DepartmentID { get; set; } = null;
        public virtual Department Department { get; set; }
       public virtual ICollection< Department> DepartmentManeger { get; set; }



    }
}
