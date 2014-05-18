using ActivitiClient.Models.Bpmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Models
{
    public class Variable
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public string Scope { get; set; }
    }
}
