using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        #region メソッド
        public NameValueCollection Extract(NameValueCollection form)
        {
            var taskDefitionId = form.Get("taskDefitionId");
            Bpmn.Task task = null;
            if (StartEvent.Any(t => t.Id == taskDefitionId))
                task = StartEvent.Single(t => t.Id == taskDefitionId);
            if (EndEvent.Any(t => t.Id == taskDefitionId))
                task = EndEvent.Single(t => t.Id == taskDefitionId);
            if (UserTask.Any(t => t.Id == taskDefitionId))
                task = UserTask.Single(t => t.Id == taskDefitionId);

            return task.Extract(form);
        }

        public List<FormProperty> FormProperties()
        {
            var tasks = new List<Task>();
            tasks.Add(StartEvent[0]);
            tasks.AddRange(UserTask);

            var map = new Dictionary<string, FormProperty>();
            tasks.ForEach(t => {
                var formProperty = t.FormProperty;
                formProperty.ForEach(p => {
                    if (!map.Any(m => m.Key == p.Id))
                        map.Add(p.Id, p);
                    else
                        map[p.Id] = p;
                });
            });

            return map.Select(m => m.Value).ToList();
        }
        #endregion
    }
}
