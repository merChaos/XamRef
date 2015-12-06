using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;
using Xam.Ref.Models;

namespace Xam.Ref.BL
{
    public static class UserManager
    {
        static ILogger logger = IocContainer.Resolve<ILogger>();

        public static async Task<bool> AuthenticateUser(LoginDetails loggedInUser)
        {
            // NOTE: This should be in Using. 
            var serviceProxy = IocContainer.Resolve<IServiceProxy>();
            var userDal = IocContainer.Resolve<IRepository<User>>();

            try
            {
                // Call the service
                var serviceResult = await serviceProxy.AuthenticateUserAsync(loggedInUser);

                if (serviceResult.IsSuccess)
                {
                    // if service is successful Save to local DB
                    userDal.Save(serviceResult.Result);
                    return true;
                }
                else
                {
                    // else return false
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log exception - generic
                logger.LogException(ex);
                return false;
            }
            finally
            {
                serviceProxy = null;
                userDal = null;
            }


        }
    }
}
