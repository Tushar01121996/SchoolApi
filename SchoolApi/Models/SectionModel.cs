using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class SectionModel : BaseModel
    {
        public string? sectionid { get; set; }
        [Required]
        public string sectionname { get; set; }
        [ForeignKey(nameof(ClassModel.classid))]
        public string classid { get; set; }
    }
}