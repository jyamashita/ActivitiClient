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

        public string ProcessDefinitionId { get; set; }

        public string processDefinitionUrl { get; set; }

        public int TaskId { get; set; }

        public string TaskUrl { get; set; }

        public List<FormProperty> FormProperties  { get; set; }

        public List<ActivitiClient.Models.Bpmn.FormProperty> DetailFormProperties(List<Variable> variables)
        {
            var formProperties = this.FormProperties.Select(v => {
                var variable = variables.SingleOrDefault(p => p.Name == v.Id);
                return new ActivitiClient.Models.Bpmn.FormProperty {
                    Id = v.Id,
                    Name = v.Name,
                    EnumValues = v.EnumValues,
                    DatePattern = v.DatePattern,
                    IsReadable = v.IsReadable,
                    IsRequired = v.IsRequired,
                    Type = v.Type,
                    Value = variable.Value,
                    IsWritable = false,
                };
            }).ToList();
            return formProperties;
        }
    }
}
