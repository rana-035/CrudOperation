using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EmployeeEditViewModel
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Phone]
        [MaxLength(11)]
        [MinLength(11)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        public int? DepartmentID { get; set; }
    }
}
