using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xam.Ref.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }

    }

    public class LoginDetails
    {
        public string UserId { get; set; }

        public string Password { get; set; }
    }
}
