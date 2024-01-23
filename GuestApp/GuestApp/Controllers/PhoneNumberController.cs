using AutoMapper;
using Guest_BAL.IServices;
using Guest_BO;
using Guest_BO.DataModel;
using Guest_BO.DTOModel.GuestModel;
using Guest_BO.DTOModel.PhoneNumber;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Guest_App.Controllers
{
    [Route("api/PhoneNumber/[action]")]
    [ApiController]
    [Authorize]
    public class PhoneNumberController : ControllerBase
    {
        protected APIResponse _response;
        public readonly IPhoneService _phoneService;
        public readonly IGuestPhoneNumberService _guestPhoneNumberService;
        public readonly IMapper _mapper;

        public PhoneNumberController(IPhoneService phoneService, IGuestPhoneNumberService guestPhoneNumberService, IMapper mapper)
        {
            _phoneService = phoneService;
            _guestPhoneNumberService = guestPhoneNumberService;
            this._response = new();
            _mapper = mapper;
            
        }

        [HttpGet("{guestId}",Name = "PhoneNumberByGuestId")]
        public ActionResult<APIResponse> PhoneNumberByGuestId(string guestId)
        {
            try
            {
                var guestdata = _guestPhoneNumberService.GetPhoneDetails(x => x.GuestId.ToString().ToLower() == guestId.ToLower());
                if (guestdata == null)
                {
                    _response.statuCode = HttpStatusCode.NotFound;
                    _response.isSuccess = false;
                    return NotFound(_response);
                }
                else
                {
                    _response.statuCode = HttpStatusCode.OK;
                    _response.Result = guestdata;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.errorMessage.Add(ex.Message);
                return _response;
            }
        }

        [HttpPost]
        public ActionResult<APIResponse> AddPhoneNumber([FromBody] CreatePhoneNumberDTO phoneNumberObj)
        {
            try
            {
                var isphonenumberavailable = _phoneService.Get(x=>x.PhoneNumberValue== phoneNumberObj.PhoneNumberValue);
                if (phoneNumberObj == null)
                {
                    _response.statuCode = HttpStatusCode.BadRequest;
                    _response.isSuccess = false;
                    return BadRequest(_response);
                }
                else if (isphonenumberavailable != null)
                {
                    _response.statuCode = HttpStatusCode.BadRequest;
                    _response.errorMessage.Add("PhoneNumber alrady in used");
                    _response.isSuccess = false;
                    return BadRequest(_response);
                }
                else
                {
                    var phonenumbermapdata = _mapper.Map<PhoneNumber>(phoneNumberObj);
                    var phonedata = _phoneService.Add(phonenumbermapdata);
                    var guestphonenumbermapdata = _mapper.Map<GuestPhoneNumber>(phoneNumberObj);
                    guestphonenumbermapdata.PhoneId = phonenumbermapdata.Id;
                    var _guestPhoneNumberdata = _guestPhoneNumberService.Add(guestphonenumbermapdata);
                    _response.statuCode = HttpStatusCode.Created;
                    _response.Result = _guestPhoneNumberdata;
                    return CreatedAtRoute("PhoneNumberByGuestId", new {guestId = phoneNumberObj.GuestId.ToString() }, _response);
                }
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.errorMessage.Add(ex.Message);
                return _response;
            }
        }
    }
}
 