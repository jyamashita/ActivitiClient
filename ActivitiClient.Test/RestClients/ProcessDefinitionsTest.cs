using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActivitiClient.RestClients;

namespace ActivitiClient.Test.RestClients
{
    [TestClass]
    public class ProcessDefinitionsTest
    {
        ActivitiRestClient Client { get; set; }

        public ProcessDefinitionsTest()
        {
            this.Client = new ActivitiRestClient("http://localhost:8080/activiti-rest/service", "kermit", "kermit");
        }

        [TestMethod]
        public void ListTest()
        {
            var processDefinitions = this.Client.ProcessDefinitions.List(latest: true);
        }

        [TestMethod]
        public void GetTest()
        {
            var processDefinition = this.Client.ProcessDefinitions.Get("assessment:1:1612");
        }

        [TestMethod]
        public void GetBpmnByXmlTest()
        {
            var model = this.Client.ProcessDefinitions.GetResourcedata("assessment:1:1612");
        }
    }
}
