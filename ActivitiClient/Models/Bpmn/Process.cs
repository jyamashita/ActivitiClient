using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ActivitiClient.Models.Bpmn
{
    public class Process
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("isExecutable")]
        public bool IsExecutable { get; set; }

        [XmlElement("startEvent")]
        public List<Task> StartEvent { get; set; }

        [XmlElement("endEvent")]
        public List<Task> EndEvent { get; set; }

        [XmlElement("userTask")]
        public List<Task> UserTask { get; set; }
    }
}
