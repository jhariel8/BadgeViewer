using BadgeViewer.Dal.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Dal.Repository
{
    public class BadgeDataRepository : IBadgeDataRepository
    {
        public BadgeDataRepository()
        {
            User = new UserDal();
            Notification = new NotificationDal();
        }

        public IUserDal User { get; private set; }

        public INotificationDal Notification { get; private set; }
    }
}
