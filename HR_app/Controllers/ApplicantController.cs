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
    
    public class ApplicantController : ControllerBase
    {
        public ApplicantController(IApplicantService applicantService, IMapper mapper)
        {
            _applicantService = applicantService;
            _mapper = mapper;
        }

        // GET: api/<ApplicantController>
        /// <summary>
        /// Возвращает список занесённых в систему людей
        /// </summary>
        /// <param name="pageIndex">Номер страницы, с которой нужно брать данные</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns>Короткая версия DTO, содержащая только ФИО</returns>
        [HttpGet(nameof(ApplicantController.List))]
        public ApplicantListDto List([BindRequired]int pageIndex, [BindRequired]int pageSize)
        {
            return new()
            {
                Count = _applicantService.GetCount(),
                Applicants = _applicantService.GetAll(pageIndex, pageSize)
                    .Select(x => _mapper.Map<ApplicantShortDto>(x))
            };
        }

        // GET api/<ApplicantController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var applicant = _applicantService.GetById(id);

            return applicant != null ? Ok(_mapper.Map<ApplicantDto>(applicant)) : NotFound();
        }

        // POST api/<ApplicantController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ApplicantDto>> PostAsync([FromBody] ApplicantCreateDto value)
        {
            var newApplicant = _mapper.Map<Applicant>(value);
            var createdApplicant = await _applicantService.CreateAsync(newApplicant);
            return CreatedAtAction(nameof(Get), new { id = createdApplicant.Id }, _mapper.Map<ApplicantDto>(createdApplicant));
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ApplicantDto value)
        {
            var applicant = _mapper.Map<Applicant>(value);
            await _applicantService.UpdateAsync(id, applicant);
            return NoContent();
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await _applicantService.DeleteAsync(id);
            return NoContent();
        }

        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;

    }
}
