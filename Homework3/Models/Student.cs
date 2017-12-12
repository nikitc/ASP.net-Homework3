using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Homework3.Models
{
    public class Student : IValidatableObject
    {
        public int? Id { get; set; }

        [Required (ErrorMessage = "Не указано имя")]
        [MaxLength(20)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Не указан возраст")]
        [Display(Name = "Возраст")]
        public int? Age { get; set; }

        [Required (ErrorMessage = "Не указана группа")]
        [MaxLength(20)]
        [Display(Name = "Группа")]
        public string GroupName { get; set; }

        public int? RecordBookId { get; set; }

        [ForeignKey("RecordBookId")]
        public RecordBook StudentRecordBook { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Age < 18)
            {
                yield return new ValidationResult("Студент должен быть старше 18", new[] {nameof(Age)});
            }
        }
    }
}
