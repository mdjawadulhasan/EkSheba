using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UsersDetailDTO
    {
        public int Nid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Religion { get; set; }
        [Required]
        public string FathersName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string Status { get; set; }

        public Nullable<int> FK_Uid { get; set; }
    }
}
