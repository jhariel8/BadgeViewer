using BadgeViewer.Core.Enum;
using BadgeViewer.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Core.Services
{
    public interface IUserManagerService
    {
        Task<UserDto> ReadAsync(Guid uid);

        Task<UserDto> UpdateLastViewedTime(DateTime time);

        Task<UserDto> UpdateUsername(string username);

        Task<UserDto> UpdateUserClass(UserTypes userType);

        void ClearUser();
    }
}
