using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Application.Common.Responses
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
    }
}
