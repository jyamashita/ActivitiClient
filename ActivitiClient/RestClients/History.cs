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

namespace ActivitiClient.RestClients
{
    public class History : RestClientBase
    {
        public History(RestClient client) : base(client) { }

        #region Get a historic process instance
        public Models.History Get(int processInstanceId)
        {
            var request = new RestRequest("history/historic-process-instances/{processInstanceId}", Method.GET);
            request.AddUrlSegment("processInstanceId", processInstanceId.ToString());
            var response = base.Client.Execute<Models.History>(request);
            base.HandleError(response);
            return response.Data;
        }
        #endregion

        #region List of historic variable instances
        public List<VariableInstance> VariableInstances(int processInstanceId)
        {
            var request = new RestRequest("history/historic-variable-instances", Method.GET);
            request.AddParameter("processInstanceId", processInstanceId.ToString());
            var response = base.Client.Execute<DataSet<VariableInstance>>(request);
            base.HandleError(response);
            return response.Data.GetData();
        }
        #endregion
    }
}
