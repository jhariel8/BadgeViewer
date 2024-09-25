using BadgeViewer.Dal.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Dal.Repository
{
    public interface IBadgeDataRepository
    {
        IUserDal User { get; }

        INotificationDal Notification { get; }
    }
}
