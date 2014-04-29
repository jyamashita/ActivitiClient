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
    public class ProcessInstances : RestClientBase
    {
        public ProcessInstances(RestClient client) : base(client) { }

        #region Get a process instance
        public ProcessInstance Get(int processInstanceId)
        {
            var request = new RestRequest("runtime/process-instances/{processInstanceId}", Method.GET);
            request.AddUrlSegment("processDefinitionId", processInstanceId.ToString());
            var response = base.Client.Execute<ProcessInstance>(request);
            base.HandleError(response);
            return response.Data;
        }
        #endregion

        #region Start a process instance
        public ProcessInstance Start(
            string processDefinitionId,
            NameValueCollection collection = null,
            string businessKey = null,
            string tenantId = null,
            string message = null)
        {
            var request = new RestRequest("runtime/process-instances", Method.POST);
            var param = (from name in collection.AllKeys
                        select new { name, value = collection.Get(name) }).ToList();
            var json = new {
                processDefinitionId = processDefinitionId,
                variables = param,
                businessKey = businessKey,
                tenantId = tenantId,
                message = tenantId,
            };
            request.RequestFormat = DataFormat.Json;
            request.AddBody(json);
            var response = base.Client.Execute<ProcessInstance>(request);
            base.HandleError(response);
            return response.Data;
        }
        #endregion
    }
}
