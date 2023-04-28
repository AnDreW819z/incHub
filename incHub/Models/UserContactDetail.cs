using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
namespace incHub.Models
{
    public class UserContactDetail : BaseEntity
    {
        public string Email { get; set; }
        public string Account { get; set; }
        public  string Repository { get; set; }
        public User User { get; set; }
    }
}
