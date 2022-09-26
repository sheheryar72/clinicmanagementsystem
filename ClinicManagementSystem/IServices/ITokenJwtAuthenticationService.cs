using ClinicManagementSystem.Model;

namespace ClinicManagementSystem.IServices
{
    public interface ITokenJwtAuthenticationService
    {
        Tokens Authenticate(UserDTO userDTO);
        Tokens GenerateJwtToken(UserDTO userDTO);
        string ValidateJwtToken(string token);
    }
}
