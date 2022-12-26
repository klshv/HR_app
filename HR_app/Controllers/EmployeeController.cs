using AutoMapper;
using HR_app.App.Domain;
using HR_app.App.Interfaces.Services;
using HR_app.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HR_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        /// <summary>
        /// Возвращает список занесённых в систему людей
        /// </summary>
        /// <param name="pageIndex">Номер страницы, с которой нужно брать данные</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns>Короткая версия DTO, содержащая только ФИО</returns>
        [HttpGet(nameof(EmployeeController.List))]
        public EmployeeListDto List([BindRequired] int pageIndex, [BindRequired] int pageSize)
        {
            return new()
            {
                Count = _employeeService.GetCount(),
                Employees = _employeeService.GetAll(pageIndex, pageSize)
                    .Select(x => _mapper.Map<EmployeeShortDto>(x))
            };
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.GetById(id);

            return employee != null ? Ok(_mapper.Map<EmployeeDto>(employee)) : NotFound();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EmployeeDto>> PostAsync([FromBody] EmployeeCreateDto value)
        {
            var newEmployee = _mapper.Map<Employee>(value);
            var createdEmployee = await _employeeService.CreateAsync(newEmployee);
            return CreatedAtAction(nameof(Get), new { id = createdEmployee.Id }, _mapper.Map<EmployeeDto>(createdEmployee));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] EmployeeDto value)
        {
            var employee = _mapper.Map<Employee>(value);
            await _employeeService.UpdateAsync(id, employee);
            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

    }
}
