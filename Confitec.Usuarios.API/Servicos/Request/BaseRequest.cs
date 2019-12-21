using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace Confitec.Usuarios.API.Servicos.Request
{
    public abstract class BaseRequest : Notifiable, IValidatable
    {
        public abstract void Validate();
    }
}
