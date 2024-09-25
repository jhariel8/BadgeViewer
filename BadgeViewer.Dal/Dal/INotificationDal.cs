using BadgeViewer.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Dal.Dal
{
    public interface INotificationDal
    {
        Task<List<NotificationDto>> ReadByUserUID(Guid uid);
    }
}
