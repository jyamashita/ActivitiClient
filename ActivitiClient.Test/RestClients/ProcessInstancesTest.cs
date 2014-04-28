using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActivitiClient.RestClients;

namespace ActivitiClient.Test.RestClients
{
    [TestClass]
    public class ProcessInstancesTest
    {
        ActivitiRestClient Client { get; set; }

        public ProcessInstancesTest()
        {
            this.Client = new ActivitiRestClient("http://localhost:8080/activiti-rest/service", "kermit", "kermit");
        }

        [TestMethod]
        public void GetTest()
        {
            var processDefinitions = this.Client.ProcessInstances.Get(1);
        }

        [TestMethod]
        public void GetTest()
        {
            var processDefinition = this.Client.ProcessInstances.Start("assessment:1:1612");
        }
    }
}
