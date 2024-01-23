using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BO
{
    public class APIResponse
    {
        public APIResponse()
        {
            errorMessage = new List<string>();
        }
        public HttpStatusCode statuCode { get; set; }
        public bool isSuccess { get; set; } = true;
        public List<string> errorMessage { get; set; }
        public object Result { get; set; }
    }
}
