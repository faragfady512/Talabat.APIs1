using System;
using System.Collections.Generic;

namespace Talabat.APIs1.Errors
{
    public class ValidationErrorsMessagecs : ApiErrorResponse
    {
   
        public  IEnumerable<string> Errors { get; set; }

        public ValidationErrorsMessagecs() : base(400)
        {


        }
    }
}
