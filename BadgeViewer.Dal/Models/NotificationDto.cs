using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Dal.Models
{
    public class NotificationDto
    {
        public string message { get; set; }
        public DateTime expirationTime { get; set; }
    }
}
