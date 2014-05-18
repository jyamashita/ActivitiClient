using ActivitiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.RestClients
{
    public class VariableInstance
    {
        public int Id { get; set; }

        public int ProcessInstanceId { get; set; }

        public string ProcessInstanceUrl { get; set; }

        public int TaskId { get; set; }

        public Variable Variable { get; set; }
    }
}
