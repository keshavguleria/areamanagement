using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AreaManagement.Entity
{
    [Table("User")]
    public class TblUser
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
