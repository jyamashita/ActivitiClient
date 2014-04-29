using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiClient.Extensions
{
    public static class StringExtention
    {
        public static int ToInt(this string @this)
        {
            return int.Parse(@this);
        }
    }
}
