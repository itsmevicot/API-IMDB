using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Utils
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly List<string> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<string>();
        }

        public void NotificarErro(string erro)
        {
            _notifications.Add(erro);
        }

        public bool TemErros()
        {
            return _notifications.Any();
        }

        public List<string> ObterErros()
        {
            return _notifications;
        }
    }
}
