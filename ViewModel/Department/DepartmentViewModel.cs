using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DepartmentViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ManegerName { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }

    }
}
