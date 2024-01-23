using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BO.DataModel
{
    public class GuestPhoneNumber
    {
        [Key]
        public int Id { get; set; }
        public Guid GuestId { get; set; }
        public int PhoneId { get; set; }
    }
}
