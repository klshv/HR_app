using AutoMapper;
using HR_app.App.Domain;
using HR_app.Interfaces.Services;
using HR_app.Models.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_app.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    public PersonController(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

    // GET: api/<PersonController>
    /// <summary>
    /// Возвращает список занесённых в систему людей
    /// </summary>
    /// <param name="pageIndex">Номер страницы, с которой нужно брать данные</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <returns>Короткая версия DTO, содержащая только ФИО</returns>
    [HttpGet(nameof(PersonController.List))]
    public PersonListDto List(int pageIndex, int pageSize)
    {
        return new()
        {
            Count = _personService.GetCount(),
            Persons = _personService.GetAll(pageIndex, pageSize)
                .Select(x => _mapper.Map<PersonShortDto>(x))
        };
    }

    // GET api/<PersonController>/5
    [HttpGet("{id}")]
    public PersonDto Get(int id)
    {
        var person = _personService.GetById(id);
        return _mapper.Map<PersonDto>(person);
    }

    // POST api/<PersonController>
    [HttpPost]
    public async Task PostAsync([FromBody] PersonCreateDto value)
    {
        var newPerson = _mapper.Map<Person>(value);
        await _personService.CreateAsync(newPerson);
    }

    // PUT api/<PersonController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] PersonDto value)
    {
    }

    // DELETE api/<PersonController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

}
