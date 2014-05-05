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
    public class Forms : RestClientBase
    {
        public Forms(RestClient client) : base(client) { }

        #region Get form data
        public Form Get(int? taskId = null, string processDefinitionId = null)
        {
            var request = new RestRequest("form/form-data", Method.GET);
            request.AddParameterIfNotNull("taskId", taskId);
            request.AddParameterIfNotNull("processDefinitionId", processDefinitionId);
            var response = base.Client.Execute<Form>(request);
            base.HandleError(response);
            return response.Data;
        }
        #endregion

        #region Submit task form data
        public Models.Task Post(
            int? taskId = null,
            string processDefinitionId = null,
            string businessKey = null,
            NameValueCollection collection = null)
        {
            var request = new RestRequest("form/form-data", Method.POST);
            request.AddParameter("taskId", taskId.ToString());
            request.AddParameter("processDefinitionId", processDefinitionId);
            var param = (from name in collection.AllKeys
                        select new { name, value = collection.Get(name) }).ToList();
            var json = new {
                taskId = taskId,
                processDefinitionId = processDefinitionId,
                businessKey = businessKey,
                properties = param,
            };
            request.RequestFormat = DataFormat.Json;
            request.AddBody(json);
            var response = base.Client.Execute<Models.Task>(request);
            base.HandleError(response);
            return response.Data;
        }
        #endregion
    }
}
