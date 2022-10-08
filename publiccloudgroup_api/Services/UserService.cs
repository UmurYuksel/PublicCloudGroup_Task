using Microsoft.EntityFrameworkCore;
using publiccloudgroup_api.Data;
using publiccloudgroup_api.DTO_s;
using publiccloudgroup_api.Interfaces;
using publiccloudgroup_api.Models;

namespace publiccloudgroup_api.Services
{
    public class UserService : IUser
    {
        private readonly UserDbContext _userDbContext;

        public UserService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<(bool isError, string responseMessage, User? user)> GetUserByEmailAndPassword(UserDto userDto)
        {
            try
            {
                var user = await _userDbContext.Users?.FirstOrDefaultAsync(x => x.Email == userDto.Email && x.Password == userDto.Password);

                if (user == null)
                    return (true, "User Not Found", null);

                return (false, string.Empty, user);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }

        }

    }
}
