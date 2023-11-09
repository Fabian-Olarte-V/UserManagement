using Microsoft.AspNetCore.Mvc;
using Prueba.Api.Services;
using Prueba.Model.AggregateModels;
using Prueba.Model.Dtos;

namespace Prueba.Api.Controllers
{
    [ApiController]
    [Route("users/")]
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Person> CreateUserAccount(UserDataDto userData)
        {
            var personCreated = _userAccountService.CreateUser(userData);
            if (personCreated == null)
            {
                return NotFound("User cannot be created");
            }
            return personCreated;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Person> LoginUserAccount(LoginRequestDto userLoginData)
        {
            var personFound = _userAccountService.LoginUser(userLoginData);
            if (personFound == null)
            {
                return NotFound("Incorrect credentials");
            }
            return personFound;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Person> GetUserById(int id)
        {
            var personFound = _userAccountService.GetUserById(id);       
            if(personFound == null)
            {
                return NotFound("User not found");
            }
            return personFound;
        }
    }
}
