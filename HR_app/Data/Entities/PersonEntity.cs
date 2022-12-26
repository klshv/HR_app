using System.ComponentModel.DataAnnotations;

namespace HR_app.Data.Entities
{
    public class PersonEntity
    {
        [Key]
        public int PersonId { get; set; }

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

        public void Overwrite(PersonEntity updatedPerson)
        {
            FirstName = updatedPerson.FirstName;
            LastName = updatedPerson.LastName;
            Patronymic = updatedPerson.Patronymic;
            Birthday = updatedPerson.Birthday;
            ContactData.Overwrite(updatedPerson.ContactData);
        }
    }
}
