using AutoMapper;
using Guest_BAL.IServices;
using Guest_BO;
using Guest_BO.DataModel;
using Guest_BO.DTOModel.GuestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace Guest_App.Controllers
{
    [Route("api/Guest/[action]")]
    [ApiController]
    [Authorize]
    public class GuestController : ControllerBase
    {
        protected APIResponse _response;
        public readonly IGuestService _guestService;
        public readonly IMapper _mapper;

        public GuestController(IGuestService guestService, IMapper mapper)
        {
            _guestService = guestService;
            this._response = new();
            _mapper = mapper;
            
        }

        [HttpGet]
        public ActionResult<APIResponse> AllGuests()
        {
            try
            {
                var guestdatas = _guestService.GetAll();
                if (guestdatas == null || guestdatas.Count == 0)
                {
                    _response.statuCode = HttpStatusCode.NotFound;
                    _response.isSuccess = false;
                    return NotFound(_response);
                }
                else
                {
                    _response.statuCode = HttpStatusCode.OK;
                    _response.Result = _mapper.Map<List<GuestDTO>>(guestdatas);
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

        [HttpGet("{Id}", Name = "GuestById")]
        public ActionResult<APIResponse> GuestById(string Id)
        {
            try
            {
                var guestdata = _guestService.Get(x => x.ID.ToString().ToLower() == Id.ToLower());
                if (guestdata == null)
                {
                    _response.statuCode = HttpStatusCode.NotFound;
                    _response.isSuccess = false;
                    return NotFound(_response);
                }
                else
                {
                    _response.statuCode = HttpStatusCode.OK;
                    _response.Result = _mapper.Map<GuestDTO>(guestdata);
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
        public ActionResult<APIResponse> AddGuest(CreateGuestDTO guestObj)
        {
            try
            {

                if (guestObj == null)
                {
                    _response.statuCode = HttpStatusCode.BadRequest;
                    _response.isSuccess = false;
                    return BadRequest(_response);
                }
                else if (guestObj.FirstName == null && guestObj.FirstName=="")
                {
                    _response.statuCode = HttpStatusCode.BadRequest;
                    _response.isSuccess = false;
                    _response.Result="First name is mandatory.";
                    return BadRequest(_response);
                }
                else
                {
                    var guestmapdata = _mapper.Map<Guest>(guestObj);
                    guestmapdata.ID = Guid.NewGuid();
                    guestmapdata.CreatedDate = DateTime.Now;
                    var guestdata = _guestService.Add(guestmapdata);
                    _response.statuCode = HttpStatusCode.Created;
                    _response.Result = guestmapdata;
                    return CreatedAtRoute("GuestById", new { Id = guestmapdata.ID.ToString() }, _response);
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
