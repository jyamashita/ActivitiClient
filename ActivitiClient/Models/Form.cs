using ActivitiClient.Models.Bpmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Models
{
    public class Form
    {
        public string FormKey { get; set; }

        public int DeploymentId { get; set; }

        public int ProcessDefinitionId { get; set; }

        public string processDefinitionUrl { get; set; }

        public int TaskId { get; set; }

        public string TaskUrl { get; set; }

        public List<FormProperty> FormProperties  { get; set; }
    }
}
