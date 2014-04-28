using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Models
{
    public class ProcessInstance
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string BusinessKey { get; set; }

        public bool Suspended { get; set; }

        public string ProcessDefinitionUrl { get; set; }

        public string ActivityId { get; set; }

        public string TenantId { get; set; }
    }
}
