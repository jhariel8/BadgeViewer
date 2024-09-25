using BadgeViewer.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Dal.Dal
{
    public interface IUserDal
    {
        Task<UserDto> ReadByUIDAsync(Guid uid);

        Task<UserDto> UpdateAsync(UserDto userDto);
    }
}
