using ActivitiRestClient.Models.Exception;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiRestClient
{
    public class ActivitiRestClient
    {
        public enum Sort { name, id, key, category, deploymentId, version }

        public enum Order { asc, desc }

        public RestClient Client { get; set; }

        public ActivitiRestClient(string baseurl, string user, string password)
        {
            this.Client = new RestClient(baseurl);
            this.Client.Authenticator = new HttpBasicAuthenticator(user, password);
        }

        public void HandleError(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created)
            {
                throw new ActivitiRestClientException(response.StatusDescription);
            }
        }
    }
}
