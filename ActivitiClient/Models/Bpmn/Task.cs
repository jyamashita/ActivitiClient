using System;
using System.Collections.Generic;
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
        [XmlArrayItem("formProperty ", Namespace = "activiti")]
        public List<FormProperty> FormProperty { get; set; }
    }
}
