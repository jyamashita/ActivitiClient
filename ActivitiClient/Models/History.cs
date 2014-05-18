using ActivitiClient.Models.Bpmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Models
{
    public class History
    {
        public int Id {get; set;}

        public string Url {get; set;}

        public string BusinessKey {get; set;}

        public string ProcessDefinitionId {get; set;}

        public string ProcessDefinitionUrl {get; set;}

        public DateTime StartTime {get; set;}

        public DateTime EndTime { get; set; }

        public string DurationInMillis {get; set;}

        public string StartUserId {get; set;}

        public string StartActivityId {get; set;}

        public string EndActivityId {get; set;}

        public string DeleteReason {get; set;}

        public string SuperProcessInstanceId { get; set; }

        public List<Variable> Variables { get; set; }

        public string TenantId { get; set; }
    }
}
