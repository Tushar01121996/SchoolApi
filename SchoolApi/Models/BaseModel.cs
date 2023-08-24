using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseModel
    {
        [Key]
        public int srno { get; set; }
        [Required]
        public string createdBy { get; set; }
        public string? updatedBy { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime? updatedDate { get;set; }
        [Required]
        public string SID { get; set; }

    }
}
