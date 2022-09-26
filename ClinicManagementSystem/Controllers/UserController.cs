using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Model;
using ClinicManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using ClinicManagementSystem.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;

namespace ClinicManagementSystem.Controllers
{
    [Route("Api/Controller")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ITokenJwtAuthenticationService _tokenJwtAuthenticationService;
        private readonly string _controllerName = "User Controller";
        private readonly ILogger<UserRepository> _logger;
        private readonly IMemoryCache _memoryCache; 
        private readonly CacheManager<User> _cacheManager;
        public UserController(IUserService userService, ITokenJwtAuthenticationService tokenJwtAuthenticationService, ILogger<UserRepository> logger, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _userService = userService;
            _logger = logger;
            _configuration = configuration;
            _tokenJwtAuthenticationService = tokenJwtAuthenticationService;
            _memoryCache = memoryCache;
            _cacheManager = new CacheManager<User>(_userService ,_memoryCache, CacheNames.User, CacheAbsoluteDuration.User);
        }
        [HttpPost("AuthenticateUser")]
        public IActionResult AuthenticateUser(UserDTO userDTO)
        {
            _logger.LogInformation($"{_controllerName} - AuthenticationUser");
            Tokens sessionId = _tokenJwtAuthenticationService.Authenticate(userDTO);
            if (sessionId == null)
            {
                return Ok(new RequestResponse()
                {
                    ResponseCode = 401,
                    Message = "UnAuthorized",
                    Data = null
                });
            }
            else
            {
                Response.Headers.Add("authorizationtoken", sessionId.Token);
                return Ok(new RequestResponse()
                {
                    ResponseCode = 200,
                    Message = "Successfull",
                    Data = sessionId.Token
                });
            }
        }
        [HttpPost("GetAllUser")]
        public IActionResult GetAllUser()
        {
            //Log.Information("Index Controller Called");
            _logger.LogInformation($"{_controllerName} - GetAllUser");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string tokenEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(tokenEmail))
                {
                    IEnumerable<User> objs = _cacheManager.GetCache();
                    //List<User> users = _userService.GetAll();
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "Successfull",
                        Data = objs
                    });
                }
                else
                {
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 401,
                        Message = "UnAuthorized",
                        Data = new
                        {
                            LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                        }
                    });
                }
            }
            else
            {
                return Ok(new RequestResponse()
                {
                    ResponseCode = 401,
                    Message = "UnAuthorized",
                    Data = new
                    {
                        LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                    }
                });
            }
        }
        [HttpPost("GetUserById")]
        public IActionResult GetUserById(int Id)
        {
            _logger.LogInformation($"{_controllerName} - GetUserById");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string validateUser = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(validateUser))
                {
                    var record = _cacheManager.GetCache().AsParallel().Where(p => p.Id == Id).FirstOrDefault();
                    //User record = _userService.GetUserById(Id);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "Successfull",
                        Data = record
                    });
                }
                else
                {
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 401,
                        Message = "UnAuthorized",
                        Data = new
                        {
                            LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                        }
                    });
                }
            }
            else
            {
                return Ok(new RequestResponse()
                {
                    ResponseCode = 401,
                    Message = "UnAuthorized",
                    Data = new
                    {
                        LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                    }
                });
            }
        }
        [HttpPost("EditUser")]
        public IActionResult EditUser(User user)
        {
            _logger.LogInformation($"{_controllerName} - EditUser");
            string sessionId = HttpContext.Response.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                var validateToken = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(validateToken))
                {
                    //int id = _userService.Edit(user);
                    var oldItem = _cacheManager.GetCache().Where(p => p.Id == user.Id).FirstOrDefault();
                    var dataUpdate = _cacheManager.UpdateItemInCache(oldItem, user);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "Successfull",
                        Data = dataUpdate
                    });

                }
                else
                {
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 401,
                        Message = "UnAuthorized",
                        Data = new
                        {
                            LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                        }
                    });
                }
            }
            else
            {
                return Ok(new RequestResponse()
                {
                    ResponseCode = 401,
                    Message = "UnAuthorized",
                    Data = new
                    {
                        LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                    }
                });
            }

        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            _logger.LogInformation($"{_controllerName} - AddUser");
            string sessionId = HttpContext.Response.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                var validateToken = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(validateToken))
                {
                    //int id = _userService.Add(user);
                    var dataAdd = _cacheManager.AddItemInCache(user);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "Successfull",
                        Data = dataAdd
                    });

                }
                else
                {
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 401,
                        Message = "UnAuthorized",
                        Data = new
                        {
                            LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                        }
                    });
                }
            }
            else
            {
                return Ok(new RequestResponse()
                {
                    ResponseCode = 401,
                    Message = "UnAuthorized",
                    Data = new
                    {
                        LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                    }
                });
            }

        }
    }
}
