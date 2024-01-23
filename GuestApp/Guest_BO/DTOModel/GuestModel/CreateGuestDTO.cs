using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BO.DTOModel.GuestModel
{
    public class CreateGuestDTO
    {
        [Required]
        public int TitleId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public string Email { get; set; }
    }
}
