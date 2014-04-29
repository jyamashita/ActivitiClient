using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Extensions
{
    public static class RestRequestExtention
    {
        public static IRestRequest AddParameterIfNotNull(this RestRequest @this, string name, object value)
        {
            if (value != null)
                return @this.AddParameter(name, value);
            else
                return @this;
        }
    }
}
