namespace HR_app.Data.Entities
{
    public class PersonEntity
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
        public ContactDataEntity ContactData { get; set; } = new();
    }
}
