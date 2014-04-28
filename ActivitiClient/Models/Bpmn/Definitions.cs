using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ActivitiClient.Models.Bpmn
{
    [XmlRoot("definitions", Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL")]
    public class Definitions
    {
        [XmlAttribute("targetNamespace")]
        public string TargetNamespace { get; set; }

        [XmlElement("process")]
        public Process Process { get; set; }
    }
}
