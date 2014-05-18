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

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("readable")]
        public bool Readable { get; set; }

        [XmlIgnore]
        public bool ReadableSpecified { get; set; }

        [XmlIgnore]
        public virtual bool IsReadable
        {
            get { return !ReadableSpecified; }
            set
            {
                Readable = false;
                ReadableSpecified = !value;
            }
        }

        [XmlAttribute("writable")]
        public bool Writable { get; set; }

        [XmlIgnore]
        public bool WritableSpecified { get; set; }

        [XmlIgnore]
        public virtual bool IsWritable
        {
            get { return !WritableSpecified; }
            set
            {
                Writable = false;
                WritableSpecified = !value;
            }
        }

        [XmlAttribute("required")]
        public bool Required { get; set; }

        [XmlIgnore]
        public bool RequiredSpecified { get; set; }

        [XmlIgnore]
        public virtual bool IsRequired
        {
            get { return Required; }
            set
            {
                Required = value;
                RequiredSpecified = value;
            }
        }

        [XmlAttribute("datePattern")]
        public string DatePattern { get; set; }

        [XmlElement("value", Namespace = "http://activiti.org/bpmn")]
        public List<EnumValue> EnumValues { get; set; }

        public bool AsBoolValue()
        {
            var ret = false;
            bool.TryParse(this.Value, out ret);
            return ret;
        }

        public long AslongValue()
        {
            var ret = 0L;
            long.TryParse(this.Value, out ret);
            return ret;
        }

        public DateTime AsDateTimeValue()
        {
            var ret = DateTime.MinValue;
            DateTime.TryParse(this.Value, out ret);
            return ret;
        }
    }
}
