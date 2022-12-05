namespace HR_app.App.Domain
{
    public record Person
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; } = string.Empty;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Контактные данные
        /// </summary>
        public ContactData ContactData { get; set; } = new();

        public string GetFullName()
        {
            var nameComponents = new List<string>()
            {
                FirstName,
                Patronymic,
                LastName
            };
            return string.Join(
                " ",
                nameComponents.Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}
