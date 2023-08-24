using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ClassModel : BaseModel
    {
        public string? classid { get; set; }
        [Required]
        public string classname { get; set; }
    }
}