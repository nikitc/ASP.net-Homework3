using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Homework3.Models
{
    public class Student : IValidatableObject
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Не указано имя")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required (ErrorMessage = "Не указан возраст")]
        public int Age { get; set; }

        [Required (ErrorMessage = "Не указана группа")]
        [MaxLength(20)]
        public string GroupName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Age < 18)
            {
                yield return new ValidationResult("Студент должен быть старше 18", new[] {nameof(Age)});
            }
        }
    }
}
