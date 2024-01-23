using System.ComponentModel.DataAnnotations;

namespace Guest_BO.DTOModel.PhoneNumber
{
    public class GuestPhoneNumberDTO
    {
        public GuestPhoneNumberDTO()
        {
            phoneNumbers = new List<Guest_BO.DataModel.PhoneNumber>();
        }
        public Guid GuestId { get; set; }
        public List<Guest_BO.DataModel.PhoneNumber> phoneNumbers { get; set; } 
    }
}
