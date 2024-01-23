using AutoMapper;
using Guest_BAL.IServices;
using Guest_BO;
using Guest_BO.DataModel;
using Guest_BO.DTOModel.GuestModel;
using Guest_BO.DTOModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GuestApp.Controllers
{
    [Route("api/Title/[action]")]
    [ApiController]
    [Authorize]
    public class TitleController : ControllerBase
    {
        protected APIResponse _response;
        public readonly ITitleService _titleService;
        public readonly IMapper _mapper;
        public TitleController(ITitleService titleService, IMapper mapper)
        {
            _titleService = titleService;
            this._response = new();
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<APIResponse> AllTitle()
        {
            try
            {
                var titledatas = _titleService.GetAll();
                if (titledatas == null || titledatas.Count == 0)
                {
                    _response.statuCode = HttpStatusCode.NotFound;
                    _response.isSuccess = false;
                    return NotFound(_response);
                }
                else
                {
                    _response.statuCode = HttpStatusCode.OK;
                    _response.Result = _mapper.Map<List<Title>>(titledatas);
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
    }
}
