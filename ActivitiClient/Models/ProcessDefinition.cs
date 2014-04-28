using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Models
{
    public class ProcessDefinition
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public int Version  { get; set; }

        public string Key { get; set; }

        public string Category { get; set; }

        public bool Suspended { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DeploymentId { get; set; }

        public string DeploymentUrl { get; set; }

        public bool GraphicalNotationDefined { get; set; }

        public string Resource { get; set; }

        public string DiagramResource { get; set; }

        public bool StartFormDefined { get; set; }
    }
}
