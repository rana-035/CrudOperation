using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class DepartmentExtentions
    {
        public static DepartmentViewModel ToViewModel(this Department model)
        {
            return new DepartmentViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                ManegerName = model.Maneger?.Name,
                Employees=model.Employees?.Select(i=>i.ToViewModel()).ToList()
                
            };
        }
        public static DepartmentEditViewModel ToEditViewModel(this Department model)
        {
            return new DepartmentEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                MenegerID=model?.ManegerID
                
            };
        }
        public static Department ToModel(this DepartmentEditViewModel model)
        {
            return new Department()
            {
                ID = model.ID,
                Name = model.Name,
                ManegerID=model?.MenegerID
                
            };
        }
    }
}
