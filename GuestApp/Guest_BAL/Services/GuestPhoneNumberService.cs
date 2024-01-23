using Guest_BAL.IServices;
using Guest_BO.DataModel;
using Guest_BO.DTOModel.PhoneNumber;
using Guest_DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BAL.Services
{
    public class GuestPhoneNumberService : Service<GuestPhoneNumber, IGuestPhoneNumberRepository>, IGuestPhoneNumberService
    {
        public readonly IGuestPhoneNumberRepository _guestPhoneNumberRepository;
        public readonly IPhoneService _phoneService;
        public GuestPhoneNumberService(IGuestPhoneNumberRepository guestPhoneNumberRepository,IPhoneService phoneService) : base(guestPhoneNumberRepository)
        {
            _guestPhoneNumberRepository = guestPhoneNumberRepository;
            _phoneService = phoneService;
        }

        public GuestPhoneNumberDTO GetPhoneDetails(Expression<Func<GuestPhoneNumber, bool>>? filter = null)
        {
            var getGuestPhoneNumbers = _guestPhoneNumberRepository.GetAll(filter);
            GuestPhoneNumberDTO guestPhoneNumberDTO = new GuestPhoneNumberDTO();
            if (getGuestPhoneNumbers != null)
            {
                
                guestPhoneNumberDTO.GuestId = getGuestPhoneNumbers.FirstOrDefault().GuestId;
                foreach (var phonenumber in getGuestPhoneNumbers)
                {
                    var getPhoneNumbers = _phoneService.Get(x => x.Id == phonenumber.PhoneId);
                    guestPhoneNumberDTO.phoneNumbers.Add(getPhoneNumbers);

                }
                
            }
           return guestPhoneNumberDTO;

        }

    }
}
