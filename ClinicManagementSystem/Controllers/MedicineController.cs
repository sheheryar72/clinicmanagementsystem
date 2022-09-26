using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Model;
using ClinicManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory; 

namespace ClinicManagementSystem.Controllers
{
    [Route("Api/Controller")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly ILogger<MedicineRepository> _logger;
        private readonly string _controllerName = "MedicineController";
        private readonly IMedicineService _medicineService;
        private readonly ITokenJwtAuthenticationService _tokenJwtAuthenticationService;
        private readonly IMemoryCache _memoryCache;
        private readonly CacheManager<Medicine> _cacheManager;
        private readonly IConfiguration _configuration;
        public MedicineController(IConfiguration configuration,IMemoryCache memoryCache ,ILogger<MedicineRepository> logger, IMedicineService medicineService, ITokenJwtAuthenticationService tokenJwtAuthenticationService)
        {
            _configuration = configuration;
            _logger = logger;
            _memoryCache = memoryCache;
            _medicineService = medicineService;
            _tokenJwtAuthenticationService = tokenJwtAuthenticationService;
            _cacheManager = new CacheManager<Medicine>(_medicineService, _memoryCache, CacheNames.Medicine, CacheAbsoluteDuration.Medicine);
        }
        [HttpPost("GetAllMedicine")]
        public IActionResult GetAllMedicine()
        {
            _logger.LogInformation($"{_controllerName} - GetAll");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var records = _medicineService.GetAll();
                    //var records = _cacheManager.GetCache();
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = records
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
        [HttpPost("GetMedicineById/{Id}")]
        public IActionResult GetMedicineById(int Id)
        {
            _logger.LogInformation($"{_controllerName} - GetMedicineById");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var medicine = _medicineService.GetMedicineById(Id);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = medicine
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
        [HttpPost("AddMedicine")]
        public IActionResult AddMedicine(Medicine medicine)
        {
            _logger.LogInformation($"{_controllerName} - Add");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    int id = _medicineService.Add(medicine);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = new
                        {
                            LoginUrl = _configuration["RdirectionURL:LoginUrl"]
                        }
                    });
                }
                else
                {
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 401,
                        Message = "UnAuthorized",
                        Data = null
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

        [HttpPost("EditMedicine")]
        public IActionResult EditMedicine(Medicine medicine)
        {
            _logger.LogInformation($"{_controllerName} - Edit");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    int id = _medicineService.Edit(medicine);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = id
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
        [HttpPost("DeleteMedicine/{Id}")]
        public IActionResult DeleteMedicine(int Id)
        {
            _logger.LogInformation($"{_controllerName} - Delete");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    bool deleteMedicine = _medicineService.Delete(Id);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = deleteMedicine
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
