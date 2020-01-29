using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AreaManagement.Entity
{
    [Table("Areas")]
    public class TblArea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Area Name")]
        public string Name { get; set; }

        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }

        [Display(Name = "Updated By")]
        public int UpdatedBy { get; set; }

        [Display(Name = "Created On")]
        public DateTimeOffset CreatedOn { get; set; }

        [Display(Name = "Updated On")]
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
