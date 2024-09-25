using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Dal.Models
{
    public class UserDto
    {
        public Guid uid { get; set; }
        public string username { get; set; }
        public DateTime lastviewedtime { get; set; }
        public string @class { get; set; }
    }
}
