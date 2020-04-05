using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.WebAPIService.Models
{
    public abstract class BaseResponse
    {
        public List<string> Errors { get; set; }
        public bool HasErrors { get; set; }
        public bool IsSuccesful { get; set; }

    }
}
