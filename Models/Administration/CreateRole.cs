using System.ComponentModel.DataAnnotations;

namespace Models.Administration
{
    public class CreateRole
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
