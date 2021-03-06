﻿using ActivitiClient.Models.Exception;
using ActivitiClient.RestClients;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.RestClients
{
    public class ActivitiRestClient
    {
        private RestClient Client { get; set; }

        #region コンストラクタ
        public ActivitiRestClient(string baseurl, string user, string password)
        {
            this.Client = new RestClient(baseurl);
            this.Client.Authenticator = new HttpBasicAuthenticator(user, password);

            this.ProcessDefinitions = new ProcessDefinitions(this.Client);
            this.ProcessInstances = new ProcessInstances(this.Client);
            this.Forms = new Forms(this.Client);
            this.Tasks = new Tasks(this.Client);
            this.History = new History(this.Client);
            this.Deployment = new Deployment(this.Client);
        }
        #endregion

        #region RestClients
        public RestClients.ProcessDefinitions ProcessDefinitions { get; set; }

        public RestClients.ProcessInstances ProcessInstances { get; set; }

        public RestClients.Tasks Tasks { get; set; }

        public RestClients.Forms Forms { get; set; }

        public RestClients.History History { get; set; }

        public RestClients.Deployment Deployment { get; set; }
        #endregion
    }
}
