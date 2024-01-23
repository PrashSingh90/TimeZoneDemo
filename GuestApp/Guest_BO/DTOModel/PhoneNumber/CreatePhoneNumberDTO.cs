using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BO.DTOModel.PhoneNumber
{
    public class CreatePhoneNumberDTO
    {
        [Required]
        public Guid GuestId { get; set; }

        [Required]
        public string PhoneNumberValue { get; set; }
    }
}
