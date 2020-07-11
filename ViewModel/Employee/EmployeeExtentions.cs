using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class EmployeeExtentions
    {
        public static EmployeeViewModel ToViewModel(this Employee model)
        {
            return new EmployeeViewModel()
            {
                ID=model.ID,
                Name=model.Name,
                Phone=model.Phone,
                Address=model.Address,
                DepartmentName=model.Department?.Name
            };
        }
        public static EmployeeEditViewModel ToEditViewModel(this Employee model)
        {
            return new EmployeeEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address,
                DepartmentID = model?.DepartmentID
            };
        }
        public static Employee ToModel(this EmployeeEditViewModel model)
        {
            return new Employee()
            {
                ID = model.ID,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address,
                DepartmentID = model?.DepartmentID
            };
        }
    }
}
