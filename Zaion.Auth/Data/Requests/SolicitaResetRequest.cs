using System.ComponentModel.DataAnnotations;

namespace Zaion.Auth.Data.Requests {
    public class SolicitaResetRequest {
        [Required]
        public string Email { get; set; }
    }
}
