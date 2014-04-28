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

            if (version != null) request.AddParameter("version", version);
            if (name != null) request.AddParameter("name", name);
            if (nameLike != null) request.AddParameter("nameLike", nameLike);
            if (key != null) request.AddParameter("key", key);
            if (keyLike != null) request.AddParameter("keyLike", keyLike);
            if (resourceName != null) request.AddParameter("resourceName", resourceName);
            if (resourceNameLike != null) request.AddParameter("resourceNameLike", resourceNameLike);
            if (category != null) request.AddParameter("category", category);
            if (categoryLike != null) request.AddParameter("categoryLike", categoryLike);
            if (categoryNotEquals != null) request.AddParameter("categoryNotEquals", categoryNotEquals);
            if (deploymentId != null) request.AddParameter("deploymentId", deploymentId);
            if (startableByUser != null) request.AddParameter("startableByUser", startableByUser);
            if (latest != null) request.AddParameter("latest", latest);
            if (suspended != null) request.AddParameter("suspended", suspended);
            if (sort != null) request.AddParameter("sort", sort.ToString());

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
