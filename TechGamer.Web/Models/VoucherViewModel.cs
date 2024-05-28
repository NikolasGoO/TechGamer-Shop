using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TechGamer.Web.Models
{
    public class VoucherViewModel
    {
        [MaxLength(5, ErrorMessage = "O campo Código só pode ter 5 caracteres.")]
        [DisplayName("Código")]
        public string Code { get; set; }
    }
}
