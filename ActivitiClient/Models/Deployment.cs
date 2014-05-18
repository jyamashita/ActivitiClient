using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Models
{
    public class Deployment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DeploymentTime { get; set; }

        public string Category { get; set; }

        public string Url { get; set; }

        public string TenantId { get; set; }
    }
}
