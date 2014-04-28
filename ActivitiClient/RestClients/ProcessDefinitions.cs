using ActivitiClient.Models;
using ActivitiClient.Models.Bpmn;
using ActivitiClient.RestClients;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ActivitiClient.Extensions;

namespace ActivitiClient.RestClients
{
    public class ProcessDefinitions : RestClientBase
    {
        public ProcessDefinitions(RestClient client) : base(client) { }

        #region List of process definitions
        public List<ProcessDefinition> List(
            int? version = null,
            string name = null,
            string nameLike = null,
            string key	= null,
            string keyLike = null,
            string resourceName = null,
            string resourceNameLike = null,
            string category = null,
            string categoryLike = null,
            string categoryNotEquals = null,
            string deploymentId = null,
            string startableByUser = null,
            bool? latest = null,
            bool? suspended = null,
            RestClientBase.Sort? sort = null)
        {
            var request = new RestRequest("repository/process-definitions", Method.GET);

            request.AddParameterIfNotNull("version", version);
            request.AddParameterIfNotNull("name", name);
            request.AddParameterIfNotNull("nameLike", nameLike);
            request.AddParameterIfNotNull("key", key);
            request.AddParameterIfNotNull("keyLike", keyLike);
            request.AddParameterIfNotNull("resourceName", resourceName);
            request.AddParameterIfNotNull("resourceNameLike", resourceNameLike);
            request.AddParameterIfNotNull("category", category);
            request.AddParameterIfNotNull("categoryLike", categoryLike);
            request.AddParameterIfNotNull("categoryNotEquals", categoryNotEquals);
            request.AddParameterIfNotNull("deploymentId", deploymentId);
            request.AddParameterIfNotNull("startableByUser", startableByUser);
            request.AddParameterIfNotNull("latest", latest);
            request.AddParameterIfNotNull("suspended", suspended);
            request.AddParameterIfNotNull("sort", sort);

            var response = base.Client.Execute<DataSet<ProcessDefinition>>(request);
            base.HandleError(response);
            return response.Data.GetData();
        }
        #endregion

        #region Get a process definition
        public ProcessDefinition Get(string processDefinitionId)
        {
            var request = new RestRequest("repository/process-definitions/{processDefinitionId}", Method.GET);
            request.AddUrlSegment("processDefinitionId", processDefinitionId);
            var response = this.Client.Execute<ProcessDefinition>(request);
            base.HandleError(response);
            return response.Data;
        }
        #endregion

        #region Get a process definition resource content
        public Process GetResourcedata(string processDefinitionId)
        {
            var request = new RestRequest("repository/process-definitions/{processDefinitionId}/resourcedata", Method.GET);
            request.AddUrlSegment("processDefinitionId", processDefinitionId);
            var response = base.Client.Execute(request);
            base.HandleError(response);
            var serializer = new XmlSerializer(typeof(Definitions));
            Definitions definitions = null;
            using (var crd = new StringReader(response.Content)) {
                definitions = serializer.Deserialize(crd) as Definitions;
            }
            return definitions.Process;
        }
        #endregion
    }
}
