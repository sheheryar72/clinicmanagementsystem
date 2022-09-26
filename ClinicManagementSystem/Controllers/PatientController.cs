using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Model;
using ClinicManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    [Route("Api/Controller")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientRepository> _logger;
        private readonly string _controllerName = "PatientController";
        private readonly IPatientService _patientService;
        private readonly IConfiguration _configuration;
        private readonly ITokenJwtAuthenticationService _tokenJwtAuthenticationService;
        public PatientController(IConfiguration configuration ,ILogger<PatientRepository> logger, IPatientService patientService, ITokenJwtAuthenticationService tokenJwtAuthenticationService)
        {
            _configuration = configuration;
            _logger = logger;
            _patientService = patientService;
            _tokenJwtAuthenticationService = tokenJwtAuthenticationService;
        }
        [HttpPost("GetAllPatient")]
        public IActionResult GetAllPatient()
        {
            _logger.LogInformation($"{_controllerName} - GetAllPatient");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var patient = _patientService.GetAll();
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = patient
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
        [HttpPost("GetPatientById/{Id}")]
        public IActionResult GetPatientById(int Id)
        {
            _logger.LogInformation($"{_controllerName} - GetPatientById");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var patient = _patientService.GetPatientById(Id);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = patient
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
        [HttpPost("AddPatient")]
        public IActionResult AddPatient(Patient patient)
        {
            _logger.LogInformation($"{_controllerName} - Add");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    int id = _patientService.Add(patient);
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

        [HttpPost("Editpatient")]
        public IActionResult EditPatient(Patient patient)
        {
            _logger.LogInformation($"{_controllerName} - Edit");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    int id = _patientService.Edit(patient);
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
        [HttpPost("DeletePatient/{Id}")]
        public IActionResult DeletePatient(int Id)
        {
            _logger.LogInformation($"{_controllerName} - Delete");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    bool deletepatient = _patientService.Delete(Id);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = deletepatient
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
