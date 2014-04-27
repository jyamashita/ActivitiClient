using ActivitiRestClient.Models;
using ActivitiRestClient.Models.Bpmn;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ActivitiRestClient
{
    public class ActivitiRestClient_ProcessInstances
    {
        #region GetProcessDefinitions
        public List<ProcessDefinition> GetProcessDefinitions(this ActivitiRestClient @this,
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
            ActivitiRestClient.Sort? sort = null)
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

            var response = @this.Client.Execute<ProcessDefinitions>(request);

            @this.HandleError(response);

            var processDefinitions = response.Data;
            var processDefinitionList = processDefinitions.Data;
            if (processDefinitionList.Capacity <= processDefinitions.Total)
                processDefinitionList.Capacity = processDefinitions.Total;
            else
                processDefinitionList.Capacity = processDefinitionList.Count;

            return processDefinitionList;
        }
        #endregion

        #region GetProcessDefinition
        public ProcessDefinition GetProcessDefinition(this ActivitiRestClient @this, string processDefinitionId)
        {
            var request = new RestRequest("repository/process-definitions/{processDefinitionId}", Method.GET);
            request.AddUrlSegment("processDefinitionId", processDefinitionId);
            var response = @this.Client.Execute<ProcessDefinition>(request);
            @this.HandleError(response);
            return response.Data;
        }
        #endregion

        #region Get a process definition BPMN model
        public Process GetProcessBpmnModel(this ActivitiRestClient @this, string processDefinitionId)
        {
            var request = new RestRequest("repository/process-definitions/{processDefinitionId}/model", Method.GET);
            request.AddUrlSegment("processDefinitionId", processDefinitionId);
            var response = @this.Client.Execute(request);
            @this.HandleError(response);
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
