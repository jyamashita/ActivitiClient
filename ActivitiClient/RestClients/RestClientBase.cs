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

        protected RestClient Client { get; set; }

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
