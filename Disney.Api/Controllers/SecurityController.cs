using System.Threading.Tasks;
using AutoMapper;
using Disney.Api.Responses;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Enumerations;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("[controller]")]
    [Route("auth")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityService, IMapper mapper, 
            IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        /// <summary>
        /// Register a new user in the system
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);
            security.Password = _passwordService.Hash(security.Password);
            
            await _securityService.RegisterUser(security);

            securityDto = _mapper.Map<SecurityDto>(security);
            var response = OperationResult<SecurityDto>
                .CreateSuccessResult(securityDto);
            return Ok(response);
        }

    }
}