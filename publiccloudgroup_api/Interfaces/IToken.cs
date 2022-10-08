using publiccloudgroup_api.DTO_s;
using publiccloudgroup_api.Models;

namespace publiccloudgroup_api.Interfaces
{
    public interface IToken
    {
        /// <summary>
        /// This function is used to Generate token for the logged in user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>bool response, string message, Token object</returns>
        Task<(bool isSuccess, string errorMessage, object? token)> GenerateToken(UserDto user);
    }
}
