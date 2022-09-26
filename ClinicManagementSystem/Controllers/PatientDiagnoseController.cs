using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Model;
using ClinicManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    [Route("Api/Controller")]
    [ApiController]
    public class PatientDiagnoseController : Controller
    {
        private readonly ILogger<PatientDiagnoseRepository> _logger;
        private readonly string _controllerName = "PatientDiagnoseController";
        private readonly IPatientDiagnoseService _patientDiagnoseService;
        private readonly IConfiguration _configuration;
        private readonly ITokenJwtAuthenticationService _tokenJwtAuthenticationService;
        public PatientDiagnoseController(IConfiguration configuration, ILogger<PatientDiagnoseRepository> logger, IPatientDiagnoseService patientDiagnoseService, ITokenJwtAuthenticationService tokenJwtAuthenticationService)
        {
            _configuration = configuration;
            _logger = logger;
            _patientDiagnoseService = patientDiagnoseService;
            _tokenJwtAuthenticationService = tokenJwtAuthenticationService;
        }
        [HttpPost("GetAllPatientDiagnose")]
        public IActionResult GetAllPatientDiagnose()
        {
            _logger.LogInformation($"{_controllerName} - GetAllPatientDiagnose");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var patient = _patientDiagnoseService.GetAll();
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
        [HttpPost("GetPatientDiagnoseById/{Id}")]
        public IActionResult GetPatientDiagnoseById(int Id)
        {
            _logger.LogInformation($"{_controllerName} - GetPatientById");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var patientDiagnose = _patientDiagnoseService.GetPatientDiagnoseById(Id);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = patientDiagnose
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
        [HttpPost("AddPatientDiagnose")]
        public IActionResult AddPatientDiagnose(PatientDiagnose patientDiagnose)
        {
            _logger.LogInformation($"{_controllerName} - Diagnose");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    int id = _patientDiagnoseService.Add(patientDiagnose);
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

        [HttpPost("EditPatientDiagnose")]
        public IActionResult EditPatientDiagnose(PatientDiagnose patientDiagnose)
        {
            _logger.LogInformation($"{_controllerName} - Edit");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    int id = _patientDiagnoseService.Edit(patientDiagnose);
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
        [HttpPost("DeletePatientDiagnose/{Id}")]
        public IActionResult DeletePatientDiagnose(int Id)
        {
            _logger.LogInformation($"{_controllerName} - Delete");
            string sessionId = HttpContext.Request.Headers["authorizationtoken"];
            if (!string.IsNullOrEmpty(sessionId))
            {
                string userEmail = _tokenJwtAuthenticationService.ValidateJwtToken(sessionId);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    bool deletepatientDiagnose = _patientDiagnoseService.Delete(Id);
                    return Ok(new RequestResponse()
                    {
                        ResponseCode = 200,
                        Message = "SuccessFull",
                        Data = deletepatientDiagnose
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
