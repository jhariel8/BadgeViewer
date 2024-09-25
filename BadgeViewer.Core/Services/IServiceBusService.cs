using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeViewer.Core.Services
{
    public interface IServiceBusService
    {
        Task SendServiceBusMessageAsync(string message);
    }
}
