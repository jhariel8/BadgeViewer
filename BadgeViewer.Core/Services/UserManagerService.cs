using BadgeViewer.Core.Enum;
using BadgeViewer.Dal.Dal;
using BadgeViewer.Dal.Models;
using BadgeViewer.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Core.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IBadgeDataRepository badgeDataRepository;

        private UserDto currentUser;

        public UserManagerService(IBadgeDataRepository badgeDataRepository)
        {
            this.badgeDataRepository = badgeDataRepository;
        }

        public async Task<UserDto> ReadAsync(Guid uid)
        {
            currentUser = await badgeDataRepository.User.ReadByUIDAsync(uid);

            return currentUser;
        }

        public async Task<UserDto> UpdateLastViewedTime(DateTime time)
        {
            currentUser.lastviewedtime = time;

            return await badgeDataRepository.User.UpdateAsync(currentUser);
        }

        public Task<UserDto> UpdateUsername(string username)
        {
            currentUser.username = username;

            return badgeDataRepository.User.UpdateAsync(currentUser);
        }

        public void ClearUser()
        {
            currentUser = null;
        }

        public Task<UserDto> UpdateUserClass(UserTypes userType)
        {
            switch(userType)
            {
               case UserTypes.Local:
                    currentUser.@class = "local";
                    break;
                case UserTypes.Facebook:
                case UserTypes.Google:
                    currentUser.@class = "social";
                    break;
                case UserTypes.Microsoft:
                    currentUser.@class = "work";
                    break;
            }

            return badgeDataRepository.User.UpdateAsync(currentUser);
        }

        public async Task<List<NotificationDto>> GetNotificationsForCurrentUser()
        {
            var notificationsToKeep = new List<NotificationDto>();

            var notifications = await badgeDataRepository.Notification.ReadByUserUID(currentUser.uid);

            foreach(var notification in notifications)
            {
                if(notification.expirationTime > DateTime.Now && !string.IsNullOrEmpty(notification.message))
                {
                    notificationsToKeep.Add(notification);
                }
            }

            return notificationsToKeep;
        }
    }
}
