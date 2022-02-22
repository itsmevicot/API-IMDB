using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Role : byte
    {
        [Description("Usuario")]
        Usuario = 1,
        [Description("Administrador")]
        Administrador = 2
    }
}
