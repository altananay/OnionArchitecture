using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        IUserReadRepository _userReadRepository;
        IUserClaimReadRepository _userClaimReadRepository;

        public UsersController(IUserService userService, IUserReadRepository userReadRepository, IUserClaimReadRepository userClaimReadRepository)
        {
            _userService = userService;
            _userReadRepository = userReadRepository;
            _userClaimReadRepository = userClaimReadRepository;
        }

        [HttpGet("getbyemail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("getclaims")]
        //public IActionResult GetClaims(string id)
        //{
        //    var result = _userClaimReadRepository.GetClaims(id);
        //    return Ok(result);
        //}
    }
}
