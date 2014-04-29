using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActivitiClient.RestClients;
using System.Collections.Specialized;

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
        public void StartTest()
        {
            var collection = new NameValueCollection();
            collection.Add("title", "タイトル");
            collection.Add("level", "5");
            collection.Add("approver", "test01");
            collection.Add("system-test", "テスト値");
            var processDefinition = this.Client.ProcessInstances.Start("assessment:4:1712",
                collection: collection);
        }
    }
}
