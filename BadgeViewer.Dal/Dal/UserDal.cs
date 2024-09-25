using BadgeViewer.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Dal.Dal
{
    public class UserDal : IUserDal
    {
        public Task<UserDto> ReadByUIDAsync(Guid uid)
        {
            return Task.FromResult(new UserDto()
            {
                uid = uid,
                username = "Test",
                lastviewedtime = DateTime.Now
            });
        }

        public Task<UserDto> UpdateAsync(UserDto userDto)
        {
            return Task.FromResult(userDto);
        }
    }
}
