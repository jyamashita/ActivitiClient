using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Models
{
    public class Task
    {
        public string Assignee { get; set; }

        public DateTime CreateTime { get; set; }

        public string DelegationState { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Execution { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string ParentTask { get; set; }

        public int Priority { get; set; }

        public string ProcessDefinition { get; set; }

        public string ProcessInstance { get; set; }

        public string Suspended { get; set; }

        public string TaskDefinitionKey { get; set; }

        public string Url { get; set; }

        public string TenantId { get; set; }
    }
}
