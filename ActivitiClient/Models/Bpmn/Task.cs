using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ActivitiClient.Models.Bpmn
{
    public class Task
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("initiator", Namespace = "http://activiti.org/bpmn")]
        public string Initiator { get; set; }

        [XmlArray("extensionElements")]
        [XmlArrayItem("formProperty", Namespace = "http://activiti.org/bpmn")]
        public List<FormProperty> FormProperty { get; set; }

        #region メソッド
        public NameValueCollection Extract(NameValueCollection form)
        {
            var param = new NameValueCollection();
            this.FormProperty.ForEach(prop => {
                if (!prop.Id.StartsWith("system_"))
                    param.Add(prop.Id, form.Get(prop.Id));
            });
            return param;
        }

        public List<ActivitiClient.Models.Bpmn.FormProperty> DetailFormProperties(List<Variable> variables)
        {
            var formProperties = this.FormProperty.Select(v => {
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

        #endregion
    }
}
