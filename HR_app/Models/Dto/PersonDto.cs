namespace HR_app.Models.Dto
{
    /// <summary>
    /// Личные данные человека
    /// </summary>
    public record PersonDto
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = String.Empty;
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; } = String.Empty;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = String.Empty;
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Контактные данные
        /// </summary>
        public ContactDataDto ContactData { get; set; } = new();

    }
}
