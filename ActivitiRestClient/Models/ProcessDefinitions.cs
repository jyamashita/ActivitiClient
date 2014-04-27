using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiRestClient.Models
{
    public class ProcessDefinitions
    {
        public List<ProcessDefinition> Data { get; set; }

        public int Total { get; set; }

        public int Start { get; set; }

        public ActivitiRestClient.Sort Sort { get; set; }

        public ActivitiRestClient.Order Order { get; set; }

        public int Size { get; set; }
    }
}
