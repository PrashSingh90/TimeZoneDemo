using Guest_BAL.IServices;
using Guest_BO;
using Guest_BO.DTOModel.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GuestApp.Controllers
{
    [Route("api/UserAuth")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private IUserService _userservice { get; set; }
        protected APIResponse _response;
        public AuthUserController(IUserService userService)
        {
            _userservice = userService;
            this._response = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginresponse = await _userservice.Login(model);
            if (loginresponse.user == null || string.IsNullOrEmpty(loginresponse.Token))
            {
                _response.statuCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.errorMessage.Add("userName or Password is incorrect");
                return BadRequest(_response);
            }
            _response.statuCode = HttpStatusCode.OK;
            _response.isSuccess = true;
            _response.Result = loginresponse;

            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            var isusernameunique = await _userservice.isUniqueUser(model.UserName);
            if (!isusernameunique)
            {
                _response.statuCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.errorMessage.Add("User Name already exist");
                return BadRequest(_response);
            }

            var user = await _userservice.Register(model);
            if (user == null)
            {
                _response.statuCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.errorMessage.Add("Error While Registering");
                return BadRequest(_response);
            }

            _response.statuCode = HttpStatusCode.OK;
            _response.isSuccess = true;
            return Ok(_response);
        }
    }
}
