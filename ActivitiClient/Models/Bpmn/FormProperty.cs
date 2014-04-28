using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ActivitiClient.Models.Bpmn
{
    public class FormProperty
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("readable")]
        public bool Readable { get; set; }

        [XmlAttribute("writable")]
        public bool Writable { get; set; }

        [XmlAttribute("required")]
        public bool Required { get; set; }

        [XmlAttribute("datePattern")]
        public string DatePattern { get; set; }

        [XmlElement("value", Namespace = "http://activiti.org/bpmn")]
        public List<EnumValue> EnumValues { get; set; }
    }
}
