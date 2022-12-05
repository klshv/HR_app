namespace HR_app.Models.Dto
{
    public class PersonListDto
    {
        public int Count { get; set; } = 0;
        public IEnumerable<PersonShortDto> Persons { get; set; } = new List<PersonShortDto>();
    }
}
