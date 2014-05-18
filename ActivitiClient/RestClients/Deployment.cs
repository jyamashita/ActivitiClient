using ActivitiClient.Models;
using ActivitiClient.Extensions;
using ActivitiClient.RestClients;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ActivitiClient.RestClients
{
    public class Deployment : RestClientBase
    {
        public Deployment(RestClient client) : base(client) { }

        #region Create a new deployment
        public Models.Deployment Create(Stream depfile, string filename)
        {
            var request = new RestRequest("repository/deployments", Method.POST);
            request.AddFile("deployfile", (s) => { depfile.CopyTo(s); }, filename);
            var response = base.Client.Execute<Models.Deployment>(request);
            base.HandleError(response);
            return response.Data;
        }
        #endregion
    }
}
