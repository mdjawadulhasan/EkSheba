using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
       
        public Nullable<int> Type { get; set; }
        [Required]
        public string Uname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
