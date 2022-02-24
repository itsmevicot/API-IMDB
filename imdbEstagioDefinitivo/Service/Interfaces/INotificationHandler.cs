using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface INotificationHandler
    {
        void NotificarErro(string erro);
        bool TemErros();
        List<string> ObterErros();
    }
}
