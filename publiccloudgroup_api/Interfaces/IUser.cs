using publiccloudgroup_api.DTO_s;
using publiccloudgroup_api.Models;

namespace publiccloudgroup_api.Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// This function is used to retreive Users from the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Bool Result, String Response Message, User Object</returns>
        Task<(bool isError, string responseMessage, User? user)> GetUserByEmailAndPassword(UserDto user);
    }
}
