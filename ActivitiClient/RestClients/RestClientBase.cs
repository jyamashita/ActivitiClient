using ActivitiClient.Models;
using ActivitiClient.Models.Exception;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.RestClients
{
    public class RestClientBase
    {
        public enum Sort { name, id, key, category, deploymentId, version }

        public enum Order { asc, desc }

        public enum Action { complete, claim, @delegate, resolve }

        protected RestClient Client { get; set; }

        #region const
        protected const string ISO_DATE = "YYYY-MM-DDThh:mm:sssTZD";
        #endregion

        public RestClientBase(RestClient client)
        {
            this.Client = client;
        }

        #region HandleError
        protected void HandleError(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created)
            {
                throw new ActivitiRestClientException(response.StatusDescription);
            }
        }
        #endregion
    }
}
