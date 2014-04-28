using ActivitiClient.Models;
using ActivitiClient.RestClients;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.RestClients
{
    public class Tasks : RestClientBase
    {
        public Tasks(RestClient client) : base(client) { }

        #region Get a task
        public Models.Task Get(int taskId)
        {
            var request = new RestRequest("runtime/tasks/{taskId}", Method.GET);
            request.AddUrlSegment("taskId", taskId.ToString());
            var response = base.Client.Execute<Models.Task>(request);
            base.HandleError(response);
            return response.Data;
        }
        #endregion

        #region Get a task
        public Models.Task List(int taskId)
        {
            var request = new RestRequest("runtime/tasks", Method.GET);

            var response = base.Client.Execute<Models.Task>(request);
            base.HandleError(response);

            return response.Data;
        }
        #endregion
    }
}
