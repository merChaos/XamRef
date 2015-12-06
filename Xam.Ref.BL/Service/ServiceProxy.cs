using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xam.Ref.Infra.Interfaces;
using Xam.Ref.Infra.Ioc;
using Xam.Ref.Models;

namespace Xam.Ref.BL.Service
{
    public class ServiceProxy : IServiceProxy
    {
        private const string HEADER_JSON = "application/json";

        public async Task<IServiceResult<User>> AuthenticateUserAsync(LoginDetails loggedInUser)
        {
            using (HttpClient client = new HttpClient())
            {
                var requestJson = JsonConvert.SerializeObject(loggedInUser);
                client.DefaultRequestHeaders.Add("id", loggedInUser.UserId);
                var response = await client.PostAsync("", new StringContent(requestJson, Encoding.UTF8, HEADER_JSON));
                var returnVal = IocContainer.Resolve<IServiceResult<User>>();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    
                    // all success
                    var content = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<User>(content);
                    returnVal.IsSuccess = true;
                    returnVal.StatusCode = Convert.ToInt32(response.StatusCode).ToString();
                    returnVal.Result = loginResponse;
                }
                else
                {
                    returnVal.IsSuccess = false;
                    returnVal.StatusCode = Convert.ToInt32(response.StatusCode).ToString();
                    //returnVal.Result = null;                       
                }
                return returnVal;
            }
        }

        #region IDisposable Members

        //Implement IDisposable Correctly
        //http://msdn.microsoft.com/en-us/library/ms244737(VS.80).aspx
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            // free native resources if there are any.

        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        /// <summary>
        /// Finalizes an instance of the <see cref="BaseView"/> class.
        /// </summary>
        ~ServiceProxy()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        #endregion
    }
}
