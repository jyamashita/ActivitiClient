using ActivitiClient.RestClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Models
{
    class DataSet<T>
    {
        public List<T> Data { get; set; }

        public int Total { get; set; }

        public int Start { get; set; }

        public RestClientBase.Sort Sort { get; set; }

        public RestClientBase.Order Order { get; set; }

        public int Size { get; set; }

        #region GetData
        public List<T> GetData()
        {
            if (this.Data.Capacity <= this.Total)
                this.Data.Capacity = this.Total;
            else
                this.Data.Capacity = this.Data.Count;
            return this.Data;
        }
        #endregion
    }
}
