using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xam.Ref.Infra.Interfaces
{
    public interface IUserDialog
    {
        void ShowAlert(string heading, string message);
    }
}
