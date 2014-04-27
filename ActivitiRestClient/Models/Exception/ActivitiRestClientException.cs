using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiRestClient.Models.Exception
{
    class ActivitiRestClientException : System.Exception
    {
        public ActivitiRestClientException(string message) : base(message) { }
    }
}
