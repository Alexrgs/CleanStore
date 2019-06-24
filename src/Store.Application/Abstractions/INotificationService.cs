using Store.Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Abstractions
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
