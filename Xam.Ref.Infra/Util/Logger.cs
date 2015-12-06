using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;

namespace Xam.Ref.Infra.Util
{
    public class Logger : ILogger
    {
        public void LogException(Exception ex)
        {
            // Save to Analytics or file or wherever    
        }

        public async Task Log(string description)
        {
            await Task.Run(() =>
            {
                // Save to Analytics or file or wherever    
            });

        }
    }
}
