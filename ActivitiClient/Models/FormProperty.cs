using ActivitiClient.Models.Bpmn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ActivitiClient.Models
{
    public class FormProperty : Bpmn.FormProperty
    {
        new public bool Readable
        {
            get { return base.IsReadable; }
            set { base.IsReadable = value; }
        }

        new public bool Writable
        {
            get { return base.IsWritable; }
            set { base.IsWritable = value; }
        }

        new public bool Required
        {
            get { return base.IsRequired; }
            set { base.IsRequired = value; }
        }
    }
}
