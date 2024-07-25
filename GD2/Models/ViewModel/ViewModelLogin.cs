using System.ComponentModel.DataAnnotations;

namespace GD2.Models.ViewModel
{
    public class ViewModelLogin
    {
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
