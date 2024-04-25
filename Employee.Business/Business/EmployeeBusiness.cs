using AutoMapper;
using Employee.Repository.Contract;
using Employee.ViiewModels.ViewModels;
using Employee.Business.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Business.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeBusiness(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeModel>> GetList()
        {
            List<EmployeeModel> employeeList = new();

            var result = await _employeeRepository.GetList();

            employeeList = _mapper.Map<List<EmployeeModel>>(result);
            return employeeList;
        }


        public async Task<EmployeeModel> GetById(Guid id)
        {
            EmployeeModel employeeData = new();

            var result = await _employeeRepository.GetById(id);

            employeeData = _mapper.Map<EmployeeModel>(result);
            return employeeData;
        }
    }
}
