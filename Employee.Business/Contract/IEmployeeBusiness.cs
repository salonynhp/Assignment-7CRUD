using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.ViiewModels.ViewModels;



namespace Employee.Business.Contract
{
    public interface IEmployeeBusiness
    {
        Task<List<EmployeeModel>> GetList();

        Task<EmployeeModel> GetById(Guid id);

        Task<>
    }
}
