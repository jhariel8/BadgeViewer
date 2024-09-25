using BadgeViewer.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Dal.Dal
{
    public class NotificationDal : INotificationDal
    {
        public Task<List<NotificationDto>> ReadByUserUID(Guid uid)
        {
            return Task.FromResult(new List<NotificationDto>
            {
                new NotificationDto()
                {
                    message = "Hello",
                    expirationTime = DateTime.Now.AddDays(1)
                },
                new NotificationDto()
                {
                    message = "World",
                    expirationTime = DateTime.Now.AddDays(2)
                }
            });
        }
    }
}
