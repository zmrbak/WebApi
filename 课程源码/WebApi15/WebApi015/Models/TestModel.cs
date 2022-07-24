using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApi015.Validations;

namespace WebApi015.Models
{
    public class TestModel:IValidatableObject
    {
        public int Id { get; set; }

        //[NonSpace]
        [DisplayName("名称1")]
        [MaxLength(5)]
        public string? Name1 { get; set; }

        //[Compare(nameof(Name1))]
        public string? Name2 { get; set; }

        //[Range(0,200,ErrorMessage ="年龄超范围")]
        public int Age { get; set; }
        public string? Gender { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name1?.ToString()?.Contains(" ") == true)
            {
                yield return new ValidationResult("该字符串不允许包含空格",new[] { nameof(Name1) });
            }
        }
    }
}
