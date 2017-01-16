using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlossaryProject.Models.Responses
{
    public abstract class BaseResponse
    {
        public bool IsSuccessfull { get; set; }

        public string TransactionId { get; set; }

        public BaseResponse()
        {
            this.TransactionId = Guid.NewGuid().ToString();
        }
    }
}