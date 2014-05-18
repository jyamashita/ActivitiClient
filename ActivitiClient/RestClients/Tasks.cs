using ActivitiClient.Models;
using ActivitiClient.RestClients;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitiClient.Extensions;

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

        #region List of tasks
        public Models.Task List(
            string name = null, string nameLike = null, string description = null, int? priority = null,
            int? minimumPriority = null, int? maximumPriority = null, string assignee = null, string assigneeLike = null,
            string owner = null, string ownerLike = null, bool? unassigned = null, string delegationState = null,
            string candidateUser = null, string candidateGroup = null, string involvedUser = null,
            string taskDefinitionKey = null, string taskDefinitionKeyLike = null,
            string processInstanceId = null, string processInstanceBusinessKey = null,
            string processInstanceBusinessKeyLike = null, string processDefinitionKey = null,
            string processDefinitionKeyLike = null, string processDefinitionName = null,
            string processDefinitionNameLike = null, string executionId = null,
            DateTime? createdOn = null, DateTime? createdBefore = null, DateTime? createdAfter = null,
            DateTime? dueOn = null, DateTime? dueBefore = null, DateTime? dueAfter = null,
            bool? withoutDueDate = null, bool? excludeSubTasks = null, bool? active = null,
            bool? includeTaskLocalVariables = null, bool? includeProcessVariables = null,
            string tenantId = null, string tenantIdLike = null, string withoutTenantId = null)
        {
            var request = new RestRequest("runtime/tasks", Method.GET);

            request.AddParameterIfNotNull("name", name);
            request.AddParameterIfNotNull("nameLike", nameLike);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("priority", priority);
            request.AddParameterIfNotNull("minimumPriority", minimumPriority);
            request.AddParameterIfNotNull("maximumPriority", maximumPriority);
            request.AddParameterIfNotNull("assignee", assignee);
            request.AddParameterIfNotNull("assigneeLike", assigneeLike);
            request.AddParameterIfNotNull("owner", owner);
            request.AddParameterIfNotNull("ownerLike", ownerLike);
            request.AddParameterIfNotNull("unassigned", unassigned);
            request.AddParameterIfNotNull("delegationState", delegationState);
            request.AddParameterIfNotNull("candidateUser", candidateUser);
            request.AddParameterIfNotNull("candidateGroup", candidateGroup);
            request.AddParameterIfNotNull("involvedUser", involvedUser);
            request.AddParameterIfNotNull("taskDefinitionKey", taskDefinitionKey);
            request.AddParameterIfNotNull("taskDefinitionKeyLike", taskDefinitionKeyLike);
            request.AddParameterIfNotNull("processInstanceId", processInstanceId);
            request.AddParameterIfNotNull("processInstanceBusinessKey", processInstanceBusinessKey);
            request.AddParameterIfNotNull("processInstanceBusinessKeyLike", processInstanceBusinessKeyLike);
            request.AddParameterIfNotNull("processDefinitionKey", processDefinitionKey);
            request.AddParameterIfNotNull("processDefinitionKeyLike", processDefinitionKeyLike);
            request.AddParameterIfNotNull("processDefinitionName", processDefinitionName);
            request.AddParameterIfNotNull("processDefinitionNameLike", processDefinitionNameLike);
            request.AddParameterIfNotNull("executionId", executionId);
            request.AddParameterIfNotNull("createdOn", createdOn.Value.ToString(RestClientBase.ISO_DATE));
            request.AddParameterIfNotNull("createdBefore", createdBefore.Value.ToString(RestClientBase.ISO_DATE));
            request.AddParameterIfNotNull("createdAfter", createdAfter.Value.ToString(RestClientBase.ISO_DATE));
            request.AddParameterIfNotNull("dueOn", dueOn.Value.ToString(RestClientBase.ISO_DATE));
            request.AddParameterIfNotNull("dueBefore", dueBefore.Value.ToString(RestClientBase.ISO_DATE));
            request.AddParameterIfNotNull("dueAfter", dueAfter.Value.ToString(RestClientBase.ISO_DATE));
            request.AddParameterIfNotNull("withoutDueDate", withoutDueDate);
            request.AddParameterIfNotNull("excludeSubTasks", excludeSubTasks);
            request.AddParameterIfNotNull("active", active);
            request.AddParameterIfNotNull("includeTaskLocalVariables", includeTaskLocalVariables);
            request.AddParameterIfNotNull("includeProcessVariables", includeProcessVariables);
            request.AddParameterIfNotNull("tenantId", tenantId);
            request.AddParameterIfNotNull("tenantIdLike", tenantIdLike);
            request.AddParameterIfNotNull("withoutTenantId", withoutTenantId);

            var response = base.Client.Execute<Models.Task>(request);
            base.HandleError(response);

            return response.Data;
        }
        #endregion

        #region Task actions
        public void Post(int taskId, RestClientBase.Action action,
            NameValueCollection variables = null,
            string assignee = null)
        {
            var request = new RestRequest("runtime/tasks/{taskId}", Method.POST);
            request.AddUrlSegment("taskId", taskId.ToString());

            var param = (from name in variables.AllKeys
                         select new { name, value = variables.Get(name) }).ToList();
            var json = new {
                action = action.ToString(),
                variables = param,
                assignee = assignee,
            };
            request.RequestFormat = DataFormat.Json;
            request.AddBody(json);
            var response = base.Client.Execute<Models.Task>(request);
            base.HandleError(response);
        }
        #endregion
    }
}
