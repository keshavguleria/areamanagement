using System.ComponentModel.DataAnnotations;

namespace AreaManagement.Entity
{
    public class TblUser
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
